﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Xml;
using Newtonsoft.Json;


namespace UpdateApp
{
    public partial class UpdateForm : Form
    {
        private static string GitConfigWebUrl = @"http://www.ziyangsoft.com/Config.ashx";
        //private static string webUrl2 = @"http://www.ziyangsoft.com/filelist.ashx?InstallOrUpdate=Update";
        //private static string webUrl3 = @"http://www.ziyangsoft.com/GetFileMD5.ashx";
        private static string systemName = "XTHospital";
        delegate void ShowProgressDelegate(int totalStep, int currentStep);
        private static string UpdataURLConfig = "InstallURL";
        private static string InstallPathConfig = "InstallPath";
        private WebClient downWebClient = new WebClient();
        private static string InstallURL=string.Empty;
        private static long size;//所有文件大小 
        private static int count;//文件总数 
        /// <summary>
        /// 更新文件列表
        /// </summary>
        private static string[] fileNames;
        private static int num=0;//已更新文件数 
        private static long upsize;//已更新文件大小 
        private static string fileName="Update.zip";//当前文件名 
        private static long filesize;//当前文件大小
        private static string InstallPath = @"C:\XTHospital";//安装路径，默认C盘
        private static string LastAppNoConfig = "LastAppNo";
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            //dirPath = ConfigurationManager.AppSettings["WebServicesURL"].Trim();
            //updateURL = Common.GetConfigFormIni();
            try
            {
                InstallURL = GetWebConfig(UpdataURLConfig);//http://www.ziyangsoft.com/App/Install
                InstallPath = GetWebConfig(InstallPathConfig);//C:\XTHospital
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //if (string.IsNullOrEmpty(Common.globalAppVNo)&& string.IsNullOrEmpty(Common.globalAppMD5No))
            if (string.IsNullOrEmpty(Common.globalUpdateList))
            {
                this.Height = 450;                
            }
            else
            {
                this.Height = 142;                
                //this.Text ="自动更新程序---------" + Common.globalAppVNo + "@" + Common.globalAppMD5No;

                this.Text = "自动更新程序=====>" + Common.globalUpdateList;
                UpdaterStart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string LastAppNo = GetWebConfig(LastAppNoConfig);
            string LastAppNo = GetServerUpdateFileMD5();
            //string OldAppNo = GetAppNo();
            string OldAppNo = GetAppNoFromTxt();
            if (!LastAppNo.Equals(OldAppNo)
                && MessageBox.Show("需要更新，要更新吗？","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                //string[] strTemp = LastAppNo.Split('@');
                //Common.globalAppVNo = strTemp[0];
                //Common.globalAppMD5No = strTemp[1];
                //Common.globalAppMD5No = LastAppNo;
                UpdaterStart();
                //btnUpdate.Enabled = false;
            }
        }

        /// <summary>
        /// 从配置文件中获取程序号
        /// </summary>
        /// <returns></returns>
        public static string GetAppNo()
        {
            string filePath = InstallPath + "\\Update.ini";
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string s = string.Empty;
            string version = string.Empty;
            int lines = 0;
            while ((s = sr.ReadLine()) != null && lines<2)
            {
                version = version + "@" + s;
                lines++;
            }
            if (version.IndexOf("@") == 0)
            {
                version = version.Substring(1);
            }
            sr.Close();
            return version;
        }

        /// <summary>
        /// 从配置文件中获取程序号
        /// </summary>
        /// <returns></returns>
        public static string GetAppNoFromTxt()
        {
            string filePath = InstallPath + "\\Update.ini";
            string[] strs = File.ReadAllLines(filePath);
            if (strs.Length > 0)
            {
                return strs[0];
            }
            else
            {
                return "";
            }
        }

        /// <summary> 
        /// 获取更新文件大小统计 
        /// </summary> 
        /// <param name="filePath">更新文件数据XML</param> 
        /// <returns>返回值</returns> 
        private static long GetUpdateSize(string filePath)
        {
            long len;
            len = 0;
            try
            {
                WebClient wc = new WebClient();
                Stream sm = wc.OpenRead(filePath);
                XmlTextReader xr = new XmlTextReader(sm);
                while (xr.Read())
                {
                    if (xr.Name == "UpdateSize")
                    {
                        len = Convert.ToInt64(xr.GetAttribute("Size"), CultureInfo.InvariantCulture);
                        break;
                    }
                }
                xr.Close();
                sm.Close();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return len;
        }

        /// <summary> 
        /// 转换字节大小 
        /// </summary> 
        /// <param name="byteSize">输入字节数</param> 
        /// <returns>返回值</returns> 
        private static string ConvertSize(long byteSize)
        {
            string str = "";
            float tempf = (float)byteSize;
            if (tempf / 1024 > 1)
            {
                if ((tempf / 1024) / 1024 > 1)
                {
                    str = ((tempf / 1024) / 1024).ToString("##0.00", CultureInfo.InvariantCulture) + "MB";
                }
                else
                {
                    str = (tempf / 1024).ToString("##0.00", CultureInfo.InvariantCulture) + "KB";
                }
            }
            else
            {
                str = tempf.ToString(CultureInfo.InvariantCulture) + "B";
            }
            return str;
        }

        /// <summary> 
        /// 获取文件列表并下载 
        /// </summary> 
        private static void GetDownloadFileList()
        {
            fileNames = new string[] { "Update.zip" };
            try
            {
                string strRet = string.Empty;
                WebRequest req = WebRequest.Create(@"http://ziyangsoft.com/filelist.ashx?InstallOrUpdate=Update");
                WebResponse res = req.GetResponse();
                System.IO.Stream resStream = res.GetResponseStream();
                Encoding encode = System.Text.Encoding.Default;
                StreamReader readStream = new StreamReader(resStream, encode);
                Char[] read = new Char[256];
                int count = readStream.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    strRet = strRet + str;
                    count = readStream.Read(read, 0, 256);
                }
                resStream.Close();
                readStream.Close();
                res.Close();
                fileNames = strRet.Split('|');
            }
            catch
            { }
            finally
            {
            }
        }

        private static void GetUpdateFileList()
        {
            fileNames = Common.globalUpdateList.Split('|');
        }

        public static string EncryptPWD(string password)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        }

        /// <summary> 
        /// 开始更新 
        /// </summary> 
        private void UpdaterStart()
        {
            float tempf;
            //委托下载数据时事件 
            this.downWebClient.DownloadProgressChanged += delegate(object wcsender, DownloadProgressChangedEventArgs ex)
            {
                lbMessageSize.Text = String.Format(
                    CultureInfo.InvariantCulture,
                    "正在下载:{0}  [ {1}/{2} ]",
                    fileName.Replace(".zip",""),
                    ConvertSize(ex.BytesReceived),
                    ConvertSize(ex.TotalBytesToReceive));

                tempf = (float)ex.BytesReceived / (float)ex.TotalBytesToReceive;
                progressBarSize.Value = Convert.ToInt32(tempf * 100);
            };
            //委托下载完成时事件 
            this.downWebClient.DownloadFileCompleted += delegate(object wcsender, AsyncCompletedEventArgs ex)
            {
                if (ex.Error != null)
                {
                    MessageBox.Show(ex.Error.Message);
                }
                else
                {
                    //if (fileName.EndsWith(".zip"))
                    //{
                        //获取程序包的MD5值
                        //string appMD5 = Common.GetMD5HashFromFile(appPath + "\\" + fileName);
                        //if (!appMD5.Equals(Common.globalAppMD5No))
                        //{
                        //    MessageBox.Show("所下载的更新包不完整，请尝试重新启动程序。");
                        //    Application.Exit();
                        //    return;
                        //}
                        //解压缩
                        //Common.UnZipFile(appPath + "\\" + fileName, appPath);
                    //}
                    //移动下载包
                    //File.Move(Application.StartupPath + "\\AutoUpdater\\" + fileName, Application.StartupPath + "\\" + fileName);
                    if (num < fileNames.Length)
                    {
                        DownloadFile(num);
                    }
                    else
                    {   
                        //设置最新的程序号
                        //string[] newAppNo = { Common.globalAppVNo, Common.globalAppMD5No };
                        //SetConfigAppNo(newAppNo);
                        //SetConfigAppNo(Common.globalAppMD5No);//根据实际服务器文件列表更新,不需要更新本地配置列表                        
                        UpdaterClose();
                    }
                }
            };
            //GetDownloadFileList();
            GetUpdateFileList();
            DownloadFile(num);
        }

        /// <summary> 
        /// 下载文件 
        /// </summary> 
        /// <param name="arry">下载序号</param> 
        private void DownloadFile(int arry)
        {
            try
            {                
                fileName = fileNames[arry];
                num++;
                //删除已有的下载包
                if (File.Exists(InstallPath + "\\" + fileName))
                {
                    File.Delete(InstallPath + "\\" + fileName);
                }
                lbMessageFile.Text = String.Format(
                    CultureInfo.InvariantCulture,
                    "更新进度 {0}/{1}",
                    num,
                    fileNames.Length);
                progressBarFile.Value = Convert.ToInt32(((float)num / (float)fileNames.Length) * 100);
                if (!Directory.Exists(InstallPath))
                {
                    Directory.CreateDirectory(InstallPath);
                }
                string DownLoadURL = InstallURL + @"/" + fileName;
                //string SavePathName = appPath + "\\" + fileName;
                string SavePathName = InstallPath + "\\" + fileName.Substring(0, fileName.LastIndexOf(".zip"));
                this.downWebClient.DownloadFileAsync(
                    new Uri(DownLoadURL),
                    SavePathName);
            }
            catch (WebException ex)
            {
                MeBox(ex.Message);
            }
        }
        
        /// <summary> 
        /// 弹出提示框 
        /// </summary> 
        /// <param name="txt">输入提示信息</param> 
        private static void MeBox(string txt)
        {
            MessageBox.Show(
                txt,
                "提示信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        } 

        /// <summary> 
        /// 关闭程序 
        /// </summary> 
        private static void UpdaterClose()
        {            
            try
            {
                System.Diagnostics.Process.Start(InstallPath + @"\UI.exe", "Update");
            }
            catch (Win32Exception ex)
            {
                MeBox(ex.Message);
            }
            Application.Exit();
        }

        private void btnUnZip_Click(object sender, EventArgs e)
        {
            Common.UnZipFile(Application.StartupPath + "\\AutoUpdater\\app.zip",Application.StartupPath + "\\AutoUpdater");
        }

        private void SetConfigAppNo(string[] appNos)
        {
            FileStream fsInfo = new FileStream(InstallPath + "\\Update.ini", FileMode.OpenOrCreate); 
            StreamWriter swInfo = new StreamWriter( fsInfo ); 
            swInfo.Flush(); 
            swInfo.BaseStream.Seek( 0, SeekOrigin.Begin );
            for (int i = 0; i < appNos.Length; i++)
            {
                swInfo.WriteLine(appNos[i]);
            }
            swInfo.Flush(); 
            swInfo.Close();
        }

        private void SetConfigAppNo(string appNo)
        {
            File.WriteAllText(InstallPath + "\\Update.ini", appNo); 
        }

        private void btnMD5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Common.GetMD5HashFromFile(txtMD5.Text));
        }

        private static string GetWebConfig(string ConfigName)
        {
            string strRet = string.Empty;
            WebRequest req = WebRequest.Create(string.Format("{0}?SystemName={1}&ConfigName={2}", GitConfigWebUrl, systemName, ConfigName));
            WebResponse res = req.GetResponse();
            System.IO.Stream resStream = res.GetResponseStream();
            Encoding encode = System.Text.Encoding.Default;
            StreamReader readStream = new StreamReader(resStream, encode);
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                String str = new String(read, 0, count);
                strRet = strRet + str;
                count = readStream.Read(read, 0, 256);
            }
            resStream.Close();
            readStream.Close();
            res.Close();
            return strRet;
        }

        private static string GetServerUpdateFileMD5()
        {
            string strRet = string.Empty;
            WebRequest req = WebRequest.Create(string.Format("{0}?FileName={1}", @"http://www.ziyangsoft.com/GetFileMD5.ashx", "Update.zip"));
            WebResponse res = req.GetResponse();
            System.IO.Stream resStream = res.GetResponseStream();
            Encoding encode = System.Text.Encoding.Default;
            StreamReader readStream = new StreamReader(resStream, encode);
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                String str = new String(read, 0, count);
                strRet = strRet + str;
                count = readStream.Read(read, 0, 256);
            }
            resStream.Close();
            readStream.Close();
            res.Close();
            return strRet;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DirectoryInfo directoryInfo = new DirectoryInfo(System.Environment.CurrentDirectory);
            DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\PublishWeb\App\Install");
            FileInfo[] files = directoryInfo.GetFiles();
            string MD5s=string.Empty;
            List<app> apps = new List<app>();
            for(int i=0;i<files.Length;i++)
            {
                app app = new app(files[i].Name, Common.GetMD5HashFromFile(files[i].FullName));
                apps.Add(app);
            }
            txtMD5.Text = JsonConvert.SerializeObject(apps);
            apps.Clear();
            apps = JsonConvert.DeserializeObject<List<app>>(txtMD5.Text);

            for(int j=0;j<apps.Count;j++)
            {
                listBox1.Items.Add(apps[j].name+":"+apps[j].md5);            
            }
        }

        class app
        {
            public app(string appName, string appMD5)
            {
                name = appName;
                md5 = appMD5;
            }
            public string name { get; set; }
            public string md5 { get; set; }
        }

        private void btntxtEncrypt_Click(object sender, EventArgs e)
        {
            txtEncryptNew.Text = EncryptPWD(txtEncryptOriginal.Text);
        }
    }
}

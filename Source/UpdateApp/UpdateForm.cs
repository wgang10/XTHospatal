using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Xml;


namespace UpdateApp
{
    public partial class UpdateForm : Form
    {
        private static const string webUrl = @"http://ziyangsoft.com/Config.ashx";
        private static const string systemName = "XTHospatal";
        delegate void ShowProgressDelegate(int totalStep, int currentStep);
        private static const string UpdataURLConfig = "UpdataURL";
        private WebClient downWebClient = new WebClient();
        private static string updateURL=string.Empty;
        private static long size;//所有文件大小 
        private static int count;//文件总数 
        private static string[] fileNames;
        private static int num;//已更新文件数 
        private static long upsize;//已更新文件大小 
        private static string fileName="Update.zip";//当前文件名 
        private static long filesize;//当前文件大小
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
                updateURL = GetWebConfig(UpdataURLConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (string.IsNullOrEmpty(Common.globalAppVNo)&& string.IsNullOrEmpty(Common.globalAppMD5No))
            {
                this.Height = 276;
                
            }
            else
            {
                this.Height = 142;
                
                this.Text ="自动更新程序---------" + Common.globalAppVNo + "@" + Common.globalAppMD5No;
                //if (MessageBox.Show("是否更新？", "update?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //{
                //    UpdaterStart();
                //}
                UpdaterStart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBarSize.Maximum = 100;
            UpdaterStart();
            btnUpdate.Enabled = false;
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
                    fileName,
                    ConvertSize(ex.BytesReceived),
                    ConvertSize(ex.TotalBytesToReceive));

                tempf = (float)ex.BytesReceived / (float)ex.TotalBytesToReceive;
                progressBarFile.Value = 50;
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
                    //获取程序包的MD5值
                    string appMD5 = Common.GetMD5HashFromFile(Application.StartupPath + "\\" + fileName);
                    if (!appMD5.Equals(Common.globalAppMD5No))
                    {
                        MessageBox.Show("所下载的更新包不完整，请尝试重新启动程序。");
                        Application.Exit();
                        return;
                    }
                    //移动下载包
                    //File.Move(Application.StartupPath + "\\AutoUpdater\\" + fileName, Application.StartupPath + "\\" + fileName);               
                    //解压缩
                    Common.UnZipFile(Application.StartupPath + "\\"+fileName, Application.StartupPath);
                    //设置最新的程序号
                    string[] newAppNo = { Common.globalAppVNo, Common.globalAppMD5No };
                    SetConfigAppNo(newAppNo);
                    UpdaterClose();
                }
            };
            DownloadFile(0);
        }

        /// <summary> 
        /// 下载文件 
        /// </summary> 
        /// <param name="arry">下载序号</param> 
        private void DownloadFile(int arry)
        {
            try
            {
                num++;
                //fileName = fileNames[arry];
                //删除已有的下载包
                if (File.Exists(Application.StartupPath + "\\" + fileName))
                {
                    File.Delete(Application.StartupPath + "\\" + fileName);
                }
                lbMessageFile.Text = String.Format(
                    CultureInfo.InvariantCulture,
                    "更新进度 {0}/{1}  [ {2} ]",
                    num,
                    count,
                    ConvertSize(size));
                string DownLoadURL = updateURL;
                if(!Directory.Exists(Application.StartupPath))
                {
                    Directory.CreateDirectory(Application.StartupPath);
                }
                string SavePathName=Application.StartupPath + "\\" + fileName;
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
                System.Diagnostics.Process.Start(Application.StartupPath + @"\UI.exe");
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
            FileStream fsInfo = new FileStream(Application.StartupPath+"\\Update.ini",FileMode.OpenOrCreate); 
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

        private void btnMD5_Click(object sender, EventArgs e)
        {
            txtMD5.Text = Common.GetMD5HashFromFile(txtMD5.Text);
        }

        private static string GetWebConfig(string ConfigName)
        {
            string strRet = string.Empty;
            WebRequest req = WebRequest.Create(string.Format("{0}?SystemName={1}&ConfigName={2}", webUrl, systemName, ConfigName));
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
    }
}

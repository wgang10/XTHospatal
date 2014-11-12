using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UI.Properties;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace UI
{
    public partial class FromLogin : Form
    {
        private static string webUrl = @"http://localhost/Config.ashx";
        private static string GetFileMD5webUrl = @"http://localhost/GetFileMD5.ashx";
        private static string GetFilesMD5webUrl = @"http://localhost/GetFilesMD5.ashx";
        private static string systemName = "XTHospatal";
        private static string WebServicesURLConfig = "WebServicesURL";
        private static string LastAppNoConfig = "LastAppNo";
        private static Dictionary<string,string> updateFiles = null;
        private static Dictionary<string, string> deleteFiles = null;
        private static string updateFileList = string.Empty;

        /// <summary>
        /// hide
        /// </summary>
        int windowHeight1 = 228;
        /// <summary>
        /// show
        /// </summary>
        int windowHeight2 = 327;
        public FromLogin()
        {
            InitializeComponent();
            this.Load += delegate { this.alphaBlendingBringer1.SetAlphaBlending(this); };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                GlobalVal.blCloseForm = true;
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserID=txtUserID.Text.Trim();
            string strUserPWD=txtUserPwd.Text.Trim();
            //string strYearMonth=cmbYearMonth.Text.Trim();
            if(strUserID.Length <1)
            {
                MessageBox.Show("用户名不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserID.Focus();
                txtUserID.Select();
                return;
            }
            if(strUserPWD.Length <1)
            {
                MessageBox.Show("密码不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserPwd.Focus();
                txtUserPwd.Select();
                return;
            }
            //if (strYearMonth.Length < 1)
            //{
            //    MessageBox.Show("请选择或输入年月！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cmbYearMonth.Focus();
            //    cmbYearMonth.Select();
            //    return;
            //}
            //if (!CheckYearMonth(cmbYearMonth.Text))
            //{
            //    MessageBox.Show("请输入正确的年月！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cmbYearMonth.Focus();
            //    cmbYearMonth.Select();
            //    return;
            //}
            try
            {
                if (GlobalVal.gloWebSerices == null)
                {
                    GlobalVal.gloWebSerices = new MyWebService(GlobalVal.glostrServicesURL+@"/Service.asmx");
                }
                string[] resoult = GlobalVal.gloWebSerices.ValidateUserNoYearMonth(GlobalVal.gloStrLoginUserID, GlobalVal.gloStrTerminalCD, strUserID, strUserPWD);
                if (resoult[0] == "1")
                {
                    GlobalVal.gloWebSerices.AddLog("管理用户[" + strUserID + "]登录了系统.", "2", Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
                    //GlobalVal.gloYearMonth = strYearMonth;
                    GlobalVal.gloStrLoginUserID = strUserID;
                    GlobalVal.gloStrLoginUserType = resoult[2];
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    GlobalVal.gloWebSerices.AddLog("用户[" + strUserID + "]尝试登录管理系统失败." + resoult[1], "2", Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
                    MessageBox.Show(resoult[1], "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FromLogin_Load(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                Image image = Image.FromStream(wc.OpenRead(GlobalVal.gloStrPictureLoginUrl));
                this.pictureBox1.Image = image;
            }
            catch(Exception ex)
            {
                GlobalVal.gloWebSerices.AddLog("加载图片[" + GlobalVal.gloStrPictureLoginUrl + "]失败."+ex.Message , "3", Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
            }
            //txtServerURL.Text = ConfigurationManager.AppSettings["WebServicesURL"];
            //txtServerURL.Text = GetConfigFormIni();
            try
            {
                txtServerURL.Text = GetWebConfig(WebServicesURLConfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (GlobalVal.gloStrTerminalCD.Equals("Install", StringComparison.CurrentCultureIgnoreCase)
                || GlobalVal.gloStrTerminalCD.Equals("Update", StringComparison.CurrentCultureIgnoreCase))
            {
                //**************************************
                System.Threading.ThreadStart testWeb = new System.Threading.ThreadStart(TestWebService);
                System.Threading.Thread testWebThread = new System.Threading.Thread(testWeb);
                testWebThread.Start();
                //**************************************
                this.Height = windowHeight1;
                btnConfig.Text = "▼";
                this.Activate();
            }
            else
            {
                List<app> apps = new List<app>();
                try
                {
                    //txtServerURL.Text = GetWebConfig(WebServicesURLConfig);
                    //string result = GetServerUpdateFileMD5();
                    string result = GetServerLastFilesMD5();
                    if (result.Length > 0)
                    {
                        //服务器文件列表
                        apps = JsonConvert.DeserializeObject<List<app>>(result);
                    }

                    //获取本地文件列表
                    DirectoryInfo dir = new DirectoryInfo(System.Environment.CurrentDirectory);
                    FileInfo[] files = dir.GetFiles();
                    string md5 = string.Empty;
                    updateFiles = new Dictionary<string, string>();
                    deleteFiles = new Dictionary<string, string>();
                    bool isFind = false;
                    for (int f = 0; f < files.Length; f++)//遍历所有本地文件,找本地和服务器端都存在的文件然后对比MD5
                    {
                        isFind = false;
                        foreach (app p in apps)//同服务器文件列表对比
                        {
                            if (p.name.Equals(files[f].Name + ".zip", StringComparison.InvariantCultureIgnoreCase))
                            {
                                md5 = Method.GetMD5HashFromFile(files[f].FullName);
                                isFind = true;
                                if (!p.md5.Equals(md5))//如果文件名相同，对比MD5
                                {
                                    updateFiles.Add(files[f].Name + ".zip", md5);
                                    updateFileList += files[f].Name + ".zip|";
                                }
                                break;
                            }
                        }

                        if (!isFind)//如果本地文件不在服务器列表中，加入删除列表
                        {
                            deleteFiles.Add(files[f].Name, "");
                        }
                    }

                    for (int k = 0; k < apps.Count; k++)//找到本地不存在，服务器端存在的文件列表
                    {
                        isFind = false;
                        for (int l = 0; l < files.Length; l++)
                        {
                            if ((files[l].Name + ".zip").Equals(apps[k].name, StringComparison.InvariantCultureIgnoreCase))
                            {
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            updateFiles.Add(apps[k].name, "");
                            updateFileList += apps[k].name + "|";
                        }
                    }

                    if (updateFileList.Length > 0)
                    {
                        updateFileList = updateFileList.Substring(0, updateFileList.LastIndexOf("|"));
                    }


                    //LastNos = GetServerUpdateFileMD5();

                    //开始检查更新******************************************************************                    ;
                    if (updateFiles.Count == 0)
                    {
                        //**************************************
                        System.Threading.ThreadStart testWeb = new System.Threading.ThreadStart(TestWebService);
                        System.Threading.Thread testWebThread = new System.Threading.Thread(testWeb);
                        testWebThread.Start();
                        //**************************************
                        this.Height = windowHeight1;
                        btnConfig.Text = "▼";
                        this.Activate();
                        //Method.CmbDataBound("YearMonth", cmbYearMonth);
                    }
                    //****************************************************************************
                    else
                    {
                        if (MessageBox.Show("发现有新程序可以更新，是否更新？\n" + updateFileList, "发现更新：" + updateFiles.Count.ToString() + "个文件", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(Application.StartupPath + @"\UpdateApp.exe", updateFileList);
                            }
                            catch (Win32Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            GlobalVal.blCloseForm = true;
                            Application.Exit();
                        }
                        else
                        {
                            //**************************************
                            System.Threading.ThreadStart testWeb = new System.Threading.ThreadStart(TestWebService);
                            System.Threading.Thread testWebThread = new System.Threading.Thread(testWeb);
                            testWebThread.Start();
                            //**************************************
                            this.Height = windowHeight1;
                            btnConfig.Text = "▼";
                            this.Activate();
                            //Method.CmbDataBound("YearMonth", cmbYearMonth);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// SetYearMonth
        /// </summary>
        /// <param name="YearMonth"></param>
        /// <returns></returns>
        private bool CheckYearMonth(string YearMonth)
        {
            bool blFlag = false;
            int intYear = 0;
            int intMonth = 0;
            if (YearMonth.Trim().Length == 6)
            {
                try
                {
                    intYear = Int32.Parse(YearMonth.Substring(0, 4));
                    intMonth = Int32.Parse(YearMonth.Substring(4, 2));
                    if (1900 <= intYear && intYear <= 2100 && 1 <= intMonth && intMonth <= 12)
                    {
                        blFlag = true;
                    }
                }
                catch
                {
                }
            }
            return blFlag;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IEXPLORE.exe", GlobalVal.glostrSupportCompanyURL);
        }

        private void FromLogin_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (btnLogin.Enabled)
                    {
                        btnLogin_Click(sender, e);
                    }
                    break;
                case Keys.Escape:

                    if (btnExit.Enabled)
                    {
                        btnExit_Click(sender, e);
                    }
                    break;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (Height == windowHeight1)
            {
                this.Height = windowHeight2;
                btnConfig.Text = "▲";
            }
            else
            {
                this.Height = windowHeight1;
                btnConfig.Text = "▼";
            }
        }

        /// <summary>
        /// 测试服务器连接
        /// </summary>
        private void TestWebService()
        {
            bool blws = false;
            try
            {
                if (GlobalVal.gloWebSerices == null)
                {
                    GlobalVal.gloWebSerices = new MyWebService(txtServerURL.Text.Trim() + @"/Service.asmx");
                }
                GlobalVal.gloWebSerices.Url = txtServerURL.Text.Trim() + @"/Service.asmx";
                string strResoult = GlobalVal.gloWebSerices.CheckWebServices();
                if (strResoult.Trim() == "WanGang")
                {
                    blws = true;
                    btnConfig.ForeColor = Color.Green;
                    GlobalVal.glostrServicesURL = txtServerURL.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!blws)
                {
                    MessageBox.Show("不能连接到服务器！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnConfig.ForeColor = Color.Red;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool blws = false;
            try
            {
                if (GlobalVal.gloWebSerices == null)
                {
                    GlobalVal.gloWebSerices = new MyWebService(txtServerURL.Text.Trim() + @"/Service.asmx");
                }
                GlobalVal.gloWebSerices.Url = txtServerURL.Text.Trim() + @"/Service.asmx";
                string strResoult = GlobalVal.gloWebSerices.CheckWebServices();
                if (strResoult.Trim() == "WanGang")
                {
                    //修改配置文件
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    if (config.AppSettings.Settings["WebServicesURL"] != null)
                    {
                        config.AppSettings.Settings["WebServicesURL"].Value = txtServerURL.Text;
                    }
                    else
                    {
                        config.AppSettings.Settings.Add("WebServicesURL", txtServerURL.Text);
                    }
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    SaveConfigIni(txtServerURL.Text);
                    GlobalVal.glostrServicesURL = txtServerURL.Text.Trim();

                    blws = true;
                    //MessageBox.Show("成功连接服务！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //System.Configuration.ConfigurationManager.AppSettings.Set("","");
                    this.Height = windowHeight1;
                    btnConfig.Text = "▼";
                    btnConfig.ForeColor = Color.Green;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!blws)
                {
                    MessageBox.Show("不能连接到服务器！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Height = windowHeight1;
            btnConfig.Text = "▼";
        }

        //private void btnFile_Click(object sender, EventArgs e)
        //{
        //    if (this.ofdCode.ShowDialog() == DialogResult.OK) this.txtCode.Text = this.ofdCode.FileName;
        //}
        //private void btnGo_Click(object sender, EventArgs e)
        //{
        //    if (!(!string.IsNullOrEmpty(this.txtCode.Text) && File.Exists(this.txtCode.Text)))
        //    {
        //        MessageBox.Show("请指定第九关代买文件！", "文件出错！", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    }
        //    List<byte> list = new List<byte>();
        //    using (StreamReader reader = new StreamReader(File.OpenRead(this.txtCode.Text)))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            string[] strArray = reader.ReadLine().Replace('_', '1').Split(new char[] { ' ' });
        //            foreach (string str2 in strArray)
        //            {
        //                list.Add(Convert.ToByte(str2, 2));
        //            }
        //        }
        //    }
        //    string s = new ASCIIEncoding().GetString(list.ToArray());
        //    string path = "result.tar.zip";
        //    if (File.Exists(path)) File.Delete(path);
        //    using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.CreateNew)))
        //    {
        //        writer.Write(Convert.FromBase64String(s));
        //        writer.Flush();
        //    }
        //}

        /// <summary>
        /// 从配置文件中获取配置项
        /// </summary>
        /// <returns></returns>
        public static string GetConfigFormIni()
        {
            string filePath = Application.StartupPath + "\\WebURL.ini";
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string s = string.Empty;
            s = sr.ReadLine();
            sr.Close();
            if (s.EndsWith(@"/"))
            {
                s = s.Substring(0, s.Length - 1);
            }
            return s;
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="appNos"></param>
        private void SaveConfigIni(string config)
        {
            FileStream fsInfo = new FileStream(Application.StartupPath + "\\WebURL.ini", FileMode.OpenOrCreate);
            StreamWriter swInfo = new StreamWriter(fsInfo);
            swInfo.Flush();
            swInfo.BaseStream.Seek(0, SeekOrigin.Begin);
            swInfo.WriteLine(config);
            swInfo.Flush();
            swInfo.Close();
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

        private static string GetServerUpdateFileMD5()
        {
            string strRet = string.Empty;
            WebRequest req = WebRequest.Create(string.Format("{0}?FileName={1}", GetFileMD5webUrl, "Update.zip"));
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

        private static string GetServerLastFilesMD5()
        {
            string strRet = string.Empty;
            WebRequest req = WebRequest.Create(GetFilesMD5webUrl);
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            bool blws = false;
            try
            {
                if (GlobalVal.gloWebSerices == null)
                {
                    GlobalVal.gloWebSerices = new MyWebService(txtServerURL.Text.Trim() + @"/Service.asmx");
                }
                if (txtServerURL.Text.Trim().IndexOf(@"http://") < 0)
                {
                    txtServerURL.Text = "http://" + txtServerURL.Text.Trim();
                }
                GlobalVal.gloWebSerices.Url = txtServerURL.Text.Trim() + @"/Service.asmx";
                string strResoult = GlobalVal.gloWebSerices.CheckWebServices();
                if (strResoult.Trim() == "WanGang")
                {
                    blws = true;
                    btnConfig.ForeColor = Color.Green;
                    MessageBox.Show("服务器测试成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                btnConfig.ForeColor = Color.Red;
                //MessageBox.Show(ex.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!blws)
                {
                    btnConfig.ForeColor = Color.Red;
                    MessageBox.Show("不能连接到服务器！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
    }
}
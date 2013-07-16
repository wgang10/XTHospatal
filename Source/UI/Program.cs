using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Text;

namespace UI
{
    static class Program
    {
        [DllImport("User32.dll")]//呼出Win32 API関数
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]//呼出Win32 API関数
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //if (ConfigurationManager.AppSettings["WebServicesURL"] != null)
                //{
                //    GlobalVal.glostrServicesURL = ConfigurationManager.AppSettings["WebServicesURL"].Trim() + @"/Service.asmx";
                //}
                //if (!ReadProperties())
                //{
                //    Application.Exit();
                //    return;
                //}
            }
            catch (Exception ex)
            {
                LogManager.WriteClientErrLog4Net(ex);
                Method.MessageShow("W18888");//Program have been running.
                Application.Exit();
                return;
            }

            Process instance = RunningInstance();
            if (instance != null)
            {
                Method.MessageShow("999999");
                HandleRunningInstance(instance);
                return;
            }
            else
            {
                bool canCreateThread;
                Mutex mutex = new Mutex(true, Application.UserAppDataPath.Replace("\\", "_"), out canCreateThread);

                if (!canCreateThread)
                {
                    MessageBox.Show("应用程序已在运行中！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                GlobalVal.SplashObj = SplashObject.GetSplash();
                GlobalVal.glostrAppNo = GetAppNoFromTxt();
                Application.Run(new FromMain());
                //Application.Run(new FormStatistics());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ReadProperties()
        {
            //获得当前计算机名+当前系统登陆用户名
            GlobalVal.gloStrTerminalCD = Environment.UserDomainName + "@" + Environment.UserName;
            //GlobalVal.gloDataTableMessage = Method.GetMsgDataTable();
            //if (GlobalVal.gloDataTableMessage.Rows.Count < 1)
            //{
            //    Method.MessageShow("");
            //    return false;
            //}
            //测试Web Service是否可用
            bool blws = false;
            try
            {
                if (GlobalVal.gloWebSerices == null)
                {
                    GlobalVal.gloWebSerices = new MyWebService(GlobalVal.glostrServicesURL + @"/Service.asmx");
                }
                string strResoult = GlobalVal.gloWebSerices.CheckWebServices();
                if (strResoult.Trim() == "WanGang")
                {
                    blws = true;
                }
            }
            catch
            { }
            if (!blws)
            {
                MessageBox.Show("不能连接Web Service服务器！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //GlobalVal.glostrIniFilePath = System.Configuration.ConfigurationManager.AppSettings["PropertiesPath"];
            //if (GlobalVal.glostrIniFilePath.Trim().Length < 1)
            //{
            //    Method.MessageShow("");
            //    return false;
            //}

            //GlobalVal.glostrMsgTitle = Method.ReadFileContext("MessageTitle", "MessageBoxCaption");
            //if (GlobalVal.glostrMsgTitle.Trim().Length < 1)
            //{
            //    Method.MessageShow("");
            //    return false;
            //}

            //GlobalVal.glostrSystemName = Method.ReadFileContext("SystemName", "SystemName");
            //if (GlobalVal.glostrSystemName.Trim().Length < 1)
            //{
            //    Method.MessageShow("");
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }

        /// <summary>
        /// 从配置文件中获取程序号
        /// </summary>
        /// <returns></returns>
        public static string GetAppNo()
        {
            string filePath = Application.StartupPath+"\\Update.ini";
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
            string filePath = Application.StartupPath + "\\Update.ini";
            string[] strs = null ;
            if (File.Exists(filePath))
            {
                strs = File.ReadAllLines(filePath);
            }
            if (strs != null && strs.Length > 0)
            {
                return strs[0];
            }
            else
            {
                return "";
            }
        }

    }
}

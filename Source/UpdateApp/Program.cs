using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace UpdateApp
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
        static void Main(string[] args)
        {
            Process instance = RunningInstance();
            if (instance != null)
            {
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
                if (args.Length > 0)
                {
                    try
                    {
                        //string[] strTemp = args[0].Split('@');
                        //Common.globalAppVNo = strTemp[0];
                        //Common.globalAppMD5No = strTemp[1];
                        Common.globalUpdateList = args[0];
                    }
                    catch { }
                }
                Application.Run(new UpdateForm());
            }
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
    }
}

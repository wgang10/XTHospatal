using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Install
{
  public partial class Install : Form
  {
      private static string ServerURL = @"http://www.ziyangsoft.com";
      private static string systemName = "XTHospital";
      private static string InstallURLConfig = "InstallURL";
      private static string InstallPathConfig = "InstallPath";
      private static string InstallURL = string.Empty;
    private WebClient downWebClient = new WebClient();
    private static string fileName = "Install.zip";//当前文件名 
    private static string appPath = @"C:\XTHospital";
    private static int num=0;//已更新文件数 
    private static string[] fileNames;
    private static long size;//所有文件大小 
    private Dictionary<string, string> LocalFiles = new Dictionary<string, string>();
    public Install()
    {
      InitializeComponent();
    }

    private void Install_Shown(object sender, EventArgs e)
    {
        Thread t = new Thread(new ThreadStart(BeginInstall));
        t.Start();
    }

      /// <summary>
      /// 获取本地已经存在文件的MD5值
      /// </summary>
    private void GetLoacalFilesMD5()
    {
        try
        {
            string md5Code = string.Empty;
            DirectoryInfo dr = new DirectoryInfo(appPath);
            FileInfo[] files = dr.GetFiles();
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            FileStream file;
            StringBuilder sb = new StringBuilder();
            byte[] retVal;
            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i].FullName))
                {
                    file = new FileStream(files[i].FullName, FileMode.Open);                    
                    retVal = md5.ComputeHash(file);
                    file.Close();                    
                    for (int j = 0; j < retVal.Length; j++)
                    {
                        sb.Append(retVal[j].ToString("x2"));
                    }
                    md5Code = sb.ToString();
                }
                LocalFiles.Add(files[i].Name, md5Code);
            }
        }
        catch
        {   
        }
    }

    private void BeginInstall()
    {
        try
        {
            InstallURL = GetWebConfig(InstallURLConfig);
            appPath = GetWebConfig(InstallPathConfig);
            GetLoacalFilesMD5();
        }
        catch (Exception ex)
        {
            MeBox(ex.Message);
            return;
        }
        GetDownloadFileList();//获取服务器文件列表
        DeleteExtraFiles();//删除本地不在列表中的文件
        UpdaterStart();//开始下载
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
          //string appMD5 = GetMD5HashFromFile(Application.StartupPath + "\\AutoUpdater\\" + fileName);
          //if (!appMD5.Equals(Common.globalAppMD5No))
          //{
          //  MessageBox.Show("所下载的更新包不完整，请尝试重新启动程序。");
          //  Application.Exit();
          //  return;
          //}
          //Environment.GetFolderPath(Environment.SpecialFolder.System);
          
          //删除已有的下载包
          //if (File.Exists(appPath + "\\" + fileName))
          //{
          //  File.Delete(appPath + "\\" + fileName);
          //}
          //移动下载包
          //File.Move(Application.StartupPath + "\\AutoUpdater\\" + fileName, Application.StartupPath + "\\" + fileName);               
          
          //设置最新的程序号
          //string[] newAppNo = { Common.globalAppVNo, Common.globalAppMD5No };
          //SetConfigAppNo(newAppNo);
          if (num < fileNames.Length)
          {
            DownloadFile(num);
          }
          else
          {
              //UpdaterClose();//不需要解压
              //fileName = GetWebConfig(InstallFileNameConfig);
              //appPath = GetWebConfig(InstallPathConfig);
              //System.Console.WriteLine("开始解压...");
              //UnZipFile(appPath + "\\" + fileName, appPath);
              System.Console.WriteLine("开始配置程序...");
              //Thread t1 = new Thread(new ThreadStart(CreateDesktopLnk));
              //t1.Start();
              //while (t1.ThreadState == ThreadState.Running)
              //{
              //    Thread.Sleep(500);
              //}
              System.Console.WriteLine("配置完成，开始启动程序...");
              int i = 0;
              while (!File.Exists(appPath + @"\UI.exe") && i < 20)
              {
                  Thread.Sleep(1000);
                  System.Console.WriteLine(i.ToString() + "...");
                  i++;
              }

              try
              {
                  System.Diagnostics.Process.Start(appPath + @"\UI.exe","Install");
              }
              catch (Win32Exception e)
              {
                  MeBox(e.Message);
              }
              catch (Exception e)
              {
                  MeBox(e.Message);
              }
              finally
              {
                  Application.Exit();
              }
          }
        }
      };
      DownloadFile(num);
    }

    //private static void CreateDesktopLnk()
    //{
    //    System.Console.WriteLine("开始创建桌面快捷方式...");
    //    int i = 0;
    //    while (!File.Exists(appPath + @"\UI.exe") && i < 20)
    //    {
    //        Thread.Sleep(500);
    //        System.Console.WriteLine(i.ToString() + "...");
    //        i++;
    //    }
    //    string DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);//得到桌面文件夹 
    //    IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShellClass();
    //    IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(DesktopPath + "\\体检系统.lnk");
    //    shortcut.TargetPath = appPath + @"\UI.exe";
    //    shortcut.Arguments = "";// 参数 
    //    shortcut.Description = "体检系统";
    //    shortcut.WorkingDirectory = appPath;//程序所在文件夹，在快捷方式图标点击右键可以看到此属性 
    //    shortcut.IconLocation = appPath + @"\UI.exe,0";//图标 
    //    shortcut.Hotkey = "CTRL+SHIFT+T";//热键 
    //    shortcut.WindowStyle = 1;
    //    shortcut.Save();
    //}

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
        //如果本地存在相同文件（文件名和MD5值都相同），则不需要再次下载
        if (LocalFiles.ContainsKey(fileName.Substring(0, fileName.LastIndexOf(".zip"))))
        {
            if (LocalFiles[fileName.Substring(0, fileName.LastIndexOf(".zip"))] == (GetServerFileMD5(fileName)))
            {
                lbMessageFile.Text = String.Format(
            CultureInfo.InvariantCulture,
            "进度 {0}/{1}>>已存在，跳过..",
            num,
            fileNames.Length);
                return;
            }
        }


        if (File.Exists(appPath + "\\" + fileName))
        {
            File.Delete(appPath + "\\" + fileName);
        }


        lbMessageFile.Text = String.Format(
            CultureInfo.InvariantCulture,
            "下载进度 {0}/{1}",
            num,
            fileNames.Length);
        progressBarFile.Value = Convert.ToInt32(((float)num / (float)fileNames.Length) * 100);
        string DownLoadURL = InstallURL + @"/" + fileName;
        if (!Directory.Exists(appPath))
        {
          Directory.CreateDirectory(appPath);
        }
        string SavePathName = appPath + "\\" + fileName.Substring(0,fileName.LastIndexOf(".zip"));
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
    /// 获取文件列表并下载 
    /// </summary> 
    private static void GetDownloadFileList()
    {
        fileNames = new string[] { "ICSharpCode.SharpZipLib.dll.zip"
        ,"Interop.IWshRuntimeLibrary.dll.zip"
        ,"log4net.dll.zip" 
        ,"System.Windows.Forms.DataVisualization.dll.zip"
        ,"UI.exe.config.zip"
        ,"UI.exe.zip"
        ,"UpdateApp.exe.zip"};
        try
        {
            string strRet = string.Empty;
            WebRequest req = WebRequest.Create(string.Format("{0}/filelist.ashx", ServerURL));
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

      /// <summary>
      /// 删除本地额外文件
      /// </summary>
    private void DeleteExtraFiles()
    {
        foreach(string key in LocalFiles.Keys)
        {
            bool IsExist = false;
            for (int j = 0; j < fileNames.Length; j++)
            {
                if (fileNames[j].Substring(0, fileNames[j].LastIndexOf(".zip")).Equals(key, StringComparison.CurrentCultureIgnoreCase))
                {
                    IsExist = true;
                    break;
                }
            }
            if(!IsExist)
            {
                File.Delete(appPath + "\\" + key);
            }
        }
    }

    /// <summary>
    /// 计算文件的MD5校验
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetMD5HashFromFile(string fileName)
    {
      try
      {
        FileStream file = new FileStream(fileName, FileMode.Open);
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] retVal = md5.ComputeHash(file);
        file.Close();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < retVal.Length; i++)
        {
          sb.Append(retVal[i].ToString("x2"));
        }
        return sb.ToString();
      }
      catch (Exception ex)
      {
        throw new Exception("error:" + ex.Message);
      }
    }

      /// <summary>
      /// 获取服务器文件MD5值
      /// </summary>
      /// <param name="file"></param>
      /// <returns></returns>
    private string GetServerFileMD5(string file)
    {
        string strRet = string.Empty;
        WebRequest req = WebRequest.Create(string.Format("{0}/GetFileMD5.ashx?FileName={1}", ServerURL, file));
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

    /// <summary> 
    /// 关闭程序 
    /// </summary> 
    private static void UpdaterClose()
    {
        try
        {
            System.Diagnostics.Process.Start(appPath + @"\UnZip.exe");
            //MeBox("下载完成！");
        }
        catch (Win32Exception ex)
        {
            MeBox(ex.Message);
        }
        catch (Exception ex)
        {
            MeBox(ex.Message);
        }
        finally
        {
            Application.Exit();
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

    private static string GetWebConfig(string ConfigName)
    {
        string strRet = string.Empty;
        WebRequest req = WebRequest.Create(string.Format("{0}/Config.ashx?SystemName={1}&ConfigName={2}", ServerURL, systemName, ConfigName));
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

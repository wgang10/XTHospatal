using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Install
{
  public partial class Install : Form
  {
    private static string dirPath = string.Empty;
    private WebClient downWebClient = new WebClient();
    private static string fileName = "Install.zip";//当前文件名 
    private static string appPath = @"C:\XTHospatal";
    private static int num=0;//已更新文件数 
    private static string[] fileNames;
    private static long size;//所有文件大小 
    public Install()
    {
      InitializeComponent();
    }

    private void Install_Shown(object sender, EventArgs e)
    {
      dirPath = @"http://www.ziyangsoft.com/App/Install";
      GetDownloadFileList();
      UpdaterStart();
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
          if (File.Exists(appPath + "\\" + fileName))
          {
            File.Delete(appPath + "\\" + fileName);
          }
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
            UpdaterClose();
          }
        }
      };
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
        lbMessageFile.Text = String.Format(
            CultureInfo.InvariantCulture,
            "更新进度 {0}/{1}",
            num,
            fileNames.Length);
        progressBarFile.Value = Convert.ToInt32(((float)num / (float)fileNames.Length) * 100);
        string DownLoadURL = dirPath + @"/" + fileName;
        if (!Directory.Exists(appPath))
        {
          Directory.CreateDirectory(appPath);
        }
        string SavePathName = appPath + "\\" + fileName.Replace(".zip","");
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
      fileNames = new string[] { "UI.exe.config.zip", "Update.ini.zip", "UI.exe.manifest.zip", "log4net.dll.zip" };
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
    /// 关闭程序 
    /// </summary> 
    private static void UpdaterClose()
    {
      try
      {
        //System.Diagnostics.Process.Start(Application.StartupPath + @"\UI.exe");
        MeBox("下载完成！");
      }
      catch (Win32Exception ex)
      {
        MeBox(ex.Message);
      }
      catch (Exception ex)
      {
        MeBox(ex.Message);
      }
      Application.Exit();
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
  }
}

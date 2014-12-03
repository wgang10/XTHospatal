<%@ WebHandler Language="C#" Class="GetFilesMD5" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;

public class GetFilesMD5 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string md5Code = string.Empty;
        try
        {
            string appPath = context.Server.MapPath("App/Install");
            if (Directory.Exists(appPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(appPath);
                FileInfo[] files = directoryInfo.GetFiles();
                string MD5s = string.Empty;
                List<app> apps = new List<app>();
                for (int i = 0; i < files.Length; i++)
                {
                    app app = new app(files[i].Name, GetMD5HashFromFile(files[i].FullName));
                    apps.Add(app);
                }                
                md5Code = Newtonsoft.Json.JsonConvert.SerializeObject(apps);
            }
        }
        catch {}
        finally
        {}
        context.Response.Write(md5Code);
    }

    class app
    {
        public app(string appName, string appMD5)
        {
            Name = appName;
            MD5 = appMD5;
        }

        private string Name;
        private string MD5;
        public string name { get { return Name; } set { Name = value; } }
        public string md5 { get { return MD5; } set { MD5 = value; } }
    }
 
    public bool IsReusable {
        get {
            return false;
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

}
<%@ WebHandler Language="C#" Class="FileList" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

public class FileList : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string fileList = string.Empty;
        try
        {
            string path = context.Server.MapPath("App/Install");
            DirectoryInfo dr = new DirectoryInfo(path);
            FileInfo[] files = dr.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                fileList += "|" + files[i].Name;
            }
            if (fileList.Length > 0)
            {
                fileList = fileList.Substring(1);
            }
        }
        catch { }
        context.Response.Write(fileList);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for GlobalValue
/// </summary>
public static class GlobalValue
{
    private static XTWebService.Service gloWebSerices = null;

    private static string glostrServicesURL = string.Empty;

    private static string GloWebServicesURL
    {
        get
        {
            if (string.IsNullOrEmpty(glostrServicesURL))
            {
                WebRequest req = WebRequest.Create(string.Format("{0}?SystemName={1}&ConfigName={2}", @"http://ziyangsoft.com/Config.ashx", "XTHospatal", "WebServicesURL"));
                WebResponse res = req.GetResponse();
                System.IO.Stream resStream = res.GetResponseStream();
                Encoding encode = System.Text.Encoding.Default;
                StreamReader readStream = new StreamReader(resStream, encode);
                Char[] read = new Char[256];
                int count = readStream.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    glostrServicesURL = glostrServicesURL + str;
                    count = readStream.Read(read, 0, 256);
                }
                resStream.Close();
                readStream.Close();
                res.Close();
            }
            return glostrServicesURL;
        }
    }

    public static XTWebService.Service GloWebSerices {
        get {
            if (gloWebSerices == null)
            {
                gloWebSerices = new MyWebService(GloWebServicesURL + @"/Service.asmx");
            }
            return gloWebSerices;
        }
    }
}

[System.Diagnostics.DebuggerStepThrough()
    , System.ComponentModel.DesignerCategory("code")
    , System.Web.Services.WebServiceBinding(Name = "", Namespace = "")]
public class MyWebService : XTWebService.Service
{
    //public MyWebService():base()
    //{
    //    this.Url = GlobalVal.glostrServicesURL;
    //}

    public MyWebService(string webUrl)
        : base()
    {

        this.Url = webUrl;
    }
}
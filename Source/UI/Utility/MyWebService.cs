using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    [System.Diagnostics.DebuggerStepThrough()
    ,System.ComponentModel.DesignerCategory("code")
    ,System.Web.Services.WebServiceBinding(Name = "",Namespace = "")]
    public class MyWebService : UI.webService.Service
    {
        //public MyWebService():base()
        //{
        //    this.Url = GlobalVal.glostrServicesURL;
        //}

        public MyWebService(string webUrl) :base()
        {

　　       this.Url = webUrl;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.COM
{
    public class GlobalVal
    {
        public static int gloPage
        {
            get
            {
                int gloPage = 50;
                try
                {
                    gloPage = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
                }
                catch{}
                return gloPage;
            }
        }        
    }
}

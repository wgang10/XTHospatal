using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Log
    {
        private static readonly IDAL_Log dalLog= Factory.CreateLog();
        private static Log M_model = new Log();

        public static void AddLog(string content,string type,string clint)
        {
            M_model.Content = content;
            M_model.Type = type;
            M_model.TERMINAL_CD = clint;
            ReturnValue resoult = AddLog(M_model);
            if (!resoult.ErrorFlag)
            {
                XTHospital.COM.UtilityLog.WriteFatal("¼ÇÂ¼ÈÕÖ¾Ê§°Ü£¡´íÎó£º"+resoult.ErrorID);
            }
        }

        public static ReturnValue AddLog(Model.Log model)
        {   
            return dalLog.Add(model);
        }

        public ReturnValue GetListLog(string DateFrom, string DateTo, string Type)
        {
            return dalLog.GetList(DateFrom, DateTo, Type);
        }
    }
}

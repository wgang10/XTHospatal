using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_Log
    {
        ReturnValue Add(Model.Log model);

        ReturnValue GetList(string DateFrom, string DateTo,string Type);
    }
}

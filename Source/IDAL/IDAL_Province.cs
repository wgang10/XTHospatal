using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_Province
    {
        ReturnValue Add(Province model);

        ReturnValue Search(string ProvinceID);

        ReturnValue Update(Province model);

        ReturnValue Delete(string ProvinceID);

        ReturnValue GetList();
    }
}
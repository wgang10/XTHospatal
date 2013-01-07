using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_Proportion
    {
        ReturnValue GetListCount(string Type,string DrugsCode,string ProvinceCode);

        ReturnValue Insert(Model.Proportion proportion);

        ReturnValue Update(Model.Proportion proportion);
    }
}

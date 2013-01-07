using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_Drug
    {
        ReturnValue GetList(string strWhere);

        ReturnValue GetList(int intStart, int intEnd,Drug model);

        ReturnValue GetListCount(Drug model);

        ReturnValue Search(string Type2,string DrugCode);

        ReturnValue GetDrugInfo(string ProvinceCode, string Code, string Type);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_DrugClass
    {
        ReturnValue Add(DrugClass model);

        ReturnValue SearchCode(string Code);

        ReturnValue Update(DrugClass model);

        ReturnValue Delete(string Code);

        ReturnValue GetList(string strWhere);

        ReturnValue GetMainDrugClassCode();

        ReturnValue GetChildDrugClass(string strUpCode);
    }
}

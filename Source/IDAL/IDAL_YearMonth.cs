using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_YearMonth
    {
        ReturnValue Add(YearMonth model);

        ReturnValue Search(string YearMonth);

        ReturnValue Update(YearMonth model);

        ReturnValue Delete(string YearMonth);

        ReturnValue GetList();

        ReturnValue StatisticNums();
    }
}

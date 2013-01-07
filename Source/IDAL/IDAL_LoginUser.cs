using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_LoginUser
    {
        ReturnValue Add(LoginUser model);

        ReturnValue Search(string UserID);

        ReturnValue Update(LoginUser model);

        ReturnValue Delete(string UserID);

        ReturnValue GetList();

        ReturnValue GetUserPwd(string UserID);

        ReturnValue GetEmployeePWD(string EmployeeGZID);

        ReturnValue GetPWDByEmployeeID(string EmployeeID);

        ReturnValue GetYearMonth();

        ReturnValue SearchYearMonth(string YearMonth);

        ReturnValue AddYearMonth(string LoginUserID, string TerminalCD, string YearMonth);

        ReturnValue StatisticNums();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.IDAL
{
    public interface IDAL_Employee
    {
        ReturnValue Add(Employee model);

        ReturnValue Search(string EmployeeID);

        ReturnValue Update(Employee model);

        ReturnValue GetList(string strWhere);

        ReturnValue GetEmployeeInfo(string EmployeeGZID);

        ReturnValue SearchAllInfo(string EmployeeID, string YearMoth);

        ReturnValue SearchMyInfo(string EmployeeID, string YearMoth);

        ReturnValue ChangePassWord(Employee model);

        ReturnValue GetCheckEmployeeNum(string YearMonth,string strWhere);
    }
}

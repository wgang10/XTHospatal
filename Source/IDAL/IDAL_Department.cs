using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_Department
    {
        ReturnValue Add(Model.Department model);

        ReturnValue Search(string DepartmentID);

        ReturnValue Update(Model.Department model);

        ReturnValue GetList(string strWhere);

        ReturnValue Delete(string DepartmentID);

        ReturnValue GetUseingDepartmentCount(string DepartmentID);
    }
}

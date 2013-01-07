using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_Surgery
    {
        ReturnValue Add(Surgery model);

        ReturnValue Search(string EmployeeID, string YearMoth);

        ReturnValue Update(Surgery model);
    }
}

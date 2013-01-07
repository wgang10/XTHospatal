using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.IDAL
{
    public interface IDAL_Features
    {
        ReturnValue Add(Features model);

        ReturnValue Search(string EmployeeID, string YearMoth);

        ReturnValue Update(Features model);
    }
}

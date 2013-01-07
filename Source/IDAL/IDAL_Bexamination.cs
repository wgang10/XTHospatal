using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.IDAL
{
    public interface IDAL_Bexamination
    {
        ReturnValue Add(Bexamination model);

        ReturnValue Search(string EmployeeID, string YearMoth);

        ReturnValue Update(Bexamination model);
    }
}

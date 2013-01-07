using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.IDAL
{
    public interface IDAL_Feme
    {
        ReturnValue Add(Feme model);

        ReturnValue Search(string EmployeeID, string YearMoth);

        ReturnValue Update(Feme model);
    }
}

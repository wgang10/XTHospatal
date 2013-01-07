using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_Composition
    {
        ReturnValue Add(Model.Composition model);

        ReturnValue Search(string EmployeeID, string YearMoth);

        ReturnValue Update(Model.Composition model);
    }
}

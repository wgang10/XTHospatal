using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.IDAL
{
    public interface IDAL_Biochemistry
    {
        ReturnValue Add(Biochemistry model);

        ReturnValue Search(string EmployeeID, string YearMoth);

        ReturnValue Update(Biochemistry model);

        ReturnValue GetAll();

        ReturnValue GetStatisticsBio(string EmployeeID);
    }
}

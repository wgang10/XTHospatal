using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_MedicalItems
    {
        ReturnValue Add(MedicalItems model);

        ReturnValue Search(string Code);

        ReturnValue Update(MedicalItems model);

        ReturnValue Delete(string Code);

        ReturnValue GetList();
    }
}

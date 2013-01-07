using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_ECG
    {
        private readonly IDAL_ECG dalECG = Factory.CreateECG();
        public ReturnValue AddUpdate(ECG model)
        {  
            ReturnValue resoult = dalECG.Search(model.EmployeeID,model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalECG.Update(model);
            }
            else
            {
                resoult = dalECG.Add(model);
            }
            return resoult;
        }
    }
}

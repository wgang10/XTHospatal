using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_InternalMedicine
    {
        private readonly IDAL_InternalMedicine dalInternalMedicine = Factory.CreateInternalMedicine();
        public ReturnValue AddUpdate(InternalMedicine model)
        {   
            ReturnValue resoult = dalInternalMedicine.Search(model.EmployeeID,model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalInternalMedicine.Update(model);
            }
            else
            {
                resoult = dalInternalMedicine.Add(model);
            }
            return resoult;
        }
    }
}

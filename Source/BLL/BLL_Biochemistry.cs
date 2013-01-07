using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Biochemistry
    {
        private readonly IDAL_Biochemistry dalBiochemistry = Factory.CreateBiochemistry();
        public ReturnValue AddUpdate(Biochemistry  model)
        {   
            ReturnValue resoult = dalBiochemistry.Search(model.EmployeeID,model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalBiochemistry.Update(model);
            }
            else
            {
                resoult = dalBiochemistry.Add(model);
            }
            return resoult;
        }
    }
}

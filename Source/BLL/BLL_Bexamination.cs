using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Bexamination
    {
        private readonly IDAL_Bexamination dalBexamination = Factory.CreateBexamination();   
        public ReturnValue AddUpdate(Bexamination model)
        {   
            ReturnValue resoult = dalBexamination.Search(model.EmployeeID,model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalBexamination.Update(model);
            }
            else
            {
                resoult = dalBexamination.Add(model);
            }
            return resoult;
        }
    }
}

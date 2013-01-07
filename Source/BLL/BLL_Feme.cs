using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Feme
    {
        private readonly IDAL_Feme dalFeme = Factory.CreateFeme();
        public ReturnValue AddUpdate(Feme model)
        {
            ReturnValue resoult = dalFeme.Search(model.EmployeeID, model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalFeme.Update(model);
            }
            else
            {
                resoult = dalFeme.Add(model);
            }
            return resoult;
        }
    }
}

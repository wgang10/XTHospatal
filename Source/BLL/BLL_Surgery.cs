using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;


namespace XTHospital.BLL
{
    public class BLL_Surgery
    {
        private readonly IDAL_Surgery dalSurgery = Factory.CreateSurgery();
        public ReturnValue AddUpdate(Surgery model)
        {   
            ReturnValue resoult = dalSurgery.Search(model.EmployeeID,model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalSurgery.Update(model);
            }
            else
            {
                resoult = dalSurgery.Add(model);
            }
            return resoult;
        }
    }
}

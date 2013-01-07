using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Features
    {
        private readonly IDAL_Features dalFeatures = Factory.CreateFeatures();
        
        public ReturnValue AddUpdate(Model.Features model)
        {  
            ReturnValue resoult = dalFeatures.Search(model.EmployeeID,model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalFeatures.Update(model);
            }
            else
            {
                resoult = dalFeatures.Add(model);
            }
            return resoult;
        }
    }
}

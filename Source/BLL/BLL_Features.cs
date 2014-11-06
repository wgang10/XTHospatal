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
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的五官信息", "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalFeatures.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 录入了用户 " + model.EmployeeID + " 的五官信息", "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }
    }
}

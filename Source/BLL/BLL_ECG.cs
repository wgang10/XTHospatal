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
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的心电图信息", "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalECG.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的心电图信息", "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }
    }
}

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
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的内科信息", "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalInternalMedicine.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的内科信息", "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }
    }
}

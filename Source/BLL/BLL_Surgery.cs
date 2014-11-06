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
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的外科信息", "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalSurgery.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的外科信息", "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }
    }
}

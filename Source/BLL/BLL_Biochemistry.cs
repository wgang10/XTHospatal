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
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID+" 的生化检验信息", "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalBiochemistry.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 添加了用户 " + model.EmployeeID+" 的生化检验信息", "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }

        public ReturnValue GetAll()
        {
            return dalBiochemistry.GetAll();
        }

        public ReturnValue GetStatisticsBio(string EmployeeID)
        {
            return dalBiochemistry.GetStatisticsBio(EmployeeID);
        }
    }
}

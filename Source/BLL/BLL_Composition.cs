using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Composition
    {
        private readonly IDAL_Composition dalComposition = Factory.CreateComposition();

        /// <summary>
        /// AddUpdate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnValue AddUpdate(Composition model)
        {
            ReturnValue resoult = dalComposition.Search(model.EmployeeID, model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalComposition.Update(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的体成分信息", "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalComposition.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的体成分信息", "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }
    }
}

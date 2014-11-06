using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.IDAL;
using XTHospital.Model;

namespace XTHospital.BLL
{
    public class BLL_Xray
    {
        private readonly IDAL_Xray dalXray = Factory.CreateXray();

        /// <summary>
        /// AddUpdate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnValue AddUpdate(Xray model)
        {
            ReturnValue resoult = dalXray.Search(model.EmployeeID, model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalXray.Update(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的X射线信息", "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalXray.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeID + " 的X射线信息", "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }
    }
}

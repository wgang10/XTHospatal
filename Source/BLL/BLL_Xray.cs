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
            }
            else
            {
                resoult = dalXray.Add(model);
            }
            return resoult;
        }
    }
}

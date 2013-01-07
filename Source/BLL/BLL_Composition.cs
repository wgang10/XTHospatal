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
            }
            else
            {
                resoult = dalComposition.Add(model);
            }
            return resoult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Proportion
    {
        private readonly IDAL_Proportion dal = Factory.CreateProportion();

        public ReturnValue AddUpdate(Proportion model)
        {
            ReturnValue resoult = dal.GetListCount(model.Type, model.DrugsCode, model.ProvinceCode);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dal.Update(model);
            }
            else
            {
                resoult = dal.Insert(model);
            }
            return resoult;
        }
    }
}
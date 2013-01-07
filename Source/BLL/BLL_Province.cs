using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Province
    {
        private readonly IDAL_Province dalProvince = Factory.CreateProvince();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnValue AddUpdate(Province model)
        {
            ReturnValue resoult = dalProvince.Search(model.Code);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalProvince.Update(model);
            }
            else
            {
                resoult = dalProvince.Add(model);
            }
            return resoult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnValue GetList()
        {
            ReturnValue resoult = dalProvince.GetList();
            return resoult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public string DeleteProvince(string ProvinceCode)
        {
            ReturnValue resoult = dalProvince.Delete(ProvinceCode);
            if (resoult.ErrorFlag)
            {
                return "0";
            }
            else
            {
                return resoult.ErrorID;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_DrugClass
    {
        private readonly IDAL_DrugClass dal = Factory.CreateDrugClass();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnValue GetList(string strWhere)
        {
            ReturnValue resoult = dal.GetList(strWhere);
            return resoult;
        }

        public ReturnValue GetMainDrugClassCode()
        {
            return dal.GetMainDrugClassCode();
        }

        public ReturnValue GetChildDrugClass(string strUpCode)
        {
            return dal.GetChildDrugClass(strUpCode);
        }

    }
}

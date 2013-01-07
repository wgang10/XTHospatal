using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Drug
    {
        private readonly IDAL_Drug dal = Factory.CreateDrug();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnValue GetList(int intPageNum,Drug model)
        {
            int intRowCount = 0;
            int intPageStart = 0;
            int intPageEnd = 0;
            ReturnValue returnV = dal.GetListCount(model);
            if (returnV.ErrorFlag)
            {
                intRowCount = returnV.Count;
            }
            else
            {
                return returnV;
            }
            intPageStart = (intPageNum - 1) * COM.GlobalVal.gloPage + 1;
            intPageEnd = intPageNum * COM.GlobalVal.gloPage;
            returnV = dal.GetList(intPageStart,intPageEnd,model);
            if (returnV.ErrorFlag)
            {
                returnV.Count = intRowCount;
            }
            return returnV;
        }

        public ReturnValue Search(string Type2, string Code)
        {
            return dal.Search(Type2, Code);
        }

        public ReturnValue GetDrugInfo(string ProvinceCode, string Code, string Type)
        {
            return dal.GetDrugInfo(ProvinceCode, Code, Type);
        }
    }
}

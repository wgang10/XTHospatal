using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_MedicalItems
    {
        private readonly IDAL_MedicalItems dalMedicalItems = Factory.CreateMedicalItems();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnValue AddUpdate(MedicalItems model)
        {
            ReturnValue resoult = dalMedicalItems.Search(model.Code);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalMedicalItems.Update(model);
            }
            else
            {
                resoult = dalMedicalItems.Add(model);
            }
            return resoult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnValue GetList()
        {
            ReturnValue resoult = dalMedicalItems.GetList();
            return resoult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public string DeletedalMedicalItems(string Code)
        {
            ReturnValue resoult = dalMedicalItems.Delete(Code);
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

using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Department
    {
        private readonly IDAL_Department dalDepartment = Factory.CreateDepartment();


        /// <summary>
        /// AddUpdateDepartment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnValue AddUpdateDepartment(Department model)
        {
            ReturnValue resoult = dalDepartment.Search(model.ID);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalDepartment.GetList(" and ID <> '" + model.ID + "' and Name = '"+model.Name+"'");
                if (!resoult.ErrorFlag)
                {
                    return resoult;
                }
                if (resoult.Count > 0)
                {
                    resoult.ErrorFlag = false;
                    resoult.ErrorID = "该部门名称已经存在！";
                    return resoult;
                }
                resoult = dalDepartment.Update(model);
            }
            else
            {
                resoult = dalDepartment.GetList(" and Name = '" + model.Name + "'");
                if (!resoult.ErrorFlag)
                {
                    return resoult;
                }
                if (resoult.Count > 0)
                {
                    resoult.ErrorFlag = false;
                    resoult.ErrorID = "该部门名称已经存在！";
                    return resoult;
                }
                resoult = dalDepartment.Add(model);
            }
            return resoult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnValue GetDepartmentList()
        {
            return dalDepartment.GetList("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <returns></returns>
        public ReturnValue DeleteDepartment(string DepartmentID)
        {
            ReturnValue resoult = dalDepartment.GetUseingDepartmentCount(DepartmentID);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult.ErrorFlag = false;
                resoult.ErrorID = "存在隶属于该部门的人员，不能删除！";
                return resoult;
            }
            return dalDepartment.Delete(DepartmentID);
        }
    }
}

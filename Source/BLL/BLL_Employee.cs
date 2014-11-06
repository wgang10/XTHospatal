using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Employee
    {
        private readonly IDAL_Employee dalEmployee = Factory.CreateEmployee();
        private readonly IDAL_LoginUser dalLoginUser = Factory.CreateLoginUser();

        public ReturnValue AddUpdate(Employee model)
        {
            ReturnValue resoult = dalEmployee.Search(model.EmployeeID);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalEmployee.Update(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 修改了用户 " + model.EmployeeName, "1", model.TERMINAL_CD);
                }
            }
            else
            {
                resoult = dalEmployee.Add(model);
                if (resoult.ErrorFlag)
                {
                    BLL_Log.AddLog(model.UPDATER_ID + " 添加了用户 " + model.EmployeeName, "1", model.TERMINAL_CD);
                }
            }
            return resoult;
        }

        public ReturnValue GetList(string strWhere)
        {
            return dalEmployee.GetList(strWhere);
        }

        public ReturnValue SearchAllInfo(string EmployeeID, string YearMonth)
        {
            return dalEmployee.SearchAllInfo(EmployeeID, YearMonth);
        }

        public ReturnValue SearchMyInfo(string EmployeeGZID, string YearMonth)
        {
            return dalEmployee.SearchMyInfo(EmployeeGZID, YearMonth);
        }

        /// <summary>
        /// 取得生化参考值信息
        /// </summary>
        /// <returns></returns>
        public ReturnValue SearchBioTInfo()
        {
            return dalEmployee.SearchBioTInfo();
        }

        public ReturnValue GetEmployeeInfo(string EmployeeID)
        {
            return dalEmployee.GetEmployeeInfo(EmployeeID);
        }

        public ReturnValue ChangePassWord(Employee model)
        {
            XTHospital.COM.ReturnValue resoult = dalLoginUser.GetPWDByEmployeeID(model.EmployeeID);
            if (resoult.ErrorFlag)
            {
                if (resoult.Count < 1)
                {
                    resoult.ErrorFlag = false;
                    resoult.ErrorID = "用户不存在！";
                    return resoult;
                }
                else
                {
                    if (model.EmployeePWD == resoult.ResultDataSet.Tables[0].Rows[0]["EmployeePWD"].ToString())
                    {
                        //修改密码
                        resoult=dalEmployee.ChangePassWord(model);
                        return resoult;
                    }
                    else
                    {
                        resoult.ErrorFlag = false;
                        resoult.ErrorID = "原始密码错误！";
                        return resoult;
                    }
                }
            }
            else
            {
                return resoult;
            }
        }

        public ReturnValue GetCheckEmployeeNum(string YearMonth, string EmployeeName, string EmployeeBM)
        {
            string where = string.Empty;
            if (!string.IsNullOrEmpty(EmployeeName))
            {
                where = " And Emp.EmployeeName Like '%" + EmployeeName + "%'";
            }
            if (EmployeeBM.Length > 0)
            {
                where += " And Emp.EmployeeBM='" + EmployeeBM + "'";
            }
            return dalEmployee.GetCheckEmployeeNum(YearMonth, where);
        }
    }
}

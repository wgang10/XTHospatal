using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;
using System.Data;

namespace XTHospital.BLL
{
    public class BLL_LoginUser
    {
        private readonly IDAL_LoginUser dalLoginUser = Factory.CreateLoginUser();

        public ReturnValue AddUpdate(LoginUser model)
        {   
            ReturnValue resoult = dalLoginUser.Search(model.UserID);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalLoginUser.Update(model);
            }
            else
            {
                resoult = dalLoginUser.Add(model);
            }
            return resoult;
        }

        public ReturnValue Delete(string UserID)
        {   
            ReturnValue resoult = dalLoginUser.Search(UserID);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.ResultDataSet.Tables[0].Rows.Count < 1)
            {
                return new ReturnValue(false, "W11023");//The User is not existed!
            }
            return dalLoginUser.Delete(UserID);
        }

        public ReturnValue GetList()
        {
            return dalLoginUser.GetList();
        }

        public ReturnValue GetUserPwd(string UserID)
        {
            return dalLoginUser.GetUserPwd(UserID);
        }

        public ReturnValue GetEmployeePWD(string EmployeeGZID)
        {
            return dalLoginUser.GetEmployeePWD(EmployeeGZID);
        }
        
        public ReturnValue GetYearMonth()
        {
            return dalLoginUser.GetYearMonth();
        }
        
        public ReturnValue SetYearMonth(string LoginUserID, string TerminalCD, string YearMonth)
        {
            ReturnValue resoult = dalLoginUser.SearchYearMonth(YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count < 1)
            {
                resoult = dalLoginUser.AddYearMonth(LoginUserID, TerminalCD, YearMonth);
            }
            return resoult;
        }

        /// <summary>
        /// 按年统计体检人数
        /// </summary>
        /// <returns></returns>
        public ReturnValue StatisticNums()
        {
            ReturnValue resoult = dalLoginUser.StatisticNums();
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            DataTable tb = new DataTable();
            tb.Columns.Add("YearMonth", typeof(string));
            tb.Columns.Add("Nums", typeof(int));
            for (int i = 0; i < resoult.ResultDataSet.Tables.Count; i++)
            {
                for (int j = 0; j < resoult.ResultDataSet.Tables[i].Rows.Count; j++)
                {
                    DataRow dr = tb.NewRow();
                    dr["YearMonth"] = resoult.ResultDataSet.Tables[i].Rows[j]["YearMoth"].ToString();
                    dr["Nums"] = Int32.Parse(resoult.ResultDataSet.Tables[i].Rows[j]["Nums"].ToString());
                    tb.Rows.Add(dr);
                }
            }
            resoult.ResultDataSet.Tables.Clear();
            resoult.ResultDataSet.Tables.Add(tb);
            return resoult;
        }
    }
}

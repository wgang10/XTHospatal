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
    public class BLL_YearMonth
    {
        private readonly IDAL_YearMonth dalYearMonth = Factory.CreateYearMonth();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnValue AddUpdate(YearMonth model)
        {
            ReturnValue resoult = dalYearMonth.Search(model.YMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalYearMonth.Update(model);
            }
            else
            {
                resoult = dalYearMonth.Add(model);
            }
            return resoult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnValue GetList()
        {
            ReturnValue resoult = dalYearMonth.GetList();
            return resoult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="YearMonthID"></param>
        /// <returns></returns>
        public string DeleteYearMonth(string YearMonth)
        {
            ReturnValue resoult = dalYearMonth.Delete(YearMonth);
            if (resoult.ErrorFlag)
            {
                return "0";
            }
            else
            {
                return resoult.ErrorID;
            }
        }

        /// <summary>
        /// 按年统计体检人数
        /// </summary>
        /// <returns></returns>
        public ReturnValue StatisticNums()
        {
            ReturnValue resoult = dalYearMonth.StatisticNums();
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
                    dr["YearMonth"] = resoult.ResultDataSet.Tables[i].Rows[j]["YearMonth"].ToString();
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

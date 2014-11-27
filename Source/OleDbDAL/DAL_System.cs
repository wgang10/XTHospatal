using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using XTHospital.COM;
using XTHospital.DB;
using XTHospital.IDAL;

namespace XTHospital.OleDbDAL
{
    public class DAL_System : IDAL_System
    {
        #region SQL Statement

        private string getNews_SQL = @"Select Top @@@ CreateTime,Title,Url,Body From News Where TRANS_STATE <> '3' ";

        #endregion

        #region         

        public ReturnValue GetNewsList(string SystemName, int Num)
        {
            string strWhere = string.Empty;
            strWhere += " and SystemName = '" + SystemName + "' Order By CreateTime Desc";
            return OleDbHelper.Query(getNews_SQL.Replace("@@@",Num.ToString()) + strWhere);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using XTHospital.IDAL;
using XTHospital.DB;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.OleDbDAL
{
    public class DAL_YearMonth : IDAL_YearMonth
    {
        private string Add_SQL = @"Insert Into YearMonth(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,YMonth)
Values (FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@YMonth)";
        private string Update_SQL = @"Update YearMonth Set YMonth=@YMonth Where YMonth=@YMonth";
        private string Search_SQL = @"Select YMonth FROM YearMonth Where YMonth=@YMonth";
        private string GetList_SQL = @"Select YMonth FROM YearMonth Order by YMonth";
        private string Delete_SQL = @"Delete From YearMonth Where YMonth=@YMonth";
        public ReturnValue Add(YearMonth model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@YMonth", OleDbType.VarWChar,6)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.YMonth;
            return OleDbHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Update(YearMonth model)
        {
            OleDbParameter[] parameters = {					
					new OleDbParameter("@YMonth", OleDbType.VarWChar,6)};
            parameters[0].Value = model.YMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parameters);
        }

        public ReturnValue Search(string YearMonth)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@YMonth", OleDbType.VarWChar, 6) };
            parameters[0].Value = YearMonth;
            return OleDbHelper.Query(Search_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return OleDbHelper.Query(GetList_SQL);
        }

        public ReturnValue Delete(string YearMonth)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@YMonth", OleDbType.VarWChar, 6) };
            parameters[0].Value = YearMonth;
            return OleDbHelper.ExecuteSql(Delete_SQL, parameters);
        }

        /// <summary>
        /// 按年统计体检人数
        /// </summary>
        /// <returns></returns>
        public ReturnValue StatisticNums()
        {
            string[] sqlList = new string[10];
            sqlList[0] = @"Select YearMonth,count(*) as Nums from Biochemistry group by YearMoth";//生化检验
            sqlList[1] = @"Select YearMonth,count(*) as Nums from Features group by YearMoth";//体格检查五官
            sqlList[2] = @"Select YearMonth,count(*) as Nums from Surgery group by YearMoth";//体格检查外科
            sqlList[3] = @"Select YearMonth,count(*) as Nums from InternalMedicine group by YearMoth";//体格检查内科
            sqlList[4] = @"Select YearMonth,count(*) as Nums from ECG group by YearMoth";//心电图
            sqlList[5] = @"Select YearMonth,count(*) as Nums from Xray group by YearMoth";//X线
            sqlList[6] = @"Select YearMonth,count(*) as Nums from Bexamination group by YearMoth";//B超
            sqlList[7] = @"Select YearMonth,count(*) as Nums from Composition group by YearMoth";//体成分分析
            sqlList[8] = @"Select YearMonth,count(*) as Nums from Feme group by YearMoth";//妇科
            sqlList[9] = @"Select YearMonth,count(*) as Nums from Report group by YearMoth";//报告
            return OleDbHelper.Query(sqlList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XTHospital.IDAL;
using XTHospital.DB;
using XTHospital.Model;
using XTHospital.COM;

namespace XTHospital.DAL
{
    public class DAL_YearMonth:IDAL_YearMonth
    {
        private string Add_SQL = @"Insert Into YearMonth(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,YMonth)
Values (CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@YMonth)";
        private string Update_SQL = @"Update YearMonth Set 
UPDATE_DATETIME = CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
YMonth=@YMonth Where YMonth=@YMonth";
        private string Search_SQL = @"Select YMonth FROM YearMonth Where YMonth=@YMonth";
        private string GetList_SQL = @"Select YMonth FROM YearMonth Order by YMonth";
        private string Delete_SQL = @"Delete From YearMonth Where YMonth=@YMonth";
        public ReturnValue Add(YearMonth model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar),
					new SqlParameter("@YMonth", SqlDbType.NVarChar,6)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.YMonth;
            return SqlHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Update(YearMonth model)
        {
            SqlParameter[] parameters = {
				    new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
					new SqlParameter("@YMonth", SqlDbType.NVarChar,6)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.YMonth;
            return SqlHelper.ExecuteSql(Update_SQL, parameters);
        }

        public ReturnValue Search(string YearMonth)
        {
            SqlParameter[] parameters = { new SqlParameter("@YMonth", SqlDbType.NVarChar, 6) };
            parameters[0].Value = YearMonth;
            return SqlHelper.Query(Search_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return SqlHelper.Query(GetList_SQL);
        }

        public ReturnValue Delete(string YearMonth)
        {
            SqlParameter[] parameters = { new SqlParameter("@YMonth", SqlDbType.NVarChar, 6) };
            parameters[0].Value = YearMonth;
            return SqlHelper.ExecuteSql(Delete_SQL, parameters);
        }


        public ReturnValue StatisticNums()
        {
            throw new NotImplementedException();
        }
    }
}

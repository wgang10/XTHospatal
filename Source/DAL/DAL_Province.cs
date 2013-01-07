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
    class DAL_Province : IDAL_Province
    {
        private string Add_SQL = @"Insert Into Province(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,Code,Name)
Values (CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@Code,@Name)";
        private string Update_SQL = @"Update Province Set 
UPDATE_DATETIME = CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
Name=@Name 
Where Code=@Code";
        private string Search_SQL = @"Select Code,Name FROM Province Where Code=@Code";
        private string GetList_SQL = @"Select Code,Name FROM Province Order by Code";
        private string Delete_SQL = @"Delete From Province Where Code=@Code";
        public ReturnValue Add(Province model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Name;
            return SqlHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Update(Province model)
        {
            SqlParameter[] parameters = {
				    new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Code", SqlDbType.NVarChar,50),};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Code;
            return SqlHelper.ExecuteSql(Update_SQL, parameters);
        }

        public ReturnValue Search(string ProvinceID)
        {
            SqlParameter[] parameters = { new SqlParameter("@Code", SqlDbType.NVarChar, 50) };
            parameters[0].Value = ProvinceID;
            return SqlHelper.Query(Search_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return SqlHelper.Query(GetList_SQL);
        }

        public ReturnValue Delete(string ProvinceCode)
        {
            SqlParameter[] parameters = { new SqlParameter("@Code", SqlDbType.NVarChar, 50) };
            parameters[0].Value = ProvinceCode;
            return SqlHelper.ExecuteSql(Delete_SQL, parameters);
        }   
    }
}

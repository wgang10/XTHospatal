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
    public class DAL_DrugClass : IDAL_DrugClass
    {
        private string SearchCode_SQL = @"Select Code From DrugClass Where Code=@Code";
        private string Add_SQL = @"Insert Into DrugClass(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,Code,Name,UpCode,Type)
Values (CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@Code,@Name,@UpCode,@Type)";
        private string Update_SQL = @"Update DrugClass Set 
UPDATE_DATETIME = CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
Name=@Name,
UpCode=@UpCode,
Type=@Type
Where Code=@Code";
        private string Delete_SQL = @"Delete from DrugClass Where Code=@Code ";

        private string GetList_SQL = @"Select A.CREATE_DATETIME,A.UPDATE_DATETIME,A.TRANS_STATE,A.UPDATER_ID,A.TERMINAL_CD,
A.Code,A.Name,A.UpCode,B.Name As UpName,A.Type,(Case A.Type When '0' Then '西药' When '1' Then '中药' End) As TypeName 
FROM DrugClass A Left Join DrugClass B On B.Code = A.UpCode Where 1=1 ";

        private string GetMainDrugClassCode_SQL = @"select Code,(Case Type When 0 Then '西药-'+Name When 1 Then '中药-'+Name End) As Name,
type + right('0'+replace(Convert(Varchar(2),code),'.',''),2) as OrderID from DrugClass Where UpCode = '' Order By Type,OrderID ";

        private string GetChildDrugClass_SQL = @"Select Code,name From DrugClass where UpCode = @UpCode";

        #region IDAL_DrugClass 成员

        public ReturnValue Add(DrugClass model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@UpCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,1)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.UpCode;
            parameters[5].Value = model.Type;
            return SqlHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue SearchCode(string Code)
        {
            SqlParameter[] parameters = { new SqlParameter("@Code", SqlDbType.NVarChar, 50) };
            parameters[0].Value = Code;
            return SqlHelper.Query(SearchCode_SQL, parameters);
        }

        public ReturnValue Update(DrugClass model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@UpCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,1)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.UpCode;
            parameters[5].Value = model.Type;
            return SqlHelper.ExecuteSql(Update_SQL, parameters);
        }

        public ReturnValue Delete(string Code)
        {
            SqlParameter[] parameters = {new SqlParameter("@Code", SqlDbType.NVarChar,50)};
            parameters[0].Value = Code;
            return SqlHelper.ExecuteSql(Delete_SQL, parameters);
        }

        public ReturnValue GetList(string strWhere)
        {
            return SqlHelper.Query(GetList_SQL + strWhere);
        }

        /// <summary>
        /// 取得药品主分类
        /// </summary>
        /// <returns></returns>
        public ReturnValue GetMainDrugClassCode()
        {
            return SqlHelper.Query(GetMainDrugClassCode_SQL);
        }

        public ReturnValue GetChildDrugClass(string strUpCode)
        {
            SqlParameter[] parameters = { new SqlParameter("@UpCode", SqlDbType.NVarChar, 50) };
            parameters[0].Value = strUpCode;
            return SqlHelper.Query(GetChildDrugClass_SQL, parameters);
        }

        #endregion
    }
}

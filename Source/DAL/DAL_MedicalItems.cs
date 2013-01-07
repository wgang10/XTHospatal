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
    public class DAL_MedicalItems : IDAL_MedicalItems
    {
        private string Add_SQL = @"Insert Into MedicalItems(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,Code,FinanceID,Name,Units,Limit0,Limit1,Limit2,Limit3,Connotation,ExceptContents,Description)
Values (CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@Code,@FinanceID,@Name,@Units,@Limit0,@Limit1,@Limit2,@Limit3,@Connotation,@ExceptContents,@Description)";
        private string Update_SQL = @"Update MedicalItems Set 
UPDATE_DATETIME = CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
FinanceID=@FinanceID,Name=@Name,Units=@Units,Limit0=@Limit0,Limit1=Limit1,Limit2=@Limit2,Limit3=@Limit3,Connotation=@Connotation,ExceptContents=@ExceptContents,Description=@Description Where Code=@Code";
        private string Search_SQL = @"Select Code,FinanceID,Name,Units,Limit0,Limit1,Limit2,Limit3,Connotation,ExceptContents,Description FROM MedicalItems Where Code=@Code";
        private string GetList_SQL = @"Select Code,FinanceID,Name,Units,Limit0,Limit1,Limit2,Limit3,Connotation,ExceptContents,Description FROM MedicalItems Order by Code";
        private string Delete_SQL = @"Delete From MedicalItems Where Code=@Code";
        public ReturnValue Add(MedicalItems model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar),
					new SqlParameter("@Code", SqlDbType.NVarChar,10),
                    new SqlParameter("@FinanceID", SqlDbType.NVarChar,1),
                    new SqlParameter("@Name", SqlDbType.NVarChar,255),
                    new SqlParameter("@Units", SqlDbType.NVarChar,50),
                    new SqlParameter("@Limit0", SqlDbType.Int),
                    new SqlParameter("@Limit1", SqlDbType.Int),
                    new SqlParameter("@Limit2", SqlDbType.Int),
                    new SqlParameter("@Limit3", SqlDbType.Int),
                    new SqlParameter("@Connotation", SqlDbType.NVarChar,255),
                    new SqlParameter("@ExceptContents", SqlDbType.NVarChar,255),
                    new SqlParameter("@Description", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.FinanceID;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Units;
            parameters[6].Value = model.Limit0;
            parameters[7].Value = model.Limit1;
            parameters[8].Value = model.Limit2;
            parameters[9].Value = model.Limit3;
            parameters[10].Value = model.Connotation;
            parameters[11].Value = model.ExceptContents;
            parameters[12].Value = model.Description;
            return SqlHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Update(MedicalItems model)
        {
            SqlParameter[] parameters = {
	            new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
				new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,255),
                new SqlParameter("@FinanceID", SqlDbType.NVarChar,1),
                new SqlParameter("@Name", SqlDbType.NVarChar,255),
                new SqlParameter("@Units", SqlDbType.NVarChar,50),
                new SqlParameter("@Limit0", SqlDbType.Int),
                new SqlParameter("@Limit1", SqlDbType.Int),
                new SqlParameter("@Limit2", SqlDbType.Int),
                new SqlParameter("@Limit3", SqlDbType.Int),
                new SqlParameter("@Connotation", SqlDbType.NVarChar,255),
                new SqlParameter("@ExceptContents", SqlDbType.NVarChar,255),
                new SqlParameter("@Description", SqlDbType.NVarChar,255),
                new SqlParameter("@Code", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.FinanceID;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Units;
            parameters[6].Value = model.Limit0;
            parameters[7].Value = model.Limit1;
            parameters[8].Value = model.Limit2;
            parameters[9].Value = model.Limit3;
            parameters[10].Value = model.Connotation;
            parameters[11].Value = model.ExceptContents;
            parameters[12].Value = model.Description;
            return SqlHelper.ExecuteSql(Update_SQL, parameters);
        }

        public ReturnValue Search(string Code)
        {
            SqlParameter[] parameters = { new SqlParameter("@Code", SqlDbType.NVarChar, 10) };
            parameters[0].Value = Code;
            return SqlHelper.Query(Search_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return SqlHelper.Query(GetList_SQL);
        }

        public ReturnValue Delete(string Code)
        {
            SqlParameter[] parameters = { new SqlParameter("@Code", SqlDbType.NVarChar, 10) };
            parameters[0].Value = Code;
            return SqlHelper.ExecuteSql(Delete_SQL, parameters);
        }   
    }
}

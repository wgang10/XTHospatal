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
    public class DAL_MedicalItems : IDAL_MedicalItems
    {
        private string Add_SQL = @"Insert Into MedicalItems(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,Code,FinanceID,Name,Units,Limit0,Limit1,Limit2,Limit3,Connotation,ExceptContents,Description)
Values (FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@Code,@FinanceID,@Name,@Units,@Limit0,@Limit1,@Limit2,@Limit3,@Connotation,@ExceptContents,@Description)";
        private string Update_SQL = @"Update MedicalItems Set FinanceID=@FinanceID,Name=@Name,Units=@Units,Limit0=@Limit0,Limit1=Limit1,Limit2=@Limit2,Limit3=@Limit3,Connotation=@Connotation,ExceptContents=@ExceptContents,Description=@Description Where Code=@Code";
        private string Search_SQL = @"Select Code,FinanceID,Name,Units,Limit0,Limit1,Limit2,Limit3,Connotation,ExceptContents,Description FROM MedicalItems Where Code=@Code";
        private string GetList_SQL = @"Select Code,FinanceID,Name,Units,Limit0,Limit1,Limit2,Limit3,Connotation,ExceptContents,Description FROM MedicalItems Order by Code";
        private string Delete_SQL = @"Delete From MedicalItems Where Code=@Code";
        public ReturnValue Add(MedicalItems model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@Code", OleDbType.VarWChar,10),
                    new OleDbParameter("@FinanceID", OleDbType.VarWChar,1),
                    new OleDbParameter("@Name", OleDbType.VarWChar,255),
                    new OleDbParameter("@Units", OleDbType.VarWChar,50),
                    new OleDbParameter("@Limit0", OleDbType.Integer),
                    new OleDbParameter("@Limit1", OleDbType.Integer),
                    new OleDbParameter("@Limit2", OleDbType.Integer),
                    new OleDbParameter("@Limit3", OleDbType.Integer),
                    new OleDbParameter("@Connotation", OleDbType.VarWChar,255),
                    new OleDbParameter("@ExceptContents", OleDbType.VarWChar,255),
                    new OleDbParameter("@Description", OleDbType.VarWChar,255)};
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
            return OleDbHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Update(MedicalItems model)
        {
            OleDbParameter[] parameters = {					
                new OleDbParameter("@FinanceID", OleDbType.VarWChar,1),
                new OleDbParameter("@Name", OleDbType.VarWChar,255),
                new OleDbParameter("@Units", OleDbType.VarWChar,50),
                new OleDbParameter("@Limit0", OleDbType.Integer),
                new OleDbParameter("@Limit1", OleDbType.Integer),
                new OleDbParameter("@Limit2", OleDbType.Integer),
                new OleDbParameter("@Limit3", OleDbType.Integer),
                new OleDbParameter("@Connotation", OleDbType.VarWChar,255),
                new OleDbParameter("@ExceptContents", OleDbType.VarWChar,255),
                new OleDbParameter("@Description", OleDbType.VarWChar,255),
                new OleDbParameter("@Code", OleDbType.VarWChar,10)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.FinanceID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Units;
            parameters[4].Value = model.Limit0;
            parameters[5].Value = model.Limit1;
            parameters[6].Value = model.Limit2;
            parameters[7].Value = model.Limit3;
            parameters[8].Value = model.Connotation;
            parameters[9].Value = model.ExceptContents;
            parameters[10].Value = model.Description;
            return OleDbHelper.ExecuteSql(Update_SQL, parameters);
        }

        public ReturnValue Search(string Code)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@Code", OleDbType.VarWChar, 10) };
            parameters[0].Value = Code;
            return OleDbHelper.Query(Search_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return OleDbHelper.Query(GetList_SQL);
        }

        public ReturnValue Delete(string Code)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@Code", OleDbType.VarWChar, 10) };
            parameters[0].Value = Code;
            return OleDbHelper.ExecuteSql(Delete_SQL, parameters);
        }   
    }
}

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
    class DAL_Province : IDAL_Province
    {
        private string Add_SQL = @"Insert Into Province(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,Code,Name)
Values (FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@Code,@Name)";
        private string Update_SQL = @"Update Province Set Name=@Name Where Code=@Code";
        private string Search_SQL = @"Select Code,Name FROM Province Where Code=@Code";
        private string GetList_SQL = @"Select Code,Name FROM Province Order by Code";
        private string Delete_SQL = @"Delete From Province Where Code=@Code";
        public ReturnValue Add(Province model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@Code", OleDbType.VarWChar,10),
					new OleDbParameter("@Name", OleDbType.VarWChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Name;
            return OleDbHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Update(Province model)
        {
            OleDbParameter[] parameters = {					
					new OleDbParameter("@Name", OleDbType.VarWChar,50),
                    new OleDbParameter("@Code", OleDbType.VarWChar,10),};            
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Code;
            return OleDbHelper.ExecuteSql(Update_SQL, parameters);
        }

        public ReturnValue Search(string ProvinceID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@Code", OleDbType.VarWChar, 10) };
            parameters[0].Value = ProvinceID;
            return OleDbHelper.Query(Search_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return OleDbHelper.Query(GetList_SQL);
        }

        public ReturnValue Delete(string ProvinceCode)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@Code", OleDbType.VarWChar, 10) };
            parameters[0].Value = ProvinceCode;
            return OleDbHelper.ExecuteSql(Delete_SQL, parameters);
        }   
    }
}

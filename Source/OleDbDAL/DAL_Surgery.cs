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
    public class DAL_Surgery : IDAL_Surgery
    {
        private string SearchID_SQL = @"Select EmployeeID From Surgery
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Surgery(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,Length,Bust,Weight,BadBreath,Skin,Lymphoid,Thyroid,Spine,Limbs,Joint,Flatfoot,Genitourinary,Anal,Hernia,Other,MedicalAdvice,Physicians)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@Length,@Bust,@Weight,@BadBreath,@Skin,@Lymphoid,@Thyroid,@Spine,@Limbs,@Joint,@Flatfoot,@Genitourinary,@Anal,@Hernia,@Other,@MedicalAdvice,@Physicians)";
        private string Update_SQL = @"Update Surgery Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
Length=@Length,
Bust=@Bust,
Weight=@Weight,
BadBreath=@BadBreath,
Skin=@Skin,
Lymphoid=@Lymphoid,
Thyroid=@Thyroid,
Spine=@Spine,
Limbs=@Limbs,
Joint=@Joint,
Flatfoot=@Flatfoot,
Genitourinary=@Genitourinary,
Anal=@Anal,
Hernia=@Hernia,
Other=@Other,
MedicalAdvice=@MedicalAdvice,
Physicians=@Physicians
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth ";

        public ReturnValue Add(Surgery model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@Length", OleDbType.VarWChar,8),
					new OleDbParameter("@Bust", OleDbType.VarWChar,8),
					new OleDbParameter("@Weight", OleDbType.VarWChar,8),
					new OleDbParameter("@BadBreath", OleDbType.VarWChar,50),
					new OleDbParameter("@Skin", OleDbType.VarWChar,128),
					new OleDbParameter("@Lymphoid", OleDbType.VarWChar,128),
					new OleDbParameter("@Thyroid", OleDbType.VarWChar,128),
					new OleDbParameter("@Spine", OleDbType.VarWChar,128),
					new OleDbParameter("@Limbs", OleDbType.VarWChar,128),
					new OleDbParameter("@Joint", OleDbType.VarWChar,128),
					new OleDbParameter("@Flatfoot", OleDbType.VarWChar,128),
					new OleDbParameter("@Genitourinary", OleDbType.VarWChar,128),
					new OleDbParameter("@Anal", OleDbType.VarWChar,128),
					new OleDbParameter("@Hernia", OleDbType.VarWChar,128),
					new OleDbParameter("@Other", OleDbType.LongVarWChar),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.Length;
            parameters[5].Value = model.Bust;
            parameters[6].Value = model.Weight;
            parameters[7].Value = model.BadBreath;
            parameters[8].Value = model.Skin;
            parameters[9].Value = model.Lymphoid;
            parameters[10].Value = model.Thyroid;
            parameters[11].Value = model.Spine;
            parameters[12].Value = model.Limbs;
            parameters[13].Value = model.Joint;
            parameters[14].Value = model.Flatfoot;
            parameters[15].Value = model.Genitourinary;
            parameters[16].Value = model.Anal;
            parameters[17].Value = model.Hernia;
            parameters[18].Value = model.Other;
            parameters[19].Value = model.MedicalAdvice;
            parameters[20].Value = model.Physicians;
            return OleDbHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Search(string EmployeeID, string YearMonth)
        {
            OleDbParameter[] parametersSearchID = { 
                new OleDbParameter("@EmployeeID", OleDbType.VarWChar, 18),
                new OleDbParameter("@YearMonth", OleDbType.VarWChar, 6)};
            parametersSearchID[0].Value = EmployeeID;
            parametersSearchID[1].Value = YearMonth;
            return OleDbHelper.Query(SearchID_SQL, parametersSearchID);
        }

        public ReturnValue Update(Surgery model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@Length", OleDbType.VarWChar,8),
					new OleDbParameter("@Bust", OleDbType.VarWChar,8),
					new OleDbParameter("@Weight", OleDbType.VarWChar,8),
					new OleDbParameter("@BadBreath", OleDbType.VarWChar,50),
					new OleDbParameter("@Skin", OleDbType.VarWChar,128),
					new OleDbParameter("@Lymphoid", OleDbType.VarWChar,128),
					new OleDbParameter("@Thyroid", OleDbType.VarWChar,128),
					new OleDbParameter("@Spine", OleDbType.VarWChar,128),
					new OleDbParameter("@Limbs", OleDbType.VarWChar,128),
					new OleDbParameter("@Joint", OleDbType.VarWChar,128),
					new OleDbParameter("@Flatfoot", OleDbType.VarWChar,128),
					new OleDbParameter("@Genitourinary", OleDbType.VarWChar,128),
					new OleDbParameter("@Anal", OleDbType.VarWChar,128),
					new OleDbParameter("@Hernia", OleDbType.VarWChar,128),
					new OleDbParameter("@Other", OleDbType.LongVarWChar),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.Length;
            parametersUpdate[3].Value = model.Bust;
            parametersUpdate[4].Value = model.Weight;
            parametersUpdate[5].Value = model.BadBreath;
            parametersUpdate[6].Value = model.Skin;
            parametersUpdate[7].Value = model.Lymphoid;
            parametersUpdate[8].Value = model.Thyroid;
            parametersUpdate[9].Value = model.Spine;
            parametersUpdate[10].Value = model.Limbs;
            parametersUpdate[11].Value = model.Joint;
            parametersUpdate[12].Value = model.Flatfoot;
            parametersUpdate[13].Value = model.Genitourinary;
            parametersUpdate[14].Value = model.Anal;
            parametersUpdate[15].Value = model.Hernia;
            parametersUpdate[16].Value = model.Other;
            parametersUpdate[17].Value = model.MedicalAdvice;
            parametersUpdate[18].Value = model.Physicians;
            parametersUpdate[19].Value = model.EmployeeID;
            parametersUpdate[20].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

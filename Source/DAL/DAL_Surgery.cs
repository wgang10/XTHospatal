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
    public class DAL_Surgery : IDAL_Surgery
    {
        private string SearchID_SQL = @"Select EmployeeID From Surgery
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert Into Surgery(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMonth,Length,Bust,Weight,BadBreath,Skin,Lymphoid,Thyroid,Spine,Limbs,Joint,Flatfoot,Genitourinary,Anal,Hernia,Other,MedicalAdvice,Physicians)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@Length,@Bust,@Weight,@BadBreath,@Skin,@Lymphoid,@Thyroid,@Spine,@Limbs,@Joint,@Flatfoot,@Genitourinary,@Anal,@Hernia,@Other,@MedicalAdvice,@Physicians)";
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
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth ";

        public ReturnValue Add(Surgery model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@Length", SqlDbType.NVarChar,8),
					new SqlParameter("@Bust", SqlDbType.NVarChar,8),
					new SqlParameter("@Weight", SqlDbType.NVarChar,8),
					new SqlParameter("@BadBreath", SqlDbType.NVarChar,50),
					new SqlParameter("@Skin", SqlDbType.NVarChar,128),
					new SqlParameter("@Lymphoid", SqlDbType.NVarChar,128),
					new SqlParameter("@Thyroid", SqlDbType.NVarChar,128),
					new SqlParameter("@Spine", SqlDbType.NVarChar,128),
					new SqlParameter("@Limbs", SqlDbType.NVarChar,128),
					new SqlParameter("@Joint", SqlDbType.NVarChar,128),
					new SqlParameter("@Flatfoot", SqlDbType.NVarChar,128),
					new SqlParameter("@Genitourinary", SqlDbType.NVarChar,128),
					new SqlParameter("@Anal", SqlDbType.NVarChar,128),
					new SqlParameter("@Hernia", SqlDbType.NVarChar,128),
					new SqlParameter("@Other", SqlDbType.NVarChar,256),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
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
            return SqlHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Search(string EmployeeID, string YearMonth)
        {
            SqlParameter[] parametersSearchID = { 
                new SqlParameter("@EmployeeID", SqlDbType.NVarChar, 18),
                new SqlParameter("@YearMonth", SqlDbType.NVarChar, 6)};
            parametersSearchID[0].Value = EmployeeID;
            parametersSearchID[1].Value = YearMonth;
            return SqlHelper.Query(SearchID_SQL, parametersSearchID);
        }

        public ReturnValue Update(Surgery model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@Length", SqlDbType.NVarChar,8),
					new SqlParameter("@Bust", SqlDbType.NVarChar,8),
					new SqlParameter("@Weight", SqlDbType.NVarChar,8),
					new SqlParameter("@BadBreath", SqlDbType.NVarChar,50),
					new SqlParameter("@Skin", SqlDbType.NVarChar,128),
					new SqlParameter("@Lymphoid", SqlDbType.NVarChar,128),
					new SqlParameter("@Thyroid", SqlDbType.NVarChar,128),
					new SqlParameter("@Spine", SqlDbType.NVarChar,128),
					new SqlParameter("@Limbs", SqlDbType.NVarChar,128),
					new SqlParameter("@Joint", SqlDbType.NVarChar,128),
					new SqlParameter("@Flatfoot", SqlDbType.NVarChar,128),
					new SqlParameter("@Genitourinary", SqlDbType.NVarChar,128),
					new SqlParameter("@Anal", SqlDbType.NVarChar,128),
					new SqlParameter("@Hernia", SqlDbType.NVarChar,128),
					new SqlParameter("@Other", SqlDbType.NVarChar,256),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.Length;
            parametersUpdate[5].Value = model.Bust;
            parametersUpdate[6].Value = model.Weight;
            parametersUpdate[7].Value = model.BadBreath;
            parametersUpdate[8].Value = model.Skin;
            parametersUpdate[9].Value = model.Lymphoid;
            parametersUpdate[10].Value = model.Thyroid;
            parametersUpdate[11].Value = model.Spine;
            parametersUpdate[12].Value = model.Limbs;
            parametersUpdate[13].Value = model.Joint;
            parametersUpdate[14].Value = model.Flatfoot;
            parametersUpdate[15].Value = model.Genitourinary;
            parametersUpdate[16].Value = model.Anal;
            parametersUpdate[17].Value = model.Hernia;
            parametersUpdate[18].Value = model.Other;
            parametersUpdate[19].Value = model.MedicalAdvice;
            parametersUpdate[20].Value = model.Physicians;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}


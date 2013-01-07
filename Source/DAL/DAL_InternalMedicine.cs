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
    public class DAL_InternalMedicine : IDAL_InternalMedicine
    {
        private string SearchID_SQL = @"Select EmployeeID From InternalMedicine
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert Into InternalMedicine(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMonth,BloodPressure,DevelopmentStatus,Neurological,Lung,HeartBlood,AbdominalOrgans,Liver,Spleen,Other,MedicalAdvice,Physicians)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@BloodPressure,@DevelopmentStatus,@Neurological,@Lung,@HeartBlood,@AbdominalOrgans,@Liver,@Spleen,@Other,@MedicalAdvice,@Physicians)";
        private string Update_SQL = @"Update InternalMedicine Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
BloodPressure=@BloodPressure,
DevelopmentStatus=@DevelopmentStatus,
Neurological=@Neurological,
Lung=@Lung,
HeartBlood=@HeartBlood,
AbdominalOrgans=@AbdominalOrgans,
Liver=@Liver,
Spleen=@Spleen,
Other=@Other,
MedicalAdvice=@MedicalAdvice,
Physicians=@Physicians
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth ";

        public ReturnValue Add(InternalMedicine model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@BloodPressure", SqlDbType.NVarChar,12),
					new SqlParameter("@DevelopmentStatus", SqlDbType.NVarChar,256),
					new SqlParameter("@Neurological", SqlDbType.NVarChar,256),
					new SqlParameter("@Lung", SqlDbType.NVarChar,256),
					new SqlParameter("@HeartBlood", SqlDbType.NVarChar,256),
					new SqlParameter("@AbdominalOrgans", SqlDbType.NVarChar,256),
					new SqlParameter("@Liver", SqlDbType.NVarChar,256),
					new SqlParameter("@Spleen", SqlDbType.NVarChar,256),
					new SqlParameter("@Other", SqlDbType.NVarChar,256),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.BloodPressure;
            parameters[5].Value = model.DevelopmentStatus;
            parameters[6].Value = model.Neurological;
            parameters[7].Value = model.Lung;
            parameters[8].Value = model.HeartBlood;
            parameters[9].Value = model.AbdominalOrgans;
            parameters[10].Value = model.Liver;
            parameters[11].Value = model.Spleen;
            parameters[12].Value = model.Other;
            parameters[13].Value = model.MedicalAdvice;
            parameters[14].Value = model.Physicians;
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

        public ReturnValue Update(InternalMedicine model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@BloodPressure", SqlDbType.NVarChar,12),
					new SqlParameter("@DevelopmentStatus", SqlDbType.NVarChar,256),
					new SqlParameter("@Neurological", SqlDbType.NVarChar,256),
					new SqlParameter("@Lung", SqlDbType.NVarChar,256),
					new SqlParameter("@HeartBlood", SqlDbType.NVarChar,256),
					new SqlParameter("@AbdominalOrgans", SqlDbType.NVarChar,256),
					new SqlParameter("@Liver", SqlDbType.NVarChar,256),
					new SqlParameter("@Spleen", SqlDbType.NVarChar,256),
					new SqlParameter("@Other", SqlDbType.NVarChar,256),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.BloodPressure;
            parametersUpdate[5].Value = model.DevelopmentStatus;
            parametersUpdate[6].Value = model.Neurological;
            parametersUpdate[7].Value = model.Lung;
            parametersUpdate[8].Value = model.HeartBlood;
            parametersUpdate[9].Value = model.AbdominalOrgans;
            parametersUpdate[10].Value = model.Liver;
            parametersUpdate[11].Value = model.Spleen;
            parametersUpdate[12].Value = model.Other;
            parametersUpdate[13].Value = model.MedicalAdvice;
            parametersUpdate[14].Value = model.Physicians;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

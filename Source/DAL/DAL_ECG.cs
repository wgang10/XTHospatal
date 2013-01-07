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
    public class DAL_ECG : IDAL_ECG
    {
        private string SearchID_SQL = @"Select EmployeeID From ECG
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert Into ECG(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMonth,ECGNo,ClinicalDiagnosis,UsedDrugs,SummaryHistory,SummaryBody,PatientSituation,MedicalAdvice,ECG,Physicians)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@ECGNo,@ClinicalDiagnosis,@UsedDrugs,@SummaryHistory,@SummaryBody,@PatientSituation,@MedicalAdvice,@ECG,@Physicians)";
        private string Update_SQL = @"Update ECG Set 
TRANS_STATE='2', 
UPDATER_ID=@UPDATER_ID, 
TERMINAL_CD=@TERMINAL_CD, 
ECGNo=@ECGNo, 
ClinicalDiagnosis=@ClinicalDiagnosis, 
UsedDrugs=@UsedDrugs, 
SummaryHistory=@SummaryHistory, 
SummaryBody=@SummaryBody, 
PatientSituation=@PatientSituation, 
MedicalAdvice=@MedicalAdvice, 
ECG=@ECG, 
Physicians=@Physicians 
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth ";

        public ReturnValue Add(ECG model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@ECGNo", SqlDbType.NVarChar,10),
					new SqlParameter("@ClinicalDiagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@UsedDrugs", SqlDbType.NVarChar,256),
					new SqlParameter("@SummaryHistory", SqlDbType.NVarChar,256),
					new SqlParameter("@SummaryBody", SqlDbType.NVarChar,256),
					new SqlParameter("@PatientSituation", SqlDbType.NVarChar,1),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@ECG", SqlDbType.Image),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.ECGNo;
            parameters[5].Value = model.ClinicalDiagnosis;
            parameters[6].Value = model.UsedDrugs;
            parameters[7].Value = model.SummaryHistory;
            parameters[8].Value = model.SummaryBody;
            parameters[9].Value = model.PatientSituation;
            parameters[10].Value = model.MedicalAdvice;
            if (model.ECGImage == null)
            {
                parameters[11].Value = DBNull.Value;
            }
            else
            {
                parameters[11].Value = model.ECGImage;
            }
            parameters[12].Value = model.Physicians;
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

        public ReturnValue Update(ECG model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@ECGNo", SqlDbType.NVarChar,10),
					new SqlParameter("@ClinicalDiagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@UsedDrugs", SqlDbType.NVarChar,256),
					new SqlParameter("@SummaryHistory", SqlDbType.NVarChar,256),
					new SqlParameter("@SummaryBody", SqlDbType.NVarChar,256),
					new SqlParameter("@PatientSituation", SqlDbType.NVarChar,1),
					new SqlParameter("@MedicalAdvice", SqlDbType.NVarChar,1024),
					new SqlParameter("@ECG", SqlDbType.Image),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.ECGNo;
            parametersUpdate[5].Value = model.ClinicalDiagnosis;
            parametersUpdate[6].Value = model.UsedDrugs;
            parametersUpdate[7].Value = model.SummaryHistory;
            parametersUpdate[8].Value = model.SummaryBody;
            parametersUpdate[9].Value = model.PatientSituation;
            parametersUpdate[10].Value = model.MedicalAdvice;
            if (model.ECGImage == null)
            {
                parametersUpdate[11].Value = DBNull.Value;
            }
            else
            {
                parametersUpdate[11].Value = model.ECGImage;
            }
            parametersUpdate[12].Value = model.Physicians;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

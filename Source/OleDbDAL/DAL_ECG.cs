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
    public class DAL_ECG : IDAL_ECG
    {
        private string SearchID_SQL = @"Select EmployeeID From ECG
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into ECG(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,ECGNo,ClinicalDiagnosis,UsedDrugs,SummaryHistory,SummaryBody,PatientSituation,MedicalAdvice,ECG,Physicians)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@ECGNo,@ClinicalDiagnosis,@UsedDrugs,@SummaryHistory,@SummaryBody,@PatientSituation,@MedicalAdvice,@ECG,@Physicians)";
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
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@ECGNo", OleDbType.VarWChar,10),
					new OleDbParameter("@ClinicalDiagnosis", OleDbType.LongVarWChar),
					new OleDbParameter("@UsedDrugs", OleDbType.LongVarWChar),
					new OleDbParameter("@SummaryHistory", OleDbType.LongVarWChar),
					new OleDbParameter("@SummaryBody", OleDbType.LongVarWChar),
					new OleDbParameter("@PatientSituation", OleDbType.VarWChar,1),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@ECG", OleDbType.LongVarBinary),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50)};
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

        public ReturnValue Update(ECG model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@ECGNo", OleDbType.VarWChar,10),
					new OleDbParameter("@ClinicalDiagnosis", OleDbType.LongVarWChar),
					new OleDbParameter("@UsedDrugs", OleDbType.LongVarWChar),
					new OleDbParameter("@SummaryHistory", OleDbType.LongVarWChar),
					new OleDbParameter("@SummaryBody", OleDbType.LongVarWChar),
					new OleDbParameter("@PatientSituation", OleDbType.VarWChar,1),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@ECG", OleDbType.LongVarBinary),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.ECGNo;
            parametersUpdate[3].Value = model.ClinicalDiagnosis;
            parametersUpdate[4].Value = model.UsedDrugs;
            parametersUpdate[5].Value = model.SummaryHistory;
            parametersUpdate[6].Value = model.SummaryBody;
            parametersUpdate[7].Value = model.PatientSituation;
            parametersUpdate[8].Value = model.MedicalAdvice;
            if (model.ECGImage == null)
            {
                parametersUpdate[9].Value = DBNull.Value;
            }
            else
            {
                parametersUpdate[9].Value = model.ECGImage;
            }
            parametersUpdate[10].Value = model.Physicians;
            parametersUpdate[11].Value = model.EmployeeID;
            parametersUpdate[12].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

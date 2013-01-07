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
    public class DAL_InternalMedicine : IDAL_InternalMedicine
    {
        private string SearchID_SQL = @"Select EmployeeID From InternalMedicine
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into InternalMedicine(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,BloodPressure,BloodPressure1,DevelopmentStatus,Neurological,Lung,HeartBlood,AbdominalOrgans,Liver,Spleen,Other,MedicalAdvice,Physicians)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@BloodPressure,@BloodPressure1,@DevelopmentStatus,@Neurological,@Lung,@HeartBlood,@AbdominalOrgans,@Liver,@Spleen,@Other,@MedicalAdvice,@Physicians)";
        private string Update_SQL = @"Update InternalMedicine Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
BloodPressure=@BloodPressure,
BloodPressure1=@BloodPressure1,
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
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth ";

        public ReturnValue Add(InternalMedicine model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@BloodPressure", OleDbType.VarWChar,12),
                    new OleDbParameter("@BloodPressure1", OleDbType.VarWChar,12),
					new OleDbParameter("@DevelopmentStatus", OleDbType.LongVarWChar),
					new OleDbParameter("@Neurological", OleDbType.LongVarWChar),
					new OleDbParameter("@Lung", OleDbType.LongVarWChar),
					new OleDbParameter("@HeartBlood", OleDbType.LongVarWChar),
					new OleDbParameter("@AbdominalOrgans", OleDbType.LongVarWChar),
					new OleDbParameter("@Liver", OleDbType.LongVarWChar),
					new OleDbParameter("@Spleen", OleDbType.LongVarWChar),
					new OleDbParameter("@Other", OleDbType.LongVarWChar),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.BloodPressure;
            parameters[5].Value = model.BloodPressure1;
            parameters[6].Value = model.DevelopmentStatus;
            parameters[7].Value = model.Neurological;
            parameters[8].Value = model.Lung;
            parameters[9].Value = model.HeartBlood;
            parameters[10].Value = model.AbdominalOrgans;
            parameters[11].Value = model.Liver;
            parameters[12].Value = model.Spleen;
            parameters[13].Value = model.Other;
            parameters[14].Value = model.MedicalAdvice;
            parameters[15].Value = model.Physicians;
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

        public ReturnValue Update(InternalMedicine model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@BloodPressure", OleDbType.VarWChar,12),
                    new OleDbParameter("@BloodPressure1", OleDbType.VarWChar,12),
					new OleDbParameter("@DevelopmentStatus", OleDbType.LongVarWChar),
					new OleDbParameter("@Neurological", OleDbType.LongVarWChar),
					new OleDbParameter("@Lung", OleDbType.LongVarWChar),
					new OleDbParameter("@HeartBlood", OleDbType.LongVarWChar),
					new OleDbParameter("@AbdominalOrgans", OleDbType.LongVarWChar),
					new OleDbParameter("@Liver", OleDbType.LongVarWChar),
					new OleDbParameter("@Spleen", OleDbType.LongVarWChar),
					new OleDbParameter("@Other", OleDbType.LongVarWChar),
					new OleDbParameter("@MedicalAdvice", OleDbType.LongVarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.BloodPressure;
            parametersUpdate[3].Value = model.BloodPressure1;
            parametersUpdate[4].Value = model.DevelopmentStatus;
            parametersUpdate[5].Value = model.Neurological;
            parametersUpdate[6].Value = model.Lung;
            parametersUpdate[7].Value = model.HeartBlood;
            parametersUpdate[8].Value = model.AbdominalOrgans;
            parametersUpdate[9].Value = model.Liver;
            parametersUpdate[10].Value = model.Spleen;
            parametersUpdate[11].Value = model.Other;
            parametersUpdate[12].Value = model.MedicalAdvice;
            parametersUpdate[13].Value = model.Physicians;
            parametersUpdate[14].Value = model.EmployeeID;
            parametersUpdate[15].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

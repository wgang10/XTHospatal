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
    public class DAL_Bexamination : IDAL_Bexamination
    {
        private string SearchID_SQL = @"Select EmployeeID From Bexamination
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Bexamination(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,BID,HistorySigns,LaboratoryExamination,Diagnosis,Purpose,Results,BImage,Physicians)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@BID,@HistorySigns,@LaboratoryExamination,@Diagnosis,@Purpose,@Results,@BImage,@Physicians)";
        private string Update_SQL = @"Update Bexamination Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
BID=@BID,
HistorySigns=@HistorySigns,
LaboratoryExamination=@LaboratoryExamination,
Diagnosis=@Diagnosis,
Purpose=@Purpose,
Results=@Results,
BImage=@BImage,
Physicians=@Physicians
Where EmployeeID=@EmployeeID and YearMoth=@YearMonth ";

        public ReturnValue Add(Bexamination model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@BID", OleDbType.VarWChar,10),
					new OleDbParameter("@HistorySigns", OleDbType.LongVarWChar),
					new OleDbParameter("@LaboratoryExamination", OleDbType.LongVarWChar),
					new OleDbParameter("@Diagnosis", OleDbType.LongVarWChar),
					new OleDbParameter("@Purpose", OleDbType.LongVarWChar),
					new OleDbParameter("@Results", OleDbType.LongVarWChar),
					new OleDbParameter("@BImage", OleDbType.LongVarBinary),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.BID;
            parameters[5].Value = model.HistorySigns;
            parameters[6].Value = model.LaboratoryExamination;
            parameters[7].Value = model.Diagnosis;
            parameters[8].Value = model.Purpose;
            parameters[9].Value = model.Results;
            if (model.BImage == null)
            {
                parameters[10].Value = DBNull.Value;
            }
            else
            {
                parameters[10].Value = model.BImage;
            }
            parameters[11].Value = model.Physicians;
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

        public ReturnValue Update(Bexamination model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@BID", OleDbType.VarWChar,10),
					new OleDbParameter("@HistorySigns", OleDbType.LongVarWChar),
					new OleDbParameter("@LaboratoryExamination", OleDbType.LongVarWChar),
					new OleDbParameter("@Diagnosis", OleDbType.LongVarWChar),
					new OleDbParameter("@Purpose", OleDbType.LongVarWChar),
					new OleDbParameter("@Results", OleDbType.LongVarWChar),
					new OleDbParameter("@BImage", OleDbType.LongVarBinary),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.BID;
            parametersUpdate[3].Value = model.HistorySigns;
            parametersUpdate[4].Value = model.LaboratoryExamination;
            parametersUpdate[5].Value = model.Diagnosis;
            parametersUpdate[6].Value = model.Purpose;
            parametersUpdate[7].Value = model.Results;
            if (model.BImage == null)
            {
                parametersUpdate[8].Value = DBNull.Value;
            }
            else
            {
                parametersUpdate[8].Value = model.BImage;
            }
            parametersUpdate[9].Value = model.Physicians;
            parametersUpdate[10].Value = model.EmployeeID;
            parametersUpdate[11].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

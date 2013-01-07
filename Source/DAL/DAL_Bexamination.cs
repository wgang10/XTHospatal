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
    public class DAL_Bexamination :IDAL_Bexamination
    {
        private string SearchID_SQL = @"Select EmployeeID From Bexamination
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert Into Bexamination(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMonth,BID,HistorySigns,LaboratoryExamination,Diagnosis,Purpose,Results,BImage,Physicians)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@BID,@HistorySigns,@LaboratoryExamination,@Diagnosis,@Purpose,@Results,@BImage,@Physicians)";
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
Where EmployeeID=@EmployeeID and YearMonth=@YearMonth ";

        public ReturnValue Add(Bexamination model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@BID", SqlDbType.NVarChar,10),
					new SqlParameter("@HistorySigns", SqlDbType.NVarChar,256),
					new SqlParameter("@LaboratoryExamination", SqlDbType.NVarChar,256),
					new SqlParameter("@Diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@Purpose", SqlDbType.NVarChar,256),
					new SqlParameter("@Results", SqlDbType.NVarChar,256),
					new SqlParameter("@BImage", SqlDbType.Image),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
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

        public ReturnValue Update(Bexamination model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@BID", SqlDbType.NVarChar,10),
					new SqlParameter("@HistorySigns", SqlDbType.NVarChar,256),
					new SqlParameter("@LaboratoryExamination", SqlDbType.NVarChar,256),
					new SqlParameter("@Diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@Purpose", SqlDbType.NVarChar,256),
					new SqlParameter("@Results", SqlDbType.NVarChar,256),
					new SqlParameter("@BImage", SqlDbType.Image),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.BID;
            parametersUpdate[5].Value = model.HistorySigns;
            parametersUpdate[6].Value = model.LaboratoryExamination;
            parametersUpdate[7].Value = model.Diagnosis;
            parametersUpdate[8].Value = model.Purpose;
            parametersUpdate[9].Value = model.Results;
            if (model.BImage == null)
            {
                parametersUpdate[10].Value = DBNull.Value;
            }
            else
            {
                parametersUpdate[10].Value = model.BImage;
            }
            parametersUpdate[11].Value = model.Physicians;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

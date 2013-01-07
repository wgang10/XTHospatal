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
    public class DAL_Report : IDAL_Report
    {
        private string SearchID_SQL = @"Select EmployeeID From Report
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert Into Report(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMonth,ChestPerspective,Laboratory,Review,Remarks)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@ChestPerspective,@Laboratory,@Review,@Remarks)";
        private string Update_SQL = @"Update Report Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
ChestPerspective=@ChestPerspective,
Laboratory=@Laboratory,
Review=@Review,
Remarks=@Remarks
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth  ";

        public ReturnValue Add(Report model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@ChestPerspective", SqlDbType.NVarChar,256),
					new SqlParameter("@Laboratory", SqlDbType.NVarChar,256),
					new SqlParameter("@Review", SqlDbType.NVarChar,1024),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,1024)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.ChestPerspective;
            parameters[5].Value = model.Laboratory;
            parameters[6].Value = model.Review;
            parameters[7].Value = model.Remarks;
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

        public ReturnValue Update(Report model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@ChestPerspective", SqlDbType.NVarChar,256),
					new SqlParameter("@Laboratory", SqlDbType.NVarChar,256),
					new SqlParameter("@Review", SqlDbType.NVarChar,1024),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,1024)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.ChestPerspective;
            parametersUpdate[5].Value = model.Laboratory;
            parametersUpdate[6].Value = model.Review;
            parametersUpdate[7].Value = model.Remarks;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

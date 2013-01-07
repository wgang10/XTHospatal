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
    public class DAL_Report : IDAL_Report
    {
        private string SearchID_SQL = @"Select EmployeeID From Report
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Report(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,ChestPerspective,Laboratory,Review,Remarks)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@ChestPerspective,@Laboratory,@Review,@Remarks)";
        private string Update_SQL = @"Update Report Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
ChestPerspective=@ChestPerspective,
Laboratory=@Laboratory,
Review=@Review,
Remarks=@Remarks
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth  ";

        public ReturnValue Add(Report model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@ChestPerspective", OleDbType.LongVarWChar),
					new OleDbParameter("@Laboratory", OleDbType.LongVarWChar),
					new OleDbParameter("@Review", OleDbType.LongVarWChar),
					new OleDbParameter("@Remarks", OleDbType.LongVarWChar)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.ChestPerspective;
            parameters[5].Value = model.Laboratory;
            parameters[6].Value = model.Review;
            parameters[7].Value = model.Remarks;
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

        public ReturnValue Update(Report model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@ChestPerspective", OleDbType.LongVarWChar),
					new OleDbParameter("@Laboratory", OleDbType.LongVarWChar),
					new OleDbParameter("@Review", OleDbType.LongVarWChar),
					new OleDbParameter("@Remarks", OleDbType.LongVarWChar),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.ChestPerspective;
            parametersUpdate[3].Value = model.Laboratory;
            parametersUpdate[4].Value = model.Review;
            parametersUpdate[5].Value = model.Remarks;
            parametersUpdate[6].Value = model.EmployeeID;
            parametersUpdate[7].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

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
    public class DAL_Xray : IDAL_Xray
    {
        private string SearchID_SQL = @"Select EmployeeID From Xray
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Xray(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,PhotoNo,Symptoms,Laboratory,Diagnosis,Perspective,Camera,Results,XImage,Physicians)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@PhotoNo,@Symptoms,@Laboratory,@Diagnosis,@Perspective,@Camera,@Results,@XImage,@Physicians)";
        private string Update_SQL = @"Update Xray Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
PhotoNo=@PhotoNo,
Symptoms=@Symptoms,
Laboratory=@Laboratory,
Diagnosis=@Diagnosis,
Perspective=@Perspective,
Camera=@Camera,
Results=@Results,
XImage=@XImage,
Physicians=@Physicians
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth  ";
        public ReturnValue Add(Xray model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@PhotoNo", OleDbType.VarWChar,10),
					new OleDbParameter("@Symptoms", OleDbType.LongVarWChar),
					new OleDbParameter("@Laboratory", OleDbType.LongVarWChar),
					new OleDbParameter("@Diagnosis", OleDbType.LongVarWChar),
					new OleDbParameter("@Perspective", OleDbType.LongVarWChar),
					new OleDbParameter("@Camera", OleDbType.LongVarWChar),
					new OleDbParameter("@Results", OleDbType.LongVarWChar),
					new OleDbParameter("@XImage", OleDbType.LongVarBinary),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.PhotoNo;
            parameters[5].Value = model.Symptoms;
            parameters[6].Value = model.Laboratory;
            parameters[7].Value = model.Diagnosis;
            parameters[8].Value = model.Perspective;
            parameters[9].Value = model.Camera;
            parameters[10].Value = model.Results;
            if (model.XImage == null)
            {
                parameters[11].Value = DBNull.Value;
            }
            else
            {
                parameters[11].Value = model.XImage;
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

        public ReturnValue Update(Xray model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@PhotoNo", OleDbType.VarWChar,10),
					new OleDbParameter("@Symptoms", OleDbType.LongVarWChar),
					new OleDbParameter("@Laboratory", OleDbType.LongVarWChar),
					new OleDbParameter("@Diagnosis", OleDbType.LongVarWChar),
					new OleDbParameter("@Perspective", OleDbType.LongVarWChar),
					new OleDbParameter("@Camera", OleDbType.LongVarWChar),
					new OleDbParameter("@Results", OleDbType.LongVarWChar),
					new OleDbParameter("@XImage", OleDbType.LongVarBinary),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.PhotoNo;
            parametersUpdate[3].Value = model.Symptoms;
            parametersUpdate[4].Value = model.Laboratory;
            parametersUpdate[5].Value = model.Diagnosis;
            parametersUpdate[6].Value = model.Perspective;
            parametersUpdate[7].Value = model.Camera;
            parametersUpdate[8].Value = model.Results;
            if (model.XImage == null)
            {
                parametersUpdate[9].Value = DBNull.Value;
            }
            else
            {
                parametersUpdate[9].Value = model.XImage;
            }
            parametersUpdate[10].Value = model.Physicians;
            parametersUpdate[11].Value = model.EmployeeID;
            parametersUpdate[12].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

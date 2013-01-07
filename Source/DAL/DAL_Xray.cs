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
    public class DAL_Xray : IDAL_Xray
    {
        private string SearchID_SQL = @"Select EmployeeID From Xray
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth";
        private string Add_SQL = @"Insert Into Xray(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMonth,PhotoNo,Symptoms,Laboratory,Diagnosis,Perspective,Camera,Results,XImage,Physicians)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@PhotoNo,@Symptoms,@Laboratory,@Diagnosis,@Perspective,@Camera,@Results,@XImage,@Physicians)";
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
Where EmployeeID=@EmployeeID And YearMonth=@YearMonth  ";
        public ReturnValue Add(Xray model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@PhotoNo", SqlDbType.NVarChar,10),
					new SqlParameter("@Symptoms", SqlDbType.NVarChar,256),
					new SqlParameter("@Laboratory", SqlDbType.NVarChar,256),
					new SqlParameter("@Diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@Perspective", SqlDbType.NVarChar,256),
					new SqlParameter("@Camera", SqlDbType.NVarChar,256),
					new SqlParameter("@Results", SqlDbType.NVarChar,1024),
					new SqlParameter("@XImage", SqlDbType.Image),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
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

        public ReturnValue Update(Xray model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar,18),
					new SqlParameter("@YearMonth", SqlDbType.NVarChar,6),
					new SqlParameter("@PhotoNo", SqlDbType.NVarChar,10),
					new SqlParameter("@Symptoms", SqlDbType.NVarChar,256),
					new SqlParameter("@Laboratory", SqlDbType.NVarChar,256),
					new SqlParameter("@Diagnosis", SqlDbType.NVarChar,256),
					new SqlParameter("@Perspective", SqlDbType.NVarChar,256),
					new SqlParameter("@Camera", SqlDbType.NVarChar,256),
					new SqlParameter("@Results", SqlDbType.NVarChar,1024),
					new SqlParameter("@XImage", SqlDbType.Image),
					new SqlParameter("@Physicians", SqlDbType.NVarChar,50)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.EmployeeID;
            parametersUpdate[3].Value = model.YearMonth;
            parametersUpdate[4].Value = model.PhotoNo;
            parametersUpdate[5].Value = model.Symptoms;
            parametersUpdate[6].Value = model.Laboratory;
            parametersUpdate[7].Value = model.Diagnosis;
            parametersUpdate[8].Value = model.Perspective;
            parametersUpdate[9].Value = model.Camera;
            parametersUpdate[10].Value = model.Results;
            if (model.XImage == null)
            {
                parametersUpdate[11].Value = DBNull.Value;
            }
            else
            {
                parametersUpdate[11].Value = model.XImage;
            }
            parametersUpdate[12].Value = model.Physicians;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

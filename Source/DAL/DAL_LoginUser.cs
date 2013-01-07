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
    public class DAL_LoginUser : IDAL_LoginUser
    {
        private string SearchID_SQL = @"Select UserID From LoginUser Where UserID = @UserID";
        private string Add_SQL = @"Insert Into LoginUser(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,UserID,UserPwd,UserType,MEMO)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@UserID,@UserPwd,@UserType,@MEMO)";
        private string Update_SQL = @"Update LoginUser Set 
UPDATE_DATETIME=CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
UserPwd=@UserPwd,
UserType=@UserType,
MEMO=@MEMO
Where UserID=@UserID ";
        private string Delete_SQL = @"Delete from LoginUser Where UserID=@UserID";

        private string GetList_SQL = @"Select CREATE_DATETIME,
UPDATE_DATETIME,TRANS_STATE,
UPDATER_ID,TERMINAL_CD,
UserID,UserPwd,
(Case UserType When '0' Then '管理员' When '1' Then '高级用户' When '2' Then '一般用户' End) As UserTypeName,
UserType,MEMO From LoginUser Order by UserID";

        private string GetUserPwd_SQL = @"Select UserPwd,UserType From LoginUser Where UserID = @UserID";

        private string GetEmployeePWD_SQL = @"Select EmployeePWD,EmployeeID,EmployeeEmail,EmployeePhone,EmployeeValidateCode From Employee Where EmployeeGZID = @EmployeeGZID";

        private string GetPWDByEmployeeID_SQL = @"Select EmployeePWD,EmployeeID,EmployeeEmail,EmployeePhone,EmployeeValidateCode From Employee Where EmployeeID = @EmployeeID";

        private string GetYearMonth_SQL = @"Select SelectYearMonth,SelectYearMonth As SelectYearMonthValue From YearMonth Order By SelectYearMonth";

        private string SearchYearMonth_SQL = @"Select SelectYearMonth From YearMonth Where SelectYearMonth = @SelectYearMonth";

        private string AddYearMonth_SQL = @"Insert Into YearMonth(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,SelectYearMonth)
Values (
CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),CONVERT(VARCHAR,GETDATE(),112)+REPLACE(CONVERT(VARCHAR,GETDATE(),108),':',''),'1',@UPDATER_ID,@TERMINAL_CD,@SelectYearMonth)";

        public ReturnValue Add(LoginUser model)
        {
            SqlParameter[] parametersAdd = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.NVarChar,1),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,256)};
            parametersAdd[0].Value = model.UPDATER_ID;
            parametersAdd[1].Value = model.TERMINAL_CD;
            parametersAdd[2].Value = model.UserID;
            parametersAdd[3].Value = model.UserPwd;
            parametersAdd[4].Value = model.UserType;
            parametersAdd[5].Value = model.MEMO;
            return SqlHelper.ExecuteSql(Add_SQL, parametersAdd);
        }

        public ReturnValue Search(string UserID)
        {
            SqlParameter[] parametersSearchID = { new SqlParameter("@UserID", SqlDbType.NVarChar, 50) };
            parametersSearchID[0].Value = UserID;
            return SqlHelper.Query(SearchID_SQL, parametersSearchID);
        }

        public ReturnValue Update(LoginUser model)
        {
            SqlParameter[] parametersUpdate = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@UserID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.NVarChar,1),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,256)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.UserID;
            parametersUpdate[3].Value = model.UserPwd;
            parametersUpdate[4].Value = model.UserType;
            parametersUpdate[5].Value = model.MEMO;
            return SqlHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }

        public ReturnValue Delete(string UserID)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = UserID;
            return SqlHelper.ExecuteSql(Delete_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return SqlHelper.Query(GetList_SQL);
        }

        public ReturnValue GetUserPwd(string UserID)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = UserID;
            return SqlHelper.Query(GetUserPwd_SQL, parameters);
        }

        public ReturnValue GetEmployeePWD(string EmployeeGZID)
        {
            SqlParameter[] parameters = { new SqlParameter("@EmployeeGZID", SqlDbType.NVarChar, 8) };
            parameters[0].Value = EmployeeGZID;
            return SqlHelper.Query(GetEmployeePWD_SQL, parameters);
        }

        public ReturnValue GetPWDByEmployeeID(string EmployeeID)
        {
            SqlParameter[] parameters = { new SqlParameter("@EmployeeID", SqlDbType.NVarChar, 50) };
            parameters[0].Value = EmployeeID;
            return SqlHelper.Query(GetPWDByEmployeeID_SQL, parameters);
        }

        public ReturnValue GetYearMonth()
        {
            return SqlHelper.Query(GetYearMonth_SQL);
        }

        public ReturnValue SearchYearMonth(string YearMonth)
        {
            SqlParameter[] parameters = { new SqlParameter("@SelectYearMonth", SqlDbType.NVarChar, 6) };
            parameters[0].Value = YearMonth;
            return SqlHelper.Query(SearchYearMonth_SQL, parameters);
        }

        public ReturnValue AddYearMonth(string LoginUserID, string TerminalCD, string YearMonth)
        {
            SqlParameter[] parametersAdd = {
					new SqlParameter("@UPDATER_ID", SqlDbType.NVarChar,12),
					new SqlParameter("@TERMINAL_CD", SqlDbType.NVarChar,256),
					new SqlParameter("@SelectYearMonth", SqlDbType.NVarChar,6)};
            parametersAdd[0].Value = LoginUserID;
            parametersAdd[1].Value = TerminalCD;
            parametersAdd[2].Value = YearMonth;
            return SqlHelper.ExecuteSql(AddYearMonth_SQL, parametersAdd);
        }


        public ReturnValue StatisticNums()
        {
            throw new NotImplementedException();
        }
    }
}

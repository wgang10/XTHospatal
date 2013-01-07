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
    public class DAL_LoginUser : IDAL_LoginUser
    {
        private string SearchID_SQL = @"Select UserID From LoginUser Where UserID = @UserID";
        private string Add_SQL = @"Insert Into LoginUser(
[CREATE_DATETIME],[UPDATE_DATETIME],[TRANS_STATE],[UPDATER_ID],[TERMINAL_CD],[UserID],[UserPwd],[UserType],[MEMO])
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',[@UPDATER_ID],[@TERMINAL_CD],[@UserID],[@UserPwd],[@UserType],[@MEMO])";
        private string Update_SQL = @"Update LoginUser Set 
[UPDATE_DATETIME]=FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),
[TRANS_STATE]='2',
[UPDATER_ID]=[@UPDATER_ID],
[TERMINAL_CD]=[@TERMINAL_CD],
[UserPwd]=[@UserPwd],
[UserType]=[@UserType],
[MEMO]=[@MEMO]
Where [UserID]=[@UserID] ";
        private string Delete_SQL = @"Delete from LoginUser Where UserID=@UserID";

        private string GetList_SQL = @"Select CREATE_DATETIME,
UPDATE_DATETIME,TRANS_STATE,
UPDATER_ID,TERMINAL_CD,
UserID,UserPwd,
Switch(UserType = '0','管理员',UserType = '1','高级用户',UserType = '2','一般用户') AS UserTypeName,
UserType,MEMO From LoginUser Order by UserID";

        private string GetUserPwd_SQL = @"Select UserPwd,UserType From LoginUser Where UserID = @UserID";

        private string GetEmployeePWD_SQL = @"Select EmployeePWD,EmployeeID,EmployeeName,EmployeeEmail,EmployeePhone,EmployeeValidateCode From Employee Where EmployeeGZID = @EmployeeGZID";

        private string GetPWDByEmployeeID_SQL = @"Select EmployeePWD,EmployeeID,EmployeeEmail,EmployeePhone,EmployeeValidateCode From Employee Where EmployeeID = @EmployeeID";

        private string GetYearMonth_SQL = @"Select SelectYearMonth,SelectYearMonth As SelectYearMonthValue From YearMonth Where 1=1 Order By SelectYearMonth Desc";

        private string SearchYearMonth_SQL = @"Select SelectYearMonth From YearMonth Where SelectYearMonth = @SelectYearMonth";

        private string AddYearMonth_SQL = @"Insert Into YearMonth(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,SelectYearMonth)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@SelectYearMonth)";

        public ReturnValue Add(LoginUser model)
        {
            OleDbParameter[] parametersAdd = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@UserID", OleDbType.VarWChar,50),
					new OleDbParameter("@UserPwd", OleDbType.VarWChar,50),
					new OleDbParameter("@UserType", OleDbType.VarWChar,1),
					new OleDbParameter("@MEMO", OleDbType.LongVarWChar)};
            parametersAdd[0].Value = model.UPDATER_ID;
            parametersAdd[1].Value = model.TERMINAL_CD;
            parametersAdd[2].Value = model.UserID;
            parametersAdd[3].Value = model.UserPwd;
            parametersAdd[4].Value = model.UserType;
            parametersAdd[5].Value = model.MEMO;
            return OleDbHelper.ExecuteSql(Add_SQL, parametersAdd);
        }

        public ReturnValue Search(string UserID)
        {
            OleDbParameter[] parametersSearchID = { new OleDbParameter("@UserID", OleDbType.VarWChar, 50) };
                parametersSearchID[0].Value = UserID;
            return OleDbHelper.Query(SearchID_SQL, parametersSearchID);
        }

        public ReturnValue Update(LoginUser model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),					
					new OleDbParameter("@UserPwd", OleDbType.VarWChar,50),
					new OleDbParameter("@UserType", OleDbType.VarWChar,1),
					new OleDbParameter("@MEMO", OleDbType.LongVarWChar),
                    new OleDbParameter("@UserID", OleDbType.VarWChar,50)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.UserPwd;
            parametersUpdate[3].Value = model.UserType;
            parametersUpdate[4].Value = model.MEMO;
            parametersUpdate[5].Value = model.UserID;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }

        public ReturnValue Delete(string UserID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@UserID", OleDbType.VarWChar, 50) };
                parameters[0].Value = UserID;
            return OleDbHelper.ExecuteSql(Delete_SQL, parameters);
        }

        public ReturnValue GetList()
        {
            return OleDbHelper.Query(GetList_SQL);
        }

        public ReturnValue GetUserPwd(string UserID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@UserID", OleDbType.VarWChar, 50) };
                parameters[0].Value = UserID;
            return OleDbHelper.Query(GetUserPwd_SQL, parameters);
        }

        public ReturnValue GetEmployeePWD(string EmployeeGZID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@EmployeeGZID", OleDbType.VarWChar, 8) };
            parameters[0].Value = EmployeeGZID;
            return OleDbHelper.Query(GetEmployeePWD_SQL, parameters);
        }

        public ReturnValue GetPWDByEmployeeID(string EmployeeID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@EmployeeID", OleDbType.VarWChar, 50) };
            parameters[0].Value = EmployeeID;
            return OleDbHelper.Query(GetPWDByEmployeeID_SQL, parameters);
        }

        public ReturnValue GetYearMonth()
        {
            return OleDbHelper.Query(GetYearMonth_SQL);
        }

        public ReturnValue SearchYearMonth(string YearMonth)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@SelectYearMonth", OleDbType.VarWChar, 6) };
                parameters[0].Value = YearMonth;
            return OleDbHelper.Query(SearchYearMonth_SQL, parameters);
        }

        public ReturnValue AddYearMonth(string LoginUserID, string TerminalCD, string YearMonth)
        {
            OleDbParameter[] parametersAdd = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@SelectYearMonth", OleDbType.VarWChar,6)};
            parametersAdd[0].Value = LoginUserID;
            parametersAdd[1].Value = TerminalCD;
            parametersAdd[2].Value = YearMonth;
            return OleDbHelper.ExecuteSql(AddYearMonth_SQL, parametersAdd);
        }

        /// <summary>
        /// 按年统计体检人数
        /// </summary>
        /// <returns></returns>
        public ReturnValue StatisticNums()
        {
            string[] sqlList = new string[10];
            sqlList[0] = @"Select YearMoth,count(*) as Nums from Biochemistry group by YearMoth";//生化检验
            sqlList[1] = @"Select YearMoth,count(*) as Nums from Features group by YearMoth";//体格检查五官
            sqlList[2] = @"Select YearMoth,count(*) as Nums from Surgery group by YearMoth";//体格检查外科
            sqlList[3] = @"Select YearMoth,count(*) as Nums from InternalMedicine group by YearMoth";//体格检查内科
            sqlList[4] = @"Select YearMoth,count(*) as Nums from ECG group by YearMoth";//心电图
            sqlList[5] = @"Select YearMoth,count(*) as Nums from Xray group by YearMoth";//X线
            sqlList[6] = @"Select YearMoth,count(*) as Nums from Bexamination group by YearMoth";//B超
            sqlList[7] = @"Select YearMoth,count(*) as Nums from Composition group by YearMoth";//体成分分析
            sqlList[8] = @"Select YearMoth,count(*) as Nums from Feme group by YearMoth";//妇科
            sqlList[9] = @"Select YearMoth,count(*) as Nums from Report group by YearMoth";//报告
            return OleDbHelper.Query(sqlList);
        }
    }
}

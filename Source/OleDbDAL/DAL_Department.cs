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
    public class DAL_Department:IDAL.IDAL_Department
    {
        #region SQL Statement

        private string _add_SQL = @"Insert Into Department(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,[ID],[Name],Notes)
Values (FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@ID,@Name,@Notes)";
        private string _search_SQL = @"Select [ID],[Name],Notes From Department Where [ID] = @ID";
        private string _update_SQL = @"Update Department Set 
UPDATE_DATETIME=FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
[Name]=@Name,
Notes=@Notes
Where [ID]=@ID";
        private string _getlist_SQL = @"Select [ID],[Name],Notes From Department Where 1=1 ";
        private string _delte_SQL = @"Delete From Department Where [ID]=@ID";

        private string _getUseingDepartmentCount_SQL = @"Select EmployeeID 
from Employee 
where EmployeeBM = @DepartmentID";

        #endregion

        #region IDAL_Department ≥…‘±

        public ReturnValue Add(Department model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@ID", OleDbType.Char,50),
                    new OleDbParameter("@Name", OleDbType.LongVarWChar),
                    new OleDbParameter("@Notes", OleDbType.LongVarWChar)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.ID;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Notes;
            return OleDbHelper.ExecuteSql(_add_SQL, parameters);
        }

        public ReturnValue Search(string DepartmentID)
        {
            OleDbParameter[] parameters = {new OleDbParameter("@ID", OleDbType.Char,50)};
            parameters[0].Value = DepartmentID;
            return OleDbHelper.Query(_search_SQL, parameters);
        }

        public ReturnValue Update(Department model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),					
                    new OleDbParameter("@Name", OleDbType.LongVarWChar),
                    new OleDbParameter("@Notes", OleDbType.LongVarWChar),
                    new OleDbParameter("@ID", OleDbType.Char,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;            
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Notes;
            parameters[4].Value = model.ID;
            return OleDbHelper.ExecuteSql(_update_SQL, parameters);
        }

        public ReturnValue GetList(string strWhere)
        {
            return OleDbHelper.Query(_getlist_SQL + strWhere +" Order By [ID]");
        }

        public ReturnValue Delete(string DepartmentID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@ID", OleDbType.Char, 50) };
            parameters[0].Value = DepartmentID;
            return OleDbHelper.ExecuteSql(_delte_SQL, parameters);
        }

        public ReturnValue GetUseingDepartmentCount(string DepartmentID)
        {
            OleDbParameter[] parameters = {new OleDbParameter("@ID", OleDbType.Char,50)};
            parameters[0].Value = DepartmentID;
            return OleDbHelper.Query(_getUseingDepartmentCount_SQL, parameters);
        }

        #endregion
    }
}

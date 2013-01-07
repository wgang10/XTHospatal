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
    public class DAL_Composition : IDAL_Composition
    {
        private string SearchID_SQL = @"Select EmployeeID From Composition
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth";
        private string Add_SQL = @"Insert Into Composition(
CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,EmployeeID,YearMoth,FatType,FatEvaluate,FatTarget,MuscleTarget,BodyWeightTarget,Physicians)
Values (
FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@EmployeeID,@YearMonth,@FatType,@FatEvaluate,@FatTarget,@MuscleTarget,@BodyWeightTarget,@Physicians)";
        private string Update_SQL = @"Update Composition Set 
TRANS_STATE='2',
UPDATER_ID=@UPDATER_ID,
TERMINAL_CD=@TERMINAL_CD,
FatType=@FatType,
FatEvaluate=@FatEvaluate,
FatTarget=@FatTarget,
MuscleTarget=@MuscleTarget,
BodyWeightTarget=@BodyWeightTarget,
Physicians=@Physicians
Where EmployeeID=@EmployeeID And YearMoth=@YearMonth  ";

        public ReturnValue Add(Composition model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6),
					new OleDbParameter("@FatType", OleDbType.VarWChar,1),
					new OleDbParameter("@FatEvaluate", OleDbType.VarWChar,1),
					new OleDbParameter("@FatTarget", OleDbType.VarWChar),
					new OleDbParameter("@MuscleTarget", OleDbType.VarWChar),
					new OleDbParameter("@BodyWeightTarget", OleDbType.VarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.EmployeeID;
            parameters[3].Value = model.YearMonth;
            parameters[4].Value = model.FatType;
            parameters[5].Value = model.FatEvaluate;
            parameters[6].Value = model.FatTarget;
            parameters[7].Value = model.MuscleTarget;
            parameters[8].Value = model.BodyWeightTarget;
            parameters[9].Value = model.Physicians;
            return OleDbHelper.ExecuteSql(Add_SQL, parameters);
        }

        public ReturnValue Search(string EmployeeID, string yearMonth)
        {
            OleDbParameter[] parametersSearchID = { 
                new OleDbParameter("@EmployeeID", OleDbType.VarWChar, 18),
                new OleDbParameter("@YearMonth", OleDbType.VarWChar, 6)};
            parametersSearchID[0].Value = EmployeeID;
            parametersSearchID[1].Value = yearMonth;
            return OleDbHelper.Query(SearchID_SQL, parametersSearchID);
        }

        public ReturnValue Update(Composition model)
        {
            OleDbParameter[] parametersUpdate = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@FatType", OleDbType.VarWChar,1),
					new OleDbParameter("@FatEvaluate", OleDbType.VarWChar,1),
					new OleDbParameter("@FatTarget", OleDbType.VarWChar),
					new OleDbParameter("@MuscleTarget", OleDbType.VarWChar),
					new OleDbParameter("@BodyWeightTarget", OleDbType.VarWChar),
					new OleDbParameter("@Physicians", OleDbType.VarWChar,50),
                    new OleDbParameter("@EmployeeID", OleDbType.VarWChar,18),
					new OleDbParameter("@YearMonth", OleDbType.VarWChar,6)};
            parametersUpdate[0].Value = model.UPDATER_ID;
            parametersUpdate[1].Value = model.TERMINAL_CD;
            parametersUpdate[2].Value = model.FatType;
            parametersUpdate[3].Value = model.FatEvaluate;
            parametersUpdate[4].Value = model.FatTarget;
            parametersUpdate[5].Value = model.MuscleTarget;
            parametersUpdate[6].Value = model.BodyWeightTarget;
            parametersUpdate[7].Value = model.Physicians;
            parametersUpdate[8].Value = model.EmployeeID;
            parametersUpdate[9].Value = model.YearMonth;
            return OleDbHelper.ExecuteSql(Update_SQL, parametersUpdate);
        }
    }
}

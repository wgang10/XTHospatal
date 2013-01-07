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
    public class DAL_Log : IDAL.IDAL_Log
    {
        #region SQL Statement

        private string _add_SQL = @"Insert Into Log(CREATE_DATETIME,UPDATE_DATETIME,TRANS_STATE,UPDATER_ID,TERMINAL_CD,Content,Type)
Values (FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),FORMAT(date(),'YYYYMMDD')+FORMAT(TIME(),'HHMMSS'),'1',@UPDATER_ID,@TERMINAL_CD,@Content,@Type)";

        private string _getList_SQL = @"Select CREATE_DATETIME,TERMINAL_CD,Content,Type From Log Where 1=1 ";

        #endregion

        #region IDAL_Log ³ÉÔ±

        ReturnValue IDAL_Log.Add(Log model)
        {
            OleDbParameter[] parameters = {
					new OleDbParameter("@UPDATER_ID", OleDbType.VarWChar,12),
					new OleDbParameter("@TERMINAL_CD", OleDbType.LongVarWChar),
					new OleDbParameter("@Content", OleDbType.LongVarWChar),
                    new OleDbParameter("@Type", OleDbType.VarWChar,1)};
            parameters[0].Value = model.UPDATER_ID;
            parameters[1].Value = model.TERMINAL_CD;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Type;
            return OleDbHelper.ExecuteSql(_add_SQL, parameters);
        }

        ReturnValue IDAL_Log.GetList(string DateFrom, string DateTo, string Type)
        {
            string strWhere = string.Empty;
            OleDbCommand cmd = new OleDbCommand();
            if (DateFrom.Trim().Length > 0)
            {
                OleDbParameter parameter1 = new OleDbParameter("@DateFrom", OleDbType.Char, 14);
                parameter1.Value = DateFrom;
                strWhere += " and CREATE_DATETIME >= @DateFrom ";
                cmd.Parameters.Add(parameter1);
            }
            if (DateTo.Trim().Length > 0)
            {
                OleDbParameter parameter2 = new OleDbParameter("@DateTo", OleDbType.Char, 14);
                parameter2.Value = DateTo;
                strWhere += " and CREATE_DATETIME <= @DateTo ";
                cmd.Parameters.Add(parameter2);
            }
            if (Type.Trim().Length > 0)
            {
                OleDbParameter parameter3 = new OleDbParameter("@Type", OleDbType.Char, 1);
                parameter3.Value = Type;
                strWhere += " and [Type] = @Type ";
                cmd.Parameters.Add(parameter3);
            }
            strWhere += " Order By CREATE_DATETIME Desc";
            return OleDbHelper.Query(_getList_SQL+strWhere,cmd);
        }

        #endregion
    }
}

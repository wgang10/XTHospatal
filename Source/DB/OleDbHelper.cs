using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using XTHospital.COM;
using System.Collections;

namespace XTHospital.DB
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class OleDbHelper
    {
        //private static string strConnection = System.Configuration.ConfigurationManager.AppSettings["SQLConnString"];
        //private static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString.ToString();
        //private static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["OLEDBConnString"].ConnectionString.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static ReturnValue Query(string strSql)
        {
            string strCon = GetConnectionStr();
            DataSet dsQuery = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(strCon))
            {
                try
                {
                    connection.Open();
                }
                catch (OleDbException ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Connection Error.");//SQL Server Connection Error.
                }
                try
                {
                    OleDbDataAdapter command = new OleDbDataAdapter(strSql, connection);
                    command.Fill(dsQuery, "Result");
                    return new ReturnValue(true, "", dsQuery, dsQuery.Tables[0].Rows.Count);
                }
                catch (OleDbException ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                }
                catch (Exception ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static ReturnValue Query(string[] strSqlList)
        {
            string strCon = GetConnectionStr();
            DataSet dsQuery = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(strCon))
            {
                try
                {
                    connection.Open();
                }
                catch (OleDbException ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Connection Error.");//SQL Server Connection Error.
                }
                try
                {
                    for (int i = 0; i < strSqlList.Length; i++)
                    {
                        OleDbDataAdapter command = new OleDbDataAdapter(strSqlList[i], connection);
                        command.Fill(dsQuery, i.ToString());
                    }
                    return new ReturnValue(true, "", dsQuery, dsQuery.Tables[0].Rows.Count);
                }
                catch (OleDbException ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                }
                catch (Exception ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                }
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static ReturnValue Query(string strSql, params OleDbParameter[] cmdParms)
        {
            string strCon = GetConnectionStr();
            DataSet dsQuery = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(strCon))
            {
                try
                {
                    connection.Open();
                }
                catch (OleDbException ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Connection Error.");//SQL Server Connection Error.
                }
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, strSql, cmdParms);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    try
                    {
                        da.Fill(dsQuery, "QDS");
                        cmd.Parameters.Clear();
                        return new ReturnValue(true, "", dsQuery, dsQuery.Tables[0].Rows.Count);
                    }
                    catch (OleDbException ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                    catch (Exception ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                }
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static ReturnValue Query(string strSql, OleDbCommand cmd)
        {
            string strCon = GetConnectionStr();
            DataSet dsQuery = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(strCon))
            {
                try
                {
                    connection.Open();
                }
                catch (OleDbException ex)
                {
                    UtilityLog.WriteError(ex.Message);
                    return new ReturnValue(false, "SQL Server Connection Error.");//SQL Server Connection Error.
                }
                PrepareCommand(cmd, connection, null, strSql, null);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    try
                    {
                        da.Fill(dsQuery, "QDS");
                        cmd.Parameters.Clear();
                        return new ReturnValue(true, "", dsQuery, dsQuery.Tables[0].Rows.Count);
                    }
                    catch (OleDbException ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                    catch (Exception ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static ReturnValue ExecuteSql(string strSql)
        {
            string strCon = GetConnectionStr();
            using (OleDbConnection connection = new OleDbConnection(strCon))
            {
                using (OleDbCommand cmd = new OleDbCommand(strSql, connection))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (OleDbException ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Connection Error.");//SQL Server Connection Error.
                    }
                    try
                    {
                        int intRows = cmd.ExecuteNonQuery();
                        //if (intRows > 0)
                        //{
                        //    return "0";
                        //}
                        //return new ReturnValue(false, "W11003");//Successful Implementation Of SQL Statements  But No Data Change.
                        return new ReturnValue(true);
                    }
                    catch (OleDbException ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                    catch (Exception ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static ReturnValue ExecuteSql(string strSql, params OleDbParameter[] cmdParms)
        {
            string strCon = GetConnectionStr();
            using (OleDbConnection connection = new OleDbConnection(strCon))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (OleDbException ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Connection Error.");//SQL Server Connection Error.
                    }
                    try
                    {
                        PrepareCommand(cmd, connection, null, strSql, cmdParms);
                        int intRows = cmd.ExecuteNonQuery();
                        //if (intRows > 0)
                        //{
                        //    return new ReturnValue(true);
                        //}
                        //return new ReturnValue(false, "W11003");//Successful Implementation Of SQL Statements  But No Data Change.
                        return new ReturnValue(true);
                    }
                    catch (OleDbException ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                    catch (Exception ex)
                    {
                        UtilityLog.WriteError(ex.Message);
                        return new ReturnValue(false, "SQL Server Running Fail.");//SQL Server Running Fail.
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn == null)
            {
                string strCon = GetConnectionStr();
                conn = new OleDbConnection(strCon);
            }
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                cmd.Parameters.Clear();
                foreach (OleDbParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        private static string GetConnectionStr()
        {
            return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/App_Data") + @"\XTHospital.mdb;Jet OLEDB:Database Password=wan;";
        }
    }
}

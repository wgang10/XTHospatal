using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XTHospital.COM;
using System.Collections;

namespace XTHospital.DB
{
    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
    public abstract class SqlHelper
    {
        private static string strConnection = System.Configuration.ConfigurationManager.AppSettings["SQLConnString"];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static ReturnValue Query(string strSql)
        {
            DataSet dsQuery = new DataSet();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return new ReturnValue(false, "E11001");//SQL Server Connection Error
                }
                try
                {
                    SqlDataAdapter command = new SqlDataAdapter(strSql, connection);
                    command.Fill(dsQuery, "Result");
                    return new ReturnValue(true, "", dsQuery, dsQuery.Tables[0].Rows.Count);
                }
                catch (SqlException ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return new ReturnValue(false, "E11002");//SQL Server Running Fail.
                }
                catch (Exception ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return new ReturnValue(false, "E11002");//SQL Server Running Fail.
                }
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static ReturnValue Query(string strSql, params SqlParameter[] cmdParms)
        {
            DataSet dsQuery = new DataSet();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return new ReturnValue(false, "E11001");//SQL Server Connection Error
                }
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, strSql, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        da.Fill(dsQuery, "QDS");
                        cmd.Parameters.Clear();
                        return new ReturnValue(true, "", dsQuery,dsQuery.Tables[0].Rows.Count);
                    }
                    catch (SqlException ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return new ReturnValue(false, "E11002");//SQL Server Running Fail.
                    }
                    catch (Exception ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return new ReturnValue(false, "E11002");//SQL Server Running Fail.
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static string ExecuteSql(string strSql)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, connection))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return "E11001";//SQL Server Connection Error
                    }
                    try
                    {
                        int intRows = cmd.ExecuteNonQuery();
                        if (intRows > 0)
                        {
                            return "0";
                        }
                        return "W11003";
                    }
                    catch (SqlException ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return "E11002";
                    }
                    catch (Exception ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return "E11002";
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
        public static ReturnValue ExecuteSql(string strSql, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return new ReturnValue(false, "E11001");//SQL Server Connection Error
                    }
                    try
                    {
                        PrepareCommand(cmd, connection, null, strSql, cmdParms);
                        int intRows = cmd.ExecuteNonQuery();
                        if (intRows > 0)
                        {
                            return new ReturnValue(true);
                        }
                        return new ReturnValue(false, "W11003");//Successful Implementation Of SQL Statements  But No Data Change.
                    }
                    catch (SqlException ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return new ReturnValue(false, "E11002");//SQL Server Running Fail.
                    }
                    catch (Exception ex)
                    {
                        UtilityLog.WriteErrLogWithLog4Net(ex);
                        return new ReturnValue(false, "E11002");//SQL Server Running Fail.
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="connection"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static string ExecuteSql(string strSql, SqlConnection connection, params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, connection))
            {
                try
                {
                    PrepareCommand(cmd, connection, null, strSql, cmdParms);
                    int intRows = cmd.ExecuteNonQuery();
                    if (intRows > 0)
                    {
                        return "0";
                    }
                    return "W11003";
                }
                catch (SqlException ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11002";
                }
                catch (Exception ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11002";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSqlList"></param>
        /// <returns></returns>
        public static string ExecuteSqlTran(ArrayList strSqlList)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11001";//SQL Server Connection Error
                }
                int intRecordCount = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    cmd.Transaction = tran;
                    for (int intIndex = 0; intIndex < strSqlList.Count; intIndex++)
                    {
                        string strsql = strSqlList[intIndex].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            intRecordCount += cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    if (intRecordCount > 0)
                    {
                        return "0";
                    }
                    return "W11003";
                }
                catch (SqlException ex)
                {
                    tran.Rollback();
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11002";//SQL Server Running Fail.
                }
                catch (Exception ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11002";//SQL Server Running Fail.
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSqlList"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static string ExecuteSqlTran(ArrayList strSqlList, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11001";//SQL Server Connection Error
                }
                int intRecordCount = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    cmd.Transaction = tran;
                    for (int intIndex = 0; intIndex < strSqlList.Count; intIndex++)
                    {
                        string strsql = strSqlList[intIndex].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            intRecordCount += cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    if (intRecordCount > 0)
                    {
                        return "0";
                    }
                    return "W11003";
                }
                catch (SqlException ex)
                {
                    tran.Rollback();
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11002";//SQL Server Running Fail.
                }
                catch (Exception ex)
                {
                    UtilityLog.WriteErrLogWithLog4Net(ex);
                    return "E11002";//SQL Server Running Fail.
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static object GetSingle(string strSql, SqlConnection connection)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, connection))
            {
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="connection"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static object GetSingle(string strSql, SqlConnection connection, params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand(strSql, connection))
            {
                PrepareCommand(cmd, connection, null, strSql, cmdParms);
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
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
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnection);
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
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(strConnection);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                UtilityLog.WriteErrLogWithLog4Net(ex);
                return null;
            }
            catch (Exception ex)
            {
                UtilityLog.WriteErrLogWithLog4Net(ex);
                return null;
            }
            return connection;
        }
    }
}

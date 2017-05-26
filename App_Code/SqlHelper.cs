using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for SqlHelper
/// </summary>
public class SqlHelper
{
    #region M E M B E R S

    public static readonly string mainConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
    //public static readonly string mainConnectionStringlms = ConfigurationManager.ConnectionStrings["ConStr"].ToString();

    #endregion

    #region N O N Q U E R Y (2 overloaded)

    public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        SqlCommand cmd = new SqlCommand();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
    }

    public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    #endregion

    #region E X E C U T E  R E A D E R
    /// <summary>
    /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
    /// using the provided parameters.
    /// </summary>
    /// <remarks>
    /// Caution ! always close the SqlDataReader "dr.Close()" after using it.
    /// </remarks>
    /// <param name="connString">a valid connection string for a SqlConnection</param>
    /// <param name="cmdType">type of the command</param>
    /// <param name="cmdText">a query string that could be a T-SQL command or Stored Procedure</param>
    /// <param name="cmdParameters">a array of the parameters which are supposed to be passed in SqlCommand</param>
    /// <returns>a SqlDataReader object containing the resultset</returns>
    public static SqlDataReader ExecuteReader(string connStr, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connStr);
        try
        {
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return sdr;
        }
        catch
        {
            conn.Close();
            throw;
        }
    }

    #endregion

    #region E X E C U T E  S C A L E R
    /// <summary>
    /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
    /// using the provided parameters.
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="MSDBConn">a valid connection string for a SqlConnection</param>
    /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    /// <param name="commandText">the stored procedure name or T-SQL command</param>
    /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>

    public static object ExecuteScaler(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        SqlCommand cmd = new SqlCommand();
        using (SqlConnection conn = new SqlConnection(connString))
        {
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
            Object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            //  conn.Close();
            return val;
        }
    }
    /// <summary>
    /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
    /// using the provided parameters.
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="conn">an existing database connection</param>
    /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    /// <param name="commandText">the stored procedure name or T-SQL command</param>
    /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>

    public static object ExecuteScaler(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
        Object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        conn.Close();
        return val;
    }
    #endregion

    #region G E T  D A T A S E T
    /// <summary>
    /// Execute a SqlCommand that returns a DataSet against the database specified in the connection string 
    /// using the provided parameters.
    /// </summary>
    /// <param name="connString">a valid connection string for a SqlConnection</param>
    /// <param name="cmdType">type of the command</param>
    /// <param name="cmdText">a query string that could be a T-SQL command or Stored Procedure</param>
    /// <param name="cmdParameters">a array of the parameters which are supposed to be passed in SqlCommand</param>
    /// <returns>a SqlDataReader object containing the resultset</returns>
    public static DataSet GetDataSet(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        try
        {
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
            da.SelectCommand = new SqlCommand();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion

    #region G E T  D A T A T A B L E
    /// <summary>
    /// Execute a SqlCommand that returns a DataSet against the database specified in the connection string 
    /// using the provided parameters.
    /// </summary>
    /// <param name="connString">a valid connection string for a SqlConnection</param>
    /// <param name="cmdType">type of the command</param>
    /// <param name="cmdText">a query string that could be a T-SQL command or Stored Procedure</param>
    /// <param name="cmdParameters">a array of the parameters which are supposed to be passed in SqlCommand</param>
    /// <returns>a SqlDataReader object containing the resultset</returns>
    public static DataTable GetDataTable(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        try
        {
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
            da.SelectCommand = new SqlCommand();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion

    public static bool checkExistance(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        bool isExists = false;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connString);
        try
        {
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            if (sdr.HasRows)
            {
                isExists = true;
            }
            sdr.Close();
        }
        catch
        {
            // conn.Close();
            throw;
        }
        return isExists;
    }

    #region P R E P A R E  C O M M A N D

    /// <summary>
    /// Prepare a command for execution
    /// </summary>
    /// <param name="cmd">SqlCommand object</param>
    /// <param name="conn">SqlConnection object</param>
    /// <param name="cmdType">ComandType object(stored procedure or text)</param>
    /// <param name="cmdText">SqlParameters to use in the command</param>
    /// <param name="cmdParameters"></param>
    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandType = cmdType;
        cmd.CommandText = cmdText;
        if (cmdParameters != null)
        {
            foreach (SqlParameter param in cmdParameters)
            {
                cmd.Parameters.Add(param);
            }
        }
    }

    #endregion

    public static DataTable GetDataTable(string QueryString)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MSDBConn"].ToString());
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        try
        {
            da = new SqlDataAdapter(QueryString, conn);
            da.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
        }
    }

    public static int ExcecuteQuery(string strSQL)
    {

        int retval = 0;
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MSDBConn"].ToString());
        if (sqlConn.State != ConnectionState.Open)
        {
            sqlConn.Open();
        }
        SqlCommand sqlcommd = new SqlCommand();
        sqlcommd.Connection = sqlConn;
        sqlcommd.CommandText = strSQL;

        try
        {
            retval = sqlcommd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        finally
        {
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();

        }

        return retval;
    }
    public SqlConnection GetConnection()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MSDBConn"].ToString());
        return con;
        throw new NotImplementedException();
    }
}
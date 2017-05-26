using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.XPath;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for AndroidDBTask
/// </summary>
public class AndroidDBTask
{
    public AndroidDBTask()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetConnectionString()
    {
        //return Convert.ToString(ConfigurationManager.AppSettings["ConStr"]);
        return Convert.ToString(ConfigurationManager.ConnectionStrings["ApplicationServices"]);
    }

    public DataSet IU_HHData_old(DataTable tblHHFamilyMember, DataTable tblHHSurvey, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportHHData";
            sqlcmd.Parameters.AddWithValue("@HHSurvey", tblHHSurvey);
            sqlcmd.Parameters.AddWithValue("@HHFamilyMember", tblHHFamilyMember);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            // sqlcmd.ExecuteNonQuery();
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            throw e;
        }
        finally
        {
        if (!(sqlConnection.State == ConnectionState.Closed))
        {
        sqlConnection.Close();
        sqlConnection.Dispose();
        }
        }
    }


    public DataSet errorlog(string sJason, int UserID, string status)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
            sqlConnection.Open();
            }

            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = " INSERT INTO [dbo].[Tablet_DataImport] ([UserID],[JSON],[Impotedon],ImportedOn_IndianTime,Status) VALUES (" + UserID + ",'" + sJason + "',GETDATE(),SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30'),'" + status + "')";
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
        if (!(sqlConnection.State == ConnectionState.Closed))
        {
        sqlConnection.Close();
        sqlConnection.Dispose();
        }
        throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }

    public DataSet IU_HHData(DataTable tblHHFamilyMember, DataTable tblHHSurvey, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportHHDataNew_online";
            sqlcmd.Parameters.AddWithValue("@HHSurvey", tblHHSurvey);
            sqlcmd.Parameters.AddWithValue("@HHFamilyMember", tblHHFamilyMember);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
            sqlConnection.Close();
            sqlConnection.Dispose();
            }
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
            sqlConnection.Close();
            sqlConnection.Dispose();
            }
        }
    }


    public DataSet IU_HHData_V501(DataTable tblHHFamilyMember, DataTable tblHHSurvey, DataTable tblMig, DataTable tblhhupdate, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
        if (sqlConnection.State != ConnectionState.Open)
        {
        sqlConnection.Open();
        }

        DataSet dbSqlDataSet = new DataSet();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlConnection;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Tablet_ImportHHDataversion_501";
        sqlcmd.Parameters.AddWithValue("@HHSurvey", tblHHSurvey);
        sqlcmd.Parameters.AddWithValue("@HHFamilyMember", tblHHFamilyMember);
        sqlcmd.Parameters.AddWithValue("@Migration", tblMig);
        sqlcmd.Parameters.AddWithValue("@tblhhupdate_Log", tblhhupdate);
        sqlcmd.Parameters.AddWithValue("@UserID", UserID);
        sqlcmd.Parameters.AddWithValue("@JSON", sJason);
        SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
        da.Fill(dbSqlDataSet);
        return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
            sqlConnection.Close();
            sqlConnection.Dispose();
            }
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }

    public DataSet IU_HHData_JH(DataTable tblHHFamilyMember, DataTable tblHHSurvey, DataTable tblMig, DataTable tblhhupdate, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportHHDataversion_JH";
            sqlcmd.Parameters.AddWithValue("@HHSurvey", tblHHSurvey);
            sqlcmd.Parameters.AddWithValue("@HHFamilyMember", tblHHFamilyMember);
            sqlcmd.Parameters.AddWithValue("@Migration", tblMig);
            sqlcmd.Parameters.AddWithValue("@tblhhupdate_Log", tblhhupdate);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }



    public DataSet IU_Ansdata(DataTable tblmstFPAns, DataTable tblmstFPDetail, DataTable tblmstimmunizationANS, DataTable tblPNChomevisit_ANS, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataans";
            sqlcmd.Parameters.AddWithValue("@tblmstFPAns", tblmstFPAns);
            sqlcmd.Parameters.AddWithValue("@tblmstFPDetail", tblmstFPDetail);
            sqlcmd.Parameters.AddWithValue("@tblmstimmunizationANS", tblmstimmunizationANS);
            sqlcmd.Parameters.AddWithValue("@tblPNChomevisit_ANS", tblPNChomevisit_ANS);
            //  sqlcmd.Parameters.AddWithValue("@tblANC", tblANCVisit);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }

    public DataSet IU_Ansdata_V501(DataTable tblmstFPAns, DataTable tblmstFPDetail, DataTable tblmstimmunizationANS, DataTable tblPNChomevisit_ANS, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataans_V501";
            sqlcmd.Parameters.AddWithValue("@tblmstFPAns", tblmstFPAns);
            sqlcmd.Parameters.AddWithValue("@tblmstFPDetail", tblmstFPDetail);
            sqlcmd.Parameters.AddWithValue("@tblmstimmunizationANS", tblmstimmunizationANS);
            sqlcmd.Parameters.AddWithValue("@tblPNChomevisit_ANS", tblPNChomevisit_ANS);
            //  sqlcmd.Parameters.AddWithValue("@tblANC", tblANCVisit);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }


    public DataSet IU_Ansdata_V601(DataTable tblmstFPAns, DataTable tblmstFPDetail, DataTable tblmstimmunizationANS, DataTable tblPNChomevisit_ANS, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataans_V601";
            sqlcmd.Parameters.AddWithValue("@tblmstFPAns", tblmstFPAns);
            sqlcmd.Parameters.AddWithValue("@tblmstFPDetail", tblmstFPDetail);
            sqlcmd.Parameters.AddWithValue("@tblmstimmunizationANS", tblmstimmunizationANS);
            sqlcmd.Parameters.AddWithValue("@tblPNChomevisit_ANS", tblPNChomevisit_ANS);
            //  sqlcmd.Parameters.AddWithValue("@tblANC", tblANCVisit);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }

    public DataSet IU_Ansdata_V701(DataTable tblmstFPAns, DataTable tblmstFPDetail, DataTable tblmstimmunizationANS, DataTable tblPNChomevisit_ANS, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataans_V701";
            sqlcmd.Parameters.AddWithValue("@tblmstFPAns", tblmstFPAns);
            sqlcmd.Parameters.AddWithValue("@tblmstFPDetail", tblmstFPDetail);
            sqlcmd.Parameters.AddWithValue("@tblmstimmunizationANS", tblmstimmunizationANS);
            sqlcmd.Parameters.AddWithValue("@tblPNChomevisit_ANS", tblPNChomevisit_ANS);
            //  sqlcmd.Parameters.AddWithValue("@tblANC", tblANCVisit);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }



    public DataSet IU_VHNDdata(DataTable tbl_VHNDPerformance, DataTable tbl_VHND_DueList,DataTable tblVHNDDueList, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataVHND";
            sqlcmd.Parameters.AddWithValue("@tbl_VHNDPerformance", tbl_VHNDPerformance);
            sqlcmd.Parameters.AddWithValue("@tbl_VHND_DueList", tbl_VHND_DueList);
            sqlcmd.Parameters.AddWithValue("@tblVHNDDueList", tblVHNDDueList);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }


    public DataSet IU_MNCHData(DataTable tblpregnant_woman, DataTable tblchild, DataTable tblANCVisit, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataMNCH";
            sqlcmd.Parameters.AddWithValue("@tblchild", tblchild);
            sqlcmd.Parameters.AddWithValue("@tblpregnant_woman", tblpregnant_woman);
            sqlcmd.Parameters.AddWithValue("@tblANC", tblANCVisit);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }

    public DataSet IU_MNCHData_V501(DataTable tblpregnant_woman, DataTable tblchild, DataTable tblANCVisit, DataTable tblDatesEd, DataTable tblhhupdate, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataMNCH_V501";
            sqlcmd.Parameters.AddWithValue("@tblchild", tblchild);
            sqlcmd.Parameters.AddWithValue("@tblpregnant_woman", tblpregnant_woman);
            sqlcmd.Parameters.AddWithValue("@tblANC", tblANCVisit);
            sqlcmd.Parameters.AddWithValue("@tblDatesEd", tblDatesEd);
            sqlcmd.Parameters.AddWithValue("@tblhhupdate_Log", tblhhupdate);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }


    public DataSet IU_MNCHData_V601(DataTable tblpregnant_woman, DataTable tblchild, DataTable tblANCVisit, DataTable tblDatesEd, DataTable tblhhupdate, string sJason, int UserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_ImportDataMNCH_V601";
            sqlcmd.Parameters.AddWithValue("@tblchild", tblchild);
            sqlcmd.Parameters.AddWithValue("@tblpregnant_woman", tblpregnant_woman);
            sqlcmd.Parameters.AddWithValue("@tblANC", tblANCVisit);
            sqlcmd.Parameters.AddWithValue("@tblDatesEd", tblDatesEd);
            sqlcmd.Parameters.AddWithValue("@tblhhupdate_Log", tblhhupdate);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@JSON", sJason);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }



    private DataTable GetTableTypeColumns(string sTableTypeName)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataTable dbSqlDataSet = new DataTable();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_GetTableTypeColumns";
            sqlcmd.Parameters.AddWithValue("@TableType", sTableTypeName);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd);

            sqlDataAdapter.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            //IUErrorDetail(e.ToString());
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

        }
    }

    public DataTable CreateDataTable(string sTableTypeName)
    {
        DataTable dt = new DataTable();
        DataTable dtDB = GetTableTypeColumns(sTableTypeName);

        foreach (DataRow dr in dtDB.Rows)
        {
            // dt.Columns.Add("ss",typeof(System));
            dt.Columns.Add(new DataColumn(dr["ColumnName"].ToString(), Type.GetType(dr["TypeName"].ToString())));
        }

        return dt;
    }

    public DataSet GetMasterData(string sFlag, int UserID,int ashaid)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "[Tablet_GetMasterData]";
            sqlcmd.Parameters.AddWithValue("@Flag", sFlag);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@ashaid", ashaid);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd);

            sqlDataAdapter.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            //IUErrorDetail(e.ToString());
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }

    public DataSet GetMasterFullData(string sFlag, int UserID, int ashaid)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataSet dbSqlDataSet = new DataSet();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandTimeout = 0;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "[Tablet_GetMasterFullData]";
            sqlcmd.Parameters.AddWithValue("@Flag", sFlag);
            sqlcmd.Parameters.AddWithValue("@UserID", UserID);
            sqlcmd.Parameters.AddWithValue("@ashaid", ashaid);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd);

            sqlDataAdapter.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
            sqlConnection.Close();
            sqlConnection.Dispose();
            }
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
            sqlConnection.Close();
            sqlConnection.Dispose();
            }
        }
    }

    public DataSet GetUserData(string sFlag, int sUserID)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
        if (sqlConnection.State != ConnectionState.Open)
        {
        sqlConnection.Open();
        }

        DataSet dbSqlDataSet = new DataSet();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlConnection;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "[Tablet_GetUserData]";
        sqlcmd.Parameters.AddWithValue("@Flag", sFlag);
        sqlcmd.Parameters.AddWithValue("@UserID", sUserID);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd);
        sqlDataAdapter.Fill(dbSqlDataSet);
        return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            IUErrorDetail(e.ToString());
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }

    public DataTable GetUserAuthenticate(string pUsername, string pPassword)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataTable dbSqlDataSet = new DataTable();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Tablet_AuthenticateUser";
            sqlcmd.Parameters.AddWithValue("@UserName", pUsername);
            sqlcmd.Parameters.AddWithValue("@Password", pPassword);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcmd);

            sqlDataAdapter.Fill(dbSqlDataSet);
            return dbSqlDataSet;
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            IUErrorDetail(e.ToString());
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

        }
    }

    public void IUErrorDetail(string sError)
    {
        SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
        try
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            DataTable dbSqlDataSet = new DataTable();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConnection;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "[Tablet_IUErrorDetail]";
            sqlcmd.Parameters.AddWithValue("@Error", sError);
            sqlcmd.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            throw e;
        }
        finally
        {
            if (!(sqlConnection.State == ConnectionState.Closed))
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

        }
    }
}


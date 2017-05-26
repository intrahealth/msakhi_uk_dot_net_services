using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlTypes;
using System.Web.Configuration;


//using BusinessLogicLayer;


/// Summary description for DALOrderLibrary

namespace DataAccessLayer
{
    public class DALOrderLibrary
    {
        #region  gaurav
        SqlCommand dbSqlCommand;
        SqlDataAdapter dbSqlAdapter;
        DataTable dbSqlDataTable;
        DataSet dbSqlDataSet;
         public static string RDBConn = WebConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
         SqlConnection dbSqlconnection = new SqlConnection(RDBConn);
        #endregion
        #region("Common Function used in the site")

        public DataTable GetResultFromSqlQur(String strQur)
        {
            try
            {
            if (this.dbSqlconnection.State == ConnectionState.Closed)
            {
            this.dbSqlconnection.Open();
            }
            SqlCommand smd = new SqlCommand();
            SqlDataAdapter dbSqlAdapter = new SqlDataAdapter();
            dbSqlDataTable = new DataTable();
            smd.Parameters.Clear();
            smd.CommandType = CommandType.Text;
            smd.CommandText = strQur;
            smd.Connection = dbSqlconnection;
            dbSqlAdapter.SelectCommand = smd;
            smd.CommandTimeout = 10000000;
            //smd.CommandTimeout = 999999999;
            dbSqlAdapter.Fill(dbSqlDataTable);
            return dbSqlDataTable;
            }
            catch (SqlException sqlEx)
            {
            if (!(this.dbSqlconnection.State == ConnectionState.Closed))
            {
            this.dbSqlconnection.Close();
            }
            throw sqlEx;
            }
            catch (Exception ex1)
            {
            if (!(this.dbSqlconnection.State == ConnectionState.Closed))
            {
                this.dbSqlconnection.Close();
            }
            throw ex1;
            }
            finally
            {
            if (!(this.dbSqlconnection.State == ConnectionState.Closed))
            {
            this.dbSqlconnection.Close();
            }
            }
        }

        public int INS_UPD_PIAEmpEditDetails(int PIALoginID, int iEmployerId, string sEmployerName, string sScale, string sWebsite, string sPAN, string sTAN, int iManpower)
        {
            dbSqlCommand = new SqlCommand();
            dbSqlCommand.Connection = dbSqlconnection;
            if (dbSqlconnection.State == ConnectionState.Closed)
            dbSqlconnection.Open();
            dbSqlCommand.CommandType = CommandType.StoredProcedure;
            dbSqlCommand.CommandText = "SP_PIAEDIT";
            dbSqlCommand.Parameters.Add("@PIAID", SqlDbType.Int).Value = PIALoginID;
            dbSqlCommand.Parameters.Add("@EmployerId", SqlDbType.Int).Value = iEmployerId;
            dbSqlCommand.Parameters.Add("@EmployerName", SqlDbType.VarChar).Value = sEmployerName;
            dbSqlCommand.Parameters.Add("@Scale", SqlDbType.VarChar).Value = sScale;
            dbSqlCommand.Parameters.Add("@Website", SqlDbType.VarChar).Value = sWebsite;
            dbSqlCommand.Parameters.Add("@PAN", SqlDbType.VarChar).Value = sPAN;
            dbSqlCommand.Parameters.Add("@TAN", SqlDbType.VarChar).Value = sTAN;
            dbSqlCommand.Parameters.Add("@Manpower", SqlDbType.Int).Value = iManpower;
            System.Data.SqlClient.SqlParameter pRowsAffected = new SqlParameter("@output", System.Data.SqlDbType.Int);
            pRowsAffected.Direction = System.Data.ParameterDirection.Output;
            dbSqlCommand.Parameters.Add(pRowsAffected);

            try
            {
                dbSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return Convert.ToInt32(pRowsAffected.Value);
        }

        #endregion

        public int insertvhndprev(DataTable dt)
        {
            dbSqlCommand = new SqlCommand();
            dbSqlCommand.Connection = dbSqlconnection;
            if (dbSqlconnection.State == ConnectionState.Closed)
                dbSqlconnection.Open();
            dbSqlCommand.CommandType = CommandType.StoredProcedure;
            dbSqlCommand.CommandText = "PROC_INSERT_VHNDPrevyear";
            dbSqlCommand.Parameters.AddWithValue("@dt", dt);
            System.Data.SqlClient.SqlParameter pRowsAffected = new SqlParameter("@output", System.Data.SqlDbType.Int);
            pRowsAffected.Direction = System.Data.ParameterDirection.Output;
            dbSqlCommand.Parameters.Add(pRowsAffected);

            try
            {
                dbSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return Convert.ToInt32(pRowsAffected.Value);
        }


        public int insertvhndschedule(SqlDateTime jan, SqlDateTime feb, SqlDateTime mar, SqlDateTime apr, SqlDateTime may, SqlDateTime jun, SqlDateTime jul, SqlDateTime aug, SqlDateTime sep, SqlDateTime oct, SqlDateTime nov, SqlDateTime dec, int id, string village, string days, string occurence)
        {
            dbSqlCommand = new SqlCommand();
            dbSqlCommand.Connection = dbSqlconnection;
            if (dbSqlconnection.State == ConnectionState.Closed)
                dbSqlconnection.Open();
            dbSqlCommand.CommandType = CommandType.StoredProcedure;
            dbSqlCommand.CommandText = "[PROC_INSERT_vhndschedule]";
            dbSqlCommand.Parameters.AddWithValue("@jan", jan);
            dbSqlCommand.Parameters.AddWithValue("@feb", feb);
            dbSqlCommand.Parameters.AddWithValue("@mar", mar);
            dbSqlCommand.Parameters.AddWithValue("@apr", apr);
            dbSqlCommand.Parameters.AddWithValue("@may", may);
            dbSqlCommand.Parameters.AddWithValue("@jun", jun);
            dbSqlCommand.Parameters.AddWithValue("@jul", jul);
            dbSqlCommand.Parameters.AddWithValue("@aug", aug);
            dbSqlCommand.Parameters.AddWithValue("@sep", sep);
            dbSqlCommand.Parameters.AddWithValue("@oct", oct);
            dbSqlCommand.Parameters.AddWithValue("@nov", nov);
            dbSqlCommand.Parameters.AddWithValue("@dec", dec);
            dbSqlCommand.Parameters.AddWithValue("@id", id);
            dbSqlCommand.Parameters.AddWithValue("@villageid", village);
            dbSqlCommand.Parameters.AddWithValue("@days", days);
            dbSqlCommand.Parameters.AddWithValue("@occurence", occurence);
            System.Data.SqlClient.SqlParameter pRowsAffected = new SqlParameter("@output", System.Data.SqlDbType.Int);
            pRowsAffected.Direction = System.Data.ParameterDirection.Output;
            dbSqlCommand.Parameters.Add(pRowsAffected);

            try
            {
                dbSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return -1;
            }

            return Convert.ToInt32(pRowsAffected.Value);
        }



        public int INS_UPD_details(string name, string namehindi, int anmcode, int subcentercode, int ID, string Querytype, string type)
        {
            dbSqlCommand = new SqlCommand();
            dbSqlCommand.Connection = dbSqlconnection;
            if (dbSqlconnection.State == ConnectionState.Closed)
            dbSqlconnection.Open();
            dbSqlCommand.CommandType = CommandType.StoredProcedure;
            dbSqlCommand.CommandText = "Ins_Upd_Alldata";
            dbSqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            dbSqlCommand.Parameters.Add("@namehindi", SqlDbType.VarChar).Value = namehindi;
            dbSqlCommand.Parameters.Add("@anmcode", SqlDbType.VarChar).Value = anmcode;
            dbSqlCommand.Parameters.Add("@subcentercode", SqlDbType.VarChar).Value = subcentercode;
            dbSqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            dbSqlCommand.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype;
            dbSqlCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
            System.Data.SqlClient.SqlParameter pRowsAffected = new SqlParameter("@output", System.Data.SqlDbType.Int);
            pRowsAffected.Direction = System.Data.ParameterDirection.Output;
            dbSqlCommand.Parameters.Add(pRowsAffected);

            try
            {
            dbSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            return -1;
            }
            return Convert.ToInt32(pRowsAffected.Value);
        }


        public DataTable getdata(string whr, string flag)
        {
        DataTable SqlDataTable = new DataTable();
        dbSqlCommand = new SqlCommand();
        dbSqlAdapter = new SqlDataAdapter();
        SqlDataTable = new DataTable();
        try
        {
        dbSqlCommand.Connection = dbSqlconnection;
        if (dbSqlconnection.State == ConnectionState.Closed)
        dbSqlconnection.Open();
        dbSqlCommand.CommandType = CommandType.StoredProcedure;
        dbSqlCommand.CommandText = "[Proc_GET_DATA]";         
        dbSqlCommand.Parameters.AddWithValue("@whr",whr);
        dbSqlCommand.Parameters.AddWithValue("@flag",flag);
        dbSqlAdapter.SelectCommand = dbSqlCommand;
        dbSqlAdapter.Fill(SqlDataTable);
        dbSqlconnection.Close();
        return SqlDataTable;
        }
        catch (Exception ex)
        {
        dbSqlconnection.Close();
        return SqlDataTable = null;
        }
        }


        public DataTable getdatavhnd(string whr, string flag)
        {
            DataTable SqlDataTable = new DataTable();
            dbSqlCommand = new SqlCommand();
            dbSqlAdapter = new SqlDataAdapter();
            SqlDataTable = new DataTable();
            try
            {
                dbSqlCommand.Connection = dbSqlconnection;
                if (dbSqlconnection.State == ConnectionState.Closed)
                    dbSqlconnection.Open();
                dbSqlCommand.CommandType = CommandType.StoredProcedure;
                dbSqlCommand.CommandText = "[Proc_GET_DATAvhnd]";
                dbSqlCommand.Parameters.AddWithValue("@whr", whr);
                dbSqlCommand.Parameters.AddWithValue("@flag", flag);
                dbSqlAdapter.SelectCommand = dbSqlCommand;
                dbSqlAdapter.Fill(SqlDataTable);
                dbSqlconnection.Close();
                return SqlDataTable;
            }
            catch (Exception ex)
            {
                dbSqlconnection.Close();
                return SqlDataTable = null;
            }
        }

        public DataTable getdatavhndinser(string year, string occurence, string days)
        {
            DataTable SqlDataTable = new DataTable();
            dbSqlCommand = new SqlCommand();
            dbSqlAdapter = new SqlDataAdapter();
            SqlDataTable = new DataTable();
            try
            {
                dbSqlCommand.Connection = dbSqlconnection;
                if (dbSqlconnection.State == ConnectionState.Closed)
                    dbSqlconnection.Open();
                dbSqlCommand.CommandType = CommandType.StoredProcedure;
                dbSqlCommand.CommandText = "[Proc_GET_DATAvhnd_insert]";
                dbSqlCommand.Parameters.AddWithValue("@year", year);
                dbSqlCommand.Parameters.AddWithValue("@occurence", occurence);
                dbSqlCommand.Parameters.AddWithValue("@days", days);
                dbSqlAdapter.SelectCommand = dbSqlCommand;
                dbSqlAdapter.Fill(SqlDataTable);
                dbSqlconnection.Close();
                return SqlDataTable;
            }
            catch (Exception ex)
            {
                dbSqlconnection.Close();
                return SqlDataTable = null;
            }
        }



        public DataTable TrackChanges(int ashaid, int month, string flag)
        {
            DataTable SqlDataTable = new DataTable();
            dbSqlCommand = new SqlCommand();
            dbSqlAdapter = new SqlDataAdapter();
            SqlDataTable = new DataTable();
            try
            {
            dbSqlCommand.Connection = dbSqlconnection;
            if (dbSqlconnection.State == ConnectionState.Closed)
            dbSqlconnection.Open();
            dbSqlCommand.CommandType = CommandType.StoredProcedure;
            dbSqlCommand.CommandText = "[Proc_TrackChanges]";
            dbSqlCommand.Parameters.AddWithValue("@Ashaid", ashaid);
            dbSqlCommand.Parameters.AddWithValue("@month", month);
            dbSqlCommand.Parameters.AddWithValue("@flag", flag);
            dbSqlAdapter.SelectCommand = dbSqlCommand;
            dbSqlAdapter.Fill(SqlDataTable);
            dbSqlconnection.Close();
            return SqlDataTable;
            }
            catch (Exception ex)
            {
            dbSqlconnection.Close();
            return SqlDataTable = null;
            }
        }


        public DataTable getdatamember(string whr)
        {
        DataTable SqlDataTable = new DataTable();
        dbSqlCommand = new SqlCommand();
        dbSqlAdapter = new SqlDataAdapter();
        SqlDataTable = new DataTable();
        try
        {
        dbSqlCommand.Connection = dbSqlconnection;
        if (dbSqlconnection.State == ConnectionState.Closed)
        dbSqlconnection.Open();
        dbSqlCommand.CommandType = CommandType.StoredProcedure;
        dbSqlCommand.CommandText = "[Proc_GET_DATA_Member]";
        dbSqlCommand.Parameters.AddWithValue("@whr", whr);
        dbSqlAdapter.SelectCommand = dbSqlCommand;
        dbSqlAdapter.Fill(SqlDataTable);
        dbSqlconnection.Close();
        return SqlDataTable;
        }
        catch (Exception ex)
        {
        dbSqlconnection.Close();
        return SqlDataTable = null;
        }
        }


        public DataTable getreport(string whr, string flag)
        {
            DataTable SqlDataTable = new DataTable();
            dbSqlCommand = new SqlCommand();
            dbSqlAdapter = new SqlDataAdapter();
            SqlDataTable = new DataTable();
            try
            {
                dbSqlCommand.Connection = dbSqlconnection;
                if (dbSqlconnection.State == ConnectionState.Closed)
                    dbSqlconnection.Open();
                dbSqlCommand.CommandType = CommandType.StoredProcedure;
                dbSqlCommand.CommandText = "[Proc_GET_Report]";
                dbSqlCommand.Parameters.AddWithValue("@whr", whr);
                dbSqlCommand.Parameters.AddWithValue("@flag", flag);
                dbSqlAdapter.SelectCommand = dbSqlCommand;
                dbSqlAdapter.Fill(SqlDataTable);
                dbSqlconnection.Close();
                return SqlDataTable;
            }
            catch (Exception ex)
            {
                dbSqlconnection.Close();
                return SqlDataTable = null;
            }
        }


        public DataSet getdatareport()
        {
            DataSet SqlDataTable = new DataSet();
            dbSqlCommand = new SqlCommand();
            dbSqlAdapter = new SqlDataAdapter();
            SqlDataTable = new DataSet();
            try
            {
                dbSqlCommand.Connection = dbSqlconnection;
                if (dbSqlconnection.State == ConnectionState.Closed)
                dbSqlconnection.Open();
                dbSqlCommand.CommandType = CommandType.StoredProcedure;
                dbSqlCommand.CommandText = "[Proc_GET_DataReport]";
                dbSqlAdapter.SelectCommand = dbSqlCommand;
                dbSqlAdapter.Fill(SqlDataTable);
                dbSqlconnection.Close();
                return SqlDataTable;
            }
            catch (Exception ex)
            {
                dbSqlconnection.Close();
                return SqlDataTable = null;
            }
        }     

    }
    }



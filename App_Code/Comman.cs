using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public class Comman
{

    public static DataTable Select_All_Data(string TableName, string TFieldName, string Condition, string OrderbyCondition, string Sortcondition)
    {
        DataTable dtcombo = new DataTable();
        try
        {
            string WConditions = Condition.Length > 0 ? " where " + Condition : "";
            string OrderbyvalueMem = OrderbyCondition.Length > 0 ? " order by " + OrderbyCondition + "  " : "";
            string sortbycondi = Sortcondition.Length > 0 ? "" + Sortcondition : "";
            string FieldName = TFieldName.Length > 0 ? TFieldName : "";
            SqlParameter[] paramvT = new SqlParameter[]
                    {                            
                            new SqlParameter("@TableName",TableName),
                            new SqlParameter("@Condition",WConditions),
                            new SqlParameter("@OrderbyvalueMem",OrderbyvalueMem),
                            new SqlParameter("@sortbycondi",sortbycondi), 
                            new SqlParameter("@FieldName",FieldName),                            
                           
                    };

            dtcombo = SqlHelper.GetDataTable(SqlHelper.mainConnectionString, CommandType.StoredProcedure, "Get_Select_AllTableData", paramvT);
        }
        catch (Exception ex)
        {
            //string mmsg = ex.Message; showMessages(mmsg);
            //showMessages("(SelectAllData)  " + mmsg);
        }
        return dtcombo;
    }
    public static DataTable MenuDataTable(string userlevel)
    {
        DataTable oDataTable = new DataTable();
        try
        {
            if (userlevel == "99")
            {
                oDataTable = SqlHelper.GetDataTable("SELECT distinct m.MenuID, MenuParentID as ParentID, Menu as  Name,ReWriteURL as URL, MenuURL as MURL,MenuSequence FROM MstMenu m inner join MstRoleMenu mr on m.MenuID=mr.MenuID order by MenuParentID,MenuSequence asc ");

            }
            else
            {
                oDataTable = SqlHelper.GetDataTable(" select m.MenuID, MenuParentID as ParentID, Menu as  Name,ReWriteURL as URL, MenuURL as MURL,MenuSequence from MstMenu m inner join (select * from(select  mr.menuid,SUM(permission) as p,SUM(AddEdit) as e,SUM(Administrator)as ad from  MstRoleMenu mr  where mr.RoleID in(" + userlevel + ") group by  mr.menuid)dt where dt.ad>0 and p>0)mr on m.MenuID=mr.MenuID order by MenuSequence asc");
            }
        }
        catch (Exception ex)
        {

        }
        return oDataTable;
    }
    public static DataTable MenuDataTable_EditAdd_Rights(string userlevel,string pageURL)
    {
        DataTable oDataTable = new DataTable();
        try
        {
            oDataTable = SqlHelper.GetDataTable("select case when p>0 then 'True' else 'False' end pr,case when e>0 then 'True' else 'False' end ed,case when ad>0 then 'True' else 'False' end ad from( select  mr.menuid,SUM(permission) as p,SUM(AddEdit) as e,SUM(Administrator)as ad from  MstRoleMenu mr inner join MstMenu m on m.MenuID=mr.MenuID  where mr.RoleID in(" + userlevel + ") and  and m.MenuURL='" + pageURL + "'  group by  mr.menuid)dt");
            
        }
        catch (Exception ex)
        {

        }
        return oDataTable;
    }
   
    public static string Generate_RandomString(int NoChar)
    {
        string UNICode = "";
        System.Threading.Thread.Sleep(1000);
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, NoChar).Select(s => s[random.Next(s.Length)]).ToArray());
        //var result = new string(Enumerable.Repeat(chars, NoChar).Select(s => s[random.Next(s.Length)]).ToArray()) + DateTime.Now.ToString("yyyyMMddhhmmssfff");
        UNICode = result.ToString();
        return UNICode;
    }
    public static void SetDdl_value(DropDownList ddl, string Svalue)
    {
        try
        {
            ddl.SelectedValue = Svalue;
        }
        catch (Exception ex)
        {
            ddl.SelectedIndex = 0;
        }
    }
    public static void SetDdl_TextFields(DropDownList ddl, string Svalue)
    {
        try
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text.ToLower() == Svalue || ddl.Items[i].Value == Svalue)
                {
                    ddl.Items[i].Selected = true;                  
                    break;
                }
            }           
        }
        catch (Exception ex)
        {
            ddl.SelectedIndex = 0;
        }
    }
    public static void SetDdl_value_withText(DropDownList ddl, string Svalue)
    {
        try
        {
            ddl.SelectedItem.Text = Svalue;
        }
        catch (Exception ex)
        {
            ddl.SelectedIndex = 0;
        }
    }
    public static void BindDDL_ZeroIndex(DropDownList dll, DataTable dt, string fname, string fvalue, string ZeroIndex)
    {
        try
        {
            DataRow dr = dt.NewRow();
            dr[fvalue] = 0;
            dr[fname] = "--" + ZeroIndex + "--";
            dt.Rows.InsertAt(dr, 0);
            dt.AcceptChanges();
            if (dll.Items.Count > 0)
            {
                dll.Items.Clear();
            }
            dll.DataSource = dt;
            dll.DataTextField = fname;
            dll.DataValueField = fvalue;
            dll.DataBind();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public static void Bind_DropDownlist(DropDownList dll, DataTable dt, string fname, string fvalue)
    {
        try
        {
            if (dt.Rows.Count > 0)
            {
                if (dll.Items.Count > 0)
                {
                    dll.Items.Clear();
                }
                dll.DataSource = dt;
                dll.DataTextField = fname;
                dll.DataValueField = fvalue;
                dll.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public static object Setnullvalue(string value)
    {
        if (value == "" || value == "0" || value == null)
            return DBNull.Value;
        else
            return value;
    }
    public static object Setnullvalue_nonZero(string value)
    {
        if (value == "" || value == null)
            return DBNull.Value;
        else
            return value;
    }
    public static object SetnullvalueDate(DateTime value)
    {
        if (value == null)
            return DBNull.Value;
        else
            return value;
    }
    public static int _Month_Integer(string monthName)
    {
        int Mnth = 0;
        switch (monthName.ToLower().Substring(0, 3))
        {
            case "jan": Mnth = 1;
                break;
            case "feb": Mnth = 2;
                break;
            case "mar": Mnth = 3;
                break;
            case "apr": Mnth = 4;
                break;
            case "may": Mnth = 5;
                break;
            case "jun": Mnth = 6;
                break;
            case "jul": Mnth = 7;
                break;
            case "aug": Mnth = 8;
                break;
            case "sep": Mnth = 9;
                break;
            case "oct": Mnth = 10;
                break;
            case "nov": Mnth = 11;
                break;
            case "dec": Mnth = 12;
                break;
        }
        return Mnth;
    }
    public static string Date_SlaceToHifan(string strdt)
    {
        string dtstr = "";
        string[] dtyp = strdt.Split('/');
        dtstr = dtyp[2] + "-" + dtyp[1] + "-" + dtyp[0];
        return dtstr;
    }
    public static string Date_HifanToSlace(string strdt)
    {
        string dtstr = "";
        string[] dtyp = strdt.Split('-');
        dtstr = dtyp[2] + "/" + dtyp[1] + "/" + dtyp[0];
        return dtstr;
    }
    public static string Date_SlaceToHifan(DateTime dtD)
    {
        string dtstr = "", dd = dtD.Day > 9 ? dtD.Day.ToString() : "0" + dtD.Day.ToString()
          , mm = dtD.Month > 9 ? dtD.Month.ToString() : "0" + dtD.Month.ToString()
          , yy = dtD.Year > 9 ? dtD.Year.ToString() : "0" + dtD.Year.ToString();
        dtstr = yy + "-" + mm + "-" + dd;
        return dtstr;
    }
    public static string Date_HifanToSlace(DateTime dtD)
    {
        string dtstr = "", dd = dtD.Day > 9 ? dtD.Day.ToString() : "0" + dtD.Day.ToString()
            , mm = dtD.Month > 9 ? dtD.Month.ToString() : "0" + dtD.Month.ToString()
            , yy = dtD.Year > 9 ? dtD.Year.ToString() : "0" + dtD.Year.ToString();
        dtstr = dd + "/" + mm + "/" + yy;
        return dtstr;
    }
    public static string Date_InInteger(DateTime dtD)
    {
        string dtstr = "", dd = dtD.Day > 9 ? dtD.Day.ToString() : "0" + dtD.Day.ToString()
            , mm = dtD.Month > 9 ? dtD.Month.ToString() : "0" + dtD.Month.ToString()
            , yy = dtD.Year > 9 ? dtD.Year.ToString() : "0" + dtD.Year.ToString();
        dtstr = yy + mm + dd;
        return dtstr;
    }

}



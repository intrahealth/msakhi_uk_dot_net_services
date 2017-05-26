using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    public System.Data.DataTable dtSessionGlobal = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["OptionDB"] = null;
        if (Cache["UserSessions"] != null)
        {
            dtSessionGlobal = (DataTable)Cache["UserSessions"];
            if (dtSessionGlobal.Columns.Count == 0)
            {
                dtSessionGlobal.Columns.Add("UserName");
                dtSessionGlobal.Columns.Add("SessionID");
            }
        }
        else
        {
            dtSessionGlobal.Columns.Add("UserName");
            dtSessionGlobal.Columns.Add("SessionID");
            Cache["UserSessions"] = dtSessionGlobal;
        }

        if (!IsPostBack)
        {
            lbl_msg.Text = "";
        }
    }
    public void Login_User()
    {
        try
        {
            lbl_msg.Text = "";
            SqlParameter[] pr = new SqlParameter[] { 
        new SqlParameter("@Userid",txt_uid.Text.Trim()),
         new SqlParameter("@Password",txt_pwd.Text.Trim()),
        };

            DataTable dt = SqlHelper.GetDataTable(SqlHelper.mainConnectionString, CommandType.StoredProcedure, "Sp_Get_UserLogin_data", pr);

            if (txt_uid.Text.Trim() == "adminuser" || txt_uid.Text.Trim() == "stateuser1" || txt_uid.Text.Trim() == "districtuser1" || txt_uid.Text.Trim() == "blockuser1")
            {
                if (dt.Rows.Count > 0)
                {
                    Session["UserID"] = dt.Rows[0]["UserID"];

                    if (Convert.ToString(dt.Rows[0]["UserID"]) == "")
                    {
                        Response.Redirect("~/Login.aspx", false);
                    }
                    else
                    {
                        DataTable dtmenu = Comman.MenuDataTable(Convert.ToString(Session["userlevel"]));
                        FormsAuthentication.SetAuthCookie(txt_uid.Text.Trim(), true);
                        HttpCookie cc = FormsAuthentication.GetAuthCookie(txt_uid.Text.Trim(), true);
                        Response.Redirect("~/Dashboard.aspx", false);
                    }
                }
                else
                {
                    lbl_msg.ForeColor = Color.Red;
                    lbl_msg.Text = "Invalid userid or password.";
                }
            }
            else
            {
                lbl_msg.ForeColor = Color.Red;
                lbl_msg.Text = "Invalid userid or password.";
                txt_pwd.Text = "";
            }
        }
        catch (Exception ex)
        {
            lbl_msg.ForeColor = Color.Red;
            lbl_msg.Text = "Problem with connnection.";
        }
    }

    protected void tbn_login_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_msg.Text = "";
            Login_User();
        }
        catch (Exception ex)
        {
            lbl_msg.ForeColor = Color.Red;
            lbl_msg.Text = ex.Message;
        }

    }
}
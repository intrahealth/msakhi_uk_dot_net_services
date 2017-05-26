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


public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    getData();
    }

    private void getData()
    {
        SqlParameter[] pr = new SqlParameter[] { 
        new SqlParameter("@Condition1",""),
        new SqlParameter("@Condition2",""),
        };
        DataTable dtpia = SqlHelper.GetDataTable(SqlHelper.mainConnectionString, CommandType.StoredProcedure, "Sp_Get_Count_data", pr);

        if (dtpia.Rows.Count > 0)
        {
        lblmale.Text = dtpia.Rows[0][0].ToString();
        lblfemale.Text = dtpia.Rows[0][1].ToString();
        lblMember.Text = dtpia.Rows[0][2].ToString();
        lblmarried.Text = dtpia.Rows[0][3].ToString();
        lblunmarried.Text = dtpia.Rows[0][4].ToString();
        lblsc.Text = dtpia.Rows[0][5].ToString();
        lblst.Text = dtpia.Rows[0][6].ToString();
        lblobc.Text = dtpia.Rows[0][7].ToString();
        lblother.Text = dtpia.Rows[0][8].ToString();
        lblvillage.Text = dtpia.Rows[0][9].ToString();
        }
        else
        {
        lblmale.Text = "";
        lblfemale.Text = "";
        lblMember.Text = "";
        lblmarried.Text = "";
        lblunmarried.Text = "";
        lblsc.Text = "";
        lblst.Text = "";
        lblobc.Text = "";
        lblother.Text = "";
        lblvillage.Text = "";
        }
    }

   
}
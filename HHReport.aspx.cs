using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BusinessLogicLayer;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Drawing;

public partial class HHReport : System.Web.UI.Page
{
    BllLibrary objBLL = new BllLibrary();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessage.Text = "";
        if (IsPostBack == false)
        {
            bindGrid();

        }
    }

   
    PageStatePersister pageStatePersister;
    protected override PageStatePersister PageStatePersister
    {
        get
        {
            // Unlike as exemplified in the MSDN docs, we cannot simply return a new PageStatePersister
            // every call to this property, as it causes problems
            return pageStatePersister ?? (pageStatePersister = new SessionPageStatePersister(this));
        }
    }

    #region Properties for Sorting and DataTable

    string SortField
    {
        get
        {
            object o = ViewState["SortField"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortField"] = value;
        }
    }

    string SortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            if (o == null)
                return String.Empty;
            else
                return (string)o;
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }

    public DataTable Temp
    {
        get
        {
            object o = ViewState["Temp"];
            if (o == null)
            {
                DataTable dt = new DataTable();
                return dt;
            }
            else
                return (DataTable)o;
        }
        set
        {
            ViewState["Temp"] = value;
        }
    }

    #endregion

    private void bindGrid()
    {
        lblcount.Text = "0";
        DataTable dt = new DataTable();
        dt = objBLL.getreport("", "B");
        if (dt.Rows.Count > 0)
        {
        lblcount.Text = dt.Rows.Count.ToString();
        this.GVhhreportData.DataSource = dt;
        this.GVhhreportData.DataBind();
        }
        else
        {
        lblmessage.Text = "No Record Found.......";
        lblmessage.ForeColor = Color.Red;
        this.GVhhreportData.DataSource = null;
        this.GVhhreportData.DataBind();
        }
    }


    protected void GVhhreportData_Sorting(object sender, GridViewSortEventArgs e)
    {
    if (e.SortExpression.Trim() == this.SortField)
    this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
    else
    this.SortDirection = "A";
    this.SortField = e.SortExpression;
    bindGrid();
    }


    protected void GVhhreportData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    GVhhreportData.PageIndex = e.NewPageIndex;
    bindGrid();       
    }

  
    protected void GVhhreportData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblmsg.Text = "";
        lblmessage.Text = "";
        string WhereQuery = "";
       
        DataTable dtRowData = new DataTable();

        if (e.CommandName == "Editdata")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string autoID = GVhhreportData.DataKeys[index].Values["anmcode"].ToString();
            string anmname = GVhhreportData.DataKeys[index].Values["anmname"].ToString();
            Session["anmcode"] = autoID;
            Session["anmname"] = anmname;

            if (autoID != "")
            {
                WhereQuery = "where total.anmcode='" + autoID + "'";
            }

            dtRowData = objBLL.getreport(WhereQuery,"A");

            if (dtRowData.Rows.Count > 0)
            {
                lblcountmem.Text = dtRowData.Rows.Count.ToString();
                lblanm.Text = anmname;
                lblanm.ForeColor = Color.OrangeRed;
                this.GVhhashadet.DataSource = dtRowData;
                this.GVhhashadet.DataBind();
            }

            MpexdrBlock.Show();

        }


    }


   
  
}
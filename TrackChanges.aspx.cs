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


public partial class TrackChanges : System.Web.UI.Page
{
    BllLibrary objBLL = new BllLibrary();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessage.Text = "";
        if (IsPostBack == false)
        {
            FillashaName();
            bindGrid();
           
        }
    }

   

    private void FillashaName()
    {
        DataTable dtSelectasha = new DataTable();
        dtSelectasha = objBLL.Selectashatrack();
        Session["BankBranch"] = dtSelectasha;
        ddlashaName.DataValueField = "ASHAId";
        ddlashaName.DataTextField = "ASHAName";
        ddlashaName.DataSource = dtSelectasha;
        ddlashaName.DataBind();
        ddlashaName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
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
        int ashaid =0, month=0;
        dt = objBLL.TrackChanges(ashaid, month,"N");
        if (dt.Rows.Count > 0)
        {
        lblcount.Text = dt.Rows.Count.ToString();
        this.GVtrackchanges.DataSource = dt;
        this.GVtrackchanges.DataBind();
        }
        else
        {
        lblmessage.Text = "No Record Found.......";
        lblmessage.ForeColor = Color.Red;
        this.GVtrackchanges.DataSource = null;
        this.GVtrackchanges.DataBind();
        }
    }


    protected void GVtrackchanges_Sorting(object sender, GridViewSortEventArgs e)
    {
    if (e.SortExpression.Trim() == this.SortField)
    this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
    else
    this.SortDirection = "A";
    this.SortField = e.SortExpression;
    BtnSearch_Click1(sender, e);
    }


    protected void GVtrackchanges_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    GVtrackchanges.PageIndex = e.NewPageIndex;
    if (ddlmonth.SelectedValue != "" || ddlashaName.SelectedValue != "")
    {
    BtnSearch_Click1(sender, e);
    }
    else
    {
    bindGrid();
    }
    }

    protected void BtnSearch_Click1(object sender, EventArgs e)
    {
        lblcount.Text = "0";
        int month= 0, ashaid = 0;        
        lblmessage.Text = " ";
        month = Convert.ToInt32(ddlmonth.SelectedValue);
        if (ddlashaName.SelectedValue != "")
        {
            ashaid = Convert.ToInt32(ddlashaName.SelectedValue);
        }
        else
        {
            ashaid = 0;
        }

        DataTable dt = new DataTable();
        dt = objBLL.TrackChanges(ashaid, month,"C");
        if (dt.Rows.Count > 0)
        {
        lblcount.Text = dt.Rows.Count.ToString();
        this.GVtrackchanges.DataSource = dt;
        this.GVtrackchanges.DataBind();
        }
        else
        {
        //lblmessage.Text = "No Record Found.......";
        lblmessage.ForeColor = Color.Red;
        this.GVtrackchanges.DataSource = null;
        this.GVtrackchanges.DataBind();
        bindGrid();
        }        
        ScriptManager.RegisterStartupScript(this.Page, GetType(), "Key", "gridviewScroll();", true);

    }

}
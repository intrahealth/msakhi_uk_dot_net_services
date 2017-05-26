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

public partial class hhvrerification : System.Web.UI.Page
{
    BllLibrary objBLL = new BllLibrary();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessage.Text = "";
        if (IsPostBack == false)
        {
            FillanmName();
            FillashaName();
            bindGrid();
        }
    }

    private void FillanmName()
    {
        DataTable dtSelectanm = new DataTable();
        dtSelectanm = objBLL.Getselectanm();
        Session["anm"] = dtSelectanm;
        ddlanmName.DataValueField = "ANMCode";
        ddlanmName.DataTextField = "ANMName";
        ddlanmName.DataSource = dtSelectanm;
        ddlanmName.DataBind();
        ddlanmName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
    }


    //protected void ddlanmName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dtSelectasha = new DataTable();
    //    dtSelectasha = objBLL.GetSelectasha(ddlanmName.SelectedValue);
    //    Session["BankBranch"] = dtSelectasha;
    //    ddlashaName.DataValueField = "ASHACode";
    //    ddlashaName.DataTextField = "ASHAName";
    //    ddlashaName.DataSource = dtSelectasha;
    //    ddlashaName.DataBind();
    //    ddlashaName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
    //}


    private void FillashaName()
    {
        DataTable dtSelectasha = new DataTable();
        dtSelectasha = objBLL.GetSelectasha12();
        Session["BankBranch"] = dtSelectasha;
        ddlashaName.DataValueField = "ASHACode";
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
        string WhereQuery = "order by MstANM.ANMName";
        dt = objBLL.getdata(WhereQuery, "V");
        if (dt.Rows.Count > 0)
        {
            lblcount.Text = dt.Rows.Count.ToString();
            this.GVanmData.DataSource = dt;
            this.GVanmData.DataBind();
        }
        else
        {
            lblmessage.Text = "No Record Found.......";
            lblmessage.ForeColor = Color.Red;
            this.GVanmData.DataSource = null;
            this.GVanmData.DataBind();
        }
    }


    protected void GVanmData_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
        else
            this.SortDirection = "A";
        this.SortField = e.SortExpression;
        bindGrid();
    }


    protected void GVanmData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVanmData.PageIndex = e.NewPageIndex;
        if (Session["anmname"] != "")
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
        string WhereQuery = "";
        string anmcode, ashacode;
        lblmessage.Text = " ";
        anmcode = ddlanmName.SelectedValue;
        Session["anmname"] = anmcode;
        ashacode = ddlashaName.SelectedValue;
            if (anmcode != "")
            {
                if (WhereQuery != "")
                {
                    WhereQuery = WhereQuery + "and mstanm.ANMCode=" + anmcode + "";
                }
                else
                {
                    WhereQuery = "where mstanm.ANMCode=" + anmcode + "";
                }
            }
            if (ashacode != "")
            {
                if (WhereQuery != "")
                {
                    WhereQuery = WhereQuery + "and mstasha.ASHACode='" + ashacode + "'";
                }
                else
                {
                WhereQuery ="where mstasha.ASHACode='" + ashacode + "'";
                }
            }

            DataTable dt = new DataTable();
            dt = objBLL.getdata(WhereQuery, "S");
            if (dt.Rows.Count > 0)
            {
                lblcount.Text = dt.Rows.Count.ToString();
                this.GVanmData.DataSource = dt;
                this.GVanmData.DataBind();
            }
            else
            {
                lblmessage.Text = "No Record Found.......";
                lblmessage.ForeColor = Color.Red;
                this.GVanmData.DataSource = null;
                this.GVanmData.DataBind();
            }
        ScriptManager.RegisterStartupScript(this.Page, GetType(), "Key", "gridviewScroll();", true);
    }


   
}
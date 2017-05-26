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


public partial class hhdata : System.Web.UI.Page
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
            ClientScript.RegisterStartupScript(GetType(), "key", "gridviewScroll();", true);
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
    //DataTable dtSelectasha = new DataTable();
    //dtSelectasha = objBLL.GetSelectasha(ddlanmName.SelectedValue);
    //Session["BankBranch"] = dtSelectasha;
    //ddlashaName.DataValueField = "ASHACode";
    //ddlashaName.DataTextField = "ASHAName";
    //ddlashaName.DataSource = dtSelectasha;
    //ddlashaName.DataBind();
    //ddlashaName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
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
    dt = objBLL.getdata(WhereQuery, "F");
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
        string anmcode, ashacode, verified;
        lblmessage.Text = " ";
        anmcode = ddlanmName.SelectedValue;
        Session["anmname"] = anmcode;
        ashacode = ddlashaName.SelectedValue;
        verified = ddlverify.SelectedValue;
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

            if (verified != "")
            {
                if (WhereQuery != "")
                {
               WhereQuery = WhereQuery + "and tblhhsurvey.verified='" + verified + "'";
                }
                else
                {
                    WhereQuery = "where tblhhsurvey.verified='" + verified + "'";
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


    protected void BtnSearchmem_Click(object sender, EventArgs e)
    {
        lblcountmem.Text = "0";
        string WhereQuery = "";
        string membercode = "", membername = "", autoID = "";
        lblmessage.Text = " ";
        membercode = txt_familycode.Text;
        membername = txtfamilyname.Text;
        autoID = Session["hhsurveyguid"].ToString();

        if (membername != "" && membercode != "")
        {
        WhereQuery = "where FamilyMemberName= N'" + membername + "' and HHFamilyMemberCode=" + membercode + " and hhsurveyguid='" + autoID + "' ";
        }
        else if (membername == "" && membercode == "")
        {
        WhereQuery = "where hhsurveyguid='" + autoID + "' ";
        }
        else
        {
        if (membername != "")
        {
        WhereQuery = "where FamilyMemberName= N'" + membername + "' and hhsurveyguid='" + autoID + "'";
        }

        if (membercode != "")
        {
        WhereQuery = "where HHFamilyMemberCode='" + membercode + "' and hhsurveyguid='" + autoID + "'";
        }
        }
        DataTable dtRowData = new DataTable();
        dtRowData = objBLL.getdatamember(WhereQuery);
        if (dtRowData.Rows.Count > 0)
        {
        lblcountmem.Text = dtRowData.Rows.Count.ToString();
        this.GVmember.DataSource = dtRowData;
        this.GVmember.DataBind();
        lblmsg.Text = "";
        }
        else
        {
        lblmsg.Text = "No Record Found.......";
        lblmsg.ForeColor = Color.Red;
        this.GVmember.DataSource = null;
        this.GVmember.DataBind();
        }
        MpexdrBlock.Show();
    }


    protected void GVanmData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblmsg.Text = "";
        lblmessage.Text = "";
        string WhereQuery = "";
        txt_familycode.Text = "";
        txtfamilyname.Text = "";
        DataTable dtRowData = new DataTable();

        if (e.CommandName == "Editdata")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string autoID = GVanmData.DataKeys[index].Values["hhsurveyguid"].ToString();
            Session["hhsurveyguid"] = autoID;

            if (autoID != "")
            {
                WhereQuery = "where hhsurveyguid='" + autoID + "'";
            }
            dtRowData = objBLL.getdatamember(WhereQuery);
            if (dtRowData.Rows.Count > 0)
            {
                lblcountmem.Text = dtRowData.Rows.Count.ToString();
                this.GVmember.DataSource = dtRowData;
                this.GVmember.DataBind();
            }
            MpexdrBlock.Show();
        }
    }


    protected void GVanmData_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
        {
            Session["count"] = 0;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string verify = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "verified"));
            if (verify != "" && verify != "No")
            {
                for (int i = 0; i < GVanmData.HeaderRow.Cells.Count; i++)
                {
                    string test = GVanmData.HeaderRow.Cells[i].Text;
                    if (test == "Verify")
                        e.Row.Cells[i].BackColor = Color.Green;
                }
            }
            else
            {
                e.Row.BackColor = Color.White;
            }
        }
        else
        {
        }
    }


    protected void GVmember_OnDataBound(object sender, EventArgs e)
    {
        if (GVmember.Rows.Count > 0)
        {
            GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell_0 = new TableCell();
            HeaderCell_0.Text = "SNo";
            HeaderCell_0.ColumnSpan = 0;
            HeaderCell_0.Width = 50;
            HeaderRow.Cells.Add(HeaderCell_0);
            HeaderCell_0.Style.Add("text-align", "left");
            HeaderCell_0.Style.Add("color", "#990000");
            HeaderCell_0.Style.Add("background-color", "#edd4ab");
            HeaderCell_0.Style.Add("font-weight", "bold");

            TableCell HeaderCell_01 = new TableCell();
            HeaderCell_01.Text = "Family Code";
            HeaderCell_01.ColumnSpan = 0;
            HeaderCell_01.Width = 100;
            HeaderRow.Cells.Add(HeaderCell_01);
            HeaderCell_01.Style.Add("text-align", "left");
            HeaderCell_01.Style.Add("color", "#990000");
            HeaderCell_01.Style.Add("background-color", "#edd4ab");
            HeaderCell_01.Style.Add("font-weight", "bold");

            TableCell HeaderCell_2 = new TableCell();
            HeaderCell_2.Text = "HH Member Name";
            HeaderCell_2.ColumnSpan = 0;
            HeaderCell_2.Width = 250;
            HeaderRow.Cells.Add(HeaderCell_2);
            HeaderCell_2.Style.Add("background-color", "#edd4ab");
            HeaderCell_2.Style.Add("text-align", "left");
            HeaderCell_2.Style.Add("color", "#990000");
            HeaderCell_2.Style.Add("font-weight", "bold");

            TableCell HeaderCell_04 = new TableCell();
            HeaderCell_04.Text = "Gender";
            HeaderCell_04.ColumnSpan = 0;
            HeaderCell_04.Width = 50;
            HeaderCell_04.Style.Add("background-color", "#edd4ab");
            HeaderCell_04.Style.Add("text-align", "left");
            HeaderCell_04.Style.Add("color", "#990000");
            HeaderCell_04.Style.Add("font-weight", "bold");
            HeaderRow.Cells.Add(HeaderCell_04);

            TableCell HeaderCell_03 = new TableCell();
            HeaderCell_03.Text = "Maritial Status";
            HeaderCell_03.ColumnSpan = 0;
            HeaderCell_03.Width = 100;
            HeaderCell_03.Style.Add("background-color", "#edd4ab");
            HeaderCell_03.Style.Add("text-align", "left");
            HeaderCell_03.Style.Add("color", "#990000");
            HeaderCell_03.Style.Add("font-weight", "bold");
            HeaderRow.Cells.Add(HeaderCell_03);

            TableCell HeaderCell_06 = new TableCell();
            HeaderCell_06.Text = "Age";
            HeaderCell_06.ColumnSpan = 4;
            HeaderCell_06.Width = 100;
            HeaderCell_06.Style.Add("background-color", "#edd4ab");
            HeaderCell_06.Style.Add("text-align", "center");
            HeaderCell_06.Style.Add("color", "#990000");
            HeaderCell_06.Style.Add("font-weight", "bold");
            HeaderRow.Cells.Add(HeaderCell_06);
            GVmember.Controls[0].Controls.AddAt(0, HeaderRow);

        }
    }

}
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


public partial class frm_ASHA : System.Web.UI.Page
{
    DataTable dtSrchBlock_code, dtFillDistrict, dtRowData, dtSelectMethod, dtFillState;
    BllLibrary objBLL = new BllLibrary();
    //public static string btnval;
    public static string btnval, btnvalGM, MainQuery, GroupName;
    //static int autoID;
    static string stateCode, autoID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {
            lblmessage.Text = "";
            bindGrid();
        }
    }


    private void FillanmName()
    {
    DataTable dtSelectanm = new DataTable();
    dtSelectanm = objBLL.Getselectanm();        
    Session["anmcode"] = dtSelectanm;
    ddlanmName.DataValueField = "ANMCode";
    ddlanmName.DataTextField = "ANMName";
    ddlanmName.DataSource = dtSelectanm;
    ddlanmName.DataBind();
    ddlanmName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));      
    }

    private void Fillsubcenter()
    {
        DataTable dtSelectsubcenter = new DataTable();
        dtSelectsubcenter = objBLL.Getsubcenter();
        ddlsubcenter.DataValueField = "SubcenterCode";
        ddlsubcenter.DataTextField = "SubcenterName";
        ddlsubcenter.DataSource = dtSelectsubcenter;
        ddlsubcenter.DataBind();
        ddlsubcenter.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
    }


    protected void ddlanmName_SelectedIndexChanged(object sender, EventArgs e)
    {
    DataTable dtSelectsubcenter = new DataTable();
    dtSelectsubcenter = objBLL.GetSelectsubcenter(ddlanmName.SelectedValue);
    Session["subcentercode"] = dtSelectsubcenter;
    ddlsubcenter.DataValueField = "SubcenterCode";
    ddlsubcenter.DataTextField = "SubcenterName";
    ddlsubcenter.DataSource = dtSelectsubcenter;
    ddlsubcenter.DataBind();
    ddlsubcenter.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
    MpexdrBlock.Show();
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

        DataTable dt = new DataTable();
        dt = objBLL.GetGroupFilterDataasha();
        if (dt.Rows.Count > 0)
        {
        this.GVashaData.DataSource = dt;
        this.GVashaData.DataBind();
        }
        else
        {
        lblmessage.Text = "No Record Found.......";
        lblmessage.ForeColor = Color.Red;
        this.GVashaData.DataSource = null;
        this.GVashaData.DataBind();
        }

    }


    private void text_blank()
    {
    lblmessage.Text = "";
    txt_ashacode.Text = "";
    txtashaname.Text = "";
    txtashaNm.Text = "";
    txtashaNmhindi.Text = "";
    }

    #region "Insert Update and Delete Records Data"

    protected void TndrConfirmYes_Click1(object sender, EventArgs e)
    {
        DataTable dtdeleteanm = new DataTable();

        int ashaid = Convert.ToInt32(Session["ashaid"]);

        if (ashaid > 0)
        {
        dtdeleteanm = objBLL.Getashadelete(ashaid);
        bindGrid();
        lblmessage.Text = "Deleted Successfully..";
        }
    }

    protected void Btnsave_Click1(object sender, EventArgs e)
    {
        int data,anmcode, subcentercode;
        string name, namehindi;

        if (txtashaNm.Text != "")
        {
            name = txtashaNm.Text;
        }
        else
        {
            name = txtashaNm.Text;
        }

        if (txtashaNmhindi.Text != "")
        {
            namehindi = txtashaNmhindi.Text;
        }
        else
        {
            namehindi = txtashaNmhindi.Text;
        }

        
        anmcode =Convert.ToInt32(ddlanmName.SelectedValue);
        subcentercode = Convert.ToInt32(ddlsubcenter.SelectedValue);

        int ID = Convert.ToInt32(Session["ashaid"]);

        if (ID > 0)
        {
            ID = Convert.ToInt32(Session["ashaid"]);
        }
        else
        {
            ID = 0;
        }

        if (btnval == "Add")
        {

            data = objBLL.insetupdatedate(name, namehindi, anmcode, subcentercode, ID, "A", "I");
            if (data > 0)
            {
                bindGrid();
                lblmessage.Text = "Saved Successfully..";
                lblmessage.ForeColor = Color.Green;
            }
            else if (data == -11)
            {
                //  MpexdrBlock.Show(); lblMsgGrpmbr.Visible = true;
                lblMsgGrpmbr.Text = "Asha Name Already Exists!!";
                lblMsgGrpmbr.ForeColor = Color.Red;
            }
            else
            {
                lblmessage.Text = "Execution Failed..";
                lblmessage.ForeColor = Color.Red;
            }
        }
        if (btnval == "Update")
        {
            data = objBLL.insetupdatedate(name, namehindi, anmcode, subcentercode, ID, "A", "U");
            if (data > 0)
            {
                bindGrid();
                lblmessage.Text = "Executed Successfully..";
                lblmessage.ForeColor = Color.Green;
            }
            else
            {
                lblmessage.Text = "Execution Failed..";
                lblmessage.ForeColor = Color.Red;
            }
        }
    }

    #endregion

    protected void GVashaData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].ToolTip = "Edit";
                e.Row.Cells[4].ToolTip = "Delete";
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void GVashaData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblmessage.Text = "";
        dtRowData = new DataTable();
        DataTable dtRowData1 = new DataTable();
        if (e.CommandName == "EditCenter")
        {
            FillanmName();
            lblMsgGrpmbr.Text = "";
            int index = Convert.ToInt32(e.CommandArgument);
            btnval = "Update";
            addlabel.Text = "ASHA";
            autoID = GVashaData.DataKeys[index].Values["ASHAID"].ToString();
            Session["ashaid"] = autoID;   
            dtRowData = objBLL.GetashaMstrRowData(autoID);
            dtRowData1 = objBLL.GetashaMstrRowData1(autoID);
            txtashaNm.Text = dtRowData.Rows[0]["AshaName"].ToString();
            txtashaNmhindi.Text = dtRowData1.Rows[0]["AshaName"].ToString();
            ddlanmName.SelectedValue = dtRowData.Rows[0]["AnmCode"].ToString();
            Fillsubcenter();
            ddlsubcenter.SelectedValue = dtRowData.Rows[0]["subcenterCode"].ToString();

            MpexdrBlock.Show();
        }

        else if ((e.CommandName == "DeleteCenter"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            btnval = "Delete";
            autoID = GVashaData.DataKeys[index].Values["AshaID"].ToString();
            Session["ashaid"] = autoID;   
            MPDelBlock.Show();
        }
    }

    protected void GVashaData_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
        else
            this.SortDirection = "A";

        this.SortField = e.SortExpression;
        bindGrid();
    }

    protected void GVashaData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVashaData.PageIndex = e.NewPageIndex;
        bindGrid();
    }


    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        text_blank();
        lblMsgGrpmbr.Text = "";

        MpexdrBlock.Show();

        btnval = "Add";
        addlabel.Text = "Add ASHA";
        FillanmName();
    }

    protected void BtnSearch_Click1(object sender, EventArgs e)
    {
        string ashaname;
        string WhereQuery = "";
        string ashacode;
        lblmessage.Text = " ";

        ashacode = txt_ashacode.Text;
        ashaname = txtashaname.Text;


        if (ashacode != "")
        {
           // WhereQuery = "where t1.ASHACode=" + ashacode + "";
            WhereQuery = "where t1.ASHACode like '%"+ashacode+"%'";
        }

        if (ashaname != "")
        {
            if (WhereQuery == "")
            {
                //WhereQuery = "where t1.ASHAName='" + ashaname + "'";
                WhereQuery = "where t1.ASHAName like '%"+ashaname+"%'";
            }
            else
            {
               // WhereQuery = WhereQuery + "and t1.ASHAName='" + ashaname + "'";
                WhereQuery = WhereQuery + "and t1.ASHAName like '%"+ashaname+"%'";
            }
        }

        if (ashaname == "" && ashacode == "")
        {
            WhereQuery = "order by ASHAID";
        }


        DataTable dt = new DataTable();
        dt = objBLL.GetGroupsearchDataasha(WhereQuery);
        if (dt.Rows.Count > 0)
        {
        this.GVashaData.DataSource = dt;
        this.GVashaData.DataBind();
        }
        else
        {
        lblmessage.Text = "No Record Found.......";
        lblmessage.ForeColor = Color.Red;
        this.GVashaData.DataSource = null;
        this.GVashaData.DataBind();
        }

    }
}
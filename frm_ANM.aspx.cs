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


public partial class frm_ANM : System.Web.UI.Page
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
    dt = objBLL.GetGroupFilterDataanm();
    if (dt.Rows.Count > 0)
    {
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

    private void text_blank()
    {
    lblmessage.Text = "";
    txt_anmcode.Text = "";
    txtanmname.Text = "";
    txtanmNm.Text = "";
    txtanmNmhindi.Text = "";
    }

    #region "Insert Update and Delete Records Data"

    protected void TndrConfirmYes_Click1(object sender, EventArgs e)
    {
       DataTable dtdeleteanm = new DataTable();
      
       int anmid = Convert.ToInt32(Session["anmid"]);

       if (anmid > 0)
        {
            dtdeleteanm = objBLL.Getanmdelete(anmid);
        bindGrid();
        lblmessage.Text = "Deleted Successfully..";
        }
     
    }

    protected void Btnsave_Click1(object sender, EventArgs e)
    {
        int data;
        string name, namehindi;

        if (txtanmNm.Text != "")
        {
            name = txtanmNm.Text;
        }
        else
        {
            name = txtanmNm.Text;
        }

        if (txtanmNmhindi.Text != "")
        {
            namehindi = txtanmNmhindi.Text;
        }
        else
        {
            namehindi = txtanmNmhindi.Text;
        }


        int ID = Convert.ToInt32(Session["anmid"]);

        if (ID > 0)
        {
            ID = Convert.ToInt32(Session["anmid"]);
        }
        else
        {
            ID = 0;
        }

        if (btnval == "Add")
        {

            data = objBLL.insetupdatedate(name, namehindi,0,0, ID, "B", "I");
            if (data > 0)
            {
                bindGrid();
                lblmessage.Text = "Saved Successfully..";
                lblmessage.ForeColor = Color.Green;
            }
            else if (data == -11)
            {
                //  MpexdrBlock.Show(); lblMsgGrpmbr.Visible = true;
                lblMsgGrpmbr.Text = "ANM Name Already Exists!!";
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
            data = objBLL.insetupdatedate(name, namehindi, 0,0,ID, "B", "U");
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

    protected void GVanmData_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void GVanmData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblmessage.Text = "";
        dtRowData = new DataTable();
       DataTable dtRowData1 = new DataTable();
        if (e.CommandName == "EditCenter")
        {
            lblMsgGrpmbr.Text = "";
            int index = Convert.ToInt32(e.CommandArgument);
            btnval = "Update";
            addlabel.Text = "ANM";
            autoID = GVanmData.DataKeys[index].Values["ANMID"].ToString();
            Session["anmid"] = autoID; 
            dtRowData = objBLL.GetanmMstrRowData(autoID);
            dtRowData1 = objBLL.GetanmMstrRowData1(autoID);
            txtanmNm.Text = dtRowData.Rows[0]["ANMName"].ToString();
            txtanmNmhindi.Text = dtRowData1.Rows[0]["ANMName"].ToString();
            MpexdrBlock.Show();
        }
        else if ((e.CommandName == "DeleteCenter"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            btnval = "Delete";
            autoID = GVanmData.DataKeys[index].Values["ANMID"].ToString();
            Session["anmid"] = autoID;          
            MPDelBlock.Show();
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
        bindGrid();
    }


    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        text_blank();
        lblMsgGrpmbr.Text = "";
        MpexdrBlock.Show();
        btnval = "Add";
        addlabel.Text = "Add ANM";
        
    }

    protected void BtnSearch_Click1(object sender, EventArgs e)
    {
        string anmname;
        string WhereQuery = "";
        string anmcode;
        lblmessage.Text = " ";

        anmcode = txt_anmcode.Text;
        anmname = txtanmname.Text;

        if (anmcode != "")
        {
           // WhereQuery = "where t1.ANMCode=" + anmcode + "";
            WhereQuery = "where t1.ANMCode like '%"+anmcode+"%'";
        }

        if (anmname != "")
        {
            if (WhereQuery == "")
            {
               // WhereQuery = "where t1.ANMName='" + anmname + "'";
                WhereQuery = "where t1.ANMName like '%"+anmname+"%'";
            }
            else
            {
               // WhereQuery = WhereQuery + "and t1.ANMName='" + anmname + "'";
                WhereQuery = WhereQuery + "and t1.ANMName like '%"+anmname+"%'";
            }
        }

        if (anmname == "" && anmcode == "")
        {
            WhereQuery = "order by ANMID";
        }


        DataTable dt = new DataTable();
        dt = objBLL.GetGroupsearchDataanm(WhereQuery);
        if (dt.Rows.Count > 0)
        {
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
}
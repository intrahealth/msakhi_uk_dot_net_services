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


public partial class frm_center : System.Web.UI.Page
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
        dt = objBLL.GetGroupFilterDatacenter();
        if (dt.Rows.Count > 0)
        {        
            this.GVCenterData.DataSource = dt;
            this.GVCenterData.DataBind();       
        }
        else
        {
            lblmessage.Text = "No Record Found.......";
            lblmessage.ForeColor = Color.Red;
            this.GVCenterData.DataSource = null;
            this.GVCenterData.DataBind();
        }

    }

   
    private void text_blank()
    {
        lblmessage.Text = "";
        txt_code.Text = "";
        txtcentername.Text = "";
        txtCenterNm.Text = "";
        txtCenterNmhindi.Text = "";
    }

    #region "Insert Update and Delete Records Data"

    protected void TndrConfirmYes_Click1(object sender, EventArgs e)
    {
        DataTable dtdeleteanm = new DataTable();

        int centerid = Convert.ToInt32(Session["centerid"]);

        if (centerid > 0)
        {
            dtdeleteanm = objBLL.Getcenterdelete(centerid);
            bindGrid();
            lblmessage.Text = "Deleted Successfully..";
        }
    }

    protected void Btnsave_Click1(object sender, EventArgs e)
    {
        int data;
        string name,namehindi;

        if (txtCenterNm.Text != "")
        {
            name = txtCenterNm.Text;
        }
        else
        {
            name = txtCenterNm.Text;
        }

        if (txtCenterNmhindi.Text != "")
        {
            namehindi = txtCenterNmhindi.Text;
        }
        else
        {
            namehindi = txtCenterNmhindi.Text;
        }


        int ID = Convert.ToInt32(Session["centerid"]);

        if (ID > 0)
        {
            ID = Convert.ToInt32(Session["centerid"]);
        }
        else
        {
            ID = 0;
        }

        if (btnval == "Add")
        {

            data = objBLL.insetupdatedate(name, namehindi,0,0,ID,"C","I");
            if (data > 0)
            {
                bindGrid();
                lblmessage.Text = "Saved Successfully..";
                lblmessage.ForeColor = Color.Green;
            }
            else if (data == -11)
            {
                //  MpexdrBlock.Show(); lblMsgGrpmbr.Visible = true;
                lblMsgGrpmbr.Text = "Sub Center Name Already Exists!!";
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
            data = objBLL.insetupdatedate(name, namehindi,0,0,ID,"C","U");
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

    protected void GVCenterData_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void GVCenterData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblmessage.Text = "";
        dtRowData = new DataTable();
        DataTable dtRowData1 = new DataTable();
        if (e.CommandName == "EditCenter")
        {
        lblMsgGrpmbr.Text = "";
        int index = Convert.ToInt32(e.CommandArgument);
        btnval = "Update";
        addlabel.Text = "Center";
        autoID = GVCenterData.DataKeys[index].Values["SubCenterID"].ToString();
        Session["centerid"] = autoID;
        dtRowData = objBLL.GetcenterMstrRowData(autoID);
        dtRowData1 = objBLL.GetcenterMstrRowData1(autoID);
        txtCenterNm.Text = dtRowData.Rows[0]["SubCenterName"].ToString();
        txtCenterNmhindi.Text = dtRowData1.Rows[0]["SubCenterName"].ToString();
        MpexdrBlock.Show();
        }
        else if ((e.CommandName == "DeleteCenter"))
        {
        int index = Convert.ToInt32(e.CommandArgument);
        btnval = "Delete";
        autoID = GVCenterData.DataKeys[index].Values["SubCenterID"].ToString();
        Session["centerid"] = autoID;  
        MPDelBlock.Show();
        }
    }

    protected void GVCenterData_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
        else
            this.SortDirection = "A";

        this.SortField = e.SortExpression;
        bindGrid();
    }

    protected void GVCenterData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVCenterData.PageIndex = e.NewPageIndex;
        bindGrid();
    }

  
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        text_blank();
        lblMsgGrpmbr.Text = "";
       
        MpexdrBlock.Show();
       
        btnval = "Add";
        addlabel.Text = "Add Center";
      
    }
   
    protected void BtnSearch_Click1(object sender, EventArgs e)
    {
        string centername;
        string WhereQuery = "";
        string centercode;
        lblmessage.Text = " ";

        centercode = txt_code.Text;
        centername = txtcentername.Text;


        if (centercode != "")
        {
          //  WhereQuery = "where mstsubcenter.SubCenterCode=" + centercode + "";
            WhereQuery = "where t1.SubCenterCode like '%"+centercode+"%'";
        }

        if (centername != "")
        {
            if (WhereQuery == "")
            {
               // WhereQuery = "where mstsubcenter.SubCenterName='" + centername + "'";
                WhereQuery = "where t1.SubCenterName like '%"+centername+"%'";
            }
            else
            {
               // WhereQuery = WhereQuery + "and mstsubcenter.SubCenterName='" + centername + "'";
                WhereQuery = WhereQuery + "and t1.SubCenterName like '%"+centername+"%'";
            }
        }

        if (centername == "" && centercode == "")
        {
            WhereQuery = "order by SubCenterID";
        }
      
        
        DataTable dt = new DataTable();
        dt = objBLL.GetGroupsearchDatacenter(WhereQuery);
        if (dt.Rows.Count > 0)
        {

            this.GVCenterData.DataSource = dt;
            this.GVCenterData.DataBind();

        }
        else
        {
            lblmessage.Text = "No Record Found.......";
            lblmessage.ForeColor = Color.Red;
            this.GVCenterData.DataSource = null;
            this.GVCenterData.DataBind();
        }
      
    }
}
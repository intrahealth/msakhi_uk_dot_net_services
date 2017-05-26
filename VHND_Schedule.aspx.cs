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

public partial class VHND_Schedule : System.Web.UI.Page
{
    BllLibrary objBLL = new BllLibrary();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessage.Text = "";
        if (IsPostBack == false)
        {
            Fillsubcenter();
            YearComboFill();
        }
    }


    public void YearComboFill()
    {
        int fillYear = DateTime.Now.Year;
        for (int i = fillYear; i >= fillYear - 1; i--)
        {
            string num = Convert.ToString(i);
            ddlyear.Items.Add(new ListItem(num));
            ddlyear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected
        }
    }

    private void Fillsubcenter()
    {
        DataTable dtSubcenter = new DataTable();
        dtSubcenter = objBLL.Getsubcenter();
        Session["subcenter"] = dtSubcenter;
        ddlsubcenter.DataValueField = "SubCenterCode";
        ddlsubcenter.DataTextField = "SubCenterName";
        ddlsubcenter.DataSource = dtSubcenter;
        ddlsubcenter.DataBind();
        ddlsubcenter.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
    }


    protected void ddlsubcenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtSelectanm = new DataTable();
        dtSelectanm = objBLL.GetSelectcenteranm(ddlsubcenter.SelectedValue);
        Session["anm"] = dtSelectanm;
        ddlanm.DataValueField = "AnmId";
        ddlanm.DataTextField = "AnmName";
        ddlanm.DataSource = dtSelectanm;
        ddlanm.DataBind();
        ddlanm.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---Select---", ""));
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

    protected void GVVHND_Sorting(object sender, GridViewSortEventArgs e)
    {
    if (e.SortExpression.Trim() == this.SortField)
    this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
    else
    this.SortDirection = "A";
    this.SortField = e.SortExpression;
    Btnshow_Click(sender, e); 
    }
    

    protected void GVVHND_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    GVVHND.PageIndex = e.NewPageIndex;  
    Btnshow_Click(sender, e);    
    }


    protected void btnprevyear_Click(object sender, EventArgs e)
    {
        int data;
        DataTable dtvhnd = new DataTable();
        dtvhnd = objBLL.Selectvhnd();
        if (dtvhnd.Rows.Count > 0)
        {
            data = objBLL.insertvhndprev(dtvhnd);
            if (data > 0)
            {
                lblmessage.Text = "Generated Successfully..";
                lblmessage.ForeColor = Color.Green;
            }
            else if (data == -11)
            {
                lblmessage.Text = "VHND micro plan also availabe for current year!!";
                lblmessage.ForeColor = Color.Red;
            } 
        } 
    }

    protected void Btnshow_Click(object sender, EventArgs e)
    {
        lblcount.Text = "0";
        string WhereQuery = "", year = "", subcenter = "", anm = "";

        if (ddlyear.SelectedValue == "" || ddlanm.SelectedValue == "")
        {
            lblmessage.Text = "Please Select Year,SubCenter,Anm ";
        }

        else
        {
           if (ddlyear.SelectedValue != "")
            {
            year = ddlyear.SelectedValue;
            WhereQuery = "and year =" + year + " ";
            }


            if (ddlanm.SelectedValue != "")
            {
            anm = ddlanm.SelectedValue;
            WhereQuery = WhereQuery + "and anm_id =" + anm + " ";
            }

            lblmessage.Text = " ";

            DataTable dt = new DataTable();
            dt = objBLL.getdatavhnd(WhereQuery, "S");
            if (dt.Rows.Count > 0)
            {
            lblcount.Text = dt.Rows.Count.ToString();
            this.GVVHND.DataSource = dt;
            this.GVVHND.DataBind();
            }
            else
            {
            lblmessage.Text = "No Record Found Please Generate VHND Micro Plan Firstly";
            lblmessage.ForeColor = Color.Red;
            this.GVVHND.DataSource = null;
            this.GVVHND.DataBind();
            }
        }
    }


    protected void Btngenerate_Click(object sender, EventArgs e)
    {
        SqlDateTime jan = SqlDateTime.Null, feb = SqlDateTime.Null, mar = SqlDateTime.Null, apr = SqlDateTime.Null, may = SqlDateTime.Null, jun = SqlDateTime.Null,
        jul = SqlDateTime.Null, aug = SqlDateTime.Null, sep = SqlDateTime.Null, oct = SqlDateTime.Null, nov = SqlDateTime.Null, dec = SqlDateTime.Null;
        string WhereQuery = "", year = "", occurence = "", days = "",village = "";
        int id = 0;
        DataTable dt = new DataTable();
        for (int i = 0; i < GVVHND.Rows.Count; i++)
        {
            year = ddlyear.SelectedValue;
            occurence = ((DropDownList)GVVHND.Rows[i].Cells[2].FindControl("ddlOccurence")).SelectedValue == "" ? "" : ((DropDownList)GVVHND.Rows[i].Cells[7].FindControl("ddlOccurence")).SelectedValue;
            days = ((DropDownList)GVVHND.Rows[i].Cells[2].FindControl("ddlDays")).SelectedValue == "" ? "" : ((DropDownList)GVVHND.Rows[i].Cells[7].FindControl("ddlDays")).SelectedValue;
            village = ((DropDownList)GVVHND.Rows[i].Cells[2].FindControl("ddlvillage")).SelectedValue == "" ? "" : ((DropDownList)GVVHND.Rows[i].Cells[7].FindControl("ddlvillage")).SelectedValue;
           
            if (!string.IsNullOrEmpty(((Label)GVVHND.Rows[i].Cells[2].FindControl("lblSchedule_Id")).Text))
                id = Convert.ToInt32(((Label)GVVHND.Rows[i].Cells[2].FindControl("lblSchedule_Id")).Text);

            if (days != "" && occurence != "" && village != "")
            {
                dt = objBLL.getdatavhndinser(year, occurence, days);

                jan = Convert.ToDateTime(dt.Rows[11]["dyear"]);
                feb = Convert.ToDateTime(dt.Rows[10]["dyear"]);
                mar = Convert.ToDateTime(dt.Rows[9]["dyear"]);
                apr = Convert.ToDateTime(dt.Rows[0]["dyear"]);
                may = Convert.ToDateTime(dt.Rows[1]["dyear"]);
                jun = Convert.ToDateTime(dt.Rows[2]["dyear"]);
                jul = Convert.ToDateTime(dt.Rows[3]["dyear"]);
                aug = Convert.ToDateTime(dt.Rows[4]["dyear"]);
                sep = Convert.ToDateTime(dt.Rows[5]["dyear"]);
                oct = Convert.ToDateTime(dt.Rows[6]["dyear"]);
                nov = Convert.ToDateTime(dt.Rows[7]["dyear"]);
                dec = Convert.ToDateTime(dt.Rows[8]["dyear"]);

                int save;
                save = objBLL.insertvhndschedule(jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec, id, village, days, occurence);
            }

        }
        Btnshow_Click(sender, e);
       
    }


    protected void GVVHND_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
    }


    protected void GVVHND_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        GridViewRow dr = e.Row as GridViewRow;
        DropDownList ddlVillage = (DropDownList)dr.FindControl("ddlVillage");
        int ashaid = Convert.ToInt32(GVVHND.DataKeys[dr.RowIndex].Values[1].ToString());
        ddlVillage.DataSource = objBLL.Getvillage(ashaid);
        ddlVillage.DataTextField = "VillageName";
        ddlVillage.DataValueField = "VillageID";
        ddlVillage.DataBind();
        ddlVillage.SelectedValue = GVVHND.DataKeys[Convert.ToInt32(dr.RowIndex)].Value.ToString();
        }
    }


}
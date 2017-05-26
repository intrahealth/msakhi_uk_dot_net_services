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

public partial class DataReport : System.Web.UI.Page
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
        DataTable dt2 = new DataTable() ;
        DataTable dt3 = new DataTable() ;
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
       
        DataSet ds = new DataSet();
        ds = objBLL.getdatareport();

        dt = ds.Tables[0];
        dt2 = ds.Tables[1];
        dt3 = ds.Tables[2];
        dt4 = ds.Tables[3];
        dt5 = ds.Tables[4];
        dt6 = ds.Tables[5];

        foreach (DataRow dr in dt2.Rows)
        {
            DataRow[] dr1 = dt.Select("ashaid=" + dr["ashaid"] + " and month='" + dr["month"] + "'");
            if (dr1.Length > 0)
            {
                dr1[0]["Pregnent"] = dr["Pregnent"].ToString();              
            }
        }

        foreach (DataRow dr in dt3.Rows)
        {
        DataRow[] dr1 = dt.Select("ashaid=" + dr["ashaid"] + " and month='" + dr["month"] + "'");
        if (dr1.Length > 0)
        {
            dr1[0]["anccount"] = dr["anccount"].ToString();
        }
        }

        foreach (DataRow dr in dt4.Rows)
        {
            DataRow[] dr1 = dt.Select("ashaid=" + dr["ashaid"] + " and month='" + dr["month"] + "'");
            if (dr1.Length > 0)
            {
                dr1[0]["deliveries"] = dr["deliveries"].ToString();
            }
        }


        foreach (DataRow dr in dt5.Rows)
        {
            DataRow[] dr1 = dt.Select("ashaid=" + dr["ashaid"] + " and month='" + dr["month"] + "'");
            if (dr1.Length > 0)
            {
                dr1[0]["pnc"] = dr["pnc"].ToString();
            }
        }


        foreach (DataRow dr in dt6.Rows)
        {
            DataRow[] dr1 = dt.Select("ashaid=" + dr["ashaid"] + " and month='" + dr["month"] + "'");
            if (dr1.Length > 0)
            {
                dr1[0]["immunization"] = dr["immunization"].ToString();
            }
        }

        if (dt.Rows.Count > 0)
        {
        lblcount.Text = dt.Rows.Count.ToString();
        this.GVreportData.DataSource = dt;
        this.GVreportData.DataBind();
        Session["dt"] = dt.Copy();
        }
        else
        {
        lblmessage.Text = "No Record Found.......";
        lblmessage.ForeColor = Color.Red;
        this.GVreportData.DataSource = null;
        this.GVreportData.DataBind();
        }
    }


    protected void GVreportData_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Trim() == this.SortField)
            this.SortDirection = (this.SortDirection == "D" ? "A" : "D");
        else
            this.SortDirection = "A";
        this.SortField = e.SortExpression;
        bindGrid();
    }


    protected void GVreportData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVreportData.PageIndex = e.NewPageIndex;
        bindGrid();
    }


  protected void GVreportData_RowDataBound(object sender, GridViewRowEventArgs e)
  {

    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        string verify = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Month"));
        if (verify == "mar")
        {
         e.Row.Cells[1].Text = "";
         e.Row.Cells[2].Text = "";
         e.Row.Cells[3].Text = "";
        }
    }
  }

    protected void BtnExport_Click(object sender, EventArgs e)
    {
        ExporttoExcel(GVreportData, Session["dt"] as DataTable, "Data");
    }
       
        private void ExporttoExcel(GridView Gv, DataTable table, string FileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            string Fullfilename = "" + FileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".xls";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Fullfilename + " ");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers
           // int columnscount = GVreportData.HeaderRow.Cells.Count;

            for (int j = 0; j < table.Columns.Count; j++)
            {      //write in new column
            HttpContext.Current.Response.Write("<Td>");
            //Get column headers  and make it as bold in excel columns
            HttpContext.Current.Response.Write("<B>");
            HttpContext.Current.Response.Write(table.Columns[j].ColumnName);
            HttpContext.Current.Response.Write("</B>");
            HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {//write in new row
            HttpContext.Current.Response.Write("<TR>");
            for (int i = 0; i < table.Columns.Count; i++)
            {
            HttpContext.Current.Response.Write("<Td>");
            HttpContext.Current.Response.Write(row[i].ToString());
            HttpContext.Current.Response.Write("</Td>");
            }

            HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

 

}
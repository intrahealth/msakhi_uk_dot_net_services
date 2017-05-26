using System;
using System.Web.UI;
using BusinessLogicLayer;

public partial class PIA_PISMasterPage : System.Web.UI.MasterPage
{
    BllLibrary objBLL = new BllLibrary();
    protected void Page_Load(object sender, EventArgs e)
    {
        //objBLL.Check_PIA_Session();
        Request.Browser.Adapters.Clear();
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        if (scriptManager != null && scriptManager.IsInAsyncPostBack)
        {
            //Do something
        }

        if (!IsPostBack)
        {
            //lblPIAName.Text = Session["PIAName"].ToString();
            // CreateMasterTab(string.Empty, new MenuItem());
        }
    }
}

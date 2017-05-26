using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }
    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(LoginUser.UserName, LoginUser.Password))
        {
            FormsAuthentication.SetAuthCookie(LoginUser.UserName, true);
            HttpCookie cc= FormsAuthentication.GetAuthCookie(LoginUser.UserName, true);
            //Response.Redirect("~/AuthWebService.asmx");
        }
    }
}

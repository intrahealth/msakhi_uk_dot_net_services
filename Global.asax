<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        
        //if (Response.Cookies.Count > 0)
        //{
        //    foreach (string s in Response.Cookies.AllKeys)
        //    {
        //        if (s == FormsAuthentication.FormsCookieName || s.ToLower() == "asp.net_sessionid")
        //        {
        //            Response.Cookies[s].Secure = true;
        //        }
        //    }
        //}
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        //if (Response.Cookies.Count > 0)
        //{
        //    foreach (string s in Response.Cookies.AllKeys)
        //    {
        //        if (s == FormsAuthentication.FormsCookieName || s.ToLower() == "asp.net_sessionid")
        //        {
        //            Response.Cookies[s].Secure = true;
        //        }
        //    }
        //}

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        //if (Response.Cookies.Count > 0)
        //{
        //    foreach (string s in Response.Cookies.AllKeys)
        //    {
        //        if (s == FormsAuthentication.FormsCookieName || s.ToLower() == "asp.net_sessionid")
        //        {
        //            Response.Cookies[s].Secure = true;
        //        }
        //    }
        //}
    }
       
    
</script>

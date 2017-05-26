using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
     LoginToDatrose(txtUserName.Text, txtPWD.Text);
    }

    public void LoginToDatrose(string Username, string password)
    {
        Username = Username.Trim();
        password = password.Trim();
        HttpWebRequest webRequest = WebRequest.Create("http://localhost:50995/WebAuthService/Account/Login.aspx?PageModule=UsersAction&Action=UserLogin") as HttpWebRequest;
        StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
        string responseData = responseReader.ReadToEnd();
        responseReader.Close();

        // extract the viewstate value and build out POST data
        string viewState = ExtractViewState(responseData);
        string postData =
              String.Format(
                 "__VIEWSTATE={0}&ctl00$MainContent$LoginUser$UserName={1}&ctl00$MainContent$LoginUser$Password={2}&ctl00$MainContent$LoginUser$LoginButton=Log In",
                 viewState, Username, password
              );

        // have a cookie container ready to receive the forms auth cookie
        CookieContainer cookies = new CookieContainer();
        try
        {
            // now post to the login form
            webRequest = WebRequest.Create("http://localhost:50995/WebAuthService/Account/Login.aspx?PageModule=UsersAction&Action=UserLogin") as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;

            // write the form values into the request message
            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();

            // we don't need the contents of the response, just the cookie it issues
            webRequest.GetResponse().Close();
        }
        catch (WebException e)
        {
            string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();

        }
        //now make the web service call and pass the auth cookies in the header
        WebService ww = new WebService("http://localhost:50995/WebAuthService/AuthWebService.asmx", "Abhishek", cookies);
        ww.Params.Add("a", "Abhishek");
        ww.Params.Add("b", @"How you doing today");
        ww.Invoke();

        // now we can send out cookie along with a request for the protected page
        //webRequest = WebRequest.Create("http://localhost:50995/WebAuthService/AuthWebService.asmx") as HttpWebRequest;
        //webRequest.CookieContainer = cookies;
        //responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());

        //// and read the response
        //responseData = responseReader.ReadToEnd();
        //responseReader.Close();

        //Response.Write(responseData); 

    }

    private string ExtractViewState(string s)
    {
        string viewStateNameDelimiter = "__VIEWSTATE";
        string valueDelimiter = "value=\"";

        int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
        int viewStateValuePosition = s.IndexOf(
              valueDelimiter, viewStateNamePosition
           );
        
        int viewStateStartPosition = viewStateValuePosition +
                                     valueDelimiter.Length;
        int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

        return HttpUtility.UrlEncodeUnicode(
                 s.Substring(
                    viewStateStartPosition,
                    viewStateEndPosition - viewStateStartPosition
                 )
              );
    }

    public class WebService
    {
        public string Url { get; set; }
        public string MethodName { get; set; }
        public CookieContainer cc { get; set; }
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        public XDocument ResultXML;
        public string ResultString;

        public WebService()
        {

        }

        public WebService(string url, string methodName, CookieContainer Cookie)
        {
            Url = url;
            MethodName = methodName;
            cc = Cookie;

        }

        /// <summary>
        /// Invokes service
        /// </summary>
        public void Invoke()
        {
            Invoke(true);
        }

        /// <summary>
        /// Invokes service
        /// </summary>
        /// <param name="encode">Added parameters will encode? (default: true)</param>
        public void Invoke(bool encode)
        {
            string soapStr =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
               xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
              <soap:Body>
                <{0} xmlns=""http://tempuri.org/"">
                  {1}
                </{0}>
              </soap:Body>
            </soap:Envelope>";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
            req.CookieContainer = new CookieContainer();
            req.CookieContainer = cc;
            req.Headers.Add("SOAPAction", "\"http://tempuri.org/" + MethodName + "\"");
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";

            using (Stream stm = req.GetRequestStream())
            {
                string postValues = "";
                foreach (var param in Params)
                {
                    if (encode)
                        postValues += string.Format("<{0}>{1}</{0}>", HttpUtility.UrlEncode(param.Key), HttpUtility.UrlEncode(param.Value));
                    else
                        postValues += string.Format("<{0}>{1}</{0}>", param.Key, param.Value);
                }

                soapStr = string.Format(soapStr, MethodName, postValues);
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(soapStr);
                }
            }

            using (StreamReader responseReader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                string result = responseReader.ReadToEnd();
                ResultXML = XDocument.Parse(result);
                ResultString = result;
            }
        }
    }
}
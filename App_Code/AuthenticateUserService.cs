using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using System.Xml;


/// <summary>
/// Summary description for AuthenticateUserService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AuthenticateUserService : System.Web.Services.WebService
{
    AndroidDBTask DBTask = new AndroidDBTask();

    public AuthenticateUserService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string LoginAuthentication(string User, string Password)
    {
        string cookie = string.Empty;
        if (Login_User(User, Password))
        {
            string BasicURL = Convert.ToString(ConfigurationManager.AppSettings["BasicURL"]);
            HttpWebRequest webRequest = WebRequest.Create(BasicURL + "?PageModule=UsersAction&Action=UserLogin") as HttpWebRequest;
            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = ExtractViewState(responseData);
            string viewStateGenerator = ExtractViewStateGenerator(responseData);
            // string viewStateEventValidation = ExtractEventValidation(responseData);
            string postData =
                  String.Format(
                     "__VIEWSTATE={0}&__VIEWSTATEGENERATOR={1}&txt_uid={2}&txt_pwd={3}&tbn_login=Sign-In",
                     viewState, viewStateGenerator, User, Password
                  );

            // have a cookie container ready to receive the forms auth cookie
            CookieContainer cookies = new CookieContainer();
            try
            {
                webRequest = WebRequest.Create(BasicURL + "?PageModule=UsersAction&Action=UserLogin") as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.CookieContainer = cookies;

                // write the form values into the request message
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postData);
                requestWriter.Close();

                // we don't need the contents of the response, just the cookie it issues
                webRequest.GetResponse().Close();
                Dictionary<string, string> cc = new Dictionary<string, string>();
                foreach (Cookie c in cookies.GetCookies(webRequest.RequestUri))
                {
                    if (c.Name.ToUpper().Contains(".ASPXAUTH"))
                    {
                        cookie = string.Format("Name={0}, Value={1}", c.Name, c.Value);
                        Session["AuthCookie"] = c.Value;

                    }
                    //if (c.Name.Contains("ASP.NET_SessionId"))
                    //{
                    //    cookie = string.Format("Name={0}, Value={1}", c.Name, c.Value);
                    //}

                }

                return cookie;
            }
            catch (WebException e)
            {
                string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
                throw e;

            }
        }
        else
        {
            return null;
        }
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

    private string ExtractViewStateGenerator(string s)
    {
        string viewStateNameDelimiter = "__VIEWSTATEGENERATOR";
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

    public bool Login_User(string User, string Password)
    {
        try
        {
            //lbl_msg.Text = "";
            SqlParameter[] pr = new SqlParameter[] { 
        new SqlParameter("@Userid",User.Trim()),
         new SqlParameter("@Password",Password.Trim()),
        };
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.mainConnectionString, CommandType.StoredProcedure, "Pub_Get_UserLogin_data", pr);
            if (dt.Rows.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(User), true);
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string GetMasterData(string sFlag, string AuthenticationToken, string UserName, string PassWord)
    {
        //string AuthString = Convert.ToString(Session["AuthCookie"]);
        string sReturn = string.Empty;
        //if (AuthString.Equals(AuthenticationToken))
        //{
        int UserID = 0, ashaid = 0;

            DataTable dtUser = new DataTable();

            if (UserName.Trim() != "" && PassWord.Trim() != "")
            {
                SqlParameter[] paramsToStore = new SqlParameter[]
                    {
                    new SqlParameter("@UserID",UserName.Trim()), 
                    new SqlParameter("@Password",PassWord.Trim()), 
                    };
                dtUser = SqlHelper.GetDataSet(SqlHelper.mainConnectionString, CommandType.StoredProcedure, "Sp_Get_UserLogin_data", paramsToStore).Tables[0];

                if (dtUser.Rows.Count > 0)
                {
                    UserID = Convert.ToInt32(dtUser.Rows[0]["UserUId"].ToString());
                }
            }
            if (dtUser.Rows.Count > 0)
            {

                try
                {
                    DataSet dtExportData = new DataSet();
                    string StrWhr = "";

                    dtExportData = DBTask.GetMasterData(sFlag, UserID,ashaid);

                    DataSet dsMyData = new DataSet("MyData");
                    int index = 0;
                    foreach (DataTable dt in dtExportData.Tables)
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = dt.Copy();
                        dtNew.TableName = GetTableName(index, sFlag);
                        dsMyData.Tables.Add(dtNew);
                        index++;
                    }
                    sReturn = JsonConvert.SerializeObject(dsMyData);
                }

                catch (Exception ex)
                {
                    sReturn = "9999";
                }
            }
            else
            {
                sReturn = "UserID And PassWord Does not Exist";
            }
        //}
        //else
        //{
        //    sReturn = "Invalid Token";
        //}
        return sReturn;
    }

    private string GetTableName(int index, string sType)
    {
        string tablename = string.Empty;
        if (sType == "Master")
        {
            switch (index)
            {
                case 0:
                    tablename = "aspnet_Users";
                    break;
                case 1:
                    tablename = "aspnet_Role";
                    break;
                case 2:
                    tablename = "Mststate";
                    break;
                case 3:
                    tablename = "MSTDistrict";
                    break;
                case 4:
                    tablename = "MSTBlock";
                    break;
                case 5:
                    tablename = "MstPanchayat";
                    break;
                case 6:
                    tablename = "MstVillage";
                    break;
                case 7:
                    tablename = "MstCommon";
                    break;
                case 8:
                    tablename = "MstASHA";
                    break;
                case 9:
                    tablename = "MstANM";
                    break;
                case 10:
                    tablename = "MstSubcenter";
                    break;
                case 11:
                    tablename = "NoName1";
                    break;
                case 12:
                    tablename = "NoName2";
                    break;
                case 13:
                    tablename = "NoName3";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }
        else if (sType == "Data")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblHHSurvey";
                    break;
                case 1:
                    tablename = "tblHHFamilyMember";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }
        return tablename;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string PostData(string sData, string AuthenticationToken)
    {
        string sReturn = string.Empty;
        string AuthString = Convert.ToString(Session["AuthCookie"]);
        if (AuthString.Equals(AuthenticationToken))
        {
            try
            {
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);

                dsMyData.ReadXml(new XmlNodeReader(xdMyData));


                if (dsMyData.Tables.Count <= 2)
                {
                    DataTable tblHHFamilyMember = DBTask.CreateDataTable("tblHHFamilyMemberType");
                    DataTable tblHHSurvey = DBTask.CreateDataTable("tblHHSurveyType");

                    if ((dsMyData.Tables["tbl_HHFamilyMember"] != null) && (dsMyData.Tables["tbl_HHFamilyMember"].Rows.Count > 0))
                    {
                        tblHHFamilyMember = SetColumnsOrdinal(dsMyData.Tables["tbl_HHFamilyMember"], tblHHFamilyMember);
                    }
                    if ((dsMyData.Tables["tbl_HHSurvey"] != null) && (dsMyData.Tables["tbl_HHSurvey"].Rows.Count > 0))
                    {
                        tblHHSurvey = SetColumnsOrdinal(dsMyData.Tables["tbl_HHSurvey"], tblHHSurvey);
                    }

                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_HHData(tblHHFamilyMember, tblHHSurvey, sData, 1);

                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "9999";
                }
            }
            catch (Exception ex)
            {
            }
            return sReturn;
        }
        else
        {
            sReturn = "Invalid Token";
        }
        return sReturn;
    }

    private DataTable SetColumnsOrdinal(DataTable dtData, DataTable dtCols)
    {
        try
        {
            List<string> list = new List<string>();
            foreach (DataColumn colName in dtData.Columns)
            {
                list.Add(colName.ToString());
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (!dtCols.Columns.Contains(list[i].ToString()))
                {
                    dtData.Columns.Remove(list[i].ToString());
                }
            }

            for (int i = 0; i < dtCols.Columns.Count; i++)
            {
                dtData.Columns[dtCols.Columns[i].ToString()].SetOrdinal(i);
            }
        }
        catch (Exception ex)
        {

        }
        return dtData;
    }

    private DataSet ToDataSet(string[] input)
    {
        DataSet dataSet = new DataSet();
        DataTable dataTable = dataSet.Tables.Add();
        dataTable.Columns.Add("ImageName");
        Array.ForEach(input, c => dataTable.Rows.Add()[0] = Path.GetFileName(c));
        return dataSet;
    }

}

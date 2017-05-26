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
/// Summary description for ExportWebServices
/// </summary>
   [WebService(Namespace = "http://tempuri.org/")]
   [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
   public class ExportWebServices : System.Web.Services.WebService
   {
    AndroidDBTask DBTask = new AndroidDBTask();

    public ExportWebServices()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string GetMasterData(string sFlag, string AuthenticationToken, string UserName, string PassWord)
    {
        string AuthString = Convert.ToString(Session["AuthCookie"]);
        string sReturn = string.Empty;
        int ashaid = 0;
        if (AuthenticationToken != "")
        {
            try
            {
                ashaid = Convert.ToInt32(AuthenticationToken);
            }
            catch
            {
                ashaid = 0;
            }
        }
        int UserID = 0;
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
                    dtNew.Rows.Count.ToString();
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
        return sReturn;
    }


    [System.Web.Services.WebMethod(EnableSession = true)]
    public string GetMasterFullData(string sFlag, string AuthenticationToken, string UserName, string PassWord)
    {
        string AuthString = Convert.ToString(Session["AuthCookie"]);
        string sReturn = string.Empty;
        int ashaid = 0;
        if (AuthenticationToken != "")
        {
            try
            {
                ashaid = Convert.ToInt32(AuthenticationToken);
            }
            catch
            {
                ashaid = 0;
            }
        }
        int UserID = 0;
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
                dtExportData = DBTask.GetMasterFullData(sFlag, UserID, ashaid);
                DataSet dsMyData = new DataSet("MyData");
                int index = 0;
                foreach (DataTable dt in dtExportData.Tables)
                {
                DataTable dtNew = new DataTable();
                dtNew = dt.Copy();
                dtNew.TableName = GetTableNameFull(index, sFlag);
                dsMyData.Tables.Add(dtNew);
                index++;
                dtNew.Rows.Count.ToString();
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
                    tablename = "MstPHC";
                    break;
                case 12:
                    tablename = "MstSubCenterVillageMapping";
                    break;
                case 13:
                    tablename = "MstCatchmentArea";
                    break;
                case 14:
                    tablename = "MstCatchmentSupervisor";
                    break;
                case 15:
                    tablename = "tbl_Incentive";
                    break;
                case 16:
                    tablename = "MstVHND_PerformanceIndicator";
                    break;
                case 17:
                    tablename = "MstVHND_DueListItems";
                    break;
                case 18:
                    tablename = "VHND_Schedule";
                    break;
                case 19:
                    tablename = "MstVersion";
                    break;
                case 20:
                    tablename = "MstVersionTrack";
                    break;
                default:
                    tablename = "NoName1";
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
                case 2:
                    tablename = "tblMigration";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "MNCH")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblPregnant_woman";
                    break;
                case 1:
                    tablename = "tblChild";
                    break;
                case 2:
                    tablename = "tblANCVisit";
                    break;
                case 3:
                    tablename = "tbl_DatesEd";
                    break;

                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "counseling")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblmstFPQues";
                    break;
                case 1:
                    tablename = "tblmstANCQues";
                    break;
                case 2:
                    tablename = "tblmstimmunizationQues";
                    break;
                case 3:
                    tablename = "tblmstPNCQues";
                    break;
                case 4:
                    tablename = "tblPNChomevisit_ANS";
                    break;

                case 5:
                    tablename = "tblmstimmunizationANS";
                    break;

                case 6:
                    tablename = "tblmstFPAns";
                    break;

                case 7:
                    tablename = "tblmstFPFDetail";
                    break;

                default:
                    tablename = "NoName";
                    break;
            }
        }
        return tablename;
    }

    private string GetTableNameFull(int index, string sType)
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
                    tablename = "MstPHC";
                    break;
                case 12:
                    tablename = "MstSubCenterVillageMapping";
                    break;
                case 13:
                    tablename = "MstCatchmentArea";
                    break;
                case 14:
                    tablename = "MstCatchmentSupervisor";
                    break;
                case 15:
                    tablename = "tbl_Incentive";
                    break;
                case 16:
                    tablename = "MstVHND_PerformanceIndicator";
                    break;
                case 17:
                    tablename = "MstVHND_DueListItems";
                    break;
                case 18:
                    tablename = "VHND_Schedule";
                    break;
                case 19:
                    tablename = "MstVersion";
                    break;
                case 20:
                    tablename = "MstVersionTrack";
                    break;
                default:
                    tablename = "NoName1";
                    break;
            }
        }

        else if (sType == "tblHHSurvey")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblHHSurvey";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "tblHHFamilyMember")
        {
            switch (index)
            {
                
                case 0:
                    tablename = "tblHHFamilyMember";
                    break;
                
                default:
                    tablename = "NoName";
                    break;
            }
        }


        else if (sType == "tblMigration")
        {
            switch (index)
            {
               case 0:
                    tablename = "tblMigration";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "tblPregnant_woman")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblPregnant_woman";
                    break;
               default:
                    tablename = "NoName";
                    break;
            }
        }

         else if (sType == "tblChild")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblChild";
                     break;
                     default:
                    tablename = "NoName";
                    break;
            }
         }
                
         else if (sType == "tblANCVisit")
        {
              switch (index)
            {
                case 0:
                    tablename = "tblANCVisit";
                    break;
               default:
                    tablename = "NoName";
                    break;

         }
    }

        else if (sType == "tbl_DatesEd")
        {
            switch (index)
            {
                case 0:
                    tablename = "tbl_DatesEd";
                    break;

                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "Questions")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblmstFPQues";
                    break;
               
                case 1:
                    tablename = "tblmstANCQues";
                    break;
               case 2:
                    tablename = "tblmstimmunizationQues";
                    break;
                case 3:
                    tablename = "tblmstPNCQues";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "tblPNChomevisit_ANS")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblPNChomevisit_ANS";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "tblmstimmunizationANS")
        {
            switch (index)
            {

                case 0:
                    tablename = "tblmstimmunizationANS";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }           
        }

        else if (sType == "tblmstFPAns")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblmstFPAns";
                    break;
                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "tblmstFPFDetail")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblmstFPFDetail";
                    break;

                default:
                    tablename = "NoName";
                    break;
            }
        }  

        else if (sType == "tbl_VHNDPerformance")
        {
            switch (index)
            {
                case 0:
                    tablename = "tbl_VHNDPerformance";
                    break;

                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "tblVHNDDueList")
        {
            switch (index)
            {
                case 0:
                    tablename = "tblVHNDDueList";
                    break;

                default:
                    tablename = "NoName";
                    break;
            }
        }

        else if (sType == "tbl_VHND_DueList")
        {
            switch (index)
            {
                case 0:
                    tablename = "tbl_VHND_DueList";
                    break;

                default:
                    tablename = "NoName";
                    break;
            }
        }


        return tablename;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string MNCHUploadServices(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 3)
                {
                    DataTable tblpregnant_woman = DBTask.CreateDataTable("tblpregnant_womanType");  // tblpregnant_womanType - this is table type
                    DataTable tblchild = DBTask.CreateDataTable("tblchildType");
                    DataTable tblANCVisit = DBTask.CreateDataTable("tblANC_visitstype");
                    if ((dsMyData.Tables["tbl_pregnantwomen"] != null) && (dsMyData.Tables["tbl_pregnantwomen"].Rows.Count > 0)) //tblpregnant_woman - this is a dataset(dsMyData) table name
                    {
                        tblpregnant_woman = SetColumnsOrdinal(dsMyData.Tables["tbl_pregnantwomen"], tblpregnant_woman);
                    }
                    if ((dsMyData.Tables["tblchild"] != null) && (dsMyData.Tables["tblchild"].Rows.Count > 0))
                    {
                        tblchild = SetColumnsOrdinal(dsMyData.Tables["tblchild"], tblchild);
                    }
                    if ((dsMyData.Tables["tbl_ANCvisit"] != null) && (dsMyData.Tables["tbl_ANCvisit"].Rows.Count > 0))
                    {
                        tblANCVisit = SetColumnsOrdinal(dsMyData.Tables["tbl_ANCvisit"], tblANCVisit);
                    }
                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_MNCHData(tblpregnant_woman, tblchild, tblANCVisit, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;

            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string MNCHUploadServices_V501(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 5)
                {
                    DataTable tblpregnant_woman = DBTask.CreateDataTable("tblpregnant_womanType_V501");  // tblpregnant_womanType - this is table type
                    DataTable tblchild = DBTask.CreateDataTable("tblchildType_V501");
                    DataTable tblANCVisit = DBTask.CreateDataTable("tblANC_visitstype_V501");
                    DataTable tblDatesEd = DBTask.CreateDataTable("tbl_DatesEdType_V501");
                    DataTable tblhhupdate = DBTask.CreateDataTable("tblhhupdate_Log_V501");

                    if ((dsMyData.Tables["tbl_pregnantwomen"] != null) && (dsMyData.Tables["tbl_pregnantwomen"].Rows.Count > 0))
                    {
                        tblpregnant_woman = SetColumnsOrdinal(dsMyData.Tables["tbl_pregnantwomen"], tblpregnant_woman);
                    }
                    if ((dsMyData.Tables["tblchild"] != null) && (dsMyData.Tables["tblchild"].Rows.Count > 0))
                    {
                        tblchild = SetColumnsOrdinal(dsMyData.Tables["tblchild"], tblchild);
                    }
                    if ((dsMyData.Tables["tbl_ANCvisit"] != null) && (dsMyData.Tables["tbl_ANCvisit"].Rows.Count > 0))
                    {
                        tblANCVisit = SetColumnsOrdinal(dsMyData.Tables["tbl_ANCvisit"], tblANCVisit);
                    }
                    if ((dsMyData.Tables["tbl_DatesEd"] != null) && (dsMyData.Tables["tbl_DatesEd"].Rows.Count > 0))
                    {
                        tblDatesEd = SetColumnsOrdinal(dsMyData.Tables["tbl_DatesEd"], tblDatesEd);
                    }
                    if ((dsMyData.Tables["tblhhupdate_Log"] != null) && (dsMyData.Tables["tblhhupdate_Log"].Rows.Count > 0))
                    {
                        tblhhupdate = SetColumnsOrdinal(dsMyData.Tables["tblhhupdate_Log"], tblhhupdate);
                    }
                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_MNCHData_V501(tblpregnant_woman, tblchild, tblANCVisit, tblDatesEd, tblhhupdate, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string MNCHUploadServices_V601(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 5)
                {
                    DataTable tblpregnant_woman = DBTask.CreateDataTable("tblpregnant_womanType_V601");  // tblpregnant_womanType - this is table type
                    DataTable tblchild = DBTask.CreateDataTable("tblchildType_V601");
                    DataTable tblANCVisit = DBTask.CreateDataTable("tblANC_visitstype_V501");
                    DataTable tblDatesEd = DBTask.CreateDataTable("tbl_DatesEdType_V501");
                    DataTable tblhhupdate = DBTask.CreateDataTable("tblhhupdate_Log_V501");
                    if ((dsMyData.Tables["tbl_pregnantwomen"] != null) && (dsMyData.Tables["tbl_pregnantwomen"].Rows.Count > 0))
                    {
                        tblpregnant_woman = SetColumnsOrdinal(dsMyData.Tables["tbl_pregnantwomen"], tblpregnant_woman);
                    }
                    if ((dsMyData.Tables["tblchild"] != null) && (dsMyData.Tables["tblchild"].Rows.Count > 0))
                    {
                        tblchild = SetColumnsOrdinal(dsMyData.Tables["tblchild"], tblchild);
                    }
                    if ((dsMyData.Tables["tbl_ANCvisit"] != null) && (dsMyData.Tables["tbl_ANCvisit"].Rows.Count > 0))
                    {
                        tblANCVisit = SetColumnsOrdinal(dsMyData.Tables["tbl_ANCvisit"], tblANCVisit);
                    }
                    if ((dsMyData.Tables["tbl_DatesEd"] != null) && (dsMyData.Tables["tbl_DatesEd"].Rows.Count > 0))
                    {
                        tblDatesEd = SetColumnsOrdinal(dsMyData.Tables["tbl_DatesEd"], tblDatesEd);
                    }
                    if ((dsMyData.Tables["tblhhupdate_Log"] != null) && (dsMyData.Tables["tblhhupdate_Log"].Rows.Count > 0))
                    {
                        tblhhupdate = SetColumnsOrdinal(dsMyData.Tables["tblhhupdate_Log"], tblhhupdate);
                    }
                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_MNCHData_V601(tblpregnant_woman, tblchild, tblANCVisit, tblDatesEd, tblhhupdate, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string AnsUploadServices(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 4)
                {
                    DataTable tblmstFPAns = DBTask.CreateDataTable("tblmstFPAnsType");  // tblmstFPAnstype - this is table type
                    DataTable tblmstFPDetail = DBTask.CreateDataTable("tblmstFPDetailType");
                    DataTable tblmstimmunizationANS = DBTask.CreateDataTable("tblmstimmunizationANSType");
                    DataTable tblPNChomevisit_ANS = DBTask.CreateDataTable("tblPNChomevisit_ANSType");

                    if ((dsMyData.Tables["tblmstFPAns"] != null) && (dsMyData.Tables["tblmstFPAns"].Rows.Count > 0)) //tblmstFPAns - this is a dataset(dsMyData) table name
                    {
                        tblmstFPAns = SetColumnsOrdinal(dsMyData.Tables["tblmstFPAns"], tblmstFPAns);
                    }
                    if ((dsMyData.Tables["tblmstFPFDetail"] != null) && (dsMyData.Tables["tblmstFPFDetail"].Rows.Count > 0))
                    {
                        tblmstFPDetail = SetColumnsOrdinal(dsMyData.Tables["tblmstFPFDetail"], tblmstFPDetail);
                    }
                    if ((dsMyData.Tables["tblmstimmunizationANS"] != null) && (dsMyData.Tables["tblmstimmunizationANS"].Rows.Count > 0))
                    {
                        tblmstimmunizationANS = SetColumnsOrdinal(dsMyData.Tables["tblmstimmunizationANS"], tblmstimmunizationANS);
                    }
                    if ((dsMyData.Tables["tblPNChomevisit_ANS"] != null) && (dsMyData.Tables["tblPNChomevisit_ANS"].Rows.Count > 0))
                    {
                        tblPNChomevisit_ANS = SetColumnsOrdinal(dsMyData.Tables["tblPNChomevisit_ANS"], tblPNChomevisit_ANS);
                    }

                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_Ansdata(tblmstFPAns, tblmstFPDetail, tblmstimmunizationANS, tblPNChomevisit_ANS, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string AnsUploadServices_V501(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 4)
                {
                DataTable tblmstFPAns = DBTask.CreateDataTable("tblmstFPAnsType_V501");  // tblmstFPAnstype - this is table type
                DataTable tblmstFPDetail = DBTask.CreateDataTable("tblmstFPDetailType_V501");
                DataTable tblmstimmunizationANS = DBTask.CreateDataTable("tblmstimmunizationANSType_V501");
                DataTable tblPNChomevisit_ANS = DBTask.CreateDataTable("tblPNChomevisit_ANSType_V501");

                if ((dsMyData.Tables["tblmstFPAns"] != null) && (dsMyData.Tables["tblmstFPAns"].Rows.Count > 0)) //tblmstFPAns - this is a dataset(dsMyData) table name
                {
                    tblmstFPAns = SetColumnsOrdinal(dsMyData.Tables["tblmstFPAns"], tblmstFPAns);
                }
                if ((dsMyData.Tables["tblmstFPFDetail"] != null) && (dsMyData.Tables["tblmstFPFDetail"].Rows.Count > 0))
                {
                    tblmstFPDetail = SetColumnsOrdinal(dsMyData.Tables["tblmstFPFDetail"], tblmstFPDetail);
                }
                if ((dsMyData.Tables["tblmstimmunizationANS"] != null) && (dsMyData.Tables["tblmstimmunizationANS"].Rows.Count > 0))
                {
                    tblmstimmunizationANS = SetColumnsOrdinal(dsMyData.Tables["tblmstimmunizationANS"], tblmstimmunizationANS);
                }
                if ((dsMyData.Tables["tblPNChomevisit_ANS"] != null) && (dsMyData.Tables["tblPNChomevisit_ANS"].Rows.Count > 0))
                {
                    tblPNChomevisit_ANS = SetColumnsOrdinal(dsMyData.Tables["tblPNChomevisit_ANS"], tblPNChomevisit_ANS);
                }

                DataSet dsResult = new DataSet();
                dsResult = DBTask.IU_Ansdata_V501(tblmstFPAns, tblmstFPDetail, tblmstimmunizationANS, tblPNChomevisit_ANS, sData, UserID);
                sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string AnsUploadServices_V601(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 4)
                {
                DataTable tblmstFPAns = DBTask.CreateDataTable("tblmstFPAnsType_V601");  // tblmstFPAnstype - this is table type
                DataTable tblmstFPDetail = DBTask.CreateDataTable("tblmstFPDetailType_V601");
                DataTable tblmstimmunizationANS = DBTask.CreateDataTable("tblmstimmunizationANSType_V601");
                DataTable tblPNChomevisit_ANS = DBTask.CreateDataTable("tblPNChomevisit_ANSType_V501");

                if ((dsMyData.Tables["tblmstFPAns"] != null) && (dsMyData.Tables["tblmstFPAns"].Rows.Count > 0)) //tblmstFPAns - this is a dataset(dsMyData) table name
                {
                    tblmstFPAns = SetColumnsOrdinal(dsMyData.Tables["tblmstFPAns"], tblmstFPAns);
                }
                if ((dsMyData.Tables["tblmstFPFDetail"] != null) && (dsMyData.Tables["tblmstFPFDetail"].Rows.Count > 0))
                {
                    tblmstFPDetail = SetColumnsOrdinal(dsMyData.Tables["tblmstFPFDetail"], tblmstFPDetail);
                }
                if ((dsMyData.Tables["tblmstimmunizationANS"] != null) && (dsMyData.Tables["tblmstimmunizationANS"].Rows.Count > 0))
                {
                    tblmstimmunizationANS = SetColumnsOrdinal(dsMyData.Tables["tblmstimmunizationANS"], tblmstimmunizationANS);
                }
                if ((dsMyData.Tables["tblPNChomevisit_ANS"] != null) && (dsMyData.Tables["tblPNChomevisit_ANS"].Rows.Count > 0))
                {
                    tblPNChomevisit_ANS = SetColumnsOrdinal(dsMyData.Tables["tblPNChomevisit_ANS"], tblPNChomevisit_ANS);
                }

                DataSet dsResult = new DataSet();
                dsResult = DBTask.IU_Ansdata_V601(tblmstFPAns, tblmstFPDetail, tblmstimmunizationANS, tblPNChomevisit_ANS, sData, UserID);
                sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string AnsUploadServices_V701(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 4)
                {
                    DataTable tblmstFPAns = DBTask.CreateDataTable("tblmstFPAnsType_V701");  // tblmstFPAnstype - this is table type
                    DataTable tblmstFPDetail = DBTask.CreateDataTable("tblmstFPDetailType_V701");
                    DataTable tblmstimmunizationANS = DBTask.CreateDataTable("tblmstimmunizationANSType_V601");
                    DataTable tblPNChomevisit_ANS = DBTask.CreateDataTable("tblPNChomevisit_ANSType_V501");

                    if ((dsMyData.Tables["tblmstFPAns"] != null) && (dsMyData.Tables["tblmstFPAns"].Rows.Count > 0)) //tblmstFPAns - this is a dataset(dsMyData) table name
                    {
                        tblmstFPAns = SetColumnsOrdinal(dsMyData.Tables["tblmstFPAns"], tblmstFPAns);
                    }
                    if ((dsMyData.Tables["tblmstFPFDetail"] != null) && (dsMyData.Tables["tblmstFPFDetail"].Rows.Count > 0))
                    {
                        tblmstFPDetail = SetColumnsOrdinal(dsMyData.Tables["tblmstFPFDetail"], tblmstFPDetail);
                    }
                    if ((dsMyData.Tables["tblmstimmunizationANS"] != null) && (dsMyData.Tables["tblmstimmunizationANS"].Rows.Count > 0))
                    {
                        tblmstimmunizationANS = SetColumnsOrdinal(dsMyData.Tables["tblmstimmunizationANS"], tblmstimmunizationANS);
                    }
                    if ((dsMyData.Tables["tblPNChomevisit_ANS"] != null) && (dsMyData.Tables["tblPNChomevisit_ANS"].Rows.Count > 0))
                    {
                        tblPNChomevisit_ANS = SetColumnsOrdinal(dsMyData.Tables["tblPNChomevisit_ANS"], tblPNChomevisit_ANS);
                    }

                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_Ansdata_V701(tblmstFPAns, tblmstFPDetail, tblmstimmunizationANS, tblPNChomevisit_ANS, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string VHNDUploadServices(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                if (dsMyData.Tables.Count <= 4)
                {
                    DataTable tbl_VHNDPerformance = DBTask.CreateDataTable("tbl_VHNDPerformanceType");  // tbl_VHNDPerformanceType - this is table type
                    DataTable tbl_VHND_DueList = DBTask.CreateDataTable("tbl_VHND_DueListType");
                    DataTable tblVHNDDueList = DBTask.CreateDataTable("tblVHNDDueList_Type");

                    if ((dsMyData.Tables["tbl_VHNDPerformance"] != null) && (dsMyData.Tables["tbl_VHNDPerformance"].Rows.Count > 0)) //tblmstFPAns - this is a dataset(dsMyData) table name
                    {
                        tbl_VHNDPerformance = SetColumnsOrdinal(dsMyData.Tables["tbl_VHNDPerformance"], tbl_VHNDPerformance);
                    }
                    if ((dsMyData.Tables["tbl_VHND_DueList"] != null) && (dsMyData.Tables["tbl_VHND_DueList"].Rows.Count > 0))
                    {
                        tbl_VHND_DueList = SetColumnsOrdinal(dsMyData.Tables["tbl_VHND_DueList"], tbl_VHND_DueList);
                    }
                    if ((dsMyData.Tables["tblVHNDDueList"] != null) && (dsMyData.Tables["tblVHNDDueList"].Rows.Count > 0))
                    {
                        tblVHNDDueList = SetColumnsOrdinal(dsMyData.Tables["tblVHNDDueList"], tblVHNDDueList);
                    }
                   
                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_VHNDdata(tbl_VHNDPerformance, tbl_VHND_DueList,tblVHNDDueList, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }
        }
        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string PostData(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));

                if (dsMyData.Tables.Count <= 2)
                {
                    DataTable tblHHFamilyMember = DBTask.CreateDataTable("tblHHFamilyMemberType");
                    DataTable tblHHSurvey = DBTask.CreateDataTable("tblHHSurveyType");
                    if ((dsMyData.Tables["Tbl_HHFamilyMember"] != null) && (dsMyData.Tables["Tbl_HHFamilyMember"].Rows.Count > 0))
                    {
                        tblHHFamilyMember = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHFamilyMember"], tblHHFamilyMember);
                    }
                    if ((dsMyData.Tables["Tbl_HHSurvey"] != null) && (dsMyData.Tables["Tbl_HHSurvey"].Rows.Count > 0))
                    {
                        tblHHSurvey = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHSurvey"], tblHHSurvey);
                    }
                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_HHData_old(tblHHFamilyMember, tblHHSurvey, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999";
            }
        }
        return sReturn;
    }


    [System.Web.Services.WebMethod(EnableSession = true)]
    public string PostDataNewVersion(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));

                if (dsMyData.Tables.Count <= 2)
                {
                    DataTable tblHHFamilyMember = DBTask.CreateDataTable("tblHHFamilyMemberType_online");
                    DataTable tblHHSurvey = DBTask.CreateDataTable("tblHHSurveyType_online");

                    if ((dsMyData.Tables["Tbl_HHFamilyMember"] != null) && (dsMyData.Tables["Tbl_HHFamilyMember"].Rows.Count > 0))
                    {
                        tblHHFamilyMember = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHFamilyMember"], tblHHFamilyMember);
                    }
                    if ((dsMyData.Tables["Tbl_HHSurvey"] != null) && (dsMyData.Tables["Tbl_HHSurvey"].Rows.Count > 0))
                    {
                        tblHHSurvey = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHSurvey"], tblHHSurvey);
                    }

                    DataSet dsResult = new DataSet();

                    dsResult = DBTask.IU_HHData(tblHHFamilyMember, tblHHSurvey, sData, UserID);

                    sReturn = JsonConvert.SerializeObject(dsResult);

                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999";
            }

        }

        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string PostDataVersion_501(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));

                if (dsMyData.Tables.Count <= 4)
                {
                    DataTable tblHHFamilyMember = DBTask.CreateDataTable("tblHHFamilyMemberType_V501");
                    DataTable tblHHSurvey = DBTask.CreateDataTable("tblHHSurveyType_V501");
                    DataTable tblMig = DBTask.CreateDataTable("tblMigrationType_V501");
                    DataTable tblhhupdate = DBTask.CreateDataTable("tblhhupdate_Log_V501");

                    if ((dsMyData.Tables["Tbl_HHFamilyMember"] != null) && (dsMyData.Tables["Tbl_HHFamilyMember"].Rows.Count > 0))
                    {
                        tblHHFamilyMember = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHFamilyMember"], tblHHFamilyMember);
                    }
                    if ((dsMyData.Tables["Tbl_HHSurvey"] != null) && (dsMyData.Tables["Tbl_HHSurvey"].Rows.Count > 0))
                    {
                        tblHHSurvey = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHSurvey"], tblHHSurvey);
                    }

                    if ((dsMyData.Tables["tblMigration"] != null) && (dsMyData.Tables["tblMigration"].Rows.Count > 0))
                    {
                        tblMig = SetColumnsOrdinal(dsMyData.Tables["tblMigration"], tblMig);
                    }

                    if ((dsMyData.Tables["tblhhupdate_Log"] != null) && (dsMyData.Tables["tblhhupdate_Log"].Rows.Count > 0))
                    {
                        tblhhupdate = SetColumnsOrdinal(dsMyData.Tables["tblhhupdate_Log"], tblhhupdate);
                    }
                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_HHData_V501(tblHHFamilyMember, tblHHSurvey, tblMig, tblhhupdate, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }

        }

        return sReturn;
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public string PostDataVersion_JH(string sData, string AuthenticationToken, string UserName, string PassWord)
    {
        string sReturn = string.Empty;

        int UserID = 0;

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
                DataSet dsMyData = new DataSet();
                XmlDocument xdMyData = new XmlDocument();
                sData = "{ \"rootNode\": {" + sData.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                dsMyData.ReadXml(new XmlNodeReader(xdMyData));

                if (dsMyData.Tables.Count <= 4)
                {
                    DataTable tblHHFamilyMember = DBTask.CreateDataTable("tblHHFamilyMemberType_JH");
                    DataTable tblHHSurvey = DBTask.CreateDataTable("tblHHSurveyType_JH");
                    DataTable tblMig = DBTask.CreateDataTable("tblMigrationType_V501");
                    DataTable tblhhupdate = DBTask.CreateDataTable("tblhhupdate_Log_V501");

                    if ((dsMyData.Tables["Tbl_HHFamilyMember"] != null) && (dsMyData.Tables["Tbl_HHFamilyMember"].Rows.Count > 0))
                    {
                    tblHHFamilyMember = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHFamilyMember"], tblHHFamilyMember);
                    }

                    if ((dsMyData.Tables["Tbl_HHSurvey"] != null) && (dsMyData.Tables["Tbl_HHSurvey"].Rows.Count > 0))
                    {
                    tblHHSurvey = SetColumnsOrdinal(dsMyData.Tables["Tbl_HHSurvey"], tblHHSurvey);
                    }

                    if ((dsMyData.Tables["tblMigration"] != null) && (dsMyData.Tables["tblMigration"].Rows.Count > 0))
                    {
                    tblMig = SetColumnsOrdinal(dsMyData.Tables["tblMigration"], tblMig);
                    }

                    if ((dsMyData.Tables["tblhhupdate_Log"] != null) && (dsMyData.Tables["tblhhupdate_Log"].Rows.Count > 0))
                    {
                    tblhhupdate = SetColumnsOrdinal(dsMyData.Tables["tblhhupdate_Log"], tblhhupdate);
                    }
                    
                    DataSet dsResult = new DataSet();
                    dsResult = DBTask.IU_HHData_JH(tblHHFamilyMember, tblHHSurvey, tblMig, tblhhupdate, sData, UserID);
                    sReturn = JsonConvert.SerializeObject(dsResult);
                }
                else
                {
                    sReturn = "-99";
                }
            }
            catch (Exception ex)
            {
                sReturn = "-999 " + ex.Message;
                DataSet dsResult = new DataSet();
                dsResult = DBTask.errorlog(sData, UserID, "Failed");
            }

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
            ex.Message.ToString();
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

    [WebMethod(EnableSession = true)]
    public string PutImage(string filebytes, string fileName, string sUID, string sImageFieldName)
    {
        try
        {
        string stockImagesDir = ConfigurationManager.AppSettings["ImagesPath"].ToString();
        string sDirectory = Server.MapPath(stockImagesDir);
        string sFilename = sDirectory + "\\" + fileName;
        byte[] sfilebytes = Convert.FromBase64String(filebytes);
        MemoryStream ms = new MemoryStream(sfilebytes);
        if (!Directory.Exists(sDirectory))
        Directory.CreateDirectory(sDirectory);
        using (FileStream fs = new FileStream(sFilename, FileMode.Create, FileAccess.ReadWrite))
        {
        ms.WriteTo(fs);
        ms.Close();
        fs.Close();
        fs.Dispose();
        }
        return "OK";
        }
        catch (Exception ex)
        {
        return " FAIL " + ex.Message.ToString();
        }
    }

    [WebMethod(EnableSession = true)]
    public string DownloadFile(string FName)
    {
    System.IO.FileStream fs1 = null;
    fs1 = System.IO.File.Open(FName, FileMode.Open, FileAccess.Read);
    byte[] b1 = new byte[fs1.Length];
    fs1.Read(b1, 0, (int)fs1.Length);
    fs1.Close();
    return Convert.ToBase64String(b1, Base64FormattingOptions.None);
    }
}

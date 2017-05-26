using System;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Linq;
//using System.Configuration;
//using System.Data.SqlClient;
//using Microsoft.Vbe;
/// <summary>
/// Summary description for BllLibrary
/// </summary>

namespace BusinessLogicLayer
{

    public class BllLibrary
    {
        public DALOrderLibrary objDAL = new DALOrderLibrary();
        protected string SqlQuery;
        protected DataTable SqldbDataTable;
        protected DataSet SqldbDataSet;
        //protected DataSet SqlHelper;
        protected DataSet GetDataSet;
      
        public HyperLinkField hyplnkTest = new HyperLinkField();
        public string appRootPath = System.Web.HttpRuntime.AppDomainAppVirtualPath + "/";

        public BllLibrary()
        {

         
        }

    //    Subcenter
        public DataTable GetGroupFilterDatacenter()
        {
            SqlQuery = "";
            SqlQuery = "select t1.SubCenterCode,t1.SubCenterID,t1.SubCenterName,t2.SubCenterName as SubCenterName_Hindi from (select SubCenterCode,SubCenterID,SubCenterName from mstsubcenter where languageid=1) as t1  inner join (select SubCenterID,SubCenterName from mstsubcenter where languageid=2) as t2 on t1.SubCenterID=t2.SubCenterID ";
          
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetGroupsearchDatacenter(string WhereQuery)
        {
            SqlQuery = "";

          //  SqlQuery = "select SubCenterCode,SubCenterID,SubCenterName from mstsubcenter " + WhereQuery + " ";
            SqlQuery = "select t1.SubCenterCode,t1.SubCenterID,t1.SubCenterName,t2.SubCenterName as SubCenterName_Hindi from (select SubCenterCode,SubCenterID,SubCenterName from mstsubcenter where languageid=1) as t1  inner join (select SubCenterID,SubCenterName from mstsubcenter where languageid=2) as t2 on t1.SubCenterID=t2.SubCenterID " + WhereQuery + " ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetcenterMstrRowData(string autoID)
        {
            SqlQuery = "";

            SqlQuery = "select SubCenterCode,SubCenterID,SubCenterName from mstsubcenter where SubCenterID=" + autoID + " and languageID=1 ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }


        public DataTable GetcenterMstrRowData1(string autoID)
        {
            SqlQuery = "";

            SqlQuery = "select SubCenterCode,SubCenterID,SubCenterName from mstsubcenter where SubCenterID=" + autoID + " and languageID=2 ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }


        public DataTable Getcenterdelete(int centerid)
        {
            SqlQuery = "";

            SqlQuery = "delete mstsubcenter where SubCenterID=" + centerid + " ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        // end subcenter


        //    anm
        public DataTable GetGroupFilterDataanm()
        {
            SqlQuery = "";

            SqlQuery = "select t1.ANMID,t1.ANMCode,t1.ANMName,t2.ANMName as ANMName_Hindi from (select ANMID,ANMCode,ANMName from mstanm where languageid=1) as t1  inner join (select ANMID,ANMName from mstanm where languageid=2) as t2 on t1.ANMID=t2.ANMID ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetGroupsearchDataanm(string WhereQuery)
        {
            SqlQuery = "";

            SqlQuery = "select t1.ANMID,t1.ANMCode,t1.ANMName,t2.ANMName as ANMName_Hindi from (select ANMID,ANMCode,ANMName from mstanm where languageid=1) as t1  inner join (select ANMID,ANMName from mstanm where languageid=2) as t2 on t1.ANMID=t2.ANMID " + WhereQuery + " ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetanmMstrRowData(string autoID)
        {
            SqlQuery = "";

            SqlQuery = "select ANMID,ANMCode,ANMName from mstanm where ANMID=" + autoID + " and languageID=1 ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }


        public DataTable GetanmMstrRowData1(string autoID)
        {
            SqlQuery = "";

            SqlQuery = "select ANMID,ANMCode,ANMName from mstanm where ANMID=" + autoID + " and languageID=2 ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable Getanmdelete(int anmid)
        {
            SqlQuery = "";

            SqlQuery = "delete mstanm where ANMID=" + anmid + " ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        // end anm

      
        
        //    asha
        public DataTable GetGroupFilterDataasha()
        {
            SqlQuery = "";
            SqlQuery = "select t1.ANMCode,t1.ASHAID,t1.ASHACode,t1.ASHAName,t2.ASHAName as ASHAName_Hindi from (select ANMCode,ASHAID,ASHACode,ASHAName from mstasha where languageid=1) as t1  inner join (select ASHAID,ASHAName from mstasha where languageid=2) as t2 on t1.ASHAID=t2.ASHAID ";
          
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetGroupsearchDataasha(string WhereQuery)
        {
            SqlQuery = "";

            SqlQuery = "select t1.ANMCode,t1.ASHAID,t1.ASHACode,t1.ASHAName,t2.ASHAName as ASHAName_Hindi from (select ANMCode,ASHAID,ASHACode,ASHAName from mstasha where languageid=1) as t1  inner join (select ASHAID,ASHAName from mstasha where languageid=2) as t2 on t1.ASHAID=t2.ASHAID  " + WhereQuery + " ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetashaMstrRowData(string autoID)
        {
            SqlQuery = "";

            SqlQuery = "select ANMCode,subcentercode,ASHAID,ASHACode,ASHAName from mstasha where ASHAID=" + autoID + " and languageID=1 ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }


        public DataTable GetashaMstrRowData1(string autoID)
        {
            SqlQuery = "";

            SqlQuery = "select ANMCode,ASHAID,ASHACode,ASHAName from mstasha where ASHAID=" + autoID + " and languageID=2 ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable Getashadelete(int ashaid)
        {
            SqlQuery = "";

            SqlQuery = "delete mstasha where ASHAID=" + ashaid + " ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }


        // end asha


        public DataTable Getselectanm()
        {
            SqlQuery = "";
            SqlQuery = "select ANMCode,ANMName from mstanm where languageid=1 ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable Getsubcenter()
        {
            SqlQuery = "";
            SqlQuery = "select subcenterCode,subcenterName from mstsubcenter where languageid=1 ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetSelectasha(string anmcode)
        {
            SqlQuery = "";
            SqlQuery = "select ASHACode,ASHAName from mstasha where languageid=1  and anmcode = '" + anmcode + "' ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable GetSelectasha12()
        {
            SqlQuery = "";
            SqlQuery = "select ASHACode,ASHAName from mstasha where languageid=1";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }


        public DataTable GetSelectcenteranm(string subcentercodecode)
        {
            SqlQuery = "";
            SqlQuery = "select AnmId,AnmName from ANMSubcenter where  subcentercode = '" + subcentercodecode + "' ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable Selectasha()
        {
            SqlQuery = "";
            SqlQuery = "select ASHACode,ASHAName from mstasha where languageid=1 ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable Selectashatrack()
        {
            SqlQuery = "";
            SqlQuery = "select ASHAID,ASHAName from mstasha where languageid=1 ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }


        //public DataTable Selectvhnd()
        //{
        //    SqlQuery = "";
        //    SqlQuery = "select SubCenter_ID,ANM_ID,ASHA_ID,Village_ID,AW_Name,Frequency,Occurence,Days,active,createdBy,updatedBy,Year_Type from VHND_Schedule where year= 2017 ";
        //    SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
        //    return SqldbDataTable;
        //}


        public DataTable Selectvhnd()
        {
            SqlQuery = "";
            SqlQuery = "select SubCenter_ID,ANM_ID,ASHA_ID,Village_ID,mstvillage.VillageName,Frequency,Occurence,Days,active,createdBy,updatedBy,Year_Type from VHND_Schedule left join mstvillage on VHND_Schedule.Village_ID=mstvillage.VillageId where year= year(getdate()) and languageid=1 ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }

        public DataTable Getvillage(int ashaid)
        {
            SqlQuery = "";
           // SqlQuery = "select VillageName,VillageID  from mstvillage where languageid=1 ";
            SqlQuery = "select VillageName,mstvillage.VillageID from ashavillage inner join mstvillage on mstvillage.villageid=ashavillage.villageid where languageid=1 and ashaid= " + ashaid + " ";

            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }



        public DataTable GetSelectsubcenter(string anmcode)
        {
            SqlQuery = "";
            SqlQuery = "select distinct mstsubcenter.subcenterCode,subcenterName from mstsubcenter inner join mstasha on mstasha.subcentercode= mstsubcenter.subcentercode where mstasha.languageid=1 and mstsubcenter.languageid=1 and mstasha.anmcode ='" + anmcode + "' ";
            SqldbDataTable = objDAL.GetResultFromSqlQur(SqlQuery);
            return SqldbDataTable;
        }
       
       
        public int updateEmp(int PIALoginID, int iEmployerId, string sEmployerName, string sScale, string sWebsite, string sPAN, string sTAN, int iManpower)
        {
        return objDAL.INS_UPD_PIAEmpEditDetails(PIALoginID, iEmployerId, sEmployerName, sScale, sWebsite, sPAN, sTAN, iManpower);
        }


        public int insertvhndprev(DataTable dt)
        {
            return objDAL.insertvhndprev(dt);
        }

        public int insertvhndschedule(SqlDateTime jan, SqlDateTime feb, SqlDateTime mar, SqlDateTime apr, SqlDateTime may, SqlDateTime jun, SqlDateTime jul, SqlDateTime aug, SqlDateTime sep, SqlDateTime oct, SqlDateTime nov, SqlDateTime dec, int id, string village, string days, string occurence)
        {
            return objDAL.insertvhndschedule(jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec, id, village,days, occurence);
        }

        public int insetupdatedate(string name,string namehindi,int anmcode, int subcentercode,int ID ,string Querytype,string type)
        {
            return objDAL.INS_UPD_details(name, namehindi, anmcode, subcentercode,ID, Querytype, type);
        }


        public DataTable getdata(string whr, string flag)
        {
            SqldbDataTable = objDAL.getdata(whr,flag);
            return SqldbDataTable;
        }


        public DataTable getdatavhnd(string whr, string flag)
        {
            SqldbDataTable = objDAL.getdatavhnd(whr, flag);
            return SqldbDataTable;
        }


        public DataTable getdatavhndinser(string year, string occurence, string days)
        {
            SqldbDataTable = objDAL.getdatavhndinser( year,  occurence,  days);
            return SqldbDataTable;
        }
       

        public DataTable TrackChanges(int ashaid, int month, string flag)
        {
            SqldbDataTable = objDAL.TrackChanges(ashaid, month, flag);
            return SqldbDataTable;
        }

        public DataTable getdatamember(string whr)
        {
            SqldbDataTable = objDAL.getdatamember(whr);
            return SqldbDataTable;
        }

        public DataTable getreport(string whr,string flag)
        {
            SqldbDataTable = objDAL.getreport(whr, flag);
            return SqldbDataTable;
        }


        public DataSet getdatareport()
        {
            DataSet SqldbDataTable = objDAL.getdatareport();
            return SqldbDataTable;
        }



    }

}
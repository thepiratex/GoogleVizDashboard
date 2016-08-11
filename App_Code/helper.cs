using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
public class helper
{
    public static string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
    protected SqlConnection sqlConn = new SqlConnection(ConnectionString);
    public helper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string ApplicationURL
    {
        get
        {
            string strURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
            if (HttpContext.Current.Request.IsSecureConnection)
            {
                strURL = strURL.Replace("http", "https");
            }
            return strURL;
        }
    }

    public DataSet getMeanTime()
    {
        DataSet dsMeanTime = new DataSet();
        dsMeanTime = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "sp_getMeanWorkingTime");
        return dsMeanTime;
    }

    public DataSet openIncidents()
    {
        DataSet dsOpenIncidents = new DataSet();
        dsOpenIncidents = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "usp_getOpenIncidents");
        return dsOpenIncidents;
    }



    public DataSet getincidentsThisWeek()
    {
        DataSet dsincidentthisweek = new DataSet();
        dsincidentthisweek = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "usp_incidentsThisWeek");
        return dsincidentthisweek;
    }

    public DataSet getIncidentsCountRegionWise()
    {
        DataSet dsIncidentsCountRegionWise = new DataSet();
        dsIncidentsCountRegionWise = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "usp_getIncidentsCountRegionWise");
        return dsIncidentsCountRegionWise;
    }

    public DataSet getIncidentStatus()
    {
        DataSet dsIncidentStatus = new DataSet();
        dsIncidentStatus = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "sp_getIncidentStatus");
        return dsIncidentStatus;
    }

    public DataSet getProductCountBar()
    {
        DataSet dsProductCountBar = new DataSet();
        dsProductCountBar = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "sp_getProductCountBar");
        return dsProductCountBar;
    }

    public DataSet getIncidentSupportGroupAndMonthWise()
    {
        DataSet dsIncidentSupportGroupAndMonthWise = new DataSet();
        dsIncidentSupportGroupAndMonthWise = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "usp_getIncidentSupportGroupAndMonthWise");
        return dsIncidentSupportGroupAndMonthWise;
    }

    public DataSet getIncidentMonthlyCount()
    {
        DataSet dsIncidentMonthlyCount = new DataSet();
        dsIncidentMonthlyCount = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "usp_incidentMonthlyCount");
        return dsIncidentMonthlyCount;
    }

    public DataSet Details(string chartType, string selectedValue)
    {
        DataSet dsDetails = new DataSet();
        SqlParameter[] cmdParameters = new SqlParameter[2];
        cmdParameters[0] = new SqlParameter("@chartType", chartType);
        cmdParameters[1] = new SqlParameter("@selectedValue", selectedValue);
        dsDetails = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "Details", cmdParameters);
        return dsDetails;
    }


    public DataSet getDualColumn()
    {
        DataSet dsualColumn = new DataSet();
        dsualColumn = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "usp_DualColumn");
        return dsualColumn;
    }
    public DataSet getCriticalCount()
    {
        DataSet dsCriticalCount = new DataSet();
        dsCriticalCount = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "CriticalCount");
        return dsCriticalCount;
    }
    public DataSet getPriorityTimeline()
    {
        DataSet dsPriorityTimeline = new DataSet();
        dsPriorityTimeline = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "PriorityTimeline");
        return dsPriorityTimeline;
    }
    public DataSet getUnAssigned()
    {
        DataSet dsUnAssigned = new DataSet();
        dsUnAssigned = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "UnAssigned");
        return dsUnAssigned;
    }

    public DataSet getAcknowledgeTime()
    {
        DataSet dsAcknowledgeTime = new DataSet();
        dsAcknowledgeTime = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "AcknowledgeTime");
        return dsAcknowledgeTime;
    }
    public DataSet getSubmitterCount()
    {
        DataSet dsSubmitterCount = new DataSet();
        dsSubmitterCount = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "SubmitterCount");
        return dsSubmitterCount;
    }

    public DataSet getFlow()
    {
        DataSet dsFlow = new DataSet();
        dsFlow = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "flow");
        return dsFlow;
    }
}
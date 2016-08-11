using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

public partial class Details : System.Web.UI.Page
{
    helper hr = new helper();
    DataSet dsChartDetails = new DataSet();
    public string strChartType = "";
    public string strSelectedValue = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["chartname"] != null) && Request.QueryString["chartname"] != "")
        {
            strChartType = Request.QueryString["chartname"].ToString();
        }

        if ((Request.QueryString["SelectedValue"] != null) && Request.QueryString["SelectedValue"] != "")
        {
            strSelectedValue = Request.QueryString["SelectedValue"].ToString();
        }
        GenerateTableData();
    }

    private void GenerateTableData()
    {
        dsChartDetails = hr.Details(strChartType, strSelectedValue);
        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {
            StringBuilder strScript = new StringBuilder();
            strScript.Append(
            @" <script type='text/javascript'> 
            google.charts.setOnLoadCallback(drawDashboard);
            function drawDashboard() {
            var data = google.visualization.arrayToDataTable([  
                    ['Incident ID', 'Resolution Start Time (SLM)','Incident Status','Incident Priority','Assignee','Resolved Date Time','Incident Product Name'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Incident ID"] + "',new Date('" + row["Resolution Start Time (SLM)"] + "'),'" + row["Incident Status"] + "','" + row["Incident Priority"] + "','" + row["Assignee"] + "','" + row["Resolved Date Time"] + "','" + row["Incident Product Name"] + "'],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@"
        var dashboard = new google.visualization.Dashboard(document.getElementById('dashboard3_div'));
        var slider = new google.visualization.ControlWrapper({
          'controlType': 'CategoryFilter',
          'containerId': 'assignee_div',
          'options': {
            'filterColumnLabel': 'Assignee',
            'ui': {
            'allowTyping': true,
            'allowMultiple': false,
            'allowNone': true,
            'sortValues': false,
        }
          }
        });
 var ddl = new google.visualization.ControlWrapper({
          'controlType': 'DateRangeFilter',
          'containerId': 'date_div',
          'options': {
            'filterColumnLabel': 'Resolution Start Time (SLM)',
            'ui': {
            'allowTyping': false,
            'allowMultiple': false,
            'allowNone': false,
            'sortValues': false,
'label':'Date Range'
        },

          }
        });
var incident = new google.visualization.ControlWrapper({
          'controlType': 'CategoryFilter',
          'containerId': 'incident_div',
          'options': {
            'filterColumnLabel': 'Incident ID',
            'ui': {
            'allowTyping': true,
            'allowMultiple': false,
            'allowNone': true,
            'sortValues': false,
'label': 'ID',            
        }
          }
        });               
        var tableChart = new google.visualization.ChartWrapper({
 'chartType': 'Table',
    'containerId': 'chart3_div',
'options' : { 'height':'100%', 'width':'100%', 'page':'enable','pageSize':'25'}
});
        
dashboard.bind([slider,ddl,incident], tableChart);

        // Draw the dashboard.
        dashboard.draw(data);
}
");
            strScript.Append(" </script>");
            Literal1.Text = strScript.ToString();
        }
        else
        {
            divNodata.Visible = true;
            SpanNoChart.InnerText = "No Data to display.";
        }
    }
}
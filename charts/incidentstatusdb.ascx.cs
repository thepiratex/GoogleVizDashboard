using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class charts_incidentstatusdb : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {

        GenerateProductCountChart();

    }

    private void GenerateProductCountChart()
    {
        dsChartDetails = Hr.getIncidentStatus();
        StringBuilder strScript = new StringBuilder();

        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {

            strScript.Append(@"<script type='text/javascript'>
   
    google.charts.setOnLoadCallback(drawDashboard);

    function drawDashboard() {
        var data = google.visualization.arrayToDataTable([
                    ['Status', 'Count'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Status"] + "'," + row["Count"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
//            strScript.Append(@"  var options = {
//     title: 'Status Count',
//    pieHole: 0.2,
//width: '100%',
//height: '250',
//chartArea:{
//    left:0,
//    top: 20,
//bottom:0,
//    width: '100%',
//    height: '250',
//},
//     is3D: false,
//     pieSliceText: 'label',
// };");

            strScript.Append(@"
var dashboard = new google.visualization.Dashboard(document.getElementById('dashboard_div'));
var slider = new google.visualization.ControlWrapper({
          'controlType': 'CategoryFilter',
          'containerId': 'filter_div',
          'options': {
            'filterColumnLabel': 'Status',
            'ui': {
            'labelStacking': 'vertical',
            'allowTyping': false,
            'allowMultiple': true,
            'allowNone': false
        }
          }
        });
var pieChart = new google.visualization.ChartWrapper({
          'chartType': 'PieChart',
          'containerId': 'chart_div',
          'options': {
            'width': 300,
            'height': 300,
            'pieSliceText': 'value',
            'legend': 'right',
                animation:{
         startup: true,
         duration: 5000,
          easing: 'out',
      }
          }
        });
dashboard.bind(slider, pieChart);

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
            SpanNoChart.InnerText = "No Chart to display.";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class charts_IncidentGroupAndMonthWise : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {

        GenerateProductCountChart();

    }

    private void GenerateProductCountChart()
    {
        dsChartDetails = Hr.getIncidentSupportGroupAndMonthWise();
        StringBuilder strScript = new StringBuilder();

        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {

            strScript.Append(@"<script type='text/javascript'>
   
    google.charts.setOnLoadCallback(drawDashboard);

    function drawDashboard() {
        var data = google.visualization.arrayToDataTable([
                    ['Support Group', 'Count','Month'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Support Group"] + "'," + row["Count"] + ",'" + row["Month"] + "'],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@"
var dashboard = new google.visualization.Dashboard(document.getElementById('dashboard1_div'));
var slider = new google.visualization.ControlWrapper({
          'controlType': 'CategoryFilter',
          'containerId': 'filter1_div',
          'options': {
            'filterColumnLabel': 'Month',
            'ui': {
            'allowTyping': true,
            'allowMultiple': false,
            'allowNone': false,
            'sortValues': false,
            'label': 'Choose month',
        }
          }
        });
var ColumnChart = new google.visualization.ChartWrapper({
    'chartType': 'ColumnChart',
    'containerId': 'chart1_div',
    'options': {
        'legend': 'right',
        animation: {
            duration: 300,
            easing: 'inAndOut',
        },
        hAxis: {
            textPosition: 'out'
        },
        width: '100%',
        height: '250',
        vAxis: {
            minValue: 0
        },
        
        chartArea: {
            left: 40,
            top: 20,
            bottom: 30,
            width: '100%',
            height: '250',
        }
    },
    'view': {
        'columns': [0, 1]
    },
});
dashboard.bind(slider, ColumnChart);

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
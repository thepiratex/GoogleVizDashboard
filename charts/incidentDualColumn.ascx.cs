using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class charts_incidentDualColumn : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {

        GenerateProductCountChart();

    }

    private void GenerateProductCountChart()
    {
        dsChartDetails = Hr.getDualColumn();
        StringBuilder strScript = new StringBuilder();

        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {

            strScript.Append(@"<script type='text/javascript'>
   
    google.charts.setOnLoadCallback(drawDashboard);

    function drawDashboard() {
        var data = google.visualization.arrayToDataTable([
                    ['Support Group', 'Month','2015','2016'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Support Group"] + "','" + row["Month"] + "'," + row["2015"] + "," + row["2016"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@"
var dashboard = new google.visualization.Dashboard(document.getElementById('dashboard4_div'));
var slider = new google.visualization.ControlWrapper({
    'controlType': 'CategoryFilter',
    'containerId': 'filter4_div',
    'options': {
        'filterColumnLabel': 'Month',
        'ui': {
            'allowTyping': true,
            'allowMultiple': false,
            'allowNone': false,
            'sortValues': false,
            'label': 'Choose month',

        },
        
        },
'state': {
            'selectedValues': ['June']
    }
});
var ColumnChart = new google.visualization.ChartWrapper({
    'chartType': 'ColumnChart',
    'containerId': 'chart4_div',
    'options': {
        'legend': 'right',
        animation: {
            duration: 300,
            easing: 'inAndOut',
        },
        hAxis : { textPosition : 'out' },
        width: '100%',
        height: '250',
        vAxis: {
            minValue: 0
        },
        chartArea: {
            left: 40,
            top: 20,
            bottom: 30,
            right:100,
            width: '100%',
            height: '250',
        },
    },
 'view': {
        'columns': [0,2,3]
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
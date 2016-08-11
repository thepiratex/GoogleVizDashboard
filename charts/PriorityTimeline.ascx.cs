using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class charts_PriorityTimeline : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {

        GenerateProductCountChart();

    }

    private void GenerateProductCountChart()
    {
        dsChartDetails = Hr.getPriorityTimeline();
        StringBuilder strScript = new StringBuilder();

        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {

            strScript.Append(@"<script type='text/javascript'>
   
    google.charts.setOnLoadCallback(drawDashboard);

    function drawDashboard() {
        var data = google.visualization.arrayToDataTable([
                    ['Month', 'Low','Medium','High'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Month"] + "'," + row["Low"] + "," + row["Medium"] + "," + row["High"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@"  var options = {
animation:{
        startup: true,
        duration: 3000,
        easing: 'out',
      },
width: '100%',
height: '280',
chartArea:{
    left:50, right:100, top:30, 
},
pointSize: 5,
 };");
            strScript.Append(@"
var chart = new google.visualization.LineChart(document.getElementById('chart5_div'));
chart.draw(data, options);

function selectHandler() {
    var selectedItem = chart.getSelection()[0];
    if (selectedItem) {
        var topping = data.getValue(selectedItem.row, 0);
        if (topping) {
            window.location.replace('./Details.aspx?chartname=IncidentStatus&SelectedValue=' + topping);
        }
    }
}
google.visualization.events.addListener(chart, 'select', selectHandler);
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
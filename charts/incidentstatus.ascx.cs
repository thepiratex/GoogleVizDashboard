using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class charts_incidentstatus : System.Web.UI.UserControl
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
   
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
                    ['Status', 'Count'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Status"] + "'," + row["Count"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@"  var options = {
animation:{
        startup: true,
        duration: 3000,
        easing: 'out',
      },
    pieHole: 0.2,
width: '100%',
height: '300',
chartArea:{
    left:20,
    top: 20,
bottom:0,
    width: '100%',
    height: '300',
},
     is3D: true,
     pieSliceText: 'both',
 };");

            strScript.Append(@"
var chart = new google.visualization.PieChart(document.getElementById('divIncidentStatus'));
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
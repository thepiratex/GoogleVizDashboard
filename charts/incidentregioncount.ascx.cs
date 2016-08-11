using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class charts_incidentregioncount : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        generateIncidentRegionCount();
    }

    private void generateIncidentRegionCount ()
    {
        dsChartDetails = Hr.getIncidentsCountRegionWise();
        StringBuilder strScript = new StringBuilder();
        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {

            strScript.Append(@"<script type='text/javascript'>
    google.charts.load('current', {
        'packages': ['corechart']
    });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
                    ['Status', 'Count'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["region"] + "'," + row["Count"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@"  var options = {
     title: 'Status Count',
     is3D: false,
     pieSliceText: 'label',
    backgroundColor: { fill:'transparent' },
    
 };");

            strScript.Append(@"
var chart = new google.visualization.BarChart(document.getElementById('divIncidentCountRegionWise'));
chart.draw(data, options);

function selectHandler() {
    var selectedItem = chart.getSelection()[0];
    if (selectedItem) {
        var topping = data.getValue(selectedItem.row, 0);
        if (topping == 'Closed') {
            window.location.replace('./ChartDetails.aspx?chartname=IncidentStatus&SelectedValue=' + topping);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class charts_Flow : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {

        GenerateProductCountChart();

    }

    private void GenerateProductCountChart()
    {
        dsChartDetails = Hr.getFlow();
        StringBuilder strScript = new StringBuilder();

        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {

            strScript.Append(@"<script type='text/javascript'>
   
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = google.visualization.arrayToDataTable([
                    ['From', 'To','Weight'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["From"] + "','" + row["To"] + "'," + row["Weight"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@" 
var colors = ['#a6cee3', '#b2df8a', '#fb9a99', '#fdbf6f',
                  '#cab2d6', '#ffff99', '#1f78b4', '#33a02c'];

var options = {
height:'500',
sankey: {
        node: {
          colors: colors
        },
        link: {
          colorMode: 'gradient',
          colors: colors
        }
      }
 };");

            strScript.Append(@"
var chart = new google.visualization.Sankey(document.getElementById('chart7_div'));
chart.draw(data, options);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class charts_incidentMonthlyCount : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {

        GenerateProductCountChart();

    }

    private void GenerateProductCountChart()
    {
        dsChartDetails = Hr.getIncidentMonthlyCount();
        StringBuilder strScript = new StringBuilder();

        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {
            strScript.Append(@"<script type='text/javascript'>  
                    
google.charts.setOnLoadCallback(drawChart);                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Month', 'Count'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Month"] + "'," + row["Count"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@" var options = {     
                                     
colors: ['#4CAF50'],   
width: '100%',
height: '250',
pointShape: 'circle',
pointsVisible: true,
chartArea:{
    left:30,
    top: 20,
bottom:80,
    width: '100%',
    height: '250',
}                          };   ");

            strScript.Append(@"
var chart = new google.visualization.LineChart(document.getElementById('div_incidentMonthlyCount'));          
                                chart.draw(data, options);
function selectHandler() {
          var selectedItem = chart.getSelection()[0];
          if (selectedItem) {
            var topping = data.getValue(selectedItem.row, 0);
            alert('The user selected ' + topping);
          }
        }

google.visualization.events.addListener(chart, 'select', selectHandler);    

    
                                }    
                          
                            ");
            strScript.Append(" </script>");
            Literal1.Text = strScript.ToString();

        }
        //else
        //{
        //    divNodata.Visible = true;
        //    SpanNoChart.InnerText = "No Chart to display.";
        //}
    }
}
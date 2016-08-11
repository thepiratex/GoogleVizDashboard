using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class charts_productcount : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper Hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {

        GenerateProductCountChart();

    }

    private void GenerateProductCountChart()
    {
        dsChartDetails = Hr.getProductCountBar();
        StringBuilder strScript = new StringBuilder();

        if (dsChartDetails.Tables[0].Rows.Count > 0)
        {
            strScript.Append(@"<script type='text/javascript'>  
                    
google.charts.setOnLoadCallback(drawChart);                     
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Product Name', 'Count'],");
            foreach (DataRow row in dsChartDetails.Tables[0].Rows)
            {
                strScript.Append("['" + row["Incident Product Name"] + "'," + row["Count"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@"




var options = {     
                                     bar: {groupWidth: '30%'},
colors: ['#8BC34A'],   
annotations: {
        alwaysOutside: true,
        stem: {
          color: 'transparent'
        },
        textStyle: {
          fontName: 'Lato',
          fontSize: 18.75,
          bold: true,
          italic: false,
          auraColor: 'transparent',
          color: '#000'
}
      },
width: '100%',
height: '250',
 vAxis: {
      minValue: 0
    },
chartArea:{
    left:30,
    top: 20,
bottom:50,
    width: '100%',
    height: '250',
},
                                    };   ");

            strScript.Append(@"
var chart = new google.visualization.ColumnChart(document.getElementById('divProductCountBarChart'));          
                                chart.draw(data, options);
function selectHandler() {
          var selectedItem = chart.getSelection()[0];
          if (selectedItem) {
            var topping = data.getValue(selectedItem.row, 0);
            if (topping) {
            window.location.replace('./Details.aspx?chartname=ProductWise&SelectedValue=' + topping);
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
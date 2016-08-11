using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class charts_UnAssigned : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();
    helper hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateChart();
    }

    private void GenerateChart()
    {
        dsChartDetails = hr.getUnAssigned();
        Label1.Text = dsChartDetails.Tables[0].Rows[0].Field<int>(0).ToString();

    }
}
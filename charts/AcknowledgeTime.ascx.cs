using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class charts_AcknowledgeTime : System.Web.UI.UserControl
{
    DataSet dsChartDetails = new DataSet();

    helper hr = new helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateChart();
    }

    private void GenerateChart()
    {
        dsChartDetails = hr.getAcknowledgeTime();
        Label1.Text = dsChartDetails.Tables[0].Rows[0].Field<int>(0).ToString();

    }

}
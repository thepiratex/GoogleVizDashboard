<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IncidentGroupAndMonthWise.ascx.cs" Inherits="charts_IncidentGroupAndMonthWise" %>

<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title"><strong>Incident Group Wise</strong></h3>
     
    </div>

        <div class="panel-body">

            <div id="dashboard1_div">

                <div id="filter1_div"></div>
                <br />
                <div id="chart1_div"></div>
            </div>
            <div class="panel-body" id="divNodata" runat="server" visible="false">
                <span id="SpanNoChart" runat="server"></span>
            </div>
        </div>

</div>

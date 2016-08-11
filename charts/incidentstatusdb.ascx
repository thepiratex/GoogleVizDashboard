<%@ Control Language="C#" AutoEventWireup="true" CodeFile="incidentstatusdb.ascx.cs" Inherits="charts_incidentstatusdb" %>


 <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title"><i class="fa fa-long-arrow-right fa-fw"></i>Donut Chart</h3>
    </div>
    <div class="panel-body">
       
        <div id="dashboard_div">

            <div id="filter_div"></div>
            <div id="chart_div"></div>
        </div>
        <div class="panel-body" id="divNodata" runat="server" visible="false">
            <span id="SpanNoChart" runat="server"></span>
        </div>
    </div>
</div>
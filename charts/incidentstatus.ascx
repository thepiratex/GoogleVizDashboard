<%@ Control Language="C#" AutoEventWireup="true" CodeFile="incidentstatus.ascx.cs" Inherits="charts_incidentstatus" %>

<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div class="panel panel-default">

    <div class="panel-heading">
        <div class="row">
            <div class="col-lg-10">
                <h3 class="panel-title"><strong>Incident Status</strong></h3>
            </div>
            <div class="col-lg-2">
                <div class="text-right">
                <div style="cursor:pointer" data-toggle="tooltip" data-placement="right" title="" data-original-title="This chart displays the incident count by their status"><i class="fa fa-question-circle"></i></div>
               </div>
            </div>
        </div>
    </div>
    <div class="panel-body">

        <div class="dashboard_div">

            <div class="filter_div"></div>
            <div id="divIncidentStatus"></div>
        </div>
        <div class="panel-body" id="divNodata" runat="server" visible="false">
            <span id="SpanNoChart" runat="server"></span>
        </div>
    </div>
</div>



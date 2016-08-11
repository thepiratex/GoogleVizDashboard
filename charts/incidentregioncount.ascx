<%@ Control Language="C#" AutoEventWireup="true" CodeFile="incidentregioncount.ascx.cs" Inherits="charts_incidentregioncount" %>


    <div class="panel panel-material-yellow zero-margin">
        <div class="panel-heading">
            <div class="row">

                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <div id="divIncidentCountRegionWise"></div>
                <div class="panel-body" id="divNodata" runat="server" visible="false">
                    <span id="SpanNoChart" runat="server"></span>
                </div>
            </div>

        </div>
        <a href="#">
            <div class="panel-footer">
                <span class="pull-left panel-material-text">Incidents created this week</span>

                <div class="clearfix"></div>
            </div>
        </a>
    </div>


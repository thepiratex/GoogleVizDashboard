<%@ Control Language="C#" AutoEventWireup="true" CodeFile="incidentthisweek.ascx.cs" Inherits="charts_incidentthisweek" %>



    <div class="panel panel-border-green">
        <div class="panel-heading panel-material-green">
            <div class="row">
                <div class="col-xs-3">
                    <i class="fa fa-tasks fa-5x"></i>
                </div>
                <div class="col-xs-9 text-right">
                    <div class="huge">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <a href ="#OpenIncidentsThisWeek">
            <div class="panel-footer">
                <span class="pull-left panel-material-text">Incidents this week</span>
                <div class="text-right panel-material-text"><i class="fa fa-arrow-right"></i></div>
                <div class="clearfix"></div>
            </div>
        </a>
    </div>

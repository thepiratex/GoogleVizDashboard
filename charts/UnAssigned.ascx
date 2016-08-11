<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UnAssigned.ascx.cs" Inherits="charts_UnAssigned" %>

<div class="panel panel-border-lightblue">
        <div class="panel-heading panel-material-lightblue">
            <div class="row">
                <div class="col-xs-3">
                    <i class="fa fa-user-times fa-5x"></i>
                </div>
                <div class="col-xs-9 text-right">
                    <div class="huge">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <a href="#OpenIncidents">
            <div class="panel-footer">
                <span class="pull-left panel-material-text">Unassigned Incidents</span>
                 <div class="text-right panel-material-text"><i class="fa fa-arrow-right"></i></div>
                <div class="clearfix"></div>
            </div>
        </a>
    </div>

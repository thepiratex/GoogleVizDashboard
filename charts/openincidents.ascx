<%@ Control Language="C#" AutoEventWireup="true" CodeFile="openincidents.ascx.cs" Inherits="openincidents" %>



    <div class="panel panel-border-purple">
        <div class="panel-heading panel-material-purple">
            <div class="row">
                <div class="col-xs-3">
                    <i class="fa fa-pencil fa-5x"></i>
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
                <span class="pull-left panel-material-text">Open Incidents</span>
                 <div class="text-right panel-material-text"><i class="fa fa-arrow-right"></i></div>
                <div class="clearfix"></div>
            </div>
        </a>
    </div>


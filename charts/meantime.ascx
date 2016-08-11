<%@ Control Language="C#" AutoEventWireup="true" CodeFile="meantime.ascx.cs" Inherits="charts_meantime" %>

    <div class="panel panel-border-yellow">
        <div class="panel-heading panel-material-yellow">
            <div class="row">
                <div class="col-xs-3">
                    <i class="fa fa-clock-o fa-5x"></i>
                </div>
                <div class="col-xs-9 text-right">
                    <div class="huge">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="panel-footer">
                <span class="pull-left panel-material-text">Avg time to resolve (in hr)</span>
                
                <div class="clearfix"></div>
            </div>
        </div>
    </div>



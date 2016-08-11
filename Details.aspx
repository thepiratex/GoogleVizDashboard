<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <div id="dashboard3_div">
        <div class="row">
            <div class="col-lg-6">

                <div id="date_div" class="goog-menu-vertical"></div>
            </div>
            <div class="col-lg-3">
                <div id="assignee_div"></div>
            </div>
               <div class="col-lg-3">
                <div id="incident_div"></div>
            </div>
        </div> <br />
        <div class="row">
            <div id="chart3_div"></div>
        </div>
    </div>
     <div class="panel-body" id="divNodata" runat="server" visible="false">
            <span id="SpanNoChart" runat="server"></span>
        </div>
</asp:Content>



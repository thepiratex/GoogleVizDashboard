<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Flow.ascx.cs" Inherits="charts_Flow" %>

<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div class="panel panel-default">

    <div class="panel-heading">
         <div class="row">
            <div class="col-lg-11">
                <h3 class="panel-title"><strong>Issue type related to product</strong></h3>
            </div>
            <div class="col-lg-1">
                <div class="text-right">
                    <div style="cursor: pointer" data-toggle="tooltip" data-placement="top" title=""
                         data-original-title="This chart displays what type of issues are related to which product">
                        <i class="fa fa-question-circle"></i>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="panel-body">

        <div id="chart7_div"></div>
    </div>
    <div class="panel-body" id="divNodata" runat="server" visible="false">
        <span id="SpanNoChart" runat="server"></span>
    </div>
</div>

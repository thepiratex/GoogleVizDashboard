<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PriorityTimeline.ascx.cs" Inherits="charts_PriorityTimeline" %>

<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div class="panel panel-default">
    <div class="panel-heading">
        <div class="row">
            <div class="col-lg-11">
                <h3 class="panel-title"><strong>Incident Priority Timeline</strong></h3>
            </div>
            <div class="col-lg-1">
                <div class="text-right">
                    <div style="cursor: pointer" data-toggle="tooltip" data-placement="top" title=""
                         data-original-title="This chart displays incidents opened every month priority wise i.e. Low, Medium or High">
                        <i class="fa fa-question-circle"></i>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div class="panel-body">

        <div id="dashboard5_div">

            <div id="filter5_div"></div>
            <br />
            <div id="chart5_div"></div>
        </div>

        <div class="panel-body" id="divNodata" runat="server" visible="false">
            <span id="SpanNoChart" runat="server"></span>
        </div>
    </div>

</div>

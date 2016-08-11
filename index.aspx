<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Reference Control="~/Charts/meantime.ascx" %>
<%@ Register Src="~/Charts/meantime.ascx" TagName="value" TagPrefix="Meantime" %>
<%@ Register Src="~/Charts/openincidents.ascx" TagName="value" TagPrefix="Openincidents" %>
<%@ Register Src="~/Charts/incidentthisweek.ascx" TagName="value" TagPrefix="incidentsthisweek" %>
<%@ Register Src="~/Charts/incidentstatus.ascx" TagName="value" TagPrefix="incidentstatus" %>
<%@ Register Src="~/Charts/productcount.ascx" TagName="value" TagPrefix="productcount" %>
<%@ Register Src="~/Charts/incidentstatusdb.ascx" TagName="value" TagPrefix="incidentstatusdb" %>
<%@ Register Src="~/Charts/IncidentGroupAndMonthWise.ascx" TagName="value" TagPrefix="IncidentGroupAndMonthWise" %>
<%@ Register Src="~/Charts/incidentMonthlyCount.ascx" TagName="value" TagPrefix="incidentMonthlyCount" %>
<%@ Register Src="~/Charts/incidentDualColumn.ascx" TagName="value" TagPrefix="incidentDualColumn" %>
<%@ Register Src="~/Charts/CriticalCount.ascx" TagName="value" TagPrefix="CriticalCount" %>
<%@ Register Src="~/Charts/PriorityTimeline.ascx" TagName="value" TagPrefix="PriorityTimeline" %>
<%@ Register Src="~/Charts/UnAssigned.ascx" TagName="value" TagPrefix="UnAssigned" %>
<%@ Register Src="~/Charts/AcknowledgeTime.ascx" TagName="value" TagPrefix="AcknowledgeTime" %>
<%@ Register Src="~/Charts/SubmitterCount.ascx" TagName="value" TagPrefix="SubmitterCount" %>
<%@ Register Src="~/Charts/Flow.ascx" TagName="value" TagPrefix="Flow" %>







<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--FIRST ROW START--%>

    <div class="row">
        <div class="col-lg-2 col-sm-6">
            <Openincidents:value ID="openincidents1" runat="server" />
        </div>
        <div class="col-lg-2 col-sm-6">
            <incidentsthisweek:value ID="incidentsthisweek1" runat="server" />
        </div>

        <div class="col-lg-2">

            <Meantime:value ID="meantime1" runat="server" />

        </div>
        <div class="col-lg-2">
            <CriticalCount:value ID="CriticalCount" runat="server" />
        </div>
        <div class="col-lg-2">
            <UnAssigned:value ID="UnAssigned" runat="server" />
        </div>
        <div class="col-lg-2">
            <AcknowledgeTime:value ID="AcknowledgeTime" runat="server" />
        </div>
    </div>
    <%--FIRST ROW END--%>

    <%--SECOND ROW START--%>
    <div class="row">
        <div class="col-lg-4">

            <incidentstatus:value ID="incidentstatus1" runat="server" />

        </div>
        <div class="col-lg-8">

            <PriorityTimeline:value ID="PriorityTimeline" runat="server" />
        </div>
    </div>

    <%--SECOND ROW END--%>
    <div class="row">
        <div class="col-lg-12">
            <%--<incidentstatusdb:value ID="incidentstatusdb1" runat="server" />--%>
            <incidentDualColumn:value ID="incidentDualColumn" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-7">
            <incidentMonthlyCount:value ID="incidentMonthlyCount1" runat="server" />
        </div>
        <div class="col-lg-5">
            <productcount:value ID="productcount" runat="server" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-4">
            <SubmitterCount:value ID="SubmitterCount" runat="server" />
        </div>
        <div class="col-lg-8">
            <Flow:value ID="flow" runat="server" />
        </div>
    </div>


</asp:Content>


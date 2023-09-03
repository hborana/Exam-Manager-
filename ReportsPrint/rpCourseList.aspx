<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpCourseList.aspx.vb" Inherits="ReportsPrint_rpCourseList" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableParameterPrompt="False" EnableDatabaseLogonPrompt="False" ReportSourceID="CrystalReportSource1" ToolPanelView="None" Height="1202px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="E:\project\ExamManagerNew\Reports\rptCourseList.rpt">
            </Report>
        </CR:CrystalReportSource>
</form>

</asp:Content>


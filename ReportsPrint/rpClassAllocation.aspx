<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpClassAllocation.aspx.vb" Inherits="ReportsPrint_rpClassAllocation" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
     <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" ToolPanelView="None" />
     <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="..\Reports\rptClassAllosation.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
       
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyTransactionReport.aspx.cs" Inherits="EnterpriseSolution.WebService.Reports.DailyTransactionReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="DailyTransactionScriptManager" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="DailyTransactionReportViewer" runat="server" Width="100%" Height="592px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WriteOffOfFixedAsset.aspx.cs" Inherits="EnterpriseSolution.WebService.Reports.WriteOffOfFixedAsset" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="WriteOffOfFixedAssetScriptManager" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="WriteOffOfFixedAssetReportViewer" runat="server" Width="100%" Height="592px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>

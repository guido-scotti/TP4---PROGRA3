﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4___PROGRA3.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList 
                ID="dropDownListTemas"
                runat="server" 
                OnSelectedIndexChanged="dropDownListTemas_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <asp:HyperLink
            ID="linkNewPage"
            runat="server">
            Ver mas</asp:HyperLink>
    </form>
</body>
</html>

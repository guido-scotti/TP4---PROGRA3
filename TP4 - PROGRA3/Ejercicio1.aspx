<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4___PROGRA3.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
        <asp:Label ID="lblDestinoInicio" runat="server" BackColor="White" BorderColor="#333333" BorderStyle="None" Font-Bold="True" Font-Names="Bahnschrift" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="True" ForeColor="#3333CC" Text="DESTINO DE INICIO: "></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblProvinciaInicio" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Bahnschrift" Font-Size="Large" ForeColor="Black" Text="PROVINCIA: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlProvinciaInicio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged">
        </asp:DropDownList>
        <div>
            <br />
            <asp:Label ID="lblLocalidadInicio" runat="server" Font-Bold="True" Font-Names="Bahnschrift" Font-Size="Large" ForeColor="Black" Text="LOCALIDAD: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocalidadInicio" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Names="Bahnschrift" Font-Size="Medium" ForeColor="Red" Text="¡No podés elegir la misma provincia de inicio y de llegada!" Visible="False"></asp:Label>
        </div>
        <br />
        <asp:Label ID="lblDestinoFinal" runat="server" Font-Bold="True" Font-Names="Bahnschrift" Font-Size="Large" Font-Underline="True" ForeColor="#3333CC" Text="DESTINO DE LLEGADA: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="lblProvinciaLlegada" runat="server" Font-Bold="True" Font-Names="Bahnschrift" Font-Size="Large" ForeColor="Black" Text="PROVINCIA: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlProvinciaLlegada" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvinciaLlegada_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblLocalidadLlegada" runat="server" Font-Bold="True" Font-Names="Bahnschrift" Font-Size="Large" ForeColor="Black" Text="LOCALIDAD: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlLocalidadLlegada" runat="server">
        </asp:DropDownList>
        </div>
    </form>
</body>
</html>

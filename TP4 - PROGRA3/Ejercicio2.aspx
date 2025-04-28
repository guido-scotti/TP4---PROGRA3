<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4___PROGRA3.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Filtro de Productos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="IdProducto" runat="server">IdProducto</asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Text="Igual a:" Value="=" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Mayor a:" Value=">"></asp:ListItem>
                <asp:ListItem Text="Menor a:" Value="<"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtProducto" runat="server" Width="150px"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="IdCategoria" runat="server">IdCategoria</asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem Text="Igual a:" Value="=" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Mayor a:" Value=">"></asp:ListItem>
                <asp:ListItem Text="Menor a:" Value="<"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtCategoria" runat="server" Width="150px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Filtrar" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Borrar Filtro" OnClick="Button2_Click" />
        </div>

        <asp:GridView ID="GVProductos" runat="server" AutoGenerateColumns="True">
        </asp:GridView>
    </form>
</body>
</html>


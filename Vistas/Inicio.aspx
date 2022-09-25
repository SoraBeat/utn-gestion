<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vistas.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <header>
            <h1>
                Sistema Control de Pagos
            </h1>
        </header>


        <div>   
            <asp:Label ID="Label1" runat="server" Text="Facturado en el dia: "></asp:Label>
            <asp:Label ID="lblFacturacionDiaria" runat="server"></asp:Label>
            <br />

            <asp:Label ID="Label2" runat="server" Text="Facturado diario en distintos metodos de pago: "></asp:Label>
            <asp:GridView ID="grdMetodosPago" runat="server"></asp:GridView>
        </div>

        <br />
        <br />

        <div>
            <a href="ControlPagos2.aspx">Control Pagos</a>
        </div>
    </form>
</body>
</html>

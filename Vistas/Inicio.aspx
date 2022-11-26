<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vistas.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css"/>
    <link rel="stylesheet" href="./StyleSheet3.css" />
    <style type="text/css">
        .auto-style1 {
            width: 10px;
        }
    </style>
</head>

<body>
    <div class="container-fluid">
                <div class="row first">
                    <div class="col">
                       
                        <img src="https://www.frgp.utn.edu.ar/public/frontend/assets/img/logo-utn.png" alt="atras" border="0" width="200px" style="margin-left: 20px;" />

                    </div>
                    <div class="col">
                        <div class="encabezado">

                            <h3 style="font-size: 1.9vw">CONTROL DE PAGOS</h3>
                        </div>
                    </div>
                </div>
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

     <div class="container">
        <footer style="position:absolute;bottom:0;"  class="py-3 my-4">
               
                <p class="text-center text-muted">© 2022 UNIVERSIDAD TECNCOLOGICA NACIONAL, FRGP</p>
        </footer>
    </div>

</body>
</html>

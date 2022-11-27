<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPagos2.aspx.cs" Inherits="Vistas.ControlPagos2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css"/>
    <link rel="stylesheet" href="./StyleSheet3.css" />
    <style>
        .grid{
            font-size: 0.920em;
        }
        .grid table {
            width: 100%;
            max-width: 100%;
            margin-bottom: 40px;
            background-color: transparent;
        }

        .grid tbody {
            display: table-header-group;
            vertical-align: middle;
            border-color: inherit;
            text-align: center;
        }

        .grid tr {
            display: table-row;
            vertical-align: inherit;
            border-color: inherit;
        }

        .grid th {
            color: #fff;
            background-color: #212529;
            border-color: #32383e;
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
        }

        .grid td {
            padding: 0.75rem;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
        }

        .back-to-top {
            position: fixed;
            bottom: 25px;
            right: 25px;
            display: none;
        }
        .auto-style1 {
            width: 983px;
        }
    </style>

</head>
<body>
    <div class="container-xxl">
        <form id="form1" runat="server">
            <div class="container-fluid">
                <div class="row first">
                    <div class="col">
                        <a href="Inicio.aspx">
                            <img src="https://i.ibb.co/5KqDHdN/atras.png" alt="atras" border="0" width="10px" /></a>
                        <img src="https://www.frgp.utn.edu.ar/public/frontend/assets/img/logo-utn.png" alt="atras" border="0" width="200px" style="margin-left: 20px;" />

                    </div>
                    <div class="col">
                        <div class="encabezado">

                             <h3 style="font-size: 1.5vw">CONTROL DE PAGOS</h3>
                        </div>
                    </div>
                </div>

                <div class="row second">
                    <div class="col-9">
                        <p>SELECCIONE CARRERA O CURSO  </p>
                    </div>

                    <div class="col buscador">
                        <asp:TextBox ID="tbxBusquedaTexto" runat="server" class="form-control rounded" placeholder="Buscar por nombre" OnTextChanged="tbxBusquedaTexto_TextChanged"></asp:TextBox>
                        <asp:Button ID="btnBusquedaTexto" class="btn btn-primary buscar" runat="server" Text="Buscar" />
                    </div>
                </div>

                <div class="row third">
                    <div class="col">

                        <asp:RadioButtonList ID="rblistSeleccionCarrCurso" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CellPadding="9" OnSelectedIndexChanged="rblistSeleccionCarrCurso_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Todo">&nbsp; Todo</asp:ListItem>
                            <asp:ListItem Value="Carrera">&nbsp; Carreras</asp:ListItem>
                            <asp:ListItem Value="Curso">&nbsp; Cursos</asp:ListItem>
                            <asp:ListItem Value="Maestria">&nbsp; Maestrías</asp:ListItem>
                        </asp:RadioButtonList>

                    </div>
                </div>

                <div class="row fourth">
                    <div class="col">
                        <asp:CheckBoxList ID="cblCarrera" runat="server" CssClass="chkboxlist" RepeatLayout="Table" RepeatColumns="3" RepeatDirection="Vertical"></asp:CheckBoxList>
                    </div>
                </div>

                <div class="row second">
                    <div class="col">
                        <p>SELECCIONE AÑO / MES  </p>
                    </div>

                </div>
                <div class="row sixth ">
                    <asp:RadioButtonList CssClass="d-flex bd-highlight" ID="rblAnio" runat="server" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </div>
                <div class="row sixth">
                    <asp:CheckBoxList ID="cblMes" runat="server" CssClass="chkboxlistMes" RepeatDirection="Horizontal" CellPadding="5"></asp:CheckBoxList>
                </div>
                <div class="row eighth">
                    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary col-2" Text="BUSCAR" OnClick="btnBuscar_Click" />
                    <asp:Label ID="lblAdvertencia" Style="color: red;" runat="server" Text=""></asp:Label>
                </div>
                <asp:Panel ID="Panel1" runat="server" BackColor="#E0E0E0" ScrollBars="Auto" Style="z-index: 100;" Width="100%">
                    <asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder>
                </asp:Panel>

                <div runat="server" id="resultadosConsultas">
                <div class="row p-4">
                    <asp:Label class="col-2" ID="Label4" runat="server" Text="Informacion filtrada:" Visible="False"></asp:Label>
                    <asp:Button ID="btnExportar" class="btn btn-success btn-sm ml-4 col-2" runat="server" Text="EXPORTAR" OnClick="btnExportar_Click" Visible="False" />
                    <asp:Button ID="btnRefresh" class="btn btn-success btn-sm ml-4 col-2 mx-2" runat="server" Text="VOLVER A BUSCAR" OnClick="btnRefresh_Click" Visible="False" />
                </div>
            </div>
            </div>
        
            
            </form>
    </div>
    
    <div class="container">
        <footer class="py-3 my-4">
                <div class="row text-center">
                    <p class="">
                        <a class="btn btn-outline-dark" href="#"><i class="bi bi-chevron-up"></i></a> 
                    </p>
                </div>
                <p class="text-center text-muted">© 2022 UNIVERSIDAD TECNCOLOGICA NACIONAL, FRGP</p>
        </footer>
    </div>

</body>
    
        
</html>

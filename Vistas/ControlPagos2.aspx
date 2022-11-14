<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPagos2.aspx.cs" Inherits="Vistas.ControlPagos2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="./StyleSheet3.css" />
    <style>
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

                        <h3>CONTROL DE PAGOS</h3>
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
            <div class="row sixth">
                <asp:RadioButtonList ID="rblAnio" runat="server" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </div>
            <div class="row sixth">

                <asp:CheckBoxList ID="cblMes" runat="server" CssClass="chkboxlistMes" RepeatDirection="Horizontal" CellPadding="5"></asp:CheckBoxList>
            </div>

                <div class="row eighth">
                    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" Text="BUSCAR" OnClick="btnBuscar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAdvertencia" Style="color: red;" runat="server" Text=""></asp:Label>
                </div>
                <div class="ResultadosTabla">
                    &nbsp;<asp:PlaceHolder ID="PlaceHolder" runat="server"></asp:PlaceHolder>
                </div>
                <div class="row nineth">
                </div>
            </div>
        </div>
                    <div runat="server" id="resultadosConsultas">
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Informacion filtrada:                                                                          " Visible="False" CssClass="mr-4"></asp:Label>
                        <asp:Button ID="btnExportar" class="btn btn-success btn-sm ml-4" runat="server" Text="EXPORTAR" OnClick="btnExportar_Click" Visible="False" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="btnRefresh" runat="server" CssClass="mt-2" ForeColor="White" Height="24px" ImageUrl="https://www.vhv.rs/dpng/d/570-5706067_update-reload-refresh-refresh-png-icon-transparent-png.png" OnClick="btnRefresh_Click" Visible="False" />
                        <br />
                    </div>
                </body>
    </form>
        
</html>

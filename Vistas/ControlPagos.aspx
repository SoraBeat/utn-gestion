<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPagos.aspx.cs" Inherits="Vistas.ControlPagos"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="./StyleSheet1.css"  />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h2>
                CONTROL DE PAGOS CARRERAS
            </h2>
            <a href="Inicio.aspx"> Volver al inicio </a>

        </header>
        <div>
            <asp:Label ID="lblSeleccion" runat="server" Text="Seleccionar Carrera - Cursos:"></asp:Label>
                <div id="SeleccionCarreraCurso">
                    <div id="OpcionesBusqueda">
                        <asp:RadioButtonList ID="rblistSeleccionCarrCurso" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblistSeleccionCarrCurso_SelectedIndexChanged">
                            <asp:ListItem Selected="True">Todo</asp:ListItem>
                            <asp:ListItem Value="Carrera">Carreras</asp:ListItem>
                            <asp:ListItem Value="Curso">Cursos</asp:ListItem>
                            <asp:ListItem Value="Maestria">Maestrias</asp:ListItem>
                        </asp:RadioButtonList>
                         <asp:Label ID="lblBusquedaTexto" runat="server" Text="Buscar por nombre"></asp:Label>
                         <asp:TextBox ID="tbxBusquedaTexto" runat="server" OnTextChanged="tbxBusquedaTexto_TextChanged"></asp:TextBox>
                        <asp:Button ID="btnBusquedaTexto" runat="server" Text="Buscar" />
                    </div>
               
                   
                    <div style="height: 250px; overflow-y: scroll; width: 100%; background: white;">
                       <asp:CheckBoxList ID="cblCarrera" runat="server" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical"></asp:CheckBoxList>
                    </div>
            </div>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Seleccione año/mes:"></asp:Label>
            <div id="SeleccionFecha">
                <div style="height: 100px; overflow-y: scroll;">
                <asp:CheckBoxList ID="cblAnio" runat="server"></asp:CheckBoxList>
            </div>
            
            <asp:CheckBoxList ID="cblMes" runat="server" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" ></asp:CheckBoxList>
            </div>
            
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Seleccione tipos de pago:"></asp:Label>
            <asp:RadioButtonList ID="rblTipoPago" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">CUOTAS</asp:ListItem>
                <asp:ListItem>MATRICULAS</asp:ListItem>
                <asp:ListItem>AMBAS</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
           <br />
           <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" OnClick="btnBuscar_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblAdvertencia" runat="server" Text=""></asp:Label>
        </div>

        <div runat="server" ID="resultadosConsultas">
            <br />
            <asp:Label ID="Label4" runat="server" Text="Informacion filtrada:" Visible="False"></asp:Label>
            &nbsp;<asp:Button ID="btnExportar" runat="server" Text="Descargar" OnClick="btnExportar_Click" />
            <br />
            <asp:GridView ID="grdBuscado" runat="server" CellPadding="5" CellSpacing="10"></asp:GridView>
        </div>
    </form>
</body>
</html>

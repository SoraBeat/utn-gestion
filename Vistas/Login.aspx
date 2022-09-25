<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>


    <title>Iniciar Sesion</title>
</head>
<body style="background-color:black; color:white;">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row ">

                <div class="col-4"></div>
                <div class="col-4">
                   <div style="margin-top:30%;">
                      <img src="https://i.ibb.co/BT9yNk6/logo-utn-horizontal-copia.png" style="width:350px;" alt="logo-utn-horizontal-copia" border="0" />
                   </div> 
  
    <div style="background-color:#0266af; padding:20px; margin-top:10px; width:350px;">

        <div class="form-group"  >
    <label for="exampleInputUser" style="color:white;">Usuario</label>
    <asp:TextBox runat="server" ID="txtUser" type="text" class="form-control"/>
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1" style="color:white;">Contraseña</label>
    <asp:TextBox runat="server" type="password" class="form-control" id="txtPass"/>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
  </div>
  
        
  
  <asp:Button runat="server" type="submit" Text="Iniciar Sesión" class="btn" style="background-color:black; color:white; width:100%; margin-top:10px" OnClick="btnIniciarSesion" ID="btnIniSes" />

    </div>
     
  </div>
    <div class="modal fade" id="ErrorLogin" tabindex="-1" role="dialog" aria-labelledby="ErrorLogin2" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content" style="background-color:#e30613; color:white;" >
                <div class="modal-header" >
                    <h5 class="modal-title" id="ErrorLogin2"> ERROR </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
            <div class="modal-body">
                 <p>Usuario y/o contraseña incorrectos </p>
            </div>
         
            </div>
        </div>
    </div>

  <div class="col-4"></div>
    </div>
    </div>

            <script type="text/javascript">
            function openModalErrorLogin() {
                $('#ErrorLogin').modal('show');
                $('#ErrorLogin').on('hidden.bs.modal', function () {
                    window.location.href = "Login.aspx"
                })
            }
            </script>

</form>
</body>
</html>

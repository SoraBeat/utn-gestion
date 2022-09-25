using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Drawing;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion(object sender, EventArgs e)
        {
            NegocioSusuarios negusuario = new NegocioSusuarios();
            NegocioSusuarios_subcuentas negusuariosubcuenta = new NegocioSusuarios_subcuentas();
            String clave = negusuario.EncriptarClave(txtPass.Text.Trim());
            Susuarios usuario = new Susuarios(txtUser.Text.Trim(), clave);
            //int validacion=negusuario.verificarUseryPass(usuario);

            Susuarios usu = negusuario.verificarUseryPass(usuario);
            if (usu != null)
            {
               String IdUsuario =negusuario.obtenerIdUsuario(usuario);
                if (Session["usuario"] == null)
                {
                    Session["usuario"] = usu;
                }

                if (Session["IdUsuario"] == null)
                {
                    Session["IdUsuario"] = IdUsuario;
                }

                ///negusuariosubcuenta.obtenerSubcuentasDeUsuario();

                Response.Redirect("Inicio.aspx");
            }
            else
            {
                
                lblMensaje.Text = "Error al iniciar Sesion.";
            }
            /*
            
            if (validacion==2)
            {
                Response.Redirect("Inicio.aspx");

            }
            else if(validacion==3)
            {
                Console.WriteLine("Console text");
            }
            else if (validacion == 4)
            {
                Console.WriteLine("Console text");
            }
            */
        }
    }
}
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Inicio : System.Web.UI.Page
    {

        NegocioIngresos negocioIngresos = new NegocioIngresos();

        protected void Page_Load(object sender, EventArgs e)
        {
            grdMetodosPago.DataSource = negocioIngresos.obtenerDataIngresos();
            grdMetodosPago.DataBind();
            
            string ingresodiario = negocioIngresos.ObtenerIngresosDiarios();
            if (ingresodiario.Equals(""))
            {
                lblFacturacionDiaria.Text = "$" + "0";
            }
            else
            { 
                lblFacturacionDiaria.Text = "$" + ingresodiario;

            }
            
        }
    }
}
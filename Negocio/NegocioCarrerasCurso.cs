using Dao;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Negocio
{
    public class NegocioCarrerasCurso
    {

        private DaoCarrerasCurso dao = new DaoCarrerasCurso();
        private List <string> Carreras_seleccionadas = new List<string>();
        private List <int> Meses_seleccionados = new List<int>();
        private List <int> Anios_seleccionados = new List<int>();

        string TipoPago_seleccionado = "";

        public NegocioCarrerasCurso() {;}

        public void cargarDatosCarrerasCBL(string idusuario,CheckBoxList checkBoxList, string TipoConsulta = "Todo", string TextoBusqueda = "")
        {
            
            checkBoxList.DataSource = dao.listarCarreras(TipoConsulta, TextoBusqueda, idusuario);
            checkBoxList.DataTextField = "cacu_descripcion";
            checkBoxList.DataValueField = "cacu_idcarrcurs";
            checkBoxList.DataBind();
        }

        public void cargarDatosMesesCBL(CheckBoxList checkBoxList)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Numero");
            dt.Columns.Add("Mes");
            dt.Rows.Add("01", "ENERO");
            dt.Rows.Add("02", "FEBRERO");
            dt.Rows.Add("03", "MARZO");
            dt.Rows.Add("04", "ABRIL");
            dt.Rows.Add("05", "MAYO");
            dt.Rows.Add("06", "JUNIO");
            dt.Rows.Add("07", "JULIO");
            dt.Rows.Add("08", "AGOSTO");
            dt.Rows.Add("09", "SEPTIEMBRE");
            dt.Rows.Add("10", "OCTUBRE");
            dt.Rows.Add("11", "NOVIEMBRE");
            dt.Rows.Add("12", "DICIEMBRE");
            checkBoxList.DataSource = dt;
            checkBoxList.DataTextField = "Mes";
            checkBoxList.DataValueField = "Numero";

            checkBoxList.SelectedIndex = 0;

            checkBoxList.DataBind();
         
        }

        public void cargarDatosAñosRBL(RadioButtonList radioButtonList)
        {
            radioButtonList.DataSource = dao.listarFechasCarreras();
            radioButtonList.DataTextField = "Fecha";
            radioButtonList.DataValueField = "IdFecha";

            radioButtonList.SelectedIndex = 0;

            radioButtonList.DataBind();
        }
        
        public DataTable obtenerDatosTabla(String descCarrera,RadioButtonList anio, CheckBoxList meses)
        {
            DataTable tablaResuelta = new DataTable();
            tablaResuelta.Columns.Add("MES");
            tablaResuelta.Columns.Add("C_TOTAL");
            tablaResuelta.Columns.Add("C_PAGAS");
            tablaResuelta.Columns.Add("C_PARCIALES");
            tablaResuelta.Columns.Add("C_IMPAGAS");
            tablaResuelta.Columns.Add("C_$PAGAS");
            tablaResuelta.Columns.Add("C_$PARCIALES");
            tablaResuelta.Columns.Add("C_$IMPAGAS");
            tablaResuelta.Columns.Add("M_TOTAL");
            tablaResuelta.Columns.Add("M_PAGAS");
            tablaResuelta.Columns.Add("M_PARCIALES");
            tablaResuelta.Columns.Add("M_IMPAGAS");
            tablaResuelta.Columns.Add("M_$PAGAS");
            tablaResuelta.Columns.Add("M_$PARCIALES");
            tablaResuelta.Columns.Add("M_$IMPAGAS");


            for (int i=0;i<meses.Items.Count;i++){
                if (meses.Items[i].Selected)
                {
                    tablaResuelta.ImportRow(dao.traerDatos(descCarrera, anio.SelectedItem.Text, meses.Items[i].Value, meses.Items[i].Text));
                }
            }
            return tablaResuelta;
        }



    }
}

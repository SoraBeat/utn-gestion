using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;




namespace Vistas
{
    public partial class ControlPagos2 : System.Web.UI.Page
    {

        NegocioCarrerasCurso negocioCarrerasCurso = new NegocioCarrerasCurso();
        List<DataTable> tablasCarrerasCurso = new List<DataTable>();


        protected void Page_Load(object sender, EventArgs e)
        {
            string idusuario = "";
            if (Session["IdUsuario"] != null)
            {
                idusuario = Session["IdUsuario"].ToString();
            }

            if (!IsPostBack)
            {
                negocioCarrerasCurso.cargarDatosCarrerasCBL(idusuario, cblCarrera);
                negocioCarrerasCurso.cargarDatosMesesCBL(cblMes);
                negocioCarrerasCurso.cargarDatosAñosRBL(rblAnio);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String advertencia ="";
            lblAdvertencia.Text = advertencia;
            

            if (!verificarCBLMarcado(cblCarrera))
            {
                advertencia = "Por favor, seleccione todos los datos";
                lblAdvertencia.Text = advertencia;
            }
            else
            {
                List<GridView> lstGridViews = new List<GridView>();

                for (int i=0;i<cblCarrera.Items.Count;i++){
                    if (cblCarrera.Items[i].Selected)
                    {
                        GridView grid = new GridView();
                        grid.AutoGenerateColumns = true;
                        
                        grid.DataSource =  negocioCarrerasCurso.obtenerDatosTabla(cblCarrera.Items[i].Text, rblAnio, cblMes);
                        grid.DataBind();
                        grid.CssClass = "grid";
                        PlaceHolder.Controls.Add(grid);

                        //titulo
                        GridViewRow rowTitle = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                        TableHeaderCell cellTitle = new TableHeaderCell();
                        cellTitle.Text = cblCarrera.Items[i].Text +"     Periodo: "+rblAnio.SelectedItem.Text+"     Fecha de reporte: " +DateTime.Now.ToString("d");
                        cellTitle.ColumnSpan = 20;
                        rowTitle.Controls.Add(cellTitle);
                        grid.HeaderRow.Parent.Controls.AddAt(0, rowTitle);

                        //subtiulos
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                        TableHeaderCell cell = new TableHeaderCell();
                        cell.Text = "";
                        cell.ColumnSpan = 1;
                        row.Controls.Add(cell);
                        cell = new TableHeaderCell();
                        cell.Text = "CUOTAS";
                        cell.ColumnSpan = 7;
                        row.Controls.Add(cell);
                        cell = new TableHeaderCell();
                        cell.Text = "MATRICULA  ";
                        cell.ColumnSpan = 7;
                        row.Controls.Add(cell);
                        cell = new TableHeaderCell();
                        cell.Text = "BECAS";
                        cell.ColumnSpan = 2;
                        row.Controls.Add(cell);
                        cell = new TableHeaderCell();
                        cell.Text = "DESCUENTOS  ";
                        cell.ColumnSpan = 2;
                        row.Controls.Add(cell);
                        cell = new TableHeaderCell();
                        cell.Text = "TOTAL  ";
                        cell.ColumnSpan = 1;
                        row.Controls.Add(cell);
                        grid.HeaderRow.Parent.Controls.AddAt(1, row);

                        //TOTALES
                        
                        GridViewRow footer = grid.FooterRow;
                        int celdas = footer.Cells.Count;
                        GridViewRow newRow = new GridViewRow(0, 0, footer.RowType, footer.RowState);


                        double[] totales = new double[19] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0 };
                        foreach (GridViewRow celda1 in grid.Rows)
                        {
                            for (int j = 1; j < 20; j++)
                            {
                                if(celda1.Cells[j].Text != "&nbsp;")
                                {
                                    totales[j - 1] += Double.Parse(celda1.Cells[j].Text.Replace("$", ""));
                                }
                                else
                                {
                                    celda1.Cells[j].Text="0";
                                }
                                
                            }

                        }

                        for (int z = 0; z < celdas; z++)
                        {
                            if (z == 0)
                            {
                                TableCell celdaFooter = new TableCell();
                                Label campo = new Label();
                                campo.Text = "TOTALES";
                                celdaFooter.Controls.Add(campo);
                                newRow.Cells.Add(celdaFooter);
                            }
                            else
                            {
                                if(z==5 || z==6 || z==7 || z==12 || z == 13 || z == 14)
                                {
                                    TableCell celdaFooter = new TableCell();
                                    Label campo = new Label();
                                    campo.Text = "$"+totales[z - 1].ToString();
                                    celdaFooter.Controls.Add(campo);
                                    newRow.Cells.Add(celdaFooter);
                                }
                                else
                                {
                                    TableCell celdaFooter = new TableCell();
                                    Label campo = new Label();
                                    campo.Text = totales[z - 1].ToString();
                                    celdaFooter.Controls.Add(campo);
                                    newRow.Cells.Add(celdaFooter);
                                }
                                
                            }

                            

                        }
                        grid.FooterRow.Parent.Controls.Add(newRow);
                        
                        foreach (TableCell celda in grid.HeaderRow.Cells)

                        {
                            celda.Text = celda.Text.Replace("C_", "");
                            celda.Text = celda.Text.Replace("M_", "");
                            celda.CssClass = "col px-2";
                        }
/*
                       

                        lblAdvertencia.Text = totales[13].ToString();*/

                        lstGridViews.Add(grid);
                        Session["lstGridViews"] = lstGridViews;
                        Label4.Visible = true;
                        btnExportar.Visible = true;
                        btnRefresh.Visible = true;
                        btnBuscar.Visible = false;
                        

                    }
                }
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm form = new HtmlForm();
            List<GridView> lstGridViews =(List<GridView>)Session["lstGridViews"];

            try
            {
                foreach (var grid in lstGridViews) {

                    response.Clear();
                    response.AddHeader("Content-Disposition", "attachment; filename= Reporte_Control_Pagos" + ".xls");
                    response.ContentType = "application/vnd.xls";
                    grid.AllowPaging = false;
                    grid.HeaderRow.BackColor = Color.White;



                    foreach (TableCell cell in grid.HeaderRow.Cells)

                    {

                        cell.CssClass = "bhead";


                    }

                    foreach (GridViewRow row in grid.Rows)

                    {

                        row.BackColor = Color.White;

                        foreach (TableCell cell in row.Cells)

                        {

                            if (row.RowIndex % 2 == 0)

                            {

                                cell.CssClass = "bbody";

                            }

                            else

                            {

                                cell.BackColor = grid.RowStyle.BackColor;

                            }

                        }
                    }

                    grid.RenderControl(htw);

                }
                    string style = @"<style> .bhead { 
                         
                          background: #0366b0;
                            color: white;
                            padding: 10px 25px 10px 5px;
                            text-align: left;
                            font-size: 14px;
                            }
                            .bbody {
                                padding: 5px 5px;
                                font-size: 14px;
                            }                    


                        } </style>";

                    response.Write(style);
                    response.Output.Write(sw.ToString());
                    response.End();
                
            }
            catch (Exception ex)
            {
                lblAdvertencia.Text = "No pudo generarse correctamente el excel";
            }


        }

        protected void rblistSeleccionCarrCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            string busqueda = tbxBusquedaTexto.Text.Trim().ToUpper();
            string idusuario = "";
            if (Session["IdUsuario"] != null)
            {
                idusuario = Session["IdUsuario"].ToString();
            }
            negocioCarrerasCurso.cargarDatosCarrerasCBL(idusuario, cblCarrera, rblistSeleccionCarrCurso.SelectedValue, busqueda);
        }

        protected void tbxBusquedaTexto_TextChanged(object sender, EventArgs e)
        {
            string busqueda = tbxBusquedaTexto.Text.Trim().ToUpper();
            string idusuario = "";
            if (Session["IdUsuario"] != null)
            {
                idusuario = Session["IdUsuario"].ToString();
            }
            negocioCarrerasCurso.cargarDatosCarrerasCBL(idusuario, cblCarrera, rblistSeleccionCarrCurso.SelectedValue, busqueda);
        }

        protected bool verificarCBLMarcado(CheckBoxList cbl)
        {

            foreach (ListItem li in cbl.Items)
            {
                if (li.Selected) return true;
            }

            return false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Session["lstGridViews"] = null;
            Label4.Visible = false;
            btnRefresh.Visible = false;
            btnExportar.Visible = false;
            btnBuscar.Visible = true;
            cblMes.ClearSelection();
            cblCarrera.ClearSelection();
            String idusuario = Session["IdUsuario"].ToString();
            negocioCarrerasCurso.cargarDatosCarrerasCBL(idusuario, cblCarrera);
            rblistSeleccionCarrCurso.SelectedIndex = 0;
            rblAnio.SelectedIndex = 0;
            tbxBusquedaTexto.Text = "";

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Npgsql;

namespace Dao
{
    public class DaoCarrerasCurso
    {
        private AccesoDatos accesoDatos = new AccesoDatos();

        public DaoCarrerasCurso() {; }

        public DataTable listarCarreras(string filtrosTipoCarrCurs, string textoBusqueda, string idusuario)
        {
            DataTable dt = new DataTable();

            string consulta;

            if (filtrosTipoCarrCurs == "Todo")
            {
                /*
                consulta = "SELECT cacu_idcarrcurs, cacu_descripcion FROM carrerascursos " +
                "WHERE (cacu_tipocarrcurs = 'CARRERA' OR cacu_tipocarrcurs = 'CURSO'  OR cacu_tipocarrcurs = 'MAESTRIA') " +
                "AND (cacu_descripcion NOT LIKE '%NO USAR%') ";

                if(textoBusqueda != "")
                {
                    consulta += $"AND (cacu_descripcion LIKE '%{textoBusqueda}%') ";
                }

                consulta += "ORDER BY cacu_descripcion";
                */

                /// agrega solo con ID de usuario
                consulta = "SELECT cacu_idcarrcurs, cacu_descripcion FROM carrerascursos INNER JOIN susuarios_subcuentas ON carrerascursos.cacu_idsubcuen = susuarios_subcuentas.ussu_idsubcuenta WHERE ussu_idusuario = '" + idusuario + "'  AND (cacu_descripcion NOT LIKE '%NO USAR%') ";


                if (textoBusqueda != "")
                {
                    consulta += $"AND (cacu_descripcion LIKE '%{textoBusqueda}%') ";
                }
                consulta += "ORDER BY cacu_descripcion";

                dt = accesoDatos.ObtenerTabla("Carreras", consulta);
                // return dt;
            }
            else if (filtrosTipoCarrCurs == "Carrera")
            {
                consulta = "SELECT cacu_idcarrcurs, cacu_descripcion FROM carrerascursos INNER JOIN susuarios_subcuentas ON carrerascursos.cacu_idsubcuen = susuarios_subcuentas.ussu_idsubcuenta WHERE ussu_idusuario = '" + idusuario + "' AND cacu_tipocarrcurs = 'CARRERA' AND (cacu_descripcion NOT LIKE '%NO USAR%') ";

                if (textoBusqueda != "")
                {
                    consulta += $"AND (cacu_descripcion LIKE '%{textoBusqueda}%') ";
                }

                consulta += "ORDER BY cacu_descripcion";

                dt = accesoDatos.ObtenerTabla("Carreras", consulta);
                //return dt;
            }
            else if (filtrosTipoCarrCurs == "Curso")
            {
                consulta = "SELECT cacu_idcarrcurs, cacu_descripcion FROM carrerascursos INNER JOIN susuarios_subcuentas ON carrerascursos.cacu_idsubcuen = susuarios_subcuentas.ussu_idsubcuenta WHERE ussu_idusuario = '" + idusuario + "' AND cacu_tipocarrcurs = 'CURSO' AND cacu_descripcion NOT LIKE '%NO USAR%'";



                if (textoBusqueda != "")
                {
                    consulta += $"AND (cacu_descripcion LIKE '%{textoBusqueda}%') ";
                }

                consulta += "ORDER BY cacu_descripcion";

                dt = accesoDatos.ObtenerTabla("Carreras", consulta);
                // return dt;
            }
            else if (filtrosTipoCarrCurs == "Maestria")
            {
                consulta = "SELECT cacu_idcarrcurs, cacu_descripcion FROM carrerascursos INNER JOIN susuarios_subcuentas ON carrerascursos.cacu_idsubcuen = susuarios_subcuentas.ussu_idsubcuenta WHERE ussu_idusuario = '" + idusuario + "' AND cacu_tipocarrcurs = 'MAESTRIA'" +
                "AND cacu_descripcion NOT LIKE '%NO USAR%' ";

                if (textoBusqueda != "")
                {
                    consulta += $"AND (cacu_descripcion LIKE '%{textoBusqueda}%') ";
                }

                consulta += "ORDER BY cacu_descripcion";

                dt = accesoDatos.ObtenerTabla("Carreras", consulta);
                //  return dt;
            }
            return dt;
        }

        public DataTable listarFechasCarreras()
        {

            DataTable dt = new DataTable();

            //La consulta devuelve una tabla con 2 columnas, la primera con el id del año y otra con el año
            // Ejemplo:
            // 1    2019
            // 2    2020

            string consulta = "SELECT ROW_NUMBER() OVER(ORDER BY EXTRACT(YEAR FROM ccal_fechaalta)) AS \"IdFecha\", " +
                "EXTRACT(YEAR FROM ccal_fechaalta) AS \"Fecha\" " +
                "FROM carrerascursosalta " +
                "GROUP BY \"Fecha\" " +
                "ORDER BY \"Fecha\" DESC";

            dt = accesoDatos.ObtenerTabla("Fechas", consulta);
            return dt;
        }
        public DataTable listarCarreraxFecha(CarrerasCurso _Carrera)
        {
            //FALTANTES: 
            /*
                Ver como hacer para mandar por parametros la fecha correspondiente, y hacer el pedido por varias carreras
                tanto como para varios meses y años.
                tambien hay que ver la consulta pedir la cantidad de alumnos y demas, esta en la imagen, las relaciones ya estan armadas
                
             */

            DataTable dt = new DataTable();

            /* string consulta = $"SELECT carrerascursos.cacu_descripcion as DESCRIPCION FROM carrerascursos WHERE carrerascursos.cacu_idcarrcurs = '{_Carrera.Id1}'";*/


            string consulta = "select carrerascursos.cacu_descripcion, count(pagoalumnos.paal_idalucarrcurs) from carrerascursos  " +
            "inner join carrerascursosalta " +
            "on carrerascursosalta.ccal_idcarrcurs = carrerascursos.cacu_idcarrcurs " +
            " inner join alumnoscarreracurso" +
            " on alumnoscarreracurso.alcc_idccalta = carrerascursosalta.ccal_idccalta" +
            " inner join pagoalumnos" +
            " on pagoalumnos.paal_idalucarrcurs = alumnoscarreracurso.alcc_idalucarrcurs" +
            " where carrerascursos.cacu_idcarrcurs = '4919999' and carrerascursosalta.CCAL_estado = 'EJECUCION' " + //id de la carrera interpolado
            " and EXTRACT(MONTH FROM pagoalumnos.paal_fechadeb) = 7 and EXTRACT(YEAR FROM pagoalumnos.paal_fechadeb) = 2020 " + //meses y años interpolados
            " group by carrerascursos.cacu_descripcion";

            dt = accesoDatos.ObtenerTabla("Carreras", consulta);

            return dt;
        }
        public DataTable TablaCuotas() // Pasar en el parametro los datos
        {
            DataTable dt = new DataTable();

            string consulta = "SELECT SUM(CASE WHEN paal_estado = 'PAGO' THEN 1 ELSE 0 END ) as \"Pago_Cuotas\" , " +
            "SUM(CASE WHEN paal_estado = 'IMPAGO' THEN 1 ELSE 0 END) as \"Impago_Cuotas\", " +
            "sSUM(CASE WHEN paal_estado = 'PARCIAL' THEN 1 ELSE 0 END) as \"Parcial_Cuotas\", " +
            "FROM pagoalumnos AS pag " +
            "INNER JOIN alumnoscarreracurso AS alcc " +
            "ON pag.paal_idalucarrcurs = alcc.alcc_idalucarrcurs " +
            "INNER JOIN carrerascursosalta as ccalta " +
            "ON alcc.alcc_idccalta = ccalta.ccal_idccalta " +
            "INNER JOIN carrerascursos as ccursos " +
            "ON ccursos.cacu_idcarrcurs = ccalta.ccal_idcarrcurs " +
            "where ccalta.ccal_estado = 'EJECUCION' " +
            "and EXTRACT(MONTH FROM pag.paal_fechadeb) = 11 and EXTRACT(YEAR FROM pag.paal_fechadeb) = 2021 " + // Interpolar fechas 
            "and ccursos.cacu_idcarrcurs = '4920001' " + // Interpolar id 
            "and pag.paal_tipopago = 'CUOTA'";

            dt = accesoDatos.ObtenerTabla("Carreras", consulta);

            return dt;
        }
        public DataTable TablaMatriculas() // Pasar en el parametro los datos 
        {
            DataTable dt = new DataTable();

            string consulta = "SELECT SUM(CASE WHEN paal_estado = 'PAGO' THEN 1 ELSE 0 END ) as \"Pago_Matriculas\" ," +
            "SUM(CASE WHEN paal_estado = 'IMPAGO' THEN 1 ELSE 0 END) as \"Impago_Matriculas\"," +
            "SUM(CASE WHEN paal_estado = 'PARCIAL' THEN 1 ELSE 0 END) as \"Parcial_Matriculas\" ," +
            "FROM pagoalumnos AS pag " +
            "INNER JOIN alumnoscarreracurso AS alcc" +
            "ON pag.paal_idalucarrcurs = alcc.alcc_idalucarrcurs" +
            "INNER JOIN carrerascursosalta as ccalta" +
            "ON alcc.alcc_idccalta = ccalta.ccal_idccalta" +
            "INNER JOIN carrerascursos as ccursos" +
            "ON ccursos.cacu_idcarrcurs = ccalta.ccal_idcarrcurs" +
            "where ccalta.ccal_estado = 'EJECUCION'" +
            "and EXTRACT(MONTH FROM pag.paal_fechadeb) = 12 and EXTRACT(YEAR FROM pag.paal_fechadeb) = 2021" + // Interpolar fechas
            "and ccursos.cacu_idcarrcurs = '5356551'" + // Interpolar id 
            "and pag.paal_tipopago = 'MATRICULA'";

            dt = accesoDatos.ObtenerTabla("Carreras", consulta);
            NpgsqlCommand comando = new NpgsqlCommand();

            return dt;
        }

        private void ArmarParametrosCarrCurso(ref NpgsqlCommand Comando, int Mes, int Año, String idcarreraCurso)
        {
            NpgsqlParameter SqlParametros = new NpgsqlParameter();

            SqlParametros = Comando.Parameters.Add("@mes", NpgsqlTypes.NpgsqlDbType.Integer);
            SqlParametros.Value = Mes;

            SqlParametros = Comando.Parameters.Add("@anio", NpgsqlTypes.NpgsqlDbType.Integer);
            SqlParametros.Value = Año;

            SqlParametros = Comando.Parameters.Add("@idcarrcurso", NpgsqlTypes.NpgsqlDbType.Varchar, 10);
            SqlParametros.Value = idcarreraCurso;

        }

        private void ArmarParametrosCarrCursoxAnio(ref NpgsqlCommand Comando, int Año, String idcarreraCurso)
        {
            NpgsqlParameter SqlParametros = new NpgsqlParameter();

            SqlParametros = Comando.Parameters.Add("@anio", NpgsqlTypes.NpgsqlDbType.Integer);
            SqlParametros.Value = Año;

            SqlParametros = Comando.Parameters.Add("@idcarrcurso", NpgsqlTypes.NpgsqlDbType.Varchar, 10);
            SqlParametros.Value = idcarreraCurso;

        }

        public DataTable ObtenerAlumnosCarrCursoxAnio(int Año, String idcarreraCurso)
        {
            NpgsqlCommand comando = new NpgsqlCommand();
            ArmarParametrosCarrCursoxAnio(ref comando, Año, idcarreraCurso);

            return accesoDatos.EjecutarProcedimientoAlmacenado_DT(comando, "function_obtenerAlumnosCarrCursxAnio");

        }

        public DataTable ObtenerCuotasCarrCursoxAnio(int Año, String idcarreraCurso)
        {
            NpgsqlCommand comando = new NpgsqlCommand();
            ArmarParametrosCarrCursoxAnio(ref comando, Año, idcarreraCurso);

            return accesoDatos.EjecutarProcedimientoAlmacenado_DT(comando, "function_obtenerCuotasCarrCursxAnio");

        }

        public DataTable ObtenerMatriculasCarrCursoxAnio(int Año, String idcarreraCurso)
        {
            NpgsqlCommand comando = new NpgsqlCommand();
            ArmarParametrosCarrCursoxAnio(ref comando, Año, idcarreraCurso);

            return accesoDatos.EjecutarProcedimientoAlmacenado_DT(comando, "function_obtenerMatriculasCarrCursxAnio");

        }

        public DataTable ObtenerAlumnosCarrCursoxFecha(int Mes, int Año, String idcarreraCurso)
        {
            NpgsqlCommand comando = new NpgsqlCommand();
            ArmarParametrosCarrCurso(ref comando, Mes, Año, idcarreraCurso);

            return accesoDatos.EjecutarProcedimientoAlmacenado_DT(comando, "function_obteneralumnoscarrcursxfecha");

        }

        public DataTable ObtenerCuotasCarrCursoxFecha(int Mes, int Año, String idcarreraCurso)
        {
            NpgsqlCommand comando = new NpgsqlCommand();
            ArmarParametrosCarrCurso(ref comando, Mes, Año, idcarreraCurso);

            return accesoDatos.EjecutarProcedimientoAlmacenado_DT(comando, "function_obtenerCuotasCarrCursxFecha");

        }
        public DataTable ObtenerMatriculasCarrCursoxFecha(int Mes, int Año, String idcarreraCurso)
        {
            NpgsqlCommand comando = new NpgsqlCommand();
            ArmarParametrosCarrCurso(ref comando, Mes, Año, idcarreraCurso);

            return accesoDatos.EjecutarProcedimientoAlmacenado_DT(comando, "function_obtenerMatriculasCarrCursxFecha");

        }

        public DataRow traerDatos(String descCarrera, String anio, String mes,String nombreMes)
        {
            DataRow dt;
            string consulta = "SELECT ('"+ nombreMes + "') AS MES " +
                ",( " +
                "SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '"+anio+"' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '"+mes+"' AND paal_tipopago = 'CUOTA') AS C_TOTAL " +
                ",( " +
                "SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'CUOTA' AND (paal_importecuota+paal_intereses=paal_importepago OR paal_estado='PAGO')) AS C_PAGAS " +
                ",(SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'CUOTA' AND ((paal_importecuota+paal_intereses>paal_importepago AND paal_importepago>'0') OR paal_estado='PARCIAL')) AS C_PARCIALES " +
                ",(SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'CUOTA' AND (paal_importepago='0' OR paal_estado='IMPAGO')) AS C_IMPAGAS " +
                ",(SELECT CONCAT('$',CAST(COALESCE(SUM(paal_importepago),0) as varchar(50))) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'CUOTA' AND (paal_importecuota+paal_intereses=paal_importepago OR paal_estado='PAGO')) AS C_$PAGAS " +
                ",(SELECT CONCAT('$',CAST(COALESCE(SUM(paal_importepago),0) as varchar(50))) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'CUOTA' AND ((paal_importecuota+paal_intereses>paal_importepago AND paal_importepago>'0') OR paal_estado='PARCIAL')) AS C_$PARCIALES " +
                ",(SELECT CONCAT('$',CAST(COALESCE(SUM(paal_importecuota+paal_intereses-paal_importepago),0) as varchar(50))) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'CUOTA' AND (paal_importepago='0' OR paal_estado='IMPAGO')) AS C_$IMPAGAS " +
                ",( " +
                "SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'MATRICULA') AS M_TOTAL " +
                ",( " +
                "SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'MATRICULA' AND (paal_importecuota+paal_intereses=paal_importepago OR paal_estado='PAGO')) AS M_PAGAS " +
                ",(SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'MATRICULA' AND ((paal_importecuota+paal_intereses>paal_importepago AND paal_importepago>'0') OR paal_estado='PARCIAL')) AS M_PARCIALES " +
                ",(SELECT COUNT(*) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'MATRICULA' AND (paal_importepago='0' OR paal_estado='IMPAGO')) AS M_IMPAGAS " +
                ",(SELECT CONCAT('$',CAST(COALESCE(SUM(paal_importepago),0) as varchar(50))) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'MATRICULA' AND (paal_importecuota+paal_intereses=paal_importepago OR paal_estado='PAGO')) AS M_$PAGAS " +
                ",(SELECT CONCAT('$',CAST(COALESCE(SUM(paal_importepago),0) as varchar(50))) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'MATRICULA' AND ((paal_importecuota+paal_intereses>paal_importepago AND paal_importepago>'0') OR paal_estado='PARCIAL')) AS M_$PARCIALES " +
                ",(SELECT CONCAT('$',CAST(COALESCE(SUM(paal_importecuota+paal_intereses-paal_importepago),0) as varchar(50))) FROM pagoalumnos " +
                "INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND (SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND (SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "' AND paal_tipopago = 'MATRICULA' AND (paal_importepago='0' OR paal_estado='IMPAGO')) AS M_$IMPAGAS " +
                ",(SELECT COUNT(alcc_tipodescuento) FROM alumnoscarreracurso INNER JOIN pagoalumnos ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                 "WHERE alcc_tipodescuento = 'COMPLETA' AND cacu_descripcion = '" + descCarrera + "' AND(SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND(SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "') AS BECA_COMPLETA " +
                ",(SELECT COUNT(alcc_tipodescuento) FROM alumnoscarreracurso INNER JOIN pagoalumnos ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE alcc_tipodescuento = 'MITAD' AND cacu_descripcion = '" + descCarrera + "' AND(SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND(SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "') AS BECA_MITAD " +
                ",(SELECT SUM(paal_importepago) FROM pagoalumnos INNER JOIN alumnoscarreracurso ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND(SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND(SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "') AS TOTAL_BECAS " +
                ",(SELECT COUNT(alcc_descuentocuota) FROM alumnoscarreracurso " +
                "INNER JOIN pagoalumnos ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta " +
                "INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE alcc_descuentocuota > 0 AND cacu_descripcion = '" + descCarrera + "' AND(SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND(SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "') AS CANT_DESCUENTO " +
                ",(SELECT SUM(alcc_descuentocuota) FROM alumnoscarreracurso INNER JOIN pagoalumnos ON alcc_idalucarrcurs = paal_idalucarrcurs " +
                "INNER JOIN carrerascursosalta ON alcc_idccalta = ccal_idccalta INNER JOIN carrerascursos ON ccal_idcarrcurs = cacu_idcarrcurs " +
                "WHERE cacu_descripcion = '" + descCarrera + "' AND(SELECT EXTRACT(YEAR FROM paal_fechadeb)) = '" + anio + "' AND(SELECT EXTRACT(MONTH FROM paal_fechadeb)) = '" + mes + "') AS TOTAL_DESCUENTO  ";

            dt = accesoDatos.ObtenerFila("pagoAlumnos", consulta);
            return dt;
        }


    }


}

using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioIngresos
    {
        private DaoIngresos dao = new DaoIngresos();

        public DataTable obtenerDataIngresos()
        {
            DataTable dt = new DataTable();
            dt = dao.listarIngresos();
            return dt;
        }

        public string ObtenerIngresosDiarios()
        {
            DataTable dt = dao.ObtenerTotalIngresosDiarios();
            string totalIngresosDiarios = dt.Rows[0][0].ToString();
            return totalIngresosDiarios;
        }
    }
}

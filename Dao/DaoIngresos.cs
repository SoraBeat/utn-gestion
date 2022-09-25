using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoIngresos
    {
        private AccesoDatos accesoDatos = new AccesoDatos();

        public DaoIngresos() {; }

        DateTime fechahoy = DateTime.Today;

        public DataTable listarIngresos()
        {
            

            DataTable dt = new DataTable();
            ///select sum(ingr_importepago) as Total, timo_descripcion as Tipo_moneda 
            //from ingresos
            //inner join efectivo on ingr_idingreso = efec_idoperacion
            //inner
            //join tipomoneda on timo_idtipomoneda = efec_tipomoneda
            //where ingr_fecha = TO_DATE('fecha.toString(yyyyMMdd)', 'YYYYMMDD')
            //group by timo_descripcion
            string consulta = $"select sum(ingr_importepago) as Total, timo_descripcion as Tipo_moneda from ingresos  inner join efectivo on ingr_idingreso = efec_idoperacion" +
                $" inner join tipomoneda on timo_idtipomoneda = efec_tipomoneda where ingr_fecha = TO_DATE('" + fechahoy.ToString("yyyyMMdd") + "' , 'YYYYMMDD') group by timo_descripcion";
            dt = accesoDatos.ObtenerTabla("ingresos", consulta);

            return dt;
        }

        public DataTable ObtenerTotalIngresosDiarios()
        {
            // select sum(ingr_importepago) from ingresos where ingr_fecha = TO_DATE('fecha.ToString("yyyyMMdd")', 'YYYYMMDD')
            string consulta = "select sum(ingr_importepago) from ingresos where ingr_fecha = TO_DATE(' " +  fechahoy.ToString("yyyyMMdd") +   "', 'YYYYMMDD')";
            DataTable dt = accesoDatos.ObtenerTabla("ingresos", consulta);
            return dt;
        }
    }
}

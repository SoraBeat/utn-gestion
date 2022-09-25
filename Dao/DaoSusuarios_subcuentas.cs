using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class DaoSusuarios_subcuentas
    {

        private AccesoDatos accesoDatos = new AccesoDatos();

        public DaoSusuarios_subcuentas(){; }

        public DataTable obtenerSubcuentasDeUsuario()
        {

            String consulta = "SELECT ussu_idsubcuenta FROM susuarios_subcuentas WHERE ussu_idusuario = '1'";
            return accesoDatos.ObtenerTabla("susuarios_subcuentas", consulta);

        }


    }
}

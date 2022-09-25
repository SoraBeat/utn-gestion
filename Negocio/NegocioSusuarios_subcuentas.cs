using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;

namespace Negocio
{
    public class NegocioSusuarios_subcuentas
    {

        DaoSusuarios_subcuentas DaoSusuarios_subcuentas = new DaoSusuarios_subcuentas();
        public DataTable obtenerSubcuentasDeUsuario()
        {
            return DaoSusuarios_subcuentas.obtenerSubcuentasDeUsuario();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Dao
{
    class AccesoDatos
    {
        // Cambiar para conectarse a la BD

        private const String port = "5432";
        private const String dataBase = "proy_sacc";
        private const String username = "postgres";
        private const String password = "1234";

        // password = "root"
        // dataBase = "sacc"

        private String rutaDB = $"Server=localhost;Port={port};Database={dataBase};" +
            $"User Id={username};Password={password};";

        public AccesoDatos() { ; }

        private NpgsqlConnection ObtenerConexion()
        {
            NpgsqlConnection conn = new NpgsqlConnection(rutaDB);
            if (!String.IsNullOrWhiteSpace(rutaDB))
            {
                try
                {
                    conn.Open();
                
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    conn.Close();
                }

            }
            return conn;
        }

        private NpgsqlDataAdapter ObtenerAdapter(String consultaSQL, NpgsqlConnection sqlcn)
        {
            NpgsqlDataAdapter adaptador;
            try
            {
                adaptador = new NpgsqlDataAdapter(consultaSQL, sqlcn);
                return adaptador;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable ObtenerTabla(String nombreTabla, String SQL)
        {
            DataSet dataset = new DataSet();
            NpgsqlConnection conexion = ObtenerConexion();
            NpgsqlDataAdapter adapter = ObtenerAdapter(SQL, conexion);
            adapter.Fill(dataset, nombreTabla);
            conexion.Close();
            return dataset.Tables[nombreTabla];
        }
        public DataRow ObtenerFila(String nombreTabla, String SQL)
        {
            DataSet dataset = new DataSet();
            NpgsqlConnection conexion = ObtenerConexion();
            NpgsqlDataAdapter adapter = ObtenerAdapter(SQL, conexion);
            adapter.Fill(dataset, nombreTabla);
            conexion.Close();
            return dataset.Tables[nombreTabla].Rows[0];
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            NpgsqlConnection Conexion = ObtenerConexion();
            NpgsqlCommand cmd = new NpgsqlCommand(consulta, Conexion);

        
            NpgsqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }

        public int EjecutarProcedimientoAlmacenado(NpgsqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            NpgsqlConnection Conexion = ObtenerConexion();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        //Ejecuta un sp pero devuelve datos en vez de las filas cambiadas.
        public DataTable EjecutarProcedimientoAlmacenado_DT(NpgsqlCommand Comando, String NombreSP)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection Conexion = ObtenerConexion();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            dt.Load(cmd.ExecuteReader());

            Conexion.Close();
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Susuarios
    {
        private String usua_idusuario;
        private String usua_user;
        private String usua_password;
        private String usua_apellido;
        private String usua_nombre;
        private String usua_baja;
        private String usua_clave;

        public Susuarios() {; }

        public Susuarios(String nombreUsuario, String contrasenia)
        {
            this.usua_user = nombreUsuario;
            this.usua_clave = contrasenia;
        }

        public string Idusuario { get=> usua_idusuario; set=> usua_idusuario=value; }
        public string User { get => usua_user; set => usua_user = value; }
        public string Password { get => usua_password; set => usua_password = value; }
        public string Apellido { get => usua_apellido; set => usua_apellido = value; }
        public string Nombre { get => usua_nombre; set => usua_nombre = value; }
        public string Baja { get => usua_baja; set => usua_baja = value; }
        public string Clave { get => usua_clave; set => usua_clave = value; }

    }

}

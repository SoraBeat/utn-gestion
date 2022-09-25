using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Susuarios_subcuentas
    {
        private String ussu_idusuariosubcuenta;
        private String ussu_idusuario;
        private String ussu_idsubcuenta;

        public Susuarios_subcuentas() {; }

        public string Ussu_idusuariosubcuenta { get => ussu_idusuariosubcuenta; set => ussu_idusuariosubcuenta = value; }
        public string Ussu_idusuario { get => ussu_idusuario; set => ussu_idusuario = value; }

        public string Ussu_idsubcuenta { get => ussu_idsubcuenta; set => ussu_idsubcuenta = value; }
    }
}

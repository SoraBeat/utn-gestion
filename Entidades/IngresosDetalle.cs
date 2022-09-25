using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IngresosDetalle
    {

        private String Id;
        private Ingresos idIngreso;
        private String idSubcuenta;
        private String descripcion;
        private double importePagado;
        private String tipoRelacionado;
        private String idRelacionado;
   
       public IngresosDetalle() {; }

        public string Id1 { get => Id; set => Id = value; }
        public Ingresos IdIngreso { get => idIngreso; set => idIngreso = value; }
        public string IdSubcuenta { get => idSubcuenta; set => idSubcuenta = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double ImportePagado { get => importePagado; set => importePagado = value; }
        public string TipoRelacionado { get => tipoRelacionado; set => tipoRelacionado = value; }
        public string IdRelacionado { get => idRelacionado; set => idRelacionado = value; }
    }
}

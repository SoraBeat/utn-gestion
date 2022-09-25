using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoMoneda
    {

        private String Id;
        private String descripcion;
        private double cambio;

        public TipoMoneda() {; }

        public string Id1 { get => Id; set => Id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Cambio { get => cambio; set => cambio = value; }
    }
}

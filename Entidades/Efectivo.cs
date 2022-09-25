using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Efectivo
    {
        private String Id;
        private Ingresos idOperacion;
        private TipoMoneda tipoMoneda;
        private double cambio;
        private double importeOriginal;
        private double importePesos;
        private String entrada;
        private String salida;
        private int listo;
  
        public Efectivo() {; }

        public string Id1 { get => Id; set => Id = value; }
        public Ingresos IdOperacion { get => idOperacion; set => idOperacion = value; }
        public TipoMoneda TipoMoneda { get => tipoMoneda; set => tipoMoneda = value; }
        public double Cambio { get => cambio; set => cambio = value; }
        public double ImporteOriginal { get => importeOriginal; set => importeOriginal = value; }
        public double ImportePesos { get => importePesos; set => importePesos = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string Salida { get => salida; set => salida = value; }
        public int Listo { get => listo; set => listo = value; }
 
    }
}

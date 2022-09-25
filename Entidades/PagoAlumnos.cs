using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PagoAlumnos
    {
        private String Id;
        private AlumnosCarrerasCurso idAluCarrCurs;
        private String fechaDeb;
        private String tipoPago;
        private String descripcion;
        private double importeCuota;
        private double intereses;
        private double importePago;
        private String Estado;
   

        public PagoAlumnos() {; }

        public string Id1 { get => Id; set => Id = value; }
        public AlumnosCarrerasCurso IdAluCarrCurs { get => idAluCarrCurs; set => idAluCarrCurs = value; }
        public string FechaDeb { get => fechaDeb; set => fechaDeb = value; }
        public string TipoPago { get => tipoPago; set => tipoPago = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double ImporteCuota { get => importeCuota; set => importeCuota = value; }
        public double Intereses { get => intereses; set => intereses = value; }
        public double ImportePago { get => importePago; set => importePago = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
    }
}

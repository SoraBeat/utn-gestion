using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnosCarrerasCurso
    {
        private String Id;
        private String idAlumno;
        private String idccAlta;
        private String legajo;
        private String estado;
        private String fechaEgreso;
        private double descuentoCuota;
        private String tipoDescuento;
        private int cantCuotasCob;
        private String duracionDesc;
   

        public AlumnosCarrerasCurso() {; }

        public string Id1 { get => Id; set => Id = value; }
        public string IdAlumno { get => idAlumno; set => idAlumno = value; }
        public string IdccAlta { get => idccAlta; set => idccAlta = value; }
        public string Legajo { get => legajo; set => legajo = value; }
        public string Estado { get => estado; set => estado = value; }
        public string FechaEgreso { get => fechaEgreso; set => fechaEgreso = value; }
        public double DescuentoCuota { get => descuentoCuota; set => descuentoCuota = value; }
        public string TipoDescuento { get => tipoDescuento; set => tipoDescuento = value; }
        public int CantCuotasCob { get => cantCuotasCob; set => cantCuotasCob = value; }
        public string DuracionDesc { get => duracionDesc; set => duracionDesc = value; }
    }
}

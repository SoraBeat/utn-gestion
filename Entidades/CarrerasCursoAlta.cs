using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CarrerasCursoAlta
    {

        private String Id;
        private CarrerasCurso idCarreraCurso;
        private String idProfesor;
        private String fechaInicio;
        private String fechaFin;
        private String turno;
        private String horario;
        private String dias;
        private double sueldoProfesor;
        private int cantidadCuotasCob;
        private String estado;
        private String fechaAlta;
        private String descripcion;
        private String fechaUltdeb;

        public CarrerasCursoAlta() {; }

        public string Id1 { get => Id; set => Id = value; }
        public CarrerasCurso IdCarreraCurso { get => idCarreraCurso; set => idCarreraCurso = value; }
        public string IdProfesor { get => idProfesor; set => idProfesor = value; }
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Turno { get => turno; set => turno = value; }
        public string Horario { get => horario; set => horario = value; }
        public string Dias { get => dias; set => dias = value; }
        public double SueldoProfesor { get => sueldoProfesor; set => sueldoProfesor = value; }
        public int CantidadCuotasCob { get => cantidadCuotasCob; set => cantidadCuotasCob = value; }
        public string Estado { get => estado; set => estado = value; }
        public string FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FechaUltdeb { get => fechaUltdeb; set => fechaUltdeb = value; }
    }
}

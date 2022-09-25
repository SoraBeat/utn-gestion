using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CarrerasCurso
    {
        private String Id;
        private String tipo;
        private String descripcion;
        private String idSubcuenta;
        private String duracion;
        private int cupoMin;
        private int cupoMax;
        private String inicioElectivo;
        private String finalElectivo;
        private int totalHrs;
        private String modalidad;
        private int cantidadCuotas;
        private double matricula;
        private String observaciones;
        private double cuota;
        private double sena;
        private String tipoCuota;
        private double costoTotal;
        private int requerido;
     

        public CarrerasCurso() {; }

        public string Id1 { get => Id; set => Id = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string IdSubcuenta { get => idSubcuenta; set => idSubcuenta = value; }
        public string Duracion { get => duracion; set => duracion = value; }
        public int CupoMin { get => cupoMin; set => cupoMin = value; }
        public int CupoMax { get => cupoMax; set => cupoMax = value; }
        public string InicioElectivo { get => inicioElectivo; set => inicioElectivo = value; }
        public string FinalElectivo { get => finalElectivo; set => finalElectivo = value; }
        public int TotalHrs { get => totalHrs; set => totalHrs = value; }
        public string Modalidad { get => modalidad; set => modalidad = value; }
        public int CantidadCuotas { get => cantidadCuotas; set => cantidadCuotas = value; }
        public double Matricula { get => matricula; set => matricula = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public double Cuota { get => cuota; set => cuota = value; }
        public double Sena { get => sena; set => sena = value; }
        public string TipoCuota { get => tipoCuota; set => tipoCuota = value; }
        public double CostoTotal { get => costoTotal; set => costoTotal = value; }
        public int Requerido { get => requerido; set => requerido = value; }
    }
}

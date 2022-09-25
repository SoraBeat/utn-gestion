using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ingresos
    {
        private String Id;
        private String fecha;
        private String hora;
        private String tipoComp;
        private String nroComp;
        private String idAlumno;
        private String cuit;
        private String razon;
        private String domicilio;
        private String localidad;
        private String condicionIva;
        private double importeTotal;
        private double importePago;
        private String idSubcuenta;
        private String estado;
        private String anulado;
        private String observaciones;
        private String obserDetapago;

        public Ingresos() {; }

        public string Id1 { get => Id; set => Id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public string TipoComp { get => tipoComp; set => tipoComp = value; }
        public string NroComp { get => nroComp; set => nroComp = value; }
        public string IdAlumno { get => idAlumno; set => idAlumno = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string Razon { get => razon; set => razon = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string CondicionIva { get => condicionIva; set => condicionIva = value; }
        public double ImporteTotal { get => importeTotal; set => importeTotal = value; }
        public double ImportePago { get => importePago; set => importePago = value; }
        public string IdSubcuenta { get => idSubcuenta; set => idSubcuenta = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Anulado { get => anulado; set => anulado = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string ObserDetapago { get => obserDetapago; set => obserDetapago = value; }
    }
}

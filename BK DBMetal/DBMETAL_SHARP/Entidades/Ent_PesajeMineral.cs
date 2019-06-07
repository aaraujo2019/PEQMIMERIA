using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_PesajeMineral
    {
        public int Id { get; set; }

        public int Consecutivo { get; set; }
        public int IdVehiculo { get; set; }
        public string PlacaVehiculo { get; set; }
        public string DescripcionVehiculo { get; set; }
        public decimal PesoVehiculo { get; set; }
        public int IdConductor { get; set; }
        public string CodigoConductor { get; set; }
        public string NombreConductor { get; set; }
        public string TelefonoConductor { get; set; }
        public string CodigoProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string CodigoPlazaDefault { get; set; }
        public int IdPlaza { get; set; }
        public string CodigoPlaza { get; set; }
        public string NombrePlaza { get; set; }
        public string DescripcionPlaza { get; set; }
        public string CodigoContenedor { get; set; }
        public string NombreContenedor { get; set; }
        public Byte[] Foto { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaEstado0 { get; set; }
        public DateTime FechaEstado1 { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PesoEstado0 { get; set; }
        public decimal PesoEstado1 { get; set; }
        public string Sello1 { get; set; }

        public string Sello2 { get; set; }

        public string Sello3 { get; set; }

        public string Sello4 { get; set; }

        public string Sello5 { get; set; }

        public string Sello6 { get; set; }
        public byte OpcionGuardar { get; set; }
        public bool Available { get; set; }

    }
}

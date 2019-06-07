using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_VehiculosSeguros
    {
        public int IdPlaca { get; set; }
        public string Proveedor { get; set; }
        public string IdTomador { get; set; }
        public string Nombretomador { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Telefono { get; set; }
        public string CodigoSucursal { get; set; }
        public string ClaveProductor { get; set; }
        public string CiudadExpedicion { get; set; }
        public string Direccion { get; set; }
        public string CiudadResidencia { get; set; }
        public string Poliza { get; set; }
        public string Reemplaza { get; set; }
        public string ClaseVehiculo { get; set; }
        public string Pasajeros { get; set; }
        public string Tarifa { get; set; }
    }
}

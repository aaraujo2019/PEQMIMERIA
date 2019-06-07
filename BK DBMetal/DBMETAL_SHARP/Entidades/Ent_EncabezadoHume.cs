using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_EncabezadoHume
    {
        public string Fecha { get; set; }
        public string Muestras { get; set; }
        public string Cliente { get; set; }
        public string AuUnidad { get; set; }
        public string AuMetodo { get; set; }
        public string AgUnidad { get; set; }
        public string AgMetodo { get; set; }
        public string HumedadUnd { get; set; }
        public string HumedadMet { get; set; }
        public string TipoMuestras { get; set; }
        public string Orden { get; set; }
        public string ClienteOrden { get; set; }
        public string NumMuestras { get; set; }
        public string FechaMuestreo { get; set; }
        public string FechaReporte { get; set; }
        public string Notas { get; set; }
        public string CodigoPrepa { get; set; }
        public string DescripcionPrepa { get; set; }
        public string CodigoAnalisis { get; set; }
        public string DescripcionAnalisis { get; set; }
    }
}

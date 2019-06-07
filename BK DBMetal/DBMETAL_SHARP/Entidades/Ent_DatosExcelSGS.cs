using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_DatosExcelSGS
    {
        public bool Incluir { get; set; }
        public int Id { get; set; }
        public string SelloH { get; set; }
        public string SelloP { get; set; }
        public double Humedad { get; set; }
        public double Tenor { get; set; }
        public int Peso { get; set; }
        public string Cliente { get; set; }
        public string Orden { get; set; }
        public string Muestra { get; set; }
        public string Referencia { get; set; }
        public string Lugar { get; set; }
        public string Recepcion { get; set; }
        public string Reporte { get; set; }
    }
}

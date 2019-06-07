using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_MuestrasSGS2
    {
        public int  Consecutivo { get; set; }
        public bool Incluir { get; set; }
        public int Id { get; set; }
        public string SelloH { get; set; }
        public string SelloP { get; set; }
        public double Tenor { get; set; }
        public double Peso { get; set; }
        public string Cliente { get; set; } 
        public string Orden { get; set; }
        public int Muestra { get; set; } 
        public string Referencia { get; set; } 
        public string Lugar { get; set; } 
        public string Recepcion { get; set; }
        public string Reporte { get; set; }
    }
}

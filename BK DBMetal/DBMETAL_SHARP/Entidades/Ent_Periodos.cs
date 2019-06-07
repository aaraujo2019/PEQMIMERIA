using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_Periodos
    {
        public int Id { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public int Estado { get; set; }
        public double TRM { get; set; }
        public double ORO { get; set; }
        public double TRMEspecial { get; set; }
        public double RecuperacionReportada { get; set; }
        public double RecuperacionCalculada { get; set; }
        public double CostoPlanta { get; set; }
        public double OzCircuito { get; set; }
        public double Regalias { get; set; }
        public string Titulo { get; set; }
    }
}

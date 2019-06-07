using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_LiquidacionPeriodos
    {
        public string FechaAplica { get; set; }

        public string IdPeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string AnoPeriodo { get; set; }
        public string MesPeriodo { get; set; }
        public string Periodo { get; set; }
        public decimal? OnzasFundidas { get; set; }
        public decimal? OnzasRecuperadas { get; set; }
        public decimal? RecuperacionPlanta { get; set; }

        public bool? Available { get; set; }
    
        

    }
}

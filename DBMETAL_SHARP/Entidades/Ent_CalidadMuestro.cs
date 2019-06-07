using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
 public   class Ent_CalidadMuestro
    {
        //public DateTime FechaProduccion { get; set; }
        public int ConsecutivoBascula { get; set; }
        public string SelloControl { get; set; }
        //public string Contendor { get; set; }
        public string NombreProyecto { get; set; }
        //public decimal Total { get; set; }
        public decimal Peso{ get; set; }
        public string Duplicado { get; set; }
        public decimal? Humedad { get; set; }
        public decimal? AUFA { get; set; }
        public decimal? AUGR { get; set; }
        public decimal? AG { get; set; }
        public decimal? PesoMuestra { get; set; }
        public string Hora { get; set; }
        public bool AAQAQC { get; set; }
        public bool? Reanalisis { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public  class Ent_OrdenesMuestra
    {

        public int Id { get; set; }
        public int TotalMuestras { get; set; }
        public DateTime FechaOrden { get; set; }
        public string IdOrden { get; set; }
        public int Laboratorio { get; set; }
        public bool TipoAnalisis { get; set; }

    }
}

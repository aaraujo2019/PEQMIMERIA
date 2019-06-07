using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_RelacionTipoOrigenDestino
    {
        public int IdTipo { get; set; }
        public string CodigoTipoMineral { get; set; }
        public string NombreTipoMineral { get; set; }
        public int IdOrigen { get; set; }
        public string CodigoOrigen { get; set; }
        public string NombreOrigen { get; set; }
        public int IdDestino { get; set; }
        public string CodigoDestino { get; set; }
        public string NombreDestino { get; set; }
        public bool Estado { get; set; }
    }
}

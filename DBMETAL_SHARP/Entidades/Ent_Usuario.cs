using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Entidades
{
  public  class Ent_Usuario
    {
        public int Iden  { get; set; }

        public string Usuario { get; set; }

        public string Nombres { get; set; }
        public string Perfil { get; set; }
        public bool ContenedorPeqMineria { get; set; }
        public bool ContenedorZandor { get; set; }
        public bool ContenedorOtros { get; set; }
        public string Pages { get; set; }
        public string Name{ get; set; }
    }
}

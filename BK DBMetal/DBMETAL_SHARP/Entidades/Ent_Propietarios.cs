using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_Propietarios
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TelFijo { get; set; }
        public string Extension { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public bool Deshabilitado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_PersonalMuestreo
    {
        public int Id { get; set; }
        public string Identificacacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string TelFijo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int Rol { get; set; }
        public DateTime Create { get; set; }
        public bool Estado { get; set; }

        public Byte[] Foto { get; set; }
    }
}

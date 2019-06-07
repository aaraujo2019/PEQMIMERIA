using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_DatosAdjuntos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Archivo { get; set; }
        public string Extension { get; set; }
        public string Detalle { get; set; }
        public DateTime Realizado { get; set; }
        public int Usuario { get; set; }
        public string Maquina { get; set; }
    }
}

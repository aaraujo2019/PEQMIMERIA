using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_VwMinas
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdExpediente { get; set; }
        public string Expediente { get; set; }
        public double Este { get; set; }
        public double Norte { get; set; }
        public double Elevacion { get; set; }
        public bool Deshabilitado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

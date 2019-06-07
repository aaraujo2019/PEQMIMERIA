using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_TblMinasContratos
    {
        public int Id { get; set; }
        public int IdMina { get; set; }
        public int CodigoEsquema { get; set; }
        public int IdContratista { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Inscripcion { get; set; }
        public DateTime Vencimiento { get; set; }
        public double Recuperacion { get; set; }
        public double Fondo { get; set; }
        public double Impuestos { get; set; }
        public int Duracion { get; set; }
        public bool Tenores { get; set; }
        public bool AnexoSeguridad { get; set; }
        public bool Explosivos { get; set; }
        public bool DevolucionFondo { get; set; }
        public DateTime Realizado { get; set; }
        public string Maquina { get; set; }
        public int Usuario { get; set; }
    }
}

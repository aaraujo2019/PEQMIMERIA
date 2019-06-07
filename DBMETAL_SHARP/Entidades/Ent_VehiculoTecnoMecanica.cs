using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_VehiculoTecnoMecanica
    {
        public int IdPlaca { get; set; }
        public string NroControl { get; set; }
        public DateTime FechaExpedicion {get;set; }
        public DateTime FechaVencimiento {get;set; }
        public int IdPropietario {get;set; }
        public string NombrePropietario {get;set; }
        public string NitAutomotor {get;set; }
        public string NombreAutomotor {get;set; }
        public string ConsecutivoRunt { get; set; }
        public string CertificadoAcreditacion { get; set; }
    }
}

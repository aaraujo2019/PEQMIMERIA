using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_Conductores
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string TelFijo { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime Nacimiento { get; set; }
        public int RH { get; set; }
        public int IdContratista { get; set; }
        public string IdentificacionContratista { get; set; }
        public string NombreContratista { get; set; }
        public string ApellidoContratista { get; set; }
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        public bool Estado { get; set; }
        public Byte[] Foto { get; set; }
        public string Identificacion { get; set; }
    }
}

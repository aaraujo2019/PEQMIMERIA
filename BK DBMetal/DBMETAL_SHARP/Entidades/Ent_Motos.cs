using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_Motos
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public bool Estado { get; set; }
        public string Descripcion { get; set; }
        public string Licencia { get; set; }
        public int IdPropietario { get; set; }
        public string IdentificacionPropietrio { get; set; }
        public string NombrePropietario { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Linea { get; set; }
        public string Servicio { get; set; }
        public double Cilindraje { get; set; }
        public string Color { get; set; }
        public string Combustible { get; set; }
        public string Clase { get; set; }
        public string Carroceria { get; set; }
        public int Capacidad { get; set; }
        public string Motor { get; set; }
        public string Reg1 { get; set; }
        public string Vin { get; set; }
        public string Serie { get; set; }
        public string Reg2 { get; set; }
        public string Chasis { get; set; }
        public string Reg3 { get; set; }
        public int TipoVehiculo { get; set; }
        public string RestriccionMovilidad { get; set; }
        public string Blindaje { get; set; }
        public string Potencia { get; set; }
        public string DeclaracionImportacion { get; set; }
        public string IE { get; set; }
        public DateTime FechaImportacion { get; set; }
        public int Puertas { get; set; }
        public string LimitacionPropiedad { get; set; }
        public DateTime FechaMatricula { get; set; }
        public DateTime FechaExpLicTTO { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string OrganismoTransito { get; set; }
        public Byte[] Foto { get; set; }
        public int Usuario { get; set; }
        public string Maquina { get; set; }
        public string NombreUsuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_TipoLicenciaConductor
    {
        public int Id { get; set; }
        public int IdConductor { get; set; }        
        public DateTime FechaExpedicion { get; set; }
        public int Puertas { get; set; }
        public string RestriccionesConductor { get; set; }
        public string OrganismoTransito { get; set; }
        public int Categoria1 { get; set; }
        public int Categoria2 { get; set; }
        public int Categoria3 { get; set; }
        public string DetalleCategoria1 { get; set; }
        public string DetalleCategoria2 { get; set; }
        public string DetalleCategoria3 { get; set; }
        public DateTime Vigencia1 { get; set; }
        public DateTime Vigencia2 { get; set; }
        public DateTime Vigencia3 { get; set; }
        public int Usuario { get; set; }
        public string Maquina { get; set; }
        public string NombreUsuario { get; set; }
        public string NroLicencia { get; set; }
    }
}

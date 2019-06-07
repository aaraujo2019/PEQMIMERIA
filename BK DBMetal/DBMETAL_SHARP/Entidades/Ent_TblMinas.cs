using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ent_TblMinas
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string CodigoPM { get; set; }
        public int IdMina { get; set; }
        public string NombreVwMina { get; set; }
        public string NombreMina { get; set; }
        public int IdExpediente { get; set; }
        public string Expediente { get; set; }
        public string CodigoContenedor { get; set; }
        public string NombreContenedor { get; set; }        
        public int IdTipoContrato { get; set; }
        public string NombreTipoContrato { get; set; }
        public bool TenorPromedio { get; set; }
        public double Area { get; set; }
        public string Este { get; set; }
        public string Norte { get; set; }
        public string Elevacion { get; set; }
        public int IdTipoEmpresa { get; set; }
        public string NombreTipoEmpresa { get; set; }
        public string Detalle { get; set; }
        public string CodigoPlaza { get; set; }
        public string NombrePlaza { get; set; }
        public string Email { get; set; }
        public bool MostrarEnInformes { get; set; }
        public bool RecuperacionPlanta { get; set; }
        public bool Estado { get; set; }
    }
}

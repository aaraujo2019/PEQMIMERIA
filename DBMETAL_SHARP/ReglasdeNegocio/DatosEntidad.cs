using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasdeNegocio
{
    public static class DatosEntidad
    {
        public static DataSet Dataset(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            return LlenarGrid.Datos("SpConsulta_Tablas", new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            });
        }
        public static Ent_Periodos Periodos(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            return consultaEntidades.Periodos("SpConsulta_Tablas", sP_Parametros);
        }
        public static List<Ent_Periodos> ListPeriodos(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            return consultaEntidades.ListPeriodos("SpConsulta_Tablas", sP_Parametros);
        }
    }
}

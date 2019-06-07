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
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            DataSet DS = LlenarGrid.Datos("SpConsulta_Tablas", ParamSQL);
            return DS;
        }

        public static Ent_Periodos Periodos(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamUsuario = new SqlParameter[4];
            ParamUsuario[0] = new SqlParameter("@Op", Op);
            ParamUsuario[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamUsuario[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamUsuario[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Periodos Reader = Maestro.Periodos("SpConsulta_Tablas", ParamUsuario);
            return Reader;
        }

        public static List<Ent_Periodos> ListPeriodos(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] Parametros = new SqlParameter[4];
            Parametros[0] = new SqlParameter("@Op", Op);
            Parametros[1] = new SqlParameter("@ParametroChar", ParametroChar);
            Parametros[2] = new SqlParameter("@ParametroInt", ParametroInt);
            Parametros[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            List<Ent_Periodos> ListReturn = Maestro.ListPeriodos("SpConsulta_Tablas", Parametros);
            return ListReturn;
        }


    }
}

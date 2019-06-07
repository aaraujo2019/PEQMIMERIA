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
    public class ConsultaTablas
    {
        public static DataSet Dataset(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            DataSet DS;
            DS = LlenarGrid.Datos("SpConsulta_Tablas", ParamSQL);
            return DS;
        }

        public static List<Ent_VwMinas> ListaVwMinas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            List<Ent_VwMinas> Lista = new List<Ent_VwMinas>();
            Lista = Maestro.ListVwMinas("SpConsulta_Tablas", ParamSQL);
            return Lista;
        }

        public static List<Ent_VwTipoContrato> ListaVwTipoContrato(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            List<Ent_VwTipoContrato> Lista = new List<Ent_VwTipoContrato>();
            Lista = Maestro.ListVwTipoContrato("SpConsulta_Tablas", ParamSQL);
            return Lista;
        }

        public static List<Ent_Contenedores> ListaContenedores(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            List<Ent_Contenedores> Lista = new List<Ent_Contenedores>();
            Lista = Maestro.ListContenedores("SpConsulta_Tablas", ParamSQL);
            return Lista;
        }

        public static List<Ent_TiposDeEmpresa> ListaTipoEmpresas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            List<Ent_TiposDeEmpresa> Lista = new List<Ent_TiposDeEmpresa>();
            Lista = Maestro.ListaTiposDeEmpresa ("SpConsulta_Tablas", ParamSQL);
            return Lista;
        }

        public static Ent_TblMinas TblMinas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_TblMinas Entidad = new Ent_TblMinas();
            Entidad = Maestro.TblMina("SpConsulta_Tablas", ParamSQL);
            return Entidad;
        }

        public static Ent_Plazas TblPlazas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Plazas Entidad = new Ent_Plazas();
            Entidad = Maestro.Plazas("SpConsulta_Tablas", ParamSQL);
            return Entidad;
        }

        public static Ent_Esquemas Esquemas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Esquemas Entidad = new Ent_Esquemas();
            Entidad = Maestro.Esquemas("SpConsulta_Tablas", ParamSQL);
            return Entidad;
        }

        public static List<Ent_Esquemas> ListaEsquemas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            List<Ent_Esquemas> Lista = new List<Ent_Esquemas>();
            Lista = Maestro.ListaEsquemas("SpConsulta_Tablas", ParamSQL);
            return Lista;
        }

        public static List<Ent_VwContratistas> ListaVwContratista(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);
            ConsultaEntidades Maestro = new ConsultaEntidades();
            List<Ent_VwContratistas> Lista = new List<Ent_VwContratistas>();
            Lista = Maestro.ListaVwContratistas("SpConsulta_Tablas", ParamSQL);
            return Lista;
        }

        public static Ent_DatosAdjuntos Adjuntos(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@Op", Op);
            ParamSQL[1] = new SqlParameter("@ParametroChar", ParametroChar);
            ParamSQL[2] = new SqlParameter("@ParametroInt", ParametroInt);
            ParamSQL[3] = new SqlParameter("@ParametroNuemric", ParametroNumeric);

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_DatosAdjuntos Entidad = new Ent_DatosAdjuntos();
            Entidad = Maestro.Adjunto("SpConsulta_Tablas", ParamSQL);
            return Entidad;
        }

    }
}

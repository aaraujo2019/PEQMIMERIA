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
            return LlenarGrid.Datos("SpConsulta_Tablas", new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            });
        }
        public static List<Ent_VwMinas> ListaVwMinas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            List<Ent_VwMinas> list = new List<Ent_VwMinas>();
            return consultaEntidades.ListVwMinas("SpConsulta_Tablas", sP_Parametros);
        }
        public static List<Ent_VwTipoContrato> ListaVwTipoContrato(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            List<Ent_VwTipoContrato> list = new List<Ent_VwTipoContrato>();
            return consultaEntidades.ListVwTipoContrato("SpConsulta_Tablas", sP_Parametros);
        }
        public static List<Ent_Contenedores> ListaContenedores(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            List<Ent_Contenedores> list = new List<Ent_Contenedores>();
            return consultaEntidades.ListContenedores("SpConsulta_Tablas", sP_Parametros);
        }
        public static List<Ent_TiposDeEmpresa> ListaTipoEmpresas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            List<Ent_TiposDeEmpresa> list = new List<Ent_TiposDeEmpresa>();
            return consultaEntidades.ListaTiposDeEmpresa("SpConsulta_Tablas", sP_Parametros);
        }
        public static Ent_TblMinas TblMinas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            Ent_TblMinas ent_TblMinas = new Ent_TblMinas();
            return consultaEntidades.TblMina("SpConsulta_Tablas", sP_Parametros);
        }
        public static Ent_Plazas TblPlazas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            Ent_Plazas ent_Plazas = new Ent_Plazas();
            return consultaEntidades.Plazas("SpConsulta_Tablas", sP_Parametros);
        }
        public static Ent_Esquemas Esquemas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            Ent_Esquemas ent_Esquemas = new Ent_Esquemas();
            return consultaEntidades.Esquemas("SpConsulta_Tablas", sP_Parametros);
        }
        public static List<Ent_Esquemas> ListaEsquemas(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            List<Ent_Esquemas> list = new List<Ent_Esquemas>();
            return consultaEntidades.ListaEsquemas("SpConsulta_Tablas", sP_Parametros);
        }
        public static List<Ent_VwContratistas> ListaVwContratista(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            List<Ent_VwContratistas> list = new List<Ent_VwContratistas>();
            return consultaEntidades.ListaVwContratistas("SpConsulta_Tablas", sP_Parametros);
        }
        public static Ent_DatosAdjuntos Adjuntos(string Op, string ParametroChar, int ParametroInt, double ParametroNumeric)
        {
            SqlParameter[] sP_Parametros = new SqlParameter[]
            {
                new SqlParameter("@Op", Op),
                new SqlParameter("@ParametroChar", ParametroChar),
                new SqlParameter("@ParametroInt", ParametroInt),
                new SqlParameter("@ParametroNuemric", ParametroNumeric)
            };
            ConsultaEntidades consultaEntidades = new ConsultaEntidades();
            Ent_DatosAdjuntos ent_DatosAdjuntos = new Ent_DatosAdjuntos();
            return consultaEntidades.Adjunto("SpConsulta_Tablas", sP_Parametros);
        }
    }
}

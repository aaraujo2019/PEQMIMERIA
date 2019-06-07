using ReglasdeNegocio;
using ReglasdeNegocio.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocios
{
    public class List_CamposRDB
    {
        SqlConnection objconexion;
        SqlCommand cmd;

        #region Consultar Campos de las Tablas
        public List<string> Consultar_Campos(string StoreProcedure, SqlParameter[] Parametros)
        {
            List<string> Lista = new List<string>();

            objconexion = Conexion.OpenConexion();
            cmd = new SqlCommand(StoreProcedure, objconexion);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var item in Parametros)
                cmd.Parameters.Add(item).Value = item.Value;

            SqlDataReader Reader;

            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                string campo = Reader["NombreCampo"].ToString();
                Lista.Add(campo);
            }
            ConexionDB.CloseConexion(cmd);
            return Lista;
        }
        #endregion
    }
}

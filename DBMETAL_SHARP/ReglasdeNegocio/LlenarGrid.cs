using ReglasdeNegocio.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasdeNegocio
{
    public class LlenarGrid
    {
        public static DataSet Datos(string StoreProcedure, SqlParameter[] Parametros)
        {
            SqlConnection objconexion;
            SqlCommand cmd;
            objconexion = Conexion.OpenConexion();
            cmd = new SqlCommand(StoreProcedure, objconexion);
            cmd.CommandType = CommandType.StoredProcedure;


            foreach (var item in Parametros)
                cmd.Parameters.Add(item).Value = item.Value;

            SqlDataAdapter DataAdapter = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DataAdapter.Fill(DS, "Result");

            ConexionDB.CloseConexion(cmd);
            return DS;
        }
    }
}

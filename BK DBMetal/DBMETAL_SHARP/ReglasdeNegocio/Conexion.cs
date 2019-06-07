using ReglasdeNegocio.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace ReglasdeNegocio
{
    public class Conexion
    {
        public static SqlConnection OpenConexion()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = ConexionDB.OpenConexion(); ///@"Server=MEDITADMDC\SQLEXPRESS;Database=DBMETAL;User Id=sainventario;Password=Zandor;";
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                else
                    Conn.Open();
                return Conn;
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error al Abrir Conexion " + Ex.Errors);
            }

            return Conn;
        }

        public static void CloseConexion(SqlCommand Conn)
        {
            //Temporal esperando confirmación del cambio
            //Conn.ConnectionString = @"Server=10.10.201.6;Database=SoftTAP;User Id=sainventario;Password=Zandor;";
            try
            {
                if (Conn.Connection.State == ConnectionState.Open)

                {
                    Conn.Connection.Close();
                    Conn.Dispose();
                    Conn = null;

                }

            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error al Abrir Conexion " + Ex.Errors);

            }

        }

    }
}

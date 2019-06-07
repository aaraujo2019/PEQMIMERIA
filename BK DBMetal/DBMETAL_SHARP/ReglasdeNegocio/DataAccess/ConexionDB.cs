using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio.DataAccess
{
    public class ConexionDB
    {

        public static string OpenConexion()
        {

            SqlConnection Conn = new SqlConnection();
            string cadena = "";
            string servidor = "";
            string dbase = "";
            string usuario = "";
            string pws = "";
            string clave = "";
            int index = 0;

            #region Lectura de INI

            try
            {
                System.IO.StreamReader File = new System.IO.StreamReader(@"C:\WINDOWS\ConnServerNP.ini");

                bool indicate = true;
                string context = string.Empty;
                while ((cadena = File.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(cadena))
                    {

                        context = cadena.Substring(cadena.IndexOf("=") + 1, cadena.Length - cadena.IndexOf("=") - 1);
                        cadena = cadena.Substring(0, cadena.IndexOf("="));
                    }

                    if (cadena.Contains("Active"))
                        indicate = true;

                    if (indicate)
                    {
                        switch (cadena)
                        {
                            case "Active":
                                indicate = context.ToString().ToLower().Trim().Contains("true") ? true : false;
                                index++;
                                break;
                            case "Server":
                                servidor = context.Trim();
                                break;
                            case "Database":
                                dbase = context.Trim();
                                break;
                            case "User Id":
                                usuario = context.Trim();
                                break;
                            case "Password":
                                clave = context.Trim().ToString();
                                pws = Clave.DesEncriptar(Convert.FromBase64String(clave));
                                break;
                            default:
                                break;
                        }
                    }

                    if (!String.IsNullOrEmpty(pws))
                        break;
                }
                File.Close();
            }
            catch (Exception ErrorConexion)
            {

                MessageBox.Show(ErrorConexion.Message);
            }

            Conn.ConnectionString = "Server=" + servidor + ";Database=" + dbase + ";User Id=" + usuario + ";Password=" + pws + ";";

            try
            {
                return Conn.ConnectionString;

            }
            catch (SqlException Ex)
            {
                // MessageBox.Show("Error de comunicacion:  " + Ex.Errors, "Informe de la aplicacion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion


            return Conn.ConnectionString;

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

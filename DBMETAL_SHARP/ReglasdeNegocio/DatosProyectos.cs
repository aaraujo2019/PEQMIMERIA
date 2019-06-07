using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ReglasdeNegocio
{
    public class DatosProyectos
    {

        /// <summary>
        /// Obtiene las plazas.
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable getCmbPlazasProyectos()
        {
            SqlConnection con = Conexion.OpenConexion();

            try
            {
                DataTable datosFiltros = new DataTable();

                using (SqlCommand cmdConsulta = new SqlCommand("Sp_Cargar_Combo_Plazas", con))
                {
                    cmdConsulta.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter daConsulta = new SqlDataAdapter(cmdConsulta);
                    daConsulta.Fill(datosFiltros);

                    return datosFiltros;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Algo pasó en getCmbPlazasProyectos, Sp_Cargar_Combo_Plazas." + ex.Message);
            }
        }

        /// <summary>
        /// Metodo para Insertar un proyecto
        /// </summary>
        /// <param name="proyecto"></param>
        public void insertProyecto (Ent_Proyectos proyecto)
        {
            SqlConnection con = Conexion.OpenConexion();

            try
            {
                using (SqlCommand cmdConsulta = new SqlCommand("Sp_Insertar_Proyectos", con))
                {
                    cmdConsulta.CommandType = CommandType.StoredProcedure;
                    cmdConsulta.Parameters.Clear();
                    cmdConsulta.Parameters.AddWithValue("@pCodigo", proyecto.Codigo);
                    cmdConsulta.Parameters.AddWithValue("@pNombre", proyecto.Nombre);
                    cmdConsulta.Parameters.AddWithValue("@pDescripcion", proyecto.Descripcion);
                    cmdConsulta.Parameters.AddWithValue("@pIdPlaza", proyecto.IdPlaza);
                    cmdConsulta.Parameters.AddWithValue("@pAnalisis", proyecto.Analisis);
                    
                    cmdConsulta.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Algo pasó en insertProyecto, Sp_Insertar_Proyectos." + ex.Message);
            }
        }

        public DataTable getProyectoPorCodigo(string codigo)
        {
            SqlConnection con = Conexion.OpenConexion();

            try
            {
                DataTable datosFiltros = new DataTable();

                using (SqlCommand cmdConsulta = new SqlCommand("Sp_BuscarProyecto", con))
                {
                    cmdConsulta.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter daConsulta = new SqlDataAdapter(cmdConsulta);
                    cmdConsulta.Parameters.Clear();
                    cmdConsulta.Parameters.AddWithValue("@pCodigo", codigo);
                    daConsulta.Fill(datosFiltros);

                    return datosFiltros;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Algo pasó en getProyectoPorCodigo, Sp_BuscarProyecto." + ex.Message);
            }
        }


        public List<T> getProyectoPorCodigoSafe(string codigo)
        {
            SqlConnection con = Conexion.OpenConexion();

            try
            {
                DataTable datosFiltros = new DataTable();
                Safe safe = new Safe();

                using (SqlCommand cmdConsulta = new SqlCommand("Sp_BuscarProyecto", con))
                {
                    cmdConsulta.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter daConsulta = new SqlDataAdapter(cmdConsulta);
                    cmdConsulta.Parameters.Clear();
                    cmdConsulta.Parameters.AddWithValue("@pCodigo", codigo);
                    daConsulta.Fill(datosFiltros);

                    return new List<T>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Algo pasó en getProyectoPorCodigo, Sp_BuscarProyecto." + ex.Message);
            }
        }

    }
}

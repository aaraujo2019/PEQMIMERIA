using ReglasdeNegocio.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio
{
    public class GuardarDatos
    {
        SqlConnection objconexion;
        SqlCommand cmd;
        bool Respueta = false;

        public static string _Existe(string Tabla, string Campo)
        {
            SqlParameter[] Parametros = new SqlParameter[2];
            Parametros[0] = new SqlParameter("@Tabla", Tabla);
            Parametros[1] = new SqlParameter("@Codigo", Campo);
            DataSet DS = ProcesosSQL.ExistenciaCodigoTabla("SP_Consulta_ExistenciaCodigoTabla", Parametros);
            string resultado = DS.Tables[0].Rows[0]["Tipo"].ToString().Trim();
            return resultado;
        }



        public bool booleano(string procedimiento, SqlParameter[] pparametros)
        {
            try
            {
                objconexion = Conexion.OpenConexion();
                cmd = new SqlCommand(procedimiento, objconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var parametro in pparametros)
                    cmd.Parameters.Add(parametro).Value = parametro.Value;

                if (cmd.ExecuteNonQuery() == 1)
                    Respueta = true;
                else
                    Respueta = false;


                ConexionDB.CloseConexion(cmd);
            }
            catch (Exception Ext1)
            {
                //System.Windows.Forms.MessageBox.Show(Ext1.Message);

                throw new System.ArgumentException(Ext1.Message, Ext1);
            }

            return Respueta;
        }

        public int Numerico(string procedimiento, SqlParameter[] pparametros)
        {
            objconexion = Conexion.OpenConexion();
            cmd = new SqlCommand(procedimiento, objconexion);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var parametro in pparametros)
                cmd.Parameters.Add(parametro).Value = parametro.Value;

           int value = Convert.ToInt32(cmd.ExecuteScalar());
            Conexion.CloseConexion(cmd);
            return value;
        }


        public static DataTable GetRoles(string queryString)
        {
            SqlConnection objconexion = Conexion.OpenConexion();



            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, objconexion);
            dataAdapter.Fill(ds, "usersInRoles");

            objconexion.Close();
            return ds.Tables[0];
        }

        public bool _ImagenPublicitaria(int Op, Byte[] Imagen)
        {
            objconexion = Conexion.OpenConexion();
            cmd = new SqlCommand("Sp_Guardar_Logo", objconexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("Foto", SqlDbType.VarBinary);
            cmd.Parameters.Add("Op", SqlDbType.Int);
            cmd.Parameters["Foto"].Value = Imagen;
            cmd.Parameters["Op"].Value = Op;
            cmd.ExecuteNonQuery();

            return true;
        }

        public static SqlParameter[] Parametros_PersonalMuestreo(string Op, string Identificacacion, string Nombre, string Apellido, string Direccion, string TelFijo, string Celular, string Email, int Rol, Byte[] Foto, bool Estado, DateTime create)
        {
            SqlParameter[] ParamSQL = new SqlParameter[12];
            if (Op.Trim().Length == 0)
                ParamSQL[0] = new SqlParameter("@Op", GuardarDatos._Existe("Tbl_PersonalMuestreo", Identificacacion.Trim()));
            else
                ParamSQL[0] = new SqlParameter("@Op", "D");
            ParamSQL[1] = new SqlParameter("@Identificacacion", Identificacacion.Trim());
            ParamSQL[2] = new SqlParameter("@Nombre", Nombre.Trim());
            ParamSQL[3] = new SqlParameter("@Apellido", Apellido.Trim());
            ParamSQL[4] = new SqlParameter("@Direccion", Direccion.Trim());
            ParamSQL[5] = new SqlParameter("@TelFijo", TelFijo.Trim());
            ParamSQL[6] = new SqlParameter("@Celular", Celular.Trim());
            ParamSQL[7] = new SqlParameter("@Email", Email.Trim());
            ParamSQL[8] = new SqlParameter("@Rol", Rol);
            ParamSQL[9] = new SqlParameter("@Foto", Foto);
            ParamSQL[10] = new SqlParameter("@Estado", Estado);
            ParamSQL[11] = new SqlParameter("@Creado", create);
            return ParamSQL;
        }

        public static SqlParameter[] Parameter_GerPermissions(string nameUser, string PageMaster)
        {
            SqlParameter[] ParamSQL = new SqlParameter[2];
            ParamSQL[0] = new SqlParameter("@Name", nameUser);
            ParamSQL[1] = new SqlParameter("@FKPage", PageMaster);

            return ParamSQL;
        }

        public static SqlParameter[] Parameter_UpdateSelloControls(int ConsecutivoBascula, string SelloDesc, string SelloControl, string SelloContNuevo)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@ConsecutivoBascula", ConsecutivoBascula);
            ParamSQL[1] = new SqlParameter("@SelloControlDes", SelloDesc);
            ParamSQL[2] = new SqlParameter("@SelloControl", SelloControl);
            ParamSQL[3] = new SqlParameter("@SelloControlNuevo", SelloContNuevo);
            
            return ParamSQL;
        }

        public static SqlParameter[] Parametros_MuestreoPM(bool isRechekeo, string Op, int IdUsuario, string Consecutivo, DateTime Reportado, int IdEncargado, int Idercero, int IdSeguridad, int IdCuartea, string SelloControl, string Sello1, decimal PesoSello1, string DestinoSello1, int IdTipoSello1, int IdAnalisisSello1, string DetalleSello1, string Sello2, decimal PesoSello2, string DestinoSello2, int IdTipoSello2, int IdAnalisisSello2, string DetalleSello2, string Sello3, decimal PesoSello3, string DestinoSello3, int IdTipoSello3, int IdAnalisisSello3, string DetalleSello3, string Sello4, decimal PesoSello4, string DestinoSello4, int IdTipoSello4, int IdAnalisisSello4, string DetalleSello4, string Sello5, decimal PesoSello5, string DestinoSello5, int IdTipoSello5, int IdAnalisisSello5, string DetalleSello5, string Sello6, decimal PesoSello6, string DestinoSello6, int IdTipoSello6, int IdAnalisisSello6, string DetalleSello6, decimal TenorAu, decimal TenorAg, decimal Humedad, string Contenedor, string CodProyect, decimal PesoTotalMuestra, bool available, string descProyect)
        {
            //MessageBox.Show("entro 000");
            SqlParameter[] ParamSQL = new SqlParameter[53];
            if (!isRechekeo)
            {
                if (Op.Trim().Length == 0)
                    ParamSQL[0] = new SqlParameter("@Op", GuardarDatos._Existe("Tbl_ReporteMuestraPM", Consecutivo.Trim()));
                else
                    ParamSQL[0] = new SqlParameter("@Op", "D");
            }
            else
                ParamSQL[0] = new SqlParameter("@Op", "U");

            ParamSQL[1] = new SqlParameter("@Consecutivo", Consecutivo.Trim());
            ParamSQL[2] = new SqlParameter("@ConsecutivoBascula", Consecutivo.Trim());

            var culturaCol = CultureInfo.GetCultureInfo("es-CO");

            //MessageBox.Show(Reportado.ToString("dd/MM/yyyy"), "Entro 1.2");

            Reportado = Convert.ToDateTime(Reportado.ToString("dd/MM/yyyy"), culturaCol);
            //MessageBox.Show("Entro 1.2");
            ParamSQL[3] = new SqlParameter("@Reportado", Reportado);
            //MessageBox.Show("Entro 1.3");

            ParamSQL[4] = new SqlParameter("@IdEncargado", IdEncargado);
            ParamSQL[5] = new SqlParameter("@Idercero", Idercero);
            ParamSQL[6] = new SqlParameter("@IdSeguridad", IdSeguridad);
            ParamSQL[7] = new SqlParameter("@IdCuartea", IdCuartea);
            ParamSQL[8] = new SqlParameter("@SelloControl", SelloControl);
            ParamSQL[9] = new SqlParameter("@Sello1", Sello1);
            ParamSQL[10] = new SqlParameter("@PesoSello1", PesoSello1);
            ParamSQL[11] = new SqlParameter("@DestinoSello1", DestinoSello1);
            ParamSQL[12] = new SqlParameter("@IdTipoSello1", IdTipoSello1);
            ParamSQL[13] = new SqlParameter("@IdAnalisisSello1", IdAnalisisSello1);
            ParamSQL[14] = new SqlParameter("@DetalleSello1", DetalleSello1.Trim());
            ParamSQL[15] = new SqlParameter("@Sello2", Sello2.Trim());
            ParamSQL[16] = new SqlParameter("@PesoSello2", PesoSello2);
            ParamSQL[17] = new SqlParameter("@DestinoSello2", DestinoSello2.Trim());
            ParamSQL[18] = new SqlParameter("@IdTipoSello2", IdTipoSello2);
            ParamSQL[19] = new SqlParameter("@IdAnalisisSello2", IdAnalisisSello2);
            ParamSQL[20] = new SqlParameter("@DetalleSello2", DetalleSello2);
            ParamSQL[21] = new SqlParameter("@Sello3", Sello3);
            ParamSQL[22] = new SqlParameter("@PesoSello3", PesoSello3);
            ParamSQL[23] = new SqlParameter("@DestinoSello3", DestinoSello3);
            ParamSQL[24] = new SqlParameter("@IdTipoSello3", IdTipoSello3);
            ParamSQL[25] = new SqlParameter("@IdAnalisisSello3", IdAnalisisSello3);
            ParamSQL[26] = new SqlParameter("@DetalleSello3", DetalleSello3.Trim());
            ParamSQL[27] = new SqlParameter("@Sello4", Sello4.Trim());
            ParamSQL[28] = new SqlParameter("@PesoSello4", PesoSello4);
            ParamSQL[29] = new SqlParameter("@DestinoSello4", DestinoSello4);
            ParamSQL[30] = new SqlParameter("@IdTipoSello4", IdTipoSello4);
            ParamSQL[31] = new SqlParameter("@IdAnalisisSello4", IdAnalisisSello4);
            ParamSQL[32] = new SqlParameter("@DetalleSello4", DetalleSello4.Trim());
            ParamSQL[33] = new SqlParameter("@Sello5", Sello5);
            ParamSQL[34] = new SqlParameter("@PesoSello5", PesoSello5);
            ParamSQL[35] = new SqlParameter("@DestinoSello5", DestinoSello5.Trim());
            ParamSQL[36] = new SqlParameter("@IdTipoSello5", IdTipoSello5);
            ParamSQL[37] = new SqlParameter("@IdAnalisisSello5", IdAnalisisSello5);
            ParamSQL[38] = new SqlParameter("@DetalleSello5", DetalleSello5);
            ParamSQL[39] = new SqlParameter("@Sello6", Sello6);
            ParamSQL[40] = new SqlParameter("@PesoSello6", PesoSello6);
            ParamSQL[41] = new SqlParameter("@DestinoSello6", DestinoSello6);
            ParamSQL[42] = new SqlParameter("@IdTipoSello6", IdTipoSello6);
            ParamSQL[43] = new SqlParameter("@IdAnalisisSello6", IdAnalisisSello6);
            ParamSQL[44] = new SqlParameter("@DetalleSello6", DetalleSello6);
            ParamSQL[45] = new SqlParameter("@TenorAu", DBNull.Value);
            ParamSQL[46] = new SqlParameter("@TenorAg", DBNull.Value);
            ParamSQL[47] = new SqlParameter("@Humedad", DBNull.Value);
            ParamSQL[48] = new SqlParameter("@IdUsuario", IdUsuario);

            ParamSQL[49] = new SqlParameter("@CodContenedor", Contenedor);
            ParamSQL[50] = new SqlParameter("@CodProyecto", CodProyect);
            ParamSQL[51] = new SqlParameter("@PesoTotalMuestra", PesoTotalMuestra);
            ParamSQL[52] = new SqlParameter("@NombreProyecto", descProyect);



            return ParamSQL;
        }

        public static SqlParameter[] Parametros_OrdenesMuestreoPM(string Op, string IdOrden, DateTime FechaOrden, int TotalMuestras, int Laboratorio, bool TipoAnalisis, int IdUsuario)
        {
            SqlParameter[] ParamSQL = new SqlParameter[7];
            if (Op.Trim().Length == 0)
                ParamSQL[0] = new SqlParameter("@Op", GuardarDatos._Existe("OrdenesMuestraPM", IdOrden.Trim()));
            else
                ParamSQL[0] = new SqlParameter("@Op", "D");

            ParamSQL[1] = new SqlParameter("@IdOrden", IdOrden.Trim());
            ParamSQL[2] = new SqlParameter("@FechaOrden", FechaOrden);
            ParamSQL[3] = new SqlParameter("@TotalMuestras", TotalMuestras);
            ParamSQL[4] = new SqlParameter("@Laboratorio", Laboratorio);
            ParamSQL[5] = new SqlParameter("@TipoAnalisis", TipoAnalisis);
            ParamSQL[6] = new SqlParameter("@IdUsuario", IdUsuario);


            return ParamSQL;
        }
        public static SqlParameter[] Parametros_BorrarMuestreoPM(string SelloControl)
        {
            SqlParameter[] ParamSQL = new SqlParameter[1];


            ParamSQL[0] = new SqlParameter("@SelloControl", SelloControl.Trim());

            return ParamSQL;
        }


        public static SqlParameter[] Parametros_OrdenesDetalleMuestreoPM(string Op, string SelloControl, string TipoMuestra, string IdLab, string Duplicado, int ConsecutivoBascula, bool QAQC, bool AC, bool Available, DateTime FechaProduccion, DateTime FechaRegistro, int Usuario)
        {
            SqlParameter[] ParamSQL = new SqlParameter[12];
            //if (Op.Trim().Length == 0)
            //    ParamSQL[0] = new SqlParameter("@Op", GuardarDatos._Existe("OrdenesMuestraPM", IdOrden.Trim()));
            //else
            //    ParamSQL[0] = new SqlParameter("@Op", "D");

            ParamSQL[0] = new SqlParameter("@Op", "I");


            ParamSQL[1] = new SqlParameter("@SelloControl", SelloControl.Trim());
            ParamSQL[2] = new SqlParameter("@TipoMuestra", TipoMuestra);
            ParamSQL[3] = new SqlParameter("@IdLab", IdLab);
            ParamSQL[4] = new SqlParameter("@Duplicado", Duplicado);
            ParamSQL[5] = new SqlParameter("@ConsecutivoBascula", ConsecutivoBascula);
            ParamSQL[6] = new SqlParameter("@QAQC", QAQC);
            ParamSQL[7] = new SqlParameter("@AC", AC);
            ParamSQL[8] = new SqlParameter("@Available", Available);
            ParamSQL[9] = new SqlParameter("@FechaProduccion", FechaProduccion);
            ParamSQL[10] = new SqlParameter("@FechaRegistro", FechaRegistro);
            ParamSQL[11] = new SqlParameter("@Usuario", Usuario);

            return ParamSQL;
        }

        public static SqlParameter[] Parametros_DetalleExcelPM(string Op, string SelloControl, decimal humedad, decimal au, decimal ag, decimal peso, string usuario,string idLab)
        {
            SqlParameter[] ParamSQL = new SqlParameter[7];
            ParamSQL[0] = new SqlParameter("@SelloControl", SelloControl.Trim());
            ParamSQL[1] = new SqlParameter("@humedad", humedad);
            ParamSQL[2] = new SqlParameter("@au", au);
            ParamSQL[3] = new SqlParameter("@ag", ag);
            ParamSQL[4] = new SqlParameter("@peso", peso);
            ParamSQL[5] = new SqlParameter("@usuario", usuario);
            ParamSQL[6] = new SqlParameter("@IdLab", idLab);
            
            return ParamSQL;
        }

        public static SqlParameter[] Parametros_DetalleExcelZandor(string Op, string SelloControl, decimal au, decimal augr, string usuario)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];
            ParamSQL[0] = new SqlParameter("@SelloControl", SelloControl.Trim());
            ParamSQL[1] = new SqlParameter("@au", au);
            ParamSQL[2] = new SqlParameter("@augr", augr);
            ParamSQL[3] = new SqlParameter("@usuario", usuario);

            return ParamSQL;
        }
        public static SqlParameter[] Parametros_DetalleExcelReanalisis(string SelloControl, decimal au)
        {
            SqlParameter[] ParamSQL = new SqlParameter[2];
            ParamSQL[0] = new SqlParameter("@SelloControl", SelloControl.Trim());
            ParamSQL[1] = new SqlParameter("@au", au);
            return ParamSQL;
        }

        public static SqlParameter[] Parametros_DetalleExcelHumedad(string Op, string SelloControl, decimal humedad, string usuario)
        {
            SqlParameter[] ParamSQL = new SqlParameter[3];
            ParamSQL[0] = new SqlParameter("@SelloControl", SelloControl.Trim());
            ParamSQL[1] = new SqlParameter("@Humedad", humedad);
            ParamSQL[2] = new SqlParameter("@usuario", usuario);

            return ParamSQL;
        }

        public static SqlParameter[] Parametros_ToneladaSeca(string consecutivo, decimal humedad)
        {
            SqlParameter[] ParamSQL = new SqlParameter[2];
            ParamSQL[0] = new SqlParameter("@Consecutivo", consecutivo);
            ParamSQL[1] = new SqlParameter("@Humedad", humedad);

            return ParamSQL;
        }

        public static SqlParameter[] Parametros_ActQAQC(int consecutivo)
        {
            SqlParameter[] ParamSQL = new SqlParameter[1];
            ParamSQL[0] = new SqlParameter("@Consecutivo", consecutivo);

            return ParamSQL;
        }

        public static SqlParameter[] Parametros_Update_MuestreoPM(int Consecutivo, string Duplicado)
        {
            SqlParameter[] ParamSQL = new SqlParameter[2];

            ParamSQL[0] = new SqlParameter("@Consecutivo", Consecutivo);
            ParamSQL[1] = new SqlParameter("@Duplicado", Duplicado);

            return ParamSQL;
        }
        public static SqlParameter[] Parametros_Cerrar_PeriodoPM(string idPerioso)
        {
            SqlParameter[] ParamSQL = new SqlParameter[1];
            ParamSQL[0] = new SqlParameter("@Periodos", idPerioso);

            return ParamSQL;
        }
        public static SqlParameter[] Parametros_Insertar_PeriodoPM(string op, DateTime fechaInicial, DateTime fechaFinal, int cboAno, int cboMes, string cboPeriodo, decimal onzasFundidas, decimal recuperacion, decimal onzasRecuperadas, int usuario)
        {
            string IdPeriodo = string.Concat(cboAno.ToString().Trim(), "-", cboMes.ToString().Trim(), "-", cboPeriodo.ToString().Trim());
            SqlParameter[] ParamSQL = new SqlParameter[12];
            if (op.Trim().Length == 0)
                ParamSQL[0] = new SqlParameter("@Op", GuardarDatos._Existe("Tbl_PeriodoLiquidacion", IdPeriodo));
            else
                ParamSQL[0] = new SqlParameter("@Op", "D");


            ParamSQL[1] = new SqlParameter("@IdPeriodo", IdPeriodo);
            ParamSQL[2] = new SqlParameter("@FechaInicio", fechaInicial);
            ParamSQL[3] = new SqlParameter("@FechaFin", fechaFinal);
            ParamSQL[4] = new SqlParameter("@RecuperacionPlanta", recuperacion);
            ParamSQL[5] = new SqlParameter("@AnoPeriodo", cboAno);
            ParamSQL[6] = new SqlParameter("@MesPeriodo", cboMes);
            ParamSQL[7] = new SqlParameter("@Periodo", cboPeriodo);
            ParamSQL[8] = new SqlParameter("@Available", true);
            ParamSQL[9] = new SqlParameter("@OnzasFundidas", onzasFundidas);
            ParamSQL[10] = new SqlParameter("@OnzasRecuperadas", onzasRecuperadas);
            ParamSQL[11] = new SqlParameter("@Usuario", usuario);

            return ParamSQL;
        }

        public static SqlParameter[] Parametros_Update_QAQCPM(bool QAQC, int ConsecutivoBascula, string SelloControl,bool Reanalisis)
        {
            SqlParameter[] ParamSQL = new SqlParameter[4];

            ParamSQL[0] = new SqlParameter("@QAQC", QAQC);
            ParamSQL[1] = new SqlParameter("@ConsecutivoBascula", ConsecutivoBascula);
            ParamSQL[2] = new SqlParameter("@SelloControl", SelloControl);
            ParamSQL[3] = new SqlParameter("@Reanalisis", Reanalisis);

            return ParamSQL;
        }

        public static SqlParameter[] Parametros_Update_Rol(int roleID, string nameForm, string controlID, int InVisible, int Disabled, int ContenedorPeqMineria, int ContenedorZandor, int ContenedorOtros)
        {
            SqlParameter[] ParamSQL = new SqlParameter[8];

            ParamSQL[0] = new SqlParameter("@RoleID", roleID);
            ParamSQL[1] = new SqlParameter("@PageName", nameForm);
            ParamSQL[2] = new SqlParameter("@ControlID", controlID);

            ParamSQL[3] = new SqlParameter("@invisible", InVisible);
            ParamSQL[4] = new SqlParameter("@disabled", Disabled);
            ParamSQL[5] = new SqlParameter("@ContenedorPeqMineria", ContenedorPeqMineria);

            ParamSQL[6] = new SqlParameter("@ContenedorZandor", ContenedorZandor);
            ParamSQL[7] = new SqlParameter("@ContenedorOtros", ContenedorOtros);

            return ParamSQL;
        }

        public static SqlParameter[] Parametros_Localizacion(string Op, string Identificacacion, string Nombre, bool estado, string Detalle)
        {
            if (Op.Trim().Length == 0)
            {
                SqlParameter[] ParamSQL = new SqlParameter[5];

                ParamSQL[0] = new SqlParameter("@Op", GuardarDatos._Existe("Tbl_Localizacion", Identificacacion.Trim()));
                ParamSQL[1] = new SqlParameter("@Identificacacion", Identificacacion.Trim());
                ParamSQL[2] = new SqlParameter("@Nombre", Nombre.Trim());
                ParamSQL[3] = new SqlParameter("@Detalle", Detalle);
                ParamSQL[4] = new SqlParameter("@Estado", estado);


                return ParamSQL;
            }
            else
            {
                SqlParameter[] ParamSQL = new SqlParameter[5];

                ParamSQL[0] = new SqlParameter("@Op", "D");
                ParamSQL[1] = new SqlParameter("@Identificacacion", Identificacacion.Trim());
                ParamSQL[2] = new SqlParameter("@Nombre", Nombre.Trim());
                ParamSQL[3] = new SqlParameter("@Detalle", Detalle);
                ParamSQL[4] = new SqlParameter("@Estado", estado);

                return ParamSQL;
            }


        }

    }
}

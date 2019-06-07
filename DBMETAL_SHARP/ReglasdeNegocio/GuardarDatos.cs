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
        private SqlConnection objconexion;
        private SqlCommand cmd;
        private bool Respueta = false;
        public static string _Existe(string Tabla, string Campo)
        {
            DataSet dataSet = ProcesosSQL.ExistenciaCodigoTabla("SP_Consulta_ExistenciaCodigoTabla", new SqlParameter[]
            {
                new SqlParameter("@Tabla", Tabla),
                new SqlParameter("@Codigo", Campo)
            });
            return dataSet.Tables[0].Rows[0]["Tipo"].ToString().Trim();
        }
        public bool booleano(string procedimiento, SqlParameter[] pparametros)
        {
            try
            {
                this.objconexion = Conexion.OpenConexion();
                this.cmd = new SqlCommand(procedimiento, this.objconexion);
                this.cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < pparametros.Length; i++)
                {
                    SqlParameter sqlParameter = pparametros[i];
                    this.cmd.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
                }
                if (this.cmd.ExecuteNonQuery() == 1)
                {
                    this.Respueta = true;
                }
                else
                {
                    this.Respueta = false;
                }
                ConexionDB.CloseConexion(this.cmd);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
            return this.Respueta;
        }
        public int Numerico(string procedimiento, SqlParameter[] pparametros)
        {
            this.objconexion = Conexion.OpenConexion();
            this.cmd = new SqlCommand(procedimiento, this.objconexion);
            this.cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < pparametros.Length; i++)
            {
                SqlParameter sqlParameter = pparametros[i];
                this.cmd.Parameters.Add(sqlParameter).Value = sqlParameter.Value;
            }
            int result = Convert.ToInt32(this.cmd.ExecuteScalar());
            Conexion.CloseConexion(this.cmd);
            return result;
        }
        public static DataTable GetRoles(string queryString)
        {
            SqlConnection sqlConnection = Conexion.OpenConexion();
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(queryString, sqlConnection);
            sqlDataAdapter.Fill(dataSet, "usersInRoles");
            sqlConnection.Close();
            return dataSet.Tables[0];
        }
        public bool _ImagenPublicitaria(int Op, byte[] Imagen)
        {
            this.objconexion = Conexion.OpenConexion();
            this.cmd = new SqlCommand("Sp_Guardar_Logo", this.objconexion);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.Add("Foto", SqlDbType.VarBinary);
            this.cmd.Parameters.Add("Op", SqlDbType.Int);
            this.cmd.Parameters["Foto"].Value = Imagen;
            this.cmd.Parameters["Op"].Value = Op;
            this.cmd.ExecuteNonQuery();
            return true;
        }
        public static SqlParameter[] Parametros_PersonalMuestreo(string Op, string Identificacacion, string Nombre, string Apellido, string Direccion, string TelFijo, string Celular, string Email, int Rol, byte[] Foto, bool Estado, DateTime create)
        {
            SqlParameter[] array = new SqlParameter[12];
            if (Op.Trim().Length == 0)
            {
                array[0] = new SqlParameter("@Op", GuardarDatos._Existe("Tbl_PersonalMuestreo", Identificacacion.Trim()));
            }
            else
            {
                array[0] = new SqlParameter("@Op", "D");
            }
            array[1] = new SqlParameter("@Identificacacion", Identificacacion.Trim());
            array[2] = new SqlParameter("@Nombre", Nombre.Trim());
            array[3] = new SqlParameter("@Apellido", Apellido.Trim());
            array[4] = new SqlParameter("@Direccion", Direccion.Trim());
            array[5] = new SqlParameter("@TelFijo", TelFijo.Trim());
            array[6] = new SqlParameter("@Celular", Celular.Trim());
            array[7] = new SqlParameter("@Email", Email.Trim());
            array[8] = new SqlParameter("@Rol", Rol);
            array[9] = new SqlParameter("@Foto", Foto);
            array[10] = new SqlParameter("@Estado", Estado);
            array[11] = new SqlParameter("@Creado", create);
            return array;
        }
        public static SqlParameter[] Parameter_GerPermissions(string nameUser, string PageMaster)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Name", nameUser),
                new SqlParameter("@FKPage", PageMaster)
            };
        }
        public static SqlParameter[] Parameter_UpdateSelloControls(int ConsecutivoBascula, string SelloDesc, string SelloControl, string SelloContNuevo)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ConsecutivoBascula", ConsecutivoBascula),
                new SqlParameter("@SelloControlDes", SelloDesc),
                new SqlParameter("@SelloControl", SelloControl),
                new SqlParameter("@SelloControlNuevo", SelloContNuevo)
            };
        }
        public static SqlParameter[] Parametros_MuestreoPM(bool isRechekeo, string Op, int IdUsuario, string Consecutivo, DateTime Reportado, int IdEncargado, int Idercero, int IdSeguridad, int IdCuartea, string SelloControl, string Sello1, decimal PesoSello1, string DestinoSello1, int IdTipoSello1, int IdAnalisisSello1, string DetalleSello1, string Sello2, decimal PesoSello2, string DestinoSello2, int IdTipoSello2, int IdAnalisisSello2, string DetalleSello2, string Sello3, decimal PesoSello3, string DestinoSello3, int IdTipoSello3, int IdAnalisisSello3, string DetalleSello3, string Sello4, decimal PesoSello4, string DestinoSello4, int IdTipoSello4, int IdAnalisisSello4, string DetalleSello4, string Sello5, decimal PesoSello5, string DestinoSello5, int IdTipoSello5, int IdAnalisisSello5, string DetalleSello5, string Sello6, decimal PesoSello6, string DestinoSello6, int IdTipoSello6, int IdAnalisisSello6, string DetalleSello6, decimal TenorAu, decimal TenorAg, decimal Humedad, string Contenedor, string CodProyect, decimal PesoTotalMuestra, bool available, string descProyect)
        {
            SqlParameter[] array = new SqlParameter[53];
            if (!isRechekeo)
            {
                if (Op.Trim().Length == 0)
                {
                    array[0] = new SqlParameter("@Op", GuardarDatos._Existe("Tbl_ReporteMuestraPM", Consecutivo.Trim()));
                }
                else
                {
                    array[0] = new SqlParameter("@Op", "D");
                }
            }
            else
            {
                array[0] = new SqlParameter("@Op", "U");
            }
            array[1] = new SqlParameter("@Consecutivo", Consecutivo.Trim());
            array[2] = new SqlParameter("@ConsecutivoBascula", Consecutivo.Trim());
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("es-CO");
            Reportado = Convert.ToDateTime(Reportado.ToString("dd/MM/yyyy"), cultureInfo);
            array[3] = new SqlParameter("@Reportado", Reportado);
            array[4] = new SqlParameter("@IdEncargado", IdEncargado);
            array[5] = new SqlParameter("@Idercero", Idercero);
            array[6] = new SqlParameter("@IdSeguridad", IdSeguridad);
            array[7] = new SqlParameter("@IdCuartea", IdCuartea);
            array[8] = new SqlParameter("@SelloControl", SelloControl);
            array[9] = new SqlParameter("@Sello1", Sello1);
            array[10] = new SqlParameter("@PesoSello1", PesoSello1);
            array[11] = new SqlParameter("@DestinoSello1", DestinoSello1);
            array[12] = new SqlParameter("@IdTipoSello1", IdTipoSello1);
            array[13] = new SqlParameter("@IdAnalisisSello1", IdAnalisisSello1);
            array[14] = new SqlParameter("@DetalleSello1", DetalleSello1.Trim());
            array[15] = new SqlParameter("@Sello2", Sello2.Trim());
            array[16] = new SqlParameter("@PesoSello2", PesoSello2);
            array[17] = new SqlParameter("@DestinoSello2", DestinoSello2.Trim());
            array[18] = new SqlParameter("@IdTipoSello2", IdTipoSello2);
            array[19] = new SqlParameter("@IdAnalisisSello2", IdAnalisisSello2);
            array[20] = new SqlParameter("@DetalleSello2", DetalleSello2);
            array[21] = new SqlParameter("@Sello3", Sello3);
            array[22] = new SqlParameter("@PesoSello3", PesoSello3);
            array[23] = new SqlParameter("@DestinoSello3", DestinoSello3);
            array[24] = new SqlParameter("@IdTipoSello3", IdTipoSello3);
            array[25] = new SqlParameter("@IdAnalisisSello3", IdAnalisisSello3);
            array[26] = new SqlParameter("@DetalleSello3", DetalleSello3.Trim());
            array[27] = new SqlParameter("@Sello4", Sello4.Trim());
            array[28] = new SqlParameter("@PesoSello4", PesoSello4);
            array[29] = new SqlParameter("@DestinoSello4", DestinoSello4);
            array[30] = new SqlParameter("@IdTipoSello4", IdTipoSello4);
            array[31] = new SqlParameter("@IdAnalisisSello4", IdAnalisisSello4);
            array[32] = new SqlParameter("@DetalleSello4", DetalleSello4.Trim());
            array[33] = new SqlParameter("@Sello5", Sello5);
            array[34] = new SqlParameter("@PesoSello5", PesoSello5);
            array[35] = new SqlParameter("@DestinoSello5", DestinoSello5.Trim());
            array[36] = new SqlParameter("@IdTipoSello5", IdTipoSello5);
            array[37] = new SqlParameter("@IdAnalisisSello5", IdAnalisisSello5);
            array[38] = new SqlParameter("@DetalleSello5", DetalleSello5);
            array[39] = new SqlParameter("@Sello6", Sello6);
            array[40] = new SqlParameter("@PesoSello6", PesoSello6);
            array[41] = new SqlParameter("@DestinoSello6", DestinoSello6);
            array[42] = new SqlParameter("@IdTipoSello6", IdTipoSello6);
            array[43] = new SqlParameter("@IdAnalisisSello6", IdAnalisisSello6);
            array[44] = new SqlParameter("@DetalleSello6", DetalleSello6);
            array[45] = new SqlParameter("@TenorAu", DBNull.Value);
            array[46] = new SqlParameter("@TenorAg", DBNull.Value);
            array[47] = new SqlParameter("@Humedad", DBNull.Value);
            array[48] = new SqlParameter("@IdUsuario", IdUsuario);
            array[49] = new SqlParameter("@CodContenedor", Contenedor);
            array[50] = new SqlParameter("@CodProyecto", CodProyect);
            array[51] = new SqlParameter("@PesoTotalMuestra", PesoTotalMuestra);
            array[52] = new SqlParameter("@NombreProyecto", descProyect);
            return array;
        }
        public static SqlParameter[] Parametros_OrdenesMuestreoPM(string Op, string IdOrden, DateTime FechaOrden, int TotalMuestras, int Laboratorio, bool TipoAnalisis, int IdUsuario)
        {
            SqlParameter[] array = new SqlParameter[7];
            if (Op.Trim().Length == 0)
            {
                array[0] = new SqlParameter("@Op", GuardarDatos._Existe("OrdenesMuestraPM", IdOrden.Trim()));
            }
            else
            {
                array[0] = new SqlParameter("@Op", "D");
            }
            array[1] = new SqlParameter("@IdOrden", IdOrden.Trim());
            array[2] = new SqlParameter("@FechaOrden", FechaOrden);
            array[3] = new SqlParameter("@TotalMuestras", TotalMuestras);
            array[4] = new SqlParameter("@Laboratorio", Laboratorio);
            array[5] = new SqlParameter("@TipoAnalisis", TipoAnalisis);
            array[6] = new SqlParameter("@IdUsuario", IdUsuario);
            return array;
        }
        public static SqlParameter[] Parametros_BorrarMuestreoPM(string SelloControl)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@SelloControl", SelloControl.Trim())
            };
        }
        public static SqlParameter[] Parametros_OrdenesDetalleMuestreoPM(string Op, string SelloControl, string TipoMuestra, string IdLab, string Duplicado, int ConsecutivoBascula, bool QAQC, bool AC, bool Available, DateTime FechaProduccion, DateTime FechaRegistro, int Usuario)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Op", "I"),
                new SqlParameter("@SelloControl", SelloControl.Trim()),
                new SqlParameter("@TipoMuestra", TipoMuestra),
                new SqlParameter("@IdLab", IdLab),
                new SqlParameter("@Duplicado", Duplicado),
                new SqlParameter("@ConsecutivoBascula", ConsecutivoBascula),
                new SqlParameter("@QAQC", QAQC),
                new SqlParameter("@AC", AC),
                new SqlParameter("@Available", Available),
                new SqlParameter("@FechaProduccion", FechaProduccion),
                new SqlParameter("@FechaRegistro", FechaRegistro),
                new SqlParameter("@Usuario", Usuario)
            };
        }
        public static SqlParameter[] Parametros_DetalleExcelPM(string Op, string SelloControl, decimal humedad, decimal au, decimal ag, decimal peso, string usuario, string idLab)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@SelloControl", SelloControl.Trim()),
                new SqlParameter("@humedad", humedad),
                new SqlParameter("@au", au),
                new SqlParameter("@ag", ag),
                new SqlParameter("@peso", peso),
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@IdLab", idLab)
            };
        }
        public static SqlParameter[] Parametros_DetalleExcelZandor(string Op, string SelloControl, decimal au, decimal augr, string usuario)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@SelloControl", SelloControl.Trim()),
                new SqlParameter("@au", au),
                new SqlParameter("@augr", augr),
                new SqlParameter("@usuario", usuario)
            };
        }
        public static SqlParameter[] Parametros_DetalleExcelReanalisis(string SelloControl, decimal au, string tipoIngreso)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@SelloControl", SelloControl.Trim()),
                new SqlParameter("@au", au),
                new SqlParameter("@TipoIngreso", tipoIngreso)
            };
        }
        public static SqlParameter[] Parametros_DetalleExcelHumedad(string Op, string SelloControl, decimal humedad, string usuario)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@SelloControl", SelloControl.Trim()),
                new SqlParameter("@Humedad", humedad),
                new SqlParameter("@usuario", usuario)
            };
        }

        public static SqlParameter[] CargaReclamosActLab(string SelloControl, string idLab, decimal humedad, decimal au, decimal ag, decimal peso, string tipoIngreso, string usuario)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@SelloControl", SelloControl.Trim()),
                new SqlParameter("@IdLab", idLab),
                new SqlParameter("@Humedad", humedad),
                new SqlParameter("@au", au),
                new SqlParameter("@ag", ag),
                new SqlParameter("@peso", peso),
                new SqlParameter("@TipoIngreso", tipoIngreso),
                new SqlParameter("@usuario", usuario)
            };
        }



        public static SqlParameter[] Parametros_ToneladaSeca(string consecutivo, decimal humedad)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Consecutivo", consecutivo),
                new SqlParameter("@Humedad", humedad)
            };
        }
        public static SqlParameter[] Parametros_ActQAQC(int consecutivo)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Consecutivo", consecutivo)
            };
        }
        public static SqlParameter[] Parametros_Update_MuestreoPM(int Consecutivo, string Duplicado)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Consecutivo", Consecutivo),
                new SqlParameter("@Duplicado", Duplicado)
            };
        }
        public static SqlParameter[] Parametros_Cerrar_PeriodoPM(string idPerioso)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Periodos", idPerioso)
            };
        }
        public static SqlParameter[] Parametros_Insertar_PeriodoPM(string op, DateTime fechaInicial, DateTime fechaFinal, int cboAno, int cboMes, string cboPeriodo, decimal onzasFundidas, decimal recuperacion, decimal onzasRecuperadas, int usuario)
        {
            string text = string.Concat(new string[]
            {
                cboAno.ToString().Trim(),
                "-",
                cboMes.ToString().Trim(),
                "-",
                cboPeriodo.ToString().Trim()
            });
            SqlParameter[] array = new SqlParameter[12];
            if (op.Trim().Length == 0)
            {
                array[0] = new SqlParameter("@Op", GuardarDatos._Existe("Tbl_PeriodoLiquidacion", text));
            }
            else
            {
                array[0] = new SqlParameter("@Op", "D");
            }
            array[1] = new SqlParameter("@IdPeriodo", text);
            array[2] = new SqlParameter("@FechaInicio", fechaInicial);
            array[3] = new SqlParameter("@FechaFin", fechaFinal);
            array[4] = new SqlParameter("@RecuperacionPlanta", recuperacion);
            array[5] = new SqlParameter("@AnoPeriodo", cboAno);
            array[6] = new SqlParameter("@MesPeriodo", cboMes);
            array[7] = new SqlParameter("@Periodo", cboPeriodo);
            array[8] = new SqlParameter("@Available", true);
            array[9] = new SqlParameter("@OnzasFundidas", onzasFundidas);
            array[10] = new SqlParameter("@OnzasRecuperadas", onzasRecuperadas);
            array[11] = new SqlParameter("@Usuario", usuario);
            return array;
        }
        public static SqlParameter[] Parametros_Update_QAQCPM(bool QAQC, int ConsecutivoBascula, string SelloControl, bool Reanalisis)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@QAQC", QAQC),
                new SqlParameter("@ConsecutivoBascula", ConsecutivoBascula),
                new SqlParameter("@SelloControl", SelloControl),
                new SqlParameter("@Reanalisis", Reanalisis)
            };
        }
        public static SqlParameter[] Parametros_Update_Rol(int roleID, string nameForm, string controlID, int InVisible, int Disabled, int ContenedorPeqMineria, int ContenedorZandor, int ContenedorOtros)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@RoleID", roleID),
                new SqlParameter("@PageName", nameForm),
                new SqlParameter("@ControlID", controlID),
                new SqlParameter("@invisible", InVisible),
                new SqlParameter("@disabled", Disabled),
                new SqlParameter("@ContenedorPeqMineria", ContenedorPeqMineria),
                new SqlParameter("@ContenedorZandor", ContenedorZandor),
                new SqlParameter("@ContenedorOtros", ContenedorOtros)
            };
        }
        public static SqlParameter[] Parametros_Localizacion(string Op, string Identificacacion, string Nombre, bool estado, string Detalle)
        {
            SqlParameter[] result;
            if (Op.Trim().Length == 0)
            {
                result = new SqlParameter[]
                {
                    new SqlParameter("@Op", GuardarDatos._Existe("Tbl_Localizacion", Identificacacion.Trim())),
                    new SqlParameter("@Identificacacion", Identificacacion.Trim()),
                    new SqlParameter("@Nombre", Nombre.Trim()),
                    new SqlParameter("@Detalle", Detalle),
                    new SqlParameter("@Estado", estado)
                };
            }
            else
            {
                result = new SqlParameter[]
                {
                    new SqlParameter("@Op", "D"),
                    new SqlParameter("@Identificacacion", Identificacacion.Trim()),
                    new SqlParameter("@Nombre", Nombre.Trim()),
                    new SqlParameter("@Detalle", Detalle),
                    new SqlParameter("@Estado", estado)
                };
            }
            return result;
        }
    }
}

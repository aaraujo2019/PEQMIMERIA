using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_Motos : Form
    {
        public Frm_Motos(string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        public int Op = 0;
        public int IdUsuario = 0;
        public string Login;

        public void EjecutaPasarDato(string Dato)
        {
            switch (Op)
            {
                case 1:
                    this.TxbPlacaMoto.Text = Dato;
                    TxbPlacaMoto_Leave(null, null);
                    break;
                case 2:
                    this.TxbLicenciaFCodPropietrio.Text = Dato;
                    TxbLicenciaFCodPropietrio_Leave(null, null);
                    break;
            }
        }

        public static class ImageConvert
        {
            public static byte[] imageToByte(System.Drawing.Image imageIn)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                byte[] arrImg = ms.GetBuffer();
                ms.Flush();
                ms.Close();
                return arrImg;
            }

            public static System.Drawing.Image byteToImage(byte[] byteArrayIn)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.TxbPlacaMoto.Text.Trim().Length > 6)
            {
                try
                {
                    SqlParameter[] ParametrosEnt_Vehiculos = new SqlParameter[40];

                    #region Determinando si se hace insert o update
                    SqlParameter[] ParamTipo = new SqlParameter[4];
                    ParamTipo[0] = new SqlParameter("@Op", "ExisteIdPlacaMoto");
                    ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                    ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                    ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);

                    if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                        ParametrosEnt_Vehiculos[0] = new SqlParameter("@Op", "I");
                    else
                        ParametrosEnt_Vehiculos[0] = new SqlParameter("@Op", "U");
                    #endregion

                    ParametrosEnt_Vehiculos[1] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                    ParametrosEnt_Vehiculos[2] = new SqlParameter("@Placa", this.TxbPlacaMoto.Text.Trim());
                    ParametrosEnt_Vehiculos[3] = new SqlParameter("@Descripcion", this.RtbLicenciaFDescripcion.Text.Trim());
                    ParametrosEnt_Vehiculos[4] = new SqlParameter("@Licencia", this.TxbLicenciaFLicencia.Text.Trim());
                    ParametrosEnt_Vehiculos[5] = new SqlParameter("@Propietario", this.TxbLicenciaFCodPropietrio.Text.Trim());
                    ParametrosEnt_Vehiculos[6] = new SqlParameter("@Modelo", this.TxbLicenciaFModelo.Text.Trim());
                    ParametrosEnt_Vehiculos[7] = new SqlParameter("@Marca", this.TxbLicenciaFMarca.Text.Trim());
                    ParametrosEnt_Vehiculos[8] = new SqlParameter("@Linea", this.TxbLicenciaFLinea.Text.Trim());
                    ParametrosEnt_Vehiculos[9] = new SqlParameter("@Servicio", this.TxbLicenciaFServicio.Text.Trim());
                    ParametrosEnt_Vehiculos[10] = new SqlParameter("@Cilindraje", this.TxbLicenciaFCilindraje.Text.Trim());
                    ParametrosEnt_Vehiculos[11] = new SqlParameter("@Color", this.TxbLicenciaFColor.Text.Trim());
                    ParametrosEnt_Vehiculos[12] = new SqlParameter("@Combustible", this.TxbLicenciaFCombustible.Text.Trim());
                    ParametrosEnt_Vehiculos[13] = new SqlParameter("@Clase", this.TxbLicenciaFClase.Text.Trim());
                    ParametrosEnt_Vehiculos[14] = new SqlParameter("@Carroceria", this.TxbLicenciaFCarroceria.Text.Trim());
                    ParametrosEnt_Vehiculos[15] = new SqlParameter("@Capacidad", this.TxbLicenciaFCapacidad.Text.Trim());
                    ParametrosEnt_Vehiculos[16] = new SqlParameter("@Motor", this.TxbLicenciaFMotor.Text.Trim());
                    ParametrosEnt_Vehiculos[17] = new SqlParameter("@Reg1", this.TxbLicenciaFReg3.Text.Trim());
                    ParametrosEnt_Vehiculos[18] = new SqlParameter("@Vin", this.TxbLicenciaFVin.Text.Trim());
                    ParametrosEnt_Vehiculos[19] = new SqlParameter("@Serie", this.TxbLicenciaFSerie.Text.Trim());
                    ParametrosEnt_Vehiculos[20] = new SqlParameter("@Reg2", this.TxbLicenciaFReg1.Text.Trim());
                    ParametrosEnt_Vehiculos[21] = new SqlParameter("@Chasis", this.TxbLicenciaFChasis.Text.Trim());
                    ParametrosEnt_Vehiculos[22] = new SqlParameter("@Reg3", this.TxbLicenciaFReg2.Text.Trim());
                    ParametrosEnt_Vehiculos[23] = new SqlParameter("@TipoVehiculo", this.CmbLicenciaFTipoVehiculo.SelectedIndex);
                    ParametrosEnt_Vehiculos[24] = new SqlParameter("@RestriccionMovilidad", this.TxbLicenciaRRestriccionMovilidad.Text.Trim());
                    ParametrosEnt_Vehiculos[25] = new SqlParameter("@Blindaje", this.TxbLicenciaRBlindaje.Text.Trim());
                    ParametrosEnt_Vehiculos[26] = new SqlParameter("@Potencia", this.TxbLicenciaRPotencia.Text.Trim());
                    ParametrosEnt_Vehiculos[27] = new SqlParameter("@DeclaracionImportacion", this.TxbLicenciaRDeclaracionImportacion.Text.Trim());
                    ParametrosEnt_Vehiculos[28] = new SqlParameter("@IE", this.TxbLicenciaRIE.Text.Trim());
                    ParametrosEnt_Vehiculos[29] = new SqlParameter("@FechaImportacion", this.DtpLicenciaRFechaImportacion.Text.Trim().Replace("/", ""));
                    ParametrosEnt_Vehiculos[30] = new SqlParameter("@Puertas", this.TxbLicenciaRPuertas.Text.Trim());
                    ParametrosEnt_Vehiculos[31] = new SqlParameter("@LimitacionPropiedad", this.TxbLicenciaRLimitacionPropiedad.Text.Trim());
                    ParametrosEnt_Vehiculos[32] = new SqlParameter("@FechaMatricula", this.DtpLicenciaRFechaMatricula.Text.Trim().Replace("/", ""));
                    ParametrosEnt_Vehiculos[33] = new SqlParameter("@FechaExpLicTTO", this.DtpLicenciaRFechaExpLicencia.Text.Trim().Replace("/", ""));
                    ParametrosEnt_Vehiculos[34] = new SqlParameter("@FechaVencimiento", this.DtpLicenciaRFechaVencimiento.Text.Trim().Replace("/", ""));
                    ParametrosEnt_Vehiculos[35] = new SqlParameter("@OrganismoTransito", this.TxbLicenciaROrganismoTransito.Text.Trim());
                    ParametrosEnt_Vehiculos[36] = new SqlParameter("@Foto", ImageConvert.imageToByte(this.ptbVehiculo.Image));
                    ParametrosEnt_Vehiculos[37] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt_Vehiculos[38] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt_Vehiculos[39] = new SqlParameter("@Usuario", this.IdUsuario);

                    GuardarDatos GuardarDatos = new GuardarDatos();
                    GuardarDatos.booleano("GRBMotos", ParametrosEnt_Vehiculos);

                    if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                        MessageBox.Show("Datos de la Moto Insertados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Datos de la Moto actualizado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Numero de la placa no cumple con el minino de caracteres esperados");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op = 2;
            Frm_Consultas Forma = new Frm_Consultas(5);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }


        private void TxbLicenciaFCodPropietrio_Leave(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_ConsultaVehiculos = new SqlParameter[4];
            Parametros_ConsultaVehiculos[0] = new SqlParameter("@Op", "Propietarios");
            Parametros_ConsultaVehiculos[1] = new SqlParameter("@ParametroChar", this.TxbLicenciaFCodPropietrio.Text.Trim());
            Parametros_ConsultaVehiculos[2] = new SqlParameter("@ParametroInt", "");
            Parametros_ConsultaVehiculos[3] = new SqlParameter("@ParametroNuemric", "0.0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Propietarios ReaderVehiculos = new Ent_Propietarios();

            ReaderVehiculos = Maestro.Propietarios("SpConsulta_Tablas", Parametros_ConsultaVehiculos);

            if (ReaderVehiculos.Identificacion != null)
            {
                this.TxbLicenciaFCodPropietrio.Text = ReaderVehiculos.Identificacion.ToString();
                this.TxbLicenciaFNombPropietario.Text = ReaderVehiculos.Nombre.ToString();
            }
        }

        private void BtnSeleccArchivo_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "\\SoftTap\\";
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            this.ptbVehiculo.Image = Image.FromFile(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void TxbPlacaMoto_Leave(object sender, EventArgs e)
        {
            #region Leave de page Licencia
            if (this.TxbPlacaMoto.Text.Trim().Length > 1)
            {
                SqlParameter[] Parametros_ConsultaVehiculos = new SqlParameter[4];
                Parametros_ConsultaVehiculos[0] = new SqlParameter("@Op", "MotoEspe");
                Parametros_ConsultaVehiculos[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                Parametros_ConsultaVehiculos[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_ConsultaVehiculos[3] = new SqlParameter("@ParametroNuemric", "0.0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                Ent_Motos ReaderMotos = new Ent_Motos();

                ReaderMotos = Maestro.Moto("SpConsulta_Tablas", Parametros_ConsultaVehiculos);

                if (ReaderMotos.Placa != null)
                {
                    this.ChbEstado.Checked = ReaderMotos.Estado;
                    if (ReaderMotos.Estado)
                        this.ChbEstado.Text = "Activo";
                    else
                        this.ChbEstado.Text = "Bloqueado";

                    this.TxbPlacaMoto.Text = ReaderMotos.Placa.ToString();
                    this.TxbLicenciaFLicencia.Text = ReaderMotos.Licencia.ToString();
                    this.TxbLicenciaFCodPropietrio.Text = ReaderMotos.IdentificacionPropietrio.Trim();
                    this.TxbLicenciaFNombPropietario.Text = ReaderMotos.NombrePropietario;
                    this.TxbLicenciaFModelo.Text = ReaderMotos.Modelo.ToString();
                    this.TxbLicenciaFMarca.Text = ReaderMotos.Marca.ToString();
                    this.TxbLicenciaFLinea.Text = ReaderMotos.Linea.ToString();
                    this.TxbLicenciaFServicio.Text = ReaderMotos.Servicio.ToString();
                    this.TxbLicenciaFCilindraje.Text = ReaderMotos.Cilindraje.ToString();
                    this.TxbLicenciaFColor.Text = ReaderMotos.Color.ToString();
                    this.TxbLicenciaFCombustible.Text = ReaderMotos.Combustible.ToString();
                    this.TxbLicenciaFClase.Text = ReaderMotos.Clase.ToString();
                    this.TxbLicenciaFCarroceria.Text = ReaderMotos.Carroceria.ToString();
                    this.TxbLicenciaFCapacidad.Text = ReaderMotos.Capacidad.ToString();
                    this.TxbLicenciaFMotor.Text = ReaderMotos.Motor.ToString();
                    this.TxbLicenciaFReg1.Text = ReaderMotos.Reg2.ToString();
                    this.TxbLicenciaFVin.Text = ReaderMotos.Vin.ToString();
                    this.TxbLicenciaFSerie.Text = ReaderMotos.Serie.ToString();
                    this.TxbLicenciaFReg2.Text = ReaderMotos.Reg3.ToString();
                    this.TxbLicenciaFChasis.Text = ReaderMotos.Chasis.ToString();
                    this.TxbLicenciaFReg3.Text = ReaderMotos.Reg1.ToString();
                    this.CmbLicenciaFTipoVehiculo.SelectedIndex = ReaderMotos.TipoVehiculo;
                    this.RtbLicenciaFDescripcion.Text = ReaderMotos.Descripcion.ToString();
                    this.TxbLicenciaRRestriccionMovilidad.Text = ReaderMotos.RestriccionMovilidad.ToString();
                    this.TxbLicenciaRBlindaje.Text = ReaderMotos.Blindaje.ToString();
                    this.TxbLicenciaRPotencia.Text = ReaderMotos.Potencia.ToString();
                    this.TxbLicenciaRDeclaracionImportacion.Text = ReaderMotos.DeclaracionImportacion.ToString();
                    this.TxbLicenciaRIE.Text = ReaderMotos.IE.ToString();
                    this.DtpLicenciaRFechaImportacion.Value = ReaderMotos.FechaImportacion;
                    this.TxbLicenciaRPuertas.Text = ReaderMotos.Puertas.ToString();
                    this.TxbLicenciaRLimitacionPropiedad.Text = ReaderMotos.LimitacionPropiedad.ToString();
                    this.DtpLicenciaRFechaMatricula.Value = ReaderMotos.FechaMatricula;
                    this.DtpLicenciaRFechaExpLicencia.Value = ReaderMotos.FechaExpLicTTO;
                    this.DtpLicenciaRFechaVencimiento.Value = ReaderMotos.FechaVencimiento;
                    this.TxbLicenciaROrganismoTransito.Text = ReaderMotos.OrganismoTransito.ToString();
                    this.ptbVehiculo.Image = ImageConvert.byteToImage(ReaderMotos.Foto);

                    #region Actualizando el DatGridView Seguros
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "MotosSeg");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", ReaderMotos.Placa);
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.dataGridViewSeguros.DataSource = DS;
                        this.dataGridViewSeguros.DataMember = "Result";
                        this.dataGridViewSeguros.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    #region Actualizando el DatGridView De TecnoMecanica

                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "MotosTecno");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", ReaderMotos.Placa);
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.dataGridViewTecno.DataSource = DS;
                        this.dataGridViewTecno.DataMember = "Result";
                        this.dataGridViewTecno.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    #region Llenado el DataGrid de los adjuntos
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosMotos");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", "");
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", ReaderMotos.Id);
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DtgAdjunto.DataSource = DS;
                        this.DtgAdjunto.DataMember = "Result";
                        this.DtgAdjunto.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                }

            }
            #endregion
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Op = 1;
            Frm_Consultas Forma = new Frm_Consultas(11);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void BtnGuardarSeg_Click(object sender, EventArgs e)
        {
            if (this.TxbPlacaMoto.Text.Trim().Length > 0)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[22];
                    bool Insertar = false;

                    #region Determinando si Existe el vehiculo al se le va insertar/actualizar el seguro
                    SqlParameter[] ParamTipo = new SqlParameter[4];
                    ParamTipo[0] = new SqlParameter("@Op", "ExisteIdPlacaMoto");
                    ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                    ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                    ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                    if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                        MessageBox.Show("Moto no Existe");
                    else
                    {
                        #region Determinando si se hace insert o update
                        ParamTipo[0] = new SqlParameter("@Op", "ExisteSeguroMoto");
                        ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbSegurosPoliza.Text.Trim());
                        ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                        ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                        if (Convert.ToInt32(DSet.Tables[0].Rows[0]["Id"]) == 0)
                        {
                            ParametrosEnt[0] = new SqlParameter("@Op", "I");
                            Insertar = true;
                        }
                        else
                            ParametrosEnt[0] = new SqlParameter("@Op", "U");
                        #endregion

                        ParametrosEnt[1] = new SqlParameter("@IdPlaca", Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]));
                        ParametrosEnt[2] = new SqlParameter("@Proveedor", this.TxbSegurosProveedor.Text.Trim());
                        ParametrosEnt[3] = new SqlParameter("@IdTomador", this.TxbSegurosIdTomador.Text.Trim());
                        ParametrosEnt[4] = new SqlParameter("@NombreTomador", this.TxbSegurosNombreTomador.Text.Trim());
                        ParametrosEnt[5] = new SqlParameter("@FechaExpedicion", this.DtpSegurosFechaExpedicion.Text.Trim().Replace("/", ""));
                        ParametrosEnt[6] = new SqlParameter("@FechaInicial", this.DtpSegurosFechaInicio.Text.Trim().Replace("/", ""));
                        ParametrosEnt[7] = new SqlParameter("@FechaFinal", this.DtpSegurosFechaFinal.Text.Trim().Replace("/", ""));
                        ParametrosEnt[8] = new SqlParameter("@Telefono", this.TxbSegurosTelefono.Text.Trim());
                        ParametrosEnt[9] = new SqlParameter("@CodigoSucursal", this.TxbSegurosCodSucursalExpedida.Text.Trim());
                        ParametrosEnt[10] = new SqlParameter("@ClaveProductor", this.TxbSegurosClaveProductor.Text.Trim());
                        ParametrosEnt[11] = new SqlParameter("@CiudadExpedicion", this.TxbSegurosCiudadExpedicion.Text.Trim());
                        ParametrosEnt[12] = new SqlParameter("@Direccion", this.TxbSegurosDireccionTomador.Text.Trim());
                        ParametrosEnt[13] = new SqlParameter("@CiudadResidencia", this.TxbSegurosCiudadResidencia.Text.Trim());
                        ParametrosEnt[14] = new SqlParameter("@Poliza", this.TxbSegurosPoliza.Text.Trim());
                        ParametrosEnt[15] = new SqlParameter("@Reemplaza", this.TxbSegurosReemplazaPoliza.Text.Trim());
                        ParametrosEnt[16] = new SqlParameter("@ClaseVehiculo", this.TxbSegurosClaseVehiculo.Text.Trim());
                        ParametrosEnt[17] = new SqlParameter("@Pasajeros", this.TxbSegurosPasajeros.Text.Trim());
                        ParametrosEnt[18] = new SqlParameter("@Tarifa", this.TxbSegurosTarifa.Text.Trim());
                        ParametrosEnt[19] = new SqlParameter("@Usuario", this.IdUsuario);
                        ParametrosEnt[20] = new SqlParameter("@Realizado", DateTime.Now);
                        ParametrosEnt[21] = new SqlParameter("@Maquina", Environment.MachineName);
                    }
                    #endregion

                    GuardarDatos Guardar = new GuardarDatos();
                    Guardar.booleano("GRBBascula_MotosSeguros", ParametrosEnt);
                    if (Insertar)
                        MessageBox.Show("Seguro ingresado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Seguro actualizado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region Actualizando el DatGridView Seguros
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "MotosSeg");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.dataGridViewSeguros.DataSource = DS;
                        this.dataGridViewSeguros.DataMember = "Result";
                        this.dataGridViewSeguros.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                }


                catch (Exception Exc)
                {
                    MessageBox.Show("OCURRIÓ UN ERROR AL ADJUNTAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_GuardarTecno_Click(object sender, EventArgs e)
        {
            if (this.TxbPlacaMoto.Text.Length > 0)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[14];
                    bool Insertar = false;

                    #region Determinando si Existe el vehiculo al se le va insertar/actualizar la TenoMecanica
                    SqlParameter[] ParamTipo = new SqlParameter[4];
                    ParamTipo[0] = new SqlParameter("@Op", "ExisteIdPlacaMoto");
                    ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                    ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                    ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                    #endregion
                    if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                        MessageBox.Show("Moto no Existe");
                    else
                    {
                        #region Determinando si se hace insert o update
                        ParamTipo[0] = new SqlParameter("@Op", "ExisteTecnoMoto");
                        ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbTecnoMecanicaNroControl.Text.Trim());
                        ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                        ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                        if (Convert.ToInt32(DSet.Tables[0].Rows[0]["Id"]) == 0)
                        {
                            ParametrosEnt[0] = new SqlParameter("@Op", "I");
                            Insertar = true;
                        }
                        else
                            ParametrosEnt[0] = new SqlParameter("@Op", "U");
                        #endregion

                        ParametrosEnt[1] = new SqlParameter("@IdPlaca", Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]));
                        ParametrosEnt[2] = new SqlParameter("@NroControl", this.TxbTecnoMecanicaNroControl.Text.Trim());
                        ParametrosEnt[3] = new SqlParameter("@FechaExpedicion", this.DtpTecnoMecanicaFechaExpedicion.Text.Trim().Replace("/", ""));
                        ParametrosEnt[4] = new SqlParameter("@FechaVencimiento", this.DtpTecnoMecanicaFechaFinal.Text.Trim().Replace("/", ""));
                        ParametrosEnt[5] = new SqlParameter("@IdPropietario", this.TxbTecnoMecanicaIdPropietario.Text.Trim());
                        ParametrosEnt[6] = new SqlParameter("@NombrePropietario", this.TxbTecnoMecanicaNombrePropietario.Text.Trim());
                        ParametrosEnt[7] = new SqlParameter("@NitAutomotor", this.TxbTecnoMecanicaNit.Text.Trim());
                        ParametrosEnt[8] = new SqlParameter("@NombreAutomotor", this.TxbTecnoMecanicaCentroDiagnostico.Text.Trim());
                        ParametrosEnt[9] = new SqlParameter("@ConsecutivoRunt", this.TxbTecnoMecanicaNroConsecutivoRunt.Text.Trim());
                        ParametrosEnt[10] = new SqlParameter("@CertificadoAcreditacion", this.TxbTecnoMecanicaNroCertificadoAcreditacion.Text.Trim());
                        ParametrosEnt[11] = new SqlParameter("@Usuario", this.IdUsuario);
                        ParametrosEnt[12] = new SqlParameter("@Realizado", DateTime.Now);
                        ParametrosEnt[13] = new SqlParameter("@Maquina", Environment.MachineName);

                        GuardarDatos Guardar = new GuardarDatos();
                        Guardar.booleano("GRBBascula_MotosTecnoMecanica", ParametrosEnt);
                        if (Insertar)
                            MessageBox.Show("Tecnicomecanica Insertada satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Tecnicomecanica Actualizada satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        #region Actualizando el DatGridView
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[4];
                            ParametrosGrid[0] = new SqlParameter("@Op", "MotosTecno");
                            ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                            ParametrosGrid[2] = new SqlParameter("@ParametroInt", "");
                            ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                            this.dataGridViewTecno.DataSource = DS;
                            this.dataGridViewTecno.DataMember = "Result";
                            this.dataGridViewTecno.AutoResizeColumns();
                        }
                        catch (Exception Exc)
                        {
                            MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion
                    }
                }


                catch (Exception Exc)
                {
                    MessageBox.Show("OCURRIÓ UN ERROR AL ADJUNTAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewSeguros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.TxbSegurosProveedor.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[1].Value);
            this.TxbSegurosIdTomador.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[2].Value);
            this.TxbSegurosNombreTomador.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[3].Value);
            this.TxbSegurosTelefono.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[7].Value);
            this.TxbSegurosCodSucursalExpedida.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[8].Value);
            this.TxbSegurosClaveProductor.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[9].Value);
            this.TxbSegurosCiudadExpedicion.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[10].Value);
            this.TxbSegurosDireccionTomador.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[11].Value);
            this.TxbSegurosCiudadResidencia.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[12].Value);
            this.TxbSegurosPoliza.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[13].Value);
            this.TxbSegurosReemplazaPoliza.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[14].Value);
            this.TxbSegurosClaseVehiculo.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[15].Value);
            this.TxbSegurosPasajeros.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[16].Value);
            this.TxbSegurosTarifa.Text = Convert.ToString(this.dataGridViewSeguros.CurrentRow.Cells[17].Value);
            this.DtpSegurosFechaExpedicion.Value = Convert.ToDateTime(this.dataGridViewSeguros.CurrentRow.Cells[4].Value);
            this.DtpSegurosFechaInicio.Value = Convert.ToDateTime(this.dataGridViewSeguros.CurrentRow.Cells[5].Value);
            this.DtpSegurosFechaFinal.Value = Convert.ToDateTime(this.dataGridViewSeguros.CurrentRow.Cells[6].Value);
        }

        private void dataGridViewTecno_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.TxbTecnoMecanicaNroControl.Text = Convert.ToString(this.dataGridViewTecno.CurrentRow.Cells[0].Value);
            this.TxbTecnoMecanicaIdPropietario.Text = Convert.ToString(this.dataGridViewTecno.CurrentRow.Cells[5].Value);
            this.TxbTecnoMecanicaNombrePropietario.Text = Convert.ToString(this.dataGridViewTecno.CurrentRow.Cells[6].Value);
            this.TxbTecnoMecanicaNit.Text = Convert.ToString(this.dataGridViewTecno.CurrentRow.Cells[7].Value);
            this.TxbTecnoMecanicaCentroDiagnostico.Text = Convert.ToString(this.dataGridViewTecno.CurrentRow.Cells[8].Value);
            this.TxbTecnoMecanicaNroConsecutivoRunt.Text = Convert.ToString(this.dataGridViewTecno.CurrentRow.Cells[9].Value);
            this.TxbTecnoMecanicaNroCertificadoAcreditacion.Text = Convert.ToString(this.dataGridViewTecno.CurrentRow.Cells[10].Value);
            this.DtpTecnoMecanicaFechaExpedicion.Value = Convert.ToDateTime(this.dataGridViewTecno.CurrentRow.Cells[3].Value);
            this.DtpTecnoMecanicaFechaFinal.Value = Convert.ToDateTime(this.dataGridViewTecno.CurrentRow.Cells[4].Value);
        }

        private void Btn_GuardarAd_Click(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "MotosEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            GuardarDatos GuardarDatos = new GuardarDatos();
            Ent_Motos Reader = new Ent_Motos();

            Reader = Maestro.Moto("SpConsulta_Tablas", Parametros_Consulta);

            #region Insertando Datos Adjuntos
            if (this.TxbAdjuntosPath.Text.Length > 0)
            {
                try
                {
                    FileStream fs = new FileStream(this.TxbAdjuntosPath.Text, FileMode.Open);
                    //Creamos un array de bytes para almacenar los datos leídos por fs.
                    Byte[] data = new byte[fs.Length];
                    //Y guardamos los datos en el array data
                    fs.Read(data, 0, Convert.ToInt32(fs.Length));
                    fs.Close();

                    int PosInicialPath = this.TxbAdjuntosPath.Text.Trim().LastIndexOf("\\") + 1;
                    int PosFinalPath = this.TxbAdjuntosPath.Text.Trim().LastIndexOf(".") - 1;
                    int PosInicialExtension = this.TxbAdjuntosPath.Text.Trim().LastIndexOf(".");
                    int NumeroCaracteres = PosFinalPath - PosInicialPath + 1;
                    int CaracteresExtension = this.TxbAdjuntosPath.Text.Trim().Length - PosInicialExtension;

                    SqlParameter[] ParametrosEnt = new SqlParameter[11];
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                    ParametrosEnt[1] = new SqlParameter("@Id", "0");
                    ParametrosEnt[2] = new SqlParameter("@IdVehiculo", Reader.Id);
                    ParametrosEnt[3] = new SqlParameter("@Tipo", "1");
                    ParametrosEnt[4] = new SqlParameter("@Nombre", this.TxbAdjuntosPath.Text.Substring(PosInicialPath, NumeroCaracteres));
                    ParametrosEnt[5] = new SqlParameter("@Archivo", data);
                    ParametrosEnt[6] = new SqlParameter("@Extension", this.TxbAdjuntosPath.Text.Substring(PosInicialExtension, CaracteresExtension));
                    ParametrosEnt[7] = new SqlParameter("@Detalle", this.TxbAdjuntosPath.Text.Trim());
                    ParametrosEnt[8] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[9] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[10] = new SqlParameter("@Usuario", this.IdUsuario);

                    GuardarDatos Guardar = new GuardarDatos();
                    bool Realizado = Guardar.booleano("Sp_Guardar_DatosAdjuntosMotos", ParametrosEnt);
                    if (Realizado)
                        MessageBox.Show("Archivo Adjuntado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                catch (Exception Exc)
                {
                    MessageBox.Show("OCURRIÓ UN ERROR AL ADJUNTAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region Llenado el DataGrid de los adjuntos
            try
            {
                SqlParameter[] ParametrosGrid = new SqlParameter[4];
                ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosMotos");
                ParametrosGrid[1] = new SqlParameter("@ParametroChar", "");
                ParametrosGrid[2] = new SqlParameter("@ParametroInt", Reader.Id);
                ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                DataSet DS;

                DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                this.DtgAdjunto.DataSource = DS;
                this.DtgAdjunto.DataMember = "Result";
                this.DtgAdjunto.AutoResizeColumns();
            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void button14_Click(object sender, EventArgs e)
        {

            OpenFileDialog getArchivoAdjunto = new OpenFileDialog();
            getArchivoAdjunto.InitialDirectory = "C:\\";
            getArchivoAdjunto.RestoreDirectory = true;
            //getArchivoAdjunto.Filter = "Archivos adjuntos Excel(*.exe)| *.xls;| PDF(.pdf)|*.pdf;| Texto(*text)| *.txt;| Imagenes(*.jpg) (*.jpeg)| *.jpg; *.jpeg| PNG(*.png)| *.png| GIF(*.gif)| *.gif;| Todos*(*.exe)(*.pdf)(*.text)(*.jpg)(*.png)(*.gif)|*.xls;*.pdf;*.txt;*.jpg;*.png;*.gif";

            if (getArchivoAdjunto.ShowDialog() == DialogResult.OK)
            {
                TxbAdjuntosPath.Text = getArchivoAdjunto.FileName;
            }

            else
            {
                MessageBox.Show("No has seleccionado ningun archivo", "Seleccione una archivo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void DtgAdjunto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Muestra o ejecuta los Datos adjuntos
            int IdFile = Convert.ToInt32(this.DtgAdjunto.CurrentRow.Cells[0].Value);
            try
            {
                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "AdjuntosByteMotos");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", "");
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", IdFile);
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                GuardarDatos GuardarDatos = new GuardarDatos();
                Ent_DatosAdjuntos ReaderConsulta = new Ent_DatosAdjuntos();

                ReaderConsulta = Maestro.Adjunto("SpConsulta_Tablas", Parametros_Consulta);

                string fichero = Convert.ToString(Path.GetTempPath()) + "Temp_" + ReaderConsulta.Archivo + ReaderConsulta.Extension;

                using (FileStream archivoStream = new FileStream(fichero, FileMode.Create))
                {
                    archivoStream.Write(ReaderConsulta.Archivo, 0, ReaderConsulta.Archivo.Length);
                    archivoStream.Close();
                    if (File.Exists(fichero))
                    {
                        Process process = new Process { StartInfo = { FileName = fichero } };
                        process.Start();
                    }
                }
            }
            catch (Exception aa)
            {
                MessageBox.Show(aa.Message); ;
            }
            #endregion
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.TxbPlacaMoto.Text = "";
            this.ChbEstado.Checked = true;
            this.tabControl3.SelectedIndex = 0;

            #region Limpiando la pestaña de licencia

            #region Frontal
            this.TxbLicenciaFLicencia.Text = "";
            this.TxbLicenciaFCodPropietrio.Text = "";
            this.TxbLicenciaFNombPropietario.Text = "";
            this.TxbLicenciaFModelo.Text = "";
            this.TxbLicenciaFMarca.Text = "";
            this.TxbLicenciaFLinea.Text = "";
            this.TxbLicenciaFServicio.Text = "";
            this.TxbLicenciaFCilindraje.Text = "0";
            this.TxbLicenciaFColor.Text = "";
            this.TxbLicenciaFCombustible.Text = "";
            this.TxbLicenciaFClase.Text = "";
            this.TxbLicenciaFCarroceria.Text = "";
            this.TxbLicenciaFCapacidad.Text = "";
            this.TxbLicenciaFMotor.Text = "";
            this.TxbLicenciaFReg1.Text = "";
            this.TxbLicenciaFVin.Text = "";
            this.TxbLicenciaFSerie.Text = "";
            this.TxbLicenciaFReg2.Text = "";
            this.TxbLicenciaFChasis.Text = "";
            this.TxbLicenciaFReg3.Text = "";
            this.CmbLicenciaFTipoVehiculo.SelectedIndex = -1;
            this.RtbLicenciaFDescripcion.Text = "";
            this.ptbVehiculo.Image = DBMETAL_SHARP.Properties.Resources.vfr_1200_xd_cc_menu_honda;
            this.ChbEstado.Checked = false;
            this.ChbEstado.Text = "Estado";
            #endregion

            #region Respaldo
            this.TxbLicenciaRRestriccionMovilidad.Text = "";
            this.TxbLicenciaRBlindaje.Text = "";
            this.TxbLicenciaRPotencia.Text = "";
            this.TxbLicenciaRDeclaracionImportacion.Text = "";
            this.TxbLicenciaRIE.Text = "";
            this.DtpLicenciaRFechaImportacion.Text = "";
            this.TxbLicenciaRPuertas.Text = "";
            this.TxbLicenciaRLimitacionPropiedad.Text = "";
            this.DtpLicenciaRFechaMatricula.Text = "";
            this.DtpLicenciaRFechaExpLicencia.Text = "";
            this.DtpLicenciaRFechaVencimiento.Text = "";
            this.TxbLicenciaROrganismoTransito.Text = "";
            #endregion

            this.TxbPlacaMoto.Focus();

            #endregion

            #region Limpiando Seguros
            this.TxbSegurosProveedor.Text = "";
            this.DtpSegurosFechaExpedicion.Text = "";
            this.DtpSegurosFechaInicio.Text = "";
            this.DtpSegurosFechaFinal.Text = "";
            this.TxbSegurosIdTomador.Text = "";
            this.TxbSegurosNombreTomador.Text = "";
            this.TxbSegurosTelefono.Text = "";
            this.TxbSegurosCodSucursalExpedida.Text = "";
            this.TxbSegurosClaveProductor.Text = "";
            this.TxbSegurosCiudadExpedicion.Text = "";
            this.TxbSegurosDireccionTomador.Text = "";
            this.TxbSegurosCiudadResidencia.Text = "";
            this.TxbSegurosReemplazaPoliza.Text = "";
            this.TxbSegurosPoliza.Text = "";
            this.TxbSegurosClaseVehiculo.Text = "";
            this.TxbSegurosPasajeros.Text = "";
            this.TxbSegurosTarifa.Text = "";
            this.dataGridViewSeguros.DataSource = null;
            #endregion

            #region Limpiando TecnoMecanica
            this.TxbTecnoMecanicaNroControl.Text = "";
            this.DtpTecnoMecanicaFechaExpedicion.Text = "";
            this.DtpTecnoMecanicaFechaFinal.Text = "";
            this.TxbTecnoMecanicaIdPropietario.Text = "";
            this.TxbTecnoMecanicaNombrePropietario.Text = "";
            this.TxbTecnoMecanicaNit.Text = "";
            this.TxbTecnoMecanicaCentroDiagnostico.Text = "";
            this.TxbTecnoMecanicaNroConsecutivoRunt.Text = "";
            this.TxbTecnoMecanicaNroCertificadoAcreditacion.Text = "";
            this.dataGridViewTecno.DataSource = null;
            #endregion

            #region Limpiando Adjuntos
            this.TxbAdjuntosPath.Text = "";
            this.TxbAdjuntosDetalle.Text = "";
            this.DtgAdjunto.DataSource = null;
            #endregion
        }

        private void Btn_NuevoSeg_Click(object sender, EventArgs e)
        {
            this.TxbSegurosProveedor.Text = "";
            this.TxbSegurosIdTomador.Text = "";
            this.TxbSegurosNombreTomador.Text = "";
            this.TxbSegurosCodSucursalExpedida.Text = "";
            this.TxbSegurosClaveProductor.Text = "";
            this.TxbSegurosDireccionTomador.Text = "";
            this.TxbSegurosPoliza.Text = "";
            this.TxbSegurosReemplazaPoliza.Text = "";
            this.TxbSegurosClaseVehiculo.Text = "";
            this.TxbSegurosTelefono.Text = "";
            this.TxbSegurosCiudadExpedicion.Text = "";
            this.TxbSegurosCiudadResidencia.Text = "";
            this.TxbSegurosPasajeros.Text = "";
            this.TxbSegurosTarifa.Text = "";
            this.DtpSegurosFechaExpedicion.Text = "";
            this.DtpSegurosFechaInicio.Text = "";
            this.DtpSegurosFechaFinal.Text = "";
        }

        private void Btn_NuevoTecno_Click(object sender, EventArgs e)
        {
            this.TxbTecnoMecanicaNroControl.Text = "";
            this.TxbTecnoMecanicaIdPropietario.Text = "";
            this.TxbTecnoMecanicaNombrePropietario.Text = "";
            this.TxbTecnoMecanicaNit.Text = "";
            this.TxbTecnoMecanicaCentroDiagnostico.Text = "";
            this.TxbTecnoMecanicaNroConsecutivoRunt.Text = "";
            this.TxbTecnoMecanicaNroCertificadoAcreditacion.Text = "";
            this.DtpTecnoMecanicaFechaExpedicion.Text = "";
            this.DtpTecnoMecanicaFechaFinal.Text = "";
        }

        private void Btn_NuevoAd_Click(object sender, EventArgs e)
        {
            this.TxbAdjuntosDetalle.Text = "";
            this.TxbAdjuntosPath.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region Eliminando Datos tabla Motos

            if (this.TxbPlacaMoto.Text.Length > 0)
            {
                DialogResult Opcion = MessageBox.Show("Desea Eliminar el registro de Vehiculos", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
                if (Opcion == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] ParametrosEnt_Vehiculos = new SqlParameter[40];

                        ParametrosEnt_Vehiculos[0] = new SqlParameter("@Op", "D");
                        ParametrosEnt_Vehiculos[1] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                        ParametrosEnt_Vehiculos[2] = new SqlParameter("@Placa", this.TxbPlacaMoto.Text.Trim());
                        ParametrosEnt_Vehiculos[3] = new SqlParameter("@Descripcion", this.RtbLicenciaFDescripcion.Text.Trim());
                        ParametrosEnt_Vehiculos[4] = new SqlParameter("@Licencia", this.TxbLicenciaFLicencia.Text.Trim());
                        ParametrosEnt_Vehiculos[5] = new SqlParameter("@Propietario", this.TxbLicenciaFCodPropietrio.Text.Trim());
                        ParametrosEnt_Vehiculos[6] = new SqlParameter("@Modelo", this.TxbLicenciaFModelo.Text.Trim());
                        ParametrosEnt_Vehiculos[7] = new SqlParameter("@Marca", this.TxbLicenciaFMarca.Text.Trim());
                        ParametrosEnt_Vehiculos[8] = new SqlParameter("@Linea", this.TxbLicenciaFLinea.Text.Trim());
                        ParametrosEnt_Vehiculos[9] = new SqlParameter("@Servicio", this.TxbLicenciaFServicio.Text.Trim());
                        ParametrosEnt_Vehiculos[10] = new SqlParameter("@Cilindraje", this.TxbLicenciaFCilindraje.Text.Trim());
                        ParametrosEnt_Vehiculos[11] = new SqlParameter("@Color", this.TxbLicenciaFColor.Text.Trim());
                        ParametrosEnt_Vehiculos[12] = new SqlParameter("@Combustible", this.TxbLicenciaFCombustible.Text.Trim());
                        ParametrosEnt_Vehiculos[13] = new SqlParameter("@Clase", this.TxbLicenciaFClase.Text.Trim());
                        ParametrosEnt_Vehiculos[14] = new SqlParameter("@Carroceria", this.TxbLicenciaFCarroceria.Text.Trim());
                        ParametrosEnt_Vehiculos[15] = new SqlParameter("@Capacidad", this.TxbLicenciaFCapacidad.Text.Trim());
                        ParametrosEnt_Vehiculos[16] = new SqlParameter("@Motor", this.TxbLicenciaFMotor.Text.Trim());
                        ParametrosEnt_Vehiculos[17] = new SqlParameter("@Reg1", this.TxbLicenciaFReg3.Text.Trim());
                        ParametrosEnt_Vehiculos[18] = new SqlParameter("@Vin", this.TxbLicenciaFVin.Text.Trim());
                        ParametrosEnt_Vehiculos[19] = new SqlParameter("@Serie", this.TxbLicenciaFSerie.Text.Trim());
                        ParametrosEnt_Vehiculos[20] = new SqlParameter("@Reg2", this.TxbLicenciaFReg1.Text.Trim());
                        ParametrosEnt_Vehiculos[21] = new SqlParameter("@Chasis", this.TxbLicenciaFChasis.Text.Trim());
                        ParametrosEnt_Vehiculos[22] = new SqlParameter("@Reg3", this.TxbLicenciaFReg2.Text.Trim());
                        ParametrosEnt_Vehiculos[23] = new SqlParameter("@TipoVehiculo", this.CmbLicenciaFTipoVehiculo.SelectedIndex);
                        ParametrosEnt_Vehiculos[24] = new SqlParameter("@RestriccionMovilidad", this.TxbLicenciaRRestriccionMovilidad.Text.Trim());
                        ParametrosEnt_Vehiculos[25] = new SqlParameter("@Blindaje", this.TxbLicenciaRBlindaje.Text.Trim());
                        ParametrosEnt_Vehiculos[26] = new SqlParameter("@Potencia", this.TxbLicenciaRPotencia.Text.Trim());
                        ParametrosEnt_Vehiculos[27] = new SqlParameter("@DeclaracionImportacion", this.TxbLicenciaRDeclaracionImportacion.Text.Trim());
                        ParametrosEnt_Vehiculos[28] = new SqlParameter("@IE", this.TxbLicenciaRIE.Text.Trim());
                        ParametrosEnt_Vehiculos[29] = new SqlParameter("@FechaImportacion", this.DtpLicenciaRFechaImportacion.Text.Trim().Replace("/", ""));
                        ParametrosEnt_Vehiculos[30] = new SqlParameter("@Puertas", this.TxbLicenciaRPuertas.Text.Trim());
                        ParametrosEnt_Vehiculos[31] = new SqlParameter("@LimitacionPropiedad", this.TxbLicenciaRLimitacionPropiedad.Text.Trim());
                        ParametrosEnt_Vehiculos[32] = new SqlParameter("@FechaMatricula", this.DtpLicenciaRFechaMatricula.Text.Trim().Replace("/", ""));
                        ParametrosEnt_Vehiculos[33] = new SqlParameter("@FechaExpLicTTO", this.DtpLicenciaRFechaExpLicencia.Text.Trim().Replace("/", ""));
                        ParametrosEnt_Vehiculos[34] = new SqlParameter("@FechaVencimiento", this.DtpLicenciaRFechaVencimiento.Text.Trim().Replace("/", ""));
                        ParametrosEnt_Vehiculos[35] = new SqlParameter("@OrganismoTransito", this.TxbLicenciaROrganismoTransito.Text.Trim());
                        ParametrosEnt_Vehiculos[36] = new SqlParameter("@Foto", ImageConvert.imageToByte(this.ptbVehiculo.Image));
                        ParametrosEnt_Vehiculos[37] = new SqlParameter("@Realizado", DateTime.Now);
                        ParametrosEnt_Vehiculos[38] = new SqlParameter("@Maquina", Environment.MachineName);
                        ParametrosEnt_Vehiculos[39] = new SqlParameter("@Usuario", this.IdUsuario);

                        GuardarDatos GuardarDatos = new GuardarDatos();
                        GuardarDatos.booleano("GRBMotos", ParametrosEnt_Vehiculos);

                        MessageBox.Show("Moto Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }

        private void Btn_BorrarSeg_Click(object sender, EventArgs e)
        {
            #region Eliminando Datos tabla Seguros
            DialogResult Opcion = MessageBox.Show("Desea Eliminar el registro de la Moto", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                if (this.TxbPlacaMoto.Text.Trim().Length > 0)
                {
                    try
                    {
                        SqlParameter[] ParametrosEnt = new SqlParameter[22];
                        #region Determinando si Existe el vehiculo que se va a Eliminar el seguro
                        SqlParameter[] ParamTipo = new SqlParameter[4];
                        ParamTipo[0] = new SqlParameter("@Op", "ExisteIdPlacaMoto");
                        ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                        ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                        ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                        if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                            MessageBox.Show("Moto no Existe");
                        else
                        {
                            ParametrosEnt[0] = new SqlParameter("@Op", "D");
                            ParametrosEnt[1] = new SqlParameter("@IdPlaca", Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]));
                            ParametrosEnt[2] = new SqlParameter("@Proveedor", this.TxbSegurosProveedor.Text.Trim());
                            ParametrosEnt[3] = new SqlParameter("@IdTomador", this.TxbSegurosIdTomador.Text.Trim());
                            ParametrosEnt[4] = new SqlParameter("@NombreTomador", this.TxbSegurosNombreTomador.Text.Trim());
                            ParametrosEnt[5] = new SqlParameter("@FechaExpedicion", this.DtpSegurosFechaExpedicion.Text.Trim().Replace("/", ""));
                            ParametrosEnt[6] = new SqlParameter("@FechaInicial", this.DtpSegurosFechaInicio.Text.Trim().Replace("/", ""));
                            ParametrosEnt[7] = new SqlParameter("@FechaFinal", this.DtpSegurosFechaFinal.Text.Trim().Replace("/", ""));
                            ParametrosEnt[8] = new SqlParameter("@Telefono", this.TxbSegurosTelefono.Text.Trim());
                            ParametrosEnt[9] = new SqlParameter("@CodigoSucursal", this.TxbSegurosCodSucursalExpedida.Text.Trim());
                            ParametrosEnt[10] = new SqlParameter("@ClaveProductor", this.TxbSegurosClaveProductor.Text.Trim());
                            ParametrosEnt[11] = new SqlParameter("@CiudadExpedicion", this.TxbSegurosCiudadExpedicion.Text.Trim());
                            ParametrosEnt[12] = new SqlParameter("@Direccion", this.TxbSegurosDireccionTomador.Text.Trim());
                            ParametrosEnt[13] = new SqlParameter("@CiudadResidencia", this.TxbSegurosCiudadResidencia.Text.Trim());
                            ParametrosEnt[14] = new SqlParameter("@Poliza", this.TxbSegurosPoliza.Text.Trim());
                            ParametrosEnt[15] = new SqlParameter("@Reemplaza", this.TxbSegurosReemplazaPoliza.Text.Trim());
                            ParametrosEnt[16] = new SqlParameter("@ClaseVehiculo", this.TxbSegurosClaseVehiculo.Text.Trim());
                            ParametrosEnt[17] = new SqlParameter("@Pasajeros", this.TxbSegurosPasajeros.Text.Trim());
                            ParametrosEnt[18] = new SqlParameter("@Tarifa", this.TxbSegurosTarifa.Text.Trim());
                            ParametrosEnt[19] = new SqlParameter("@Usuario", this.IdUsuario);
                            ParametrosEnt[20] = new SqlParameter("@Realizado", DateTime.Now);
                            ParametrosEnt[21] = new SqlParameter("@Maquina", Environment.MachineName);
                        }
                        #endregion

                        GuardarDatos Guardar = new GuardarDatos();
                        Guardar.booleano("GRBBascula_MotosSeguros", ParametrosEnt);
                        MessageBox.Show("Seguro Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        #region Actualizando el DatGridView Seguros
                        try
                        {
                            SqlParameter[] ParametrosGrid = new SqlParameter[4];
                            ParametrosGrid[0] = new SqlParameter("@Op", "MotosSeg");
                            ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                            ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                            ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                            DataSet DS;

                            DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                            this.dataGridViewSeguros.DataSource = DS;
                            this.dataGridViewSeguros.DataMember = "Result";
                            this.dataGridViewSeguros.AutoResizeColumns();
                        }
                        catch (Exception Exc)
                        {
                            MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL ADJUNTAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }

        private void Btn_BorrarTecno_Click(object sender, EventArgs e)
        {
            #region Eliminando Datos tabla Tecnomecanica

            if (this.TxbPlacaMoto.Text.Length > 0)
            {
                DialogResult Opcion = MessageBox.Show("Desea Eliminar el registro ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
                if (Opcion == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] ParametrosEnt = new SqlParameter[14];

                        #region Determinando si Existe el vehiculo al se le va insertar/actualizar la TenoMecanica
                        SqlParameter[] ParamTipo = new SqlParameter[4];
                        ParamTipo[0] = new SqlParameter("@Op", "ExisteIdPlacaMoto");
                        ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                        ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                        ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                        #endregion
                        if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                            MessageBox.Show("Moto no Existe");
                        else
                        {
                            ParametrosEnt[0] = new SqlParameter("@Op", "D");
                            ParametrosEnt[1] = new SqlParameter("@IdPlaca", Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]));
                            ParametrosEnt[2] = new SqlParameter("@NroControl", this.TxbTecnoMecanicaNroControl.Text.Trim());
                            ParametrosEnt[3] = new SqlParameter("@FechaExpedicion", this.DtpTecnoMecanicaFechaExpedicion.Text.Trim().Replace("/", ""));
                            ParametrosEnt[4] = new SqlParameter("@FechaVencimiento", this.DtpTecnoMecanicaFechaFinal.Text.Trim().Replace("/", ""));
                            ParametrosEnt[5] = new SqlParameter("@IdPropietario", this.TxbTecnoMecanicaIdPropietario.Text.Trim());
                            ParametrosEnt[6] = new SqlParameter("@NombrePropietario", this.TxbTecnoMecanicaNombrePropietario.Text.Trim());
                            ParametrosEnt[7] = new SqlParameter("@NitAutomotor", this.TxbTecnoMecanicaNit.Text.Trim());
                            ParametrosEnt[8] = new SqlParameter("@NombreAutomotor", this.TxbTecnoMecanicaCentroDiagnostico.Text.Trim());
                            ParametrosEnt[9] = new SqlParameter("@ConsecutivoRunt", this.TxbTecnoMecanicaNroConsecutivoRunt.Text.Trim());
                            ParametrosEnt[10] = new SqlParameter("@CertificadoAcreditacion", this.TxbTecnoMecanicaNroCertificadoAcreditacion.Text.Trim());
                            ParametrosEnt[11] = new SqlParameter("@Usuario", this.IdUsuario);
                            ParametrosEnt[12] = new SqlParameter("@Realizado", DateTime.Now);
                            ParametrosEnt[13] = new SqlParameter("@Maquina", Environment.MachineName);

                            GuardarDatos Guardar = new GuardarDatos();
                            Guardar.booleano("GRBBascula_MotosTecnoMecanica", ParametrosEnt);
                            MessageBox.Show("Tecnicomecanica Eliminada satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            #region Actualizando el DatGridView
                            try
                            {
                                SqlParameter[] ParametrosGrid = new SqlParameter[4];
                                ParametrosGrid[0] = new SqlParameter("@Op", "MotosTecno");
                                ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                                ParametrosGrid[2] = new SqlParameter("@ParametroInt", "");
                                ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                                DataSet DS;

                                DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                                this.dataGridViewTecno.DataSource = DS;
                                this.dataGridViewTecno.DataMember = "Result";
                                this.dataGridViewTecno.AutoResizeColumns();
                            }
                            catch (Exception Exc)
                            {
                                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion
                        }
                    }


                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL ADJUNTAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }

        private void Btn_BorrarAd_Click(object sender, EventArgs e)
        {
            #region Eliminando los datos Adjuntos
            DialogResult Opcion = MessageBox.Show("Desea Eliminar el archivo adjunto Seleccionado oprima el botón SI", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    #region Determinando si se hace insert o update
                    SqlParameter[] ParamTipo = new SqlParameter[4];
                    ParamTipo[0] = new SqlParameter("@Op", "ExisteIdPlaca");
                    ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbPlacaMoto.Text.Trim());
                    ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                    ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                    int IdVehiculo = Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]);
                    #endregion

                    GuardarDatos GuardarDatos = new GuardarDatos();

                    int IdFile = Convert.ToInt32(this.DtgAdjunto.CurrentRow.Cells[0].Value);

                    SqlParameter[] ParametrosEnt = new SqlParameter[11];
                    ParametrosEnt[0] = new SqlParameter("@Op", "D");
                    ParametrosEnt[1] = new SqlParameter("@Id", IdFile);
                    ParametrosEnt[2] = new SqlParameter("@Tipo", "1");
                    ParametrosEnt[3] = new SqlParameter("@IdVehiculo", IdVehiculo);
                    ParametrosEnt[4] = new SqlParameter("@Nombre", "");
                    ParametrosEnt[5] = new SqlParameter("@Archivo", Encoding.ASCII.GetBytes(""));
                    ParametrosEnt[6] = new SqlParameter("@Extension", "");
                    ParametrosEnt[7] = new SqlParameter("@Detalle", "");
                    ParametrosEnt[8] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[9] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[10] = new SqlParameter("@Usuario", this.IdUsuario);

                    GuardarDatos Guardar = new GuardarDatos();
                    bool Realizado = Guardar.booleano("Sp_Guardar_DatosAdjuntosMotos", ParametrosEnt);
                    if (Realizado)
                        MessageBox.Show("Archivo Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region Llenado el DataGrid de los adjuntos
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosMotos");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", "");
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", IdVehiculo);
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DtgAdjunto.DataSource = DS;
                        this.DtgAdjunto.DataMember = "Result";
                        this.DtgAdjunto.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                }
                catch (Exception Exc1)
                {
                    MessageBox.Show(Exc1.Message); ;
                }
            }

            #endregion
        }

        private void ChbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbEstado.Checked)
                this.ChbEstado.Text = "Activo";
            else
                this.ChbEstado.Text = "Bloqueado";
        }

        private void Frm_Motos_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
        }
    }
}

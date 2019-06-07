using Entidades;
using ReglasdeNegocio;
using Reportes;
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
    public partial class Frm_Conductores : Form
    {
        public Frm_Conductores(string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        public string Login { get; set; }
        public int Op = 0;
        public int IdUsuario = 0;
        DataTable Dt = new DataTable();


        public void EjecutaPasarDato(string Dato)
        {
            switch (Op)
            {
                case 1:
                    this.TxbIdentificacion.Text = Dato;
                    TxbIdentificacion_Leave(null, null);
                    break;
                case 2:
                    this.TxbIdContratista.Text = Dato;
                    TxbIdContratista_Leave(null, null);
                    break;
                case 3:
                    this.TxbPlaca.Text = Dato;
                    TxbPlaca_Leave(null, null);
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



        private void Frm_Conductores_Load(object sender, EventArgs e)
        {
            this.btnNew.PerformClick();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.TxbIdentificacion.Text.Trim().Length > 0)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[17];

                    #region Determinando si se hace insert o update
                    SqlParameter[] ParamTipo = new SqlParameter[4];
                    ParamTipo[0] = new SqlParameter("@Op", "ExisteConductor");
                    ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                    ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                    ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);

                    if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                        ParametrosEnt[0] = new SqlParameter("@Op", "I");
                    else
                        ParametrosEnt[0] = new SqlParameter("@Op", "U");
                    #endregion

                    ParametrosEnt[1] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                    ParametrosEnt[2] = new SqlParameter("@Codigo", this.TxbIdentificacion.Text.Trim());
                    ParametrosEnt[3] = new SqlParameter("@Nombre", this.TxbNombre.Text.Trim());
                    ParametrosEnt[4] = new SqlParameter("@Apellido", this.TxbApellido.Text.Trim());
                    ParametrosEnt[5] = new SqlParameter("@Direccion", this.TxbDireccion.Text.Trim());
                    ParametrosEnt[6] = new SqlParameter("@TelFijo", this.TxbTelFijo.Text.Trim());
                    ParametrosEnt[7] = new SqlParameter("@Email", this.TxbEmail.Text.Trim());
                    ParametrosEnt[8] = new SqlParameter("@Telefono", this.TxbCelular.Text.Trim());
                    ParametrosEnt[9] = new SqlParameter("@Nacimiento", this.DtpNacimiento.Text.Trim());
                    ParametrosEnt[10] = new SqlParameter("@RH", this.CmbRH.SelectedIndex);
                    ParametrosEnt[11] = new SqlParameter("@Contratista", this.TxbIdContratista.Text.Trim());
                    ParametrosEnt[12] = new SqlParameter("@IdVehiculo", "380");
                    ParametrosEnt[13] = new SqlParameter("@Foto", ImageConvert.imageToByte(this.PtbConductor.Image));
                    ParametrosEnt[14] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[15] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[16] = new SqlParameter("@Usuario", this.IdUsuario);

                    GuardarDatos GuardarDatos = new GuardarDatos();
                    GuardarDatos.booleano("GRBConductores", ParametrosEnt);

                    if (Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]) == 0)
                        MessageBox.Show("Datos del Conductor Insertados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Datos del Conductor actualizado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.TxbIdentificacion.Text = "";
            this.TxbIdContratista.Text = "";
            this.TxbNombreContratista.Text = "";
            this.TxbNombre.Text = "";
            this.TxbApellido.Text = "";
            this.TxbDireccion.Text = "";
            this.TxbTelFijo.Text = "";
            this.TxbEmail.Text = "";
            this.TxbCelular.Text = "";
            this.DtpNacimiento.Text = "";
            this.CmbRH.SelectedIndex = -1;
            this.PtbConductor.Image = DBMETAL_SHARP.Properties.Resources.Conductor_2;
            this.ChbEstado.Checked = false;
            this.ChbEstado.Text = "Estado";
            this.button6.PerformClick();
            this.Btn_NuevoAd.PerformClick();
            this.DtgLicenciaConductor.DataSource = null;
            this.tabControl1.SelectedIndex = 0;
            this.TxbIdentificacion.Focus();
            this.BtnNuevoSegVial.PerformClick();
            this.DtgSeguridadVial.DataSource = null;
            this.BtnNuevoSegVial.PerformClick();

            #region Limpando TAB de Vehiculos relacionados

            this.TxbPlaca.Text = "";
            this.TxbNombProyecto.Text = "";
            this.TxbLicenciaFTara.Text = "0";
            this.ptbVehiculo.Image = DBMETAL_SHARP.Properties.Resources.Volqueta;
            this.DgvVehiculos.Rows.Clear();
            Dt.Columns.Clear();
            Dt.Rows.Clear();
            Dt.Columns.Add("Placa");
            Dt.Columns.Add("Proyecto");
            #endregion

            #region Limpiando Adjuntos
            this.TxbAdjuntosDetalle.Text = "";
            this.TxbAdjuntosPath.Text = "";
            this.DtgAdjunto.DataSource = null;
            #endregion
        }

        private void TxbIdentificacion_Leave(object sender, EventArgs e)
        {
            if (this.TxbIdentificacion.Text.Trim().Length > 1)
            {
                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "ConductorEspe");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0.0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                Ent_Conductores Reader = new Ent_Conductores();

                Reader = Maestro.Conductores("SpConsulta_Tablas", Parametros_Consulta);
                if (Reader.Codigo != null)
                {
                    this.ChbEstado.Checked = Reader.Estado;
                    if (Reader.Estado)
                        this.ChbEstado.Text = "Activo";
                    else
                        this.ChbEstado.Text = "Bloqueado";
                    this.TxbIdentificacion.Text = Reader.Codigo.ToString();
                    this.TxbIdContratista.Text = Reader.IdentificacionContratista.ToString();
                    this.TxbNombreContratista.Text = Reader.NombreContratista.ToString() + " " + Reader.ApellidoContratista.ToString();
                    this.TxbNombre.Text = Reader.Nombre.ToString();
                    this.TxbApellido.Text = Reader.Apellido.ToString();
                    this.TxbDireccion.Text = Reader.Direccion.ToString();
                    this.TxbTelFijo.Text = Reader.TelFijo.ToString();
                    this.TxbEmail.Text = Reader.Email.ToString();
                    this.TxbCelular.Text = Reader.Telefono.ToString();
                    this.DtpNacimiento.Value = Reader.Nacimiento;
                    this.CmbRH.SelectedIndex = Reader.RH;
                    this.PtbConductor.Image = ImageConvert.byteToImage(Reader.Foto);

                    #region Actualizando el DatGridView Licencia Conductor
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "LicConductorEspe");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DtgLicenciaConductor.DataSource = DS;
                        this.DtgLicenciaConductor.DataMember = "Result";
                        this.DtgLicenciaConductor.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    #region Llenado el combo de las licencias validas en el tap de compromisos de seguridad
                    this.CmbCategoriaSeguridad.Items.Clear();
                    foreach (DataGridViewRow item in this.DtgLicenciaConductor.Rows)
                    {
                        string Categoria = "";
                        int Categoria1 = Convert.ToInt32(item.Cells[7].Value);
                        int Categoria2 = Convert.ToInt32(item.Cells[8].Value);
                        int Categoria3 = Convert.ToInt32(item.Cells[9].Value);

                        DateTime Vencimiento1 = Convert.ToDateTime(item.Cells[13].Value);
                        DateTime Vencimiento2 = Convert.ToDateTime(item.Cells[14].Value);
                        DateTime Vencimiento3 = Convert.ToDateTime(item.Cells[15].Value);

                        switch (Categoria1)
                        {
                            case 0:
                                Categoria = "A1";
                                break;
                            case 1:
                                Categoria = "A2";
                                break;
                            case 2:
                                Categoria = "B1";
                                break;
                            case 3:
                                Categoria = "B2";
                                break;
                            case 4:
                                Categoria = "B3";
                                break;
                            case 5:
                                Categoria = "C1";
                                break;
                            case 6:
                                Categoria = "C2";
                                break;
                            case 7:
                                Categoria = "C3";
                                break;
                        }
                        if (Vencimiento1 >= DateTime.Now)
                            this.CmbCategoriaSeguridad.Items.Add(Categoria);

                        switch (Categoria2)
                        {
                            case 0:
                                Categoria = "A1";
                                break;
                            case 1:
                                Categoria = "A2";
                                break;
                            case 2:
                                Categoria = "B1";
                                break;
                            case 3:
                                Categoria = "B2";
                                break;
                            case 4:
                                Categoria = "B3";
                                break;
                            case 5:
                                Categoria = "C1";
                                break;
                            case 6:
                                Categoria = "C2";
                                break;
                            case 7:
                                Categoria = "C3";
                                break;
                        }
                        if (Vencimiento2 >= DateTime.Now)
                            this.CmbCategoriaSeguridad.Items.Add(Categoria);

                        switch (Categoria3)
                        {
                            case 0:
                                Categoria = "A1";
                                break;
                            case 1:
                                Categoria = "A2";
                                break;
                            case 2:
                                Categoria = "B1";
                                break;
                            case 3:
                                Categoria = "B2";
                                break;
                            case 4:
                                Categoria = "B3";
                                break;
                            case 5:
                                Categoria = "C1";
                                break;
                            case 6:
                                Categoria = "C2";
                                break;
                            case 7:
                                Categoria = "C3";
                                break;
                        }
                        if (Vencimiento3 >= DateTime.Now)
                            this.CmbCategoriaSeguridad.Items.Add(Categoria);
                    }

                    #endregion

                    #region Actualizando el DatGridView Seguridad Vial
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "SeguVialEspe");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DtgSeguridadVial.DataSource = DS;
                        this.DtgSeguridadVial.DataMember = "Result";
                        this.DtgSeguridadVial.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    #region Actualizando el DatGridView Asignación de Vehiculos
                    try
                    {
                        this.DgvVehiculos.Rows.Clear();
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "AsigVehiculoEspe");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        //this.DgvVehiculos.DataSource = DS;
                        //this.DgvVehiculos.DataMember = "Result";
                        //this.DgvVehiculos.AutoResizeColumns();

                        foreach (DataRow dataRow in DS.Tables[0].Rows)
                        {
                            bool principal = Convert.ToBoolean(dataRow[0]);
                            string placa = dataRow[1].ToString();
                            string proyecto = dataRow[2].ToString();


                            this.DgvVehiculos.Rows.Insert(this.DgvVehiculos.RowCount, principal, placa, proyecto);

                        }
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
                        ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosConductores");
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
            }
        }

        private void TxbIdContratista_Leave(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "ContratistasEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbIdContratista.Text.Trim());
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Contratistas Reader = new Ent_Contratistas();

            Reader = Maestro.NombreContratistas("SpConsulta_Tablas", Parametros_Consulta);

            if (Reader.Identificacion != null)
            {
                this.TxbIdContratista.Text = Reader.Identificacion.ToString();
                this.TxbNombreContratista.Text = Reader.Nombre.ToString() + " " + Reader.Apellido.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op = 2;
            Frm_Consultas Forma = new Frm_Consultas(9);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op = 1;
            Frm_Consultas Forma = new Frm_Consultas(10);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {
            this.CmbCategoria1.SelectedIndex = -1;
            this.TxbCategoria1.Text = "";
        }

        private void BtnBuscarFoto_Click(object sender, EventArgs e)
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
                            this.PtbConductor.Image = Image.FromFile(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void ChbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbEstado.Checked)
                this.ChbEstado.Text = "Activo";
            else
                this.ChbEstado.Text = "Bloqueado";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "ConductorEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            GuardarDatos GuardarDatos = new GuardarDatos();
            Ent_Conductores Reader = new Ent_Conductores();

            Reader = Maestro.Conductores("SpConsulta_Tablas", Parametros_Consulta);

            #region Insertando Datos
            if (Reader.Codigo != null)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[18];
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                    ParametrosEnt[1] = new SqlParameter("@IdConductor", Reader.Id);
                    ParametrosEnt[2] = new SqlParameter("@FechaExpedicion", this.DtpFechaExpedicion.Text.Trim().Replace("/", ""));
                    ParametrosEnt[3] = new SqlParameter("@RestriccionesConductor", this.TxbRestricciones.Text.Trim());
                    ParametrosEnt[4] = new SqlParameter("@OrganismoTransito", this.TxbOrganismoTransito.Text.Trim());
                    ParametrosEnt[5] = new SqlParameter("@Categoria1", this.CmbCategoria1.SelectedIndex);
                    ParametrosEnt[6] = new SqlParameter("@Categoria2", this.CmbCategoria2.SelectedIndex);
                    ParametrosEnt[7] = new SqlParameter("@Categoria3", this.CmbCategoria3.SelectedIndex);
                    ParametrosEnt[8] = new SqlParameter("@DetalleCategoria1", this.TxbCategoria1.Text.Trim());
                    ParametrosEnt[9] = new SqlParameter("@DetalleCategoria2", this.TxbCategoria2.Text.Trim());
                    ParametrosEnt[10] = new SqlParameter("@DetalleCategoria3", this.TxbCategoria3.Text.Trim());
                    ParametrosEnt[11] = new SqlParameter("@Vigencia1", this.DtpVigencia1.Text.Trim().Replace("/", ""));
                    ParametrosEnt[12] = new SqlParameter("@Vigencia2", this.DtpVigencia2.Text.Trim().Replace("/", ""));
                    ParametrosEnt[13] = new SqlParameter("@Vigencia3", this.DtpVigencia3.Text.Trim().Replace("/", ""));
                    ParametrosEnt[14] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[15] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[16] = new SqlParameter("@Usuario", this.IdUsuario);
                    ParametrosEnt[17] = new SqlParameter("@NroLicencia", this.TxbNroLicencia.Text.Trim());
                    

                    GuardarDatos Guardar = new GuardarDatos();
                    Guardar.booleano("GRB_TiposLicenciaConductor", ParametrosEnt);

                    MessageBox.Show("Datos almacenados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    #region Actualizando el DatGridView Licencia Conductor
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "LicConductorEspe");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DtgLicenciaConductor.DataSource = DS;
                        this.DtgLicenciaConductor.DataMember = "Result";
                        this.DtgLicenciaConductor.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            #endregion
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.DtpFechaExpedicion.Text = "";
            this.TxbRestricciones.Text = "";
            this.TxbOrganismoTransito.Text = "";
            this.DtpVigencia1.Text = "";
            this.DtpVigencia2.Text = "";
            this.DtpVigencia3.Text = "";
            this.CmbCategoria1.SelectedIndex = -1;
            this.CmbCategoria2.SelectedIndex = -1;
            this.CmbCategoria3.SelectedIndex = -1;
            this.TxbCategoria1.Text = "";
            this.TxbCategoria2.Text = "";
            this.TxbCategoria3.Text = "";
        }

        private void CmbCategoria1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCategoria1.SelectedIndex == 0)
            {
                this.TxbCategoria1.Text = "Para motocicletas de cilindraje igual o menor a 125 c.c.";
            }
            else if (CmbCategoria1.SelectedIndex == 1)
            {
                this.TxbCategoria1.Text = "Para motocicletas, motociclos superiores a 125 c.c.";
            }
            else if (CmbCategoria1.SelectedIndex == 2)
            {
                this.TxbCategoria1.Text = "Automóviles, camionetas y microbuses de servicio particular. ";
            }
            else if (CmbCategoria1.SelectedIndex == 3)
            {
                this.TxbCategoria1.Text = "Camiones, buses y busetas.";
            }
            else if (CmbCategoria1.SelectedIndex == 4)
            {
                this.TxbCategoria1.Text = "Vehículos articulados o tractocamiones.";
            }
            else if (CmbCategoria1.SelectedIndex == 5)
            {
                this.TxbCategoria1.Text = "Automóviles, camionetas y microbuses de servicio público. ";
            }
            else if (CmbCategoria1.SelectedIndex == 6)
            {
                this.TxbCategoria1.Text = "Camiones rígidos, buses y busetas de servicio público.";
            }
            else if (CmbCategoria1.SelectedIndex == 7)
            {
                this.TxbCategoria1.Text = "Vehículos articulados de servicio público.";
            }
        }

        private void CmbCategoria2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCategoria2.SelectedIndex == 0)
            {
                this.TxbCategoria2.Text = "Para motocicletas de cilindraje igual o menor a 125 c.c.";
            }
            else if (CmbCategoria2.SelectedIndex == 1)
            {
                this.TxbCategoria2.Text = "Para motocicletas, motociclos superiores a 125 c.c.";
            }
            else if (CmbCategoria2.SelectedIndex == 2)
            {
                this.TxbCategoria2.Text = "Automóviles, camionetas y microbuses de servicio particular. ";
            }
            else if (CmbCategoria2.SelectedIndex == 3)
            {
                this.TxbCategoria2.Text = "Camiones, buses y busetas.";
            }
            else if (CmbCategoria2.SelectedIndex == 4)
            {
                this.TxbCategoria2.Text = "Vehículos articulados o tractocamiones.";
            }
            else if (CmbCategoria2.SelectedIndex == 5)
            {
                this.TxbCategoria2.Text = "Automóviles, camionetas y microbuses de servicio público. ";
            }
            else if (CmbCategoria2.SelectedIndex == 6)
            {
                this.TxbCategoria2.Text = "Camiones rígidos, buses y busetas de servicio público.";
            }
            else if (CmbCategoria2.SelectedIndex == 7)
            {
                this.TxbCategoria2.Text = "Vehículos articulados de servicio público.";
            }
        }

        private void CmbCategoria3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCategoria3.SelectedIndex == 0)
            {
                this.TxbCategoria3.Text = "Para motocicletas de cilindraje igual o menor a 125 c.c.";
            }
            else if (CmbCategoria3.SelectedIndex == 1)
            {
                this.TxbCategoria3.Text = "Para motocicletas, motociclos superiores a 125 c.c.";
            }
            else if (CmbCategoria3.SelectedIndex == 2)
            {
                this.TxbCategoria3.Text = "Automóviles, camionetas y microbuses de servicio particular. ";
            }
            else if (CmbCategoria3.SelectedIndex == 3)
            {
                this.TxbCategoria3.Text = "Camiones, buses y busetas.";
            }
            else if (CmbCategoria3.SelectedIndex == 4)
            {
                this.TxbCategoria3.Text = "Vehículos articulados o tractocamiones.";
            }
            else if (CmbCategoria3.SelectedIndex == 5)
            {
                this.TxbCategoria3.Text = "Automóviles, camionetas y microbuses de servicio público. ";
            }
            else if (CmbCategoria3.SelectedIndex == 6)
            {
                this.TxbCategoria3.Text = "Camiones rígidos, buses y busetas de servicio público.";
            }
            else if (CmbCategoria3.SelectedIndex == 7)
            {
                this.TxbCategoria3.Text = "Vehículos articulados de servicio público.";
            }
        }

        private void label18_DoubleClick(object sender, EventArgs e)
        {
            this.CmbCategoria2.SelectedIndex = -1;
            this.TxbCategoria2.Text = "";
        }

        private void label19_DoubleClick(object sender, EventArgs e)
        {
            this.CmbCategoria3.SelectedIndex = -1;
            this.TxbCategoria3.Text = "";
        }

        private void DtgLicenciaConductor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DtpFechaExpedicion.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[4].Value);
            this.TxbRestricciones.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[5].Value);
            this.TxbOrganismoTransito.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[6].Value);
            this.CmbCategoria1.SelectedIndex = Convert.ToInt32(this.DtgLicenciaConductor.CurrentRow.Cells[7].Value);
            this.CmbCategoria2.SelectedIndex = Convert.ToInt32(this.DtgLicenciaConductor.CurrentRow.Cells[8].Value);
            this.CmbCategoria3.SelectedIndex = Convert.ToInt32(this.DtgLicenciaConductor.CurrentRow.Cells[9].Value);
            this.TxbCategoria1.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[10].Value);
            this.TxbCategoria2.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[11].Value);
            this.TxbCategoria3.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[12].Value);
            this.DtpVigencia1.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[13].Value);
            this.DtpVigencia2.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[14].Value);
            this.DtpVigencia3.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[15].Value);
            this.TxbNroLicencia.Text = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[16].Value);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region Eliminando Datos

            if (this.TxbIdentificacion.Text.Length > 0)
            {
                string Id = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[0].Value);
                string Expedicion = Convert.ToString(this.DtgLicenciaConductor.CurrentRow.Cells[4].Value);
                DialogResult Opcion = MessageBox.Show("Desea Eliminar el registro? " + Environment.NewLine + "Id " + Id.Trim() + Environment.NewLine + "Fecha de Expedicion " + Expedicion, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Opcion == DialogResult.Yes)
                {
                    SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                    Parametros_Consulta[0] = new SqlParameter("@Op", "ConductorEspe");
                    Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                    Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                    Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                    ConsultaEntidades Maestro = new ConsultaEntidades();
                    GuardarDatos GuardarDatos = new GuardarDatos();
                    Ent_Conductores Reader = new Ent_Conductores();

                    Reader = Maestro.Conductores("SpConsulta_Tablas", Parametros_Consulta);

                    if (Reader.Codigo != null)
                    {
                        try
                        {
                            SqlParameter[] ParametrosEnt = new SqlParameter[18];
                            ParametrosEnt[0] = new SqlParameter("@Op", "D");
                            ParametrosEnt[1] = new SqlParameter("@IdConductor", Id);
                            ParametrosEnt[2] = new SqlParameter("@FechaExpedicion", this.DtpFechaExpedicion.Text.Trim().Replace("/", ""));
                            ParametrosEnt[3] = new SqlParameter("@RestriccionesConductor", this.TxbRestricciones.Text.Trim());
                            ParametrosEnt[4] = new SqlParameter("@OrganismoTransito", this.TxbOrganismoTransito.Text.Trim());
                            ParametrosEnt[5] = new SqlParameter("@Categoria1", this.CmbCategoria1.SelectedIndex);
                            ParametrosEnt[6] = new SqlParameter("@Categoria2", this.CmbCategoria2.SelectedIndex);
                            ParametrosEnt[7] = new SqlParameter("@Categoria3", this.CmbCategoria3.SelectedIndex);
                            ParametrosEnt[8] = new SqlParameter("@DetalleCategoria1", this.TxbCategoria1.Text.Trim());
                            ParametrosEnt[9] = new SqlParameter("@DetalleCategoria2", this.TxbCategoria2.Text.Trim());
                            ParametrosEnt[10] = new SqlParameter("@DetalleCategoria3", this.TxbCategoria3.Text.Trim());
                            ParametrosEnt[11] = new SqlParameter("@Vigencia1", this.DtpVigencia1.Text.Trim().Replace("/", ""));
                            ParametrosEnt[12] = new SqlParameter("@Vigencia2", this.DtpVigencia2.Text.Trim().Replace("/", ""));
                            ParametrosEnt[13] = new SqlParameter("@Vigencia3", this.DtpVigencia3.Text.Trim().Replace("/", ""));
                            ParametrosEnt[14] = new SqlParameter("@Realizado", DateTime.Now);
                            ParametrosEnt[15] = new SqlParameter("@Maquina", Environment.MachineName);
                            ParametrosEnt[16] = new SqlParameter("@Usuario", this.IdUsuario);
                            ParametrosEnt[17] = new SqlParameter("@NroLicencia", this.TxbNroLicencia.Text.Trim());



                            GuardarDatos Guardar = new GuardarDatos();
                            Guardar.booleano("GRB_TiposLicenciaConductor", ParametrosEnt);

                            MessageBox.Show("Datos Eliminados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.button6.PerformClick();

                            #region Actualizando el DatGridView Licencia Conductor
                            try
                            {
                                SqlParameter[] ParametrosGrid = new SqlParameter[4];
                                ParametrosGrid[0] = new SqlParameter("@Op", "LicConductorEspe");
                                ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                                ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                                ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                                DataSet DS;

                                DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                                this.DtgLicenciaConductor.DataSource = DS;
                                this.DtgLicenciaConductor.DataMember = "Result";
                                this.DtgLicenciaConductor.AutoResizeColumns();
                            }
                            catch (Exception Exc)
                            {
                                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion

                        }
                        catch (Exception Exc)
                        {
                            MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            #endregion
        }

        private void Btn_GuardarAd_Click(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "ConductorEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            GuardarDatos GuardarDatos = new GuardarDatos();
            Ent_Conductores Reader = new Ent_Conductores();

            Reader = Maestro.Conductores("SpConsulta_Tablas", Parametros_Consulta);

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
                    bool Realizado = Guardar.booleano("GRBBascula_Guardar_DatosAdjuntosConductores", ParametrosEnt);
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
                ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosConductores");
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

        private void Btn_NuevoAd_Click(object sender, EventArgs e)
        {
            this.TxbAdjuntosDetalle.Text = "";
            this.TxbAdjuntosPath.Text = "";
        }

        private void DtgAdjunto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Muestra o ejecuta los Datos adjuntos
            int IdFile = Convert.ToInt32(this.DtgAdjunto.CurrentRow.Cells[0].Value);
            try
            {
                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "AdjuntosByteConduct");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", "");
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", IdFile);
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                GuardarDatos GuardarDatos = new GuardarDatos();
                Ent_DatosAdjuntos ReaderConsulta = new Ent_DatosAdjuntos();

                ReaderConsulta = Maestro.Adjunto("SpConsulta_Tablas", Parametros_Consulta);

                string fichero = Convert.ToString(Path.GetTempPath()) + "Temp_" + ReaderConsulta.Nombre + ReaderConsulta.Extension;

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

        private void CmbCategoriaSeguridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.CmbCategoriaSeguridad.Text.Trim())
            {
                case "A1":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Motocicletas igual o menor a 125 c.c");
                    break;
                case "A2":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Motocicletas superiores a 125 c.c");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Motociclos  superiores a 125 c.c");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Mototriciclos  superiores a 125 c.c");
                    break;
                case "B1":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Automóviles particulares");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Motocarros particulares");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Camperos particulares");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Camionetas particulares");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Vehículos cuatrimotor particulares");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Microbuses de servicio particular");
                    break;
                case "B2":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Camiones");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Buses");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Busetas");
                    break;
                case "B3":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Vehículos articulados");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Tractocamiones");
                    break;
                case "C1":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Automóviles de servicio público");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Motocarros de servicio público");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Cuatrimotor de servicio público");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Camionetas de servicio público");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Microbuses de servicio público");
                    break;
                case "C2":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Camiones rígidos de servicio público");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Buses de servicio público");
                    this.CmbTipoVehiculoSeguridad.Items.Add("Busetas de servicio público");
                    break;
                case "C3":
                    this.CmbTipoVehiculoSeguridad.Items.Clear();
                    this.CmbTipoVehiculoSeguridad.Items.Add("Vehículos articulados de servicio público");
                    break;
            }

        }

        private void BtnGuardarSeguridad_Click(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "ConductorEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            GuardarDatos GuardarDatos = new GuardarDatos();
            Ent_Conductores Reader = new Ent_Conductores();

            Reader = Maestro.Conductores("SpConsulta_Tablas", Parametros_Consulta);

            #region Insertando Datos
            if (Reader.Codigo != null)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[18];
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                    ParametrosEnt[1] = new SqlParameter("@IdConductor", Reader.Id);
                    switch (this.CmbCategoriaSeguridad.Text.Trim())
                    {
                        case "A1":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 0);
                            break;
                        case "A2":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 1);
                            break;
                        case "B1":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 2);
                            break;
                        case "B2":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 3);
                            break;
                        case "B3":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 4);
                            break;
                        case "C1":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 5);
                            break;
                        case "C2":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 6);
                            break;
                        case "C3":
                            ParametrosEnt[2] = new SqlParameter("@Categoria", 7);
                            break;
                    }

                    ParametrosEnt[3] = new SqlParameter("@Cargo", this.TxbCargoSeguridad.Text.Trim());
                    ParametrosEnt[4] = new SqlParameter("@AñosExperiencia", this.NmdAñosExpe.Value);
                    ParametrosEnt[5] = new SqlParameter("@UltimoCurso", this.DtpUltimoCursoSegu.Text.Trim().Replace("/", ""));
                    ParametrosEnt[6] = new SqlParameter("@EntidadCertifica", this.TxbEntidadCertiSegu.Text.Trim());
                    ParametrosEnt[7] = new SqlParameter("@ReporteSimit", this.ChbReporteSimit.Checked);
                    ParametrosEnt[8] = new SqlParameter("@ReporteMinisterio", this.ChbReporteMinisterio.Checked);
                    ParametrosEnt[9] = new SqlParameter("@CertificadoManejo", this.ChbCertificadoManejo.Checked);
                    ParametrosEnt[10] = new SqlParameter("@ReporteRunt", this.ChbReporteRunt.Checked);
                    ParametrosEnt[11] = new SqlParameter("@QuienVerifica", this.TxbQuienCertifica.Text.Trim());
                    ParametrosEnt[12] = new SqlParameter("@Observaciones", this.TxbObservacionesSeg.Text.Trim());
                    ParametrosEnt[13] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[14] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[15] = new SqlParameter("@Usuario", this.IdUsuario);
                    ParametrosEnt[16] = new SqlParameter("@TipoVehiculo", this.CmbTipoVehiculoSeguridad.SelectedIndex);
                    ParametrosEnt[17] = new SqlParameter("@Stiker", this.TxbStiker.Text.Trim());

                    GuardarDatos Guardar = new GuardarDatos();
                    Guardar.booleano("GRBBascula_SeguridadVial", ParametrosEnt);

                    MessageBox.Show("Datos almacenados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    #region Actualizando el DatGridView Seguridad Vial
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "SeguVialEspe");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DtgSeguridadVial.DataSource = DS;
                        this.DtgSeguridadVial.DataMember = "Result";
                        this.DtgSeguridadVial.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            #endregion
            }
        }

        private void DtgSeguridadVial_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.CmbCategoriaSeguridad.SelectedIndex = Convert.ToInt32(this.DtgSeguridadVial.CurrentRow.Cells[4].Value);
            string categoria = "";
            this.CmbCategoriaSeguridad.Items.Clear();
            switch (Convert.ToInt32(this.DtgSeguridadVial.CurrentRow.Cells[4].Value))
            {
                case 0:
                    categoria = "A1";
                    break;
                case 1:
                    categoria = "A2";
                    break;
                case 2:
                    categoria = "B1";
                    break;
                case 3:
                    categoria = "B2";
                    break;
                case 4:
                    categoria = "B3";
                    break;
                case 5:
                    categoria = "C1";
                    break;
                case 6:
                    categoria = "C2";
                    break;
                case 7:
                    categoria = "C3";
                    break;
            }
            this.CmbCategoriaSeguridad.Items.Add(categoria);
            this.CmbCategoriaSeguridad.SelectedIndex = 0;
            this.CmbTipoVehiculoSeguridad.SelectedIndex = Convert.ToInt32(this.DtgSeguridadVial.CurrentRow.Cells[5].Value);
            this.TxbCargoSeguridad.Text = Convert.ToString(this.DtgSeguridadVial.CurrentRow.Cells[6].Value);
            this.NmdAñosExpe.Value = Convert.ToInt32(this.DtgSeguridadVial.CurrentRow.Cells[7].Value);
            this.DtpUltimoCursoSegu.Text = Convert.ToString(this.DtgSeguridadVial.CurrentRow.Cells[8].Value);
            this.TxbEntidadCertiSegu.Text = Convert.ToString(this.DtgSeguridadVial.CurrentRow.Cells[9].Value);
            this.ChbReporteSimit.Checked = Convert.ToBoolean(this.DtgSeguridadVial.CurrentRow.Cells[10].Value);
            this.ChbReporteMinisterio.Checked = Convert.ToBoolean(this.DtgSeguridadVial.CurrentRow.Cells[11].Value);
            this.ChbCertificadoManejo.Checked = Convert.ToBoolean(this.DtgSeguridadVial.CurrentRow.Cells[12].Value);
            this.ChbReporteRunt.Checked = Convert.ToBoolean(this.DtgSeguridadVial.CurrentRow.Cells[13].Value);
            this.TxbQuienCertifica.Text = Convert.ToString(this.DtgSeguridadVial.CurrentRow.Cells[14].Value);
            this.TxbObservacionesSeg.Text = Convert.ToString(this.DtgSeguridadVial.CurrentRow.Cells[15].Value);
            this.TxbStiker.Text = Convert.ToString(this.DtgSeguridadVial.CurrentRow.Cells[16].Value);

        }

        private void BtnBorrarSegu_Click(object sender, EventArgs e)
        {
            #region Eliminando Datos

            if (this.TxbIdentificacion.Text.Length > 0)
            {
                string Id = Convert.ToString(this.DtgSeguridadVial.CurrentRow.Cells[0].Value);
                DialogResult Opcion = MessageBox.Show("Desea Eliminar el registro? " + Environment.NewLine + "Id " + Id.Trim(), "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Opcion == DialogResult.Yes)
                {
                    SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                    Parametros_Consulta[0] = new SqlParameter("@Op", "ConductorEspe");
                    Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                    Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                    Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                    ConsultaEntidades Maestro = new ConsultaEntidades();
                    GuardarDatos GuardarDatos = new GuardarDatos();
                    Ent_Conductores Reader = new Ent_Conductores();

                    Reader = Maestro.Conductores("SpConsulta_Tablas", Parametros_Consulta);

                    if (Reader.Codigo != null)
                    {
                        try
                        {
                            SqlParameter[] ParametrosEnt = new SqlParameter[18];
                            ParametrosEnt[0] = new SqlParameter("@Op", "D");
                            ParametrosEnt[1] = new SqlParameter("@IdConductor", Id);
                            ParametrosEnt[2] = new SqlParameter("@Categoria", this.CmbCategoriaSeguridad.SelectedIndex);
                            ParametrosEnt[3] = new SqlParameter("@Cargo", this.TxbCargoSeguridad.Text.Trim());
                            ParametrosEnt[4] = new SqlParameter("@AñosExperiencia", this.NmdAñosExpe.Value);
                            ParametrosEnt[5] = new SqlParameter("@UltimoCurso", this.DtpUltimoCursoSegu.Text.Trim().Replace("/", ""));
                            ParametrosEnt[6] = new SqlParameter("@EntidadCertifica", this.TxbEntidadCertiSegu.Text.Trim());
                            ParametrosEnt[7] = new SqlParameter("@ReporteSimit", this.ChbReporteSimit.Checked);
                            ParametrosEnt[8] = new SqlParameter("@ReporteMinisterio", this.ChbReporteMinisterio.Checked);
                            ParametrosEnt[9] = new SqlParameter("@CertificadoManejo", this.ChbCertificadoManejo.Checked);
                            ParametrosEnt[10] = new SqlParameter("@ReporteRunt", this.ChbReporteRunt.Checked);
                            ParametrosEnt[11] = new SqlParameter("@QuienVerifica", this.TxbQuienCertifica.Text.Trim());
                            ParametrosEnt[12] = new SqlParameter("@Observaciones", this.TxbObservacionesSeg.Text.Trim());
                            ParametrosEnt[13] = new SqlParameter("@Realizado", DateTime.Now);
                            ParametrosEnt[14] = new SqlParameter("@Maquina", Environment.MachineName);
                            ParametrosEnt[15] = new SqlParameter("@Usuario", this.IdUsuario);
                            ParametrosEnt[16] = new SqlParameter("@TipoVehiculo", this.CmbTipoVehiculoSeguridad.SelectedIndex);
                            ParametrosEnt[17] = new SqlParameter("@Stiker", this.TxbStiker.Text.Trim());



                            GuardarDatos Guardar = new GuardarDatos();
                            Guardar.booleano("GRBBascula_SeguridadVial", ParametrosEnt);

                            MessageBox.Show("Datos Eliminados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.button6.PerformClick();

                            #region Actualizando el DatGridView Licencia Conductor
                            try
                            {
                                SqlParameter[] ParametrosGrid = new SqlParameter[4];
                                ParametrosGrid[0] = new SqlParameter("@Op", "SeguVialEspe");
                                ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbIdentificacion.Text.Trim());
                                ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                                ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                                DataSet DS;

                                DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                                this.DtgSeguridadVial.DataSource = DS;
                                this.DtgSeguridadVial.DataMember = "Result";
                                this.DtgSeguridadVial.AutoResizeColumns();
                            }
                            catch (Exception Exc)
                            {
                                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            #endregion

                        }
                        catch (Exception Exc)
                        {
                            MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            #endregion
        }

        private void BtnImprimirComVial_Click(object sender, EventArgs e)
        {
            FrmRptCompromisoVial Report = new FrmRptCompromisoVial();
            Report.Conductor = this.TxbIdentificacion.Text.Trim();
            Report.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.TxbIdentificacion.Text.Trim().Length == 0)
                MessageBox.Show("No puede asignar un vehiculo sin antes tener seleccionado un conductor");
            else
            {
                Op = 3;
                Frm_Consultas Forma = new Frm_Consultas(4);
                Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
                Forma.ShowDialog();
            }
        }

        private void TxbPlaca_Leave(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_ConsultaVehiculos = new SqlParameter[4];
            Parametros_ConsultaVehiculos[0] = new SqlParameter("@Op", "VehiculosEspe");
            Parametros_ConsultaVehiculos[1] = new SqlParameter("@ParametroChar", this.TxbPlaca.Text.Trim());
            Parametros_ConsultaVehiculos[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_ConsultaVehiculos[3] = new SqlParameter("@ParametroNuemric", "0.0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Vehiculo ReaderVehiculos = new Ent_Vehiculo();

            ReaderVehiculos = Maestro.Vehiculo("SpConsulta_Tablas", Parametros_ConsultaVehiculos);

            if (ReaderVehiculos.Placa != null)
            {
                this.TxbPlaca.Text = ReaderVehiculos.Placa.Trim();
                this.TxbLicenciaFTara.Text = ReaderVehiculos.Peso.ToString("###,###,##0");
                this.TxbNombProyecto.Text = ReaderVehiculos.NombreProyecto.Trim();
                this.ptbVehiculo.Image = ImageConvert.byteToImage(ReaderVehiculos.Foto);
            }
        }

        private void BtnBajarVehiculo_Click(object sender, EventArgs e)
        {
            if (this.TxbIdentificacion.Text.Trim().Length > 0)
            {
                int Registros = this.DgvVehiculos.Rows.Count;
                int Estado = 0;

                if (Registros == 0)
                    this.DgvVehiculos.Rows.Insert(this.DgvVehiculos.RowCount, true, this.TxbPlaca.Text.Trim(), this.TxbNombProyecto.Text.Trim());
                else
                {
                    foreach (DataGridViewRow rowGrid in this.DgvVehiculos.Rows)
                    {

                        if (rowGrid.Cells[1].Value.ToString().Trim() == this.TxbPlaca.Text.Trim())
                        {
                            MessageBox.Show("Vehiculo reportado anteriormente para este conductor " + rowGrid.Cells[1].Value.ToString().Trim());
                            Estado = 1;
                        }
                    }
                    if (Estado == 0)
                    {
                        this.DgvVehiculos.Rows.Insert(this.DgvVehiculos.RowCount, false, this.TxbPlaca.Text.Trim(), this.TxbNombProyecto.Text.Trim());
                    }
                }


                int I = 0;
                foreach (DataGridViewColumn Column in DgvVehiculos.Columns)
                {
                    if (I == 0)
                        Column.ReadOnly = false;
                    else
                        Column.ReadOnly = true;
                    I += 1;
                }
            }
        }

        private void DgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvVehiculos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //int RegDgv = Convert.ToInt32(this.DgvVehiculos.CurrentCell.RowIndex);
            //this.DgvVehiculos.Rows[RegDgv].Cells[0].Value = true;
        }



        private void button9_Click(object sender, EventArgs e)
        {
            this.TxbPlaca.Text = "";
            this.TxbLicenciaFTara.Text = "0";
            this.TxbNombProyecto.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.TxbIdentificacion.Text.Trim().Length > 0)
            {
                string Placa = Convert.ToString(this.DgvVehiculos.CurrentRow.Cells[1].Value);
                DialogResult Opcion = MessageBox.Show("Desea Eliminar el registro? " + Environment.NewLine + "Placa " + Placa.Trim(), "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Opcion == DialogResult.Yes)
                {
                    this.DgvVehiculos.Rows.RemoveAt(Convert.ToInt32(this.DgvVehiculos.CurrentCell.RowIndex));
                    this.BtnGuadarVehiculos.PerformClick();
                    MessageBox.Show("Vehiculo Eliminado correctamente.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea Eliminar el Conductor" + Environment.NewLine + this.TxbIdentificacion.Text.Trim() + " " + this.TxbNombre.Text.Trim() + " " + this.TxbApellido.Text.Trim(), "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Opcion == DialogResult.Yes)
            {
                if (this.TxbIdentificacion.Text.Trim().Length > 0)
                {
                    try
                    {
                        SqlParameter[] ParametrosEnt = new SqlParameter[17];

                        ParametrosEnt[0] = new SqlParameter("@Op", "D");
                        ParametrosEnt[1] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                        ParametrosEnt[2] = new SqlParameter("@Codigo", this.TxbIdentificacion.Text.Trim());
                        ParametrosEnt[3] = new SqlParameter("@Nombre", this.TxbNombre.Text.Trim());
                        ParametrosEnt[4] = new SqlParameter("@Apellido", this.TxbApellido.Text.Trim());
                        ParametrosEnt[5] = new SqlParameter("@Direccion", this.TxbDireccion.Text.Trim());
                        ParametrosEnt[6] = new SqlParameter("@TelFijo", this.TxbTelFijo.Text.Trim());
                        ParametrosEnt[7] = new SqlParameter("@Email", this.TxbEmail.Text.Trim());
                        ParametrosEnt[8] = new SqlParameter("@Telefono", this.TxbCelular.Text.Trim());
                        ParametrosEnt[9] = new SqlParameter("@Nacimiento", this.DtpNacimiento.Text.Trim());
                        ParametrosEnt[10] = new SqlParameter("@RH", this.CmbRH.SelectedIndex);
                        ParametrosEnt[11] = new SqlParameter("@Contratista", this.TxbIdContratista.Text.Trim());
                        ParametrosEnt[12] = new SqlParameter("@IdVehiculo", "380");
                        ParametrosEnt[13] = new SqlParameter("@Foto", ImageConvert.imageToByte(this.PtbConductor.Image));
                        ParametrosEnt[14] = new SqlParameter("@Realizado", DateTime.Now);
                        ParametrosEnt[15] = new SqlParameter("@Maquina", Environment.MachineName);
                        ParametrosEnt[16] = new SqlParameter("@Usuario", this.IdUsuario);

                        GuardarDatos GuardarDatos = new GuardarDatos();
                        bool Borrar = GuardarDatos.booleano("GRBConductores", ParametrosEnt);
                        if (Borrar)
                            MessageBox.Show("Datos del Conductor Eliminados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_BorrarAd_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea Eliminar el archivo" + Environment.NewLine + Convert.ToString(this.DtgAdjunto.CurrentRow.Cells[1].Value).Trim() + Convert.ToString(this.DtgAdjunto.CurrentRow.Cells[2].Value).Trim(), "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            int Id = Convert.ToInt32(this.DtgAdjunto.CurrentRow.Cells[0].Value);
            if (Opcion == DialogResult.Yes)
            {
                try
                {

                    SqlParameter[] ParametrosEnt = new SqlParameter[11];
                    ParametrosEnt[0] = new SqlParameter("@Op", "D");
                    ParametrosEnt[1] = new SqlParameter("@Id", Id);
                    ParametrosEnt[2] = new SqlParameter("@IdVehiculo", "0");
                    ParametrosEnt[3] = new SqlParameter("@Tipo", "1");
                    ParametrosEnt[4] = new SqlParameter("@Nombre", "");
                    ParametrosEnt[5] = new SqlParameter("@Archivo", Encoding.ASCII.GetBytes(""));
                    ParametrosEnt[6] = new SqlParameter("@Extension", "");
                    ParametrosEnt[7] = new SqlParameter("@Detalle", this.TxbAdjuntosPath.Text.Trim());
                    ParametrosEnt[8] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[9] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[10] = new SqlParameter("@Usuario", this.IdUsuario);

                    GuardarDatos Guardar = new GuardarDatos();
                    bool Realizado = Guardar.booleano("GRBBascula_Guardar_DatosAdjuntosConductores", ParametrosEnt);

                    MessageBox.Show("Archivo Adjunto eliminado satisfactoriamente.", "Informe del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ExtTipo1)
                {
                    MessageBox.Show("Error Controlado al Elminar " + ExtTipo1.Message);
                }
            }

        }

        private void BtnGuadarVehiculos_Click(object sender, EventArgs e)
        {
            if (this.TxbIdentificacion.Text.Trim().Length > 0)
            {
                DataTable Tbl_VehConductor = new DataTable();
                Tbl_VehConductor.Columns.Add("CodigoConductor");
                Tbl_VehConductor.Columns.Add("Placa");
                Tbl_VehConductor.Columns.Add("Principal");
                DataRow Row = Tbl_VehConductor.NewRow();

                foreach (DataGridViewRow row in this.DgvVehiculos.Rows)
                {
                    string codigoconductor = this.TxbIdentificacion.Text.Trim();
                    string placa = Convert.ToString(row.Cells[1].Value);
                    bool principal = Convert.ToBoolean(row.Cells[0].Value);

                    Row["CodigoConductor"] = codigoconductor;
                    Row["Placa"] = placa;
                    Row["Principal"] = principal;
                    Tbl_VehConductor.Rows.Add(Row);
                    Row = Tbl_VehConductor.NewRow();
                }
                SqlParameter[] Parametro = new SqlParameter[1];
                Parametro[0] = new SqlParameter("@Tbl_VehConductor", Tbl_VehConductor);
                DataSet DS = LlenarGrid.Datos("Sp_Guardar_ConductoresVehiculos", Parametro);
            }
        }

        private void DgvVehiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RegDgv = Convert.ToInt32(this.DgvVehiculos.CurrentCell.RowIndex);
            int I = 0;
            foreach (DataGridViewRow rowGrid in this.DgvVehiculos.Rows)
            {
                rowGrid.Cells[0].Value = false;
                if (I == RegDgv)
                    rowGrid.Cells[0].Value = true;
                I += 1;
            }
            this.DgvVehiculos.Rows[RegDgv].Cells[0].Value = true;
        }

        private void BtnNuevoSegVial_Click(object sender, EventArgs e)
        {
            this.CmbCategoriaSeguridad.SelectedIndex = -1;
            this.CmbTipoVehiculoSeguridad.SelectedIndex = -1;
            this.TxbCargoSeguridad.Text = "";
            this.NmdAñosExpe.Value = 0;
            this.DtpUltimoCursoSegu.Text = "";
            this.TxbEntidadCertiSegu.Text = "";
            this.ChbReporteSimit.Checked = false;
            this.ChbReporteMinisterio.Checked = false;
            this.ChbCertificadoManejo.Checked = false;
            this.ChbReporteRunt.Checked = false;
            this.TxbQuienCertifica.Text = "";
            this.TxbObservacionesSeg.Text = "";
            this.TxbStiker.Text = "";

            #region Llenado el combo de las licencias validas en el tap de compromisos de seguridad
            this.CmbCategoriaSeguridad.Items.Clear();
            foreach (DataGridViewRow item in this.DtgLicenciaConductor.Rows)
            {
                string Categoria = "";
                int Categoria1 = Convert.ToInt32(item.Cells[7].Value);
                int Categoria2 = Convert.ToInt32(item.Cells[8].Value);
                int Categoria3 = Convert.ToInt32(item.Cells[9].Value);

                DateTime Vencimiento1 = Convert.ToDateTime(item.Cells[13].Value);
                DateTime Vencimiento2 = Convert.ToDateTime(item.Cells[14].Value);
                DateTime Vencimiento3 = Convert.ToDateTime(item.Cells[15].Value);

                switch (Categoria1)
                {
                    case 0:
                        Categoria = "A1";
                        break;
                    case 1:
                        Categoria = "A2";
                        break;
                    case 2:
                        Categoria = "B1";
                        break;
                    case 3:
                        Categoria = "B2";
                        break;
                    case 4:
                        Categoria = "B3";
                        break;
                    case 5:
                        Categoria = "C1";
                        break;
                    case 6:
                        Categoria = "C2";
                        break;
                    case 7:
                        Categoria = "C3";
                        break;
                }
                if (Vencimiento1 >= DateTime.Now)
                    this.CmbCategoriaSeguridad.Items.Add(Categoria);

                switch (Categoria2)
                {
                    case 0:
                        Categoria = "A1";
                        break;
                    case 1:
                        Categoria = "A2";
                        break;
                    case 2:
                        Categoria = "B1";
                        break;
                    case 3:
                        Categoria = "B2";
                        break;
                    case 4:
                        Categoria = "B3";
                        break;
                    case 5:
                        Categoria = "C1";
                        break;
                    case 6:
                        Categoria = "C2";
                        break;
                    case 7:
                        Categoria = "C3";
                        break;
                }
                if (Vencimiento2 >= DateTime.Now)
                    this.CmbCategoriaSeguridad.Items.Add(Categoria);

                switch (Categoria3)
                {
                    case 0:
                        Categoria = "A1";
                        break;
                    case 1:
                        Categoria = "A2";
                        break;
                    case 2:
                        Categoria = "B1";
                        break;
                    case 3:
                        Categoria = "B2";
                        break;
                    case 4:
                        Categoria = "B3";
                        break;
                    case 5:
                        Categoria = "C1";
                        break;
                    case 6:
                        Categoria = "C2";
                        break;
                    case 7:
                        Categoria = "C3";
                        break;
                }
                if (Vencimiento3 >= DateTime.Now)
                    this.CmbCategoriaSeguridad.Items.Add(Categoria);
            }

            #endregion
        }





    }
}

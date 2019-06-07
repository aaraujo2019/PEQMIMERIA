using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{

    public partial class Frm_PesajesMineraPlanta : Form
    {
        #region Variables
        private static string Placa = string.Empty;
        private static int Op = 0;
        private static string placaTemporal = string.Empty;
        public string Login = string.Empty;
        public string idConductor = string.Empty;
        Timer Clock;
        int index = -1;
        bool indicativoPlacaIncompleto = false;
        private string consecutiveReturn = string.Empty;
        #endregion

        #region Constructor
        public Frm_PesajesMineraPlanta(string login)
        {
            InitializeComponent();
            //Pruebas Llamadoss
            this.Login = login;
            this.label11.Text = DateTime.Now.ToString("dd/MM/yyyy");
            #region Configuracion inicial carga
            List<Ent_Localizacion> Reader = new List<Ent_Localizacion>();
            Reader = ConsultaEntidades.ObtenerLocalizacion("SpConsulta_Tablas", "recuLocalizacion", "", 0, "0");
            cboLocalizacion.DataSource = Reader;
            cboLocalizacion.ValueMember = "Identificacacion";
            cboLocalizacion.DisplayMember = "Nombre";
            cboLocalizacion.SelectedIndex = -1;

            this.tolSripValorSalida.Image = null;
            txtConcecutivo.Text = 0.ToString();
            txtConcecutivo.BackColor = Color.FromArgb(217, 213, 213);
            txtConcecutivo.Focus();


            TxtPlaca.Enabled = true;
            TxbConductor.Enabled = true;
            txtProyectoInfProyecto.Enabled = true;
            txtPlaza.Enabled = true;
            #endregion
        }
        #endregion 

        #region Metodos
        public void EjecutaPasarDato(string Dato)
        {
            switch (Op)
            {
                case 0:
                    txtConcecutivo.Text = Dato;
                    txtConcecutivo_Leave(null, null);
                    break;
                case 1:
                    txtConcecutivo.Text = Dato;
                    txtConcecutivo_Leave(null, null);
                    break;

                case 2:
                    if (Dato.Contains("-"))
                        TxtPlaca.Text = Dato;
                    else
                        consecutiveReturn = Dato;

                    TxtPlaca_Leave(null, null);
                    break;


                case 3:
                    TxbConductor.Text = Dato;
                    TxbConductor_Leave(null, null);
                    break;

                case 4:
                    txtPlaza.Text = Dato;
                    txtPlaza_Leave(null, null);
                    break;

                case 5:
                    txtProyectoInfProyecto.Text = Dato;
                    txtProyectoInfProyecto_Leave(null, null);
                    break;

                case 6:

                    if (Dato.Contains("/"))
                    {
                        string[] valueRegister = Dato.Split('/');

                        idConductor = valueRegister[1];

                        TxtPlaca.Text = valueRegister[0];
                        TxtPlaca_Leave(null, null);
                    }
                    else
                    {
                        TxtPlaca.Text = Dato;
                        TxtPlaca_Leave(null, null);
                    }
                    break;
            }
        }
        #endregion 

        #region Eventos
        private void btnNew_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.GroupBox)
                {
                    foreach (Control item in control.Controls)
                    {
                        if (item is System.Windows.Forms.TextBox)
                            item.Text = string.Empty;

                        if (item is System.Windows.Forms.MaskedTextBox)
                            item.Text = string.Empty;
                    }
                }
            }
            dtpDate.Value = DateTime.Now;
            tolstripPeso.Text = string.Empty;
            tolstripDefaul.Text = string.Empty;
            tolSripValorSalida.Text = string.Empty;
            tolSripValorSalida.ToolTipText = string.Empty;
            cboLocalizacion.SelectedIndex = -1;
            cboLocalizacion.Enabled = true;
            cboLocalizacion.Enabled = true;
            btnplaca.Enabled = true;
            btnProyecto.Enabled = true;
            btnPlaza.Enabled = true;
            btnCatidadPlaca.Visible = false;


            btnConduc.Enabled = true;
            TxtPlaca.Enabled = true;
            TxbConductor.Enabled = true;
            txtProyectoInfProyecto.Enabled = true;
            txtPlaza.Enabled = true;
            txtConcecutivo.Enabled = true;
            txtConcecutivo.Text = 0.ToString();
            dtpDate.Enabled = true;
            consecutiveReturn = string.Empty;

            this.txtConcecutivo.Focus();
            this.toolTip1.SetToolTip(toolStrip1, "");


            List<Ent_Localizacion> Reader = new List<Ent_Localizacion>();

            Reader = ConsultaEntidades.ObtenerLocalizacion("SpConsulta_Tablas", "recuLocalizacion", "", 0, "0");
            cboLocalizacion.DataSource = Reader;
            cboLocalizacion.ValueMember = "Identificacacion";
            cboLocalizacion.DisplayMember = "Nombre";
            cboLocalizacion.SelectedIndex = -1;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /*SqlParameter[] ParametrosEnt = new SqlParameter[10];
                 ParametrosEnt[1] = new SqlParameter("@Identificacion", this.txbIdentificacion.Text.Trim());
                 ParametrosEnt[2] = new SqlParameter("@Nombre", this.txbNombre.Text.Trim());
                 ParametrosEnt[3] = new SqlParameter("@Apellido", this.txbApellido.Text.Trim());
                 ParametrosEnt[4] = new SqlParameter("@TelFijo", this.txbTelfijo.Text.Trim());
                 ParametrosEnt[5] = new SqlParameter("@Extension", this.txbExtension.Text.Trim());
                 ParametrosEnt[6] = new SqlParameter("@Celular", this.txbCelular.Text.Trim());
                 ParametrosEnt[7] = new SqlParameter("@email", this.txbEmail.Text.Trim());
                 ParametrosEnt[8] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                 ParametrosEnt[9] = new SqlParameter("@FechaCreacion", DateTime.Now.Date);

                 SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                 Parametros_Consulta[0] = new SqlParameter("@Op", "PropietariosEspe");
                 Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.txbIdentificacion.Text.Trim());
                 Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                 Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                 ConsultaEntidades Maestro = new ConsultaEntidades();
                 GuardarDatos GuardarDatos = new GuardarDatos();
                 Ent_Propietarios Reader = new Ent_Propietarios();

                 Reader = Maestro.Propietarios("SpConsulta_Tablas", Parametros_Consulta);

                 if (Reader.Nombre == null)
                     ParametrosEnt[0] = new SqlParameter("@Op", "I");
                 else
                     ParametrosEnt[0] = new SqlParameter("@Op", "U");

                 GuardarDatos.booleano("GrbBascula_Propietarios", ParametrosEnt);

                 if (Reader.Identificacion == null)
                     MessageBox.Show("Propietario creado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 else
                     MessageBox.Show("Propietario actualizado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     */
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    /* SqlParameter[] ParametrosEnt = new SqlParameter[10];
                     ParametrosEnt[0] = new SqlParameter("@Op", "D");
                     ParametrosEnt[1] = new SqlParameter("@Identificacion", this.txbIdentificacion.Text.Trim());
                     ParametrosEnt[2] = new SqlParameter("@Nombre", this.txbNombre.Text.Trim());
                     ParametrosEnt[3] = new SqlParameter("@Apellido", this.txbNombre.Text.Trim());
                     ParametrosEnt[4] = new SqlParameter("@TelFijo", this.txbNombre.Text.Trim());
                     ParametrosEnt[5] = new SqlParameter("@Extension", this.txbNombre.Text.Trim());
                     ParametrosEnt[6] = new SqlParameter("@Celular", this.txbNombre.Text.Trim());
                     ParametrosEnt[7] = new SqlParameter("@email", this.txbNombre.Text.Trim());
                     ParametrosEnt[8] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                     ParametrosEnt[9] = new SqlParameter("@FechaCreacion", DateTime.Now.Date);

                     GuardarDatos GuardarDatos = new GuardarDatos();
                     bool Eliminado = GuardarDatos.booleano("GrbBascula_Propietarios", ParametrosEnt);

                     if (Eliminado)
                         MessageBox.Show("Propietario Elimindo satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     else
                         MessageBox.Show("Problemas al Eliminar.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
     */
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Consultas Forma = new Frm_Consultas(5);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox2.Text = "Todos los conductores";
            else
                checkBox2.Text = "Vehiculo y sus conductores";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (chkCondVehiculo.Checked)
            {
                Frm_Consultas FrmConsultas = new Frm_Consultas(25);
                FrmConsultas.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
                FrmConsultas.ShowDialog();
            }
            else
            {
                Frm_Consultas FrmConsultas = new Frm_Consultas(24);
                FrmConsultas.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
                FrmConsultas.ShowDialog();

            }
        }

        private void txtConcecutivo_Leave(object sender, EventArgs e)
        {
            List<Ent_PesajeMineral> Reader = new List<Ent_PesajeMineral>();
            txtConcecutivo.BackColor = Color.White;

            if (!String.IsNullOrEmpty(this.txtConcecutivo.Text))
            {
                Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "ConsePlanta", "", Convert.ToInt64(this.txtConcecutivo.Text), "0");

                if (Reader != null && Reader.Count() > 0)
                {
                    Ent_PesajeMineral value = Reader[0];
                    dtpDate.Value = value.Fecha;
                    Placa = TxtPlaca.Text = value.PlacaVehiculo;
                    txtDescripciomPlaca.Text = value.DescripcionVehiculo;
                    TxbConductor.Text = value.CodigoConductor.ToString();
                    txtDescripcionCond.Text = value.NombreConductor;
                    txtProyectoInfProyecto.Text = value.CodigoProyecto;
                    txtDescripcionProyecto.Text = value.NombreProyecto;
                    txtPlaza.Text = value.CodigoPlaza;
                    txtDescipcionPlaza.Text = value.NombrePlaza;
                    txtSello1.Text = value.Sello1;
                    txtSello2.Text = value.Sello2;
                    txtSello3.Text = value.Sello3;
                    txtSello4.Text = value.Sello4;
                    txtSello5.Text = value.Sello5;
                    txtSello6.Text = value.Sello6;
                    txtPesoEnt.Text = value.PesoEstado1.ToString("N0", CultureInfo.InvariantCulture);
                    txtPesoSalida.Text = value.PesoEstado0.ToString("N0", CultureInfo.InvariantCulture);
                    txtTotalCargue.Text = (value.PesoEstado1 - value.PesoEstado0).ToString("N0", CultureInfo.InvariantCulture);
                    tolstripPeso.Text = value.PesoVehiculo.ToString("N0", CultureInfo.InvariantCulture);
                    tolstripDefaul.Text = value.CodigoPlazaDefault;
                    ptbFotoVehiculo.Image = DBMETAL_SHARP.Common.Common.ImageConvert.byteToImage(value.Foto);

                    cboLocalizacion.Enabled = false;
                    btnplaca.Enabled = false;
                    btnProyecto.Enabled = false;
                    btnPlaza.Enabled = false;
                    btnConduc.Enabled = false;
                    TxtPlaca.Enabled = false;
                    TxbConductor.Enabled = false;
                    txtProyectoInfProyecto.Enabled = false;
                    txtPlaza.Enabled = false;
                    txtConcecutivo.Enabled = false;
                    dtpDate.Enabled = false;
                    List<Ent_Localizacion> cbo = new List<Ent_Localizacion>();

                    cbo = ConsultaEntidades.ObtenerLocalizacion("SpConsulta_Tablas", "recuLocalizacionParam", "PARAMETRO GUARDADO COMO LOCALIZACION", 0, "0");

                    cboLocalizacion.DataSource = cbo;
                    cboLocalizacion.ValueMember = "Identificacacion";
                    cboLocalizacion.DisplayMember = "Nombre";
                    cboLocalizacion.SelectedIndex = -1;

                    if (value.PesoVehiculo > 0)
                    {
                        decimal dif = Convert.ToInt32(value.PesoVehiculo) - Convert.ToInt32(value.PesoEstado0);
                        decimal calc = (dif * -100) / Convert.ToInt32(value.PesoVehiculo);

                        if (calc >= -5 && calc <= 5)
                        {
                            tolSripValorSalida.Text = dif.ToString("N0");
                            this.toolTip1.SetToolTip(toolStrip1, " Diferencia de peso entre -5% y 5%");

                            this.tolSripValorSalida.Image = DBMETAL_SHARP.Properties.Resources.green;
                            this.tolSripValorSalida.Font = new System.Drawing.Font("Consolas", 8F);
                            this.tolSripValorSalida.ForeColor = System.Drawing.Color.Navy;
                        }
                        else
                            if (calc > 5)
                        {
                            tolSripValorSalida.Text = dif.ToString("N0");
                            this.toolTip1.SetToolTip(toolStrip1, " Diferencia de peso mayor a 5%");
                            this.tolSripValorSalida.Image = DBMETAL_SHARP.Properties.Resources.blue;
                            this.tolSripValorSalida.Font = new System.Drawing.Font("Consolas", 8F);
                            this.tolSripValorSalida.ForeColor = System.Drawing.Color.Navy;
                        }
                        else
                        {
                            tolSripValorSalida.Text = dif.ToString("N0");
                            this.toolTip1.SetToolTip(toolStrip1, " Diferencia de peso menor a 5%");
                            this.tolSripValorSalida.Image = DBMETAL_SHARP.Properties.Resources.red;
                            this.tolSripValorSalida.Font = new System.Drawing.Font("Consolas", 8F);
                            this.tolSripValorSalida.ForeColor = System.Drawing.Color.Navy;
                        }
                    }
                }
            }
        }

        private void txtConcecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxbConductor_TextChanged(object sender, EventArgs e)
        {
            Regex Val = new Regex(@"^[+-]?\d+(\.\d+)?$");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void tolSripValorSalida_Click(object sender, EventArgs e)
        {
            Frm_VistaVehiculos fr = new Frm_VistaVehiculos(Login, Placa);
            fr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TxtPlaca.Text = string.Empty;
            Op = 2;
            Frm_Consultas Forma = new Frm_Consultas(26);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();

            //StartTimer();
        }

        void StartTimer()
        {

            Clock = new Timer();
            Clock.Interval = 5000; // not sure if this length of time will work 
            Clock.Start();
            Clock.Tick += Clock_Tick;
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            if (sender == Clock)
            {
                index++;
                switch (index)
                {
                    case 0:
                        groupBox2.BackColor = System.Drawing.SystemColors.Highlight;
                        break;
                    case 1:
                        groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                        break;
                    case 2:
                        groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                        break;
                    case 3:
                        groupBox2.BackColor = System.Drawing.SystemColors.MenuBar;
                        break;
                    case 4:
                        groupBox2.BackColor = System.Drawing.SystemColors.Menu;
                        break;
                    case 5:
                        groupBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
                        index = -1;
                        break;

                    default:
                        break;
                }
                // do something here      
            }
        }

        void Timer1_Tick(object sender, EventArgs e)
        {
            groupBox2.BackColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op = 3;
            Frm_Consultas Forma = new Frm_Consultas(10);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Op = 5;
            Frm_Consultas Forma = new Frm_Consultas(6);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Op = 4;
            Frm_Consultas Forma = new Frm_Consultas(13);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }



        private void txtConcecutivo_Enter(object sender, EventArgs e)
        {
            if (txtConcecutivo.Text == 0.ToString())
                txtConcecutivo.Text = string.Empty;

            txtConcecutivo.BackColor = Color.FromArgb(217, 213, 213);
        }

        private void TxtPlaca_Leave(object sender, EventArgs e)
        {
            List<Ent_PesajeMineral> Reader = new List<Ent_PesajeMineral>();
            txtConcecutivo.BackColor = Color.White;


            if (!String.IsNullOrEmpty(this.TxtPlaca.Text) && string.IsNullOrEmpty(consecutiveReturn))
            {
                List<Ent_PesajeMineral> ReaderComplete;
                ReaderComplete = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "VehiculosEspeAll", this.TxtPlaca.Text, 0, "0");
                if (ReaderComplete == null || ReaderComplete.Count() == 0)
                {
                    Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "VehIndividual", this.TxtPlaca.Text, 0, "0");
                    if (Reader.Count() > 1 && idConductor.Length > 0)
                        Reader = Reader.Where(s => s.CodigoConductor == idConductor).ToList();
                }
                else
                    Reader = ReaderComplete;
                //Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "VehiculosEspe--VehiculosEsUn", this.TxtPlaca.Text, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    if (Reader.Count() > 1)
                    {
                        btnCatidadPlaca.Visible = true;
                        placaTemporal = this.TxtPlaca.Text;

                        Ent_PesajeMineral value1 = Reader[0];
                        if (value1.Consecutivo > 0)
                        {
                            if (placaTemporal.Length > 6)
                                indicativoPlacaIncompleto = true;

                            consecutiveReturn = value1.Consecutivo.ToString();
                            txtConcecutivo.Text = value1.Consecutivo.ToString();
                            txtConcecutivo_Leave(sender, e);
                        }
                        else
                        {
                            txtConcecutivo.Text = value1.Consecutivo.ToString();
                            TxbConductor.Text = value1.CodigoConductor;
                            TxtPlaca.Text = value1.PlacaVehiculo;
                            txtDescripciomPlaca.Text = value1.DescripcionVehiculo;
                            txtDescripcionCond.Text = value1.NombreConductor;
                            txtProyectoInfProyecto.Text = value1.CodigoProyecto;
                            txtDescripcionProyecto.Text = value1.NombreProyecto;
                            txtPlaza.Text = value1.CodigoPlaza;
                            txtDescipcionPlaza.Text = value1.NombrePlaza;
                            txtSello1.Text = value1.Sello1;
                            txtSello2.Text = value1.Sello2;
                            txtSello3.Text = value1.Sello3;
                            txtSello4.Text = value1.Sello4;
                            txtSello5.Text = value1.Sello5;
                            txtSello6.Text = value1.Sello6;
                            txtPesoEnt.Text = value1.PesoEstado1.ToString("N0", CultureInfo.InvariantCulture);
                            txtPesoSalida.Text = value1.PesoEstado0.ToString("N0", CultureInfo.InvariantCulture);
                            txtTotalCargue.Text = (value1.PesoEstado1 - value1.PesoEstado0).ToString("N0", CultureInfo.InvariantCulture);
                            tolstripPeso.Text = value1.PesoVehiculo.ToString("N0", CultureInfo.InvariantCulture);
                            tolstripDefaul.Text = value1.CodigoPlazaDefault;
                            ptbFotoVehiculo.Image = DBMETAL_SHARP.Common.Common.ImageConvert.byteToImage(value1.Foto);

                            //btnplaca.Enabled = false;
                            //btnProyecto.Enabled = false;
                            //btnPlaza.Enabled = false;
                            //btnConduc.Enabled = false;
                            //TxtPlaca.Enabled = false;
                            //TxbConductor.Enabled = false;
                            //txtProyectoInfProyecto.Enabled = false;
                            //txtPlaza.Enabled = false;
                            consecutiveReturn = string.Empty;
                        }
                    }
                    else
                    {

                        //Ent_PesajeMineral value = Reader[0];
                        //btnCatidadPlaca.Visible = false;
                        //txtDescripciomPlaca.Text = value.DescripcionVehiculo;

                        //List<Ent_PesajeMineral> ReaderComplete;
                        //ReaderComplete = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "VehiculosEspeAll", this.TxtPlaca.Text, 0, "0");
                        //if (ReaderComplete != null && ReaderComplete.Count() > 0)
                        Ent_PesajeMineral value1 = Reader[0];
                        btnCatidadPlaca.Visible = false;

                        if (true)
                        {
                            if (value1.Consecutivo > 0)

                            {
                                btnCatidadPlaca.Visible = false;
                                consecutiveReturn = value1.Consecutivo.ToString();
                                txtConcecutivo.Text = value1.Consecutivo.ToString();
                                txtConcecutivo_Leave(sender, e);
                            }
                            else
                            {
                                txtConcecutivo.Text = value1.Consecutivo.ToString();
                                TxbConductor.Text = value1.CodigoConductor;
                                TxtPlaca.Text = value1.PlacaVehiculo;
                                txtDescripciomPlaca.Text = value1.DescripcionVehiculo;
                                txtDescripcionCond.Text = value1.NombreConductor;
                                txtProyectoInfProyecto.Text = value1.CodigoProyecto;
                                txtDescripcionProyecto.Text = value1.NombreProyecto;
                                txtPlaza.Text = value1.CodigoPlaza;
                                txtDescipcionPlaza.Text = value1.NombrePlaza;
                                txtSello1.Text = value1.Sello1;
                                txtSello2.Text = value1.Sello2;
                                txtSello3.Text = value1.Sello3;
                                txtSello4.Text = value1.Sello4;
                                txtSello5.Text = value1.Sello5;
                                txtSello6.Text = value1.Sello6;
                                txtPesoEnt.Text = value1.PesoEstado1.ToString("N0", CultureInfo.InvariantCulture);
                                txtPesoSalida.Text = value1.PesoEstado0.ToString("N0", CultureInfo.InvariantCulture);
                                txtTotalCargue.Text = (value1.PesoEstado1 - value1.PesoEstado0).ToString("N0", CultureInfo.InvariantCulture);
                                tolstripPeso.Text = value1.PesoVehiculo.ToString("N0", CultureInfo.InvariantCulture);
                                tolstripDefaul.Text = value1.CodigoPlazaDefault;
                                ptbFotoVehiculo.Image = DBMETAL_SHARP.Common.Common.ImageConvert.byteToImage(value1.Foto);

                                if (txtConcecutivo.Text == "0")

                                {
                                    btnplaca.Enabled = true;
                                    btnProyecto.Enabled = true;
                                    btnPlaza.Enabled = true;
                                    btnConduc.Enabled = true;
                                    TxtPlaca.Enabled = true;
                                    TxbConductor.Enabled = true;
                                    txtProyectoInfProyecto.Enabled = true;
                                    txtPlaza.Enabled = true;
                                    txtConcecutivo.Enabled = true;
                                    txtConcecutivo.Text = string.Empty;
                                    consecutiveReturn = string.Empty;
                                }
                                else
                                {
                                    btnplaca.Enabled = false;
                                    btnProyecto.Enabled = false;
                                    btnPlaza.Enabled = false;
                                    btnConduc.Enabled = false;
                                    TxtPlaca.Enabled = false;
                                    TxbConductor.Enabled = false;
                                    txtProyectoInfProyecto.Enabled = false;
                                    txtPlaza.Enabled = false;
                                    consecutiveReturn = string.Empty;
                                }
                            }
                        }
                    }
                    idConductor = String.Empty;
                }

            }
            else
            {
                Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "ConsePlanta", "", Convert.ToInt64(consecutiveReturn), "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    if (Reader != null && Reader.Count() > 0)
                    {
                        Ent_PesajeMineral value = Reader[0];
                        txtConcecutivo.Text = value.Consecutivo.ToString();
                        Placa = TxtPlaca.Text = value.PlacaVehiculo;
                        txtDescripciomPlaca.Text = value.DescripcionVehiculo;
                        TxbConductor.Text = value.CodigoConductor.ToString();
                        txtDescripcionCond.Text = value.NombreConductor;
                        txtProyectoInfProyecto.Text = value.CodigoProyecto;
                        txtDescripcionProyecto.Text = value.NombreProyecto;
                        txtPlaza.Text = value.CodigoPlaza;
                        txtDescipcionPlaza.Text = value.NombrePlaza;
                        txtSello1.Text = value.Sello1;
                        txtSello2.Text = value.Sello2;
                        txtSello3.Text = value.Sello3;
                        txtSello4.Text = value.Sello4;
                        txtSello5.Text = value.Sello5;
                        txtSello6.Text = value.Sello6;
                        txtPesoEnt.Text = value.PesoEstado1.ToString("N0", CultureInfo.InvariantCulture);
                        txtPesoSalida.Text = value.PesoEstado0.ToString("N0", CultureInfo.InvariantCulture);
                        txtTotalCargue.Text = (value.PesoEstado1 - value.PesoEstado0).ToString("N0", CultureInfo.InvariantCulture);
                        tolstripPeso.Text = value.PesoVehiculo.ToString("N0", CultureInfo.InvariantCulture);
                        tolstripDefaul.Text = value.CodigoPlazaDefault;
                        ptbFotoVehiculo.Image = DBMETAL_SHARP.Common.Common.ImageConvert.byteToImage(value.Foto);

                        btnplaca.Enabled = false;
                        btnProyecto.Enabled = false;
                        btnPlaza.Enabled = false;
                        btnConduc.Enabled = false;
                        TxtPlaca.Enabled = false;
                        TxbConductor.Enabled = false;
                        txtProyectoInfProyecto.Enabled = false;
                        txtPlaza.Enabled = false;
                        consecutiveReturn = string.Empty;

                        if (indicativoPlacaIncompleto)
                            btnCatidadPlaca.Visible = false;
                    }
                }
            }
        }


        #endregion

        private void TxbConductor_Leave(object sender, EventArgs e)
        {
            List<Ent_PesajeMineral> Reader = new List<Ent_PesajeMineral>();
            txtConcecutivo.BackColor = Color.White;

            if (!String.IsNullOrEmpty(this.TxbConductor.Text))
            {
                Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "ConductorEsUn", this.TxbConductor.Text, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    Ent_PesajeMineral value = Reader[0];

                    txtDescripcionCond.Text = value.NombreConductor;
                    //btnplaca.Enabled = false;
                }
            }
        }

        private void txtPlaza_Leave(object sender, EventArgs e)
        {
            List<Ent_PesajeMineral> Reader = new List<Ent_PesajeMineral>();
            txtConcecutivo.BackColor = Color.White;

            if (!String.IsNullOrEmpty(this.txtPlaza.Text))
            {



                Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "PlazasPes", this.txtPlaza.Text, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    Ent_PesajeMineral value = Reader[0];

                    txtDescipcionPlaza.Text = value.NombrePlaza;
                    //btnplaca.Enabled = false;
                }
            }

        }

        private void txtProyectoInfProyecto_Leave(object sender, EventArgs e)
        {
            List<Ent_PesajeMineral> Reader = new List<Ent_PesajeMineral>();
            txtConcecutivo.BackColor = Color.White;

            if (!String.IsNullOrEmpty(this.txtProyectoInfProyecto.Text))
            {
                Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "MinasEspePe", this.txtProyectoInfProyecto.Text, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    Ent_PesajeMineral value = Reader[0];

                    txtDescripcionProyecto.Text = value.NombreProyecto;
                    //btnplaca.Enabled = false;
                }
            }
        }

        private void btnCatidadPlaca_Click(object sender, EventArgs e)
        {

            Op = 6;
            Frm_Consultas Forma = null;
            if (!String.IsNullOrEmpty(placaTemporal))
                Forma = new Frm_Consultas(26, placaTemporal);
            else
                Forma = new Frm_Consultas(26, TxtPlaca.Text.Trim());

            Forma.Tipo = 3;

            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ((Control)sender).FindForm().Close();
        }

        private void ptbFotoVehiculo_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ptbFotoVehiculo_MouseHover(object sender, EventArgs e)
        {
            if (ptbFotoVehiculo.Image != null)
            {
                Form previewForm = new Form()
                {
                    WindowState = FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None
                };
                PictureBox picture = new PictureBox()
                {
                    Image = ptbFotoVehiculo.Image,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                picture.Click += pictureBox1_Click;
                previewForm.Controls.Add(picture);
                previewForm.ShowDialog();
            }
        }
    }
}

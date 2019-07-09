using DBMETAL_SHARP.Common;
using Entidades;
using ReglasdeNegocio;
using Reportes.LiquidacionDBMETAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_ControlCalidadMuestras : Form
    {
        #region Constructor
        public Frm_ControlCalidadMuestras()
        {
            InitializeComponent();
        }

        private void ValidatePermission(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    ValidatePermission(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    ShowToolStipItems(menuStrip.Items);
                }

                if (c is Button || c is ComboBox || c is TextBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage || c is TextBox || c is GroupBox)
                {

                    Roles_Permisos valueFilter = Permission.Where(e => e.fkcontrolid == c.Name).FirstOrDefault();

                    if (valueFilter != null)
                    {
                        if (valueFilter.Invisible > 0)
                        {
                            c.Visible = false;
                        }
                        else
                        {
                            c.Visible = true;
                        }

                        if (valueFilter.Disabled > 0)
                        {
                            c.Enabled = false;
                        }
                        else
                        {
                            c.Enabled = true;
                        }
                    }
                }
            }
        }

        private void ShowToolStipItems(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                mi.ToolTipText = mi.Name;

                if (mi.DropDownItems.Count > 0)
                {
                    ShowToolStipItems(mi.DropDownItems);
                }

                Roles_Permisos valueFilter = Permission.Where(e => e.fkcontrolid == mi.Name).FirstOrDefault();

                if (valueFilter != null)
                {
                    if (valueFilter.Invisible > 0)
                    {
                        mi.Visible = false;
                    }
                    else
                    {
                        mi.Visible = true;
                    }

                    if (valueFilter.Disabled > 0)
                    {
                        mi.Enabled = false;
                    }
                    else
                    {
                        mi.Enabled = true;
                    }
                }
            }
        }


        public Frm_ControlCalidadMuestras(string User)
        {
            InitializeComponent();
            this.Usuario = User.Trim();
            Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", User.ToString().Trim(), this.Name);
            this.Permission = Common.Common.Permissions;

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("co");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            lblMuestrasDuplicadasNumero.Visible = false;
            label12.Visible = false;
            try
            {
                dtpEvent.Value = DateTime.Now;
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
                throw;
            }
            loadHistory();

            this.Permission = DBMETAL_SHARP.Common.Common.Permissions;
            ValidatePermission(this.Controls);

        }
        #endregion

        #region Propiedades - Variables

        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }

        public bool isModificate = false;
        public int indexValue = -1;
        public bool valueModificate = false;
        private List<Ent_OrdenesMuestra> obtenerHistorial = null;
        public int Op { get; set; }
        public int type { get; set; }
        public List<Roles_Permisos> Permission;

        #endregion

        #region Metodos publicos
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.

        }
        #endregion

        #region Eventos
        private void Frm_MuestreoPM_Load(object sender, EventArgs e)
        {
            //btnNew.PerformClick();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);

        }

        private void loadHistory()
        {
            this.cbmLabo.DropDownStyle = ComboBoxStyle.DropDownList;
            var read = ConsultaEntidades.ObtenerHistorialSec("SpConsulta_Tablas", "ConsecutivoControlM", "", 0, string.Empty);
            obtenerHistorial = read.OrderByDescending(o => o.IdOrden).ToList();
            label15.Text = "--";

            label16.Text = "--";
            cbmLabo.SelectedIndex = 0;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                new MyProgressBar();
                this.label13.Visible = true;
                this.button1.Enabled = false;
                if (string.IsNullOrEmpty(this.IpLocal))
                {
                    this.IpLocal = DireccionIP.Local();
                }
                if (string.IsNullOrEmpty(this.IpPublica))
                {
                    this.IpPublica = DireccionIP.Publica();
                }
                if (string.IsNullOrEmpty(this.SerialHDD))
                {
                    this.SerialHDD = DireccionIP.SerialNumberDisk();
                }
                if (string.IsNullOrEmpty(this.Usuario))
                {
                    this.Usuario = DireccionIP.SerialNumberDisk();
                }
                if (!string.IsNullOrEmpty(this.cbmLabo.Text))
                {
                    GuardarDatos guardarDatos = new GuardarDatos();
                    int num = 0;
                    bool flag = false;
                    foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvCantidadMuestras.Rows)
                    {
                        if (Convert.ToBoolean(dataGridViewRow.Cells[0].Value))
                        {
                            flag = true;
                            string text = string.Empty;
                            if (dataGridViewRow.Cells[1].Value == null)
                            {
                                text = "(1)";
                            }
                            else
                            {
                                text = dataGridViewRow.Cells[1].Value.ToString();
                            }
                            int num2 = int.Parse(text.Substring(1, 1));
                            if (num2 != 1)
                            {
                                SqlParameter[] pparametros = GuardarDatos.Parametros_OrdenesDetalleMuestreoPM("", dataGridViewRow.Cells[3].Value.ToString().Trim(), "ORG", "", dataGridViewRow.Cells[3].Value.ToString().Trim(), int.Parse(dataGridViewRow.Cells[2].Value.ToString()), true, true, true, Convert.ToDateTime(this.dtpEvent.Text), this.dtpEvent.Value, 1);
                                guardarDatos.Numerico("Sp_Guardar_OrdenDetMuesPM", pparametros);
                                SqlParameter[] pparametros2 = GuardarDatos.Parametros_Update_MuestreoPM(int.Parse(dataGridViewRow.Cells[2].Value.ToString()), text);
                                guardarDatos.booleano("Sp_Moficiar_State_MuestreoPM", pparametros2);
                                LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se envia registros a la boratorio, con sello control " + dataGridViewRow.Cells[3].Value.ToString().Trim(), "Control de calidad");
                                string str = string.Empty;
                                for (int i = 1; i <= num2 - 1; i++)
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            str = "A";

                                            break;
                                        case 2:
                                            str = "B";

                                            break;
                                        case 3:
                                            str = "C";

                                            break;
                                        case 4:
                                            str = "D";

                                            break;
                                    }
                                    string text2 = dataGridViewRow.Cells[3].Value.ToString().Trim() + str;
                                    pparametros = GuardarDatos.Parametros_OrdenesDetalleMuestreoPM("", text2, string.Empty, string.Empty, dataGridViewRow.Cells[3].Value.ToString(), int.Parse(dataGridViewRow.Cells[2].Value.ToString()), true, true, true, Convert.ToDateTime(this.dtpEvent.Text), this.dtpEvent.Value, 1);
                                    num = guardarDatos.Numerico("Sp_Guardar_OrdenDetMuesPM", pparametros);
                                    LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se crean los duplicados de control " + text2, "Asignación Duplicados");
                                }
                            }
                            else
                            {
                                SqlParameter[] pparametros3 = GuardarDatos.Parametros_OrdenesDetalleMuestreoPM("", dataGridViewRow.Cells[3].Value.ToString().Trim(), "ORG", "", dataGridViewRow.Cells[3].Value.ToString().Trim(), int.Parse(dataGridViewRow.Cells[2].Value.ToString()), true, true, true, Convert.ToDateTime(this.dtpEvent.Text), this.dtpEvent.Value, 1);
                                num = guardarDatos.Numerico("Sp_Guardar_OrdenDetMuesPM", pparametros3);
                                SqlParameter[] pparametros4 = GuardarDatos.Parametros_Update_MuestreoPM(int.Parse(dataGridViewRow.Cells[2].Value.ToString()), "(1)");
                                guardarDatos.booleano("Sp_Moficiar_State_MuestreoPM", pparametros4);
                            }
                        }
                    }
                    if (!flag)
                    {
                        MessageBox.Show("Debe de seleccionar registros del muestro del día");
                    }
                    if (num > 0)
                    {
                        MessageBox.Show("Muestreo almacenado con Exito");
                        this.loadHistory();
                        this.ReloadDataGrid();
                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo Registro de detalle Muestreo para la orden " + 1.ToString().Trim(), "Movimiento Muestreo creado");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el laborario para clasificar la muestra");
                }
                this.button1.Enabled = true;
                this.label13.Visible = false;
            }
            catch (Exception ex)
            {
                this.button1.Enabled = true;
                MessageBox.Show("Error 3", ex.Message);
            }
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            try
            {
                List<Entidades.Ent_CalidadMuestro> Reader = new List<Entidades.Ent_CalidadMuestro>();

                DateTime dateValue = new DateTime(dtpEvent.Value.Year, dtpEvent.Value.Month, dtpEvent.Value.Day);

                string Operation = string.Empty;
                var Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", this.Usuario.ToString().Trim(), "Frm_MuestreoPM");

                Roles_Permisos permisoConsulta = Permissions.Where(s => s.fkcontrolid == "TxbPesaje").FirstOrDefault();

                if (permisoConsulta.ContenedorOtros > 0 && permisoConsulta.ContenedorPeqMineria > 0 && permisoConsulta.ContenedorZandor > 0)
                {
                    Operation = "CalidadMuestreoPMDia";
                }
                else
                    if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                {
                    Operation = "CalidadMOtrPMDia";
                }
                else
                {
                    Operation = "CalidadMZanPMDia";
                }

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");

                if (Reader != null && Reader.Count() > 0)
                {
                    label2.Visible = true;
                    lblCantidadMuestras.Visible = true;

                    lblCantidadMuestras.Text = Reader.Count().ToString();
                    Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

                    dgvCantidadMuestras.DataSource = Reader;
                    dgvCantidadMuestras.Visible = true;

                    dgvCantidadMuestras.Columns["cboDuplicado"].DefaultCellStyle.NullValue = "(1)";
                    dgvCantidadMuestras.Columns["cboDuplicado"].ReadOnly = false;
                    dgvCantidadMuestras.Columns[2].HeaderText = "Concecutivo Báscula";
                    dgvCantidadMuestras.Columns[3].HeaderText = "Sello Control";
                    dgvCantidadMuestras.Columns[4].HeaderText = "Nombre Proyecto";
                    dgvCantidadMuestras.Columns[2].ReadOnly = true;
                    dgvCantidadMuestras.Columns[3].ReadOnly = true;
                    dgvCantidadMuestras.Columns[4].ReadOnly = true;
                    dgvCantidadMuestras.Columns["Duplicado"].Visible = false;
                    dgvCantidadMuestras.Columns[7].Visible = false;
                    dgvCantidadMuestras.Columns[8].Visible = false;
                    dgvCantidadMuestras.Columns[9].Visible = false;
                    dgvCantidadMuestras.Columns[10].Visible = false;
                    dgvCantidadMuestras.Columns[11].Visible = false;
                    dgvCantidadMuestras.Columns["Hora"].Visible = false;
                    dgvCantidadMuestras.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                    dgvCantidadMuestras.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvCantidadMuestras.AutoResizeColumns();

                    Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 1, "0");

                    Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

                    dgvCantidadDeMuestrasEnElLaboratorio.DataSource = Reader;
                    lblCantidadMuestrasNumero.Visible = true;
                    label12.Visible = true;
                    lblCantidadMuestrasNumero.Text = Reader.Count().ToString();
                    dgvCantidadDeMuestrasEnElLaboratorio.Visible = true;
                    label15.Text = "--";
                    label16.Text = "--";
                    dgvCantidadDeMuestrasEnElLaboratorio.AutoResizeColumns();
                }

                if (permisoConsulta.ContenedorOtros > 0 && permisoConsulta.ContenedorPeqMineria > 0 && permisoConsulta.ContenedorZandor > 0)
                {
                    Operation = "CalidadMuestreoPMP";
                }
                else
                    if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                {
                    Operation = "CalidadMOtrPMP";
                }
                else
                {
                    Operation = "CalidadMZandorPMP";
                }

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    lblCantidadPendienteMuestrasNumero.Text = Reader.Count().ToString();
                    lblCantidadPendienteMuestras.Visible = true;
                    lblCantidadPendienteMuestrasNumero.Visible = true;
                    dgvCantidadPendientesMuestras.Visible = true;
                    lblCantidadPendienteMuestrasNumero.Text = Reader.Count().ToString();
                    Reader = Reader.OrderBy(r => r.Hora).OrderBy(t => t.NombreProyecto).ToList();
                    dgvCantidadPendientesMuestras.DataSource = Reader;

                    dgvCantidadPendientesMuestras.Columns[0].HeaderText = "Concecutivo Báscula";
                    dgvCantidadPendientesMuestras.Columns[1].HeaderText = "Sello Control";
                    dgvCantidadPendientesMuestras.Columns[2].HeaderText = "Nombre Proyecto";
                    dgvCantidadPendientesMuestras.Columns["Duplicado"].Visible = false;
                    dgvCantidadPendientesMuestras.Columns[5].Visible = false;
                    dgvCantidadPendientesMuestras.Columns[6].Visible = false;
                    dgvCantidadPendientesMuestras.Columns[7].Visible = false;
                    dgvCantidadPendientesMuestras.Columns[8].Visible = false;
                    dgvCantidadPendientesMuestras.Columns[9].Visible = false;
                    dgvCantidadPendientesMuestras.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                    dgvCantidadPendientesMuestras.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvCantidadPendientesMuestras.Columns.Remove("SelloControl");
                    dgvCantidadPendientesMuestras.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error2 :", ex.Message);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("co");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            this.dgvCantidadMuestras.DataSource = null;
            this.dgvCantidadPendientesMuestras.DataSource = null;
            this.cbmLabo.Enabled = true;
            this.cbmLabo.SelectedIndex = -1;
            this.loadHistory();
        }


        private void dtpEvent_ValueChanged(object sender, EventArgs e)
        {
            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            try
            {
                List<Entidades.Ent_CalidadMuestro> Reader = new List<Entidades.Ent_CalidadMuestro>();

                DateTime dateValue = new DateTime(dtpEvent.Value.Year, dtpEvent.Value.Month, dtpEvent.Value.Day);
                string Operation = string.Empty;

                var Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", this.Usuario.ToString().Trim(), "Frm_MuestreoPM");

                Roles_Permisos permisoConsulta = Permissions.Where(s => s.fkcontrolid == "TxbPesaje").FirstOrDefault();

                if (permisoConsulta.ContenedorOtros > 0 && permisoConsulta.ContenedorPeqMineria > 0 && permisoConsulta.ContenedorZandor > 0)
                {
                    Operation = "CalidadMuestreoPMDia";
                }
                else
                    if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                {
                    Operation = "CalidadOtrPMDia";
                }
                else
                {
                    Operation = "CalidadZanPMDia";
                }

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");

                Reader = LlenarGridDeCantidadDeMuestrasyEnLaboratorio(Reader);
                Reader = LlenarGridDeMuestrasPendientes(dateValue, ref Operation, permisoConsulta);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error1 :", ex.Message);
            }
        }

        private List<Ent_CalidadMuestro> LlenarGridDeMuestrasPendientes(DateTime dateValue, ref string Operation, Roles_Permisos permisoConsulta)
        {
            List<Ent_CalidadMuestro> Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 1, "0");
            Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

            dgvCantidadDeMuestrasEnElLaboratorio.DataSource = Reader;
            lblCantidadMuestrasNumero.Visible = true;
            label12.Visible = true;
            lblCantidadMuestrasNumero.Text = Reader.Count().ToString();
            txtBuscarSelloControl.Text = string.Empty;

            dgvCantidadDeMuestrasEnElLaboratorio.Columns[0].HeaderText = "Concecutivo Báscula";
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[1].HeaderText = "Sello Control";
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[2].HeaderText = "Nombre Proyecto";
            dgvCantidadDeMuestrasEnElLaboratorio.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
            dgvCantidadDeMuestrasEnElLaboratorio.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[5].Visible = false;
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[6].Visible = false;
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[7].Visible = false;
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[8].Visible = false;
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[9].Visible = false;
            dgvCantidadDeMuestrasEnElLaboratorio.Columns[11].Visible = false;
            dgvCantidadDeMuestrasEnElLaboratorio.Columns["Hora"].Visible = false;

            dgvCantidadDeMuestrasEnElLaboratorio.Visible = true;
            dgvCantidadDeMuestrasEnElLaboratorio.AutoResizeColumns();


            if (permisoConsulta.ContenedorOtros > 0 && permisoConsulta.ContenedorPeqMineria > 0 && permisoConsulta.ContenedorZandor > 0)
            {
                Operation = "CalidadMuestreoPMP";
            }
            else
                if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
            {
                Operation = "CalidadMOtrPMP";
            }
            else
            {
                Operation = "CalidadMZandorPMP";
            }

            Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");
            if (Reader != null && Reader.Count() > 0)
            {
                lblCantidadPendienteMuestrasNumero.Text = Reader.Count().ToString();
                lblCantidadPendienteMuestras.Visible = true;
                lblCantidadPendienteMuestrasNumero.Visible = true;
                dgvCantidadPendientesMuestras.Visible = true;
                lblCantidadPendienteMuestrasNumero.Text = Reader.Count().ToString();

                Reader = Reader.OrderBy(r => r.Hora).OrderBy(t => t.NombreProyecto).ToList();

                dgvCantidadPendientesMuestras.DataSource = Reader;
                dgvCantidadPendientesMuestras.Columns[0].HeaderText = "Concecutivo Báscula";
                dgvCantidadPendientesMuestras.Columns[1].HeaderText = "Sello Control";
                dgvCantidadPendientesMuestras.Columns[2].HeaderText = "Nombre Proyecto";
                dgvCantidadPendientesMuestras.Columns.Remove("SelloControl");
                dgvCantidadPendientesMuestras.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                dgvCantidadPendientesMuestras.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCantidadPendientesMuestras.Columns["Duplicado"].Visible = false;
                dgvCantidadPendientesMuestras.Columns[4].Visible = false;
                dgvCantidadPendientesMuestras.Columns[5].Visible = false;
                dgvCantidadPendientesMuestras.Columns[6].Visible = false;
                dgvCantidadPendientesMuestras.Columns[7].Visible = false;
                dgvCantidadPendientesMuestras.Columns[8].Visible = false;
                dgvCantidadPendientesMuestras.Columns[10].Visible = false;
                dgvCantidadPendientesMuestras.AutoResizeColumns();
            }
            else
            {
                dgvCantidadPendientesMuestras.DataSource = null;
                dgvCantidadPendientesMuestras.Rows.Clear();
            }

            label15.Text = "--";
            label16.Text = "--";
            return Reader;
        }

        private List<Ent_CalidadMuestro> LlenarGridDeCantidadDeMuestrasyEnLaboratorio(List<Ent_CalidadMuestro> Reader)
        {
            if (Reader != null && Reader.Count() > 0)
            {
                label2.Visible = true;
                lblCantidadMuestras.Visible = true;

                lblCantidadMuestras.Text = Reader.Count().ToString();
                Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

                dgvCantidadMuestras.DataSource = Reader;
                dgvCantidadMuestras.Visible = true;
                dgvCantidadMuestras.Columns[2].HeaderText = "Concecutivo Báscula";
                dgvCantidadMuestras.Columns[3].HeaderText = "Sello Control";
                dgvCantidadMuestras.Columns[4].HeaderText = "Nombre Proyecto";
                dgvCantidadMuestras.Columns[2].ReadOnly = true;
                dgvCantidadMuestras.Columns[3].ReadOnly = true;
                dgvCantidadMuestras.Columns[4].ReadOnly = true;
                dgvCantidadMuestras.Columns["Duplicado"].Visible = false;
                dgvCantidadMuestras.Columns[7].Visible = false;
                dgvCantidadMuestras.Columns[8].Visible = false;
                dgvCantidadMuestras.Columns[9].Visible = false;
                dgvCantidadMuestras.Columns[10].Visible = false;
                dgvCantidadMuestras.Columns[11].Visible = false;
                dgvCantidadMuestras.Columns[13].Visible = false;
                dgvCantidadMuestras.Columns["Hora"].Visible = false;
                dgvCantidadMuestras.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                dgvCantidadMuestras.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvCantidadMuestras.AutoResizeColumns();
            }
            else
            {
                this.dgvCantidadMuestras.DataSource = null;
                this.dgvCantidadMuestras.Columns["cboDuplicado"].ReadOnly = true;
                this.dgvCantidadMuestras.Rows.Clear();
            }

            return Reader;
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dataTable = new DataTable();
            foreach (PropertyDescriptor propertyDescriptor in properties)
            {
                dataTable.Columns.Add(propertyDescriptor.Name, Nullable.GetUnderlyingType(propertyDescriptor.PropertyType) ?? propertyDescriptor.PropertyType);
            }
            foreach (T current in data)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyDescriptor propertyDescriptor2 in properties)
                {
                    dataRow[propertyDescriptor2.Name] = (propertyDescriptor2.GetValue(current) ?? DBNull.Value);
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_CargaAnalisis cargarANalisis = new Frm_CargaAnalisis(this.Usuario);
            cargarANalisis.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Fill = 0;
            if (dgvCantidadDeMuestrasEnElLaboratorio.CurrentCell != null)
            {
                Fill = dgvCantidadDeMuestrasEnElLaboratorio.CurrentCell.RowIndex;
                string value = dgvCantidadDeMuestrasEnElLaboratorio[0, Fill].Value.ToString().Trim();
                List<Entidades.Ent_CalidadMuestro> Reader = new List<Entidades.Ent_CalidadMuestro>();
                label15.Text = "--";
                label16.Text = "--";

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", "LLenarTreePM", value, 0, "0");

                if (Reader != null && Reader.Count() > 0)
                {
                    Reader = Reader.OrderBy(r => r.SelloControl).ToList();
                    Reader = Reader.OrderBy(r => r.AUFA).ToList();
                    Reader = Reader.OrderBy(r => r.AAQAQC).ToList();

                    lblMuestrasDuplicadasNumero.Visible = true;
                    label8.Visible = true;
                    lblMuestrasDuplicadasNumero.Text = Reader.Count().ToString();
                    dgvMuestrasDuplicadas.DataSource = Reader;
                    dgvMuestrasDuplicadas.Columns["Duplicado"].Visible = false;

                    dgvMuestrasDuplicadas.Columns[13].DisplayIndex = 0;
                    dgvMuestrasDuplicadas.Columns[13].HeaderText = "QAQC";
                    dgvMuestrasDuplicadas.Columns[3].HeaderText = "Sello Control";
                    dgvMuestrasDuplicadas.Columns[0].ReadOnly = false;
                    dgvMuestrasDuplicadas.Columns[1].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[2].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[3].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[4].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[5].ReadOnly = true;

                    dgvMuestrasDuplicadas.Columns[6].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[7].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[8].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[9].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[10].ReadOnly = true;

                    dgvMuestrasDuplicadas.Columns[1].Visible = false;
                    dgvMuestrasDuplicadas.Columns[2].Visible = false;
                    dgvMuestrasDuplicadas.Columns[4].Visible = false;
                    dgvMuestrasDuplicadas.Columns[5].Visible = false;

                    dgvMuestrasDuplicadas.Columns["Hora"].Visible = false;

                    dgvMuestrasDuplicadas.Visible = true;

                    string valueMedia = string.Empty;
                    foreach (DataGridViewRow row in dgvMuestrasDuplicadas.Rows)
                    {
                        decimal value1 = 0;
                        if (row.Cells[8].Value != null)
                        {
                            if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                            {
                                row.Cells[0].Value = value1;
                            }
                            else
                            {
                                if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                {
                                    row.Cells[0].Value = value1;
                                }
                                else
                                {
                                    row.Cells[0].Value = string.Empty;
                                }
                            }
                        }

                        if (Convert.ToBoolean(row.Cells[13].Value))
                        {
                            if (value1 > 0)
                            {
                                if (string.IsNullOrEmpty(valueMedia))
                                {
                                    valueMedia = string.Concat(value1, ";");
                                }
                                else
                                {
                                    valueMedia = string.Concat(valueMedia, value1, ";");
                                }
                            }
                        }

                        if (!Convert.ToBoolean(row.Cells[13].Value))
                        {
                            row.DefaultCellStyle.BackColor = Color.Gray;
                            row.ReadOnly = true;
                            DataGridViewCheckBoxCell dataGridViewCheckBoxCell = row.Cells[13] as DataGridViewCheckBoxCell;
                            DataGridViewCheckBoxCell dataGridViewCheckBoxCell2 = dataGridViewCheckBoxCell;
                            dataGridViewCheckBoxCell2.Value = false;
                            dataGridViewCheckBoxCell.ReadOnly = false;
                        }
                    }
                    string[] arrar = valueMedia.TrimEnd(';').Split(';');

                    decimal[] arra1 = new decimal[arrar.Length];
                    for (int i = 0; i < arrar.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(arrar[i]))
                        {
                            arra1[i] = Convert.ToDecimal(arrar[i]);
                        }
                        else
                        {
                            arra1[i] = Convert.ToDecimal(0);
                        }
                    }

                    var val0 = Median(arra1);
                    var val = GetMedian(arra1, true);
                    GetMedian(arra1, true);
                    label15.Text = val0.ToString();

                    double value2 = DesviacionStandard(arra1);
                    decimal value3 = 0;

                    if (decimal.TryParse(value2.ToString(), out value3))
                    {
                        if (value3 != 0)
                        {
                            if (Convert.ToDecimal(String.Format("{0:#.##}", value3)) < 1)
                            {
                                label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                            }
                            else
                            {
                                label16.Text = String.Format("{0:#.##}", value2);
                            }
                        }
                        else
                        {
                            label16.Text = String.Format("{0:#.##}", value2);
                        }
                    }
                    else
                    {
                        label16.Text = "NA";
                    }
                }
                else
                {
                    lblMuestrasDuplicadasNumero.Visible = false;
                    label8.Visible = false;
                    dgvMuestrasDuplicadas.Visible = false;
                }
            }
        }

        /// <resumen>
        /// Obtiene el valor mediano de una matriz
        /// </ summary>
        /// <typeparam name = "T"> El tipo de matriz </ typeparam>
        /// <param name = "sourceArray"> La matriz fuente </ param>
        /// <param name = "cloneArray"> Si no importa si la matriz fuente está ordenada, puede pasar false para mejorar el rendimiento </ param>
        /// <returns> </ returns>
        public static object GetMedian<T>(T[] sourceArray, bool cloneArray = true) where T : IComparable<T>
        {
            //Framework 2.0 version of this method. there is an easier way in F4        
            if (sourceArray == null || sourceArray.Length == 0)
            {
                throw new ArgumentException("Median of empty array not defined.");
            }

            //make sure the list is sorted, but use a new array
            T[] sortedArray = cloneArray ? (T[])sourceArray.Clone() : sortedArray = sourceArray;
            Array.Sort(sortedArray);

            //get the median
            int size = sortedArray.Length;
            int mid = size / 2;
            if (size % 2 != 0)
            {
                return sortedArray[mid];
            }

            dynamic value1 = sortedArray[mid];
            dynamic value2 = sortedArray[mid - 1];
            var side = (double)Convert.ToDouble(sortedArray[mid] + value1) * 0.5;
            return side;
        }

        private decimal Median(decimal[] xs)
        {
            var ys = xs.OrderBy(x => x).ToList();
            double mid = (ys.Count - 1) / 2.0;
            return Decimal.Round((ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2, 2);
        }

        private double DesviacionStandard(decimal[] listaDatos)
        {
            double desvStd = 0;
            double N = 0, prom = 0, suma = 0, NrestadoUno = 0, sumapotencias = 0;
            N = listaDatos.Length;
            NrestadoUno = N - 1;
            foreach (double dato in listaDatos)
            {
                suma += dato;
            }
            prom = suma / N;
            foreach (double dato in listaDatos)
            {
                sumapotencias += Math.Pow((dato - prom), 2);
            }
            desvStd = Math.Sqrt((1 * sumapotencias) / NrestadoUno);
            return desvStd;
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                string valueMedia = string.Empty;

                int indexCurrent = -1;
                foreach (DataGridViewRow row in dgvMuestrasDuplicadas.Rows)
                {
                    indexCurrent++;

                    decimal value1 = 0;
                    if (row.Cells[8].Value != null)
                    {
                        if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                        {
                            row.Cells[0].Value = value1;
                        }
                        else
                        {
                            if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                            {
                                row.Cells[0].Value = value1;
                            }
                            else
                            {
                                row.Cells[0].Value = string.Empty;
                            }
                        }
                    }

                    if (Convert.ToBoolean(dgvMuestrasDuplicadas.Rows[e.RowIndex].Cells[13].Value))
                    {
                        valueModificate = false;
                    }
                    else
                    {
                        valueModificate = true;
                    }

                    if (e.RowIndex == indexCurrent)
                    {
                        row.Cells[13].Value = valueModificate;
                        isModificate = false;
                        indexValue = -1;
                    }

                    if (Convert.ToBoolean(row.Cells[13].Value))
                    {
                        if (value1 > 0)
                        {
                            if (string.IsNullOrEmpty(valueMedia))
                            {
                                valueMedia = string.Concat(value1, ";");
                            }
                            else
                            {
                                valueMedia = string.Concat(valueMedia, value1, ";");
                            }
                        }
                    }
                }
                string[] arrar = valueMedia.TrimEnd(';').Split(';');

                //string[] arrar = valueMedia.Replace(',', '.').TrimEnd(';').Split(';');
                decimal[] arra1 = new decimal[arrar.Length];// { 23.3M, 34.9M, 56.9M, 34.09M };
                for (int i = 0; i < arrar.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arrar[i]))
                    {
                        arra1[i] = Convert.ToDecimal(arrar[i]);
                    }
                    else
                    {
                        arra1[i] = Convert.ToDecimal(0);
                    }
                }

                var val0 = Median(arra1);
                var val = GetMedian(arra1, true);
                label15.Text = val0.ToString();

                double value2 = DesviacionStandard(arra1);
                decimal value3 = 0;

                if (decimal.TryParse(value2.ToString(), out value3))
                {
                    if (value3 != 0)
                    {

                        if (Convert.ToDecimal(String.Format("{0:#.##}", value3)) < 1)
                        {
                            label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                        }
                        else
                        {
                            label16.Text = String.Format("{0:#.##}", value2);
                        }
                    }
                    else
                    {
                        label16.Text = String.Format("{0:#.##}", value2);
                    }
                }
                else
                {
                    label16.Text = "NA";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                label13.Visible = true;
                button3.Enabled = false;
                if (string.IsNullOrEmpty(this.IpLocal))
                {
                    this.IpLocal = DireccionIP.Local();
                }

                if (string.IsNullOrEmpty(this.IpPublica))
                {
                    this.IpPublica = DireccionIP.Publica();
                }

                if (string.IsNullOrEmpty(this.SerialHDD))
                {
                    this.SerialHDD = DireccionIP.SerialNumberDisk();
                }

                if (string.IsNullOrEmpty(this.Usuario))
                {
                    this.Usuario = DireccionIP.SerialNumberDisk();
                }

                GuardarDatos Guardar = new GuardarDatos();


                foreach (DataGridViewRow row in dgvMuestrasDuplicadas.Rows)
                {
                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_Update_QAQCPM(Convert.ToBoolean(row.Cells[13].Value), Convert.ToInt32(row.Cells[2].Value), row.Cells[3].Value.ToString().Trim(), Convert.ToBoolean(row.Cells[14].Value));
                    Guardar.Numerico("Sp_Moficiar_QAQC_MuestreoPM", ParamSQl);
                }
                button3.Enabled = true; label13.Visible = false;
            }
            catch (Exception ex)
            {
                button3.Enabled = true;
                MessageBox.Show("Error 3", ex.Message);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvMuestrasDuplicadas.Rows.Count > 0 && dgvMuestrasDuplicadas.Rows.Count < 4)
            {
                List<Ent_CalidadMuestro> dt = dgvMuestrasDuplicadas.DataSource as List<Ent_CalidadMuestro>;
                dgvMuestrasDuplicadas.DataSource = null;
                Ent_CalidadMuestro insertRegister = new Ent_CalidadMuestro();

                Entidades.Ent_Fecha Reader = new Entidades.Ent_Fecha();

                dt = dt.OrderBy(s => s.SelloControl).ToList();

                for (int i = dt.Count - 1; i < dt.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            insertRegister.SelloControl = string.Concat(dt[0].SelloControl.Trim(), "A");
                            break;
                        case 1:
                            insertRegister.SelloControl = string.Concat(dt[0].SelloControl.Trim(), "B");
                            break;
                        case 2:
                            insertRegister.SelloControl = string.Concat(dt[0].SelloControl.Trim(), "C");
                            break;
                        default:
                            break;
                    }
                    Reader = ConsultaEntidades.ObtenerFechas("SpConsulta_Tablas", "recuprarFecha", dt[i].ConsecutivoBascula, 0, "0");

                    insertRegister.Duplicado = dt[0].SelloControl.Trim();
                    insertRegister.ConsecutivoBascula = dt[i].ConsecutivoBascula;
                    insertRegister.AAQAQC = true;
                }
                GuardarDatos Guardar = new GuardarDatos();
                dt.Add(insertRegister);
                SqlParameter[] ParamSQl = GuardarDatos.Parametros_OrdenesDetalleMuestreoPM
                ("", insertRegister.SelloControl, "", "", insertRegister.Duplicado, insertRegister.ConsecutivoBascula, true, true, true, Reader.FechaProduccion, Reader.FechaRegistro, 1);

                Guardar.Numerico("Sp_Guardar_OrdenDetMuesPM", ParamSQl);
                if (dt != null)
                {
                    dgvMuestrasDuplicadas.DataSource = dt;
                    dgvMuestrasDuplicadas.Columns["Duplicado"].Visible = false;
                    dgvMuestrasDuplicadas.Columns[13].DisplayIndex = 0;
                    dgvMuestrasDuplicadas.Columns[13].HeaderText = "QAQC";
                    dgvMuestrasDuplicadas.Columns[3].HeaderText = "Sello Control";
                    dgvMuestrasDuplicadas.Columns[0].ReadOnly = false;
                    dgvMuestrasDuplicadas.Columns[1].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[2].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[3].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[4].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[5].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[6].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[7].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[8].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[9].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[10].ReadOnly = true;
                    dgvMuestrasDuplicadas.Columns[1].Visible = false;
                    dgvMuestrasDuplicadas.Columns[2].Visible = false;
                    dgvMuestrasDuplicadas.Columns[4].Visible = false;
                    dgvMuestrasDuplicadas.Columns[5].Visible = false;
                    dgvMuestrasDuplicadas.Columns["Hora"].Visible = false;
                    dgvMuestrasDuplicadas.Visible = true;

                    string valueMedia = string.Empty;
                    foreach (DataGridViewRow row in dgvMuestrasDuplicadas.Rows)
                    {
                        decimal value1 = 0;
                        if (row.Cells[8].Value != null)
                        {
                            if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                            {
                                row.Cells[0].Value = value1;
                            }
                            else
                            {
                                if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                {
                                    row.Cells[0].Value = value1;
                                }
                                else
                                {
                                    row.Cells[0].Value = string.Empty;
                                }
                            }
                        }

                        if (Convert.ToBoolean(row.Cells[13].Value))
                        {
                            if (value1 > 0)
                            {
                                if (string.IsNullOrEmpty(valueMedia))
                                {
                                    valueMedia = string.Concat(value1, ";");
                                }
                                else
                                {
                                    valueMedia = string.Concat(valueMedia, value1, ";");
                                }
                            }
                        }
                    }
                    string[] arrar = valueMedia.TrimEnd(';').Split(';');

                    decimal[] arra1 = new decimal[arrar.Length];
                    for (int i = 0; i < arrar.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(arrar[i]))
                        {
                            arra1[i] = Convert.ToDecimal(arrar[i]);
                        }
                        else
                        {
                            arra1[i] = Convert.ToDecimal(0);
                        }
                    }
                    var val0 = Median(arra1);
                    var val = GetMedian(arra1, true);
                    label15.Text = val0.ToString();

                    double value2 = DesviacionStandard(arra1);
                    decimal value3 = 0;

                    if (decimal.TryParse(value2.ToString(), out value3))
                    {
                        if (Convert.ToDecimal(String.Format("{0:#.##}", value2)) < 1)
                        {
                            label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                        }
                        else
                        {
                            label16.Text = String.Format("{0:#.##}", value2);
                        }
                    }
                    else
                    {
                        label16.Text = "NA";
                    }
                }
            }
            else
            {
                MessageBox.Show("No es posible realizar mas de 3 duplicados por muestras");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvMuestrasDuplicadas.Rows.Count != 1)
            {
                List<Ent_CalidadMuestro> dt = dgvMuestrasDuplicadas.DataSource as List<Ent_CalidadMuestro>;

                Ent_CalidadMuestro insertRegister = new Ent_CalidadMuestro();

                Entidades.Ent_Fecha Reader = new Entidades.Ent_Fecha();

                for (int i = dt.Count - 1; i < dt.Count; i++)
                {
                    Reader = ConsultaEntidades.ObtenerFechas("SpConsulta_Tablas", "recuprarFecha", dt[i].ConsecutivoBascula, 0, "0");
                    insertRegister.AUFA = dt[i].AUFA;
                    insertRegister.SelloControl = dt[i].SelloControl;
                }

                if (String.IsNullOrEmpty(insertRegister.AUFA.ToString()))
                {
                    System.DateTime datoRegistro = System.DateTime.Now.AddHours(-4); //Reader.FechaRegistro;
                    System.DateTime datoActual = System.DateTime.Now;
                    System.TimeSpan diferencia = datoActual.Subtract(datoRegistro);

                    if (diferencia.TotalHours < 12)
                    {
                        GuardarDatos Guardar = new GuardarDatos();
                        SqlParameter[] ParamSQl = GuardarDatos.Parametros_BorrarMuestreoPM(insertRegister.SelloControl);
                        Guardar.Numerico("Sp_Eliminar_Control_MuestreoPM", ParamSQl);
                        dgvMuestrasDuplicadas.DataSource = null;
                        dt.RemoveAt(dt.Count - 1);

                        // dt.Select(er => er.SelloControl == insertRegister.SelloControl);

                        if (dt != null)
                        {
                            dgvMuestrasDuplicadas.DataSource = dt;
                            dgvMuestrasDuplicadas.Columns["Duplicado"].Visible = false;
                            dgvMuestrasDuplicadas.Columns[13].DisplayIndex = 0;
                            dgvMuestrasDuplicadas.Columns[13].HeaderText = "QAQC";
                            dgvMuestrasDuplicadas.Columns[3].HeaderText = "Sello Control";
                            dgvMuestrasDuplicadas.Columns[0].ReadOnly = false;
                            dgvMuestrasDuplicadas.Columns[1].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[2].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[3].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[4].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[5].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[6].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[7].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[8].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[9].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[10].ReadOnly = true;
                            dgvMuestrasDuplicadas.Columns[1].Visible = false;
                            dgvMuestrasDuplicadas.Columns[2].Visible = false;
                            dgvMuestrasDuplicadas.Columns[4].Visible = false;
                            dgvMuestrasDuplicadas.Columns[5].Visible = false;
                            dgvMuestrasDuplicadas.Columns["Hora"].Visible = false;
                            dgvMuestrasDuplicadas.Visible = true;

                            string valueMedia = string.Empty;
                            foreach (DataGridViewRow row in dgvMuestrasDuplicadas.Rows)
                            {
                                decimal value1 = 0;
                                if (row.Cells[8].Value != null)
                                {
                                    if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                                    {
                                        row.Cells[0].Value = value1;
                                    }
                                    else
                                    {
                                        if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                        {
                                            row.Cells[0].Value = value1;
                                        }
                                        else
                                        {
                                            row.Cells[0].Value = string.Empty;
                                        }
                                    }
                                }

                                if (Convert.ToBoolean(row.Cells[13].Value))
                                {
                                    if (value1 > 0)
                                    {
                                        if (string.IsNullOrEmpty(valueMedia))
                                        {
                                            valueMedia = string.Concat(value1, ";");
                                        }
                                        else
                                        {
                                            valueMedia = string.Concat(valueMedia, value1, ";");
                                        }
                                    }
                                }
                            }
                            string[] arrar = valueMedia.TrimEnd(';').Split(';');

                            decimal[] arra1 = new decimal[arrar.Length];
                            for (int i = 0; i < arrar.Length; i++)
                            {
                                if (!String.IsNullOrEmpty(arrar[i]))
                                {
                                    arra1[i] = Convert.ToDecimal(arrar[i]);
                                }
                                else
                                {
                                    arra1[i] = Convert.ToDecimal(0);
                                }
                            }
                            var val0 = Median(arra1);
                            var val = GetMedian(arra1, true);
                            label15.Text = val0.ToString();

                            double value2 = DesviacionStandard(arra1);
                            decimal value3 = 0;

                            if (decimal.TryParse(value2.ToString(), out value3))
                            {
                                if (Convert.ToDecimal(String.Format("{0:#.##}", value2)) < 1)
                                {
                                    label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                                }
                                else
                                {
                                    label16.Text = String.Format("{0:#.##}", value2);
                                }
                            }
                            else
                            {
                                label16.Text = "NA";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El registro ya tiene mas de 12 horas a aver sido procesado");
                    }
                }
                else
                {
                    MessageBox.Show("El registro no puede ser eliminado por que posee AU final");
                }
            }
            else
            {
                MessageBox.Show("El registro original no puede ser eliminado");
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Liquidacion frmReporte = new Frm_Reporte_Liquidacion();
            object[] argument = new object[] { 3, dtpEvent.Value, true };

            frmReporte.EjecucionReportes(argument);
            frmReporte.Show();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscarSelloControl.Text.Trim()))
            {

                if (dgvCantidadDeMuestrasEnElLaboratorio.Rows.Count > 0)
                {
                    button2.Enabled = false;

                    List<Ent_CalidadMuestro> dt = dgvCantidadDeMuestrasEnElLaboratorio.DataSource as List<Ent_CalidadMuestro>;
                    //SqlParameter[] ParamSQl = GuardarDatos.Parametros_ToneladaSeca();
                    //Guardar.Numerico("Sp_Eliminar_Control_MuestreoPM", ParamSQl);
                    //[Sp_Modificar_QA]
                    int consec = 0;
                    foreach (DataGridViewRow row in dgvCantidadDeMuestrasEnElLaboratorio.Rows)
                    {
                        consec = Convert.ToInt32(row.Cells["ConsecutivoBascula"].Value);

                        GuardarDatos Guardar = new GuardarDatos();
                        SqlParameter[] ParamSQl = GuardarDatos.Parametros_ActQAQC(consec);
                        Guardar.Numerico("Sp_Modificar_QA", ParamSQl);

                        ParamSQl = GuardarDatos.Parametros_ActQAQC(consec);
                        Guardar.Numerico("Sp_Insertar_Dt_QA", ParamSQl);
                    }
                    var Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", "LLenarTreePM", consec, 0, "0");

                    if (Reader != null && Reader.Count() > 0)
                    {
                        Reader = Reader.OrderBy(r => r.SelloControl).ToList();

                        Reader = Reader.OrderBy(r => r.AUFA).ToList();


                        Reader = Reader.OrderBy(r => r.AAQAQC).ToList();

                        lblMuestrasDuplicadasNumero.Visible = true;
                        label8.Visible = true;
                        lblMuestrasDuplicadasNumero.Text = Reader.Count().ToString();
                        dgvMuestrasDuplicadas.DataSource = Reader;
                        dgvMuestrasDuplicadas.Columns["Duplicado"].Visible = false;

                        dgvMuestrasDuplicadas.Columns[13].DisplayIndex = 0;
                        dgvMuestrasDuplicadas.Columns[13].HeaderText = "QAQC";
                        dgvMuestrasDuplicadas.Columns[3].HeaderText = "Sello Control";
                        dgvMuestrasDuplicadas.Columns[0].ReadOnly = false;
                        dgvMuestrasDuplicadas.Columns[1].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[2].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[3].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[4].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[5].ReadOnly = true;

                        dgvMuestrasDuplicadas.Columns[6].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[7].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[8].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[9].ReadOnly = true;
                        dgvMuestrasDuplicadas.Columns[10].ReadOnly = true;

                        dgvMuestrasDuplicadas.Columns[1].Visible = false;
                        dgvMuestrasDuplicadas.Columns[2].Visible = false;
                        dgvMuestrasDuplicadas.Columns[4].Visible = false;
                        dgvMuestrasDuplicadas.Columns[5].Visible = false;

                        dgvMuestrasDuplicadas.Columns["Hora"].Visible = false;

                        dgvMuestrasDuplicadas.Visible = true;

                        string valueMedia = string.Empty;
                        foreach (DataGridViewRow row in dgvMuestrasDuplicadas.Rows)
                        {
                            decimal value1 = 0;
                            if (row.Cells[8].Value != null)
                            {
                                if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                                {
                                    row.Cells[0].Value = value1;
                                }
                                else
                                {
                                    if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                    {
                                        row.Cells[0].Value = value1;
                                    }
                                    else
                                    {
                                        row.Cells[0].Value = string.Empty;
                                    }
                                }
                            }

                            if (Convert.ToBoolean(row.Cells[13].Value))
                            {
                                if (value1 > 0)
                                {
                                    if (string.IsNullOrEmpty(valueMedia))
                                    {
                                        valueMedia = string.Concat(value1, ";");
                                    }
                                    else
                                    {
                                        valueMedia = string.Concat(valueMedia, value1, ";");
                                    }
                                }
                            }
                        }
                        string[] arrar = valueMedia.TrimEnd(';').Split(';');

                        decimal[] arra1 = new decimal[arrar.Length];
                        for (int i = 0; i < arrar.Length; i++)
                        {
                            if (!String.IsNullOrEmpty(arrar[i]))
                            {
                                arra1[i] = Convert.ToDecimal(arrar[i]);
                            }
                            else
                            {
                                arra1[i] = Convert.ToDecimal(0);
                            }
                        }

                        var val0 = Median(arra1);
                        var val = GetMedian(arra1, true);
                        label15.Text = val0.ToString();

                        double value2 = DesviacionStandard(arra1);
                        decimal value3 = 0;

                        if (decimal.TryParse(value2.ToString(), out value3))
                        {
                            if (value3 != 0)
                            {
                                if (Convert.ToDecimal(String.Format("{0:#.##}", value3)) < 1)
                                {
                                    label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                                }
                                else
                                {
                                    label16.Text = String.Format("{0:#.##}", value2);
                                }
                            }
                            else
                            {
                                label16.Text = String.Format("{0:#.##}", value2);
                            }
                        }
                        else
                        {
                            label16.Text = "NA";
                        }
                    }
                    else
                    {
                        lblMuestrasDuplicadasNumero.Visible = false;
                        label8.Visible = false;
                        dgvMuestrasDuplicadas.Visible = false;
                    }
                    button2.Enabled = true;
                }
            }
        }

        private void dataGridView4_BindingContextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMuestrasDuplicadas.Rows)
            {
                int kia = row.Index;
                if (Convert.ToBoolean(row.Cells["AAQAQC"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;

                }
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscarSelloControl.Text.Trim()))
            {
                List<Ent_CalidadMuestro> dt = dgvCantidadDeMuestrasEnElLaboratorio.DataSource as List<Ent_CalidadMuestro>;

                if (dt.Count > 0)
                {
                    string valConvert = txtBuscarSelloControl.Text.Replace("\r\n", "-").Replace("\n", "-").Replace("\r", "-");

                    string[] valueFilter = valConvert.Split('-');
                    List<Ent_CalidadMuestro> valueGeneric = new List<Ent_CalidadMuestro>();
                    Ent_CalidadMuestro valueInd = new Ent_CalidadMuestro();
                    foreach (var item in valueFilter)
                    {
                        valueInd = dt.Where(s => s.SelloControl.Contains(item.ToString().Trim())).FirstOrDefault();

                        if (valueInd != null)
                        {
                            valueGeneric.Add(valueInd);
                        }
                    }
                    //List<Ent_CalidadMuestro>  value = dt.Where(s => s.SelloControl.Contains(textBox1.Text.Trim())).ToList();
                    //if (value != null)
                    if (valueGeneric != null)
                    {
                        dgvCantidadDeMuestrasEnElLaboratorio.DataSource = valueGeneric;

                        lblCantidadMuestrasNumero.Visible = true;
                        label12.Visible = true;
                        lblCantidadMuestrasNumero.Text = valueGeneric.Count().ToString();
                        dgvCantidadDeMuestrasEnElLaboratorio.Visible = true;
                        label15.Text = "--";
                        label16.Text = "--";
                        dgvCantidadDeMuestrasEnElLaboratorio.AutoResizeColumns();
                    }
                }

                else
                { ReloadDataGrid(); }
            }
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtBuscarSelloControl.Text = string.Empty;
            ReloadDataGrid();
        }
    }

    #endregion
}


using DBMETAL_SHARP.Common;
using Entidades;
using ReglasdeNegocio;
using Reportes.LiquidacionDBMETAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                            c.Visible = false;
                        else
                            c.Visible = true;

                        if (valueFilter.Disabled > 0)
                            c.Enabled = false;
                        else
                            c.Enabled = true;
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
                        mi.Visible = false;
                    else
                        mi.Visible = true;

                    if (valueFilter.Disabled > 0)
                        mi.Enabled = false;
                    else
                        mi.Enabled = true;
                }
            }
        }


        public Frm_ControlCalidadMuestras(string User)
        {
            InitializeComponent();
            this.Usuario = User.Trim();

            DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", User.ToString().Trim(), this.Name);

            this.Permission = DBMETAL_SHARP.Common.Common.Permissions;

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("co");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
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
        List<Ent_OrdenesMuestra> obtenerHistorial = null;
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
                MyProgressBar progress = new MyProgressBar();
                label13.Visible = true;

                button1.Enabled = false;
                if (string.IsNullOrEmpty(this.IpLocal))
                    this.IpLocal = DireccionIP.Local();

                if (string.IsNullOrEmpty(this.IpPublica))
                    this.IpPublica = DireccionIP.Publica();

                if (string.IsNullOrEmpty(this.SerialHDD))
                    this.SerialHDD = DireccionIP.SerialNumberDisk();

                if (string.IsNullOrEmpty(this.Usuario))
                    this.Usuario = DireccionIP.SerialNumberDisk();

                if (!string.IsNullOrEmpty(cbmLabo.Text))
                {
                    GuardarDatos Guardar = new GuardarDatos();
                    int valueSabe = 0;
                    bool required = false;
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            required = true;

                            string value = string.Empty;
                            if (row.Cells[1].Value == null)
                                value = "(1)";
                            else
                                value = row.Cells[1].Value.ToString();

                            int character = int.Parse(value.Substring(1, 1));

                            if (character != 1)
                            {

                                SqlParameter[] ParamSQl = GuardarDatos.Parametros_OrdenesDetalleMuestreoPM("", row.Cells[3].Value.ToString().Trim(), "ORG", "", row.Cells[3].Value.ToString().Trim(), int.Parse(row.Cells[2].Value.ToString()), true, true, true, Convert.ToDateTime(dtpEvent.Text), dtpEvent.Value, 1);

                                Guardar.Numerico("Sp_Guardar_OrdenDetMuesPM", ParamSQl);

                                SqlParameter[] ParamSQluPDATE = GuardarDatos.Parametros_Update_MuestreoPM(int.Parse(row.Cells[2].Value.ToString()), value);

                                Guardar.booleano("Sp_Moficiar_State_MuestreoPM", ParamSQluPDATE);

                                LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se envia registros a la boratorio, con sello control " + row.Cells[3].Value.ToString().Trim(), "Control de calidad");


                                string index = string.Empty;
                                for (int i = 1; i <= character - 1; i++)
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            index = "A";
                                            break;
                                        case 2:
                                            index = "B";
                                            break;
                                        case 3:
                                            index = "C";
                                            break;
                                        case 4:
                                            index = "D";
                                            break;

                                        default:
                                            break;
                                    }
                                    string concatValue = string.Concat(row.Cells[3].Value.ToString().Trim(), index);

                                    ParamSQl = GuardarDatos.Parametros_OrdenesDetalleMuestreoPM("", concatValue, string.Empty, string.Empty, row.Cells[3].Value.ToString(), int.Parse(row.Cells[2].Value.ToString()), true, true, true, Convert.ToDateTime(dtpEvent.Text), dtpEvent.Value, 1);

                                    valueSabe = Guardar.Numerico("Sp_Guardar_OrdenDetMuesPM", ParamSQl);

                                    LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se crean los duplicados de control " + concatValue, "Asignación Duplicados");

                                }
                            }
                            else
                            {
                                SqlParameter[] ParamSQl = GuardarDatos.Parametros_OrdenesDetalleMuestreoPM("", row.Cells[3].Value.ToString().Trim(), "ORG", "", row.Cells[3].Value.ToString().Trim(), int.Parse(row.Cells[2].Value.ToString()), true, true, true, Convert.ToDateTime(dtpEvent.Text), dtpEvent.Value, 1);

                                valueSabe = Guardar.Numerico("Sp_Guardar_OrdenDetMuesPM", ParamSQl);

                                SqlParameter[] ParamSQluPDATE = GuardarDatos.Parametros_Update_MuestreoPM(int.Parse(row.Cells[2].Value.ToString()), "(1)");

                                Guardar.booleano("Sp_Moficiar_State_MuestreoPM", ParamSQluPDATE);

                            }
                        }
                    }
                    if (!required)
                        MessageBox.Show("Debe de seleccionar registros del muestro del día");

                    if (valueSabe > 0)
                    {
                        MessageBox.Show("Muestreo almacenado con Exito");
                        loadHistory();
                        ReloadDataGrid();
                        //if (dataGridView2.RowCount == 0 & dataGridView3.RowCount == 0)
                        //{
                        //    label18.Text = "Muestreo completo";

                        //    this.pictureBox1.Image = global::DBMETAL_SHARP.Properties.Resources.Boton_verde32;
                        //}
                        //else
                        //{
                        //    this.pictureBox1.Image = global::DBMETAL_SHARP.Properties.Resources.Boton_rojo32;

                        //    label18.Text = "Muestreo faltante";
                        //}
                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo Registro de detalle Muestreo para la orden " + 1.ToString().Trim(), "Movimiento Muestreo creado");
                    }
                }
                else
                    MessageBox.Show("Seleccione el laborario para clasificar la muestra");

                button1.Enabled = true;
                label13.Visible = false;
                //progressBar1.Visible = false;
            }
            catch (Exception Ex)
            {
                button1.Enabled = true;
                MessageBox.Show("Error 3", Ex.Message);
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
                    Operation = "CalidadMuestreoPMDia";
                else
                    if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                    Operation = "CalidadMOtrPMDia";
                else
                    Operation = "CalidadMZanPMDia";

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");

                if (Reader != null && Reader.Count() > 0)
                {
                    label2.Visible = true;
                    label4.Visible = true;

                    label4.Text = Reader.Count().ToString();
                    Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

                    dataGridView2.DataSource = Reader;
                    dataGridView2.Visible = true;

                    dataGridView2.Columns["cboDuplicado"].DefaultCellStyle.NullValue = "(1)";

                    dataGridView2.Columns[2].HeaderText = "Concecutivo Báscula";
                    dataGridView2.Columns[3].HeaderText = "Sello Control";
                    dataGridView2.Columns[4].HeaderText = "Nombre Proyecto";
                    dataGridView2.Columns[2].ReadOnly = true;
                    dataGridView2.Columns[3].ReadOnly = true;
                    dataGridView2.Columns[4].ReadOnly = true;
                    dataGridView2.Columns["Duplicado"].Visible = false;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].Visible = false;
                    dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[10].Visible = false;
                    dataGridView2.Columns[11].Visible = false;
                    dataGridView2.Columns["Hora"].Visible = false;
                    dataGridView2.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                    dataGridView2.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.AutoResizeColumns();

                    Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 1, "0");

                    Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

                    dataGridView1.DataSource = Reader;
                    label10.Visible = true;
                    label12.Visible = true;
                    label10.Text = Reader.Count().ToString();
                    dataGridView1.Visible = true;
                    label15.Text = "--";
                    label16.Text = "--";
                    dataGridView1.AutoResizeColumns();
                }
                else
                {
                    label2.Visible = false;
                    label4.Visible = false;
                    dataGridView2.Visible = false;
                }

                if (permisoConsulta.ContenedorOtros > 0 && permisoConsulta.ContenedorPeqMineria > 0 && permisoConsulta.ContenedorZandor > 0)
                    Operation = "CalidadMuestreoPMP";
                else
                    if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                    Operation = "CalidadMOtrPMP";
                else
                    Operation = "CalidadMZandorPMP";

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    label5.Text = Reader.Count().ToString();
                    label3.Visible = true;
                    label5.Visible = true;
                    dataGridView3.Visible = true;
                    label5.Text = Reader.Count().ToString();
                    Reader = Reader.OrderBy(r => r.Hora).OrderBy(t => t.NombreProyecto).ToList();
                    dataGridView3.DataSource = Reader;

                    dataGridView3.Columns[0].HeaderText = "Concecutivo Báscula";
                    dataGridView3.Columns[1].HeaderText = "Sello Control";
                    dataGridView3.Columns[2].HeaderText = "Nombre Proyecto";
                    dataGridView3.Columns["Duplicado"].Visible = false;
                    dataGridView3.Columns[5].Visible = false;
                    dataGridView3.Columns[6].Visible = false;
                    dataGridView3.Columns[7].Visible = false;
                    dataGridView3.Columns[8].Visible = false;
                    dataGridView3.Columns[9].Visible = false;
                    dataGridView3.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                    dataGridView3.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns.Remove("SelloControl");

                    dataGridView3.AutoResizeColumns();
                }
                else
                {
                    dataGridView3.Visible = false;
                    label3.Visible = false;
                    label5.Visible = false;
                }

                //if (dataGridView2.RowCount == 0 & dataGridView3.RowCount == 0)
                //{
                //    label18.Text = "Muestreo completo";

                //    this.pictureBox1.Image = global::DBMETAL_SHARP.Properties.Resources.Boton_verde32;
                //}
                //else
                //{
                //    this.pictureBox1.Image = global::DBMETAL_SHARP.Properties.Resources.Boton_rojo32;

                //    label18.Text = "Muestreo faltante";
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error2 :", ex.Message);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("co");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;


            dataGridView2.Visible = false;
            dataGridView3.Visible = false;


            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            cbmLabo.Enabled = true;

            cbmLabo.SelectedIndex = -1;
            loadHistory();
        }


        private void dtpEvent_ValueChanged(object sender, EventArgs e)
        {
            ReloadDataGrid();
            //cmbFiltroContenedor.
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
                    Operation = "CalidadMuestreoPMDia";
                else
                    if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                    Operation = "CalidadOtrPMDia";
                else
                    Operation = "CalidadZanPMDia";

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");

                if (Reader != null && Reader.Count() > 0)
                {
                    label2.Visible = true;
                    label4.Visible = true;

                    label4.Text = Reader.Count().ToString();
                    Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

                    dataGridView2.DataSource = Reader;
                    dataGridView2.Visible = true;
                    dataGridView2.Columns[2].HeaderText = "Concecutivo Báscula";
                    dataGridView2.Columns[3].HeaderText = "Sello Control";
                    dataGridView2.Columns[4].HeaderText = "Nombre Proyecto";
                    dataGridView2.Columns[2].ReadOnly = true;
                    dataGridView2.Columns[3].ReadOnly = true;
                    dataGridView2.Columns[4].ReadOnly = true;
                    dataGridView2.Columns["Duplicado"].Visible = false;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].Visible = false;
                    dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[10].Visible = false;
                    dataGridView2.Columns[11].Visible = false;
                    dataGridView2.Columns[13].Visible = false;
                    dataGridView2.Columns["Hora"].Visible = false;
                    dataGridView2.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                    dataGridView2.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.AutoResizeColumns();
                }
                else
                {
                    label2.Visible = false;
                    label4.Visible = false;
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Visible = false;
                }



                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 1, "0");

                Reader = Reader.OrderBy(r => r.NombreProyecto).ToList();

                dataGridView1.DataSource = Reader;
                label10.Visible = true;
                label12.Visible = true;
                label10.Text = Reader.Count().ToString();
                txtBuscarSelloControl.Text = string.Empty;

                dataGridView1.Columns[0].HeaderText = "Concecutivo Báscula";
                dataGridView1.Columns[1].HeaderText = "Sello Control";
                dataGridView1.Columns[2].HeaderText = "Nombre Proyecto";
                dataGridView1.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                dataGridView1.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns["Hora"].Visible = false;

                dataGridView1.Visible = true;
                dataGridView1.AutoResizeColumns();


                if (permisoConsulta.ContenedorOtros > 0 && permisoConsulta.ContenedorPeqMineria > 0 && permisoConsulta.ContenedorZandor > 0)
                    Operation = "CalidadMuestreoPMP";
                else
                    if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                    Operation = "CalidadMOtrPMP";
                else
                    Operation = "CalidadMZandorPMP";

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", Operation, dateValue, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    label5.Text = Reader.Count().ToString();
                    label3.Visible = true;
                    label5.Visible = true;
                    dataGridView3.Visible = true;
                    label5.Text = Reader.Count().ToString();

                    Reader = Reader.OrderBy(r => r.Hora).OrderBy(t => t.NombreProyecto).ToList();

                    dataGridView3.DataSource = Reader;
                    dataGridView3.Columns[0].HeaderText = "Concecutivo Báscula";
                    dataGridView3.Columns[1].HeaderText = "Sello Control";
                    dataGridView3.Columns[2].HeaderText = "Nombre Proyecto";
                    dataGridView3.Columns.Remove("SelloControl");
                    dataGridView3.Columns["Peso"].DefaultCellStyle.Format = "##,##.00";
                    dataGridView3.Columns["Peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns["Duplicado"].Visible = false;
                    dataGridView3.Columns[4].Visible = false;
                    dataGridView3.Columns[5].Visible = false;
                    dataGridView3.Columns[6].Visible = false;
                    dataGridView3.Columns[7].Visible = false;
                    dataGridView3.Columns[8].Visible = false;
                    dataGridView3.Columns[10].Visible = false;
                    dataGridView3.AutoResizeColumns();
                }
                else
                {
                    dataGridView3.Visible = false;
                    label3.Visible = false;
                    label5.Visible = false;
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                }
                label8.Visible = false;
                label9.Visible = false;
                dataGridView4.Visible = false;
                label15.Text = "--";
                label16.Text = "--";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error1 :", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_CargaAnalisis cargarANalisis = new Frm_CargaAnalisis(this.Usuario);
            cargarANalisis.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Fill = 0;
            if (dataGridView1.CurrentCell != null)
            {
                Fill = dataGridView1.CurrentCell.RowIndex;
                string value = dataGridView1[0, Fill].Value.ToString().Trim();
                List<Entidades.Ent_CalidadMuestro> Reader = new List<Entidades.Ent_CalidadMuestro>();
                label15.Text = "--";
                label16.Text = "--";

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", "LLenarTreePM", value, 0, "0");

                if (Reader != null && Reader.Count() > 0)
                {
                    Reader = Reader.OrderBy(r => r.SelloControl).ToList();

                    Reader = Reader.OrderBy(r => r.AUFA).ToList();

                    Reader = Reader.OrderBy(r => r.AAQAQC).ToList();


                    label9.Visible = true;
                    label8.Visible = true;
                    label9.Text = Reader.Count().ToString();
                    dataGridView4.DataSource = Reader;
                    dataGridView4.Columns["Duplicado"].Visible = false;

                    dataGridView4.Columns[13].DisplayIndex = 0;
                    dataGridView4.Columns[13].HeaderText = "QAQC";
                    dataGridView4.Columns[3].HeaderText = "Sello Control";
                    dataGridView4.Columns[0].ReadOnly = false;
                    dataGridView4.Columns[1].ReadOnly = true;
                    dataGridView4.Columns[2].ReadOnly = true;
                    dataGridView4.Columns[3].ReadOnly = true;
                    dataGridView4.Columns[4].ReadOnly = true;
                    dataGridView4.Columns[5].ReadOnly = true;

                    dataGridView4.Columns[6].ReadOnly = true;
                    dataGridView4.Columns[7].ReadOnly = true;
                    dataGridView4.Columns[8].ReadOnly = true;
                    dataGridView4.Columns[9].ReadOnly = true;
                    dataGridView4.Columns[10].ReadOnly = true;

                    dataGridView4.Columns[1].Visible = false;
                    dataGridView4.Columns[2].Visible = false;
                    dataGridView4.Columns[4].Visible = false;
                    dataGridView4.Columns[5].Visible = false;

                    dataGridView4.Columns["Hora"].Visible = false;

                    dataGridView4.Visible = true;

                    string valueMedia = string.Empty;
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        decimal value1 = 0;
                        if (row.Cells[8].Value != null)
                            if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                                row.Cells[0].Value = value1;
                            else
                            {
                                if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                    row.Cells[0].Value = value1;
                                else
                                    row.Cells[0].Value = string.Empty;
                            }

                        if (Convert.ToBoolean(row.Cells[13].Value))
                            if (value1 > 0)
                                if (string.IsNullOrEmpty(valueMedia))
                                    valueMedia = string.Concat(value1, ";");
                                else
                                    valueMedia = string.Concat(valueMedia, value1, ";");

                        if (!Convert.ToBoolean(row.Cells[13].Value))
                        {
                            row.DefaultCellStyle.BackColor = Color.Gray;

                            row.ReadOnly = true;
                            DataGridViewCheckBoxCell checkcell = row.Cells[13] as DataGridViewCheckBoxCell;
                            DataGridViewCheckBoxCell chkCell = checkcell as DataGridViewCheckBoxCell;

                            chkCell.Value = false;
                            checkcell.ReadOnly = false;

                        }
                    }
                    string[] arrar = valueMedia.TrimEnd(';').Split(';');

                    decimal[] arra1 = new decimal[arrar.Length];
                    for (int i = 0; i < arrar.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(arrar[i]))
                            arra1[i] = Convert.ToDecimal(arrar[i]);
                        else
                            arra1[i] = Convert.ToDecimal(0);

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
                                label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                            else
                                label16.Text = String.Format("{0:#.##}", value2);
                        }
                        else
                            label16.Text = String.Format("{0:#.##}", value2);

                    }
                    else
                        label16.Text = "NA";
                }
                else
                {
                    label9.Visible = false;
                    label8.Visible = false;
                    dataGridView4.Visible = false;
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
                throw new ArgumentException("Median of empty array not defined.");

            //make sure the list is sorted, but use a new array
            T[] sortedArray = cloneArray ? (T[])sourceArray.Clone() : sortedArray = sourceArray;
            Array.Sort(sortedArray);

            //get the median
            int size = sortedArray.Length;
            int mid = size / 2;
            if (size % 2 != 0)
                return sortedArray[mid];

            dynamic value1 = sortedArray[mid];
            dynamic value2 = sortedArray[mid - 1];
            var side = (double)Convert.ToDouble(sortedArray[mid] + value1) * 0.5;
            return side;
        }

        decimal Median(decimal[] xs)
        {
            var ys = xs.OrderBy(x => x).ToList();
            double mid = (ys.Count - 1) / 2.0;
            return Decimal.Round((ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2, 2);
        }

        double DesviacionStandard(decimal[] listaDatos)
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
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    indexCurrent++;

                    decimal value1 = 0;
                    if (row.Cells[8].Value != null)
                        if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                            row.Cells[0].Value = value1;
                        else
                        {
                            if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                row.Cells[0].Value = value1;
                            else
                                row.Cells[0].Value = string.Empty;
                        }

                    if (Convert.ToBoolean(dataGridView4.Rows[e.RowIndex].Cells[13].Value))
                        valueModificate = false;
                    else
                        valueModificate = true;

                    if (e.RowIndex == indexCurrent)
                    {
                        row.Cells[13].Value = valueModificate;
                        isModificate = false;
                        indexValue = -1;
                    }

                    if (Convert.ToBoolean(row.Cells[13].Value))
                        if (value1 > 0)
                            if (string.IsNullOrEmpty(valueMedia))
                                valueMedia = string.Concat(value1, ";");
                            else
                                valueMedia = string.Concat(valueMedia, value1, ";");
                }
                string[] arrar = valueMedia.TrimEnd(';').Split(';');

                //string[] arrar = valueMedia.Replace(',', '.').TrimEnd(';').Split(';');
                decimal[] arra1 = new decimal[arrar.Length];// { 23.3M, 34.9M, 56.9M, 34.09M };
                for (int i = 0; i < arrar.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arrar[i]))
                        arra1[i] = Convert.ToDecimal(arrar[i]);
                    else
                        arra1[i] = Convert.ToDecimal(0);

                }

                var val0 = Median(arra1);
                var val = GetMedian(arra1, true);
                label15.Text = val0.ToString();

                double value2 = DesviacionStandard(arra1);
                decimal value3 = 0;

                if (decimal.TryParse(value2.ToString(), out value3))
                    if (value3 != 0)
                    {

                        if (Convert.ToDecimal(String.Format("{0:#.##}", value3)) < 1)
                            label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                        else
                            label16.Text = String.Format("{0:#.##}", value2);
                    }
                    else
                    {
                        label16.Text = String.Format("{0:#.##}", value2);
                    }
                else
                    label16.Text = "NA";
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                label13.Visible = true;
                button3.Enabled = false;
                if (string.IsNullOrEmpty(this.IpLocal))
                    this.IpLocal = DireccionIP.Local();

                if (string.IsNullOrEmpty(this.IpPublica))
                    this.IpPublica = DireccionIP.Publica();

                if (string.IsNullOrEmpty(this.SerialHDD))
                    this.SerialHDD = DireccionIP.SerialNumberDisk();

                if (string.IsNullOrEmpty(this.Usuario))
                    this.Usuario = DireccionIP.SerialNumberDisk();

                GuardarDatos Guardar = new GuardarDatos();


                foreach (DataGridViewRow row in dataGridView4.Rows)
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
            if (dataGridView4.Rows.Count > 0 && dataGridView4.Rows.Count < 4)
            {
                List<Ent_CalidadMuestro> dt = dataGridView4.DataSource as List<Ent_CalidadMuestro>;
                dataGridView4.DataSource = null;
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
                    dataGridView4.DataSource = dt;
                    dataGridView4.Columns["Duplicado"].Visible = false;
                    dataGridView4.Columns[13].DisplayIndex = 0;
                    dataGridView4.Columns[13].HeaderText = "QAQC";
                    dataGridView4.Columns[3].HeaderText = "Sello Control";
                    dataGridView4.Columns[0].ReadOnly = false;
                    dataGridView4.Columns[1].ReadOnly = true;
                    dataGridView4.Columns[2].ReadOnly = true;
                    dataGridView4.Columns[3].ReadOnly = true;
                    dataGridView4.Columns[4].ReadOnly = true;
                    dataGridView4.Columns[5].ReadOnly = true;
                    dataGridView4.Columns[6].ReadOnly = true;
                    dataGridView4.Columns[7].ReadOnly = true;
                    dataGridView4.Columns[8].ReadOnly = true;
                    dataGridView4.Columns[9].ReadOnly = true;
                    dataGridView4.Columns[10].ReadOnly = true;
                    dataGridView4.Columns[1].Visible = false;
                    dataGridView4.Columns[2].Visible = false;
                    dataGridView4.Columns[4].Visible = false;
                    dataGridView4.Columns[5].Visible = false;
                    dataGridView4.Columns["Hora"].Visible = false;
                    dataGridView4.Visible = true;

                    string valueMedia = string.Empty;
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        decimal value1 = 0;
                        if (row.Cells[8].Value != null)
                            if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                                row.Cells[0].Value = value1;
                            else
                            {
                                if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                    row.Cells[0].Value = value1;
                                else
                                    row.Cells[0].Value = string.Empty;
                            }

                        if (Convert.ToBoolean(row.Cells[13].Value))
                            if (value1 > 0)
                                if (string.IsNullOrEmpty(valueMedia))
                                    valueMedia = string.Concat(value1, ";");
                                else
                                    valueMedia = string.Concat(valueMedia, value1, ";");
                    }
                    string[] arrar = valueMedia.TrimEnd(';').Split(';');

                    decimal[] arra1 = new decimal[arrar.Length];
                    for (int i = 0; i < arrar.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(arrar[i]))
                            arra1[i] = Convert.ToDecimal(arrar[i]);
                        else
                            arra1[i] = Convert.ToDecimal(0);

                    }
                    var val0 = Median(arra1);
                    var val = GetMedian(arra1, true);
                    label15.Text = val0.ToString();

                    double value2 = DesviacionStandard(arra1);
                    decimal value3 = 0;

                    if (decimal.TryParse(value2.ToString(), out value3))

                        if (Convert.ToDecimal(String.Format("{0:#.##}", value2)) < 1)
                            label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                        else
                            label16.Text = String.Format("{0:#.##}", value2);

                    else
                        label16.Text = "NA";
                }
            }
            else
                MessageBox.Show("No es posible realizar mas de 3 duplicados por muestras");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count != 1)
            {
                List<Ent_CalidadMuestro> dt = dataGridView4.DataSource as List<Ent_CalidadMuestro>;

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
                        dataGridView4.DataSource = null;
                        dt.RemoveAt(dt.Count - 1);

                        // dt.Select(er => er.SelloControl == insertRegister.SelloControl);

                        if (dt != null)
                        {
                            dataGridView4.DataSource = dt;
                            dataGridView4.Columns["Duplicado"].Visible = false;
                            dataGridView4.Columns[13].DisplayIndex = 0;
                            dataGridView4.Columns[13].HeaderText = "QAQC";
                            dataGridView4.Columns[3].HeaderText = "Sello Control";
                            dataGridView4.Columns[0].ReadOnly = false;
                            dataGridView4.Columns[1].ReadOnly = true;
                            dataGridView4.Columns[2].ReadOnly = true;
                            dataGridView4.Columns[3].ReadOnly = true;
                            dataGridView4.Columns[4].ReadOnly = true;
                            dataGridView4.Columns[5].ReadOnly = true;
                            dataGridView4.Columns[6].ReadOnly = true;
                            dataGridView4.Columns[7].ReadOnly = true;
                            dataGridView4.Columns[8].ReadOnly = true;
                            dataGridView4.Columns[9].ReadOnly = true;
                            dataGridView4.Columns[10].ReadOnly = true;
                            dataGridView4.Columns[1].Visible = false;
                            dataGridView4.Columns[2].Visible = false;
                            dataGridView4.Columns[4].Visible = false;
                            dataGridView4.Columns[5].Visible = false;
                            dataGridView4.Columns["Hora"].Visible = false;
                            dataGridView4.Visible = true;

                            string valueMedia = string.Empty;
                            foreach (DataGridViewRow row in dataGridView4.Rows)
                            {
                                decimal value1 = 0;
                                if (row.Cells[8].Value != null)
                                    if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                                        row.Cells[0].Value = value1;
                                    else
                                    {
                                        if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                            row.Cells[0].Value = value1;
                                        else
                                            row.Cells[0].Value = string.Empty;
                                    }

                                if (Convert.ToBoolean(row.Cells[13].Value))
                                    if (value1 > 0)
                                        if (string.IsNullOrEmpty(valueMedia))
                                            valueMedia = string.Concat(value1, ";");
                                        else
                                            valueMedia = string.Concat(valueMedia, value1, ";");
                            }
                            string[] arrar = valueMedia.TrimEnd(';').Split(';');

                            decimal[] arra1 = new decimal[arrar.Length];
                            for (int i = 0; i < arrar.Length; i++)
                            {
                                if (!String.IsNullOrEmpty(arrar[i]))
                                    arra1[i] = Convert.ToDecimal(arrar[i]);
                                else
                                    arra1[i] = Convert.ToDecimal(0);

                            }
                            var val0 = Median(arra1);
                            var val = GetMedian(arra1, true);
                            label15.Text = val0.ToString();

                            double value2 = DesviacionStandard(arra1);
                            decimal value3 = 0;

                            if (decimal.TryParse(value2.ToString(), out value3))

                                if (Convert.ToDecimal(String.Format("{0:#.##}", value2)) < 1)
                                    label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                                else
                                    label16.Text = String.Format("{0:#.##}", value2);

                            else
                                label16.Text = "NA";
                        }
                    }
                    else
                        MessageBox.Show("El registro ya tiene mas de 12 horas a aver sido procesado");
                }
                else
                    MessageBox.Show("El registro no puede ser eliminado por que posee AU final");
            }
            else
                MessageBox.Show("El registro original no puede ser eliminado");
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
            //if (dataGridView3.RowCount == 0)
            //{
            //    if (dataGridView2.Rows.Count == 1)
            //    {
            //        try
            //        {
            //            if (dataGridView2.Rows[0].Cells[3] != null)
            //            {
            //                label18.Text = "Muestreo faltante";
            //            }


            //        }
            //        catch
            //        {
            //            label18.Text = "Muestreo completo";

            //        }

            //    }
            //}
            //else
            //{
            //    label18.Text = "Muestreo faltante";
            //}
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //label18.Text = string.Empty;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscarSelloControl.Text.Trim()))
            {

                if (dataGridView1.Rows.Count > 0)
                {
                    button2.Enabled = false;

                    List<Ent_CalidadMuestro> dt = dataGridView1.DataSource as List<Ent_CalidadMuestro>;
                    //SqlParameter[] ParamSQl = GuardarDatos.Parametros_ToneladaSeca();
                    //Guardar.Numerico("Sp_Eliminar_Control_MuestreoPM", ParamSQl);
                    //[Sp_Modificar_QA]
                    int consec = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
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

                        label9.Visible = true;
                        label8.Visible = true;
                        label9.Text = Reader.Count().ToString();
                        dataGridView4.DataSource = Reader;
                        dataGridView4.Columns["Duplicado"].Visible = false;

                        dataGridView4.Columns[13].DisplayIndex = 0;
                        dataGridView4.Columns[13].HeaderText = "QAQC";
                        dataGridView4.Columns[3].HeaderText = "Sello Control";
                        dataGridView4.Columns[0].ReadOnly = false;
                        dataGridView4.Columns[1].ReadOnly = true;
                        dataGridView4.Columns[2].ReadOnly = true;
                        dataGridView4.Columns[3].ReadOnly = true;
                        dataGridView4.Columns[4].ReadOnly = true;
                        dataGridView4.Columns[5].ReadOnly = true;

                        dataGridView4.Columns[6].ReadOnly = true;
                        dataGridView4.Columns[7].ReadOnly = true;
                        dataGridView4.Columns[8].ReadOnly = true;
                        dataGridView4.Columns[9].ReadOnly = true;
                        dataGridView4.Columns[10].ReadOnly = true;

                        dataGridView4.Columns[1].Visible = false;
                        dataGridView4.Columns[2].Visible = false;
                        dataGridView4.Columns[4].Visible = false;
                        dataGridView4.Columns[5].Visible = false;

                        dataGridView4.Columns["Hora"].Visible = false;

                        dataGridView4.Visible = true;

                        string valueMedia = string.Empty;
                        foreach (DataGridViewRow row in dataGridView4.Rows)
                        {
                            decimal value1 = 0;
                            if (row.Cells[8].Value != null)
                                if (decimal.TryParse(row.Cells[8].Value.ToString(), out value1))
                                    row.Cells[0].Value = value1;
                                else
                                {
                                    if (decimal.TryParse(row.Cells[9].Value.ToString(), out value1))
                                        row.Cells[0].Value = value1;
                                    else
                                        row.Cells[0].Value = string.Empty;
                                }

                            if (Convert.ToBoolean(row.Cells[13].Value))
                                if (value1 > 0)
                                    if (string.IsNullOrEmpty(valueMedia))
                                        valueMedia = string.Concat(value1, ";");
                                    else
                                        valueMedia = string.Concat(valueMedia, value1, ";");
                        }
                        string[] arrar = valueMedia.TrimEnd(';').Split(';');

                        decimal[] arra1 = new decimal[arrar.Length];
                        for (int i = 0; i < arrar.Length; i++)
                        {
                            if (!String.IsNullOrEmpty(arrar[i]))
                                arra1[i] = Convert.ToDecimal(arrar[i]);
                            else
                                arra1[i] = Convert.ToDecimal(0);

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
                                    label16.Text = string.Concat("0", String.Format("{0:#.##}", value2));
                                else
                                    label16.Text = String.Format("{0:#.##}", value2);
                            }
                            else
                                label16.Text = String.Format("{0:#.##}", value2);

                        }
                        else
                            label16.Text = "NA";
                    }
                    else
                    {
                        label9.Visible = false;
                        label8.Visible = false;
                        dataGridView4.Visible = false;
                    }
                    button2.Enabled = true;
                }
            }
        }

        private void dataGridView4_BindingContextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                int kia = row.Index;

                //dataHistoryPeriodo.Rows[kia].DefaultCellStyle.BackColor = Color.Yellow;
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
                List<Ent_CalidadMuestro> dt = dataGridView1.DataSource as List<Ent_CalidadMuestro>;

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
                            valueGeneric.Add(valueInd);
                    }
                    //List<Ent_CalidadMuestro>  value = dt.Where(s => s.SelloControl.Contains(textBox1.Text.Trim())).ToList();
                    //if (value != null)
                    if (valueGeneric != null)
                    {
                        dataGridView1.DataSource = valueGeneric;

                        label10.Visible = true;
                        label12.Visible = true;
                        label10.Text = valueGeneric.Count().ToString();
                        dataGridView1.Visible = true;
                        label15.Text = "--";
                        label16.Text = "--";
                        dataGridView1.AutoResizeColumns();
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


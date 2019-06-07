using Entidades;
using OfficeOpenXml;
using ReglasdeNegocio;
using Reportes.LiquidacionDBMETAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_Periodo : Form
    {

        #region Propiedades - Variables   
        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }
        public int Fill { get; set; }
        public string ValorPeriodo { get; set; }

        public string Ano { get; set; }
        public string Mes { get; set; }
        public string Periodo { get; set; }


        public List<Roles_Permisos> Permission;
        public bool selccionValor { get; set; }

        #endregion

        #region Constructor
        public Frm_Periodo()
        {
            InitializeComponent();
        }
        public Frm_Periodo(string User)
        {
            InitializeComponent();
            this.Usuario = User.Trim();
            loadPeriodo(0);
            dataHistoryPeriodo.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);


            DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", User.ToString().Trim(), this.Name);

            this.Permission = DBMETAL_SHARP.Common.Common.Permissions;

            ValidatePermission(this.Controls);
        }
        #endregion 

        #region Eventos
        private void Frm_Periodo_Load(object sender, EventArgs e)
        {

        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void loadPeriodo(int anoPeriodo)
        {
            this.cboAno.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            if (anoPeriodo == 0)
            {
                cboAno.Items.Clear();
                var read = ConsultaEntidades.ObtenerPeriodos("SpConsulta_Tablas", "FechaPeriodo", "", anoPeriodo, string.Empty);
                var query = read.Select(c => c.FechaAplica).ToArray();
                cboAno.Items.AddRange(query.ToArray());
                cboAno.SelectedIndex = 0;
                anoPeriodo = Convert.ToInt32(cboAno.Items[0].ToString());
            }
            var readHistory = ConsultaEntidades.ObtenerPeriodos("SpConsulta_Tablas", "PeriodoAno", "", anoPeriodo, string.Empty);

            dataHistoryPeriodo.DataSource = readHistory;

            if (dataHistoryPeriodo.Rows.Count > 0)
            {
                DateTime valorAnterior = Convert.ToDateTime(dataHistoryPeriodo.Rows[0].Cells[3].Value);
                dtpEventInitial.Value = valorAnterior.AddDays(1);
                dtpDatenEnd.Value = dtpEventInitial.Value.AddDays(1);
            }
            else
            {
                dtpEventInitial.Value = DateTime.Now;
                dtpDatenEnd.Value = DateTime.Now.AddDays(1);
            }

            dataHistoryPeriodo.Columns[0].Visible = false;
            dataHistoryPeriodo.Columns[10].DisplayIndex = 0;

            dataHistoryPeriodo.Columns[10].HeaderText = "Estado Abierto";
            dataHistoryPeriodo.Columns[2].HeaderText = "Fecha Inicio";
            dataHistoryPeriodo.Columns[3].HeaderText = "Fecha Fin";
            dataHistoryPeriodo.Columns[4].HeaderText = "Año";
            dataHistoryPeriodo.Columns[5].HeaderText = "Mes";
            dataHistoryPeriodo.Columns[6].HeaderText = "Periodo";
            dataHistoryPeriodo.Columns[7].HeaderText = "Onzas Fundidas";
            dataHistoryPeriodo.Columns[8].HeaderText = "Onzas Recuperadas";
            dataHistoryPeriodo.Columns[9].HeaderText = "Recuperación Planta";
            dataHistoryPeriodo.Columns["RecuperacionPlanta"].DefaultCellStyle.Format = "##,##.00";
            dataHistoryPeriodo.Columns["RecuperacionPlanta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataHistoryPeriodo.Columns["OnzasFundidas"].DefaultCellStyle.Format = "##,##.00";
            dataHistoryPeriodo.Columns["OnzasFundidas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataHistoryPeriodo.Columns["OnzasRecuperadas"].DefaultCellStyle.Format = "##,##.00";
            dataHistoryPeriodo.Columns["OnzasRecuperadas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataHistoryPeriodo.Columns["AnoPeriodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataHistoryPeriodo.Columns["MesPeriodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataHistoryPeriodo.Columns["Periodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataHistoryPeriodo.Columns["IdPeriodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataHistoryPeriodo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataHistoryPeriodo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataHistoryPeriodo.AutoResizeColumns();

            label17.Text = "     - - ";
            btnCerrarPe.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IpLocal))
                this.IpLocal = DireccionIP.Local();

            if (string.IsNullOrEmpty(this.IpPublica))
                this.IpPublica = DireccionIP.Publica();

            if (string.IsNullOrEmpty(this.SerialHDD))
                this.SerialHDD = DireccionIP.SerialNumberDisk();

            if (string.IsNullOrEmpty(this.Usuario))
                this.Usuario = DireccionIP.SerialNumberDisk();

            string validar = ValidarRequeridos();

            if (string.IsNullOrEmpty(validar))
            {
                if (dtpEventInitial.Value.Date > dtpDatenEnd.Value.Date)
                {
                    dtpDatenEnd.Value = DateTime.Now;
                    MessageBox.Show("La fecha final debe ser mayor a la inicial!");
                    return;
                }
                string mensaje = string.Empty;

                if (dataHistoryPeriodo.Rows.Count > 0)
                {
                    if (!selccionValor)
                    {
                        DateTime valorAnterior = Convert.ToDateTime(dataHistoryPeriodo.Rows[0].Cells[3].Value);
                        int resultado = DateTime.Compare(valorAnterior, Convert.ToDateTime(dtpEventInitial.Text));
                        if (resultado < 0)
                        {
                            resultado = DateTime.Compare(valorAnterior.AddDays(1), Convert.ToDateTime(dtpEventInitial.Text));

                            if (resultado != 0)
                                mensaje = "El nuevo periodo debe de ser un día posterior al final del anterior periodo";
                        }
                        else if (resultado == 0)
                            mensaje = "La fecha inicial del nuevo periodo conincide con la fecha final del anterior periodo";
                        else
                            mensaje = "El nuevo periodo esta en el rango de fechas del anterior periodo";

                        if (dataHistoryPeriodo.Rows[0].Cells[1].Value.ToString().Trim().Contains(string.Concat(cboAno.Text.Trim(), "-", cboMes.Text.Trim(), "-", cboPeriodo.Text.Trim())))
                        {
                            MessageBox.Show("El periodo a crear ya existe en historial, verificar coposición del periodo");
                            return;
                        }
                    }
                }
                if (!String.IsNullOrEmpty(mensaje))
                {
                    MessageBox.Show(mensaje);
                    return;
                }
                GuardarDatos Guardar = new GuardarDatos();
                SqlParameter[] ParamSQl = GuardarDatos.Parametros_Insertar_PeriodoPM("", Convert.ToDateTime(dtpEventInitial.Text), Convert.ToDateTime(dtpDatenEnd.Text), Convert.ToInt32(cboAno.Text), Convert.ToInt32(cboMes.Text), cboPeriodo.Text, string.IsNullOrEmpty(txtOnzasFundidas.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(txtOnzasFundidas.Text.Trim())
                , string.IsNullOrEmpty(txtRecuperacion.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(txtRecuperacion.Text.Trim())
                , string.IsNullOrEmpty(txtOnzasRecuperadas.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(txtOnzasRecuperadas.Text.Trim()), 1);


                if (ParamSQl[0].Value.ToString() == "I")
                {
                    Guardar.booleano("Sp_Guardar_PeriodoLiquidacion", ParamSQl);
                    MessageBox.Show("Periodo almacenado con Exito");
                    LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo Registro de Periodo " + string.Concat(cboAno.Text.Trim(), "-", cboMes.Text.Trim(), "-", cboPeriodo.Text.Trim()), "Movimiento Periodo creado");
                }
                else
                {
                    Guardar.booleano("Sp_Modicar_PeriodoLiquidacion", ParamSQl);
                    MessageBox.Show("Periodo actualizado con Exito");
                    LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se modifico Periodo" + string.Concat(cboAno.Text.Trim(), "-", cboMes.Text.Trim(), "-", cboPeriodo.Text.Trim()), "Movimiento Periodo  Modificar");
                }

                LimpiarCampos();
                loadPeriodo(Convert.ToInt32(cboAno.Text));

            }
            else
                MessageBox.Show(validar);
            return;
        }
        private void LimpiarCampos()
        {
            cboAno.Text = string.Empty;
            cboMes.Text = string.Empty;
            cboPeriodo.Text = string.Empty;
            txtOnzasFundidas.Text = string.Empty;
            txtRecuperacion.Text = string.Empty;
            txtOnzasRecuperadas.Text = string.Empty;
            dtpDatenEnd.Value = DateTime.Now;
            dtpEventInitial.Value = DateTime.Now;
            label17.Text = "- -";
        }

        private string ValidarRequeridos()
        {
            if (!string.IsNullOrEmpty(cboAno.Text))
            {
                if (!string.IsNullOrEmpty(cboMes.Text))
                {
                    if (!string.IsNullOrEmpty(cboPeriodo.Text))
                    {
                        if (!string.IsNullOrEmpty(txtOnzasFundidas.Text.Trim()))
                        {
                            if (!string.IsNullOrEmpty(txtRecuperacion.Text.Trim()))
                            {
                                if (!string.IsNullOrEmpty(txtOnzasRecuperadas.Text.Trim()))
                                {
                                    return String.Empty;
                                }
                                else
                                    return string.Concat("Las onzas recuperadasson requeridas para crear periodo");
                            }
                            else
                                return string.Concat("La recuperación son requeridas para crear periodo");
                        }
                        else
                            return string.Concat("Las onzas son requeridas para crear periodo");

                    }
                    else
                        return string.Concat("El periodo es requerido para crear periodo");
                }
                else
                    return string.Concat("El mes es requerido para crear periodo");
            }
            else
                return string.Concat("El año es requerido para crear periodo");
        }

        private void dataHistoryPeriodo_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataHistoryPeriodo.Rows)
            {
                int kia = row.Index;
                if (!Convert.ToBoolean(row.Cells["Available"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }
        private void dataHistoryPeriodo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selccionValor = true;
            btnCreate.Text = "Modificar Periodo";
            Fill = dataHistoryPeriodo.CurrentCell.RowIndex;
            ValorPeriodo = dataHistoryPeriodo[1, Fill].Value.ToString().Trim();
            Ano = dataHistoryPeriodo[4, Fill].Value.ToString();
            Mes = dataHistoryPeriodo[5, Fill].Value.ToString();
            Periodo = dataHistoryPeriodo[6, Fill].Value.ToString();
            dtpEventInitial.Value = Convert.ToDateTime(dataHistoryPeriodo[2, Fill].Value.ToString().Trim());
            dtpDatenEnd.Value = Convert.ToDateTime(dataHistoryPeriodo[3, Fill].Value.ToString().Trim());
            cboAno.Text = dataHistoryPeriodo[4, Fill].Value.ToString().Trim();
            cboMes.Text = dataHistoryPeriodo[5, Fill].Value.ToString().Trim();
            cboPeriodo.Text = dataHistoryPeriodo[6, Fill].Value.ToString().Trim();

            if (dataHistoryPeriodo[7, Fill].Value != null && Convert.ToDecimal(dataHistoryPeriodo[7, Fill].Value.ToString().Trim()) > 0)
                txtOnzasFundidas.Text = dataHistoryPeriodo[7, Fill].Value.ToString().Trim();
            else
                txtOnzasFundidas.Text = string.Empty;

            if (dataHistoryPeriodo[9, Fill].Value != null && Convert.ToDecimal(dataHistoryPeriodo[9, Fill].Value.ToString().Trim()) > 0)
                txtRecuperacion.Text = dataHistoryPeriodo[9, Fill].Value.ToString().Trim();
            else
                txtRecuperacion.Text = string.Empty;

            if (dataHistoryPeriodo[8, Fill].Value != null && Convert.ToDecimal(dataHistoryPeriodo[8, Fill].Value.ToString().Trim()) > 0)
                txtOnzasRecuperadas.Text = dataHistoryPeriodo[8, Fill].Value.ToString().Trim();
            else
                txtOnzasRecuperadas.Text = string.Empty;

            if (Convert.ToBoolean(dataHistoryPeriodo[10, Fill].Value.ToString().Trim()))
            {
                label17.Text = "Abierto";
                btnCerrarPe.Enabled = true;
                btnCerrarPe.Enabled = true;
                dtpEventInitial.Enabled = true;
                dtpDatenEnd.Enabled = true;
                cboAno.Enabled = true;
                cboMes.Enabled = true;
                cboPeriodo.Enabled = true;
                txtOnzasFundidas.Enabled = true;
                txtRecuperacion.Enabled = true;
                txtOnzasRecuperadas.Enabled = true;
            }
            else
            {
                label17.Text = "Cerrado";
                btnCerrarPe.Enabled = false;
                dtpEventInitial.Enabled = false;
                dtpDatenEnd.Enabled = false;
                cboAno.Enabled = false;
                cboMes.Enabled = false;
                cboPeriodo.Enabled = false;
                txtOnzasFundidas.Enabled = false;
                txtRecuperacion.Enabled = false;
                txtOnzasRecuperadas.Enabled = false;
            }

            var read = ConsultaEntidades.DetallePeriodos("SpConsulta_Tablas", "DetallePeriodo", dataHistoryPeriodo[1, Fill].Value.ToString().Trim(), 0, string.Empty);

            dataDetailPeriodo.DataSource = read;
            dataDetailPeriodo.Columns[0].Width = 40;
            dataDetailPeriodo.Columns[1].Width = 40;

            dataDetailPeriodo.Columns[2].Width = 40;
            dataDetailPeriodo.Columns["Toneladas"].DefaultCellStyle.Format = "##,##.00";
            dataDetailPeriodo.Columns["Toneladas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataDetailPeriodo.Columns["Onzas"].DefaultCellStyle.Format = "##,##.00";
            dataDetailPeriodo.Columns["Onzas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataDetailPeriodo.Columns["Tenor"].DefaultCellStyle.Format = "##,##.00";
            dataDetailPeriodo.Columns["Tenor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var suma = read.Select(c => c.Toneladas).Sum();
            txtToneladas.Text = suma.Value.ToString("##.00");

            suma = read.Select(c => c.Tenor).Sum();
            txtTenor.Text = suma.Value.ToString("##.00");



            suma = read.Select(c => c.Onzas).Sum();
            txtOnzas.Text = suma.Value.ToString("##.00");

            dataDetailPeriodo.AutoResizeColumns();

        }




        private void btnCerrarPe_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea cerrar el periodo", "Titulo", MessageBoxButtons.YesNoCancel,
         MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                GuardarDatos Guardar = new GuardarDatos();
                SqlParameter[] ParamSQl = GuardarDatos.Parametros_Cerrar_PeriodoPM(ValorPeriodo);
                Guardar.booleano("Sp_Cerrar_Periodo_MuestreoPM", ParamSQl);

                loadPeriodo(Convert.ToInt32(cboAno.Text));
                LimpiarCampos();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void cboAno_Leave(object sender, EventArgs e)
        {
            loadPeriodo(Convert.ToInt32(cboAno.Text));
            LimpiarCampos();
        }

        private void cboAno_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Crear Periodo";
        }

        private void cboMes_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Crear Periodo";
        }

        private void cboPeriodo_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Crear Periodo";
        }

        private void dataHistoryPeriodo_BindingContextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataHistoryPeriodo.Rows)
            {
                int kia = row.Index;

                //dataHistoryPeriodo.Rows[kia].DefaultCellStyle.BackColor = Color.Yellow;
                if (!Convert.ToBoolean(row.Cells["Available"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ValorPeriodo))
            {
                Frm_Reporte_Liquidacion frmReporte = new Frm_Reporte_Liquidacion();

                LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Impresión reporte Onzas Entergadas", "Impresión Reporte");


                object[] argument = new object[] { 5, ValorPeriodo };
                frmReporte.EjecucionReportes(argument);
                frmReporte.Show();
            }
            else
                MessageBox.Show("Seleccione un periodo a imprimir");

        }
        #endregion

        #region Metodos
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


        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ValorPeriodo))
            {
                Frm_Reporte_Liquidacion frmReporte = new Frm_Reporte_Liquidacion();
                LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Impresión reporte Onzas Recuperados", "Impresión Reporte");

                object[] argument = new object[] { 6, Ano,Mes,Periodo };
                frmReporte.EjecucionReportes(argument);
                frmReporte.Show();
            }
            else
                MessageBox.Show("Seleccione un periodo a imprimir");
        }
    }
}

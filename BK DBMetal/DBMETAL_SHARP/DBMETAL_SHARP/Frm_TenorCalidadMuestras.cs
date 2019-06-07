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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_TenorCalidadMuestras : Form
    {
        List<Ent_OrdenesMuestra> obtenerHistorial = null;
        public Frm_TenorCalidadMuestras(string User)
        {
            InitializeComponent();
            this.Usuario = User.Trim();
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("co");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            dataGridView3.Visible = false;
            //dataGridView3.Visible = false;

            //label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            //label5.Visible = false;

            loadHistory();
        }

        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.

        }
        public int Op { get; set; }
        public int type { get; set; }



        private void Frm_MuestreoPM_Load(object sender, EventArgs e)
        {
            btnNew.PerformClick();
        }

        private void DtpFecha_Leave(object sender, EventArgs e)
        {

            //TxbPesaje.Focus();
        }

        private void DtpFecha_Enter(object sender, EventArgs e)
        {
        }

        private void DtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //    TxbPesaje.Focus();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }


        private void loadHistory()
        {
            cmbShipment.Items.Clear();
            this.cmbShipment.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbmLabo.DropDownStyle = ComboBoxStyle.DropDownList;
            // List<Ent_Destino> read = ConsultaEntidades.ObtenerHistorialSec("SpConsulta_Tablas", "ObeterLocalizacion", "1234", 0, string.Empty);
            var read = ConsultaEntidades.ObtenerHistorialSec("SpConsulta_Tablas", "ConsecutivoControlM", "", 0, string.Empty);
            obtenerHistorial = read.OrderByDescending(o => o.IdOrden).ToList();

            Ent_OrdenesMuestra pre = new Ent_OrdenesMuestra();
            pre.Id = read.ToList().Count + 1;
            pre.IdOrden = "Seleccione Orden";
            read.Insert(obtenerHistorial.ToList().Count, pre);

            pre = new Ent_OrdenesMuestra();
            pre.Id = 0;
            pre.IdOrden = "Nueva Orden";
            read.Insert(0, pre);

            cmbShipment.DisplayMember = "IdOrden";
            cmbShipment.ValueMember = "IdOrden";


            var query = from student in read
                        orderby student.Id descending
                        select student.IdOrden;

            //var query = obtenerHistorial.Select(c => c.IdOrden).ToList();
            cmbShipment.Items.AddRange(query.ToArray());
            cmbShipment.SelectedIndex = 0;

            dtpEvent.Value = DateTime.Now;
            //groupBox6.Visible = false;
            //     query = read.Select(c => c.Laboratorio).ToList();
            //cbmLabo.Items.AddRange(query.ToArray());
            //cbmLabo.SelectedIndex = query.ToList().Count - 1;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.IpLocal))
                    this.IpLocal = DireccionIP.Local();

                if (string.IsNullOrEmpty(this.IpPublica))
                    this.IpPublica = DireccionIP.Publica();

                if (string.IsNullOrEmpty(this.SerialHDD))
                    this.SerialHDD = DireccionIP.SerialNumberDisk();

                if (string.IsNullOrEmpty(this.Usuario))
                    this.Usuario = DireccionIP.SerialNumberDisk();

                bool indicateSave = false;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {


                        break;
                    }
                }
                GuardarDatos Guardar = new GuardarDatos();
                SqlParameter[] ParamSQl = GuardarDatos.Parametros_OrdenesMuestreoPM("", cmbShipment.Text, dtpEvent.Value, !String.IsNullOrEmpty(/*label4.Text*/ string.Empty ) ? int.Parse(/*label4.Text*/ string.Empty) : 0, cbmLabo.SelectedIndex, (true/*rbtAnalisys.Checked*/) ? /*rbtAnalisys.Checked */true: false, 1);

                if (ParamSQl[0].Value.ToString() == "I")
                {

                    Guardar.Numerico("Sp_Guardar_OrdenMuestraPM", ParamSQl).ToString();

                    MessageBox.Show("Muestreo almacenado con Exito");
                    loadHistory();
                    //LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo Registro de Muestreo " + TxbConsecutivo.Text.Trim(), "Movimiento Muestreo creado");
                    //Limpiar(1);
                }
                else
                {
                    MessageBox.Show("Personal de Muestreo actualizado con Exito");
                    //LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se modifico Personal de Muestreo " + TxbConsecutivo.Text.Trim(), "Movimiento Muestreo  Modificar");
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            try
            {
                List<Entidades.Ent_CalidadMuestro> Reader = new List<Entidades.Ent_CalidadMuestro>();

                DateTime dateValue = new DateTime(dtpEvent.Value.Year, dtpEvent.Value.Month, dtpEvent.Value.Day);

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", "CalidadMuestreoPMDia", dateValue, 0, "0");

                if (Reader != null && Reader.Count() > 0)
                {
                    dataGridView3.Visible = true;

                    label2.Visible = true;
                    //label4.Visible = true;

                    //label4.Text = Reader.Count().ToString();
                    dataGridView3.DataSource = Reader;
                    dataGridView3.Columns["Total"].DefaultCellStyle.Format = "##,##.00";
                    dataGridView3.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns["cboDuplicado"].DefaultCellStyle.NullValue = "(0)";

                    dataGridView3.Columns[2].ReadOnly = true;
                    dataGridView3.Columns[3].ReadOnly = true;
                    dataGridView3.Columns[4].ReadOnly = true;
                    dataGridView3.AutoResizeColumns();
                }
                else
                {
                    //label2.Visible = false;
                    ////label4.Visible = false;

                    //dataGridView2.Visible = false;
                }

                Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", "CalidadMuestreoPMP", dateValue, 0, "0");
                if (Reader != null && Reader.Count() > 0)
                {
                    //label5.Text = Reader.Count().ToString();
                    //label3.Visible = true;
                    //label5.Visible = true;
                    //dataGridView3.Visible = true;
                    //label5.Text = Reader.Count().ToString();
                    //dataGridView3.DataSource = Reader;
                    //dataGridView3.Columns.Remove("SelloControl");
                    //dataGridView3.Columns["Total"].DefaultCellStyle.Format = "##,##.00";
                    //dataGridView3.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    //dataGridView3.AutoResizeColumns();
                }
                else
                {
                    //dataGridView3.Visible = false;
                    //label3.Visible = false;
                    //label5.Visible = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error :", ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void cmbShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valueRef = -1;
            if (int.TryParse(cmbShipment.Text, out valueRef))
            {
                if (cmbShipment.Items.Count > 1)
                {
                    var laborat = obtenerHistorial.Where(r => r.IdOrden == cmbShipment.Text).Select(c => c.Laboratorio).FirstOrDefault();
                    cbmLabo.SelectedIndex = laborat;

                    var typeAnal = obtenerHistorial.Where(r => r.IdOrden == cmbShipment.Text).Select(c => c.TipoAnalisis).FirstOrDefault();
                    //if (typeAnal)
                    //    rbtAnalisys.Checked = true;
                    //else
                    //    rbtReanalisys.Checked = true;

                    var dateVale = obtenerHistorial.Where(r => r.IdOrden == cmbShipment.Text).Select(c => c.FechaOrden).FirstOrDefault();

                    dtpEvent.Value = dateVale;
                }
            }
            else
            {
                if (cmbShipment.Text.Contains("Nueva"))
                {

                    Ent_OrdenesMuestra pre = new Ent_OrdenesMuestra();
                    pre.Id = 1;
                    pre.IdOrden = (obtenerHistorial.Count + 1).ToString();
                    obtenerHistorial.Insert(0, pre);

                    cmbShipment.Items.Clear();

                    //var query = obtenerHistorial.Select(c => c.IdOrden).ToList();
                    cmbShipment.Items.Add(pre);
                    cmbShipment.SelectedIndex = 0;

                    //groupBox6.Visible = true;
                    //label8.Text = pre.IdOrden;

                    cbmLabo.SelectedIndex = -1;
                    //rbtAnalisys.Checked = false;
                    //rbtReanalisys.Checked = false;
                    dtpEvent.Value = DateTime.Now;

                }
            }
        }

        private void cmbShipment_Leave(object sender, EventArgs e)
        {
            int valueRef = -1;
            if (int.TryParse(cmbShipment.Text, out valueRef))
            {
                if (cmbShipment.Items.Count > 1)
                {

                    var laborat = obtenerHistorial.Where(r => r.IdOrden == cmbShipment.Text).Select(c => c.Laboratorio).FirstOrDefault();
                    cbmLabo.SelectedIndex = laborat;

                    var typeAnal = obtenerHistorial.Where(r => r.IdOrden == cmbShipment.Text).Select(c => c.TipoAnalisis).FirstOrDefault();
                    //if (typeAnal)
                    //    rbtAnalisys.Checked = true;
                    //else
                    //    rbtReanalisys.Checked = true;

                    var dateVale = obtenerHistorial.Where(r => r.IdOrden == cmbShipment.Text).Select(c => c.FechaOrden).FirstOrDefault();

                    dtpEvent.Value = dateVale;
                }
            }
            else
            { }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }


}


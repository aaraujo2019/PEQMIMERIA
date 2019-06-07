using DBMETAL_SHARP.Common;
using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ZandorConn;

namespace DBMETAL_SHARP
{
    public partial class FrmReclamos : Form
    {
        private Ent_EncabezadoReclamos encabezado = new Ent_EncabezadoReclamos();
        private Ent_Reclamos reclamos = new Ent_Reclamos();
        private DatosReclamos datosReclamos = new DatosReclamos();
        private int IdEncabezadoReclamos;
        private Frm_Busqueda Forma;
        private DataTable reclamosDt;

        public FrmReclamos()
        {
            InitializeComponent();
        }

        public void EjecutaPasarDato(string Dato)
        {
            switch (Forma.OpBusqueda)
            {
                case 1:
                    this.txtNumOrden.Text = Dato;
                    txtNumOrden_Leave(null, null);
                    break;
                case 2:
                    this.txtCliente.Text = Dato;
                    txtCliente_Leave(null, null);
                    break;
            }
        }

        private bool ValidarControles(GroupBox groupbox)
        {
            foreach (Control control in groupbox.Controls)
            {
                if (control.GetType().Equals(typeof(TextBox)))
                {
                    if (control.Text == string.Empty)
                    {
                        Safe.Message(string.Concat("El campo ", control.Tag, " es obligatorio."), 2);
                        return false;
                    }
                }
                else if (control.GetType().Equals(typeof(DateTimePicker)))
                {
                    if (control.Text == string.Empty)
                    {
                        Safe.Message(string.Concat("El campo ", control.Tag, " es obligatorio, para las fechas."), 2);
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Forma = new Frm_Busqueda(33);
            Forma.Pasado += new Frm_Busqueda.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void AsiganacionesDeLaLista(List<Ent_EncabezadoReclamos> ent_EncabezadoReclamos)
        {
            IdEncabezadoReclamos = ent_EncabezadoReclamos.FirstOrDefault().Id;
            txtNumOrden.Text = ent_EncabezadoReclamos.FirstOrDefault().NumeroOrden;

            dtpFechaRecepcion.Text = Convert.ToDateTime(ent_EncabezadoReclamos.FirstOrDefault().FechaRecepcion).ToShortDateString();
            dtpFechaReporte.Text = Convert.ToDateTime(ent_EncabezadoReclamos.FirstOrDefault().FechaReporte).ToShortDateString();

            txtLugar.Text = ent_EncabezadoReclamos.FirstOrDefault().LugarRecepcion;
            txtNumMuestras.Text = ent_EncabezadoReclamos.FirstOrDefault().NumeroMuestras.ToString();
            txtCliente.Text = ent_EncabezadoReclamos.FirstOrDefault().Cliente;
            encabezado = ent_EncabezadoReclamos.FirstOrDefault();

            reclamosDt = datosReclamos.getGridReclamos(IdEncabezadoReclamos);
            dtgvSellos.Columns.Clear();
            dtgvSellos.DataSource = reclamosDt;
            dtgvSellos.ReadOnly = true;
            btnSave.Tag = 2;
        }

        private void txtNumOrden_Leave(object sender, EventArgs e)
        {
            List<Ent_EncabezadoReclamos> ent_EncabezadoReclamos = datosReclamos.getReclamosEncabezadoPorNumOrden(txtNumOrden.Text);
            if (ent_EncabezadoReclamos.Count > 0) AsiganacionesDeLaLista(ent_EncabezadoReclamos);
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            List<Ent_EncabezadoReclamos> ent_EncabezadoReclamos = datosReclamos.getReclamosEncabezadoPorNombreCliente(txtCliente.Text);
            if (ent_EncabezadoReclamos.Count > 0) AsiganacionesDeLaLista(ent_EncabezadoReclamos);
        }

        private void FrmReclamos_Load(object sender, EventArgs e)
        {
            gbEncabezado.Enabled = true;
            btnAdicionar.Enabled = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarControles(gbEncabezado))
                return;

            gbEncabezado.Enabled = false;
            encabezado.NumeroOrden = txtNumOrden.Text;
            encabezado.FechaRecepcion = Convert.ToDateTime(dtpFechaRecepcion.Text);
            encabezado.FechaReporte = Convert.ToDateTime(dtpFechaReporte.Text);
            encabezado.Cliente = txtCliente.Text;
            encabezado.NumeroMuestras = Convert.ToInt32(txtNumMuestras.Text);
            encabezado.LugarRecepcion = txtLugar.Text;
            txtSellos.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dtpFechaRecepcion.Text = DateTime.Now.ToShortDateString();
            dtpFechaReporte.Text = DateTime.Now.ToShortDateString();

            txtNumOrden.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtNumMuestras.Text = string.Empty;
            txtLugar.Text = string.Empty;
            
            if (dtgvSellos.DataSource != null)
            {
                dtgvSellos.DataSource = null;
                dtgvSellos.Columns.Add("Sello", "Sello");
                dtgvSellos.Columns.Add("Humedad", "Humedad");
                dtgvSellos.Columns.Add("Au", "Au");
                dtgvSellos.Columns.Add("Ag", "Ag");
                dtgvSellos.Columns.Add("Weight", "Weight");
            }
            else dtgvSellos.Rows.Clear();

            encabezado = new Ent_EncabezadoReclamos();
            reclamos = new Ent_Reclamos();
            IdEncabezadoReclamos = 0;

            gbEncabezado.Enabled = true;
            btnAdicionar.Enabled = true;
            reclamosDt = null;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (gbEncabezado.Enabled == true)
                btnIngresar_Click(null, null);

            decimal au = txtAu.Text == string.Empty ? 0 : decimal.Parse(txtAu.Text.Replace(".", ","));
            decimal ag = txtAg.Text == string.Empty ? 0 : decimal.Parse(txtAg.Text.Replace(".", ","));
            decimal humedad = txtHumedad.Text == string.Empty ? 0 : decimal.Parse(txtHumedad.Text.Replace(".", ","));
            decimal weight = txtWeight.Text == string.Empty ? 0 : decimal.Parse(txtWeight.Text.Replace(".", ","));

            dtgvSellos.Rows.Add(txtSellos.Text, humedad, au, ag, weight);
            txtSellos.Text = string.Empty;
            txtHumedad.Text = string.Empty;
            txtAu.Text = string.Empty;
            txtAg.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtSellos.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int sello = 1;
            if (gbEncabezado.Enabled == true) btnIngresar_Click(null, null);
            if (!ValidarControles(gbEncabezado)) return;

            if (Convert.ToInt32(btnSave.Tag) == 2)
            {
                datosReclamos.ActualizarEncabezadosReclamos(encabezado);
                Safe.Message("Reclamo Actualizado con exito.", 3);
            }

            if (Convert.ToInt32(btnSave.Tag) == 1)
            {
                IdEncabezadoReclamos = datosReclamos.insertarEncabezadosReclamos(encabezado);

                if (dtgvSellos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow valores in dtgvSellos.Rows)
                    {
                        if (sello <= (dtgvSellos.Rows.Count - 1))
                        {
                            string strSello = string.Empty;
                            decimal humedad = 0, dAu = 0, dAg = 0, weight = 0;

                            strSello = valores.Cells[0].Value.ToString();
                            humedad = decimal.Parse(valores.Cells[1].Value.ToString(), NumberStyles.Currency);
                            dAu = decimal.Parse(valores.Cells[2].Value.ToString(), NumberStyles.Currency);
                            dAg = decimal.Parse(valores.Cells[3].Value.ToString(), NumberStyles.Currency);
                            weight = decimal.Parse(valores.Cells[4].Value.ToString(), NumberStyles.Currency);

                            reclamos = new Ent_Reclamos();
                            reclamos.IdEncabezadoReclamos = IdEncabezadoReclamos;
                            reclamos.Sello = strSello;
                            reclamos.Humedad = humedad;
                            reclamos.Au = dAu;
                            reclamos.Ag = dAg;
                            reclamos.Weigth = weight;

                            datosReclamos.insertarReclamos(reclamos);
                            sello++;
                        }
                    }
                }

                Safe.Message("Reclamo insertado con exito.", 3);
            }

            btnSave.Tag = 1;
            btnNew_Click(null, null);
        }

        private void txtNumMuestras_KeyPress(object sender, KeyPressEventArgs e)
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

        private static void ValidacionValorTeclado(KeyPressEventArgs e)
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
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '>')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '<')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtHumedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionValorTeclado(e);
        }    

        private void txtAu_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionValorTeclado(e);
        }

        private void txtAg_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionValorTeclado(e);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionValorTeclado(e);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            excel.CrearReporteExcelReclamos (encabezado, reclamosDt);
        }
    }
}

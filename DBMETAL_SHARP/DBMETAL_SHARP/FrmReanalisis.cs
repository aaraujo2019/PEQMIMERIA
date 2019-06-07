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
    public partial class FrmReanalisis : Form
    {
        private Ent_EncabezadoReanalisis encabezado = new Ent_EncabezadoReanalisis();
        private Ent_Reanalisis reanalisis = new Ent_Reanalisis();
        private DatosReanalisis datosReanalisis = new DatosReanalisis();
        private int IdEncabezadoReanalisis;
        private Frm_Busqueda Forma;
        private DataTable reanalisisDt;

        public FrmReanalisis()
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
                        if (control.Tag != "Descripción")
                        {
                            Safe.Message(string.Concat("El campo ", control.Tag, " es obligatorio."), 2);
                            return false;
                        }
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (gbEncabezado.Enabled == true)
            {
                btnIngresar_Click(null, null);
            }

            decimal au1 = txtAu1.Text == string.Empty ? 0 : decimal.Parse(txtAu1.Text.Replace(".", ","));
            decimal au2 = txtAu2.Text == string.Empty ? 0 : decimal.Parse(txtAu2.Text.Replace(".", ","));

            dtgvSellos.Rows.Add(txtSellos.Text, au1, au2);
            txtSellos.Text = string.Empty;
            txtAu1.Text = string.Empty;
            txtAu2.Text = string.Empty;
            txtSellos.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dtpFechaIngreso.Text = DateTime.Now.ToShortDateString();
            dthIngreso.Text = DateTime.Now.ToLongTimeString();

            dtpFechaReporte.Text = DateTime.Now.ToShortDateString();
            dthReporte.Text = DateTime.Now.ToLongTimeString();

            txtNumOrden.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtNumMuestras.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtTipoAnalisis.Text = string.Empty;
            txtNotas.Text = string.Empty;

            if (dtgvSellos.DataSource != null)
            {
                dtgvSellos.DataSource = null;
                dtgvSellos.Columns.Add("Sello", "Sello");
                dtgvSellos.Columns.Add("Au", "Au");
                dtgvSellos.Columns.Add("Au", "Au");
            }
            else dtgvSellos.Rows.Clear();

            encabezado = new Ent_EncabezadoReanalisis();
            reanalisis = new Ent_Reanalisis();
            IdEncabezadoReanalisis = 0;

            gbEncabezado.Enabled = true;
            btnAdicionar.Enabled = true;
            reanalisisDt = null;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarControles(gbEncabezado)) return;

            gbEncabezado.Enabled = false;
            encabezado.NumeroOrden = txtNumOrden.Text;
            encabezado.FechaIngreso = Convert.ToDateTime(string.Concat(dtpFechaIngreso.Text, " ", dthIngreso.Text));
            encabezado.FechaReporte = Convert.ToDateTime(string.Concat(dtpFechaReporte.Text, " ", dthReporte.Text));
            encabezado.Cliente = txtCliente.Text;
            encabezado.NumeroMuestras = Convert.ToInt32(txtNumMuestras.Text);
            encabezado.Descripcion = txtDescripcion.Text;
            encabezado.TipoAnalisis = txtTipoAnalisis.Text;
            txtSellos.Focus();
        }

        private void FrmReanalisis_Load(object sender, EventArgs e)
        {
            gbEncabezado.Enabled = true;
            btnAdicionar.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Forma = new Frm_Busqueda(32);
            Forma.Pasado += new Frm_Busqueda.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void txtNumOrden_Leave(object sender, EventArgs e)
        {
            List<Ent_EncabezadoReanalisis> ent_EncabezadoReanalises = datosReanalisis.getReanalisisEncabezadoPorNumOrden(txtNumOrden.Text);
            if (ent_EncabezadoReanalises.Count > 0) AsiganacionesDeLaLista(ent_EncabezadoReanalises);
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            List<Ent_EncabezadoReanalisis> ent_EncabezadoReanalises = datosReanalisis.getReanalisisEncabezadoPorNombreCliente(txtCliente.Text);
            if (ent_EncabezadoReanalises.Count > 0) AsiganacionesDeLaLista(ent_EncabezadoReanalises);
        }

        private void AsiganacionesDeLaLista(List<Ent_EncabezadoReanalisis> ent_EncabezadoReanalises)
        {
            IdEncabezadoReanalisis = ent_EncabezadoReanalises.FirstOrDefault().Id;
            txtNumOrden.Text = ent_EncabezadoReanalises.FirstOrDefault().NumeroOrden;

            dtpFechaIngreso.Text = Convert.ToDateTime(ent_EncabezadoReanalises.FirstOrDefault().FechaIngreso).ToShortDateString();
            dthIngreso.Text = Convert.ToDateTime(ent_EncabezadoReanalises.FirstOrDefault().FechaIngreso).ToLongTimeString();

            dtpFechaReporte.Text = Convert.ToDateTime(ent_EncabezadoReanalises.FirstOrDefault().FechaReporte).ToShortDateString();
            dthReporte.Text = Convert.ToDateTime(ent_EncabezadoReanalises.FirstOrDefault().FechaIngreso).ToLongTimeString();

            txtDescripcion.Text = ent_EncabezadoReanalises.FirstOrDefault().Descripcion;
            txtNumMuestras.Text = ent_EncabezadoReanalises.FirstOrDefault().NumeroMuestras.ToString();
            txtCliente.Text = ent_EncabezadoReanalises.FirstOrDefault().Cliente;
            txtTipoAnalisis.Text = ent_EncabezadoReanalises.FirstOrDefault().TipoAnalisis;
            txtNotas.Text = ent_EncabezadoReanalises.FirstOrDefault().Notas;
            encabezado = ent_EncabezadoReanalises.FirstOrDefault();

            reanalisisDt = datosReanalisis.getGridReanalisis(IdEncabezadoReanalisis);
            dtgvSellos.Columns.Clear();
            dtgvSellos.DataSource = reanalisisDt;
            dtgvSellos.ReadOnly = true;
            btnSave.Tag = 2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int sello = 1;
            if (gbEncabezado.Enabled == true) btnIngresar_Click(null, null);
            if (!ValidarControles(gbEncabezado)) return;

            if (Convert.ToInt32(btnSave.Tag) == 2)
            {
                datosReanalisis.ActualizarEncabezadosReanalisis(encabezado);
                Safe.Message("Reanálisis Actualizado con exito.", 3);
            }

            if (Convert.ToInt32(btnSave.Tag) == 1)
            {
                encabezado.Notas = txtNotas.Text;
                IdEncabezadoReanalisis = datosReanalisis.insertarEncabezadosReanalisis(encabezado);

                if (dtgvSellos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow valores in dtgvSellos.Rows)
                    {
                        if (sello <= (dtgvSellos.Rows.Count - 1))
                        {
                            string strSello = string.Empty;
                            decimal dAu1 = 0, dAu2 = 0;

                            strSello = valores.Cells[0].Value.ToString();
                            dAu1 = decimal.Parse(valores.Cells[1].Value.ToString(), NumberStyles.Currency);
                            dAu2 = decimal.Parse(valores.Cells[2].Value.ToString(), NumberStyles.Currency);
                            reanalisis = new Ent_Reanalisis();
                            reanalisis.IdEncabezadoReanalisis = IdEncabezadoReanalisis;
                            reanalisis.Sello = strSello;
                            reanalisis.Au1 = dAu1;
                            reanalisis.Au2 = dAu2;

                            datosReanalisis.insertarReanalisis(reanalisis);
                            sello++;
                        }
                    }
                }

                Safe.Message("Reanálisis insertado con exito.", 3);
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

        private void txtAu1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionValorTeclado(e);
        }

        private void txtAu2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionValorTeclado(e);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            excel.CrearReporteExcelReanalisis(encabezado, reanalisisDt);
        }
    }
}

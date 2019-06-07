using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReglasdeNegocio;
using System.Data.SqlClient;
using Entidades;

namespace DBMETAL_SHARP
{
    public partial class Frm_TenorSGS : Form
    {

        public Frm_TenorSGS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "\\DBMETAL\\";
            openFileDialog1.Filter = "Archivo de Excel(*.xls;*.xlsx)|*.XLS;*.XLSX";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                            this.TxbPath.Text = openFileDialog1.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            this.StsLabel1.Text = "Llenando Encabezado";
            this.StsProgressBar1.Value = 25;
            #region Llenando el Encabezado
            if (this.TxbPath.Text.Length != 0)
            {
                Ent_EncabezadoExcel Encabezado = LeerExcel.Encabezado(this.TxbPath.Text);
                this.TxbCliente.Text = Encabezado.Cliente;
                this.TxbOrden.Text = Encabezado.Orden;
                this.TxbLugar.Text = Encabezado.Lugar;
                this.TxbMuestras.Text = Encabezado.Muestras;
                this.TxbReferencia.Text = Encabezado.Referencia;
                this.TxbReporte.Text = Encabezado.Reporte;
                this.TxbRecepcion.Text = Encabezado.Recepcion;
            }
            #endregion

            this.StsLabel1.Text = "Llenando Tabla Principal";
            this.StsProgressBar1.Value = 50;
            #region Llenando el dataGridView Principal
            if (this.TxbPath.Text.Length != 0)
            {
                DataSet DS;
                DS = LeerExcel.Datos(this.TxbPath.Text);
                dataGridView1.DataSource = DS.Tables[0];
                dataGridView1.AutoResizeColumns();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = true;
                }
                this.chbMarcar.Checked = true;

                int I = 0;
                foreach (DataGridViewColumn Column in dataGridView1.Columns)
                {
                    if (I > 0)
                        Column.ReadOnly = true;
                    I += 1;
                }
            }
            else
                MessageBox.Show("Seleccione un archivo");
            #endregion

            this.StsLabel1.Text = "Llenando Tabla Resumen";
            this.StsProgressBar1.Value = 75;
            #region LLenado de DataGrid Auxiliar
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("IdPadre");
            dt.Columns.Add("Sello");
            dt.Columns.Add("Tenor");
            DataRow Row = dt.NewRow();
            string IdLim = "";
            string LimSupP = "";
            string G_TM = "";
            int Id = 1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string SelloP = Convert.ToString(row.Cells[2].Value);
                if (SelloP.IndexOf("A") + SelloP.IndexOf("B") + SelloP.IndexOf("C") == -3)
                {
                    IdLim = Convert.ToString(row.Cells[1].Value);
                    LimSupP = Convert.ToString(row.Cells[2].Value);
                    G_TM = Convert.ToString(row.Cells[5].Value);

                    Row["Id"] = Id;
                    Row["IdPadre"] = IdLim;
                    Row["Sello"] = LimSupP;
                    Row["Tenor"] = G_TM;
                    dt.Rows.Add(Row);
                    Row = dt.NewRow();
                    Id++;
                }
            }

            DataSet DataS = new DataSet();
            DataS.Tables.Add(dt);
            dataGridView2.DataSource = DataS.Tables[0];
            dataGridView2.AutoResizeColumns();

            try
            {
                foreach (DataGridViewRow Row2 in dataGridView2.Rows)
                {
                    string SelloConsulta = Convert.ToString(Row2.Cells[2].Value);
                    SqlParameter[] Parametros = new SqlParameter[1];
                    Parametros[0] = new SqlParameter("@Sello", SelloConsulta);

                    ConsultaEntidades Entidad = new ConsultaEntidades();
                    Ent_MinaSello Reader = new Ent_MinaSello();
                    Reader = Entidad.MinaSello("ConsultarSelloSGS", Parametros);

                    if (Reader.Consecutivo == 0)
                        dataGridView2.Rows[Row2.Index].DefaultCellStyle.BackColor = Color.SkyBlue;

                }
            }
            catch (Exception)
            {

                throw;
            }


            #endregion

            for (int i = 0; i < 100; i++)
                i += 1;
            this.StsProgressBar1.Value = 100;
            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Value = 0;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void chbMarcar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbMarcar.Checked)
            {
                int I = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = true;
                    I += 1;
                }
                if (I == 0)
                    this.chbMarcar.Checked = false;
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView1.AutoResizeColumns();
            dataGridView2.DataSource = "";
            dataGridView2.AutoResizeColumns();
            this.TxbCliente.Text = "";
            this.TxbOrden.Text = "";
            this.TxbLugar.Text = "";
            this.TxbMuestras.Text = "";
            this.TxbReferencia.Text = "";
            this.TxbReporte.Text = "";
            this.TxbRecepcion.Text = "";
            this.chbMarcar.Checked = false;
            this.TxbConsecutivo.Text = "0";
            this.TxbPath.Text = "";
            this.TxbTenor.Text = "";
            this.TxbTenorMedia.Text = "";
            this.TxbDesv.Text = "";
            this.TxbMina.Text = "";
            this.TxbFecha.Text = "";
            this.TxbConsecutivo.Focus();
            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Minimum = 0;
            this.StsProgressBar1.Maximum = 100;
            this.StsProgressBar1.Value = 0;

        }

        private void Frm_TenorSGS_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            #region Llenado los Textbox
            double SumTenor = 0.00;
            double Tenor1 = 0.00;
            double[] ArrayTenor;
            List<double> ListArray = new List<double>();

            string Sello = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            int TotalReg = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) & Convert.ToString(row.Cells[3].Value) == Sello)
                {
                    TotalReg += 1;
                    SumTenor = SumTenor + Convert.ToDouble(row.Cells[5].Value);
                    ListArray.Add(Convert.ToDouble(row.Cells[5].Value));
                    string SelloP = Convert.ToString(row.Cells[2].Value);
                    if (SelloP.IndexOf("A") + SelloP.IndexOf("B") + SelloP.IndexOf("C") == -3)
                        Tenor1 = Convert.ToDouble(row.Cells[5].Value);
                }
            }
            ArrayTenor = ListArray.ToArray();
            this.TxbTenor.Text = Tenor1.ToString().Trim();
            this.TxbTenorMedia.Text = Convert.ToString(SumTenor / TotalReg);
            this.TxbDesv.Text = Math.Round(Estadisticas.Desv(ArrayTenor), 4).ToString().Trim();
            this.TxbTenorMin.Text = ArrayTenor.Min().ToString().Trim();
            this.TxbTenorMax.Text = ArrayTenor.Max().ToString().Trim();
            #endregion

            #region Consulta al Server para traer datos del Sello

            try
            {
                string SelloConsulta = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                SqlParameter[] Parametros = new SqlParameter[1];
                Parametros[0] = new SqlParameter("@Sello", SelloConsulta);

                ConsultaEntidades Entidad = new ConsultaEntidades();
                Ent_MinaSello Reader = new Ent_MinaSello();
                Reader = Entidad.MinaSello("ConsultarSelloSGS", Parametros);

                this.TxbMina.Text = Reader.Mina + " ==> " + Reader.Consecutivo;
                this.TxbFecha.Text = Reader.Fecha.ToString().Trim();
            }
            catch (Exception Ext)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Ext.Message, "Error del Sistema...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            #region Llenado los Textbox
            double SumTenor = 0.00;
            double Tenor1 = 0.00;
            double[] ArrayTenor;
            List<double> ListArray = new List<double>();

            string Sello = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            int TotalReg = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) & Convert.ToString(row.Cells[3].Value) == Sello)
                {
                    TotalReg += 1;
                    SumTenor = SumTenor + Convert.ToDouble(row.Cells[5].Value);
                    ListArray.Add(Convert.ToDouble(row.Cells[5].Value));
                    string SelloP = Convert.ToString(row.Cells[2].Value);
                    if (SelloP.IndexOf("A") + SelloP.IndexOf("B") + SelloP.IndexOf("C") == -3)
                        Tenor1 = Convert.ToDouble(row.Cells[5].Value);
                }
            }
            ArrayTenor = ListArray.ToArray();
            this.TxbTenor.Text = Tenor1.ToString().Trim();
            this.TxbTenorMedia.Text = Convert.ToString(SumTenor / TotalReg);
            this.TxbDesv.Text = Math.Round(Estadisticas.Desv(ArrayTenor), 4).ToString().Trim();
            this.TxbTenorMin.Text = ArrayTenor.Min().ToString().Trim();
            this.TxbTenorMax.Text = ArrayTenor.Max().ToString().Trim();
            #endregion

            #region Consulta al Server para traer datos del Sello

            try
            {
                string SelloConsulta = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                SqlParameter[] Parametros = new SqlParameter[1];
                Parametros[0] = new SqlParameter("@Sello", SelloConsulta);

                ConsultaEntidades Entidad = new ConsultaEntidades();
                Ent_MinaSello Reader = new Ent_MinaSello();
                Reader = Entidad.MinaSello("ConsultarSelloSGS", Parametros);

                if (Reader.Consecutivo == 0)
                {
                    this.TxbMina.Text = Reader.Mina + " ==> " + Reader.Consecutivo;
                    this.TxbFecha.Text = "";
                }
                else
                {
                    this.TxbMina.Text = Reader.Mina + " ==> " + Reader.Consecutivo;
                    this.TxbFecha.Text = Reader.Fecha.ToShortDateString().Trim();
                }
            }
            catch (Exception Ext)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Ext.Message, "Error del Sistema...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            #region LLenado de DataGrid Auxiliar

            DataTable dt = new DataTable();
            dt.Columns.Add("Incluir");
            dt.Columns.Add("Id");
            dt.Columns.Add("SelloH");
            dt.Columns.Add("SelloP");
            dt.Columns.Add("Humedad");
            dt.Columns.Add("Tenor");
            dt.Columns.Add("Peso");
            dt.Columns.Add("Cliente");
            dt.Columns.Add("Orden");
            dt.Columns.Add("Muestra");
            dt.Columns.Add("Referencia");
            dt.Columns.Add("Lugar");
            dt.Columns.Add("Recepcion");
            dt.Columns.Add("Reporte");
            DataRow Row = dt.NewRow();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool incluir = Convert.ToBoolean(row.Cells[0].Value);
                int id = Convert.ToInt32(row.Cells[1].Value);
                string sellop = Convert.ToString(row.Cells[2].Value);
                string selloh = Convert.ToString(row.Cells[3].Value);
                double humedad = Convert.ToDouble(row.Cells[4].Value);
                double tenor = Convert.ToDouble(row.Cells[5].Value);
                int peso = Convert.ToInt32(row.Cells[6].Value);
                string cliente = this.TxbCliente.Text.Trim();
                string orden = this.TxbOrden.Text.Trim();
                string muestra = this.TxbMuestras.Text.Trim();
                string referencia = this.TxbReferencia.Text.Trim();
                string lugar = this.TxbLugar.Text.Trim();
                string recepcion = this.TxbRecepcion.Text.Trim();
                string reporte = this.TxbReporte.Text.Trim();

                Row["incluir"] = incluir;
                Row["Id"] = id;
                Row["Sellop"] = sellop;
                Row["Selloh"] = selloh;
                Row["Humedad"] = humedad;
                Row["Tenor"] = tenor;
                Row["Peso"] = peso;
                Row["Cliente"] = cliente;
                Row["Orden"] = orden;
                Row["Muestra"] = muestra;
                Row["Referencia"] = referencia;
                Row["Lugar"] = lugar;
                Row["Recepcion"] = recepcion;
                Row["Reporte"] = reporte;
                dt.Rows.Add(Row);
                Row = dt.NewRow();
            }
            #endregion

            #region Enviando Parametros para guardar Datos

            try
            {
                SqlParameter[] ParametroI = new SqlParameter[1];
                ParametroI[0] = new SqlParameter("@TablaExcelSGS", dt);

                GuardarDatos Guardar = new GuardarDatos();

                int Resultado = Guardar.Numerico("Sp_InsertDatosExcelSGS", ParametroI);
                this.TxbConsecutivo.Text = Resultado.ToString().Trim();

                MessageBox.Show("Registro Actualziado con Exito");
            }
            catch (Exception Ext)
            {
                MessageBox.Show(Ext.Message);
            }


            #endregion

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TxbConsecutivo_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlParameter[] Parametros_ConsultaUSuario = new SqlParameter[4];
            //    Parametros_ConsultaUSuario[0] = new SqlParameter("@Op", "Proveedor");
            //    Parametros_ConsultaUSuario[1] = new SqlParameter("@ParametroChar", this.TxbConsecutivo.Text.Trim());
            //    Parametros_ConsultaUSuario[2] = new SqlParameter("@ParametroInt", "0");
            //    Parametros_ConsultaUSuario[3] = new SqlParameter("@ParametroNuemric", "0");

            //    ConsultaEntidades Maestro = new ConsultaEntidades();
            //    Ent_tbl_Proveedores Reader = new Ent_tbl_Proveedores();

            //    Reader = Maestro.Proveedor("SpConsulta_Tablas", Parametros_ConsultaUSuario);
            //}
            //catch (Exception Ext)
            //{
            //    MessageBox.Show(Ext.Message);
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void TxbConsecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

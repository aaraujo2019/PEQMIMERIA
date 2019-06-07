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
    public partial class Frm_TenorSGS2 : Form
    {
        public Frm_TenorSGS2()
        {
            InitializeComponent();
        }


        #region Ejecutar PasarDato
        public void EjecutaPasarDato(string Dato)
        {
            this.btnNuevo.PerformClick();
            this.TxbConsecutivo.Text = Dato;
            TxbConsecutivo_Leave(null, null);
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
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
                DS = LeerExcel.DatosGQ15(this.TxbPath.Text);
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
                    if (I == 0)
                        Column.ReadOnly = false;
                    else
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
                if (SelloP.IndexOf("a") + SelloP.IndexOf("b") + SelloP.IndexOf("c") == -3)
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
            catch (Exception Ext)
            {

                MessageBox.Show(Ext.Message);
            }


            #endregion


            for (int i = 0; i < 1000; i++)
                i += 1;
            this.StsProgressBar1.Value = 100;
            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Value = 0;
        }

        private void btnPath_Click(object sender, EventArgs e)
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

        private void Frm_TenorSGS2_Load(object sender, EventArgs e)
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
                    SumTenor = SumTenor + Convert.ToDouble(row.Cells[4].Value);
                    ListArray.Add(Convert.ToDouble(row.Cells[4].Value));
                    string SelloP = Convert.ToString(row.Cells[2].Value);
                    if (SelloP.IndexOf("a") + SelloP.IndexOf("b") + SelloP.IndexOf("c") == -3)
                        Tenor1 = Convert.ToDouble(row.Cells[4].Value);
                }
            }
            ArrayTenor = ListArray.ToArray();
            this.TxbTenor.Text = Tenor1.ToString().Trim();
            //this.TxbTenorMedia.Text = Convert.ToString(SumTenor / TotalReg);
            this.TxbTenorMedia.Text = Estadisticas.Mediana(ListArray).ToString();
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
                    SumTenor = SumTenor + Convert.ToDouble(row.Cells[4].Value);
                    ListArray.Add(Convert.ToDouble(row.Cells[4].Value));
                    string SelloP = Convert.ToString(row.Cells[2].Value);
                    if (SelloP.IndexOf("a") + SelloP.IndexOf("b") + SelloP.IndexOf("c") == -3)
                        Tenor1 = Convert.ToDouble(row.Cells[4].Value);
                }
            }
            ArrayTenor = ListArray.ToArray();
            this.TxbTenor.Text = Tenor1.ToString().Trim();
            //this.TxbTenorMedia.Text = Convert.ToString(SumTenor / TotalReg);
            this.TxbTenorMedia.Text = Estadisticas.Mediana(ListArray).ToString();
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
            if (this.TxbConsecutivo.Text != "0")
                MessageBox.Show("No se puede guardar, reporte ya tiene un consecutivo generado.");
            else
            {
                #region LLenado de DataGrid Auxiliar

                DataTable dt = new DataTable();
                dt.Columns.Add("Incluir");
                dt.Columns.Add("Id");
                dt.Columns.Add("SelloH");
                dt.Columns.Add("SelloP");
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
                    double tenor = Convert.ToDouble(row.Cells[4].Value);
                    int peso = Convert.ToInt32(row.Cells[5].Value);
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

                    int Resultado = Guardar.Numerico("Sp_InsertDatosExcelSGS2", ParametroI);
                    this.TxbConsecutivo.Text = Resultado.ToString().Trim();

                    MessageBox.Show("Registros Actualziados con Exito");
                }
                catch (Exception Ext)
                {
                    MessageBox.Show(Ext.Message);
                }
                #endregion

                #region Guardando los Adjuntos

                try
                {
                    FileStream fs = new FileStream(this.TxbPath.Text, FileMode.Open);
                    //Creamos un array de bytes para almacenar los datos leídos por fs.
                    Byte[] data = new byte[fs.Length];
                    //Y guardamos los datos en el array data
                    fs.Read(data, 0, Convert.ToInt32(fs.Length));
                    fs.Close();

                    int PosInicialPath = this.TxbPath.Text.Trim().LastIndexOf("\\") + 1;
                    int PosFinalPath = this.TxbPath.Text.Trim().LastIndexOf(".") - 1;
                    int PosInicialExtension = this.TxbPath.Text.Trim().LastIndexOf(".");
                    int NumeroCaracteres = PosFinalPath - PosInicialPath + 1;
                    int CaracteresExtension = this.TxbPath.Text.Trim().Length - PosInicialExtension;

                    SqlParameter[] ParametrosEnt = new SqlParameter[7];
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                    ParametrosEnt[1] = new SqlParameter("@Orden", this.TxbOrden.Text.Trim());
                    ParametrosEnt[2] = new SqlParameter("@Ruta", this.TxbPath.Text.Trim());
                    ParametrosEnt[3] = new SqlParameter("@Nombre", this.TxbPath.Text.Substring(PosInicialPath, NumeroCaracteres));
                    ParametrosEnt[4] = new SqlParameter("@Archivo", data);
                    ParametrosEnt[5] = new SqlParameter("@Extension", this.TxbPath.Text.Substring(PosInicialExtension, CaracteresExtension));
                    ParametrosEnt[6] = new SqlParameter("@Maquina", Environment.MachineName);

                    ConsultaEntidades Maestro = new ConsultaEntidades();
                    GuardarDatos Guardar = new GuardarDatos();

                    bool Realizado = Guardar.booleano("Sp_Guardar_AdjuntosSGS", ParametrosEnt);
                    MessageBox.Show("Adjunto almacenado con Exito");
                }
                catch (Exception Ext)
                {
                    MessageBox.Show(Ext.Message);
                }


                #endregion
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "AdjuntosSGS");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbOrden.Text.Trim());
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                GuardarDatos Guardar = new GuardarDatos();
                Ent_AdjuntosSGS ReaderConsulta = new Ent_AdjuntosSGS();

                ReaderConsulta = Maestro.AdjuntosSGS("SpConsulta_Tablas", Parametros_Consulta);

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
                MessageBox.Show("Error..." + aa.Message); ;
            }
        }

        private void TxbConsecutivo_Leave(object sender, EventArgs e)
        {


            #region LLenado el DataGridView con los registros relacionados
            try
            {
                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "MuestrasSGS2_2");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", "");
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", this.TxbConsecutivo.Text.Trim());
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("LimSupPadre");
                dt.Columns.Add("LimSupHijo");
                dt.Columns.Add("G_TM");
                dt.Columns.Add("PesoMuestra");
                DataRow Registro = dt.NewRow();

                DataSet DS;
                DS = LlenarGrid.Datos("SpConsulta_Tablas", Parametros_Consulta);

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    this.TxbCliente.Text = row["Cliente"].ToString();
                    this.TxbReferencia.Text = row["Referencia"].ToString();
                    this.TxbRecepcion.Text = row["Recepcion"].ToString();
                    this.TxbReporte.Text = row["Reporte"].ToString();
                    this.TxbOrden.Text = row["Orden"].ToString();
                    this.TxbLugar.Text = row["Lugar"].ToString();
                    this.TxbMuestras.Text = row["Muestra"].ToString();
                    this.TxbPath.Text = row["Ruta"].ToString();

                    Registro["Id"] = row["Id"];
                    Registro["LimSupPadre"] = row["SelloP"];
                    Registro["LimSupHijo"] = row["SelloH"];
                    Registro["G_TM"] = row["Tenor"];
                    Registro["PesoMuestra"] = row["Peso"];
                    dt.Rows.Add(Registro);
                    Registro = dt.NewRow();
                }

                DataSet DSR = new DataSet();
                DSR.Tables.Add(dt);

                dataGridView1.DataSource = DSR.Tables[0];
                dataGridView1.AutoResizeColumns();

                int I = 0;
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    this.dataGridView1[0, I].Value = row["Incluir"];
                    I += 1;
                }

                foreach (DataGridViewColumn Column in dataGridView1.Columns)
                    Column.ReadOnly = true;



            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region LLenado de DataGrid Auxiliar

            DataTable date = new DataTable();
            date.Columns.Add("Id");
            date.Columns.Add("IdPadre");
            date.Columns.Add("Sello");
            date.Columns.Add("Tenor");
            DataRow Row = date.NewRow();
            string IdLim = "";
            string LimSupP = "";
            string G_TM = "";
            int Id = 1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string SelloP = Convert.ToString(row.Cells[2].Value);
                if (SelloP.IndexOf("a") + SelloP.IndexOf("b") + SelloP.IndexOf("c") == -3)
                {
                    IdLim = Convert.ToString(row.Cells[1].Value);
                    LimSupP = Convert.ToString(row.Cells[2].Value);
                    G_TM = Convert.ToString(row.Cells[5].Value);

                    Row["Id"] = Id;
                    Row["IdPadre"] = IdLim;
                    Row["Sello"] = LimSupP;
                    Row["Tenor"] = G_TM;
                    date.Rows.Add(Row);
                    Row = date.NewRow();
                    Id++;
                }
            }

            DataSet DataS = new DataSet();
            DataS.Tables.Add(date);
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
            catch (Exception Ext)
            {
                MessageBox.Show(Ext.Message);
            }
            #endregion


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.dataGridView1[2, 0].Value.ToString());

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[1];
                    ParametrosEnt[0] = new SqlParameter("@Orden", this.TxbOrden.Text);

                    ConsultaEntidades Maestro = new ConsultaEntidades();
                    GuardarDatos Guardar = new GuardarDatos();

                    Guardar.booleano("Sp_EliminarReporteSGS", ParametrosEnt);
                    MessageBox.Show("Reporte Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnNuevo.PerformClick();
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Frm_Consultas FrmConsultas = new Frm_Consultas(2);
            FrmConsultas.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            FrmConsultas.ShowDialog();
        }

    }
}

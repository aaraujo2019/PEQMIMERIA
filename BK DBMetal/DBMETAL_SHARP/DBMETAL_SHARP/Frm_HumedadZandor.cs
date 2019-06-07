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
    public partial class Frm_HumedadZandor : Form
    {
        public Frm_HumedadZandor()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView1.AutoResizeColumns();
            this.StsLabel1.Text = "Listo";
            this.TxbConsecutivo.Text = "0";
            this.TxbPath.Text = "";
            this.TxbFecha.Text = "";
            this.TxbMuestras.Text = "";
            this.TxbCliente.Text = "";
            this.TxbAuUnidad.Text = "";
            this.TxbAuMetodo.Text = "";
            this.TxbAgUnidad.Text = "";
            this.TxbAgMetodo.Text = "";
            this.TxbHumeUnidad.Text = "";
            this.TxbHumeMetodo.Text = "";
            this.TxbTipoMuestra.Text = "";
            this.TxbOrden.Text = "";
            this.TxbClienteOrden.Text = "";
            this.TxbNumMuestras.Text = "";
            this.TxbFechaMuestreo.Text = "";
            this.TxbFechaReporte.Text = "";
            this.TxbNotas.Text = "";
            this.TxbCodigoAnalisis.Text = "";
            this.TxbCodigoPreparacion.Text = "";
            this.TxbDescripcionAnalisis.Text = "";
            this.TxbDescripcionPreparacion.Text = "";
            this.StsProgressBar1.Value = 0;
            this.LblZC.Text = "";
            this.TxbConsecutivo.Focus();
        }

        private void Frm_HumedadZandor_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
        }


        #region Ejecutar PasarDato
        public void EjecutaPasarDato(string Dato)
        {
            this.btnNuevo.PerformClick();
            this.TxbConsecutivo.Text = Dato;
            TxbConsecutivo_Leave(null, null);
        }
        #endregion

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            this.StsLabel1.Text = "Llenando Encabezado";
            this.StsProgressBar1.Value = 50;
            #region Llenando el Encabezado
            if (this.TxbPath.Text.Length != 0)
            {
                Ent_EncabezadoHume Encabezado = LeerExcel.EncabezadoHume(this.TxbPath.Text);
                this.TxbFecha.Text = Encabezado.Fecha;
                this.TxbMuestras.Text = Encabezado.Muestras;
                this.TxbCliente.Text = Encabezado.Cliente;
                this.TxbAuUnidad.Text = Encabezado.AuUnidad;
                this.TxbAuMetodo.Text = Encabezado.AuMetodo;
                this.TxbAgUnidad.Text = Encabezado.AgUnidad;
                this.TxbAgMetodo.Text = Encabezado.AgMetodo;
                this.TxbHumeUnidad.Text = Encabezado.HumedadUnd;
                this.TxbHumeMetodo.Text = Encabezado.HumedadMet;
                this.TxbTipoMuestra.Text = Encabezado.TipoMuestras;
                this.TxbOrden.Text = Encabezado.Orden;
                this.TxbClienteOrden.Text = Encabezado.ClienteOrden;
                this.TxbNumMuestras.Text = Encabezado.NumMuestras;
                this.TxbFechaMuestreo.Text = Encabezado.FechaMuestreo;
                this.TxbFechaReporte.Text = Encabezado.FechaReporte;
                this.TxbNotas.Text = Encabezado.Notas;
                this.TxbCodigoPreparacion.Text = Encabezado.CodigoPrepa;
                this.TxbDescripcionPreparacion.Text = Encabezado.DescripcionPrepa;
                this.TxbCodigoAnalisis.Text = Encabezado.CodigoAnalisis;
                this.TxbDescripcionAnalisis.Text = Encabezado.DescripcionAnalisis;
                this.LblZC.Text = Encabezado.Orden;
            }
            #endregion



            this.StsLabel1.Text = "Llenando Tabla Principal";
            this.StsProgressBar1.Value = 75;
            #region Llenando el dataGridView Principal
            if (this.TxbPath.Text.Length != 0)
            {
                DataSet DS;
                DS = LeerExcel.DatoHumedad(this.TxbPath.Text);
                dataGridView1.DataSource = DS.Tables[0];
                dataGridView1.AutoResizeColumns();
            }
            else
                MessageBox.Show("Seleccione un archivo");
            #endregion

            this.StsLabel1.Text = "Marcando Sellos no reportados";
            this.StsProgressBar1.Value = 90;

            #region Marcando Sellos no reportados
            try
            {
                foreach (DataGridViewRow Row2 in dataGridView1.Rows)
                {
                    string SelloConsulta = Convert.ToString(Row2.Cells[1].Value);
                    SqlParameter[] Parametros = new SqlParameter[1];
                    Parametros[0] = new SqlParameter("@Sello", SelloConsulta);

                    ConsultaEntidades Entidad = new ConsultaEntidades();
                    Ent_MinaSello Reader = new Ent_MinaSello();
                    Reader = Entidad.MinaSello("ConsultarSelloSGS", Parametros);

                    if (Reader.Consecutivo == 0)
                        dataGridView1.Rows[Row2.Index].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception Ext)
            {

                MessageBox.Show(Ext.Message);
            }
            #endregion

            for (int i = 0; i < 10000; i++)
            {

            }

            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Value = 100;
            this.StsProgressBar1.Value = 0;



        }

        private void btnPath_Click(object sender, EventArgs e)
        {

            #region Limpiar textos
            dataGridView1.DataSource = "";
            dataGridView1.AutoResizeColumns();
            this.StsLabel1.Text = "Listo";
            this.TxbConsecutivo.Text = "0";
            this.TxbPath.Text = "";
            this.TxbFecha.Text = "";
            this.TxbMuestras.Text = "";
            this.TxbCliente.Text = "";
            this.TxbAuUnidad.Text = "";
            this.TxbAuMetodo.Text = "";
            this.TxbAgUnidad.Text = "";
            this.TxbAgMetodo.Text = "";
            this.TxbHumeUnidad.Text = "";
            this.TxbHumeMetodo.Text = "";
            this.TxbTipoMuestra.Text = "";
            this.TxbOrden.Text = "";
            this.TxbClienteOrden.Text = "";
            this.TxbNumMuestras.Text = "";
            this.TxbFechaMuestreo.Text = "";
            this.TxbFechaReporte.Text = "";
            this.TxbNotas.Text = "";
            this.TxbCodigoAnalisis.Text = "";
            this.TxbCodigoPreparacion.Text = "";
            this.TxbDescripcionAnalisis.Text = "";
            this.TxbDescripcionPreparacion.Text = "";
            this.StsProgressBar1.Value = 0;
            #endregion

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Consulta al Server para traer datos del Sello

            try
            {
                string SelloConsulta = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                SqlParameter[] Parametros = new SqlParameter[1];
                Parametros[0] = new SqlParameter("@Sello", SelloConsulta);

                ConsultaEntidades Entidad = new ConsultaEntidades();
                Ent_MinaSello Reader = new Ent_MinaSello();
                Reader = Entidad.MinaSello("ConsultarSelloSGS", Parametros);

                if (Reader.Consecutivo == 0)
                    this.StsLabel1.Text = " Sello No Encontrado";
                else
                    this.StsLabel1.Text = Reader.Mina + " ==> " + Reader.Consecutivo + " Fecha: " + Reader.Fecha.ToShortDateString();


            }
            catch (Exception Ext)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS: \n\n" + Ext.Message, "Error del Sistema...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            this.StsLabel1.Text = "Listo";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.TxbConsecutivo.Text != "0")
                MessageBox.Show("No se puede guardar, reporte ya tiene un consecutivo generado.");
            else
            {
                #region LLenado de DataGrid Auxiliar

                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Muestras");
                dt.Columns.Add("Cliente");
                dt.Columns.Add("AuUnidad");
                dt.Columns.Add("AuMetodo");
                dt.Columns.Add("AgUnidad");
                dt.Columns.Add("AgMetodo");
                dt.Columns.Add("HumedadUnd");
                dt.Columns.Add("HumedadMet");
                dt.Columns.Add("TipoMuestras");
                dt.Columns.Add("Orden");
                dt.Columns.Add("ClienteOrden");
                dt.Columns.Add("NumMuestras");
                dt.Columns.Add("FechaMuestreo");
                dt.Columns.Add("FechaReporte");
                dt.Columns.Add("Notas");
                dt.Columns.Add("CodigoPrepa");
                dt.Columns.Add("DescripcionPrepa");
                dt.Columns.Add("CodigoAnalisis");
                dt.Columns.Add("DescripcionAnalisis");
                dt.Columns.Add("Sello");
                dt.Columns.Add("Humedad");
                DataRow Row = dt.NewRow();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    string sello = Convert.ToString(row.Cells[1].Value);
                    double humedad = Convert.ToDouble(row.Cells[2].Value);

                    Row["Id"] = id;
                    Row["Fecha"] = this.TxbFecha.Text;
                    Row["Muestras"] = this.TxbMuestras.Text;
                    Row["Cliente"] = this.TxbCliente.Text;
                    Row["AuUnidad"] = this.TxbAuUnidad.Text;
                    Row["AuMetodo"] = this.TxbAuMetodo.Text;
                    Row["AgUnidad"] = this.TxbAgUnidad.Text;
                    Row["AgMetodo"] = this.TxbAgMetodo.Text;
                    Row["HumedadUnd"] = this.TxbHumeUnidad.Text;
                    Row["HumedadMet"] = this.TxbHumeMetodo.Text;
                    Row["TipoMuestras"] = this.TxbTipoMuestra.Text;
                    Row["Orden"] = this.TxbOrden.Text;
                    Row["ClienteOrden"] = this.TxbClienteOrden.Text;
                    Row["NumMuestras"] = this.TxbNumMuestras.Text;
                    Row["FechaMuestreo"] = this.TxbFechaMuestreo.Text;
                    Row["FechaReporte"] = this.TxbFechaReporte.Text;
                    Row["Notas"] = this.TxbNotas.Text;
                    Row["CodigoPrepa"] = this.TxbCodigoPreparacion.Text;
                    Row["DescripcionPrepa"] = this.TxbDescripcionPreparacion.Text;
                    Row["CodigoAnalisis"] = this.TxbCodigoAnalisis.Text;
                    Row["DescripcionAnalisis"] = this.TxbDescripcionAnalisis.Text;
                    Row["Sello"] = sello;
                    Row["Humedad"] = humedad;
                    dt.Rows.Add(Row);
                    Row = dt.NewRow();
                }
                #endregion

                #region Enviando Parametros para guardar Datos


                try
                {
                    SqlParameter[] ParametroI = new SqlParameter[1];
                    ParametroI[0] = new SqlParameter("@TablaExcelHumeZandor", dt);

                    GuardarDatos Guardar = new GuardarDatos();

                    int Resultado = Guardar.Numerico("Sp_InsertDatosExcelHumedadZandor", ParametroI);
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

        private void TxbConsecutivo_Leave(object sender, EventArgs e)
        {

            #region LLenado el DataGridView con los registros relacionados
            try
            {
                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "HumedadZandor");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", "");
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", this.TxbConsecutivo.Text.Trim());
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Sello");
                dt.Columns.Add("Humedad");
                DataRow Registro = dt.NewRow();

                DataSet DS;
                DS = LlenarGrid.Datos("SpConsulta_Tablas", Parametros_Consulta);

                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    this.TxbPath.Text = row["Ruta"].ToString().Trim();
                    this.TxbFecha.Text = row["Fecha"].ToString().Trim();
                    this.TxbMuestras.Text = row["Muestras"].ToString().Trim();
                    this.TxbCliente.Text = row["Cliente"].ToString().Trim();
                    this.TxbAuUnidad.Text = row["AuUnidad"].ToString().Trim();
                    this.TxbAuMetodo.Text = row["AuMetodo"].ToString().Trim();
                    this.TxbAgUnidad.Text = row["AgUnidad"].ToString().Trim();
                    this.TxbAgMetodo.Text = row["AgMetodo"].ToString().Trim();
                    this.TxbHumeUnidad.Text = row["HumedadUnd"].ToString().Trim();
                    this.TxbHumeMetodo.Text = row["HumedadMet"].ToString().Trim();
                    this.TxbTipoMuestra.Text = row["TipoMuestras"].ToString().Trim();
                    this.TxbOrden.Text = row["Orden"].ToString().Trim();
                    this.TxbClienteOrden.Text = row["ClienteOrden"].ToString().Trim();
                    this.TxbNumMuestras.Text = row["NumMuestras"].ToString().Trim();
                    this.TxbFechaMuestreo.Text = row["FechaMuestreo"].ToString().Trim();
                    this.TxbFechaReporte.Text = row["FechaReporte"].ToString().Trim();
                    this.TxbNotas.Text = row["Notas"].ToString().Trim();
                    this.TxbCodigoPreparacion.Text = row["CodigoPrepa"].ToString().Trim();
                    this.TxbDescripcionPreparacion.Text = row["DescripcionPrepa"].ToString().Trim();
                    this.TxbCodigoAnalisis.Text = row["CodigoAnalisis"].ToString().Trim();
                    this.TxbDescripcionAnalisis.Text = row["DescripcionAnalisis"].ToString().Trim();
                    this.LblZC.Text = row["Orden"].ToString().Trim();

                    Registro["Id"] = row["Id"];
                    Registro["Sello"] = row["Sello"];
                    Registro["Humedad"] = row["Humedad"];
                    dt.Rows.Add(Registro);
                    Registro = dt.NewRow();
                }

                DataSet DSR = new DataSet();
                DSR.Tables.Add(dt);

                dataGridView1.DataSource = DSR.Tables[0];
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

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

                    Guardar.booleano("Sp_EliminarHumedadZandor", ParametrosEnt);
                    MessageBox.Show("Reporte Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnNuevo.PerformClick();
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "SYSTEM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Frm_Consultas FrmConsultas = new Frm_Consultas(3);
            FrmConsultas.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            FrmConsultas.ShowDialog();
        }
    }
}

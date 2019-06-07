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
    public partial class Frm_TenorZandor : Form
    {
        public Frm_TenorZandor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPath_Click(object sender, EventArgs e)
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
            this.StsProgressBar1.Value = 20;
            this.StsLabel1.Text = "Llenando Tabla Principal";
            this.StsProgressBar1.Value = 20;
            try
            {
                this.StsProgressBar1.Value = 33;
                this.StsLabel1.Text = "Llenando Tabla Principal";
                this.StsProgressBar1.Value = 33;

                #region Llenando el dataGridView Principal
                if (this.TxbPath.Text.Length != 0)
                {
                    DataSet DS;
                    DS = LeerExcel.TenorZandor(this.TxbPath.Text);
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

                this.StsProgressBar1.Value = 69;
                this.StsLabel1.Text = "Llenando Tabla Con Registros que se actualizaran";
                this.StsProgressBar1.Value = 69;

                

                #region LLenado el DataGridView con los registros relacionados

                #region LLenado de DataTable que se enviara en el SP

                DataTable dt = new DataTable();
                dt.Columns.Add("Incluir");
                dt.Columns.Add("Id");
                dt.Columns.Add("Sello");
                dt.Columns.Add("Tenor");
                dt.Columns.Add("Humedad");

                DataRow Row = dt.NewRow();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool incluir = Convert.ToBoolean(row.Cells[0].Value);
                    int id = Convert.ToInt32(row.Cells[1].Value);
                    string sello = Convert.ToString(row.Cells[2].Value);
                    double tenor = Convert.ToDouble(row.Cells[3].Value);
                    double humedad = Convert.ToDouble(row.Cells[4].Value);


                    Row["incluir"] = incluir;
                    Row["Id"] = id;
                    Row["Sello"] = sello;
                    Row["Tenor"] = tenor;
                    Row["Humedad"] = humedad;
                    dt.Rows.Add(Row);
                    Row = dt.NewRow();
                }
                #endregion

                SqlParameter[] Parametros_Consulta1 = new SqlParameter[3];
                Parametros_Consulta1[0] = new SqlParameter("@Op", "S");
                Parametros_Consulta1[1] = new SqlParameter("@Consecutivo", "0");
                Parametros_Consulta1[2] = new SqlParameter("@TablaExcelPM", dt);

                DataSet DataS;
                DataS = LlenarGrid.Datos("Sp_ConsultaDatosPM", Parametros_Consulta1);

                dataGridView2.DataSource = DataS.Tables[0];
                dataGridView2.AutoResizeColumns();

                this.StsProgressBar1.Value = 90;
                this.StsLabel1.Text = "Llenando Tabla Con Registros que NO se actualizaran";
                this.StsProgressBar1.Value = 90;

                SqlParameter[] Parametros_Consulta2 = new SqlParameter[3];
                Parametros_Consulta2[0] = new SqlParameter("@Op", "N");
                Parametros_Consulta2[1] = new SqlParameter("@Consecutivo", "0");
                Parametros_Consulta2[2] = new SqlParameter("@TablaExcelPM", dt);

                DataSet DataN;
                DataN = LlenarGrid.Datos("Sp_ConsultaDatosPM", Parametros_Consulta2);

                dataGridView3.DataSource = DataN.Tables[0];
                dataGridView3.AutoResizeColumns();
            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                #endregion


            this.StsProgressBar1.Value = 75;
            this.StsProgressBar1.Value = 100;
            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Value = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.TxbPath.Text = "";
            this.TxbConsecutivo.Text = "";
            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Minimum = 0;
            this.StsProgressBar1.Maximum = 100;
            this.StsProgressBar1.Value = 0;
            dataGridView1.DataSource = "";
            dataGridView1.AutoResizeColumns();
            dataGridView2.DataSource = "";
            dataGridView2.AutoResizeColumns();
            dataGridView3.DataSource = "";
            dataGridView3.AutoResizeColumns();
            this.TxbConsecutivo.Focus();
        }

        private void Frm_TenorZandor_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.StsLabel1.Text = "Guardando...";
            this.StsProgressBar1.Value = 50;
            #region LLenado de DataTable que se enviara en el SP

            DataTable dt = new DataTable();
            dt.Columns.Add("Incluir");
            dt.Columns.Add("Id");
            dt.Columns.Add("Sello");
            dt.Columns.Add("Tenor");
            dt.Columns.Add("Humedad");

            DataRow Row = dt.NewRow();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool incluir = Convert.ToBoolean(row.Cells[0].Value);
                int id = Convert.ToInt32(row.Cells[1].Value);
                string sello = Convert.ToString(row.Cells[2].Value);
                double tenor = Convert.ToDouble(row.Cells[3].Value);
                double humedad = Convert.ToDouble(row.Cells[4].Value);


                Row["incluir"] = incluir;
                Row["Id"] = id;
                Row["Sello"] = sello;
                Row["Tenor"] = tenor;
                Row["Humedad"] = humedad;
                dt.Rows.Add(Row);
                Row = dt.NewRow();
            }
            #endregion

            #region Enviando Parametros para guardar Datos

            try
            {
                SqlParameter[] ParametroI = new SqlParameter[1];
                ParametroI[0] = new SqlParameter("@TablaExcelPM", dt);

                GuardarDatos Guardar = new GuardarDatos();

                int Resultado = Guardar.Numerico("Sp_InsertDatosPM", ParametroI);
                this.TxbConsecutivo.Text = Resultado.ToString().Trim();

                MessageBox.Show("Registro Actualziado con Exito");
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
                ParametrosEnt[1] = new SqlParameter("@Orden", this.TxbConsecutivo.Text.Trim());
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

            this.StsLabel1.Text = "Guardando...";
            this.StsProgressBar1.Value = 100;

            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Value = 0;
        }

        private void TxbConsecutivo_Leave(object sender, EventArgs e)
        {

            try
            {
                this.StsProgressBar1.Value = 20;
                this.StsLabel1.Text = "Llenando Tabla Principal";
                this.StsProgressBar1.Value = 20;

                #region LLenado el DataGridView1 

                DataTable dtp = new DataTable();
                dtp.Columns.Add("Incluir");
                dtp.Columns.Add("Id");
                dtp.Columns.Add("Sello");
                dtp.Columns.Add("Tenor");
                dtp.Columns.Add("Humedad");


                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Sello");
                dt.Columns.Add("Tenor");
                dt.Columns.Add("Humedad");
                DataRow Registro = dt.NewRow();

                SqlParameter[] Parametros_Consulta1 = new SqlParameter[3];
                Parametros_Consulta1[0] = new SqlParameter("@Op", "1");
                Parametros_Consulta1[1] = new SqlParameter("@Consecutivo", 1);
                Parametros_Consulta1[2] = new SqlParameter("@TablaExcelPM", dtp);

                DataSet DataS;
                DataS = LlenarGrid.Datos("Sp_ConsultaDatosPM", Parametros_Consulta1);

                foreach (DataRow row in DataS.Tables[0].Rows)
                {

                    Registro["Id"] = row["Id"];
                    Registro["Sello"] = row["Sello"];
                    Registro["Tenor"] = row["Tenor"];
                    Registro["Humedad"] = row["Humedad"];
                    dt.Rows.Add(Registro);
                    Registro = dt.NewRow();
                }

                DataSet DSR = new DataSet();
                DSR.Tables.Add(dt);

                dataGridView1.DataSource = DSR.Tables[0];
                dataGridView1.AutoResizeColumns();

                int I = 0;
                foreach (DataRow row in DataS.Tables[0].Rows)
                {
                    this.dataGridView1[0, I].Value = row["Incluir"];
                    I += 1;
                }
                #endregion


                this.StsProgressBar1.Value = 61;
                this.StsLabel1.Text = "Llenando Tabla Secundaria con registros que se actualizaron";
                this.StsProgressBar1.Value = 61;

                #region Lenado el DataGridView2

                SqlParameter[] Parametros_Consulta2 = new SqlParameter[3];
                Parametros_Consulta2[0] = new SqlParameter("@Op", "2");
                Parametros_Consulta2[1] = new SqlParameter("@Consecutivo", this.TxbConsecutivo.Text.Trim());
                Parametros_Consulta2[2] = new SqlParameter("@TablaExcelPM", dtp);

                DataSet DataS1;
                DataS1 = LlenarGrid.Datos("Sp_ConsultaDatosPM", Parametros_Consulta2);

                dataGridView2.DataSource = DataS1.Tables[0];
                dataGridView2.AutoResizeColumns();
                #endregion

                this.StsProgressBar1.Value = 100;
                this.StsLabel1.Text = "Llenando Tabla Terciaria con registros que NO se actualizaron";
                this.StsProgressBar1.Value = 100;

                #region Lenado el DataGridView3
                SqlParameter[] Parametros_Consulta3 = new SqlParameter[3];
                Parametros_Consulta3[0] = new SqlParameter("@Op", "3");
                Parametros_Consulta3[1] = new SqlParameter("@Consecutivo", this.TxbConsecutivo.Text.Trim());
                Parametros_Consulta3[2] = new SqlParameter("@TablaExcelPM", dtp);

                DataSet DataN;
                DataN = LlenarGrid.Datos("Sp_ConsultaDatosPM", Parametros_Consulta3);

                dataGridView3.DataSource = DataN.Tables[0];
                dataGridView3.AutoResizeColumns();

                #endregion

            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.StsProgressBar1.Value = 0;
            this.StsLabel1.Text = "Listo";
            this.StsProgressBar1.Value = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                DataTable dtp = new DataTable();
                dtp.Columns.Add("Incluir");
                dtp.Columns.Add("Id");
                dtp.Columns.Add("Sello");
                dtp.Columns.Add("Tenor");
                dtp.Columns.Add("Humedad");

                SqlParameter[] Parametros_Consulta = new SqlParameter[3];
                Parametros_Consulta[0] = new SqlParameter("@Op", "D");
                Parametros_Consulta[1] = new SqlParameter("@Consecutivo", this.TxbConsecutivo.Text.Trim());
                Parametros_Consulta[2] = new SqlParameter("@TablaExcelPM", dtp);


                LlenarGrid.Datos("Sp_ConsultaDatosPM", Parametros_Consulta);
                MessageBox.Show("Reporte Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnNuevo.PerformClick();
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "AdjuntosSGS");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbConsecutivo.Text.Trim());
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
    }
}

using Entidades;
using OfficeOpenXml;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_CargaAnalisis : Form
    {
        #region Variables
        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }

        public List<Roles_Permisos> Permission;
        public Frm_CargaAnalisis()
        {
            InitializeComponent();
        }
        public Frm_CargaAnalisis(string User)
        {
            InitializeComponent();
            this.Usuario = User.Trim();

            DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", User.ToString().Trim(), this.Name);

            this.Permission = DBMETAL_SHARP.Common.Common.Permissions;

            ValidatePermission(this.Controls);

        }
        #endregion Variables

        #region Variables
        public int typeFile { get; set; }
        public string valueMedia = string.Empty;
        #endregion Variables

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

        #region Eventos
        private void CmdExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "Seleccionar archivos";
            openFD.Filter = "Todos los archivos  (*.xls) | *.xlsx;*.xls";
            openFD.Multiselect = false;
            openFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                Txtruta.Text = openFD.FileName;
            }
            if (Txtruta.Text == "")
            {

            }
            else
            {
                try
                {
                    Cargar(dtgExcel, Txtruta.Text);

                    if (string.IsNullOrEmpty(this.IpLocal))
                        this.IpLocal = DireccionIP.Local();

                    if (string.IsNullOrEmpty(this.IpPublica))
                        this.IpPublica = DireccionIP.Publica();

                    if (string.IsNullOrEmpty(this.SerialHDD))
                        this.SerialHDD = DireccionIP.SerialNumberDisk();

                    if (string.IsNullOrEmpty(this.Usuario))
                        this.Usuario = DireccionIP.SerialNumberDisk();

                    LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Carga Analisis Laboratorio, Archivo " + openFD.FileName, "Movimiento Muestreo creado");

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        internal void Cargar(DataGridView dgView, string SLibro)
        {
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + SLibro + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'");
                MyConnection.Open();

                System.Data.DataTable dt = MyConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string sheetName = string.Empty;
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!dt.Rows[i]["TABLE_NAME"].ToString().ToUpper().Trim().Contains("PRINT_TITLES"))
                        {
                            sheetName = dt.Rows[i]["TABLE_NAME"].ToString().Trim();
                            break;
                        }
                    }
                }
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetName + "]", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                dgView.DataSource = DtSet.Tables[0];
                dgView.AutoResizeColumns();
                MyConnection.Close();

                GuardarDatos Guardar = new GuardarDatos();


                if (DtSet.Tables[0].Rows[3][1].ToString().Trim().ToUpper().Contains("PEQUEÑA MINERÍA"))
                {

                    try
                    {

                        LblTitulos.Text = "Análisis Químico Pequeña Minería";

                        typeFile = 0;
                        string sellocontrolCopia = string.Empty;
                        bool contiene = true;
                        string idLab = DtSet.Tables[0].Rows[1][1].ToString().Trim();
                        for (int i = 10; i < DtSet.Tables[0].Rows.Count; i++)
                        {
                            string selloControl = DtSet.Tables[0].Rows[i][0].ToString().Trim();

                            if (String.IsNullOrEmpty(sellocontrolCopia))
                            {
                                contiene = true;
                                sellocontrolCopia = selloControl;
                            }
                            else
                            {
                                if (!selloControl.Contains(sellocontrolCopia))
                                {
                                    contiene = false;
                                    sellocontrolCopia = selloControl;
                                }
                            }

                            System.Globalization.NumberStyles style;
                            System.Globalization.CultureInfo culture;

                            style = System.Globalization.NumberStyles.Number | System.Globalization.NumberStyles.AllowCurrencySymbol;
                            culture = System.Globalization.CultureInfo.CreateSpecificCulture("ES-CO");

                            try
                            {

                                //MessageBox.Show(selloControl, "selloControl");
                                if (!String.IsNullOrEmpty(selloControl) && !selloControl.ToUpper().Trim().Contains("BLANK_PREP") && !selloControl.ToUpper().Trim().Contains("STD") && !selloControl.ToUpper().Trim().Contains("STD") && !selloControl.ToUpper().Trim().Contains("BLANK"))
                                {
                                    //MessageBox.Show("Ingress");
                                    decimal humedad = 0, au = 0, ag = 0, peso = 0;
                                    if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][2].ToString().Trim()))
                                    {
                                        //Forma de capturar decimales y enterior con la cultura de la maquina
                                        //var clone = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.InvariantCulture.Clone();
                                        //clone.NumberFormat.NumberDecimalSeparator = ",";
                                        //clone.NumberFormat.NumberGroupSeparator = ".";
                                        //string s = DtSet.Tables[0].Rows[i][2].ToString().Trim();
                                        //decimal d = decimal.Parse(s, clone);

                                        //MessageBox.Show(DtSet.Tables[0].Rows[i][2].ToString().Trim(), "Mensaje2.1.1");
                                        if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][2].ToString().Trim().Replace(".", ","), style, culture, out humedad))
                                        {
                                            //MessageBox.Show(humedad.ToString(), "MensajeCC2.");

                                            humedad = decimal.Parse(DtSet.Tables[0].Rows[i][2].ToString().Trim());//.Replace(".", ",").Substring(1, DtSet.Tables[0].Rows[i][2].ToString().Length-1));
                                                                                                                  //MessageBox.Show(humedad.ToString(), "MensajeCC2.1.1.2");

                                        }
                                        //MessageBox.Show(humedad.ToString(), "Mensaje2.1.3");
                                    }

                                    if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][3].ToString().Trim()))
                                    {
                                        //MessageBox.Show(DtSet.Tables[0].Rows[i][3].ToString().Trim(), "Mensaje2.1.4.0");

                                        if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][3].ToString().Trim().Replace(".", ","), style, culture, out au))
                                        {
                                            au = decimal.Parse(DtSet.Tables[0].Rows[i][3].ToString().Trim());//.Replace(".", ",").Substring(1, DtSet.Tables[0].Rows[i][3].ToString().Length - 1), style, culture);

                                            //MessageBox.Show(au.ToString(), "Mensaje2.1.4.1");

                                        }
                                    }
                                    //MessageBox.Show(au.ToString(), "Mensaje2.1.4.2");


                                    if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][4].ToString().Trim()))
                                        if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][4].ToString().Trim().Replace(".", ","), style, culture, out ag))

                                            ag = decimal.Parse(DtSet.Tables[0].Rows[i][4].ToString().Trim());//.Replace(".", ",").Substring(1, DtSet.Tables[0].Rows[i][4].ToString().Length - 1));

                                    //MessageBox.Show(ag.ToString(), "Mensaje2.1.5");

                                    if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][5].ToString().Trim()))

                                    {
                                        if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][5].ToString().Trim().Replace(".", ","), style, culture, out peso))
                                        {
                                            peso = decimal.Parse(DtSet.Tables[0].Rows[i][5].ToString().Trim());//.Replace(".", ",").Substring(1, DtSet.Tables[0].Rows[i][5].ToString().Length - 1));
                                        }
                                        //MessageBox.Show(peso.ToString(), "Mensaje2.1.6");

                                    }

                                    //MessageBox.Show("Mensaje2.5");

                                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_DetalleExcelPM("", selloControl, humedad, au, ag, peso, "1", idLab);

                                    Guardar.Numerico("Sp_Moficiar_AnaQuiPM", ParamSQl);

                                    //MessageBox.Show("Mensaje2.6");

                                    if (humedad > 0)
                                    {
                                        ParamSQl = GuardarDatos.Parametros_ToneladaSeca(selloControl, humedad);
                                        Guardar.Numerico("Sp_Moficiar_ToneladasSeca_MuestreoPM", ParamSQl);
                                    }
                                    //MessageBox.Show("Mensaje2.7");

                                }
                            }
                            catch (Exception ms)
                            {
                                MessageBox.Show(string.Concat("Sello:", selloControl, " EX:", ms.Message), "selloControl");
                                throw;
                            }
                            //else
                            //    break;
                        }
                        MessageBox.Show("Importacion Finalizada");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    if (DtSet.Tables[0].Rows[15][3].ToString().Trim().ToUpper().Contains("HUM"))
                    {
                        MessageBox.Show("Mensaje3");

                        LblTitulos.Text = "Humedad Laboratorio Zandor";
                        typeFile = 2;
                        for (int i = 45; i < DtSet.Tables[0].Rows.Count; i++)
                        {
                            string selloControl = DtSet.Tables[0].Rows[i][0].ToString().Replace(" ", "");

                            if (!String.IsNullOrEmpty(selloControl))
                            {
                                decimal humedad = 0;
                                if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][3].ToString().Trim()))
                                    if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][3].ToString().Trim().Replace(".", ","), out humedad))

                                        humedad = decimal.Parse(DtSet.Tables[0].Rows[i][3].ToString().Trim().Replace(".", ",").Substring(1, DtSet.Tables[0].Rows[i][3].ToString().Length - 1));

                                SqlParameter[] ParamSQl = GuardarDatos.Parametros_DetalleExcelHumedad("", selloControl, humedad, "1");

                                Guardar.Numerico("Sp_Moficiar_AnaQuiHum", ParamSQl);
                            }
                            else
                                break;
                        }
                        MessageBox.Show("Importacion Finalizada");
                    }
                    else
                    {
                        if (DtSet.Tables[0].Rows[0][0].ToString().Trim().ToUpper().Contains("LABORATORIO") && DtSet.Tables[0].Rows[2][0].ToString().Trim().ToUpper().Contains("REPORTE DE ANÁLISIS QUÍMICO"))
                        {
                            MessageBox.Show("Mensaje4");

                            LblTitulos.Text = "Analisis Laboratorio Químico Zandor Capital";
                            typeFile = 1;
                            for (int i = 46; i < DtSet.Tables[0].Rows.Count; i++)
                            {
                                string selloControl = DtSet.Tables[0].Rows[i][0].ToString().Replace(" ", "");

                                if (!String.IsNullOrEmpty(selloControl))
                                {
                                    decimal au = 0, augr = 0;
                                    if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][1].ToString().Trim()))
                                        if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][1].ToString().Trim().Replace(".", ","), out au))

                                            au = decimal.Parse(DtSet.Tables[0].Rows[i][1].ToString().Trim().Replace(".", ",").Substring(1, DtSet.Tables[0].Rows[i][1].ToString().Length - 1));


                                    if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][2].ToString().Trim()))
                                        if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][2].ToString().Trim().Replace(".", ","), out augr))

                                            augr = decimal.Parse(DtSet.Tables[0].Rows[i][2].ToString().Replace(".", ",").Trim().Substring(1, DtSet.Tables[0].Rows[i][2].ToString().Length - 1));


                                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_DetalleExcelZandor("", selloControl, au, augr, "1");

                                    Guardar.Numerico("Sp_Moficiar_AnaQuiZandor", ParamSQl);
                                }
                                else
                                    break;
                            }

                            MessageBox.Show("Importacion Finalizada");
                        }
                        else
                        {
                            if (DtSet.Tables[0].Rows[2][0].ToString().Trim().ToUpper().Contains("REPORTE DE ANÁLISIS QUÍMICO") || DtSet.Tables[0].Rows[1][0].ToString().Trim().ToUpper().Contains("REPORTE DE ANÁLISIS QUÍMICO"))
                            {
                                MessageBox.Show("Mensaje5");

                                LblTitulos.Text = "Reporte de Análisis Químico";
                                typeFile = 1;
                                for (int i = 48; i < DtSet.Tables[0].Rows.Count; i++)
                                {
                                    string selloControl = DtSet.Tables[0].Rows[i][0].ToString().Replace(" ", "");

                                    if (!selloControl.ToUpper().Contains("DUPLIC"))
                                    {
                                        if (selloControl.Contains("+") || selloControl.Contains("-"))
                                        {
                                            int valueSeparator = selloControl.IndexOf("(");

                                            selloControl = selloControl.Substring(0, valueSeparator);

                                            if (DtSet.Tables[0].Rows[i][0].ToString().Contains("-"))
                                                selloControl = string.Concat(selloControl, "A");

                                            if (!String.IsNullOrEmpty(selloControl))
                                            {
                                                decimal au = 0, augr = 0;
                                                if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][1].ToString().Trim()))
                                                    if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][1].ToString().Trim().Replace(",", "."), out au))

                                                        au = decimal.Parse(DtSet.Tables[0].Rows[i][1].ToString().Trim().Replace(".", ",").Substring(0, DtSet.Tables[0].Rows[i][1].ToString().Length));


                                                SqlParameter[] ParamSQl = GuardarDatos.Parametros_DetalleExcelReanalisis(selloControl, au);

                                                Guardar.Numerico("Sp_Moficiar_AnaPMR", ParamSQl);
                                            }
                                            else
                                                break;
                                        }
                                        else
                                        {
                                            if (!String.IsNullOrEmpty(selloControl))
                                            {
                                                decimal au = 0, augr = 0;
                                                if (!String.IsNullOrEmpty(DtSet.Tables[0].Rows[i][1].ToString().Trim()))
                                                    if (!Decimal.TryParse(DtSet.Tables[0].Rows[i][1].ToString().Trim().Replace(".", ","), out au))

                                                        au = decimal.Parse(DtSet.Tables[0].Rows[i][1].ToString().Trim().Replace(".", ",").Substring(1, DtSet.Tables[0].Rows[i][1].ToString().Length - 1));


                                                SqlParameter[] ParamSQl = GuardarDatos.Parametros_DetalleExcelReanalisis(selloControl, au);

                                                Guardar.Numerico("Sp_Moficiar_AnaPMR", ParamSQl);
                                            }
                                            else
                                                break;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }

            catch (Exception oMsg)
            {
                MessageBox.Show(oMsg.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }
        #endregion Eventos

        #region Metodos
        public DataTable getDataTableFromExcel(string path)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                bool hasHeader = true;
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    var row = tbl.NewRow();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                    tbl.Rows.Add(row);
                }

                return tbl;
            }
        }
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

            //return (sortedArray[mid] + value2) * 0.5;
        }

        decimal Median(decimal[] xs)
        {
            var ys = xs.OrderBy(x => x).ToList();
            double mid = (ys.Count - 1) / 2.0;
            return (ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2;
        }
        #endregion Metodos

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }
    }
}

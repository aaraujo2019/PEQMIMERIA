using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ReglasdeNegocio;
using System.IO;
using System.Diagnostics;

namespace Reportes
{
    public partial class Frm_LiquidacionMinera : Form
    {
        public Frm_LiquidacionMinera()
        {
            InitializeComponent();
        }
        public int Periodo { get; set; }
        public string Mina { get; set; }
        public string NombreMina { get; set; }
        public byte[] Logo1 { get; set; }
        public byte[] Logo2 { get; set; }

        private void Frm_LiquidacionMinera_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBMETALDataSet.Rpt_LiquidacionMinera' Puede moverla o quitarla según sea necesario.
            this.DBMETALDataSet.EnforceConstraints = false;
            this.Rpt_LiquidacionMineraTableAdapter.Fill(this.DBMETALDataSet.Rpt_LiquidacionMinera, this.Periodo, this.Mina);

            this.reportViewer1.LocalReport.EnableExternalImages = true;
            string fichero = Convert.ToString(Path.GetTempPath()) + "Logo1.png";
            using (FileStream archivoStream = new FileStream(fichero, FileMode.Create))
            {
                archivoStream.Write(this.Logo1, 0, this.Logo1.Length);
                archivoStream.Close();
            }
            ReportParameter ParamLogo1 = new ReportParameter();
            ParamLogo1.Name = "Logo1";
            ParamLogo1.Values.Add(@"file:///" + fichero);
            reportViewer1.LocalReport.SetParameters(ParamLogo1);

            fichero = Convert.ToString(Path.GetTempPath()) + "Logo2.png";
            using (FileStream archivoStream = new FileStream(fichero, FileMode.Create))
            {
                archivoStream.Write(this.Logo2, 0, this.Logo2.Length);
                archivoStream.Close();
            }
            ReportParameter ParamLogo2 = new ReportParameter();

            ParamLogo2.Name = "Logo2";
            ParamLogo2.Values.Add(@"file:///" + fichero);
            reportViewer1.LocalReport.SetParameters(ParamLogo2);

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(CargarSubReporte);

            this.GenerateReportPdf(NombreMina);
            this.reportViewer1.RefreshReport();
        }

        void CargarSubReporte(object sender, SubreportProcessingEventArgs e)
        {
            DataSet DS = DatosEntidad.Dataset("LiquidacionGrafica", this.Mina, this.Periodo, 0.00);
            //e.DataSources.Add(new ReportDataSource("DataSetSubReporte", (object)DBMETALDataSet.Rpt_LiquidacionMineraGrafica));
            e.DataSources.Add(new ReportDataSource("DataSetSubReporte", DS.Tables[0]));
        }

        private void GenerateReportPdf(string File)
        {
            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);

                using (FileStream fs = new FileStream(File, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }





    }
}

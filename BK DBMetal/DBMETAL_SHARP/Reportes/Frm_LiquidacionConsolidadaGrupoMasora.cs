using Microsoft.Reporting.WinForms;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class Frm_LiquidacionConsolidadaGrupoMasora : Form
    {
        public Frm_LiquidacionConsolidadaGrupoMasora()
        {
            InitializeComponent();
        }

        public int Periodo { get; set; }
        public string Mina { get; set; }
        public string NombreMina { get; set; }
        public byte[] Logo1 { get; set; }
        public byte[] Logo2 { get; set; }

        private void Frm_LiquidacionConsolidadaGrupoMasora_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBMETALDataSet.Sp_Rpt_LiquidacionConsolidadaGrupoMasora' Puede moverla o quitarla según sea necesario.
            this.DBMETALDataSet.EnforceConstraints = false;            
            this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraTableAdapter.Fill(this.DBMETALDataSet.Sp_Rpt_LiquidacionConsolidadaGrupoMasora,this.Periodo);


            /////////////////////////////////////////////////////////////////


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
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(CargarSubReporte_GraficaGrupoMasora);

            this.GenerateReportPdf(NombreMina);


            ////////////////////////////////////////////////////////////////



            this.reportViewer1.RefreshReport();
        }


        private void GenerateReportPdf(string File)
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

        void CargarSubReporte(object sender, SubreportProcessingEventArgs e)
        {
            DataSet DS = DatosEntidad.Dataset("DescuentoGrupoMasora", "", this.Periodo, 0.00);
            //e.DataSources.Add(new ReportDataSource("DataSetSubReporte", (object)DBMETALDataSet.Rpt_LiquidacionMineraGrafica));
            e.DataSources.Add(new ReportDataSource("DataSet_DescuentosLiquidacionGrupoMasora", DS.Tables[0]));
        }

        void CargarSubReporte_GraficaGrupoMasora(object sender, SubreportProcessingEventArgs e)
        {
            DataSet DS = DatosEntidad.Dataset("GraficoGrupoMasora", "", 0, 0.00);
            //e.DataSources.Add(new ReportDataSource("DataSetSubReporte", (object)DBMETALDataSet.Rpt_LiquidacionMineraGrafica));
            e.DataSources.Add(new ReportDataSource("DataSetLiquidacionMineraGraficaGrupoMasora", DS.Tables[0]));
        }

    }
}

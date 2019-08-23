using Microsoft.Reporting.WinForms;
using ReglasdeNegocio;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class FrmRptDiarioMuestreo : Form
    {
        public FrmRptDiarioMuestreo()
        {
            InitializeComponent();
        }

        public FrmRptDiarioMuestreo(string fechaInicio, string fechaFin, string proyecto, string periodo, string numOrden)
        {
            InitializeComponent();
            FechaInicial = fechaInicio;
            FechaFinal = fechaFin;
            Periodo = periodo;
            Proyecto = proyecto;
            NumOrden = numOrden;
        }

        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public string Proyecto { get; set; }
        public string Periodo { get; set; }
        public string NumOrden { get; set; }

        private void FrmRptDiarioMuestreo_Load(object sender, EventArgs e)
        {
            DataTable datosReporte = new DataTable();
            datosReporte = ConsultaEntidades.ReporteDiarioMuestreo(FechaInicial, FechaFinal, Proyecto, Periodo, NumOrden);

            string reporte = Path.Combine(Application.StartupPath, @"Informes\ReporteMuestreoDiario.rdlc");
            this.reportViewer1.LocalReport.ReportPath = reporte;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReporteDiarioMuestreoDataSet", datosReporte));
            this.reportViewer1.RefreshReport();

        }
    }
}

﻿using Microsoft.Reporting.WinForms;
using ReglasdeNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Reportes
{
    public partial class FrmRptDiarioMuestreo : Form
    {
        public FrmRptDiarioMuestreo()
        {
            InitializeComponent();
        }

        public FrmRptDiarioMuestreo(string fechaInicio, string fechaFin, string proyecto, string periodo)
        {
            InitializeComponent();
            FechaInicial = fechaInicio;
            FechaFinal = fechaFin;
            Periodo = periodo;
            Proyecto = proyecto;
        }

        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public string Proyecto { get; set; }
        public string Periodo { get; set; }
        public string Imprimir { get; set; }
        public string Smtp { get; set; }
        public string Credencial { get; set; }
        public string Password { get; set; }
        public int Puerto { get; set; }
        public bool SSL { get; set; }

        private void GenerateReportPdf()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream("DBMETAL_BasculaMineralProyectado.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        private void FrmRptDiarioMuestreo_Load(object sender, EventArgs e)
        {
            if (this.Imprimir == "1")
            {
                this.GenerateReportPdf();
            }
        }
    }
}
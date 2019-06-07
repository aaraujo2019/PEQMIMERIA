using Microsoft.Reporting.WinForms;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class FrmRptProyeccionMineral : Form
    {
        public FrmRptProyeccionMineral(string fecha, string imprimir)
        {
            InitializeComponent();
            this.Fecha = fecha;
            this.Imprimir = imprimir;
        }
        public string Fecha { get; set; }
        public string Imprimir { get; set; }
        public string Smtp { get; set; }
        public string Credencial { get; set; }
        public string Password { get; set; }
        public int Puerto { get; set; }
        public bool SSL { get; set; }

        private void FrmRptProyeccionMineral_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBMETALDataSet.Sp_Rpt_ProyeccionMineral' Puede moverla o quitarla según sea necesario.
            this.DBMETALDataSet.EnforceConstraints = false;
            this.Sp_Rpt_ProyeccionMineralTableAdapter.Fill(this.DBMETALDataSet.Sp_Rpt_ProyeccionMineral, this.Fecha);
            this.reportViewer1.RefreshReport();
            if (this.Imprimir == "1")
            {
                this.GenerateReportPdf();

                #region Trallendo los parametros de envio mail
                SqlParameter[] ParamSQL2 = new SqlParameter[4];
                ParamSQL2[0] = new SqlParameter("@Op", "ConsultaMails");
                ParamSQL2[1] = new SqlParameter("@ParametroChar", "");
                ParamSQL2[2] = new SqlParameter("@ParametroInt", "0");
                ParamSQL2[3] = new SqlParameter("@ParametroNuemric", "0");
                DataSet DS2;

                DS2 = LlenarGrid.Datos("SpConsulta_Tablas", ParamSQL2);
                if (DS2.Tables[0].Rows.Count > 0)
                {
                    this.Smtp = Convert.ToString(DS2.Tables[0].Rows[0]["Smtp"]).Trim();
                    this.Credencial = Convert.ToString(DS2.Tables[0].Rows[0]["Credencial"]).Trim();
                    this.Password = Convert.ToString(DS2.Tables[0].Rows[0]["Password"]).Trim();
                    this.Puerto = Convert.ToInt32(DS2.Tables[0].Rows[0]["Puerto"]);
                    this.SSL = Convert.ToBoolean(DS2.Tables[0].Rows[0]["SSL"]);
                }
                #endregion

                #region Trallendo los remitentes
                try
                {
                    string RutaFile = Directory.GetCurrentDirectory() + "\\DBMETAL_BasculaMineralProyectado.pdf";
                    MailMessage mnsj = new MailMessage();
                    mnsj.Subject = "Reporte de Mineral Proyectado a Transportar por Mina  " + this.Fecha.Trim();
                    mnsj.From = new MailAddress(Credencial, "DBMETAL");

                    mnsj.Attachments.Add(new Attachment(RutaFile));
                    mnsj.Body = "  Proyeccion de Mineral a Ingresar/Transportar a Planta \n\n Enviado desde mi aplicacion DBMETAL\n\n *VER EL ARCHIVO ADJUNTO*";

                    SqlParameter[] ParamSQL1 = new SqlParameter[4];
                    ParamSQL1[0] = new SqlParameter("@Op", "Remitentes1");
                    ParamSQL1[1] = new SqlParameter("@ParametroChar", "");
                    ParamSQL1[2] = new SqlParameter("@ParametroInt", "0");
                    ParamSQL1[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DS1;

                    DS1 = LlenarGrid.Datos("SpConsulta_Tablas", ParamSQL1);
                    if (DS1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in DS1.Tables[0].Rows)
                        {
                            mnsj.To.Add(row[0].ToString());
                        }
                    }
                    Correos.Enviar(Smtp, Puerto, Credencial, Password, SSL, mnsj);

                }
                catch (Exception)
                {

                    throw;
                }

                #endregion
            }
        }

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
    }
}

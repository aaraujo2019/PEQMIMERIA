using Entidades;
using ReglasdeNegocio;
using Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_DetalleLiquidacion : Form
    {
        public Frm_DetalleLiquidacion()
        {
            InitializeComponent();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            #region LLenando el Combo de los Conceptos
            List<Ent_Periodos> ListaPeriodos = DatosEntidad.ListPeriodos("PeriodosGen", "", 0, 0.0);
            this.CmbPeriodos.DataSource = ListaPeriodos;
            this.CmbPeriodos.DisplayMember = "Titulo";
            this.CmbPeriodos.ValueMember = "Id";
            this.CmbPeriodos.SelectedIndex = 0;
            #endregion
            this.dataGridView1.DataSource = null;
            this.RtbBodyMail.Text = "Buen@s, " + Environment.NewLine +
                                   "Anexamos archivo PDF con la relación de la liquidación del periodo." + Environment.NewLine +
                                   "Presentamos disculpas por el retraso en la generación de la información, así como agradecemos presenten hoy mismo la factura asociada con esta liquidación";

            ConsultaEntidades Consulta = new ConsultaEntidades();

            Ent_ImagenPublicidad Reader = Consulta.ImagenPublicidad();
            this.PtbLogo1.Image = Convertir.byteEnImagen(Reader.Logo1);
            this.PtbLogo2.Image = Convertir.byteEnImagen(Reader.Logo2);
        }

        private void Frm_DetalleLiquidacion_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
            this.BtnRefrescar.PerformClick();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns[0].Visible = true;
            DataSet DS = DatosEntidad.Dataset("LiquidacionPeriodo", "", Convert.ToInt32(this.CmbPeriodos.SelectedValue), 0.00);
            dataGridView1.DataSource = DS.Tables[0];
            dataGridView1.AutoResizeColumns();

            TotalGrid.MarcarSeleccion(this.dataGridView1);
            TotalGrid.HabilitarCheck(this.dataGridView1);
            this.ToolStripTxbRegistros.Text = TotalGrid.RegistrosSeleccionados(dataGridView1);
            this.ToolStripTxbDetalle.Text = TotalGrid.TotalLiquidacion(this.dataGridView1);

            #region Aplicando accion del chech que activo Grupo Damasa
            if (this.ChbOmitirDamasa.Checked)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "039" || Convert.ToString(row.Cells[1].Value).Trim() == "080" || Convert.ToString(row.Cells[1].Value).Trim() == "089")
                        row.Cells[0].Value = false;
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "039" || Convert.ToString(row.Cells[1].Value).Trim() == "080" || Convert.ToString(row.Cells[1].Value).Trim() == "089")
                        row.Cells[0].Value = true;
                }
            }
            #endregion


            #region Aplicando accion del chech que activo Grupo Masora
            if (this.ChbOmitirMasora.Checked)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "020" || Convert.ToString(row.Cells[1].Value).Trim() == "090" || Convert.ToString(row.Cells[1].Value).Trim() == "091")
                        row.Cells[0].Value = false;
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "020" || Convert.ToString(row.Cells[1].Value).Trim() == "090" || Convert.ToString(row.Cells[1].Value).Trim() == "091")
                        row.Cells[0].Value = true;
                }
            }
            #endregion
        }



        private void ChkMarcar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChkMarcar.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int index = row.Index;
                    if (Convert.ToInt32(row.Cells[8].Value) == 0)
                    {
                        row.Cells[0].Value = false;
                        this.dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    else
                        row.Cells[0].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    row.Cells[0].Value = false;
            }
            this.ToolStripTxbRegistros.Text = TotalGrid.RegistrosSeleccionados(dataGridView1);
            this.ToolStripTxbDetalle.Text = TotalGrid.TotalLiquidacion(dataGridView1);

        }


        private void CmbPeriodos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.BtnRefrescar.PerformClick();
        }

        private void ToolStripBtnRefrescar_Click(object sender, EventArgs e)
        {
            this.ToolStripTxbRegistros.Focus();
        }

        private void ToolStripTxbRegistros_Enter(object sender, EventArgs e)
        {
            this.ToolStripTxbRegistros.Text = TotalGrid.RegistrosSeleccionados(dataGridView1);
            this.ToolStripTxbDetalle.Text = TotalGrid.TotalLiquidacion(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ToolStripTxbRegistros.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int Op = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
            Frm_RevisionLiquidacion Forma = new Frm_RevisionLiquidacion();
            Forma.Op = Op;
            Forma.Show();
        }

        private void BtnEnviarMail_Click(object sender, EventArgs e)
        {
            int Envio = 0;
            if (this.ChbOmitirDamasa.Checked == false)
            {
                DialogResult Opcion = MessageBox.Show("Tiene DesMarcada la opcion de Omitir los proyectos del Grupo Damasa," + Environment.NewLine + "desea enviar los email con esta condicion.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Opcion == DialogResult.No)
                    Envio = 1;
            }

            if (this.ChbOmitirMasora.Checked == false)
            {
                DialogResult Opcion = MessageBox.Show("Tiene DesMarcada la opcion de Omitir los proyectos del Grupo Masora," + Environment.NewLine + "desea enviar los email con esta condicion.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Opcion == DialogResult.No)
                    Envio = 1;
            }

            if (Envio == 0)
            {
                #region Trallendo los parametros de envio mail
                string Smtp = "";
                string Credencial = "";
                string Password = "";
                int Puerto = 0;
                bool SSL = true;
                DataSet DS = DatosEntidad.Dataset("ConsultaMails", "", 0, 0.00);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    Smtp = Convert.ToString(DS.Tables[0].Rows[0]["Smtp"]).Trim();
                    Credencial = Convert.ToString(DS.Tables[0].Rows[0]["Credencial"]).Trim();
                    Password = Convert.ToString(DS.Tables[0].Rows[0]["Password"]).Trim();
                    Puerto = Convert.ToInt32(DS.Tables[0].Rows[0]["Puerto"]);
                    SSL = Convert.ToBoolean(DS.Tables[0].Rows[0]["SSL"]);
                }
                #endregion

                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        string ArchivoPdf = Convert.ToString(row.Cells[2].Value).Trim() + ".pdf";
                        Frm_LiquidacionMinera Forma = new Frm_LiquidacionMinera();
                        Forma.Logo1 = Convertir.ImagenEnByte(this.PtbLogo1.Image);
                        Forma.Logo2 = Convertir.ImagenEnByte(this.PtbLogo2.Image);
                        Forma.Periodo = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
                        Forma.Mina = Convert.ToString(row.Cells[1].Value);
                        Forma.NombreMina = ArchivoPdf;
                        Forma.Show();
                        string RutaFile = Directory.GetCurrentDirectory() + "\\" + ArchivoPdf.Trim();
                        MailMessage mnsj = new MailMessage();
                        mnsj.Subject = "Relación de Liquidación: " + Convert.ToString(row.Cells[2].Value) + this.CmbPeriodos.Text.Trim();

                        #region Llenado a quien se le va enviar el email
                        DataSet DsMailPara = DatosEntidad.Dataset("MailOperadores", Convert.ToString(row.Cells[1].Value).Trim(), 0, 0.00);
                        if (DsMailPara.Tables[0].Rows.Count > 0)
                            foreach (DataRow RegistroTo in DsMailPara.Tables[0].Rows)
                                mnsj.To.Add(RegistroTo[0].ToString());
                        #endregion

                        #region Llenado a quien se le va Copiar el email
                        DataSet DsMailCopia = DatosEntidad.Dataset("CopiaLiquidacion", "", 0, 0.00);
                        if (DsMailCopia.Tables[0].Rows.Count > 0)
                            foreach (DataRow RegistroCC in DsMailCopia.Tables[0].Rows)
                                mnsj.CC.Add(RegistroCC[0].ToString());
                        #endregion

                        mnsj.From = new MailAddress(Credencial);
                        mnsj.Attachments.Add(new Attachment(RutaFile));
                        mnsj.Body = this.RtbBodyMail.Text.Trim() + Environment.NewLine + Environment.NewLine + "Enviado desde mi aplicacion DBMETAL.";
                        Correos.Enviar(Smtp, Puerto, Credencial, Password, SSL, mnsj);
                    }
                }
                MessageBox.Show("Mail Enviado con exito.");
            }
        }

        private void BtnImprimirSeleccion_Click(object sender, EventArgs e)
        {
            string ArchivoPdf = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value).Trim() + ".pdf";
            Frm_LiquidacionMinera Forma = new Frm_LiquidacionMinera();
            Forma.Logo1 = Convertir.ImagenEnByte(this.PtbLogo1.Image);
            Forma.Logo2 = Convertir.ImagenEnByte(this.PtbLogo2.Image);
            Forma.Periodo = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
            Forma.Mina = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
            Forma.NombreMina = ArchivoPdf;
            Forma.Show();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ArchivoPdf = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value).Trim() + ".pdf";
            Frm_LiquidacionMinera Forma = new Frm_LiquidacionMinera();
            Forma.Logo1 = Convertir.ImagenEnByte(this.PtbLogo1.Image);
            Forma.Logo2 = Convertir.ImagenEnByte(this.PtbLogo2.Image);
            Forma.Periodo = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
            Forma.Mina = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
            Forma.NombreMina = ArchivoPdf;
            Forma.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void BtnPicture1_Click(object sender, EventArgs e)
        {
            this.PtbLogo1.Image = Seleccionar.Imagen("\\DBMETAL\\", "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG", this.PtbLogo1.Image);
            GuardarDatos Guardar = new GuardarDatos();
            Guardar._ImagenPublicitaria(1, Convertir.ImagenEnByte(this.PtbLogo1.Image));
        }

        private void BtnPicture2_Click(object sender, EventArgs e)
        {
            this.PtbLogo2.Image = Seleccionar.Imagen("\\DBMETAL\\", "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG", this.PtbLogo2.Image);
            GuardarDatos Guardar = new GuardarDatos();
            Guardar._ImagenPublicitaria(2, Convertir.ImagenEnByte(this.PtbLogo2.Image));
        }

        private void BtnEnvioDamasa_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Si desea imprimir por pantalla, seleccione la opcion SI" + Environment.NewLine + "Si desea enviar email al operador, seleccione la opcion NO" + Environment.NewLine + "Seleccione Cancelar para no hacer nada", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (Opcion == DialogResult.Yes)
            {
                string ArchivoPdf = "GrupoDamasa.pdf";
                Frm_LiquidacionConsolidadaGrupoDamasa Forma = new Frm_LiquidacionConsolidadaGrupoDamasa();
                Forma.Logo1 = Convertir.ImagenEnByte(this.PtbLogo1.Image);
                Forma.Logo2 = Convertir.ImagenEnByte(this.PtbLogo2.Image);
                Forma.Periodo = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
                Forma.Mina = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
                Forma.NombreMina = ArchivoPdf;
                Forma.Show();
            }

            if (Opcion == DialogResult.No)
            {
                #region Trallendo los parametros de envio mail
                string Smtp = "";
                string Credencial = "";
                string Password = "";
                int Puerto = 0;
                bool SSL = true;
                DataSet DS = DatosEntidad.Dataset("ConsultaMails", "", 0, 0.00);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    Smtp = Convert.ToString(DS.Tables[0].Rows[0]["Smtp"]).Trim();
                    Credencial = Convert.ToString(DS.Tables[0].Rows[0]["Credencial"]).Trim();
                    Password = Convert.ToString(DS.Tables[0].Rows[0]["Password"]).Trim();
                    Puerto = Convert.ToInt32(DS.Tables[0].Rows[0]["Puerto"]);
                    SSL = Convert.ToBoolean(DS.Tables[0].Rows[0]["SSL"]);
                }
                #endregion

                string ArchivoPdf = "GrupoDamasa.pdf";
                Frm_LiquidacionConsolidadaGrupoDamasa Forma = new Frm_LiquidacionConsolidadaGrupoDamasa();
                Forma.Logo1 = Convertir.ImagenEnByte(this.PtbLogo1.Image);
                Forma.Logo2 = Convertir.ImagenEnByte(this.PtbLogo2.Image);
                Forma.Periodo = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
                Forma.Mina = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
                Forma.NombreMina = ArchivoPdf;
                Forma.Show();
                string RutaFile = Directory.GetCurrentDirectory() + "\\" + ArchivoPdf.Trim();
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = "Relación de Liquidación: Grupo Damasa " + this.CmbPeriodos.Text.Trim();

                #region Llenado a quien se le va enviar el email
                DataSet DsMailPara = DatosEntidad.Dataset("MailOperadores", "039", 0, 0.00);
                if (DsMailPara.Tables[0].Rows.Count > 0)
                    foreach (DataRow RegistroTo in DsMailPara.Tables[0].Rows)
                        mnsj.To.Add(RegistroTo[0].ToString());
                #endregion

                #region Llenado a quien se le va Copiar el email
                DataSet DsMailCopia = DatosEntidad.Dataset("CopiaLiquidacion", "", 0, 0.00);
                if (DsMailCopia.Tables[0].Rows.Count > 0)
                    foreach (DataRow RegistroCC in DsMailCopia.Tables[0].Rows)
                        mnsj.CC.Add(RegistroCC[0].ToString());
                #endregion

                mnsj.From = new MailAddress(Credencial);
                mnsj.Attachments.Add(new Attachment(RutaFile));
                mnsj.Body = this.RtbBodyMail.Text.Trim() + Environment.NewLine + Environment.NewLine + "Enviado desde mi aplicacion DBMETAL.";
                Correos.Enviar(Smtp, Puerto, Credencial, Password, SSL, mnsj);

                MessageBox.Show("Mail Enviado con exito.");
            }
        }

        private void ChbOmitirDamasa_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbOmitirDamasa.Checked)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "039" || Convert.ToString(row.Cells[1].Value).Trim() == "080" || Convert.ToString(row.Cells[1].Value).Trim() == "089")
                        row.Cells[0].Value = false;
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "039" || Convert.ToString(row.Cells[1].Value).Trim() == "080" || Convert.ToString(row.Cells[1].Value).Trim() == "089")
                        row.Cells[0].Value = true;
                }
            }
        }

        private void ChbOmitirMasora_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbOmitirMasora.Checked)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "020" || Convert.ToString(row.Cells[1].Value).Trim() == "090" || Convert.ToString(row.Cells[1].Value).Trim() == "091")
                        row.Cells[0].Value = false;
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Trim() == "020" || Convert.ToString(row.Cells[1].Value).Trim() == "090" || Convert.ToString(row.Cells[1].Value).Trim() == "091")
                        row.Cells[0].Value = true;
                }
            }
        }

        private void BtnEnvioMasora_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Si desea imprimir por pantalla, seleccione la opcion SI" + Environment.NewLine + "Si desea enviar email al operador, seleccione la opcion NO" + Environment.NewLine + "Seleccione Cancelar para no hacer nada", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (Opcion == DialogResult.Yes)
            {
                string ArchivoPdf = "GrupoMasora.pdf";
                Frm_LiquidacionConsolidadaGrupoMasora Forma = new Frm_LiquidacionConsolidadaGrupoMasora();
                Forma.Logo1 = Convertir.ImagenEnByte(this.PtbLogo1.Image);
                Forma.Logo2 = Convertir.ImagenEnByte(this.PtbLogo2.Image);
                Forma.Periodo = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
                Forma.Mina = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
                Forma.NombreMina = ArchivoPdf;
                Forma.Show();
            }

            if (Opcion == DialogResult.No)
            {
                #region Trallendo los parametros de envio mail
                string Smtp = "";
                string Credencial = "";
                string Password = "";
                int Puerto = 0;
                bool SSL = true;
                DataSet DS = DatosEntidad.Dataset("ConsultaMails", "", 0, 0.00);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    Smtp = Convert.ToString(DS.Tables[0].Rows[0]["Smtp"]).Trim();
                    Credencial = Convert.ToString(DS.Tables[0].Rows[0]["Credencial"]).Trim();
                    Password = Convert.ToString(DS.Tables[0].Rows[0]["Password"]).Trim();
                    Puerto = Convert.ToInt32(DS.Tables[0].Rows[0]["Puerto"]);
                    SSL = Convert.ToBoolean(DS.Tables[0].Rows[0]["SSL"]);
                }
                #endregion

                string ArchivoPdf = "GrupoMasora.pdf";
                Frm_LiquidacionConsolidadaGrupoMasora Forma = new Frm_LiquidacionConsolidadaGrupoMasora();
                Forma.Logo1 = Convertir.ImagenEnByte(this.PtbLogo1.Image);
                Forma.Logo2 = Convertir.ImagenEnByte(this.PtbLogo2.Image);
                Forma.Periodo = Convert.ToInt32(this.CmbPeriodos.SelectedValue);
                Forma.Mina = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
                Forma.NombreMina = ArchivoPdf;
                Forma.Show();
                string RutaFile = Directory.GetCurrentDirectory() + "\\" + ArchivoPdf.Trim();
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = "Relación de Liquidación: Grupo Masora " + this.CmbPeriodos.Text.Trim();

                #region Llenado a quien se le va enviar el email
                DataSet DsMailPara = DatosEntidad.Dataset("MailOperadores", "039", 0, 0.00);
                if (DsMailPara.Tables[0].Rows.Count > 0)
                    foreach (DataRow RegistroTo in DsMailPara.Tables[0].Rows)
                        mnsj.To.Add(RegistroTo[0].ToString());
                #endregion

                #region Llenado a quien se le va Copiar el email
                DataSet DsMailCopia = DatosEntidad.Dataset("CopiaLiquidacion", "", 0, 0.00);
                if (DsMailCopia.Tables[0].Rows.Count > 0)
                    foreach (DataRow RegistroCC in DsMailCopia.Tables[0].Rows)
                        mnsj.CC.Add(RegistroCC[0].ToString());
                #endregion

                mnsj.From = new MailAddress(Credencial);
                mnsj.Attachments.Add(new Attachment(RutaFile));
                mnsj.Body = this.RtbBodyMail.Text.Trim() + Environment.NewLine + Environment.NewLine + "Enviado desde mi aplicacion DBMETAL.";
                Correos.Enviar(Smtp, Puerto, Credencial, Password, SSL, mnsj);

                MessageBox.Show("Mail Enviado con exito.");
            }

        }
    }
}

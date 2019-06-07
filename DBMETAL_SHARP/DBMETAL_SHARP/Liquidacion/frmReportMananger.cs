using Entidades;
using ReglasdeNegocio;
using Reportes.LiquidacionDBMETAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DBMETAL_SHARP.Liquidacion
{
    public partial class frmReportMananger : Form
    {

        #region Propiedades - Variables

        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }

        public List<Roles_Permisos> Permission;
        #endregion
        public frmReportMananger(string User)
        {
            InitializeComponent();
            this.Usuario = User.Trim();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Insert(0, "Detalle Mina Día");
            comboBox1.Items.Insert(1, "Resumen Mina Día");
            comboBox1.Items.Insert(2, "Detalle Muestreo");

            dtpEventInitial.Value = DateTime.Now;

            dtpEventEnd.Value = DateTime.Now;

            DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", User.ToString().Trim(), this.Name);

            this.Permission = DBMETAL_SHARP.Common.Common.Permissions;

            ValidatePermission(this.Controls);


            var read = ConsultaEntidades.MinasReader("SpConsulta_Tablas", "Minas", "", 0, string.Empty);//.OrderBy(f=>f.Nombre);

            comboMina.DisplayMember = "Nombre";
            comboMina.ValueMember = "Codigo";
            //CmbTypSub.DataSource = LoadShipmentAll();
            //Implementación David Ciro
            //var query1 = LoadShipmentAllTypSubEntity();

            this.comboMina.DropDownStyle = ComboBoxStyle.DropDownList;

             read= read.OrderBy(f => f.Nombre).ToList();

            Ent_Minas pre = new Ent_Minas();
            pre.Codigo = "-1";
            pre.Nombre = "Seleccione opción..";
            read.Insert(read.ToList().Count, pre);

            comboMina.DataSource = read.Select(c => c.Nombre).ToList();
            comboMina.SelectedIndex = read.ToList().Count - 1;
        }
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

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Liquidacion frmReporte = null;
            object[] argument = null;
            string nameReport = string.Empty;

            //comboBox1
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (dtpEventInitial.Value > dtpEventEnd.Value)
                    {
                        MessageBox.Show("La fecha inicial no debe de ser superior a la final");
                        return;
                    }
                    else
                        if (dtpEventEnd.Value < dtpEventInitial.Value)
                    {
                        MessageBox.Show("La fecha final no debe de ser inferior a la inicial");
                        return;
                    }
                    string mina = string.Empty;

                    if (!comboMina.SelectedIndex.Equals(comboMina.Items.Count-1))
                        mina = comboMina.Text.Trim();

                            nameReport = "Detalle Mina Día";


                    frmReporte = new Frm_Reporte_Liquidacion();
                    argument = new object[] { 1, dtpEventInitial.Value, dtpEventEnd.Value, checkBox1.Checked, mina };

                    frmReporte.EjecucionReportes(argument);
                    frmReporte.Show();
                    break;
                case 1:
                    if (dtpEventInitial.Value == null)
                    {
                        MessageBox.Show("La fecha inicial no puede ser  Nula");
                        return;
                    }
                    nameReport = "Resumen Mina Día";
                    mina = string.Empty;

                    if (!comboMina.SelectedIndex.Equals(comboMina.Items.Count - 1))
                        mina = comboMina.Text.Trim();

                    frmReporte = new Frm_Reporte_Liquidacion();
                    argument = new object[] { 2, dtpEventInitial.Value, dtpEventEnd.Value, checkBox1.Checked, mina };

                    frmReporte.EjecucionReportes(argument);
                    frmReporte.Show();
                    break;
                case 2:
                    if (dtpEventInitial.Value == null)
                    {
                        MessageBox.Show("La fecha inicial no puede ser  Nula");
                        return;
                    }
                    nameReport = "Detalle Muestreo";

                     mina = string.Empty;

                    if (!comboMina.SelectedIndex.Equals(comboMina.Items.Count - 1))
                        mina = comboMina.Text.Trim();

                    frmReporte = new Frm_Reporte_Liquidacion();
                    argument = new object[] { 3, dtpEventInitial.Value, dtpEventEnd.Value, checkBox1.Checked,mina };

                    frmReporte.EjecucionReportes(argument);
                    frmReporte.Show();
                    break;
                case -1:
                    MessageBox.Show("Selcciona el Reporte a generar");
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(this.IpLocal))
                this.IpLocal = DireccionIP.Local();

            if (string.IsNullOrEmpty(this.IpPublica))
                this.IpPublica = DireccionIP.Publica();

            if (string.IsNullOrEmpty(this.SerialHDD))
                this.SerialHDD = DireccionIP.SerialNumberDisk();

            if (string.IsNullOrEmpty(this.Usuario))
                this.Usuario = DireccionIP.SerialNumberDisk();

            LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se genera el reporte de " + nameReport, "Generación de Reportes");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

    }
}

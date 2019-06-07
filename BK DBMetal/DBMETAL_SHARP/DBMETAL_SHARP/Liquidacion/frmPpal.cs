using DBMETAL_SHARP.Liquidacion;
using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class frmPpal : Form
    {
        List<Entidades.Ent_Usuario> user;
        public List<Roles_Permisos> Permission;

        public frmPpal()
        {
            this.user = DBMETAL_SHARP.Common.Common.User;

            this.Permission = DBMETAL_SHARP.Common.Common.Permissions;

            InitializeComponent();

            ValidatePermission(this.Controls);

            holaToolStripMenuItem.Text = string.Concat("Bienvenido: ", user[0].Name);
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
                    c is RichTextBox || c is TabPage || c is TextBox)
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

        private void mnucontrolSampling_Click(object sender, EventArgs e)
        {

        }

        private void frmPpal_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI = default(MdiClient);
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = Color.White;
                }
                catch (InvalidCastException ex)
                {
                    //throw new Exception(ex.Message);
                }
            }
        }

        private void prepararEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void sGSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectDBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Periodo oDB = new Frm_Periodo(this.user[0].Name);
            oDB.MdiParent = this;
            oDB.Show();
        }

        private void administradorDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRoles dlg = new ManageRoles();
            dlg.MdiParent = this;
            dlg.Show();
        }

        private void administradorPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePermissions dlg =
                new ManagePermissions(this.user[0].Name);
            dlg.MdiParent = this;
            dlg.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultado = from item in System.Diagnostics.Process.GetProcesses()
                            where item.ProcessName.ToUpper() == "DBMETAL_SHARP"
                            select item;

            foreach (var item in resultado)
            {
                item.Kill();
            }
            Application.Exit();
            this.Close();
            this.Dispose(true);
        }

        private void jobAssayLaboratoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", this.user[0].Name.ToString().Trim(), "Frm_CargaAnalisis");

            //if (DBMETAL_SHARP.Common.Common.Permissions.Count > 0)
            //{
        }

        private void reportesInternosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportesSeguridad oDB = new frmReportesSeguridad(this.user[0].Name);
            oDB.MdiParent = this;
            oDB.Show();

        }

        private void capturaMuestreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_MuestreoPM oDB = new Frm_MuestreoPM(this.user[0].Name, true);
            oDB.MdiParent = this;
            oDB.Show();
        }

        private void controlCalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ControlCalidadMuestras oDB = new Frm_ControlCalidadMuestras(this.user[0].Name);
            oDB.MdiParent = this;
            oDB.Show();
        }

        private void reportesLiquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportMananger dlg =
              new frmReportMananger(this.user[0].Name);
            dlg.MdiParent = this;
            dlg.Show();
        }

        private void cargaAnálisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CargaAnalisis oDB = new Frm_CargaAnalisis(this.user[0].Name);
            oDB.MdiParent = this;
            oDB.Show();
        }

        private void frmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormClosing(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {

                Application.Exit();
                Dispose(true);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("¿Esta seguro de Que quiere cerrar la aplicacion?", "Cerrar la Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }
    }
}

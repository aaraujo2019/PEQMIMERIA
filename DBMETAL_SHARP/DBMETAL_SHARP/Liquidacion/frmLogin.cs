using ReglasdeNegocio;
using ReglasdeNegocio.DirectoryActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DirectorioActivo.Autenticar(Common.Common.Dominio, txtUser.Text.ToString(), txtPwd.Text.ToString(), DBMETAL_SHARP.Common.Common.path))
            {
                List<Entidades.Ent_Usuario> user = ConsultaEntidades.ObtenerUsuarioPorRoles("GetUserForRoles", txtUser.Text.ToString().Trim());

                if (user != null && user.Count() > 0)
                {
                    Common.Common.User = user;
                    Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", txtUser.Text.ToString().Trim(), "frmPpal");

                    if (Common.Common.Permissions.Count > 0)
                    {
                        frmSplash oSplash = new frmSplash();
                        oSplash.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no posee permisos para este módulo", "DBMetal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no activo en directorio activo", "DBMetal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Usuario no registrado en DBMetal", "DBMetal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnFormClosing(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            return MessageBox.Show("¿Está seguro de que quiere salir de la aplicación?", "Cerrar la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();               
            }
            
        }
    }
}

using Entidades;
using ReglasdeNegocio;
using ReglasdeNegocio.DirectoryActivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



            if (DirectorioActivo.Autenticar(DBMETAL_SHARP.Common.Common.Dominio, txtUser.Text.ToString(), txtPwd.Text.ToString(), DBMETAL_SHARP.Common.Common.path))
            {
                //string[] seconName = txtUser.Text.ToString().Split('.');
                //List<Entidades.Ent_Usuario> user = ConsultaEntidades.ObtenerUsuario("CONSULTAUSUARIO", "C", seconName[1]);
                List<Entidades.Ent_Usuario> user = ConsultaEntidades.ObtenerUsuarioPorRoles("GetUserForRoles", txtUser.Text.ToString().Trim());

                if (user != null && user.Count() > 0)
                {

                    DBMETAL_SHARP.Common.Common.User = user;

                    //user[0].Usuario
                    DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", txtUser.Text.ToString().Trim(), "frmPpal");

                    if (DBMETAL_SHARP.Common.Common.Permissions.Count > 0)
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
            DialogResult res = System.Windows.Forms.MessageBox.Show("¿Esta seguro de Que quiere cerrar la aplicacion?", "Cerrar la Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

    }
}

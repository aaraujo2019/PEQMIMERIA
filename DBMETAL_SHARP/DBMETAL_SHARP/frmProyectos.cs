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
    public partial class frmProyectos : Form
    {
        public frmProyectos()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            this.Dispose(true);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtAnalisis.Text = string.Empty;
            this.CmbPlaza.SelectedIndex = -999;
        }
    }
}

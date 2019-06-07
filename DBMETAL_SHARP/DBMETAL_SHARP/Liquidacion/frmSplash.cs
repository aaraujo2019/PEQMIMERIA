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
    public partial class frmSplash : Form
    {
     
        public frmSplash( )
        {
            InitializeComponent(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmPpal oPpal = new frmPpal();
            oPpal.Show();
            this.Hide();
            timer1.Enabled = false;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}

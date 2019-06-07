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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void TsbtnMuestra1_Click(object sender, EventArgs e)
        {
            Frm_TenorSGS Forma = new Frm_TenorSGS();
            Forma.ShowDialog();
        }

        private void TsbtnMuestra1_MouseMove(object sender, MouseEventArgs e)
        {
            this.TstLabelDetalle.Text = "Utilice esta opción para cargar los resultados de tenor y humedad emitidos por SGS, formato del archivo GQ14….xls";
        }

        private void TsbtnMuestra1_MouseLeave(object sender, EventArgs e)
        {
            this.TstLabelDetalle.Text = "Listo";
        }

        private void TsbtnMuestra2_MouseMove(object sender, MouseEventArgs e)
        {
            this.TstLabelDetalle.Text = "Utilice esta opción para cargar los resultados de tenor emitidos por SGS, formato del archivo GQ15….xls";
        }

        private void TsbtnMuestra2_MouseLeave(object sender, EventArgs e)
        {
            this.TstLabelDetalle.Text = "Listo";
        }

        private void TsbtnMuestra2_Click(object sender, EventArgs e)
        {
            Frm_TenorSGS2 Forma = new Frm_TenorSGS2();
            Forma.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.TstLabelDetalle.Text = "Listo";
        }

        private void TsbtnHumedad_MouseMove(object sender, MouseEventArgs e)
        {
            this.TstLabelDetalle.Text = "Utilice esta opción para cargar los resultados de humedad emitidos por el laboratorio de Zandor, formato del archivo ZC-….xls";
        }

        private void TsbtnHumedad_MouseLeave(object sender, EventArgs e)
        {
            this.TstLabelDetalle.Text = "Listo";
        }

        private void TsbtnHumedad_Click(object sender, EventArgs e)
        {
            Frm_HumedadZandor Forma = new Frm_HumedadZandor();
            Forma.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frm_TenorZandor Forma = new Frm_TenorZandor();
            Forma.ShowDialog();
        }

        private void toolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            this.TstLabelDetalle.Text = "Listo";
        }

        private void toolStripButton1_MouseMove(object sender, MouseEventArgs e)
        {
            this.TstLabelDetalle.Text = "Utilice esta opción para cargar los resultados de Tenor y Humedad Generados en un archivo de excel especial por el personal de Pequeña Mineria ";
        }

     

     

      
    }
}

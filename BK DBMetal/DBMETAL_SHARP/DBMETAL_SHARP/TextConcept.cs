using DBMETAL_SHARP.Common;
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
    public partial class TextConcept : Form
    {
        public TextConcept()
        {
            InitializeComponent();
            MessageBoxTemporal.Show(String.Concat("Esta Versiòn es de Pruebas para capturar el Muestreo", Environment.NewLine, "Los Datos ingresado no alteraran ningun comprtamiento en el sistema DBMEAL"), "ÀREA IT", 10, true);

        }
        string Login = "JOLIER";


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm_MuestreoPM muestreoPM = new Frm_MuestreoPM(Login,true);
            muestreoPM.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Frm_ControlCalidadMuestras muestreoPM = new Frm_ControlCalidadMuestras(Login);
            muestreoPM.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class FrmRptCompromisoVial : Form
    {
        public FrmRptCompromisoVial()
        {
            InitializeComponent();
        }

        public string Conductor { get; set; }

        private void FrmRptContratoVial_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBMETALDataSet.Sp_Rpt_CompromisoVial' Puede moverla o quitarla según sea necesario.
            this.Sp_Rpt_CompromisoVialTableAdapter.Fill(this.DBMETALDataSet.Sp_Rpt_CompromisoVial, this.Conductor);

            this.reportViewer2.RefreshReport();
        }
    }
}

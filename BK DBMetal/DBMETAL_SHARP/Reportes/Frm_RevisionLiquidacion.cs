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
    public partial class Frm_RevisionLiquidacion : Form
    {
        public Frm_RevisionLiquidacion()
        {
            InitializeComponent();
        }
        public int Op  { get; set; }
        private void Frm_RevisionLiquidacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBMETALDataSet.Rpt_RevisionLiquidacion' Puede moverla o quitarla según sea necesario.
            this.DBMETALDataSet.EnforceConstraints = false;
            
            this.Rpt_RevisionLiquidacionTableAdapter.Fill(this.DBMETALDataSet.Rpt_RevisionLiquidacion,this.Op);

            this.reportViewer1.RefreshReport();
        }
    }
}

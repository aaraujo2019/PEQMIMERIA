using Reportes;
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
    public partial class Frm_LiqudacionDBMETALMina : Form
    {
        public Frm_LiqudacionDBMETALMina()
        {
            InitializeComponent();
        }
        public Frm_LiqudacionDBMETALMina(string date1, string date2)
        {
            InitializeComponent();
            filtrarDatos(date1, date1);
        }

        private void Frm_LiqudacionDBMETALMina_Load(object sender, EventArgs e)
        {
            this.dbmetalDataSet1.EnforceConstraints = false;

            DataSet ds = new DataSet();
            dbmetalDataSet1 = new DBMETALDataSet();


            var value = this.reporte_Mineras_DetalleTableAdapter2.GetData();

            DataRow[] dtrow;
            DataTable dt = value.Clone();
            dt.Merge(value);
            dtrow = dt.Select("FechaProceso >='" + DateTime.Parse("20/04/2018") + "'");
            value.Clear();
            for (int i = 0; i < dtrow.Length; i++)
            {
                value.ImportRow(dtrow[i]);
            }

            //var valie1 = value.Select(s => s.FechaProceso == "20-04-2018").ToList();

         

            this.dbmetalDataSet1.Merge(value);
            //this.reporte_Mineras_DetalleTableAdapter1.ClearBeforeFill = true;

            //this.reporte_Mineras_DetalleTableAdapter2.Fill(valie1);

            //this.Reporte_Mineras_DetalleTableAdapter.Fill(value);
            //this.Reporte_Mineras_DetalleTableAdapter.Fill(this.DBMETALDataSet1.Reporte_Mineras_Detalle);

        }
        public void filtrarDatos(string x, string y)
        {

            reporteLiquidacion2 = new LiquidacionDBMETAL.ReporteLiquidacion();
            reporteLiquidacion2 = new LiquidacionDBMETAL.ReporteLiquidacion();
            reporteLiquidacion2.Merge(this.reporte_Mineras_DetalleTableAdapter1.GetData());
            this.reporteLiquidacion2.EnforceConstraints= false;
            //this.reporte_Mineras_DetalleTableAdapter1.GetDataFilter(x, y);
            this.reporte_Mineras_DetalleTableAdapter2.Fill(this.reporte_Mineras_DetalleTableAdapter2.GetData());

            this.reportViewer2. RefreshReport();
        }

        private void Frm_LiqudacionDBMETALMina_Load_1(object sender, EventArgs e)
        {

            //this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}

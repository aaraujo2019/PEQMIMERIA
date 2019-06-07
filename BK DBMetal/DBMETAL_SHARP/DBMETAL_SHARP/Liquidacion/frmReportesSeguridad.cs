using ReglasdeNegocio;
using Reportes.LiquidacionDBMETAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP.Liquidacion
{
    public partial class frmReportesSeguridad : Form
    {

        #region Variables
        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }
        #endregion
        public frmReportesSeguridad(string User)
        {
            InitializeComponent();

            this.Usuario = User.Trim();
        }

        public frmReportesSeguridad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Frm_Reporte_Liquidacion frmReporte = null;
            object[] argument = null;
            string nameReport = string.Empty;

            frmReporte = new Frm_Reporte_Liquidacion();
            if (cboCargaUsuario.Text == "TODOS")
                argument = new object[] { 7, "TODOS" };
            else
                argument = new object[] { 7, cboCargaUsuario.Text };



            frmReporte.EjecucionReportes(argument);
            frmReporte.Show();
        }

        private void PopulatePermissionTree()
        {
            string queryString = "	select usr .Name from ControlsToRoles ctr" +

    "  join controls c on c.ControlID = ctr.FKControlID and c.Page = ctr.FKPage" +

    "  join roles r on r.RoleID = ctr.FKRole" +

    "  join UsersToRoles UsTr on UsTr.FKRoleID = ctr.FKRole" +

    "  join Users usr on usr.UserID = UsTr.FKUserID" +

    "  group by usr.Name  ";

            DataTable dt = null;
            try
            {
                dt = GuardarDatos.GetRoles(queryString);
                DataRow row = dt.NewRow();
                row[0] = "TODOS";
                dt.Rows.Add(row);
                cboCargaUsuario.DataSource = dt;
                cboCargaUsuario.DisplayMember = "Name";
                cboCargaUsuario.SelectedIndex = cboCargaUsuario.Items.Count - 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al recuperar " + e.Message,
                    "Error al recuperar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


            string currentName = string.Empty;


        }

        private void frmReportesSeguridad_Load(object sender, EventArgs e)
        {
            PopulatePermissionTree();
        }
    }
}

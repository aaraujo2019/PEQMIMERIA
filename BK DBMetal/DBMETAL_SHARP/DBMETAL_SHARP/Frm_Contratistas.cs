using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_Contratistas : Form
    {
        public Frm_Contratistas(string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        public string Login;
        public void EjecutaPasarDato(string Dato)
        {
            this.txbIdentificacion.Text = Dato;
            txbIdentificacion_Leave(null, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] ParametrosEnt = new SqlParameter[12];
                ParametrosEnt[1] = new SqlParameter("@Identificacion", this.txbIdentificacion.Text.Trim());
                ParametrosEnt[2] = new SqlParameter("@Nombre", this.txbNombre.Text.Trim());
                ParametrosEnt[3] = new SqlParameter("@Apellido", this.txbApellido.Text.Trim());
                ParametrosEnt[4] = new SqlParameter("@TelFijo", this.txbTelfijo.Text.Trim());
                ParametrosEnt[5] = new SqlParameter("@Extension", this.txbExtension.Text.Trim());
                ParametrosEnt[6] = new SqlParameter("@Celular", this.txbCelular.Text.Trim());
                ParametrosEnt[7] = new SqlParameter("@email", this.txbEmail.Text.Trim());
                ParametrosEnt[8] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                ParametrosEnt[9] = new SqlParameter("@FechaCreacion", DateTime.Now.Date);
                ParametrosEnt[10] = new SqlParameter("@TipoIdentificacion", this.CmbTipoIdentificacion.SelectedIndex);
                ParametrosEnt[11] = new SqlParameter("@RazonCial", this.TxbRazonCial.Text.Trim());

                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "ContratistasEspe");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.txbIdentificacion.Text.Trim());
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                GuardarDatos GuardarDatos = new GuardarDatos();
                Ent_Contratistas Reader = new Ent_Contratistas();

                Reader = Maestro.Contratistas("SpConsulta_Tablas", Parametros_Consulta);

                if (Reader.Nombre == null)
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                else
                    ParametrosEnt[0] = new SqlParameter("@Op", "U");

                GuardarDatos.booleano("GrbBascula_Contratistas", ParametrosEnt);

                if (Reader.Identificacion == null)
                    MessageBox.Show("Propietario creado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Propietario actualizado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txbIdentificacion_Leave(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "ContratistasEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.txbIdentificacion.Text.Trim());
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Contratistas Reader = new Ent_Contratistas();

            Reader = Maestro.Contratistas("SpConsulta_Tablas", Parametros_Consulta);

            if (Reader.Nombre == null)
            {
                this.CmbTipoIdentificacion.SelectedIndex = -1;
                this.TxbRazonCial.Text = "";
                this.TxbRazonCial.Enabled = false;
                this.txbNombre.Text = "";
                this.txbApellido.Text = "";
                this.txbTelfijo.Text = "";
                this.txbExtension.Text = "";
                this.txbCelular.Text = "";
                this.txbEmail.Text = "";
                this.ChbEstado.Checked = true;
            }
            else
            {
                this.CmbTipoIdentificacion.SelectedIndex = Reader.TipoIdentificacion;
                this.TxbRazonCial.Text = Reader.RazonCial.Trim();
                this.txbNombre.Text = Reader.Nombre.Trim();
                this.txbApellido.Text = Reader.Apellido.Trim();
                this.txbTelfijo.Text = Reader.TelFijo.Trim();
                this.txbExtension.Text = Reader.Extension.Trim();
                this.txbCelular.Text = Reader.Celular.Trim();
                this.txbEmail.Text = Reader.Email.Trim();
                this.ChbEstado.Checked = Reader.Deshabilitado;
                if (this.CmbTipoIdentificacion.SelectedIndex == 0)
                    this.TxbRazonCial.Enabled = true;
                else
                    this.TxbRazonCial.Enabled = false;

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txbIdentificacion.Text = "";
            this.TxbRazonCial.Text = "";
            this.txbNombre.Text = "";
            this.txbApellido.Text = "";
            this.txbTelfijo.Text = "";
            this.txbExtension.Text = "";
            this.txbCelular.Text = "";
            this.txbEmail.Text = "";
            this.ChbEstado.Checked = true;
            this.CmbTipoIdentificacion.SelectedIndex = -1;
            this.txbIdentificacion.Focus();
        }

        private void ChbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbEstado.Checked)
                this.ChbEstado.Text = "Activo";
            else
                this.ChbEstado.Text = "Bloqueado";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[12];
                    ParametrosEnt[0] = new SqlParameter("@Op", "D");
                    ParametrosEnt[1] = new SqlParameter("@Identificacion", this.txbIdentificacion.Text.Trim());
                    ParametrosEnt[2] = new SqlParameter("@Nombre", this.txbNombre.Text.Trim());
                    ParametrosEnt[3] = new SqlParameter("@Apellido", this.txbNombre.Text.Trim());
                    ParametrosEnt[4] = new SqlParameter("@TelFijo", this.txbNombre.Text.Trim());
                    ParametrosEnt[5] = new SqlParameter("@Extension", this.txbNombre.Text.Trim());
                    ParametrosEnt[6] = new SqlParameter("@Celular", this.txbNombre.Text.Trim());
                    ParametrosEnt[7] = new SqlParameter("@email", this.txbNombre.Text.Trim());
                    ParametrosEnt[8] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                    ParametrosEnt[9] = new SqlParameter("@FechaCreacion", DateTime.Now.Date);
                    ParametrosEnt[10] = new SqlParameter("@TipoIdentificacion", this.CmbTipoIdentificacion.SelectedIndex);
                    ParametrosEnt[11] = new SqlParameter("@RazonCial", this.TxbRazonCial.Text.Trim());

                    GuardarDatos GuardarDatos = new GuardarDatos();
                    bool Eliminado = GuardarDatos.booleano("GrbBascula_Contratistas", ParametrosEnt);

                    if (Eliminado)
                        MessageBox.Show("Contratista Elimindo satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Consultas Forma = new Frm_Consultas(9);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void CmbTipoIdentificacion_Leave(object sender, EventArgs e)
        {
            if (this.CmbTipoIdentificacion.SelectedIndex == 0)
                this.TxbRazonCial.Enabled = true;
            else
            {
                this.TxbRazonCial.Enabled = false;
                this.TxbRazonCial.Text = "";
            }
        }

        private void CmbTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbTipoIdentificacion.SelectedIndex == 0)
                this.TxbRazonCial.Enabled = true;
            else
            {
                this.TxbRazonCial.Enabled = false;
                this.TxbRazonCial.Text = "";
            }
        }
    }
}

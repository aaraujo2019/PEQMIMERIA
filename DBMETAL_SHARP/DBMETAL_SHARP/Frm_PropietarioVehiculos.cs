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
    public partial class Frm_PropietarioVehiculos : Form
    {
        public Frm_PropietarioVehiculos( string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        public void EjecutaPasarDato(string Dato)
        {
            this.txbIdentificacion.Text = Dato;
            txbIdentificacion_Leave(null, null);
        }

        public int Op = 0;


        public string Login;
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txbIdentificacion.Text = "";
            this.txbNombre.Text = "";
            this.txbApellido.Text = "";
            this.txbTelfijo.Text = "";
            this.txbExtension.Text = "";
            this.txbCelular.Text = "";
            this.txbEmail.Text = "";
            this.ChbEstado.Checked = true;
            this.txbIdentificacion.Focus();
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
                SqlParameter[] ParametrosEnt = new SqlParameter[10];
                ParametrosEnt[1] = new SqlParameter("@Identificacion", this.txbIdentificacion.Text.Trim());
                ParametrosEnt[2] = new SqlParameter("@Nombre", this.txbNombre.Text.Trim());
                ParametrosEnt[3] = new SqlParameter("@Apellido", this.txbApellido.Text.Trim());
                ParametrosEnt[4] = new SqlParameter("@TelFijo", this.txbTelfijo.Text.Trim());
                ParametrosEnt[5] = new SqlParameter("@Extension", this.txbExtension.Text.Trim());
                ParametrosEnt[6] = new SqlParameter("@Celular", this.txbCelular.Text.Trim());
                ParametrosEnt[7] = new SqlParameter("@email", this.txbEmail.Text.Trim());
                ParametrosEnt[8] = new SqlParameter("@Estado", this.ChbEstado.Checked);
                ParametrosEnt[9] = new SqlParameter("@FechaCreacion", DateTime.Now.Date);

                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "PropietariosEspe");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.txbIdentificacion.Text.Trim());
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                GuardarDatos GuardarDatos = new GuardarDatos();
                Ent_Propietarios Reader = new Ent_Propietarios();

                Reader = Maestro.Propietarios("SpConsulta_Tablas", Parametros_Consulta);

                if (Reader.Nombre == null)
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                else
                    ParametrosEnt[0] = new SqlParameter("@Op", "U");

                GuardarDatos.booleano("GrbBascula_Propietarios", ParametrosEnt);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[10];
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

                    GuardarDatos GuardarDatos = new GuardarDatos();
                    bool Eliminado = GuardarDatos.booleano("GrbBascula_Propietarios", ParametrosEnt);

                    if (Eliminado)
                        MessageBox.Show("Propietario Elimindo satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Problemas al Eliminar.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txbIdentificacion_Leave(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "PropietariosEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.txbIdentificacion.Text.Trim());
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Propietarios Reader = new Ent_Propietarios();

            Reader = Maestro.Propietarios("SpConsulta_Tablas", Parametros_Consulta);

            if (Reader.Nombre == null)
            {
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
                this.txbNombre.Text = Reader.Nombre;
                this.txbApellido.Text = Reader.Apellido;
                this.txbTelfijo.Text = Reader.TelFijo;
                this.txbExtension.Text = Reader.Extension;
                this.txbCelular.Text = Reader.Celular;
                this.txbEmail.Text = Reader.Email;
                this.ChbEstado.Checked = Reader.Deshabilitado;
            }
        }

        private void ChbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbEstado.Checked)
                this.ChbEstado.Text = "Activo";
            else
                this.ChbEstado.Text = "Bloqueado";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Consultas Forma = new Frm_Consultas(5);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void Frm_PropietarioVehiculos_Load(object sender, EventArgs e)
        {

        }
    }
}

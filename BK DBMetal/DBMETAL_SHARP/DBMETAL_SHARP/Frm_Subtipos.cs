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
    public partial class Frm_Subtipos : Form
    {
        public Frm_Subtipos(string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        public string Login { get; set; }
        public int Op = 0;
        public int IdUsuario = 0;

        public void EjecutaPasarDato(string Dato)
        {
            this.btnNew.PerformClick();
            this.TxbCodigo.Text = Dato;
            TxbCodigo_Leave(null, null);
            this.TxbCodigo.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.TxbCodigo.Text = "";
            this.TxbNombre.Text = "";
            this.TxbDetalle.Text = "";
            this.TxbCodigo.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] ParametrosEnt = new SqlParameter[4];
                ParametrosEnt[1] = new SqlParameter("@Codigo", this.TxbCodigo.Text.Trim());
                ParametrosEnt[2] = new SqlParameter("@Nombre", this.TxbNombre.Text.Trim());
                ParametrosEnt[3] = new SqlParameter("@Detalle", this.TxbDetalle.Text.Trim());

                SqlParameter[] Parametros_Consulta = new SqlParameter[4];
                Parametros_Consulta[0] = new SqlParameter("@Op", "SubTiposEspe");
                Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.TxbCodigo.Text.Trim());
                Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                GuardarDatos Guardar = new GuardarDatos();
                Ent_SubTipos Reader = new Ent_SubTipos();

                Reader = Maestro.Subtipos("SpConsulta_Tablas", Parametros_Consulta);

                if (Reader.Detalle == null)
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                else
                    ParametrosEnt[0] = new SqlParameter("@Op", "U");

                Guardar.booleano("Sp_Guardar_Subtipos", ParametrosEnt);


                if (Reader.Codigo == null)
                {
                    MessageBox.Show("SubTipo creado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("SubTipo actualizado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea Eliminar este registro", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);

            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[4];
                    ParametrosEnt[0] = new SqlParameter("@Op", "D");
                    ParametrosEnt[1] = new SqlParameter("@Codigo", this.TxbCodigo.Text.Trim());
                    ParametrosEnt[2] = new SqlParameter("@Nombre", this.TxbNombre.Text.Trim());
                    ParametrosEnt[3] = new SqlParameter("@Detalle", this.TxbDetalle.Text.Trim());


                    GuardarDatos GuardarDatos = new GuardarDatos();
                    GuardarDatos.booleano("Sp_Guardar_SubTipos", ParametrosEnt);

                    MessageBox.Show("Subtipo eliminado satisfactoriamente.", "Informe del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch (Exception ExtTipo1)
                {
                    MessageBox.Show("Error Controlado al Elminar " + ExtTipo1.Message);
                }
                this.btnNew.PerformClick();
            }
        }

        private void TxbCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] Parametros_ConsultaCargos = new SqlParameter[4];
                Parametros_ConsultaCargos[0] = new SqlParameter("@Op", "SubTiposEspe");
                Parametros_ConsultaCargos[1] = new SqlParameter("@ParametroChar", this.TxbCodigo.Text.Trim());
                Parametros_ConsultaCargos[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_ConsultaCargos[3] = new SqlParameter("@ParametroNuemric", "0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                GuardarDatos Guardar = new GuardarDatos();
                Ent_SubTipos Reader = new Ent_SubTipos();

                Reader = Maestro.Subtipos("SpConsulta_Tablas", Parametros_ConsultaCargos);

                if (Reader.Codigo != null)
                {
                    this.TxbNombre.Text = Reader.Nombre;
                    this.TxbDetalle.Text = Reader.Detalle;

                }
                else
                {
                    this.TxbNombre.Text = "";
                    this.TxbDetalle.Text = "";
                }
            }
            catch (Exception Ex1)
            {
                MessageBox.Show(Ex1.Message); ;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Frm_Consultas FrmConsultas = new Frm_Consultas(12);
            FrmConsultas.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            FrmConsultas.ShowDialog();
        }
    }
}

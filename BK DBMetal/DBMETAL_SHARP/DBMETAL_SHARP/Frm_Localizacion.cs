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
    public partial class Frm_Localizacion : Form
    {
        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }

        public Frm_Localizacion(string User)
        {
            InitializeComponent();

            this.Usuario = User.Trim();
        }
        private void Limpiar(int Tipo)
        {
            switch (Tipo)
            {
                case 1:
                    TxbIdentificacion.Text = "";
                    TxbIdentificacion.Focus();
                    TxbNombre.Text = "";
                    txtDetail.Text = "";
                    ChbEstado.Checked = false;
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Limpiar(1);
        }

        private void Frm_PersonalMuestreo_Load(object sender, EventArgs e)
        {
            btnNew.PerformClick();
            this.IpLocal = string.Empty;
            this.IpPublica = string.Empty;
            this.SerialHDD = string.Empty;
        }

     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxbIdentificacion.Text.Trim()) && !String.IsNullOrEmpty(TxbNombre.Text.Trim()))
            {
                try
                {
                    if (string.IsNullOrEmpty(this.IpLocal))
                        this.IpLocal = DireccionIP.Local();

                    if (string.IsNullOrEmpty(this.IpPublica))
                        this.IpPublica = DireccionIP.Publica();

                    if (string.IsNullOrEmpty(this.SerialHDD))
                        this.SerialHDD = DireccionIP.SerialNumberDisk();

                    GuardarDatos Guardar = new GuardarDatos();
                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_Localizacion("", TxbIdentificacion.Text.Trim(), TxbNombre.Text.Trim(), ChbEstado.Checked, txtDetail.Text);
                    if (Guardar.booleano("Sp_Guardar_Localizacion", ParamSQl))
                        if (ParamSQl[0].Value.ToString() == "I")
                        {
                            MessageBox.Show("La localización se almacenado con Exito");
                            LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo localización " + TxbIdentificacion.Text.Trim() + " " + TxbNombre.Text.Trim(), "Maestro Localización - Crear");
                        }
                        else
                        {
                            MessageBox.Show("La localización se ha actualizado con Exito");
                            LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se modifico la localización" + TxbIdentificacion.Text.Trim() + " " + TxbNombre.Text.Trim(), "Maestro Localización - Modificar");
                        }

                    Limpiar(1);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else
                if (String.IsNullOrEmpty(TxbIdentificacion.Text.Trim()))
                MessageBox.Show("Debe de ingresar un código");
            else
                MessageBox.Show("Debe de ingresar un nombre");

        }

        private void TxbIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Consultas FrmConsultas = new Frm_Consultas(23);
            FrmConsultas.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            FrmConsultas.ShowDialog();

        }

        public void EjecutaPasarDato(string Dato)
        {
            this.btnNew.PerformClick();
            TxbIdentificacion.Text = Dato.Trim();
            TxbIdentificacion_Leave(null, null);
            this.TxbIdentificacion.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxbIdentificacion.Text.Trim()))
            {
                DialogResult Opcion = MessageBox.Show("Realmente desea eliminar la localización", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Opcion == DialogResult.Yes)
                {
                    try
                    {
                        GuardarDatos Guardar = new GuardarDatos();
                        SqlParameter[] ParamSQl = GuardarDatos.Parametros_Localizacion("D", TxbIdentificacion.Text.Trim(), TxbNombre.Text.Trim(), ChbEstado.Checked, txtDetail.Text);
                        if (Guardar.booleano("Sp_Guardar_Localizacion", ParamSQl))
                        {
                            Limpiar(1);
                            MessageBox.Show("Localización eliminada con Exito");
                            LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se elimino localización " + TxbIdentificacion.Text.Trim() + " " + TxbNombre.Text.Trim(), "Maestro Localización - Elimino localización");

                        }
                        else
                            MessageBox.Show("Localización no se elimino debido a que no existe");
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Debe de seleccionar una código para eliminar");
        }

        private void TxbIdentificacion_Leave(object sender, EventArgs e)
        {
            try
            {
                Ent_Localizacion Reader = ConsultaEntidades.ObtenerLocalizacion("ObeterLocalizacion", TxbIdentificacion.Text.Trim(), 0, 0.00).FirstOrDefault();
                if (Reader != null)
                {
                    TxbNombre.Text = Reader.nombre.Trim();
                    txtDetail.Text = Reader.Detalle;
                    ChbEstado.Checked = Reader.estado;
                }
            }
            catch (Exception Ex1)
            {
                MessageBox.Show(Ex1.Message); ;
            }
        }
    }
}

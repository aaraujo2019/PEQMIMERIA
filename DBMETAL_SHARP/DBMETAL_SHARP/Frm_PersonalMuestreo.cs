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
    public partial class Frm_PersonalMuestreo : Form
    {
        public Frm_PersonalMuestreo(string User)
        {
            InitializeComponent();
            this.Usuario = User.Trim();
        }
        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }

        public void EjecutaPasarDato(string Dato)
        {
            this.btnNew.PerformClick();
            TxbIdentificacion.Text = Dato;
            TxbIdentificacion_Leave(null, null);
            this.TxbIdentificacion.Focus();
        }

        private void Limpiar(int Tipo)
        {
            switch (Tipo)
            {
                case 1:
                    TxbIdentificacion.Text = "";
                    TxbIdentificacion.Focus();
                    TxbNombre.Text = "";
                    TxbApellido.Text = "";
                    TxbDireccion.Text = "";
                    TxbTelFijo.Text = "";
                    TxbCelular.Text = "";
                    TxbCelular.Text = "";
                    TxbEmail.Text = "";
                    ChbEstado.Checked = false;
                    ChbEncargado.Checked = false;
                    ChbTercero.Checked = false;
                    ChbSeguridad.Checked = false;
                    ChbCuartea.Checked = false;
                    PtbPersonal.Image = DBMETAL_SHARP.Properties.Resources.User;
                    break;
                case 2:
                    TxbNombre.Text = "";
                    TxbApellido.Text = "";
                    TxbDireccion.Text = "";
                    TxbTelFijo.Text = "";
                    TxbCelular.Text = "";
                    TxbCelular.Text = "";
                    TxbEmail.Text = "";
                    ChbEstado.Checked = false;
                    ChbEncargado.Checked = false;
                    ChbTercero.Checked = false;
                    ChbSeguridad.Checked = false;
                    ChbCuartea.Checked = false;
                    PtbPersonal.Image = DBMETAL_SHARP.Properties.Resources.User;
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

        private void BtnBuscarFoto_Click(object sender, EventArgs e)
        {
            this.PtbPersonal.Image = Seleccionar.Imagen("\\DBMETAL_SHARP\\", "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.JPEG", this.PtbPersonal.Image);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int rol = 0;
            int Error = 0;
            if (!ChbCuartea.Checked && !ChbEncargado.Checked && !ChbSeguridad.Checked && !ChbTercero.Checked)
                Error = 1;
            else
            if (ChbEncargado.Checked)
                rol = 1;
            else
            {
                if (ChbSeguridad.Checked)
                    rol = 2;
                else
                {
                    if (ChbTercero.Checked)
                        rol = 3;
                    else
                        rol = 4;
                }
            }


            if (TxbIdentificacion.Text.Trim().Length == 0)
                Error = 2;
            if (Error == 0)
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
                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_PersonalMuestreo("", TxbIdentificacion.Text.Trim(), TxbNombre.Text.Trim(), TxbApellido.Text.Trim(), TxbDireccion.Text.Trim(), TxbTelFijo.Text.Trim(), TxbCelular.Text.Trim(), TxbEmail.Text.Trim(), rol, Convertir.ImagenEnByte(PtbPersonal.Image), ChbEstado.Checked, DtpCreado.Value);
                    if (Guardar.booleano("Sp_Guardar_PersonalMuestreo", ParamSQl))
                    {
                        Limpiar(1);

                        if (ParamSQl[0].Value.ToString() == "I")
                        {
                            MessageBox.Show("Personal de Muestreo almacenado con Exito");
                            LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo Personal de Muestreo " + TxbIdentificacion.Text.Trim() + " " + TxbNombre.Text.Trim() + " " + TxbApellido.Text.Trim(), "Maestros - Crear");
                        }
                        else
                        {
                            MessageBox.Show("Personal de Muestreo actualizado con Exito");
                            LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se modifico Personal de Muestreo " + TxbIdentificacion.Text.Trim() + " " + TxbNombre.Text.Trim() + " " + TxbApellido.Text.Trim(), "Maestros - Modificar");
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            if (Error == 1)
                MessageBox.Show("Debe Seleccionar un tipo de Rol del Personal. ( Encargado / Seguridad / Tercero / Cuarte)");
            if (Error == 2)
                MessageBox.Show("Debe reportar una identificacion");
        }

        private void TxbIdentificacion_Leave(object sender, EventArgs e)
        {
            try
            {
                Ent_PersonalMuestreo Reader = ConsultaEntidades.PersonalMuestreo("PersonalMuestreo", TxbIdentificacion.Text.Trim(), 0, 0.00);
                if (Reader.Nombre != null)
                {
                    TxbNombre.Text = Reader.Nombre;
                    TxbApellido.Text = Reader.Apellido;
                    TxbDireccion.Text = Reader.Direccion;
                    TxbTelFijo.Text = Reader.TelFijo;
                    TxbCelular.Text = Reader.Celular;
                    TxbEmail.Text = Reader.Email;
                    DtpCreado.Value = Reader.Create;

                    switch (Reader.Rol)
                    {
                        case 1:
                            ChbEncargado.Checked = true;
                            break;
                        case 2:
                            ChbTercero.Checked = true;
                            break;
                        case 3:
                            ChbSeguridad.Checked = true;
                            break;
                        case 4:
                            ChbCuartea.Checked = true;
                            break;
                        default:
                            break;
                    }
                    ChbEstado.Checked = Reader.Estado;
                    if (Reader.Foto != null)
                        PtbPersonal.Image = Convertir.byteEnImagen(Reader.Foto);
                }
                else
                    this.Limpiar(2);
            }
            catch (Exception Ex1)
            {
                MessageBox.Show(Ex1.Message); ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Consultas FrmConsultas = new Frm_Consultas(22);
            FrmConsultas.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            FrmConsultas.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea eliminar el Personal de Muestreo", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    GuardarDatos Guardar = new GuardarDatos();
                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_PersonalMuestreo("D", TxbIdentificacion.Text.Trim(), TxbNombre.Text.Trim(), TxbApellido.Text.Trim(), TxbDireccion.Text.Trim(), TxbTelFijo.Text.Trim(), TxbCelular.Text.Trim(), TxbEmail.Text.Trim(), 1, Convertir.ImagenEnByte(PtbPersonal.Image), ChbEstado.Checked, DateTime.Now);
                    if (Guardar.booleano("Sp_Guardar_PersonalMuestreo", ParamSQl))
                    {
                        MessageBox.Show("Personal de Muestreo almacenado con Exito");
                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo Personal de Muestreo " + TxbIdentificacion.Text.Trim() + " " + TxbNombre.Text.Trim() + " " + TxbApellido.Text.Trim(), "Maestros - Crear");
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ChbEncargado_CheckedChanged(object sender, EventArgs e)
        {
            //ChbEncargado.Checked = true;
        }

        private void ChbTercero_CheckedChanged(object sender, EventArgs e)
        {
            //ChbTercero.Checked = true;
        }

        private void ChbSeguridad_CheckedChanged(object sender, EventArgs e)
        {
            //ChbSeguridad.Checked = true;
        }

        private void ChbCuartea_CheckedChanged(object sender, EventArgs e)
        {
            //ChbCuartea.Checked = true;
        }

        private void ChbEncargado_CheckStateChanged(object sender, EventArgs e)
        {
            //ChbEncargado.Checked = true;
            if (ChbTercero.Checked)
                ChbTercero.Checked = false;
            if (ChbSeguridad.Checked)
                ChbSeguridad.Checked = false;
            if (ChbCuartea.Checked)
                ChbCuartea.Checked = false;

            //ChbEncargado.Checked = true;
        }

        private void ChbTercero_CheckStateChanged(object sender, EventArgs e)
        {

            //ChbTercero.Checked = true;
            if (ChbEncargado.Checked)
                ChbEncargado.Checked = false;
            if (ChbSeguridad.Checked)
                ChbSeguridad.Checked = false;
            if (ChbCuartea.Checked)
                ChbCuartea.Checked = false;
            //ChbTercero.Checked = true;
        }

        private void ChbSeguridad_CheckStateChanged(object sender, EventArgs e)
        {
            //ChbSeguridad.Checked = true;
            if (ChbEncargado.Checked)
                ChbEncargado.Checked = false;
            if (ChbTercero.Checked)
                ChbTercero.Checked = false;
            if (ChbCuartea.Checked)
                ChbCuartea.Checked = false;

            //ChbSeguridad.Checked = true;
        }

        private void ChbCuartea_CheckStateChanged(object sender, EventArgs e)
        {
            //ChbCuartea.Checked = true;
            if (ChbEncargado.Checked)
                ChbEncargado.Checked = false;
            if (ChbTercero.Checked)
                ChbTercero.Checked = false;
            if (ChbSeguridad.Checked)
                ChbSeguridad.Checked = false;

            //ChbCuartea.Checked = true;
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {

            //foreach (int indexChecked in checkedListBox1.CheckedIndices)
            //{
            //    // The indexChecked variable contains the index of the item.
            //    MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" +
            //                    checkedListBox1.GetItemCheckState(indexChecked).ToString() + ".");
            //}

            //// Next show the object title and check state for each item selected.
            //foreach (object itemChecked in checkedListBox1.CheckedItems)
            //{

            //    // Use the IndexOf method to get the index of an item.
            //    MessageBox.Show("Item with title: \"" + itemChecked.ToString() +
            //                    "\", is checked. Checked state is: " +
            //                    checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() + ".");
            //}
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {

        }
    }
}

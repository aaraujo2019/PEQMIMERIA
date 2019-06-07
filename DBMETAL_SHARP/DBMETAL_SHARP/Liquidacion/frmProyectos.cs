using Entidades;
using ReglasdeNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace DBMETAL_SHARP.Liquidacion
{
    public partial class frmProyectos : Form
    {
        private DatosProyectos datosProyectos = new DatosProyectos();
        private Ent_Proyectos proyecto;
        public bool vacio;
        public frmProyectos()
        {
            InitializeComponent();
        }

        private void ValidarControles(GroupBox groupbox)
        {
            foreach (Control control in groupbox.Controls)
            {
                if (control.GetType().Equals(typeof(TextBox)))
                {
                    if (control.Text == string.Empty)
                    {
                        if (control.Name != "txtAnalisis")
                        {
                            MessageBox.Show(string.Concat("El campo ", control.Tag, " es obligatorio."));
                            return;
                        }
                    }
                }
                else if (control.GetType().Equals(typeof(ComboBox)))
                {
                    if (control.Text == string.Empty)
                    {
                        MessageBox.Show(string.Concat("El campo ", control.Tag, " es obligatorio."));
                        return;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtAnalisis.Text = string.Empty;
            CmbPlaza.SelectedValue = -999;
            proyecto = new Ent_Proyectos();
        }

        private void CargarComboPlazas()
        {
            CmbPlaza.DataSource = datosProyectos.getCmbPlazasProyectos();
            CmbPlaza.ValueMember = "Id";
            CmbPlaza.DisplayMember = "Codigo";
        }

        private void frmProyectos_Load(object sender, EventArgs e)
        {
            CargarComboPlazas();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
               
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (proyecto == null)
                proyecto = new Ent_Proyectos();

            ValidarControles(groupBox2);              
            proyecto.Codigo = txtCodigo.Text;
            proyecto.Nombre = txtNombre.Text;
            proyecto.Descripcion = txtDescripcion.Text;
            proyecto.IdPlaza = Convert.ToInt32(CmbPlaza.SelectedValue);
            proyecto.Analisis = txtAnalisis.Text;
            datosProyectos.insertProyecto(proyecto);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == string.Empty) MessageBox.Show("Si desea buscar debe ingresar el código");

            DataTable proyectoEncontrado = datosProyectos.getProyectoPorCodigo(txtCodigo.Text);

            frmProyectos frmP = new frmProyectos
            {
                
            };

        }
    }
}

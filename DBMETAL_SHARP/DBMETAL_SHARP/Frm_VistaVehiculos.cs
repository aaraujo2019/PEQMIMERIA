using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_VistaVehiculos : Form
    {
        public Frm_VistaVehiculos(string login, string placa)
        {
            InitializeComponent();
            this.Placa = placa;
            this.Login = login;
        }

        string Login { get; set; }
        string Placa { get; set; }

        public static class ImageConvert
        {
            public static byte[] imageToByte(System.Drawing.Image imageIn)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                byte[] arrImg = ms.GetBuffer();
                ms.Flush();
                ms.Close();
                return arrImg;
            }
            public static System.Drawing.Image byteToImage(byte[] byteArrayIn)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
            }
        }


        private void Frm_VistaVehiculos_Load(object sender, EventArgs e)
        {
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "VehiculosEspe");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", this.Placa);
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            ConsultaEntidades Maestro = new ConsultaEntidades();
            Ent_Vehiculo Reader = new Ent_Vehiculo();

            Reader = Maestro.Vehiculo("SpConsulta_Tablas", Parametros_Consulta);
            this.TxbPlaca.Text = Reader.Placa;
            this.ChbEstado.Checked = Reader.Estado;
            this.TxbLicencia.Text = Reader.Licencia;
            this.TxbNombrePropietario1.Text = Reader.NombrePropietario;
            this.TxbModelo1.Text = Reader.Modelo;
            this.TxbMarca1.Text = Reader.Marca;
            this.TxbCilindraje1.Text = Reader.Cilindraje.ToString("###,###,##0.#0").Trim();
            this.CmbTipoVehiculo1.SelectedIndex = Reader.TipoVehiculo;
            this.TxbCombustible1.Text = Reader.Combustible;
            this.TxbClase1.Text = Reader.Clase;
            this.TxbCapacidad1.Text = Reader.Peso.ToString("###,###,##0.#0").Trim();
            this.TxbMotor1.Text = Reader.Motor;
            this.TxbDetalle.Text = Reader.Descripcion;
            this.ptbVehiculo.Image = ImageConvert.byteToImage(Reader.Foto);


        }

        private void ChbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbEstado.Checked)
                this.ChbEstado.Text = "Activo";
            else
                this.ChbEstado.Text = "Bloqueado";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }
    
    }
}

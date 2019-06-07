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
    public partial class Frm_RelacionTransporteOtrosPesajes : Form
    {
        public Frm_RelacionTransporteOtrosPesajes(string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        public int Op = 0;
        public int IdUsuario = 0;
        public string Login;
        public int IdTipo;
        public int IdOrigen;

        public void EjecutaPasarDato(string Dato)
        {
            switch (Op)
            {
                case 1:
                    this.TxbTipo.Text = Dato;
                    TxbTipo_Leave(null, null);
                    break;
                case 2:
                    this.TxbOrigen.Text = Dato;
                    TxbOrigen_Leave(null, null);
                    break;
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Op = 1;
            Frm_Consultas Forma = new Frm_Consultas(7);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void TxbTipo_Leave(object sender, EventArgs e)
        {
            if (this.TxbTipo.Text.Trim().Length > 0)
            {
                SqlParameter[] Parametros_ConsultaTipo = new SqlParameter[4];
                Parametros_ConsultaTipo[0] = new SqlParameter("@Op", "TiposEspe");
                Parametros_ConsultaTipo[1] = new SqlParameter("@ParametroChar", this.TxbTipo.Text.Trim());
                Parametros_ConsultaTipo[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_ConsultaTipo[3] = new SqlParameter("@ParametroNuemric", "0.0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                Ent_TiposMineral ReaderTipos = new Ent_TiposMineral();
                ReaderTipos = Maestro.TiposMineral("SpConsulta_Tablas", Parametros_ConsultaTipo);

                if (ReaderTipos.Codigo != null)
                {
                    this.TxbNombreTipo.Text = ReaderTipos.Nombre;
                    this.IdTipo = ReaderTipos.Id;
                }
                else
                {
                    this.TxbTipo.Text = "";
                    this.TxbNombreTipo.Text = "";
                }
            }

            #region Marcando los Check del arbol que cumplan la condicion
            if (this.TxbTipo.Text.Trim().Length > 0 && this.TxbOrigen.Text.Trim().Length > 0)
            {
                SqlParameter[] Parametros = new SqlParameter[4];
                Parametros[0] = new SqlParameter("@Op", "ConsultaTipoOrigen");
                Parametros[1] = new SqlParameter("@ParametroChar", "");
                Parametros[2] = new SqlParameter("@ParametroInt", this.IdTipo);
                Parametros[3] = new SqlParameter("@ParametroNuemric", this.IdOrigen);
                ConsultaEntidades Maestro = new ConsultaEntidades();             
                List<Ent_RelacionTipoOrigenDestino> ListaTipo = new List<Ent_RelacionTipoOrigenDestino>();
                ListaTipo = Maestro.TipoOrigenDestino("SpConsulta_Tablas", Parametros);
              
                foreach (Ent_RelacionTipoOrigenDestino item in ListaTipo)
                {
                    string  Tag = item.CodigoDestino;
                    bool EstadoTag = item.Estado;
                    foreach (TreeNode tree in this.TreeDestinos.Nodes)
                    {
                        if (tree.Tag.ToString().Trim() == Tag.Trim())
                            tree.Checked = EstadoTag;
                    }
                }
            }
            #endregion
        }

        private void TxbOrigen_Leave(object sender, EventArgs e)
        {
            if (this.TxbOrigen.Text.Trim().Length > 0)
            {
                SqlParameter[] Parametros_ConsultaOrigen = new SqlParameter[4];
                Parametros_ConsultaOrigen[0] = new SqlParameter("@Op", "OrigenEspe");
                Parametros_ConsultaOrigen[1] = new SqlParameter("@ParametroChar", this.TxbOrigen.Text.Trim());
                Parametros_ConsultaOrigen[2] = new SqlParameter("@ParametroInt", "0");
                Parametros_ConsultaOrigen[3] = new SqlParameter("@ParametroNuemric", "0.0");

                ConsultaEntidades Maestro = new ConsultaEntidades();
                Ent_Origen ReaderOrigen = new Ent_Origen();

                ReaderOrigen = Maestro.Origen("SpConsulta_Tablas", Parametros_ConsultaOrigen);
                if (ReaderOrigen.Codigo != null)
                {
                    this.TxbNombreOrigen.Text = ReaderOrigen.Nombre;
                    this.IdOrigen = ReaderOrigen.Id;
                }
                else
                {
                    this.TxbOrigen.Text = "";
                    this.TxbNombreOrigen.Text = "";
                }
            }

            #region Marcando los Check del arbol que cumplan la condicion
            if (this.TxbTipo.Text.Trim().Length > 0 && this.TxbOrigen.Text.Trim().Length > 0)
            {
                SqlParameter[] Parametros = new SqlParameter[4];
                Parametros[0] = new SqlParameter("@Op", "ConsultaTipoOrigen");
                Parametros[1] = new SqlParameter("@ParametroChar", "");
                Parametros[2] = new SqlParameter("@ParametroInt", this.IdTipo);
                Parametros[3] = new SqlParameter("@ParametroNuemric", this.IdOrigen);
                ConsultaEntidades Maestro = new ConsultaEntidades();
                List<Ent_RelacionTipoOrigenDestino> ListaTipo = new List<Ent_RelacionTipoOrigenDestino>();
                ListaTipo = Maestro.TipoOrigenDestino("SpConsulta_Tablas", Parametros);

                foreach (Ent_RelacionTipoOrigenDestino item in ListaTipo)
                {
                    string Tag = item.CodigoDestino;
                    bool EstadoTag = item.Estado;
                    foreach (TreeNode tree in this.TreeDestinos.Nodes)
                    {
                        if (tree.Tag.ToString().Trim() == Tag.Trim())
                            tree.Checked = EstadoTag;
                    }
                }
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op = 2;
            Frm_Consultas Forma = new Frm_Consultas(8);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            #region LLenando el TreeVieew
            SqlParameter[] Parametros_Consulta = new SqlParameter[4];
            Parametros_Consulta[0] = new SqlParameter("@Op", "LLenarTreeDestino");
            Parametros_Consulta[1] = new SqlParameter("@ParametroChar", "");
            Parametros_Consulta[2] = new SqlParameter("@ParametroInt", "0");
            Parametros_Consulta[3] = new SqlParameter("@ParametroNuemric", "0");

            Arbol.Llenar(this.TreeDestinos, Parametros_Consulta, "SpConsulta_Tablas");
            #endregion
            this.TxbTipo.Text = "";
            this.TxbNombreTipo.Text = "";
            this.TxbOrigen.Text = "";
            this.TxbNombreOrigen.Text = "";
            this.TxbTipo.Focus();
        }

        private void Frm_RelacionTransporteOtrosPesajes_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] ParametrosEnt = new SqlParameter[4];
                GuardarDatos GuardarDatos = new GuardarDatos();
                foreach (TreeNode item in this.TreeDestinos.Nodes)
                {
                    ParametrosEnt[0] = new SqlParameter("@Tipo", this.TxbTipo.Text.Trim());
                    ParametrosEnt[1] = new SqlParameter("@Origen", this.TxbOrigen.Text.Trim());
                    ParametrosEnt[2] = new SqlParameter("@Destino", item.Tag.ToString().Trim());
                    ParametrosEnt[3] = new SqlParameter("@Estado", item.Checked);

                    GuardarDatos.booleano("GrbBascula_RelacionTiposOrigenDestino", ParametrosEnt);
                }
                MessageBox.Show("Actualzacion de relacion de Tipos/Origen/Destino Realzaida con Exito.");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message); ;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

    }
}

using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_Minas : Form
    {
        public Frm_Minas(string login)
        {
            InitializeComponent();
            this.Login = login;
        }

        public int Op = 0;
        public int IdUsuario = 0;
        public string Login;


        public void EjecutaPasarDato(string Dato)
        {
            switch (Op)
            {
                case 1:
                    this.TxbCodigo.Text = Dato;
                    TxbCodigo_Leave(null, null);
                    break;

                case 2:
                    this.TxbCodigoPlaza.Text = Dato;
                    TxbCodigoPlaza_Leave(null, null);
                    break;
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            #region LLenando el Combo de las Minas
            List<Ent_VwMinas> Lista1 = new List<Ent_VwMinas>();
            Lista1 = ConsultaTablas.ListaVwMinas("VwMinas", "", 0, 0.00);

            this.CmbMinas.DataSource = Lista1;
            this.CmbMinas.DisplayMember = "Nombre";
            this.CmbMinas.ValueMember = "Id";
            this.CmbMinas.SelectedIndex = -1;
            #endregion

            #region Limpiando Datos generales Contratos Operaciones
            this.TxbCodigo.Text = "";
            this.TxbCodigoPM.Text = "";
            this.TxbNombre.Text = "";
            this.TxbExpediente.Text = "";
            this.CmbDepende.SelectedIndex = -1;
            this.CmbTenorPromedio.SelectedIndex = -1;
            this.TxbArea.Text = "";
            this.CmbMinas.SelectedIndex = -1;
            this.CmbTipoContrato.SelectedIndex = -1;
            this.TxbEste.Text = "";
            this.TxbNorte.Text = "";
            this.TxbElevacion.Text = "";
            this.TxbDetalle.Text = "";
            this.TxbCodigoPlaza.Text = "";
            this.TxbDetallePlaza.Text = "";
            this.TxbEmail.Text = "";
            this.ChbInformes.Checked = false;
            this.TxbCodigo.Focus();
            this.ChbEstado.Checked = false;
            this.ChbEstado.Text = "Estado";
            this.ChbRecuperacion.Checked = false;
            this.CmbTipoContrato.SelectedIndex = -1;
            #endregion

            #region Limpiando Page Contratos y Liquidacion
            this.CmbEsquema.SelectedIndex = -1;
            this.CmbContratista.SelectedIndex = -1;
            this.DtpContrato.Text = "";
            this.DtpInscriContrato.Text = "";
            this.DtpVenciContrato.Text = "";
            this.TxbRecuperacion.Text = "";
            this.TxbFondo.Text = "";
            this.NmrDuracion.Value = 0;
            this.ChbTenores.Checked = false;
            this.ChbAnexos.Checked = false;
            this.ChbClausulas.Checked = false;
            this.ChbFondo.Checked = false;
            this.DgvContratos.DataSource = null;
            this.TxbPorcImpuestos.Text = "0.00";
            #endregion

            #region Limpiando Page Adjuntos
            this.TxbAdjuntosPath.Text = "";
            this.TxbAdjuntosDetalle.Text = "";
            this.DtgAdjunto.DataSource = null;
            #endregion

            ConsultaEntidades Maestro = new ConsultaEntidades();

            #region LLenando el Combo de los Tipo de Contratos
            List<Ent_VwTipoContrato> Lista2 = new List<Ent_VwTipoContrato>();
            Lista2 = ConsultaTablas.ListaVwTipoContrato("VwTipoContrato", "", 0, 0.00);

            this.CmbTipoContrato.DataSource = Lista2;
            this.CmbTipoContrato.DisplayMember = "Nombre";
            this.CmbTipoContrato.ValueMember = "Id";
            this.CmbTipoContrato.SelectedIndex = 0;
            #endregion

            #region LLenando el Combo de los Contenedores
            List<Ent_Contenedores> Lista3 = new List<Ent_Contenedores>();
            Lista3 = ConsultaTablas.ListaContenedores("ContenedoresGeneral", "", 0, 0.00);

            this.CmbDepende.DataSource = Lista3;
            this.CmbDepende.DisplayMember = "Nombre";
            this.CmbDepende.ValueMember = "Codigo";
            this.CmbDepende.SelectedIndex = -1;
            #endregion

            #region LLenando el Combo de los Tipo de Empresas
            List<Ent_TiposDeEmpresa> Lista4 = new List<Ent_TiposDeEmpresa>();
            Lista4 = ConsultaTablas.ListaTipoEmpresas("TipoEmpresas", "", 0, 0.00);

            this.CmbTipoEmpresa.DataSource = Lista4;
            this.CmbTipoEmpresa.DisplayMember = "Nombre";
            this.CmbTipoEmpresa.ValueMember = "Id";
            this.CmbTipoEmpresa.SelectedIndex = -1;
            #endregion

            #region LLenando el Combo de los Esquema
            List<Ent_Esquemas> Lista5 = new List<Ent_Esquemas>();
            Lista5 = ConsultaTablas.ListaEsquemas("EsquemasGeneral", "", 0, 0.00);

            this.CmbEsquema.DataSource = Lista5;
            this.CmbEsquema.DisplayMember = "Nombre";
            this.CmbEsquema.ValueMember = "Codigo";
            this.CmbEsquema.SelectedIndex = -1;
            #endregion

            #region LLenando el Combo de los Contratistas
            List<Ent_VwContratistas> Lista6 = new List<Ent_VwContratistas>();
            Lista6 = ConsultaTablas.ListaVwContratista("VwContratistas", "", 0, 0.00);

            this.CmbContratista.DataSource = Lista6;
            this.CmbContratista.DisplayMember = "Nombre";
            this.CmbContratista.ValueMember = "Id";
            this.CmbContratista.SelectedIndex = -1;
            #endregion

            this.TxbCodigo.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            this.Dispose(true);
        }

        private void ChbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChbEstado.Checked)
                this.ChbEstado.Text = "Activo";
            else
                this.ChbEstado.Text = "Bloqueado";
        }

        private void Frm_Minas_Load(object sender, EventArgs e)
        {
            this.btnNew.PerformClick();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult Opcion = MessageBox.Show("Realmente desea Eliminar la Mina/Proyecto", "Confirmacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[16];
                    ParametrosEnt[0] = new SqlParameter("@Op", "D");
                    ParametrosEnt[1] = new SqlParameter("@Codigo", this.TxbCodigo.Text.Trim());
                    ParametrosEnt[2] = new SqlParameter("@CodigoPM", this.TxbCodigoPM.Text.Trim());
                    ParametrosEnt[3] = new SqlParameter("@Nombre", this.TxbNombre.Text.Trim());
                    ParametrosEnt[4] = new SqlParameter("@CodigoContenedor", this.CmbDepende.SelectedValue);
                    ParametrosEnt[5] = new SqlParameter("@IdMinas", this.CmbMinas.SelectedValue);
                    ParametrosEnt[6] = new SqlParameter("@IdTipoContrato", this.CmbTipoContrato.SelectedValue);
                    ParametrosEnt[7] = new SqlParameter("@TenorPromedio", this.CmbTenorPromedio.SelectedIndex);
                    ParametrosEnt[8] = new SqlParameter("@Area", Convert.ToDouble(this.TxbArea.Text.Trim()));
                    ParametrosEnt[9] = new SqlParameter("@IdTipoEmpresa", this.CmbTipoEmpresa.SelectedValue);
                    ParametrosEnt[10] = new SqlParameter("@Detalle", this.TxbDetalle.Text.Trim());
                    ParametrosEnt[11] = new SqlParameter("@Plaza", this.TxbCodigoPlaza.Text.Trim());
                    ParametrosEnt[12] = new SqlParameter("@Email", this.TxbEmail.Text.Trim());
                    ParametrosEnt[13] = new SqlParameter("@MostrarEnInformes", this.ChbInformes.Checked);
                    ParametrosEnt[14] = new SqlParameter("@RecuperacionPlanta", this.ChbRecuperacion.Checked);
                    ParametrosEnt[15] = new SqlParameter("@Estado", this.ChbEstado.Checked);

                    GuardarDatos Guardar = new GuardarDatos();
                    Guardar.booleano("Sp_GuardarMinas", ParametrosEnt);

                    MessageBox.Show("Mina/Operador Minero Eliminada satisfactoriamente.", "Informacion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.Message, "Error controlado del Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void CmbMinas_Leave(object sender, EventArgs e)
        {
            DataSet DataS;
            DataS = ConsultaTablas.Dataset("DatosMina", "", Convert.ToInt32(this.CmbMinas.SelectedValue), 0.00);
            if (DataS.Tables[0].Rows.Count > 0)
            {
                this.TxbEste.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Este"]).Trim();
                this.TxbNorte.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Norte"]).Trim();
                this.TxbElevacion.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Elevacion"]).Trim();
                this.TxbExpediente.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Expediente"]).Trim();
            }

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Op = 1;
            Frm_Consultas Forma = new Frm_Consultas(6);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void TxbCodigo_Leave(object sender, EventArgs e)
        {
            Ent_TblMinas TblMinas = new Ent_TblMinas();
            TblMinas = ConsultaTablas.TblMinas("TblMinasEspe", this.TxbCodigo.Text.Trim(), 0, 0.00);
            if (string.IsNullOrEmpty(TblMinas.Codigo))
            {
                #region LLenando el Combo de las Minas
                List<Ent_VwMinas> Lista1 = new List<Ent_VwMinas>();
                Lista1 = ConsultaTablas.ListaVwMinas("VwMinas", "", 0, 0.00);

                this.CmbMinas.DataSource = Lista1;
                this.CmbMinas.DisplayMember = "Nombre";
                this.CmbMinas.ValueMember = "Id";
                this.CmbMinas.SelectedIndex = -1;
                #endregion

                #region Limpiando Datos generales Contratos Operaciones
                this.TxbCodigoPM.Text = "";
                this.TxbNombre.Text = "";
                this.TxbExpediente.Text = "";
                this.CmbDepende.SelectedIndex = -1;
                this.CmbTenorPromedio.SelectedIndex = -1;
                this.TxbArea.Text = "";
                this.CmbMinas.SelectedIndex = -1;
                this.CmbTipoContrato.SelectedIndex = -1;
                this.TxbEste.Text = "";
                this.TxbNorte.Text = "";
                this.TxbElevacion.Text = "";
                this.TxbDetalle.Text = "";
                this.TxbCodigoPlaza.Text = "";
                this.TxbDetallePlaza.Text = "";
                this.TxbEmail.Text = "";
                this.ChbInformes.Checked = false;
                #endregion

                #region Limpiando Page Contratos y Liquidacion
                this.CmbEsquema.SelectedIndex = -1;
                this.CmbContratista.SelectedIndex = -1;
                this.DtpContrato.Text = "";
                this.DtpInscriContrato.Text = "";
                this.DtpVenciContrato.Text = "";
                this.TxbRecuperacion.Text = "";
                this.TxbFondo.Text = "";
                this.NmrDuracion.Value = 0;
                this.ChbTenores.Checked = false;
                this.ChbAnexos.Checked = false;
                this.ChbClausulas.Checked = false;
                this.ChbFondo.Checked = false;
                #endregion

                ConsultaEntidades Maestro = new ConsultaEntidades();
                #region LLenando el Combo de los Tipo de Contratos
                List<Ent_VwTipoContrato> Lista2 = new List<Ent_VwTipoContrato>();
                Lista2 = ConsultaTablas.ListaVwTipoContrato("VwTipoContrato", "", 0, 0.00);

                this.CmbTipoContrato.DataSource = Lista2;
                this.CmbTipoContrato.DisplayMember = "Nombre";
                this.CmbTipoContrato.ValueMember = "Id";
                this.CmbTipoContrato.SelectedIndex = 0;
                #endregion

                #region LLenando el Combo de los Contenedores
                List<Ent_Contenedores> Lista3 = new List<Ent_Contenedores>();
                Lista3 = ConsultaTablas.ListaContenedores("Contenedores", "", 0, 0.00);

                this.CmbDepende.DataSource = Lista3;
                this.CmbDepende.DisplayMember = "Nombre";
                this.CmbDepende.ValueMember = "Codigo";
                this.CmbDepende.SelectedIndex = -1;
                #endregion

                #region LLenando el Combo de los Tipo de Empresas
                List<Ent_TiposDeEmpresa> Lista4 = new List<Ent_TiposDeEmpresa>();
                Lista4 = ConsultaTablas.ListaTipoEmpresas("TipoEmpresas", "", 0, 0.00);

                this.CmbTipoEmpresa.DataSource = Lista4;
                this.CmbTipoEmpresa.DisplayMember = "Nombre";
                this.CmbTipoEmpresa.ValueMember = "Id";
                this.CmbTipoEmpresa.SelectedIndex = -1;
                #endregion
            }
            else
            {
                #region LLenando los Combo de la page principal
                this.CmbMinas.SelectedValue = TblMinas.IdMina;
                this.CmbTenorPromedio.SelectedIndex = Convert.ToInt32(TblMinas.TenorPromedio);
                this.CmbDepende.SelectedValue = TblMinas.CodigoContenedor;
                this.CmbTipoContrato.SelectedValue = TblMinas.IdTipoContrato;
                this.CmbTipoEmpresa.SelectedValue = TblMinas.IdTipoEmpresa;
                #endregion

                #region Llenando Datos generales Contratos Operaciones
                this.TxbCodigoPM.Text = TblMinas.CodigoPM;
                this.TxbNombre.Text = TblMinas.NombreMina;
                this.TxbExpediente.Text = TblMinas.Expediente;
                this.TxbArea.Text = Convert.ToString(TblMinas.Area);
                this.TxbEste.Text = Convert.ToDouble(TblMinas.Este).ToString("###,###,##0.#0");
                this.TxbNorte.Text = Convert.ToDouble(TblMinas.Norte).ToString("###,###,##0.#0");
                this.TxbElevacion.Text = Convert.ToDouble(TblMinas.Elevacion).ToString("###,###,##0.#0");
                this.TxbDetalle.Text = TblMinas.Detalle;
                this.TxbCodigoPlaza.Text = TblMinas.CodigoPlaza;
                this.TxbDetallePlaza.Text = TblMinas.NombrePlaza;
                this.TxbEmail.Text = TblMinas.Email;
                this.ChbInformes.Checked = TblMinas.MostrarEnInformes;
                this.ChbRecuperacion.Checked = TblMinas.RecuperacionPlanta;                
                this.ChbEstado.Checked = TblMinas.Estado;
                if (this.ChbEstado.Checked)
                    this.ChbEstado.Text = "Activo";
                else
                    this.ChbEstado.Text = "Bloqueado";
                #endregion

                #region Llenado el DataGrid de los Contratos
                try
                {
                    DataSet DS = ConsultaTablas.Dataset("ContratosMinasEspe", this.TxbCodigo.Text.Trim(), 0, 0.00);
                    this.DgvContratos.DataSource = DS;
                    this.DgvContratos.DataMember = "Result";
                    this.DgvContratos.AutoResizeColumns();
                }
                catch (Exception Exc)
                {
                    MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region Llenado el DataGrid de los adjuntos
                try
                {
                    SqlParameter[] ParametrosGrid = new SqlParameter[4];
                    ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosMinasEspe");
                    ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbCodigo.Text.ToString().Trim());
                    ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                    ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DS;

                    DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                    this.DtgAdjunto.DataSource = DS;
                    this.DtgAdjunto.DataMember = "Result";
                    this.DtgAdjunto.AutoResizeColumns();
                }
                catch (Exception Exc)
                {
                    MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region Limpiando Page Contratos y Liquidacion
                this.CmbEsquema.SelectedIndex = -1;
                this.CmbContratista.SelectedIndex = -1;
                this.DtpContrato.Text = "";
                this.DtpInscriContrato.Text = "";
                this.DtpVenciContrato.Text = "";
                this.TxbRecuperacion.Text = "0.00";
                this.TxbFondo.Text = "0.00";
                this.NmrDuracion.Value = 0;
                this.ChbTenores.Checked = false;
                this.ChbAnexos.Checked = false;
                this.ChbClausulas.Checked = false;
                this.ChbFondo.Checked = false;
                this.TxbDetalleEsquema.Text = "";
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.CmbTipoEmpresa.SelectedValue.ToString());
        }

        private void BtnBuscarPlaza_Click(object sender, EventArgs e)
        {
            Op = 2;
            Frm_Consultas Forma = new Frm_Consultas(13);
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void TxbCodigoPlaza_Leave(object sender, EventArgs e)
        {
            Ent_Plazas Plazas = new Ent_Plazas();
            Plazas = ConsultaTablas.TblPlazas("PlazasEspe", this.TxbCodigoPlaza.Text.Trim(), 0, 0.00);
            if (string.IsNullOrEmpty(Plazas.Codigo))
            {
                this.TxbCodigoPlaza.Text = "";
                this.TxbDetallePlaza.Text = "";
            }
            else
            {
                this.TxbCodigoPlaza.Text = Plazas.Codigo;
                this.TxbDetallePlaza.Text = Plazas.Nombre;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] ParametrosEnt = new SqlParameter[16];
                ParametrosEnt[1] = new SqlParameter("@Codigo", this.TxbCodigo.Text.Trim());
                ParametrosEnt[2] = new SqlParameter("@CodigoPM", this.TxbCodigoPM.Text.Trim());
                ParametrosEnt[3] = new SqlParameter("@Nombre", this.TxbNombre.Text.Trim());
                ParametrosEnt[4] = new SqlParameter("@CodigoContenedor", this.CmbDepende.SelectedValue);
                ParametrosEnt[5] = new SqlParameter("@IdMinas", this.CmbMinas.SelectedValue);
                ParametrosEnt[6] = new SqlParameter("@IdTipoContrato", this.CmbTipoContrato.SelectedValue);
                ParametrosEnt[7] = new SqlParameter("@TenorPromedio", this.CmbTenorPromedio.SelectedIndex);
                ParametrosEnt[8] = new SqlParameter("@Area", Convert.ToDouble(this.TxbArea.Text.Trim()));
                ParametrosEnt[9] = new SqlParameter("@IdTipoEmpresa", this.CmbTipoEmpresa.SelectedValue);
                ParametrosEnt[10] = new SqlParameter("@Detalle", this.TxbDetalle.Text.Trim());
                ParametrosEnt[11] = new SqlParameter("@Plaza", this.TxbCodigoPlaza.Text.Trim());
                ParametrosEnt[12] = new SqlParameter("@Email", this.TxbEmail.Text.Trim());
                ParametrosEnt[13] = new SqlParameter("@MostrarEnInformes", this.ChbInformes.Checked);
                ParametrosEnt[14] = new SqlParameter("@RecuperacionPlanta", this.ChbRecuperacion.Checked);
                ParametrosEnt[15] = new SqlParameter("@Estado", this.ChbEstado.Checked);

                Ent_TblMinas TblMinas = new Ent_TblMinas();
                TblMinas = ConsultaTablas.TblMinas("TblMinasEspe", this.TxbCodigo.Text.Trim(), 0, 0.00);
                if (string.IsNullOrEmpty(TblMinas.Codigo))
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                else
                    ParametrosEnt[0] = new SqlParameter("@Op", "U");

                GuardarDatos Guardar = new GuardarDatos();
                Guardar.booleano("Sp_GuardarMinas", ParametrosEnt);


                if (string.IsNullOrEmpty(TblMinas.Codigo))
                {
                    MessageBox.Show("Mina/Operador Minero creada satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mina/Operador Minero actualizado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message, "Error controlado del Sistema.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbEsquema_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void CmbEsquema_MouseEnter(object sender, EventArgs e)
        {
            this.ToolTip.SetToolTip(this.CmbEsquema, this.CmbEsquema.Text);
        }

        private void BtnNewLiquidacion_Click(object sender, EventArgs e)
        {
            #region Limpiando Page Contratos y Liquidacion
            this.CmbEsquema.SelectedIndex = -1;
            this.CmbContratista.SelectedIndex = -1;
            this.DtpContrato.Text = "";
            this.DtpInscriContrato.Text = "";
            this.DtpVenciContrato.Text = "";
            this.TxbRecuperacion.Text = "0.00";
            this.TxbFondo.Text = "0.00";
            this.NmrDuracion.Value = 0;
            this.ChbTenores.Checked = false;
            this.ChbAnexos.Checked = false;
            this.ChbClausulas.Checked = false;
            this.ChbFondo.Checked = false;
            this.TxbDetalleEsquema.Text = "";
            this.TxbPorcImpuestos.Text = "0.00";
            #endregion
        }

        private void BtnGuardarLiquidacion_Click(object sender, EventArgs e)
        {
            Ent_TblMinas TblMinas = new Ent_TblMinas();
            TblMinas = ConsultaTablas.TblMinas("TblMinasEspe", this.TxbCodigo.Text.Trim(), 0, 0.00);

            #region Insertando Datos
            if (string.IsNullOrEmpty(TblMinas.Codigo))
                MessageBox.Show("Mina/Proyecto No Existe");
            else
            {
                try
                {
                    SqlParameter[] ParametrosEnt = new SqlParameter[16];
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                    ParametrosEnt[1] = new SqlParameter("@IdMina", TblMinas.Id);
                    ParametrosEnt[2] = new SqlParameter("@CodigoEsquema", this.CmbEsquema.SelectedValue);
                    ParametrosEnt[3] = new SqlParameter("@IdContratista", this.CmbContratista.SelectedValue);
                    ParametrosEnt[4] = new SqlParameter("@Detalle", this.TxbDetalleEsquema.Text.Trim());
                    ParametrosEnt[5] = new SqlParameter("@Fecha", this.DtpContrato.Text.Trim().Replace("/", ""));
                    ParametrosEnt[6] = new SqlParameter("@Inscripcion", this.DtpInscriContrato.Text.Trim().Replace("/", ""));
                    ParametrosEnt[7] = new SqlParameter("@Vencimiento", this.DtpVenciContrato.Text.Trim().Replace("/", ""));
                    ParametrosEnt[8] = new SqlParameter("@Recuperacion", Convert.ToDouble(this.TxbRecuperacion.Text.ToString().Trim()));
                    ParametrosEnt[9] = new SqlParameter("@Fondo", Convert.ToDouble(this.TxbFondo.Text.ToString().Trim()));
                    ParametrosEnt[10] = new SqlParameter("@Duracion", this.NmrDuracion.Value);
                    ParametrosEnt[11] = new SqlParameter("@Tenores", this.ChbTenores.Checked);
                    ParametrosEnt[12] = new SqlParameter("@AnexoSeguridad", this.ChbAnexos.Checked);
                    ParametrosEnt[13] = new SqlParameter("@Explosivos", this.ChbClausulas.Checked);
                    ParametrosEnt[14] = new SqlParameter("@DevolucionFondo", this.ChbFondo.Checked);
                    ParametrosEnt[15] = new SqlParameter("@Impuestos", Convert.ToDouble(this.TxbPorcImpuestos.Text.ToString().Trim()));

                    GuardarDatos Guardar = new GuardarDatos();
                    Guardar.booleano("Sp_GuardarMinasContratos", ParametrosEnt);

                    MessageBox.Show("Datos almacenados satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region Actualizando el DatGridView Mantenimiento
                    try
                    {
                        DataSet DS;
                        DS = ConsultaTablas.Dataset("ContratosMinasEspe", this.TxbCodigo.Text.Trim(), 0, 0.00);
                        this.DgvContratos.DataSource = DS;
                        this.DgvContratos.DataMember = "Result";
                        this.DgvContratos.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("Error al consultar datos..: \n\n" + Exc.Message + " " + Exc.Source, "Informe del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                }

                catch (Exception E)
                {
                    MessageBox.Show("Error al Guardar los datos..: \n\n" + E.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            #endregion
        }

        private void DgvContratos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CmbEsquema.SelectedValue = Convert.ToString(this.DgvContratos.CurrentRow.Cells[3].Value).Trim();
            this.CmbContratista.SelectedValue = Convert.ToInt32(this.DgvContratos.CurrentRow.Cells[5].Value);
            this.TxbDetalleEsquema.Text = Convert.ToString(this.DgvContratos.CurrentRow.Cells[7].Value);
            this.DtpContrato.Value = Convert.ToDateTime(this.DgvContratos.CurrentRow.Cells[8].Value);
            this.DtpInscriContrato.Value = Convert.ToDateTime(this.DgvContratos.CurrentRow.Cells[9].Value);
            this.DtpVenciContrato.Value = Convert.ToDateTime(this.DgvContratos.CurrentRow.Cells[10].Value);
            this.TxbRecuperacion.Text = Convert.ToString(this.DgvContratos.CurrentRow.Cells[11].Value);
            this.TxbFondo.Text = Convert.ToString(this.DgvContratos.CurrentRow.Cells[12].Value);
            this.TxbPorcImpuestos.Text = Convert.ToString(this.DgvContratos.CurrentRow.Cells[13].Value);
            this.NmrDuracion.Text = Convert.ToString(this.DgvContratos.CurrentRow.Cells[14].Value);
            this.ChbTenores.Checked = Convert.ToBoolean(this.DgvContratos.CurrentRow.Cells[15].Value);
            this.ChbAnexos.Checked = Convert.ToBoolean(this.DgvContratos.CurrentRow.Cells[16].Value);
            this.ChbClausulas.Checked = Convert.ToBoolean(this.DgvContratos.CurrentRow.Cells[17].Value);
            this.ChbFondo.Checked = Convert.ToBoolean(this.DgvContratos.CurrentRow.Cells[18].Value);
        }

        private void Btn_NuevoAd_Click(object sender, EventArgs e)
        {
            this.TxbAdjuntosDetalle.Text = "";
            this.TxbAdjuntosPath.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog getArchivoAdjunto = new OpenFileDialog();
            getArchivoAdjunto.InitialDirectory = "C:\\";
            getArchivoAdjunto.RestoreDirectory = true;
            //getArchivoAdjunto.Filter = "Archivos adjuntos Excel(*.exe)| *.xls;| PDF(.pdf)|*.pdf;| Texto(*text)| *.txt;| Imagenes(*.jpg) (*.jpeg)| *.jpg; *.jpeg| PNG(*.png)| *.png| GIF(*.gif)| *.gif;| Todos*(*.exe)(*.pdf)(*.text)(*.jpg)(*.png)(*.gif)|*.xls;*.pdf;*.txt;*.jpg;*.png;*.gif";

            if (getArchivoAdjunto.ShowDialog() == DialogResult.OK)
            {
                TxbAdjuntosPath.Text = getArchivoAdjunto.FileName;
            }
            else
            {
                MessageBox.Show("No has seleccionado ningun archivo", "Seleccione una archivo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Btn_GuardarAd_Click(object sender, EventArgs e)
        {
            Ent_TblMinas TblMinas = new Ent_TblMinas();
            TblMinas = ConsultaTablas.TblMinas("TblMinasEspe", this.TxbCodigo.Text.Trim(), 0, 0.00);


            #region Insertando Datos Adjuntos
            if (this.TxbAdjuntosPath.Text.Length > 0)
            {
                try
                {
                    FileStream fs = new FileStream(this.TxbAdjuntosPath.Text, FileMode.Open);
                    //Creamos un array de bytes para almacenar los datos leídos por fs.
                    Byte[] data = new byte[fs.Length];
                    //Y guardamos los datos en el array data
                    fs.Read(data, 0, Convert.ToInt32(fs.Length));
                    fs.Close();

                    int PosInicialPath = this.TxbAdjuntosPath.Text.Trim().LastIndexOf("\\") + 1;
                    int PosFinalPath = this.TxbAdjuntosPath.Text.Trim().LastIndexOf(".") - 1;
                    int PosInicialExtension = this.TxbAdjuntosPath.Text.Trim().LastIndexOf(".");
                    int NumeroCaracteres = PosFinalPath - PosInicialPath + 1;
                    int CaracteresExtension = this.TxbAdjuntosPath.Text.Trim().Length - PosInicialExtension;

                    SqlParameter[] ParametrosEnt = new SqlParameter[11];
                    ParametrosEnt[0] = new SqlParameter("@Op", "I");
                    ParametrosEnt[1] = new SqlParameter("@Id", "0");
                    ParametrosEnt[2] = new SqlParameter("@IdMina", TblMinas.Id);
                    ParametrosEnt[3] = new SqlParameter("@Tipo", "1");
                    ParametrosEnt[4] = new SqlParameter("@Nombre", this.TxbAdjuntosPath.Text.Substring(PosInicialPath, NumeroCaracteres));
                    ParametrosEnt[5] = new SqlParameter("@Archivo", data);
                    ParametrosEnt[6] = new SqlParameter("@Extension", this.TxbAdjuntosPath.Text.Substring(PosInicialExtension, CaracteresExtension));
                    ParametrosEnt[7] = new SqlParameter("@Detalle", this.TxbAdjuntosDetalle.Text.Trim());
                    ParametrosEnt[8] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[9] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[10] = new SqlParameter("@Usuario", this.IdUsuario);

                    GuardarDatos Guardar = new GuardarDatos();
                    bool Realizado = Guardar.booleano("Sp_Guardar_DatosAdjuntosMinas", ParametrosEnt);
                    if (Realizado)
                        MessageBox.Show("Archivo Adjuntado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception Exc)
                {
                    MessageBox.Show("OCURRIÓ UN ERROR AL ADJUNTAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region Llenado el DataGrid de los adjuntos
            try
            {
                DataSet DS;
                DS = ConsultaTablas.Dataset("AdjuntosMinas", "", TblMinas.Id, 0.00);                       
                this.DtgAdjunto.DataSource = DS;
                this.DtgAdjunto.DataMember = "Result";
                this.DtgAdjunto.AutoResizeColumns();
            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void DtgAdjunto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Muestra o ejecuta los Datos adjuntos
            int IdFile = Convert.ToInt32(this.DtgAdjunto.CurrentRow.Cells[0].Value);
            try
            {
                Ent_DatosAdjuntos DatosAdjunots = new Ent_DatosAdjuntos();
                DatosAdjunots = ConsultaTablas.Adjuntos("AdjuntosByteMinas", "", IdFile, 0.00);


                string fichero = Convert.ToString(Path.GetTempPath()) + "Temp_" + DatosAdjunots.Archivo + DatosAdjunots.Extension;

                using (FileStream archivoStream = new FileStream(fichero, FileMode.Create))
                {
                    archivoStream.Write(DatosAdjunots.Archivo, 0, DatosAdjunots.Archivo.Length);
                    archivoStream.Close();
                    if (File.Exists(fichero))
                    {
                        Process process = new Process { StartInfo = { FileName = fichero } };
                        process.Start();
                    }
                }
            }
            catch (Exception aa)
            {
                MessageBox.Show(aa.Message); ;
            }
            #endregion
        }

        private void Btn_BorrarAd_Click(object sender, EventArgs e)
        {
            #region Eliminando los datos Adjuntos
            DialogResult Opcion = MessageBox.Show("Desea Eliminar el archivo adjunto Seleccionado oprima el botón SI", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    #region Determinando si se hace insert o update
                    SqlParameter[] ParamTipo = new SqlParameter[4];
                    ParamTipo[0] = new SqlParameter("@Op", "ExisteIdMina");
                    ParamTipo[1] = new SqlParameter("@ParametroChar", this.TxbCodigo.Text.Trim());
                    ParamTipo[2] = new SqlParameter("@ParametroInt", "0");
                    ParamTipo[3] = new SqlParameter("@ParametroNuemric", "0");
                    DataSet DaSet = LlenarGrid.Datos("SpConsulta_Tablas", ParamTipo);
                    int IdMina = Convert.ToInt32(DaSet.Tables[0].Rows[0]["Id"]);
                    #endregion

                    GuardarDatos GuardarDatos = new GuardarDatos();

                    int IdFile = Convert.ToInt32(this.DtgAdjunto.CurrentRow.Cells[0].Value);

                    SqlParameter[] ParametrosEnt = new SqlParameter[11];
                    ParametrosEnt[0] = new SqlParameter("@Op", "D");
                    ParametrosEnt[1] = new SqlParameter("@Id", IdFile);
                    ParametrosEnt[2] = new SqlParameter("@Tipo", "1");
                    ParametrosEnt[3] = new SqlParameter("@IdMina", IdMina);
                    ParametrosEnt[4] = new SqlParameter("@Nombre", "");
                    ParametrosEnt[5] = new SqlParameter("@Archivo", Encoding.ASCII.GetBytes(""));
                    ParametrosEnt[6] = new SqlParameter("@Extension", "");
                    ParametrosEnt[7] = new SqlParameter("@Detalle", "");
                    ParametrosEnt[8] = new SqlParameter("@Realizado", DateTime.Now);
                    ParametrosEnt[9] = new SqlParameter("@Maquina", Environment.MachineName);
                    ParametrosEnt[10] = new SqlParameter("@Usuario", this.IdUsuario);

                    GuardarDatos Guardar = new GuardarDatos();
                    bool Realizado = Guardar.booleano("Sp_Guardar_DatosAdjuntosMinas", ParametrosEnt);
                    if (Realizado)
                        MessageBox.Show("Archivo Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region Llenado el DataGrid de los adjuntos
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosMinasEspe");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbCodigo.Text.ToString().Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DtgAdjunto.DataSource = DS;
                        this.DtgAdjunto.DataMember = "Result";
                        this.DtgAdjunto.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion
                }
                catch (Exception Exc1)
                {
                    MessageBox.Show(Exc1.Message); ;
                }
            }

            #endregion
        }

        private void button51_Click(object sender, EventArgs e)
        {

            #region Eliminando los datos Adjuntos
            DialogResult Opcion = MessageBox.Show("Desea Eliminar el Contrato Seleccionado oprima el botón SI", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading);
            if (Opcion == DialogResult.Yes)
            {
                try
                {
                    int IdFile = Convert.ToInt32(this.DgvContratos.CurrentRow.Cells[0].Value);
                    SqlParameter[] ParametrosEnt = new SqlParameter[16];
                    ParametrosEnt[0] = new SqlParameter("@Op", "D");
                    ParametrosEnt[1] = new SqlParameter("@IdMina", IdFile);
                    ParametrosEnt[2] = new SqlParameter("@CodigoEsquema", this.CmbEsquema.SelectedIndex);
                    ParametrosEnt[3] = new SqlParameter("@IdContratista", this.CmbContratista.SelectedValue);
                    ParametrosEnt[4] = new SqlParameter("@Detalle", this.TxbDetalleEsquema.Text.Trim());
                    ParametrosEnt[5] = new SqlParameter("@Fecha", this.DtpContrato.Text.Trim().Replace("/", ""));
                    ParametrosEnt[6] = new SqlParameter("@Inscripcion", this.DtpInscriContrato.Text.Trim().Replace("/", ""));
                    ParametrosEnt[7] = new SqlParameter("@Vencimiento", this.DtpVenciContrato.Text.Trim().Replace("/", ""));
                    ParametrosEnt[8] = new SqlParameter("@Recuperacion", this.TxbRecuperacion.Text.ToString().Trim());
                    ParametrosEnt[9] = new SqlParameter("@Fondo", this.TxbFondo.Text.ToString().Trim());
                    ParametrosEnt[10] = new SqlParameter("@Duracion", this.NmrDuracion.Value);
                    ParametrosEnt[11] = new SqlParameter("@Tenores", this.ChbTenores.Checked);
                    ParametrosEnt[12] = new SqlParameter("@AnexoSeguridad", this.ChbAnexos.Checked);
                    ParametrosEnt[13] = new SqlParameter("@Explosivos", this.ChbClausulas.Checked);
                    ParametrosEnt[14] = new SqlParameter("@DevolucionFondo", this.ChbFondo.Checked);
                    ParametrosEnt[15] = new SqlParameter("@Impuestos", Convert.ToDouble(this.TxbPorcImpuestos.Text.ToString().Trim()));

                    GuardarDatos Guardar = new GuardarDatos();
                    bool Realizado = Guardar.booleano("Sp_GuardarMinasContratos", ParametrosEnt);
                    if (Realizado)
                        MessageBox.Show("Contrato Eliminado satisfactoriamente.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region Actualizando el DatGridView Contratos
                    try
                    {
                        SqlParameter[] ParametrosGrid = new SqlParameter[4];
                        ParametrosGrid[0] = new SqlParameter("@Op", "ContratosMinasEspe");
                        ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbCodigo.Text.Trim());
                        ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                        ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                        DataSet DS;

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                        this.DgvContratos.DataSource = DS;
                        this.DgvContratos.DataMember = "Result";
                        this.DgvContratos.AutoResizeColumns();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                }
                catch (Exception Exc1)
                {
                    MessageBox.Show(Exc1.Message); ;
                }
            }

            #endregion
            #region Llenado el DataGrid de los adjuntos
            try
            {
                SqlParameter[] ParametrosGrid = new SqlParameter[4];
                ParametrosGrid[0] = new SqlParameter("@Op", "AdjuntosMinasEspe");
                ParametrosGrid[1] = new SqlParameter("@ParametroChar", this.TxbCodigo.Text.ToString().Trim());
                ParametrosGrid[2] = new SqlParameter("@ParametroInt", "0");
                ParametrosGrid[3] = new SqlParameter("@ParametroNuemric", "0");
                DataSet DS;

                DS = LlenarGrid.Datos("SpConsulta_Tablas", ParametrosGrid);
                this.DtgAdjunto.DataSource = DS;
                this.DtgAdjunto.DataMember = "Result";
                this.DtgAdjunto.AutoResizeColumns();
            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(this.CmbEsquema.SelectedValue.ToString());
        }
    }
}

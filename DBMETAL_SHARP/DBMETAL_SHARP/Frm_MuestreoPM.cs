using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    public partial class Frm_MuestreoPM : Form
    {
        #region Constructor
        public Frm_MuestreoPM()
        {
            InitializeComponent();

        }

        public Frm_MuestreoPM(string User, bool Permisos)
        {
            InitializeComponent();
            this.Usuario = User.Trim();
            Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", User.ToString().Trim(), "Frm_MuestreoPM");
            this.Permisos = Permisos;
            this.Permission = Common.Common.Permissions;
            ValidatePermission(this.Controls);
        }
        #endregion  

        #region Propiedades
        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }
        public int Op { get; set; }
        public int type { get; set; }
        public string selloControlHistorico { get; set; }
        public bool Permisos { get; set; }
        public List<Roles_Permisos> Permission;

        #endregion

        #region Metodos 
        private void ValidatePermission(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    ValidatePermission(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    ShowToolStipItems(menuStrip.Items);
                }

                if (c is Button || c is ComboBox || c is TextBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage || c is TextBox)
                {

                    Roles_Permisos valueFilter = Permission.Where(e => e.fkcontrolid == c.Name).FirstOrDefault();

                    if (valueFilter != null)
                    {
                        if (valueFilter.Invisible > 0)
                        {
                            c.Visible = false;
                        }
                        else
                        {
                            c.Visible = true;
                        }

                        if (valueFilter.Disabled > 0)
                        {
                            c.Enabled = false;
                        }
                        else
                        {
                            c.Enabled = true;
                        }
                    }
                }
            }
        }

        private void ShowToolStipItems(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                mi.ToolTipText = mi.Name;

                if (mi.DropDownItems.Count > 0)
                {
                    ShowToolStipItems(mi.DropDownItems);
                }

                Roles_Permisos valueFilter = Permission.Where(e => e.fkcontrolid == mi.Name).FirstOrDefault();

                if (valueFilter != null)
                {
                    if (valueFilter.Invisible > 0)
                    {
                        mi.Visible = false;
                    }
                    else
                    {
                        mi.Visible = true;
                    }

                    if (valueFilter.Disabled > 0)
                    {
                        mi.Enabled = false;
                    }
                    else
                    {
                        mi.Enabled = true;
                    }
                }
            }
        }

        public void SetMyCustomFormat()
        {
            DtpFecha.Format = DateTimePickerFormat.Short;
            DtpFecha.CustomFormat = "MMMM dd, yyyy - dddd";
        }

        public void EjecutaPasarDato(string Dato)
        {
            int op = this.Op;
            if (op != 1)
            {
                if (op==22)
                {
                    switch (type)
                    {
                        case 1:
                            string[] value = Dato.Split('-');
                            this.TxbSeguridad.Enabled = false;
                            this.TxbSeguridad.Text = value[0];
                            this.TxbNombreSeguridad.Text = value[1];
                            break;

                        case 2:
                            value = Dato.Split('-');
                            this.TxbSeguridad.Enabled = false;
                            this.TxbSeguridad.Text = value[0];
                            TxbNombreSeguridad.Text = value[1];
                            break;

                        case 3:
                            value = Dato.Split('-');
                            this.TxbTercero.Enabled = false;
                            this.TxbTercero.Text = value[0];
                            TxbNombreTercero.Text = value[1];
                            break;

                        case 4:
                            value = Dato.Split('-');
                            this.TxbCuartea.Enabled = false;
                            this.TxbCuartea.Text = value[0];
                            TxbNombreCuartea.Text = value[1];
                            break;

                        default:
                            break;
                    }

                }
            }
            else
            {
                this.TxbPesaje.Text = Dato;
                this.TxbPesaje_Leave(null, null);
            }
        }

        private void Limpiar(int Op)
        {
            if (Op != 1)
            {
                if (Op != 2)
                {
                    return;
                }
                IEnumerator enumerator = base.Controls.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Control control = (Control)enumerator.Current;
                        if (control is GroupBox && (control.Name == "groupBox1" || control.Name == "groupBox2" || control.Name == "groupBox4"))
                        {
                            foreach (Control control2 in control.Controls)
                            {
                                if (control2 is TextBox)
                                {
                                    control2.Text = string.Empty;
                                }
                            }
                            foreach (Control control3 in control.Controls)
                            {
                                if (control is GroupBox && (control.Name == "groupBox1" || control.Name == "groupBox2"))
                                {
                                    if (control3 is MaskedTextBox)
                                    {
                                        control3.Text = string.Empty;
                                    }
                                    if (control3 is ComboBox)
                                    {
                                        if (((ComboBox)control3).Name != "CmbDestinoSello1" && ((ComboBox)control3).Name != "CmbDestinoSello2" && ((ComboBox)control3).Name != "CmbDestinoSello3" && ((ComboBox)control3).Name != "CmbDestinoSello4" && ((ComboBox)control3).Name != "CmbDestinoSello5" && ((ComboBox)control3).Name != "CmbDestinoSello6")
                                        {
                                            ((ComboBox)control3).SelectedIndex = 0;
                                            ((ComboBox)control3).Enabled = false;
                                        }
                                        else
                                        {
                                            ((ComboBox)control3).Text = string.Empty;
                                            ((ComboBox)control3).SelectedIndex = -1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
            foreach (Control control4 in base.Controls)
            {
                if (control4 is GroupBox)
                {
                    if (control4.Name == "groupBox1" && !this.ChbGuardarConfiguracion.Checked)
                    {
                        foreach (Control control5 in control4.Controls)
                        {
                            if (control5 is TextBox)
                            {
                                control5.Text = string.Empty;
                            }
                        }
                    }
                    foreach (Control control6 in control4.Controls)
                    {
                        if (control6.Name == "groupBox3")
                        {
                            foreach (Control control7 in control6.Controls)
                            {
                                if (control7 is TextBox)
                                {
                                    control7.Text = string.Empty;
                                }
                            }
                        }
                        if (control6.Name == "groupBox4")
                        {
                            foreach (Control control8 in control6.Controls)
                            {
                                if (control8 is TextBox)
                                {
                                    control8.Text = string.Empty;
                                }
                            }
                        }
                        if (control4.Name != "groupBox1" && control6 is TextBox)
                        {
                            control6.Text = string.Empty;
                        }
                        if (control6 is MaskedTextBox)
                        {
                            control6.Text = string.Empty;
                        }
                        if (control6 is ComboBox)
                        {
                            if (((ComboBox)control6).Name != "CmbDestinoSello1" && ((ComboBox)control6).Name != "CmbDestinoSello2" && ((ComboBox)control6).Name != "CmbDestinoSello3" && ((ComboBox)control6).Name != "CmbDestinoSello4" && ((ComboBox)control6).Name != "CmbDestinoSello5" && ((ComboBox)control6).Name != "CmbDestinoSello6")
                            {
                                ((ComboBox)control6).SelectedIndex = 0;
                                ((ComboBox)control6).Enabled = false;
                            }
                            else
                            {
                                ((ComboBox)control6).Text = string.Empty;
                                ((ComboBox)control6).SelectedIndex = -1;
                            }
                        }
                    }
                }
            }
            this.DtpFecha.Value = DateTime.Now;
        }

        #endregion

        #region Eventos

        private void btnNew_Click(object sender, EventArgs e)
        {
            Limpiar(1);
        }

        private void Frm_MuestreoPM_Load(object sender, EventArgs e)
        {
            btnNew.PerformClick();
        }

        private void DtpFecha_Leave(object sender, EventArgs e)
        {
            DtpFecha.Format = DateTimePickerFormat.Long;
            TxbPesaje.Focus();
        }

        private void DtpFecha_Enter(object sender, EventArgs e)
        {
            DtpFecha.Format = DateTimePickerFormat.Short;
        }

        private void DtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.TxbPesaje.Focus();
            }
        }

        private void TxbPesaje_Leave(object sender, EventArgs e)
        {
            try
            {
                if (TxbPesaje.Text.Trim() != "0" && !String.IsNullOrEmpty(TxbPesaje.Text.Trim()))
                {
                    List<Entidades.Ent_PesajeMineral> Reader = new List<Entidades.Ent_PesajeMineral>();

                    Reader = ConsultaEntidades.ObtenerPesoMinas("SpConsulta_Tablas", "ConsePlanta", "", Convert.ToInt64(this.TxbPesaje.Text), "0");
                    if (Reader != null && Reader.Count() > 0)
                    {
                        Entidades.Ent_PesajeMineral value = Reader[0];
                        List<Entidades.Ent_Usuario> user = ConsultaEntidades.ObtenerUsuarioPorRoles("GetUserForRoles", DBMETAL_SHARP.Common.Common.User[0].Name.ToString().Trim());
                        DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", DBMETAL_SHARP.Common.Common.User[0].Name.ToString().Trim(), this.Name);
                        Roles_Permisos permisoConsulta = DBMETAL_SHARP.Common.Common.Permissions.Where(s => s.fkcontrolid == "TxbPesaje").FirstOrDefault();

                        if (user != null && user.Count() > 0)
                        {
                            Entidades.Ent_Usuario User = user[0];

                            Limpiar(2);

                            switch (value.CodigoContenedor)
                            {
                                case "001":
                                    if (permisoConsulta.ContenedorPeqMineria > 0 || permisoConsulta.ContenedorOtros > 0)
                                    {
                                        List<Entidades.Ent_Muestreo> muestreos = ConsultaEntidades.ObtenerMuestreo("SpConsulta_Tablas", "RegistroMuestreo", Convert.ToInt32(this.TxbPesaje.Text), "0");

                                        if (muestreos != null && muestreos.Count() > 0)
                                        {
                                            Entidades.Ent_Muestreo muestreo = muestreos[0];
                                            TxbEncargado.Text = muestreo.IdEncargado.ToString();
                                            TxbNombreEncargado.Text = muestreo.NombreEncargado;
                                            TxbTercero.Text = muestreo.Idercero.ToString();
                                            TxbNombreTercero.Text = muestreo.NombreTercero;
                                            TxbSeguridad.Text = muestreo.IdSeguridad.ToString();
                                            TxbNombreSeguridad.Text = muestreo.NombreSeguridad;
                                            TxbCuartea.Text = muestreo.IdCuartea.ToString();
                                            TxbNombreCuartea.Text = muestreo.NombreCuartea;
                                            TxbCodigoControl.Text = muestreo.SelloControl;
                                            selloControlHistorico = muestreo.SelloControl;
                                            TxbSello1.Text = muestreo.Sello1;
                                            TxbPesoSello1.Text = muestreo.PesoSello1.ToString("N0", CultureInfo.InvariantCulture);
                                            if (TxbPesoSello1.Text.Trim().Equals("0,"))
                                            {
                                                TxbPesoSello1.Text = string.Empty;
                                            }

                                            CmbDestinoSello1.Text = muestreo.DestinoSello1;
                                            TxbDetalleSello1.Text = muestreo.DetalleSello1;

                                            TxbSello2.Text = muestreo.Sello2;
                                            TxbPesoSello2.Text = muestreo.PesoSello2.ToString("N0", CultureInfo.InvariantCulture);
                                            if (TxbPesoSello2.Text.Trim().Equals("0,"))
                                            {
                                                TxbPesoSello2.Text = string.Empty;
                                            }

                                            CmbDestinoSello2.Text = muestreo.DestinoSello2;
                                            TxbDetalleSello2.Text = muestreo.DetalleSello2;

                                            TxbSello3.Text = muestreo.Sello3;
                                            TxbPesoSello3.Text = muestreo.PesoSello3.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello3.Text = muestreo.DestinoSello3;
                                            TxbDetalleSello3.Text = muestreo.DetalleSello3;
                                            TxbSello4.Text = muestreo.Sello4;
                                            TxbPesoSello4.Text = muestreo.PesoSello4.ToString("N0", CultureInfo.InvariantCulture);
                                            if (TxbPesoSello4.Text.Trim().Equals("0,"))
                                            {
                                                TxbPesoSello4.Text = string.Empty;
                                            }

                                            CmbDestinoSello4.Text = muestreo.DestinoSello4;
                                            TxbDetalleSello4.Text = muestreo.DetalleSello4;
                                            TxbSello5.Text = muestreo.Sello5;
                                            TxbPesoSello5.Text = muestreo.PesoSello5.ToString("N0", CultureInfo.InvariantCulture);
                                            if (TxbPesoSello5.Text.Trim().Equals("0,"))
                                            {
                                                TxbPesoSello5.Text = string.Empty;
                                            }

                                            CmbDestinoSello5.Text = muestreo.DestinoSello5;
                                            TxbDetalleSello5.Text = muestreo.DetalleSello5;
                                            if (muestreos[0].Available)
                                            {
                                                btnGuardar.Enabled = false;
                                                //btnModificar.Enabled = false;
                                            }
                                            else
                                            {
                                                btnGuardar.Enabled = true;
                                                btnModificar.Enabled = true;
                                            }
                                        }
                                        else
                                        {
                                            btnGuardar.Enabled = true;
                                            btnModificar.Enabled = false;
                                        }
                                        DtpFecha.Value = value.FechaEstado1;

                                        if (value.FechaEstado1.Minute.ToString().Length > 1)
                                        {
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":", value.FechaEstado1.Minute.ToString());
                                        }
                                        else
                                        {
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":0", value.FechaEstado1.Minute.ToString());
                                        }

                                        if (value.FechaEstado0.Minute.ToString().Length > 1)
                                        {
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":", value.FechaEstado0.Minute.ToString());
                                        }
                                        else
                                        {
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":0", value.FechaEstado0.Minute.ToString());
                                        }

                                        txbHoraIngres.Enabled = false;
                                        txtHoraSalida.Enabled = false;

                                        TxbVehiculo.Text = value.PlacaVehiculo;
                                        TxbNombreVehiculo.Text = value.DescripcionVehiculo;

                                        TxbCodigoOperador.Text = value.CodigoConductor.ToString();
                                        TxbNombreOperador.Text = value.NombreConductor;

                                        TxbPesoVacio.Text = value.PesoEstado0.ToString("N0", CultureInfo.InvariantCulture);
                                        TxbPesoVacio.Text = TxbPesoVacio.Text.Substring(0, TxbPesoVacio.Text.Length - 1);

                                        TxbPesoLleno.Text = value.PesoEstado1.ToString("N0", CultureInfo.InvariantCulture);
                                        TxbPesoLleno.Text = TxbPesoLleno.Text.Substring(0, TxbPesoLleno.Text.Length - 1);

                                        TxbPesoTotal.Text = (value.PesoEstado1 - value.PesoEstado0).ToString("N0", CultureInfo.InvariantCulture);
                                        if (TxbPesoTotal.Text.Length != 0)
                                        {
                                            TxbPesoTotal.Text = TxbPesoTotal.Text.Substring(0, TxbPesoTotal.Text.Length - 1);
                                        }

                                        txbContenedor.Text = value.CodigoContenedor;
                                        txtCodProyect.Text = value.CodigoProyecto;
                                        txtDescProyect.Text = value.NombreProyecto;

                                    }
                                    else
                                    {
                                        TxbPesaje.Text = string.Empty;
                                        MessageBox.Show("El usuario no es válido para consultar este contenedor", "Mensaje");
                                    }

                                    break;

                                case "002":
                                    if (permisoConsulta.ContenedorZandor > 0)
                                    {
                                        List<Entidades.Ent_Muestreo> muestreos = ConsultaEntidades.ObtenerMuestreo("SpConsulta_Tablas", "RecuperarMueBasPM", Convert.ToInt32(this.TxbPesaje.Text), "0");
                                        if (muestreos != null && muestreos.Count() > 0)
                                        {
                                            Entidades.Ent_Muestreo muestreo = muestreos[0];
                                            TxbEncargado.Text = muestreo.IdEncargado.ToString();
                                            TxbNombreEncargado.Text = muestreo.NombreEncargado;
                                            TxbTercero.Text = muestreo.Idercero.ToString();
                                            TxbNombreTercero.Text = muestreo.NombreTercero;
                                            TxbSeguridad.Text = muestreo.IdSeguridad.ToString();
                                            TxbNombreSeguridad.Text = muestreo.NombreSeguridad;
                                            TxbCuartea.Text = muestreo.IdCuartea.ToString();
                                            TxbNombreCuartea.Text = muestreo.NombreCuartea;
                                            TxbCodigoControl.Text = muestreo.SelloControl;
                                            selloControlHistorico = muestreo.SelloControl;

                                            TxbSello1.Text = muestreo.Sello1;
                                            TxbPesoSello1.Text = muestreo.PesoSello1.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello1.Text = muestreo.DestinoSello1;
                                            TxbDetalleSello1.Text = muestreo.DetalleSello1;
                                            TxbSello2.Text = muestreo.Sello2;
                                            TxbPesoSello2.Text = muestreo.PesoSello2.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello2.Text = muestreo.DestinoSello2;
                                            TxbDetalleSello2.Text = muestreo.DetalleSello2;
                                            TxbSello3.Text = muestreo.Sello3;
                                            TxbPesoSello3.Text = muestreo.PesoSello3.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello3.Text = muestreo.DestinoSello3;
                                            TxbDetalleSello3.Text = muestreo.DetalleSello3;
                                            TxbSello4.Text = muestreo.Sello4;
                                            TxbPesoSello4.Text = muestreo.PesoSello4.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello4.Text = muestreo.DestinoSello4;
                                            TxbDetalleSello4.Text = muestreo.DetalleSello4;

                                            TxbSello5.Text = muestreo.Sello5;
                                            TxbPesoSello5.Text = muestreo.PesoSello5.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello5.Text = muestreo.DestinoSello5;
                                            TxbDetalleSello5.Text = muestreo.DetalleSello5;

                                            if (muestreos[0].Available)
                                            {
                                                btnGuardar.Enabled = false;
                                                //btnModificar.Enabled = false;
                                            }
                                            else
                                            {
                                                btnGuardar.Enabled = true;
                                                btnModificar.Enabled = true;
                                            }
                                        }
                                        else
                                        {
                                            btnGuardar.Enabled = true;
                                            btnModificar.Enabled = false;
                                        }

                                        DtpFecha.Value = value.FechaEstado1;

                                        if (value.FechaEstado1.Minute.ToString().Length > 1)
                                        {
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":", value.FechaEstado1.Minute.ToString());
                                        }
                                        else
                                        {
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":0", value.FechaEstado1.Minute.ToString());
                                        }

                                        if (value.FechaEstado0.Minute.ToString().Length > 1)
                                        {
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":", value.FechaEstado0.Minute.ToString());
                                        }
                                        else
                                        {
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":0", value.FechaEstado0.Minute.ToString());
                                        }

                                        txbHoraIngres.Enabled = false;
                                        txtHoraSalida.Enabled = false;
                                        TxbVehiculo.Text = value.PlacaVehiculo;
                                        TxbNombreVehiculo.Text = value.DescripcionVehiculo;

                                        TxbCodigoOperador.Text = value.CodigoConductor.ToString();
                                        TxbNombreOperador.Text = value.NombreConductor;

                                        TxbPesoVacio.Text = value.PesoEstado0.ToString("N0", CultureInfo.InvariantCulture);

                                        TxbPesoVacio.Text = TxbPesoVacio.Text.Substring(0, TxbPesoVacio.Text.Length - 1);

                                        TxbPesoLleno.Text = value.PesoEstado1.ToString("N0", CultureInfo.InvariantCulture);
                                        TxbPesoLleno.Text = TxbPesoLleno.Text.Substring(0, TxbPesoLleno.Text.Length - 1);

                                        TxbPesoTotal.Text = (value.PesoEstado1 - value.PesoEstado0).ToString("N0", CultureInfo.InvariantCulture);
                                        if (TxbPesoTotal.Text.Length != 1)
                                        {
                                            TxbPesoTotal.Text = TxbPesoTotal.Text.Substring(0, TxbPesoTotal.Text.Length - 1);
                                        }

                                        txbContenedor.Text = value.CodigoContenedor;


                                        txtCodProyect.Text = value.CodigoProyecto;
                                        txtDescProyect.Text = value.NombreProyecto;
                                        txtNombreContendor.Text = value.NombreContenedor;
                                    }
                                    else
                                    {
                                        TxbPesaje.Text = string.Empty;
                                        MessageBox.Show("El usuario no es válido para consultar este contenedor", "Mensaje");
                                    }
                                    break;

                                case "003":
                                    if (permisoConsulta.ContenedorPeqMineria > 0 || permisoConsulta.ContenedorOtros > 0)
                                    {
                                        List<Entidades.Ent_Muestreo> muestreos = ConsultaEntidades.ObtenerMuestreo("SpConsulta_Tablas", "RegistroMuestreo", Convert.ToInt32(this.TxbPesaje.Text), "0");
                                        if (muestreos != null && muestreos.Count() > 0)
                                        {
                                            Entidades.Ent_Muestreo muestreo = muestreos[0];
                                            TxbEncargado.Text = muestreo.IdEncargado.ToString();
                                            TxbNombreEncargado.Text = muestreo.NombreEncargado;
                                            TxbTercero.Text = muestreo.Idercero.ToString();
                                            TxbNombreTercero.Text = muestreo.NombreTercero;
                                            TxbSeguridad.Text = muestreo.IdSeguridad.ToString();
                                            TxbNombreSeguridad.Text = muestreo.NombreSeguridad;
                                            TxbCuartea.Text = muestreo.IdCuartea.ToString();
                                            TxbNombreCuartea.Text = muestreo.NombreCuartea;
                                            TxbCodigoControl.Text = muestreo.SelloControl;
                                            selloControlHistorico = muestreo.SelloControl;


                                            TxbSello1.Text = muestreo.Sello1;
                                            TxbPesoSello1.Text = muestreo.PesoSello1.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello1.Text = muestreo.DestinoSello1;
                                            TxbDetalleSello1.Text = muestreo.DetalleSello1;

                                            TxbSello2.Text = muestreo.Sello2;
                                            TxbPesoSello2.Text = muestreo.PesoSello2.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello2.Text = muestreo.DestinoSello2;
                                            TxbDetalleSello2.Text = muestreo.DetalleSello2;

                                            TxbSello3.Text = muestreo.Sello3;
                                            TxbPesoSello3.Text = muestreo.PesoSello3.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello3.Text = muestreo.DestinoSello3;
                                            TxbDetalleSello3.Text = muestreo.DetalleSello3;

                                            TxbSello4.Text = muestreo.Sello4;
                                            TxbPesoSello4.Text = muestreo.PesoSello4.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello4.Text = muestreo.DestinoSello4;
                                            TxbDetalleSello4.Text = muestreo.DetalleSello4;

                                            TxbSello5.Text = muestreo.Sello5;
                                            TxbPesoSello5.Text = muestreo.PesoSello5.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello5.Text = muestreo.DestinoSello5;
                                            TxbDetalleSello5.Text = muestreo.DetalleSello5;
                                            if (muestreos[0].Available)
                                            {
                                                btnGuardar.Enabled = false;
                                                //btnModificar.Enabled = false;
                                            }
                                            else
                                            {
                                                btnGuardar.Enabled = true;
                                                btnModificar.Enabled = true;
                                            }
                                        }
                                        else
                                        {
                                            btnGuardar.Enabled = true;
                                            btnModificar.Enabled = false;
                                        }

                                        DtpFecha.Value = value.FechaEstado1;

                                        if (value.FechaEstado1.Minute.ToString().Length > 1)
                                        {
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":", value.FechaEstado1.Minute.ToString());
                                        }
                                        else
                                        {
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":0", value.FechaEstado1.Minute.ToString());
                                        }

                                        if (value.FechaEstado0.Minute.ToString().Length > 1)
                                        {
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":", value.FechaEstado0.Minute.ToString());
                                        }
                                        else
                                        {
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":0", value.FechaEstado0.Minute.ToString());
                                        }

                                        txbHoraIngres.Enabled = false;
                                        txtHoraSalida.Enabled = false;

                                        TxbVehiculo.Text = value.PlacaVehiculo;
                                        TxbNombreVehiculo.Text = value.DescripcionVehiculo;

                                        TxbCodigoOperador.Text = value.CodigoConductor.ToString();
                                        TxbNombreOperador.Text = value.NombreConductor;

                                        TxbPesoVacio.Text = value.PesoEstado0.ToString("N0", CultureInfo.InvariantCulture);

                                        TxbPesoVacio.Text = TxbPesoVacio.Text.Substring(0, TxbPesoVacio.Text.Length - 1);

                                        TxbPesoLleno.Text = value.PesoEstado1.ToString("N0", CultureInfo.InvariantCulture);
                                        TxbPesoLleno.Text = TxbPesoLleno.Text.Substring(0, TxbPesoLleno.Text.Length - 1);

                                        TxbPesoTotal.Text = (value.PesoEstado1 - value.PesoEstado0).ToString("N0", CultureInfo.InvariantCulture);
                                        if (TxbPesoTotal.Text.Length != 1)
                                        {
                                            TxbPesoTotal.Text = TxbPesoTotal.Text.Substring(0, TxbPesoTotal.Text.Length - 1);
                                        }

                                        txbContenedor.Text = value.CodigoContenedor;


                                        txtCodProyect.Text = value.CodigoProyecto;
                                        txtDescProyect.Text = value.NombreProyecto;
                                    }
                                    else
                                    {
                                        TxbPesaje.Text = string.Empty;
                                        MessageBox.Show("El usuario no es válido para consultar este contenedor", "Mensaje");
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void BtnBuscarPesaje_Click(object sender, EventArgs e)
        {
            Op = 1;
            Frm_Consultas Forma = new Frm_Consultas(0);
            Forma.Tipo = 1;
            type = Forma.Tipo;
            DateTime thisDate1 = new DateTime(DtpFecha.Value.Year, DtpFecha.Value.Month, DtpFecha.Value.Day);
            Forma.Fecha = new DateTime(DtpFecha.Value.Year, DtpFecha.Value.Month, DtpFecha.Value.Day);
            Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", DBMETAL_SHARP.Common.Common.User[0].Name.ToString().Trim(), this.Name);
            DtpFecha.Format = DateTimePickerFormat.Short;
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

        private void BtnBuscarEncargado_Click(object sender, EventArgs e)
        {
            Op = 22;
            Frm_Consultas Forma = new Frm_Consultas(Op);
            Forma.Tipo = 2;
            Forma.TipoFiltro = 1;
            type = Forma.TipoFiltro;
            Forma.Fecha = DtpFecha.Value;
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void BtnBuscarTercero_Click(object sender, EventArgs e)
        {
            Op = 22;
            Frm_Consultas Forma = new Frm_Consultas(Op);
            Forma.Tipo = 2;
            Forma.TipoFiltro = 3;
            type = Forma.TipoFiltro;
            Forma.Fecha = DtpFecha.Value;
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void BtnBuscarSeguridad_Click(object sender, EventArgs e)
        {
            Op = 22;
            Frm_Consultas Forma = new Frm_Consultas(Op);
            Forma.Tipo = 2;
            Forma.TipoFiltro = 2;
            type = Forma.TipoFiltro;
            Forma.Fecha = DtpFecha.Value;
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void BtnBuscarCuartea_Click(object sender, EventArgs e)
        {
            Op = 22;
            Frm_Consultas Forma = new Frm_Consultas(Op);
            Forma.Tipo = 2;
            Forma.TipoFiltro = 4;
            type = Forma.TipoFiltro;
            Forma.Fecha = DtpFecha.Value;
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void TxbConsecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbCodigoControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxbSello1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbSello2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbSello3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbSello4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbSello6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbSello5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxbPesoSello1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxbPesoSello4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbPesoSello3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void TxbPesoSello2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxbPesoSello5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void TxbPesoSello6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (this.Permisos)
            {

                if (String.IsNullOrEmpty(TxbPesaje.Text.Trim()))
                {
                    value = string.Concat(value, "El campo pesaje es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbEncargado.Text.Trim()))
                {
                    value = string.Concat(value, "El campo encargado turno es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbSeguridad.Text.Trim()))
                {
                    value = string.Concat(value, "El campo seguridad zandor es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbCodigoControl.Text.Trim()))
                {
                    value = string.Concat(value, "El campo código control es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo sello 1 es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbPesoSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo peso de sello 1 es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(CmbDestinoSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo destino es requerido", Environment.NewLine);
                }
            }

            if (!String.IsNullOrEmpty(value))
            {
                MessageBox.Show(value, "Validaciones");
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(this.IpLocal))
                    {
                        this.IpLocal = DireccionIP.Local();
                    }

                    if (string.IsNullOrEmpty(this.IpPublica))
                    {
                        this.IpPublica = DireccionIP.Publica();
                    }

                    if (string.IsNullOrEmpty(this.SerialHDD))
                    {
                        this.SerialHDD = DireccionIP.SerialNumberDisk();
                    }

                    if (string.IsNullOrEmpty(this.Usuario))
                    {
                        this.Usuario = DireccionIP.SerialNumberDisk();
                    }

                    GuardarDatos Guardar = new GuardarDatos();
                    var culturaCol = CultureInfo.GetCultureInfo("es-CO");
                    DateTime Reportado = Convert.ToDateTime(DtpFecha.Value.ToString("dd/MM/yyyy"), culturaCol);
                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_MuestreoPM(false, "", 1, TxbPesaje.Text.Trim(), Reportado, string.IsNullOrEmpty(TxbEncargado.Text.Trim()) ? 0 : Convert.ToInt32(TxbEncargado.Text.Trim()), string.IsNullOrEmpty(TxbTercero.Text.Trim()) ? 0 : Convert.ToInt32(TxbTercero.Text.Trim()), string.IsNullOrEmpty(TxbSeguridad.Text.Trim()) ? 0 : Convert.ToInt32(TxbSeguridad.Text.Trim()), string.IsNullOrEmpty(TxbCuartea.Text.Trim()) ? 0 : Convert.ToInt32(TxbCuartea.Text.Trim()), TxbCodigoControl.Text.Trim(), TxbSello1.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello1.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello1.Text.Trim()), CmbDestinoSello1.Text.Trim(), Convert.ToInt32(CmbTipoSello1.SelectedIndex), Convert.ToInt32(CmbAnalisisSello1.SelectedIndex), TxbDetalleSello1.Text.Trim(), TxbSello2.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello2.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello2.Text.Trim()), CmbDestinoSello2.Text.Trim(), Convert.ToInt32(CmbTipoSello2.SelectedIndex), Convert.ToInt32(CmbAnalisisSello2.SelectedIndex), TxbDetalleSello2.Text.Trim(), TxbSello3.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello3.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello3.Text.Trim()), CmbDestinoSello3.Text.Trim(), Convert.ToInt32(CmbTipoSello3.SelectedIndex), Convert.ToInt32(CmbAnalisisSello3.SelectedIndex), TxbDetalleSello3.Text.Trim(), TxbSello4.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello4.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello4.Text.Trim().TrimEnd(',')), CmbDestinoSello4.Text.Trim(), Convert.ToInt32(CmbTipoSello4.SelectedIndex), Convert.ToInt32(CmbAnalisisSello4.SelectedIndex), TxbDetalleSello4.Text.Trim(), TxbSello5.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello5.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello5.Text.Trim()), CmbDestinoSello5.Text.Trim(), Convert.ToInt32(CmbTipoSello5.SelectedIndex), Convert.ToInt32(CmbAnalisisSello5.SelectedIndex), TxbDetalleSello5.Text.Trim(), string.Empty, string.IsNullOrEmpty(string.Empty) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(0), string.Empty, Convert.ToInt32(0), Convert.ToInt32(0), string.Empty, 1, 1, 1, txbContenedor.Text, txtCodProyect.Text, Convert.ToDecimal(TxbPesoTotal.Text), false, txtDescProyect.Text.Trim());
                    
                    if (ParamSQl[0].Value.ToString() == "I")
                    {
                        Guardar.Numerico("Sp_Guardar_MuestreoPM", ParamSQl).ToString();
                    }


                    if (ParamSQl[0].Value.ToString() == "I")
                    {
                        MessageBox.Show("Muestreo almacenado con Exito");
                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo Registro de Muestreo " + TxbPesaje.Text.Trim(), "Movimiento Muestreo creado");
                        Limpiar(1);
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void TxbPesaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (char.IsSeparator(e.KeyChar))
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_ControlCalidadMuestras muestreoPM = new Frm_ControlCalidadMuestras(this.Usuario);
            muestreoPM.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (this.Permisos)
            {

                if (String.IsNullOrEmpty(TxbPesaje.Text.Trim()))
                {
                    value = string.Concat(value, "El campo pesaje es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbEncargado.Text.Trim()))
                {
                    value = string.Concat(value, "El campo encargado turno es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbSeguridad.Text.Trim()))
                {
                    value = string.Concat(value, "El campo seguridad zandor es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbCodigoControl.Text.Trim()))
                {
                    value = string.Concat(value, "El campo código control es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo sello 1 es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbPesoSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo peso de sello 1 es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(CmbDestinoSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo destino es requerido", Environment.NewLine);
                }
            }

            if (!String.IsNullOrEmpty(value))
            {
                MessageBox.Show(value, "Validaciones");
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(this.IpLocal))
                    {
                        this.IpLocal = DireccionIP.Local();
                    }

                    if (string.IsNullOrEmpty(this.IpPublica))
                    {
                        this.IpPublica = DireccionIP.Publica();
                    }

                    if (string.IsNullOrEmpty(this.SerialHDD))
                    {
                        this.SerialHDD = DireccionIP.SerialNumberDisk();
                    }

                    if (string.IsNullOrEmpty(this.Usuario))
                    {
                        this.Usuario = DireccionIP.SerialNumberDisk();
                    }

                    GuardarDatos Guardar = new GuardarDatos();
                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_MuestreoPM(true, "", 1, TxbPesaje.Text.Trim(), DtpFecha.Value, string.IsNullOrEmpty(TxbEncargado.Text.Trim()) ? 0 : Convert.ToInt32(TxbEncargado.Text.Trim()), string.IsNullOrEmpty(TxbTercero.Text.Trim()) ? 0 : Convert.ToInt32(TxbTercero.Text.Trim()), string.IsNullOrEmpty(TxbSeguridad.Text.Trim()) ? 0 : Convert.ToInt32(TxbSeguridad.Text.Trim()), string.IsNullOrEmpty(TxbCuartea.Text.Trim()) ? 0 : Convert.ToInt32(TxbCuartea.Text.Trim()), TxbCodigoControl.Text.Trim(), TxbSello1.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello1.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello1.Text.Trim()), CmbDestinoSello1.Text.Trim(), Convert.ToInt32(CmbTipoSello1.SelectedIndex), Convert.ToInt32(CmbAnalisisSello1.SelectedIndex), TxbDetalleSello1.Text.Trim(), TxbSello2.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello2.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello2.Text.Trim()), CmbDestinoSello2.Text.Trim(), Convert.ToInt32(CmbTipoSello2.SelectedIndex), Convert.ToInt32(CmbAnalisisSello2.SelectedIndex), TxbDetalleSello2.Text.Trim(), TxbSello3.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello3.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello3.Text.Trim()), CmbDestinoSello3.Text.Trim(), Convert.ToInt32(CmbTipoSello3.SelectedIndex), Convert.ToInt32(CmbAnalisisSello3.SelectedIndex), TxbDetalleSello3.Text.Trim(), TxbSello4.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello4.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello4.Text.Trim().TrimEnd(',')), CmbDestinoSello4.Text.Trim(), Convert.ToInt32(CmbTipoSello4.SelectedIndex), Convert.ToInt32(CmbAnalisisSello4.SelectedIndex), TxbDetalleSello4.Text.Trim(), TxbSello5.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello5.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello5.Text.Trim()), CmbDestinoSello5.Text.Trim(), Convert.ToInt32(CmbTipoSello5.SelectedIndex), Convert.ToInt32(CmbAnalisisSello5.SelectedIndex), TxbDetalleSello5.Text.Trim(), string.Empty, string.IsNullOrEmpty(string.Empty) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(0), string.Empty, Convert.ToInt32(0), Convert.ToInt32(0), string.Empty, 1, 1, 1, txbContenedor.Text, txtCodProyect.Text, Convert.ToDecimal(TxbPesoTotal.Text), false, txtDescProyect.Text.Trim());
                    if (ParamSQl[0].Value.ToString() == "I")
                    {
                        Guardar.Numerico("Sp_Guardar_MuestreoPM", ParamSQl).ToString();
                    }
                    else
                    {
                        Guardar.booleano("Sp_Moficiar_MuestreoPM", ParamSQl);
                    }

                    if (ParamSQl[0].Value.ToString() == "I")
                    {
                        MessageBox.Show("Muestreo rechequeado con Exito");
                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se creo rechequeo de Muestreo " + TxbPesaje.Text.Trim(), "Movimiento Muestreo creado");
                        Limpiar(1);
                    }
                    else
                    {
                        MessageBox.Show("Personal de Muestreo actualizado con Exito");
                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se modifico rechequeo de Muestreo " + TxbPesaje.Text.Trim(), "Movimiento Muestreo  Modificar");
                    }
                    Limpiar(1);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (this.Permisos)
            {

                if (String.IsNullOrEmpty(TxbPesaje.Text.Trim()))
                {
                    value = string.Concat(value, "El campo pesaje es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbEncargado.Text.Trim()))
                {
                    value = string.Concat(value, "El campo encargado turno es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbSeguridad.Text.Trim()))
                {
                    value = string.Concat(value, "El campo seguridad zandor es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbCodigoControl.Text.Trim()))
                {
                    value = string.Concat(value, "El campo código control es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo sello 1 es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(TxbPesoSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo peso de sello 1 es requerido", Environment.NewLine);
                }

                if (String.IsNullOrEmpty(CmbDestinoSello1.Text.Trim()))
                {
                    value = string.Concat(value, "El campo destino es requerido", Environment.NewLine);
                }
            }

            if (!String.IsNullOrEmpty(value))
            {
                MessageBox.Show(value, "Validaciones");
            }
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(this.IpLocal))
                    {
                        this.IpLocal = DireccionIP.Local();
                    }

                    if (string.IsNullOrEmpty(this.IpPublica))
                    {
                        this.IpPublica = DireccionIP.Publica();
                    }

                    if (string.IsNullOrEmpty(this.SerialHDD))
                    {
                        this.SerialHDD = DireccionIP.SerialNumberDisk();
                    }

                    if (string.IsNullOrEmpty(this.Usuario))
                    {
                        this.Usuario = DireccionIP.SerialNumberDisk();
                    }

                    var culturaCol = CultureInfo.GetCultureInfo("es-CO");


                    DateTime Reportado = Convert.ToDateTime(DtpFecha.Value.ToString("dd/MM/yyyy"), culturaCol);

                    GuardarDatos Guardar = new GuardarDatos();

                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_MuestreoPM(false, "", 1, TxbPesaje.Text.Trim(), Reportado, string.IsNullOrEmpty(TxbEncargado.Text.Trim()) ? 0 : Convert.ToInt32(TxbEncargado.Text.Trim()), string.IsNullOrEmpty(TxbTercero.Text.Trim()) ? 0 : Convert.ToInt32(TxbTercero.Text.Trim()), string.IsNullOrEmpty(TxbSeguridad.Text.Trim()) ? 0 : Convert.ToInt32(TxbSeguridad.Text.Trim()), string.IsNullOrEmpty(TxbCuartea.Text.Trim()) ? 0 : Convert.ToInt32(TxbCuartea.Text.Trim()), TxbCodigoControl.Text.Trim(), TxbSello1.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello1.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello1.Text.Trim()), CmbDestinoSello1.Text.Trim(), Convert.ToInt32(CmbTipoSello1.SelectedIndex), Convert.ToInt32(CmbAnalisisSello1.SelectedIndex), TxbDetalleSello1.Text.Trim(), TxbSello2.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello2.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello2.Text.Trim()), CmbDestinoSello2.Text.Trim(), Convert.ToInt32(CmbTipoSello2.SelectedIndex), Convert.ToInt32(CmbAnalisisSello2.SelectedIndex), TxbDetalleSello2.Text.Trim(), TxbSello3.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello3.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello3.Text.Trim()), CmbDestinoSello3.Text.Trim(), Convert.ToInt32(CmbTipoSello3.SelectedIndex), Convert.ToInt32(CmbAnalisisSello3.SelectedIndex), TxbDetalleSello3.Text.Trim(), TxbSello4.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello4.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello4.Text.Trim().TrimEnd(',')), CmbDestinoSello4.Text.Trim(), Convert.ToInt32(CmbTipoSello4.SelectedIndex), Convert.ToInt32(CmbAnalisisSello4.SelectedIndex), TxbDetalleSello4.Text.Trim(), TxbSello5.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello5.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello5.Text.Trim()), CmbDestinoSello5.Text.Trim(), Convert.ToInt32(CmbTipoSello5.SelectedIndex), Convert.ToInt32(CmbAnalisisSello5.SelectedIndex), TxbDetalleSello5.Text.Trim(), string.Empty, string.IsNullOrEmpty(string.Empty) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(0), string.Empty, Convert.ToInt32(0), Convert.ToInt32(0), string.Empty, 1, 1, 1, txbContenedor.Text, txtCodProyect.Text, Convert.ToDecimal(TxbPesoTotal.Text), false, txtDescProyect.Text.Trim());
                    if (!Guardar.booleano("Sp_Moficiar_MuestreoPM", ParamSQl))
                    {
                        MessageBox.Show("Registro actualizado con Exito");

                        if (!String.IsNullOrEmpty(selloControlHistorico) && !TxbCodigoControl.Text.Trim().Equals(selloControlHistorico.Trim()))
                        {
                            List<Entidades.Ent_CalidadMuestro> Reader = new List<Entidades.Ent_CalidadMuestro>();

                            Reader = ConsultaEntidades.ObtenerMuestroDia("SpConsulta_Tablas", "LLenarTreePM", TxbPesaje.Text.Trim(), 0, "0");
                            if (Reader != null && Reader.Count() > 0)
                            {
                                foreach (var item in Reader)
                                {
                                    int sello = 0;
                                    string selloDes = string.Empty;

                                    if (!Int32.TryParse(item.SelloControl.Trim(), out sello))
                                    {
                                        selloDes = string.Concat(TxbCodigoControl.Text.Trim(), Convert.ToString(item.SelloControl[item.SelloControl.Trim().Length - 1]));
                                    }
                                    else
                                    {
                                        selloDes = TxbCodigoControl.Text;
                                    }

                                    SqlParameter[] ParamSQlSello =
    GuardarDatos.Parameter_UpdateSelloControls(Convert.ToInt32(TxbPesaje.Text.Trim()),
    selloDes.Trim(),
    item.SelloControl.Trim(),
    TxbCodigoControl.Text.Trim());
                                    if (Guardar.booleano("Sp_Moficiar_SelloDetalle", ParamSQlSello))
                                    {
                                    }
                                }
                            }
                        }

                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Se modifico Personal de Muestreo " + TxbPesaje.Text.Trim(), "Movimiento Muestreo  Modificar");
                        Limpiar(1);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        #endregion

        private void CmbDestinoSello1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbDestinoSello1.Text != "Operador")
            {
                MessageBox.Show("Destino seleccionado incorrectamente, para el destino solo puede seleccionar el tipo Operador.", "Db_Metal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.CmbDestinoSello1.Focus();
            }
        }

        private void CmbDestinoSello2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbDestinoSello2.Text != "Laboratorio")
            {
                MessageBox.Show("Destino seleccionado incorrectamente, para el destino solo puede seleccionar el tipo Laboratorio.", "Db_Metal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.CmbDestinoSello2.Focus();
            }
        }

        private void CmbDestinoSello3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbDestinoSello3.Text != "Arbitral")
            {
                MessageBox.Show("Destino seleccionado incorrectamente, para el destino solo puede seleccionar el tipo Arbitral.", "Db_Metal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.CmbDestinoSello3.Focus();
            }
        }
    }
}

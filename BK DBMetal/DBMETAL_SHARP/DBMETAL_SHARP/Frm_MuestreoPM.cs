using DBMETAL_SHARP.Common;
using DBMETAL_SHARP.Liquidacion;
using Entidades;
using ReglasdeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", User.ToString().Trim(), "Frm_MuestreoPM");

            this.Permisos = Permisos;
            this.Permission = DBMETAL_SHARP.Common.Common.Permissions;

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
                            c.Visible = false;
                        else
                            c.Visible = true;

                        if (valueFilter.Disabled > 0)
                            c.Enabled = false;
                        else
                            c.Enabled = true;
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
                        mi.Visible = false;
                    else
                        mi.Visible = true;

                    if (valueFilter.Disabled > 0)
                        mi.Enabled = false;
                    else
                        mi.Enabled = true;
                }
            }
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            DtpFecha.Format = DateTimePickerFormat.Short;
            //DtpFecha.CustomFormat = "dd-MM-yyyy";
            DtpFecha.CustomFormat = "MMMM dd, yyyy - dddd";
        }

        public void EjecutaPasarDato(string Dato)
        {
            switch (Op)
            {
                case 1:
                    this.TxbPesaje.Text = Dato;
                    TxbPesaje_Leave(null, null);
                    break;
                //Implementaciòn David Ciro
                case 22:

                    switch (type)
                    {
                        case 1:
                            string[] value = Dato.Split('-');
                            this.TxbEncargado.Enabled = false;
                            this.TxbEncargado.Text = value[0];
                            TxbNombreEncargado.Text = value[1];
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

                        case 2:
                            value = Dato.Split('-');
                            this.TxbSeguridad.Enabled = false;
                            this.TxbSeguridad.Text = value[0];
                            TxbNombreSeguridad.Text = value[1];
                            break;

                        default:
                            break;
                    }
                    break;
            }
        }

        private void Limpiar(int Op)
        {
            switch (Op)
            {
                case 1:

                    foreach (Control control in this.Controls)
                    {
                        if (control is System.Windows.Forms.GroupBox)
                        {

                            if (control.Name == "groupBox1" && !ChbGuardarConfiguracion.Checked)
                            {
                                foreach (Control item1 in control.Controls)
                                {
                                    if (item1 is System.Windows.Forms.TextBox)
                                        item1.Text = string.Empty;
                                }
                            }

                            foreach (Control item in control.Controls)
                            {
                                if (item.Name == "groupBox3")
                                {
                                    foreach (Control item1 in item.Controls)
                                    {
                                        if (item1 is System.Windows.Forms.TextBox)
                                            item1.Text = string.Empty;
                                    }
                                }
                                if (item.Name == "groupBox4")
                                {
                                    foreach (Control item1 in item.Controls)
                                    {
                                        if (item1 is System.Windows.Forms.TextBox)
                                            item1.Text = string.Empty;
                                    }
                                }
                                if (control.Name != "groupBox1")
                                {
                                    if (item is System.Windows.Forms.TextBox)
                                        item.Text = string.Empty;
                                }
                                if (item is System.Windows.Forms.MaskedTextBox)
                                {
                                    item.Text = string.Empty;
                                }
                                if (item is System.Windows.Forms.ComboBox)
                                {
                                    if (((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello1"
                                        && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello2"
                                        && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello3"

                                       && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello4"
                                        && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello5"
                                        && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello6")
                                    {
                                        ((System.Windows.Forms.ComboBox)item).SelectedIndex = 0;
                                        ((System.Windows.Forms.ComboBox)item).Enabled = false;
                                    }
                                    else
                                    {
                                        ((System.Windows.Forms.ComboBox)item).Text = string.Empty;

                                        ((System.Windows.Forms.ComboBox)item).SelectedIndex = -1;
                                    }
                                }
                            }
                        }
                    }
                    DtpFecha.Value = DateTime.Now;
                    break;

                case 2:
                    foreach (Control control in this.Controls)
                    {
                        if (control is System.Windows.Forms.GroupBox)
                        {
                            if (control.Name == "groupBox1" || control.Name == "groupBox2" || control.Name == "groupBox4")
                            {
                                foreach (Control item1 in control.Controls)
                                {
                                    if (item1 is System.Windows.Forms.TextBox)
                                        item1.Text = string.Empty;
                                }
                                foreach (Control item in control.Controls)
                                {
                                    if (control is System.Windows.Forms.GroupBox)
                                    {
                                        if (control.Name == "groupBox1" || control.Name == "groupBox2")
                                        {
                                            if (item is System.Windows.Forms.MaskedTextBox)
                                            {
                                                item.Text = string.Empty;
                                            }
                                            if (item is System.Windows.Forms.ComboBox)
                                            {
                                                if (((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello1"
                                                    && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello2"
                                                    && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello3"

                                                   && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello4"
                                                    && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello5"
                                                    && ((System.Windows.Forms.ComboBox)item).Name != "CmbDestinoSello6")
                                                {
                                                    ((System.Windows.Forms.ComboBox)item).SelectedIndex = 0;
                                                    ((System.Windows.Forms.ComboBox)item).Enabled = false;
                                                }
                                                else
                                                {
                                                    ((System.Windows.Forms.ComboBox)item).Text = string.Empty;

                                                    ((System.Windows.Forms.ComboBox)item).SelectedIndex = -1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
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
            if (e.KeyChar == 13)
                TxbPesaje.Focus();
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
                                    if (permisoConsulta.ContenedorPeqMineria > 0)
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

                                                TxbPesoSello1.Text = string.Empty;


                                            CmbDestinoSello1.Text = muestreo.DestinoSello1;
                                            TxbDetalleSello1.Text = muestreo.DetalleSello1;

                                            TxbSello2.Text = muestreo.Sello2;
                                            TxbPesoSello2.Text = muestreo.PesoSello2.ToString("N0", CultureInfo.InvariantCulture);
                                            if (TxbPesoSello2.Text.Trim().Equals("0,"))

                                                TxbPesoSello2.Text = string.Empty;

                                            CmbDestinoSello2.Text = muestreo.DestinoSello2;
                                            TxbDetalleSello2.Text = muestreo.DetalleSello2;

                                            TxbSello3.Text = muestreo.Sello3;
                                            TxbPesoSello3.Text = muestreo.PesoSello3.ToString("N0", CultureInfo.InvariantCulture);
                                            CmbDestinoSello3.Text = muestreo.DestinoSello3;
                                            TxbDetalleSello3.Text = muestreo.DetalleSello3;
                                            TxbSello4.Text = muestreo.Sello4;
                                            TxbPesoSello4.Text = muestreo.PesoSello4.ToString("N0", CultureInfo.InvariantCulture);
                                            if (TxbPesoSello4.Text.Trim().Equals("0,"))
                                                TxbPesoSello4.Text = string.Empty;

                                            CmbDestinoSello4.Text = muestreo.DestinoSello4;
                                            TxbDetalleSello4.Text = muestreo.DetalleSello4;
                                            TxbSello5.Text = muestreo.Sello5;
                                            TxbPesoSello5.Text = muestreo.PesoSello5.ToString("N0", CultureInfo.InvariantCulture);
                                            if (TxbPesoSello5.Text.Trim().Equals("0,"))

                                                TxbPesoSello5.Text = string.Empty;

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
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":", value.FechaEstado1.Minute.ToString());
                                        else
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":0", value.FechaEstado1.Minute.ToString());

                                        if (value.FechaEstado0.Minute.ToString().Length > 1)
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":", value.FechaEstado0.Minute.ToString());
                                        else
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":0", value.FechaEstado0.Minute.ToString());

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
                                            TxbPesoTotal.Text = TxbPesoTotal.Text.Substring(0, TxbPesoTotal.Text.Length - 1);

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
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":", value.FechaEstado1.Minute.ToString());
                                        else
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":0", value.FechaEstado1.Minute.ToString());

                                        if (value.FechaEstado0.Minute.ToString().Length > 1)
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":", value.FechaEstado0.Minute.ToString());
                                        else
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":0", value.FechaEstado0.Minute.ToString());



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
                                            TxbPesoTotal.Text = TxbPesoTotal.Text.Substring(0, TxbPesoTotal.Text.Length - 1);
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
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":", value.FechaEstado1.Minute.ToString());
                                        else
                                            txbHoraIngres.Text = string.Concat(value.FechaEstado1.Hour.ToString(), ":0", value.FechaEstado1.Minute.ToString());

                                        if (value.FechaEstado0.Minute.ToString().Length > 1)
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":", value.FechaEstado0.Minute.ToString());
                                        else
                                            txtHoraSalida.Text = string.Concat(value.FechaEstado0.Hour.ToString(), ":0", value.FechaEstado0.Minute.ToString());

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
                                            TxbPesoTotal.Text = TxbPesoTotal.Text.Substring(0, TxbPesoTotal.Text.Length - 1);
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
            //Forma.Fecha = DtpFecha.Value;

            DateTime thisDate1 = new DateTime(DtpFecha.Value.Year, DtpFecha.Value.Month, DtpFecha.Value.Day);
            Forma.Fecha = new DateTime(DtpFecha.Value.Year, DtpFecha.Value.Month, DtpFecha.Value.Day);

            DBMETAL_SHARP.Common.Common.Permissions = ConsultaEntidades.GetPermisosRoles("SPGet_RolesForUser", DBMETAL_SHARP.Common.Common.User[0].Name.ToString().Trim(), this.Name);


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
            //type = Forma.Tipo;
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
            //type = Forma.Tipo;
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
            //type = Forma.Tipo;
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
            //type = Forma.Tipo;
            type = Forma.TipoFiltro;
            Forma.Fecha = DtpFecha.Value;
            Forma.Pasado += new Frm_Consultas.PasarDatoSeleccionado(EjecutaPasarDato);
            Forma.ShowDialog();
        }

        private void TxbConsecutivo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbCodigoControl_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxbSello1_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbSello2_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbSello3_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbSello4_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbSello6_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbSello5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxbPesoSello1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxbPesoSello4_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbPesoSello3_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxbPesoSello2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxbPesoSello5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxbPesoSello6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (this.Permisos)
            {

                if (String.IsNullOrEmpty(TxbPesaje.Text.Trim()))
                    value = string.Concat(value, "El campo pesaje es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbEncargado.Text.Trim()))
                    value = string.Concat(value, "El campo encargado turno es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbSeguridad.Text.Trim()))
                    value = string.Concat(value, "El campo seguridad zandor es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbCodigoControl.Text.Trim()))
                    value = string.Concat(value, "El campo código control es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbSello1.Text.Trim()))
                    value = string.Concat(value, "El campo sello 1 es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbPesoSello1.Text.Trim()))
                    value = string.Concat(value, "El campo peso de sello 1 es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(CmbDestinoSello1.Text.Trim()))
                    value = string.Concat(value, "El campo destino es requerido", Environment.NewLine);
            }

            if (!String.IsNullOrEmpty(value))
                MessageBox.Show(value, "Validaciones");
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(this.IpLocal))
                        this.IpLocal = DireccionIP.Local();

                    if (string.IsNullOrEmpty(this.IpPublica))
                        this.IpPublica = DireccionIP.Publica();

                    if (string.IsNullOrEmpty(this.SerialHDD))
                        this.SerialHDD = DireccionIP.SerialNumberDisk();

                    if (string.IsNullOrEmpty(this.Usuario))
                        this.Usuario = DireccionIP.SerialNumberDisk();

                    GuardarDatos Guardar = new GuardarDatos();
                    //MessageBox.Show("Entro 1");
                    var culturaCol = CultureInfo.GetCultureInfo("es-CO");


                    DateTime Reportado = Convert.ToDateTime(DtpFecha.Value.ToString("dd/MM/yyyy"), culturaCol);
                    //MessageBox.Show(Reportado.ToString("dd/MM/yyyy"), "Entro 1.2");

                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_MuestreoPM(false, "", 1, TxbPesaje.Text.Trim(), Reportado, string.IsNullOrEmpty(TxbEncargado.Text.Trim()) ? 0 : Convert.ToInt32(TxbEncargado.Text.Trim()), string.IsNullOrEmpty(TxbTercero.Text.Trim()) ? 0 : Convert.ToInt32(TxbTercero.Text.Trim()), string.IsNullOrEmpty(TxbSeguridad.Text.Trim()) ? 0 : Convert.ToInt32(TxbSeguridad.Text.Trim()), string.IsNullOrEmpty(TxbCuartea.Text.Trim()) ? 0 : Convert.ToInt32(TxbCuartea.Text.Trim()), TxbCodigoControl.Text.Trim(), TxbSello1.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello1.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello1.Text.Trim()), CmbDestinoSello1.Text.Trim(), Convert.ToInt32(CmbTipoSello1.SelectedIndex), Convert.ToInt32(CmbAnalisisSello1.SelectedIndex), TxbDetalleSello1.Text.Trim(), TxbSello2.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello2.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello2.Text.Trim()), CmbDestinoSello2.Text.Trim(), Convert.ToInt32(CmbTipoSello2.SelectedIndex), Convert.ToInt32(CmbAnalisisSello2.SelectedIndex), TxbDetalleSello2.Text.Trim(), TxbSello3.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello3.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello3.Text.Trim()), CmbDestinoSello3.Text.Trim(), Convert.ToInt32(CmbTipoSello3.SelectedIndex), Convert.ToInt32(CmbAnalisisSello3.SelectedIndex), TxbDetalleSello3.Text.Trim(), TxbSello4.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello4.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello4.Text.Trim().TrimEnd(',')), CmbDestinoSello4.Text.Trim(), Convert.ToInt32(CmbTipoSello4.SelectedIndex), Convert.ToInt32(CmbAnalisisSello4.SelectedIndex), TxbDetalleSello4.Text.Trim(), TxbSello5.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello5.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello5.Text.Trim()), CmbDestinoSello5.Text.Trim(), Convert.ToInt32(CmbTipoSello5.SelectedIndex), Convert.ToInt32(CmbAnalisisSello5.SelectedIndex), TxbDetalleSello5.Text.Trim(), string.Empty, string.IsNullOrEmpty(string.Empty) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(0), string.Empty, Convert.ToInt32(0), Convert.ToInt32(0), string.Empty, 1, 1, 1, txbContenedor.Text, txtCodProyect.Text, Convert.ToDecimal(TxbPesoTotal.Text), false, txtDescProyect.Text.Trim());
                    //MessageBox.Show("Entro 2");
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
                    value = string.Concat(value, "El campo pesaje es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbEncargado.Text.Trim()))
                    value = string.Concat(value, "El campo encargado turno es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbSeguridad.Text.Trim()))
                    value = string.Concat(value, "El campo seguridad zandor es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbCodigoControl.Text.Trim()))
                    value = string.Concat(value, "El campo código control es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbSello1.Text.Trim()))
                    value = string.Concat(value, "El campo sello 1 es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbPesoSello1.Text.Trim()))
                    value = string.Concat(value, "El campo peso de sello 1 es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(CmbDestinoSello1.Text.Trim()))
                    value = string.Concat(value, "El campo destino es requerido", Environment.NewLine);
            }

            if (!String.IsNullOrEmpty(value))
                MessageBox.Show(value, "Validaciones");
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(this.IpLocal))
                        this.IpLocal = DireccionIP.Local();

                    if (string.IsNullOrEmpty(this.IpPublica))
                        this.IpPublica = DireccionIP.Publica();

                    if (string.IsNullOrEmpty(this.SerialHDD))
                        this.SerialHDD = DireccionIP.SerialNumberDisk();

                    if (string.IsNullOrEmpty(this.Usuario))
                        this.Usuario = DireccionIP.SerialNumberDisk();

                    GuardarDatos Guardar = new GuardarDatos();
                    SqlParameter[] ParamSQl = GuardarDatos.Parametros_MuestreoPM(true, "", 1, TxbPesaje.Text.Trim(), DtpFecha.Value, string.IsNullOrEmpty(TxbEncargado.Text.Trim()) ? 0 : Convert.ToInt32(TxbEncargado.Text.Trim()), string.IsNullOrEmpty(TxbTercero.Text.Trim()) ? 0 : Convert.ToInt32(TxbTercero.Text.Trim()), string.IsNullOrEmpty(TxbSeguridad.Text.Trim()) ? 0 : Convert.ToInt32(TxbSeguridad.Text.Trim()), string.IsNullOrEmpty(TxbCuartea.Text.Trim()) ? 0 : Convert.ToInt32(TxbCuartea.Text.Trim()), TxbCodigoControl.Text.Trim(), TxbSello1.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello1.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello1.Text.Trim()), CmbDestinoSello1.Text.Trim(), Convert.ToInt32(CmbTipoSello1.SelectedIndex), Convert.ToInt32(CmbAnalisisSello1.SelectedIndex), TxbDetalleSello1.Text.Trim(), TxbSello2.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello2.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello2.Text.Trim()), CmbDestinoSello2.Text.Trim(), Convert.ToInt32(CmbTipoSello2.SelectedIndex), Convert.ToInt32(CmbAnalisisSello2.SelectedIndex), TxbDetalleSello2.Text.Trim(), TxbSello3.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello3.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello3.Text.Trim()), CmbDestinoSello3.Text.Trim(), Convert.ToInt32(CmbTipoSello3.SelectedIndex), Convert.ToInt32(CmbAnalisisSello3.SelectedIndex), TxbDetalleSello3.Text.Trim(), TxbSello4.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello4.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello4.Text.Trim().TrimEnd(',')), CmbDestinoSello4.Text.Trim(), Convert.ToInt32(CmbTipoSello4.SelectedIndex), Convert.ToInt32(CmbAnalisisSello4.SelectedIndex), TxbDetalleSello4.Text.Trim(), TxbSello5.Text.Trim(), string.IsNullOrEmpty(TxbPesoSello5.Text.Trim().TrimEnd(',')) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(TxbPesoSello5.Text.Trim()), CmbDestinoSello5.Text.Trim(), Convert.ToInt32(CmbTipoSello5.SelectedIndex), Convert.ToInt32(CmbAnalisisSello5.SelectedIndex), TxbDetalleSello5.Text.Trim(), string.Empty, string.IsNullOrEmpty(string.Empty) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(0), string.Empty, Convert.ToInt32(0), Convert.ToInt32(0), string.Empty, 1, 1, 1, txbContenedor.Text, txtCodProyect.Text, Convert.ToDecimal(TxbPesoTotal.Text), false, txtDescProyect.Text.Trim());
                    if (ParamSQl[0].Value.ToString() == "I")
                    {
                        Guardar.Numerico("Sp_Guardar_MuestreoPM", ParamSQl).ToString();
                    }
                    else
                        Guardar.booleano("Sp_Moficiar_MuestreoPM", ParamSQl);

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
                    value = string.Concat(value, "El campo pesaje es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbEncargado.Text.Trim()))
                    value = string.Concat(value, "El campo encargado turno es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbSeguridad.Text.Trim()))
                    value = string.Concat(value, "El campo seguridad zandor es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbCodigoControl.Text.Trim()))
                    value = string.Concat(value, "El campo código control es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbSello1.Text.Trim()))
                    value = string.Concat(value, "El campo sello 1 es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(TxbPesoSello1.Text.Trim()))
                    value = string.Concat(value, "El campo peso de sello 1 es requerido", Environment.NewLine);
                if (String.IsNullOrEmpty(CmbDestinoSello1.Text.Trim()))
                    value = string.Concat(value, "El campo destino es requerido", Environment.NewLine);
            }

            if (!String.IsNullOrEmpty(value))
                MessageBox.Show(value, "Validaciones");
            else
            {
                try
                {
                    if (string.IsNullOrEmpty(this.IpLocal))
                        this.IpLocal = DireccionIP.Local();

                    if (string.IsNullOrEmpty(this.IpPublica))
                        this.IpPublica = DireccionIP.Publica();

                    if (string.IsNullOrEmpty(this.SerialHDD))
                        this.SerialHDD = DireccionIP.SerialNumberDisk();

                    if (string.IsNullOrEmpty(this.Usuario))
                        this.Usuario = DireccionIP.SerialNumberDisk();

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
                                        selloDes = string.Concat(TxbCodigoControl.Text.Trim(), Convert.ToString(item.SelloControl[item.SelloControl.Trim().Length - 1]));
                                    else
                                        selloDes = TxbCodigoControl.Text;

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
    }
}

using Entidades;
using ReglasdeNegocio;
using ReglasNegocios;
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
    public partial class Frm_Consultas : Form
    {
        public Frm_Consultas(int Op)
        {
            InitializeComponent();
            this.Op = Op;
        }
        public Frm_Consultas(int Op, string codeFilter)
        {
                InitializeComponent();
            this.Op = Op;
            this.codeFilter = codeFilter;
            buttonBuscar.PerformClick();
        }

        #region Delegados
        public delegate void PasarDatoSeleccionado(string Dato);
        public event PasarDatoSeleccionado Pasado;

        public delegate void PasarDatoSeleccionadoRow(DataRow row);
        public event PasarDatoSeleccionadoRow dataRow;
        #endregion

        //#region P
        public int Tipo { get; set; }

        public int TipoFiltro { get; set; }
        public DateTime Fecha { get; set; }
        int Op;
        string codeFilter = string.Empty;


        private void Frm_Consultas_Load(object sender, EventArgs e)
        {
            GrbBuscar.Visible = true;

            switch (this.Tipo)
            {
                case 1:
                    buttonBuscar.PerformClick();
                    break;
                case 2:
                    List_CamposRDB FindEntities = new List_CamposRDB();
                    SqlParameter[] ParamEntities = new SqlParameter[4];
                    List<string> ListEntities;

                    ParamEntities[0] = new SqlParameter("@Op", "LlenarRDB");
                    ParamEntities[1] = new SqlParameter("@ParametroChar", "");
                    ParamEntities[2] = new SqlParameter("@ParametroInt", Op);
                    ParamEntities[3] = new SqlParameter("@ParametroNuemric", "0.00");

                    LlenarRDB.ConsultarIdRadioButton(GrbBuscar).ToString();
                    ListEntities = FindEntities.Consultar_Campos("SpConsulta_Tablas", ParamEntities);

                    int PosicionejeY = 0;
                    for (int i = 0; i < ListEntities.Count; i++)
                    {
                        RadioButton radio = new RadioButton();
                        radio.Text = ListEntities[i];
                        PosicionejeY += 20;
                        radio.Location = new Point(10, PosicionejeY);
                        if (i == 0)
                            radio.Checked = true;

                        GrbBuscar.Controls.Add(radio);
                    }
                    break;

                case 3:
                    buttonBuscar.PerformClick();

                    FindEntities = new List_CamposRDB();
                    ParamEntities = new SqlParameter[4];

                    ParamEntities[0] = new SqlParameter("@Op", "LlenarRDB");
                    ParamEntities[1] = new SqlParameter("@ParametroChar", "");
                    ParamEntities[2] = new SqlParameter("@ParametroInt", Op);
                        ParamEntities[3] = new SqlParameter("@ParametroNuemric", "0.00");

                    LlenarRDB.ConsultarIdRadioButton(GrbBuscar).ToString();
                    ListEntities = FindEntities.Consultar_Campos("SpConsulta_Tablas", ParamEntities);

                    PosicionejeY = 0;
                    for (int i = 0; i < ListEntities.Count; i++)
                    {
                        RadioButton radio = new RadioButton();
                        radio.Text = ListEntities[i];
                        PosicionejeY += 20;
                        radio.Location = new Point(10, PosicionejeY);
                        if (i == 0)
                            radio.Checked = true;

                        GrbBuscar.Controls.Add(radio);
                    }
                    break;

                default:
                    FindEntities = new List_CamposRDB();
                    ParamEntities = new SqlParameter[4];

                    ParamEntities[0] = new SqlParameter("@Op", "LlenarRDB");
                    ParamEntities[1] = new SqlParameter("@ParametroChar", "");
                    ParamEntities[2] = new SqlParameter("@ParametroInt", Op);
                    ParamEntities[3] = new SqlParameter("@ParametroNuemric", "0.00");

                    LlenarRDB.ConsultarIdRadioButton(GrbBuscar).ToString();
                    ListEntities = FindEntities.Consultar_Campos("SpConsulta_Tablas", ParamEntities);

                    PosicionejeY = 0;
                    for (int i = 0; i < ListEntities.Count; i++)
                    {
                        RadioButton radio = new RadioButton();
                        radio.Text = ListEntities[i];
                        PosicionejeY += 20;
                        radio.Location = new Point(10, PosicionejeY);
                        if (i == 0)
                            radio.Checked = true;

                        GrbBuscar.Controls.Add(radio);
                    }
                    break;
            }

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.Tipo)
                {
                    case 1:
                        GrbBuscar.Visible = false;

                        string Operation = string.Empty;
                        Roles_Permisos permisoConsulta = DBMETAL_SHARP.Common.Common.Permissions.Where(s => s.fkcontrolid == "TxbPesaje").FirstOrDefault();

                        if (permisoConsulta.ContenedorOtros>0 && permisoConsulta.ContenedorPeqMineria > 0 && permisoConsulta.ContenedorZandor > 0)
                            Operation = "Marcaciones";
                        else
                            if (permisoConsulta.ContenedorOtros > 0 || permisoConsulta.ContenedorPeqMineria > 0)
                            Operation = "MarcacionesOtros";
                        else
                            Operation = "MarcacionesZandor"; 

                            DataSet DSInitial = ConsultaTablas.Dataset(Operation, this.Fecha.ToShortDateString(), 0, 0.00);
                        DataTable dt = DSInitial.Tables[0].Clone();
                        dt.Merge(DSInitial.Tables[0]);
                        DataRow[] dtrow = dt.Select("Muestreo=" + 0);
                        DSInitial.Tables[0].Clear();

                        for (int i = 0; i < dtrow.Length; i++)
                        {
                            DSInitial.Tables[0].ImportRow(dtrow[i]);
                        }

                        dataGridViewConsulta.DataSource = DSInitial;
                        dataGridViewConsulta.DataMember = "Result";
                        dataGridViewConsulta.Columns["PesoVacio"].DefaultCellStyle.Format = "##,##.00";
                        dataGridViewConsulta.Columns["PesoVacio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dataGridViewConsulta.Columns["PesoLleno"].DefaultCellStyle.Format = "##,##.00";
                        dataGridViewConsulta.Columns["PesoLleno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dataGridViewConsulta.Columns["PesoTotal"].DefaultCellStyle.Format = "##,##.00";
                        dataGridViewConsulta.Columns["PesoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridViewConsulta.AutoResizeColumns();
                        break;
                    case 2:
                        List_CamposRDB FindEntities = new List_CamposRDB();
                        SqlParameter[] Parametros = new SqlParameter[4];
                        int IdBuscar = LlenarRDB.ConsultarIdRadioButton(GrbBuscar);
                        DataSet DS;

                        Parametros[0] = new SqlParameter("@Op", "LlenarGrid");
                        Parametros[1] = new SqlParameter("@ParametroChar", this.TxbConsulta.Text.Trim());
                        Parametros[2] = new SqlParameter("@ParametroInt", Op);
                        Parametros[3] = new SqlParameter("@ParametroNuemric", IdBuscar);

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", Parametros);

                        if (TipoFiltro > 0)
                        {
                            dt = DS.Tables[0].Clone();
                            dt.Merge(DS.Tables[0]);
                            dtrow = dt.Select("Rol=" + TipoFiltro);
                            DS.Tables[0].Clear();
                            for (int i = 0; i < dtrow.Length; i++)
                            {
                                DS.Tables[0].ImportRow(dtrow[i]);
                            }
                        }

                        dataGridViewConsulta.DataSource = DS;
                        dataGridViewConsulta.DataMember = "Result";
                        dataGridViewConsulta.AutoResizeColumns();
                        break;
                    case 3:
                        FindEntities = new List_CamposRDB();
                        Parametros = new SqlParameter[4];

                        if (!String.IsNullOrEmpty(TxbConsulta.Text))
                            this.codeFilter = TxbConsulta.Text;

                        Parametros[0] = new SqlParameter("@Op", "LlenarGrid");
                        Parametros[1] = new SqlParameter("@ParametroChar", this.codeFilter);
                        Parametros[2] = new SqlParameter("@ParametroInt", 27);
                        Parametros[3] = new SqlParameter("@ParametroNuemric", 1);

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", Parametros);

                        if (TipoFiltro > 0)
                        {
                            dt = DS.Tables[0].Clone();
                            dt.Merge(DS.Tables[0]);
                            dtrow = dt.Select("Rol=" + TipoFiltro);
                            DS.Tables[0].Clear();
                            for (int i = 0; i < dtrow.Length; i++)
                            {
                                DS.Tables[0].ImportRow(dtrow[i]);
                            }
                        }

                        dataGridViewConsulta.DataSource = DS;
                        dataGridViewConsulta.DataMember = "Result";
                        dataGridViewConsulta.AutoResizeColumns();

                        break;

                    default:
                        FindEntities = new List_CamposRDB();
                        Parametros = new SqlParameter[4];
                        IdBuscar = LlenarRDB.ConsultarIdRadioButton(GrbBuscar);

                        Parametros[0] = new SqlParameter("@Op", "LlenarGrid");
                        Parametros[1] = new SqlParameter("@ParametroChar", this.TxbConsulta.Text.Trim());
                        Parametros[2] = new SqlParameter("@ParametroInt", Op);
                        Parametros[3] = new SqlParameter("@ParametroNuemric", IdBuscar);

                        DS = LlenarGrid.Datos("SpConsulta_Tablas", Parametros);

                        if (DS.Tables[0].Rows.Count == 0)
                        {
                            Parametros = new SqlParameter[4];
                            Parametros[0] = new SqlParameter("@Op", "LlenarGrid");
                            Parametros[1] = new SqlParameter("@ParametroChar", this.TxbConsulta.Text.Trim());
                            Parametros[2] = new SqlParameter("@ParametroInt", 27);
                            Parametros[3] = new SqlParameter("@ParametroNuemric", IdBuscar);
                            DS = new DataSet();
                            DS = LlenarGrid.Datos("SpConsulta_Tablas", Parametros);
                        }


                        dataGridViewConsulta.DataSource = DS;
                        dataGridViewConsulta.DataMember = "Result";
                        dataGridViewConsulta.AutoResizeColumns();
                        break;
                }
            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL CONSULTAR O CARGAR LOS DATOS..: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Fill = dataGridViewConsulta.CurrentCell.RowIndex;

                switch (this.Tipo)
                {
                    case 1:
                        Pasado(string.Concat(dataGridViewConsulta[0, Fill].Value.ToString().Trim()));
                        Close();
                        break;
                    case 2:
                        Pasado(string.Concat(dataGridViewConsulta[0, Fill].Value.ToString().Trim(), "-", dataGridViewConsulta[1, Fill].Value.ToString().Trim(), " ", dataGridViewConsulta[2, Fill].Value.ToString().Trim()));
                        Close();
                        break;
                    default:
                        Pasado(string.Concat(dataGridViewConsulta[0, Fill].Value.ToString().Trim(),"/", dataGridViewConsulta[4, Fill].Value.ToString().Trim()));
                        Close();
                        break;
                }
            }
            catch (Exception Exc)
            {
                MessageBox.Show("OCURRIÓ UN ERROR AL PASAR LOS DATOS: \n\n" + Exc.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxbConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.buttonBuscar.PerformClick();
        }
    }
}

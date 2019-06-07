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

namespace DBMETAL_SHARP.Liquidacion
{
    public partial class ManagePermissions : Form
    {
        #region Variables
        public string Usuario { get; set; }
        public string IpLocal { get; set; }
        public string IpPublica { get; set; }
        public string SerialHDD { get; set; }
        #endregion

        private Dictionary<string, string> oldMenuToolTips =
          new Dictionary<string, string>();
        private Form workingForm;
        private ToolTip formToolTip1 = null;
        private ToolTip formToolTip2 = null;

        public ManagePermissions(string User)
        {
            InitializeComponent();
            this.Usuario = User;
            comboBox1.Items.Insert(0, "Muestreo");
            comboBox1.Items.Insert(1, "Control de calidad");
            comboBox1.Items.Insert(2, "Periodo");
            comboBox1.Items.Insert(3, "Carga de resultados");
            comboBox1.Items.Insert(4, "Formulario contenedor");

            if (workingForm == null)
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox4.Visible = false;
            }
            if (string.IsNullOrEmpty(this.IpLocal))
                this.IpLocal = DireccionIP.Local();

            if (string.IsNullOrEmpty(this.IpPublica))
                this.IpPublica = DireccionIP.Publica();

            if (string.IsNullOrEmpty(this.SerialHDD))
                this.SerialHDD = DireccionIP.SerialNumberDisk();

            if (string.IsNullOrEmpty(this.Usuario))
                this.Usuario = DireccionIP.SerialNumberDisk();
        }

        public void ManagePermission(Form f, ToolTip toolTip1, ToolTip toolTip2)
        {
            PageControls.Items.Clear();
            workingForm = f;

            //formToolTip1 = toolTip1;
            //formToolTip2 = toolTip2;
            //formToolTip1.Active = false;
            //formToolTip2.Active = true;

            this.Text += " Por vista" + f.Name;
            ShowControls(f.Controls);
            PopulatePermissionTree();
        }
        public ManagePermissions(Form f, ToolTip toolTip1, ToolTip toolTip2)
        {
            InitializeComponent();
            workingForm = f;

            //formToolTip1 = toolTip1;
            //formToolTip2 = toolTip2;
            //formToolTip1.Active = false;
            //formToolTip2.Active = true;

            this.Text += " Por vista" + f.Name;
            ShowControls(f.Controls);
            PopulatePermissionTree();
        }
        private void ShowControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    ShowControls(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    ShowToolStipItems(menuStrip.Items);
                }

                if (c is Button || c is ComboBox || c is TextBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage || c is TextBox || c is GroupBox)
                {

                    //formToolTip2.SetToolTip(c, c.Name);

                    PageControls.Items.Add(c.Name);

                }
            }
        }
        private void ShowToolStipItems(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                oldMenuToolTips.Add(mi.Name, mi.ToolTipText);
                mi.ToolTipText = mi.Name;

                if (mi.DropDownItems.Count > 0)
                {
                    ShowToolStipItems(mi.DropDownItems);
                }

                PageControls.Items.Add(mi.Name);
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexion.OpenConexion();

            SqlParameter param;
            foreach (String controlID in PageControls.SelectedItems)
            {
                foreach (DataRowView roleRow in PermissionRoles.SelectedItems)
                {

                    int roleID = Convert.ToInt32(roleRow["RoleID"]);
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "spInsertNewControlToRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        param = cmd.Parameters.Add("@RoleID", SqlDbType.Int);
                        param.Value = roleID;
                        param.Direction = ParameterDirection.Input;

                        param = cmd.Parameters.Add("@PageName", SqlDbType.VarChar, 50);
                        param.Value = workingForm.Name.ToString();
                        param.Direction = ParameterDirection.Input;

                        param = cmd.Parameters.Add("@ControlID", SqlDbType.VarChar, 50);
                        param.Value = controlID;
                        param.Direction = ParameterDirection.Input;

                        param = cmd.Parameters.Add("@invisible", SqlDbType.Int);
                        param.Value = InVisible.Checked ? 1 : 0;
                        param.Direction = ParameterDirection.Input;

                        param = cmd.Parameters.Add("@disabled", SqlDbType.Int);
                        param.Value = Disabled.Checked ? 1 : 0;
                        param.Direction = ParameterDirection.Input;

                        param = cmd.Parameters.Add("@ContenedorPeqMineria", SqlDbType.Int);
                        param.Value = checkBox1.Checked ? 1 : 0;
                        param.Direction = ParameterDirection.Input;

                        param = cmd.Parameters.Add("@ContenedorZandor", SqlDbType.Int);
                        param.Value = checkBox2.Checked ? 1 : 0;
                        param.Direction = ParameterDirection.Input;

                        param = cmd.Parameters.Add("@ContenedorOtros", SqlDbType.Int);
                        param.Value = checkBox4.Checked ? 1 : 0;
                        param.Direction = ParameterDirection.Input;
                        //}

                        int rowsInserted = cmd.ExecuteNonQuery();
                        if (rowsInserted < 1 || rowsInserted > 2)
                        {
                            DisplayError(controlID, roleID, "Registros insertados= " + rowsInserted.ToString());
                        }

                        if (string.IsNullOrEmpty(this.IpLocal))
                            this.IpLocal = DireccionIP.Local();

                        if (string.IsNullOrEmpty(this.IpPublica))
                            this.IpPublica = DireccionIP.Publica();

                        if (string.IsNullOrEmpty(this.SerialHDD))
                            this.SerialHDD = DireccionIP.SerialNumberDisk();

                        if (string.IsNullOrEmpty(this.Usuario))
                            this.Usuario = DireccionIP.SerialNumberDisk();

                        LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Creación de permisos" , "Asignación de permisos");


                    }
                    catch (Exception ex)
                    {
                        DisplayError(controlID, roleID, ex.Message);
                    }
                }
            }
            conn.Close();
            PopulatePermissionTree();

        }
        private void DisplayError(string controlID, int roleID, string message)
        {
            MessageBox.Show("No se puede agregar control(" + controlID + ") y el rol (" + roleID + ")" + message,
                "No se puede agregar control al rol",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        private void PopulatePermissionTree()
        {


            string queryString = "select ctr .fkpage, controlID, Invisible, Disabled, RoleName,ContenedorPeqMineria,ContenedorZandor,ContenedorOtros " +
            "from ControlsToRoles ctr " +
            " join controls c on c.ControlID = ctr.FKControlID and c.Page = ctr.FKPage " +
            " join roles r on r.RoleID = ctr.FKRole ";

            if (ByControlRB.Checked)
            {
                queryString += " order by ControlID";
            }
            else
            {
                queryString += " order by RoleName";
            }
            DataTable dt = null;
            try

            {
                dt = GuardarDatos.GetRoles(queryString);

            }
            catch (Exception e)
            {
                MessageBox.Show("Incapaz de recuperar permisos: " + e.Message,
                    "Error al recuperar permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            PermissionTree.BeginUpdate();
            PermissionTree.Nodes.Clear();
            TreeNode parentNode = null;
            TreeNode subNode = null;

            string currentName = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                string subNodeText = String.Concat(" Formulario: ", row["fkpage"].ToString(), "-", (ByControlRB.Checked ? row["RoleName"].ToString() : row["ControlID"].ToString()));
                subNodeText += ":";
                subNodeText += Convert.ToInt32(row["Invisible"]) == 0 ? " visible " : " no visible ";
                subNodeText += ", ";
                subNodeText += Convert.ToInt32(row["Disabled"]) == 0 ? " Activo " : " Inactivo ";


                if (workingForm != null && workingForm.Name.Trim().ToUpper().Contains("FRM_MUESTREOPM"))
                {
                    if (!String.IsNullOrEmpty(row["ContenedorPeqMineria"].ToString().Trim()))
                    {
                        subNodeText += ", ";

                        subNodeText += Convert.ToInt32(row["ContenedorPeqMineria"]) == 0 ? " No Grabar Peq Min " : " Grabar Peq Min";
                        subNodeText += ", ";
                        subNodeText += Convert.ToInt32(row["ContenedorZandor"]) == 0 ? " No Grabar Cont Zandor" : " Grabar Cont Zandor";
                        subNodeText += ", ";
                        subNodeText += Convert.ToInt32(row["ContenedorOtros"]) == 0 ? " No Grabar Cont Otros" : " Grabar Cont Otros";
                    }
                }

                subNode = new TreeNode(subNodeText);
                string dataName = ByControlRB.Checked ? row["ControlID"].ToString() : row["RoleName"].ToString();
                if (currentName != dataName)
                {
                    parentNode = new TreeNode(dataName);
                    currentName = dataName;
                    PermissionTree.Nodes.Add(parentNode);
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(subNode);
                }
            }
            PermissionTree.EndUpdate();
        }

        private void RestoreMenuStripToolTips(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                if (mi.DropDownItems.Count > 0)
                {
                    RestoreMenuStripToolTips(mi.DropDownItems);
                }

                if (oldMenuToolTips.ContainsKey(mi.Name))
                {
                    mi.ToolTipText = oldMenuToolTips[mi.Name];
                }
                else
                {
                    mi.ToolTipText = string.Empty;
                }
            }
        }
        private void ManagePermissions_Load(object sender, EventArgs e)
        {
            this.rolesTableAdapter1.Fill(this.controlSecurityDataSet1.Roles);

        }

        private void ManagePermissions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workingForm != null)
                foreach (Control c in workingForm.Controls)
                {
                    if (c is MenuStrip)
                    {
                        MenuStrip ms = c as MenuStrip;
                        RestoreMenuStripToolTips(ms.Items);
                    }
                }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ByControlRB_CheckedChanged(object sender, EventArgs e)
        {
            PopulatePermissionTree();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    Frm_MuestreoPM oDB = new Frm_MuestreoPM();
                    ManagePermission(oDB, null, null);
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox4.Visible = true;

                    break;

                case 1:
                    Frm_ControlCalidadMuestras oDB1 = new Frm_ControlCalidadMuestras();
                    ManagePermission(oDB1, null, null);
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox4.Visible = false;
                    break;

                case 3:
                    Frm_CargaAnalisis oDB2 = new Frm_CargaAnalisis();
                    ManagePermission(oDB2, null, null);
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox4.Visible = false;

                    break;

                case 2:
                    Frm_Periodo oDB3 = new Frm_Periodo();
                    ManagePermission(oDB3, null, null);
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox4.Visible = false;
                    break;

                case 4:
                    frmPpal Odb4 = new frmPpal();
                    ManagePermission(Odb4, null, null);
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox4.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string controlID = string.Empty;
            int roleID = 0;
            try
            {
                string[] node = PermissionTree.SelectedNode.FullPath.Split(':');
                string[] nameForm;
                if (node.Length > 1)
                {
                    if (!ByRoleRB.Checked)
                    {
                        nameForm = node[1].Split('-');

                        var roleId = this.controlSecurityDataSet1.Roles.Where(u => u.RoleName == nameForm[1].ToString()).Select(s => s.RoleID);

                        foreach (var item in roleId)
                        {
                            roleID = item;
                        }

                        string nameForms = nameForm[0].ToString();

                        nameForm = node[0].Split('\\');
                        controlID = nameForm[0].ToString();

                        SqlParameter[] ParamSQl = GuardarDatos.Parametros_Update_Rol(roleID, nameForms, controlID, InVisible.Checked ? 1 : 0, Disabled.Checked ? 1 : 0, checkBox1.Checked ? 1 : 0, checkBox2.Checked ? 1 : 0, checkBox4.Checked ? 1 : 0);

                        GuardarDatos Guardar = new GuardarDatos();

                        bool rowsInserted = Guardar.booleano("spUpdateControlToRole", ParamSQl);

                        if (!rowsInserted)
                        {
                            DisplayError(controlID, roleID, "Registros insertados= " + rowsInserted.ToString());
                        }
                        else
                            MessageBox.Show("Registro actualizado con exito!");
                    }
                    else
                    {
                        nameForm = node[0].Split('-');
                        string[] nameForm1 = nameForm[0].ToString().Split('\\');
                        var roleId = this.controlSecurityDataSet1.Roles.Where(u => u.RoleName == nameForm1[0].ToString()).Select(s => s.RoleID);

                        foreach (var item in roleId)
                        {
                            roleID = item;
                        }

                        string nameForms = nameForm[0].ToString();

                        nameForm = node[1].Split('-');
                        nameForms = nameForm[0].ToString();
                        controlID = nameForm[1].ToString();

                        SqlParameter[] ParamSQl = GuardarDatos.Parametros_Update_Rol(roleID, nameForms, controlID, InVisible.Checked ? 1 : 0, Disabled.Checked ? 1 : 0, checkBox1.Checked ? 1 : 0, checkBox2.Checked ? 1 : 0, checkBox4.Checked ? 1 : 0);

                        GuardarDatos Guardar = new GuardarDatos();

                        bool rowsInserted = Guardar.booleano("spUpdateControlToRole", ParamSQl);

                        if (!rowsInserted)
                        {
                            DisplayError(controlID, roleID, "Registros insertados= " + rowsInserted.ToString());
                        }
                        else
                            MessageBox.Show("Registro actualizado con exito!");
                    }


                    LlenarLog.Registro(DateTime.Now, this.Usuario, this.IpLocal, this.IpPublica, this.SerialHDD, Environment.MachineName, "Modifiación de permisos", "Asignación de permisos");


                }
            }
            catch (Exception ex)
            {
                DisplayError(controlID, roleID, ex.Message);
            }

            PopulatePermissionTree();
        }

        private void PermissionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (PermissionTree.SelectedNode != null)
            {
                string[] node = e.Node.FullPath.Split(':');

                if (node.Length > 1)
                {
                    string[] controller = node[2].Split(',');

                    if (controller[0].ToString().Trim().ToUpper().Contains("NO"))
                        InVisible.Checked = true;
                    else
                        InVisible.Checked = false;

                    if (controller[1].ToString().Trim().ToUpper().Contains("INACTIVO"))
                        Disabled.Checked = true;
                    else
                        Disabled.Checked = false;

                    if (workingForm != null && workingForm.Name.Trim().ToUpper().Contains("FRM_MUESTREOPM"))
                    {
                        if (controller[2].ToString().Trim().ToUpper().Contains("NO"))
                            checkBox1.Checked = false;
                        else
                            checkBox1.Checked = true;

                        if (controller[3].ToString().Trim().ToUpper().Contains("NO"))
                            checkBox2.Checked = false;
                        else
                            checkBox2.Checked = true;

                        if (controller[4].ToString().Trim().ToUpper().Contains("NO"))
                            checkBox4.Checked = false;
                        else
                            checkBox4.Checked = true;
                    }
                }
            }

        }
    }
}

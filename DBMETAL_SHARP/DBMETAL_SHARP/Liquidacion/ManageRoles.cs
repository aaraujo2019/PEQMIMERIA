using DBMETAL_SHARP.Liquidacion;
using DBMETAL_SHARP.Liquidacion.DataSet;
using ReglasdeNegocio;
using ReglasdeNegocio.DirectoryActivity;
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
    public partial class ManageRoles : Form
    {
        DataRow rows;
        public ManageRoles()
        {
            InitializeComponent();
            FillUsersInRollsTree();
        }

        private void FillUsersInRollsTree()
        {


            string queryString = "select u.Name, r.RoleName from userstoRoles utr " +
            " join users u on u.userID = utr.FKUserID " +
            " join Roles r on r.roleID = utr.FKRoleID ";

            if (rbName.Checked)
            {
                queryString += "order by Name";
            }
            else
            {
                queryString += "order by RoleName";
            }

            UsersInRoles.BeginUpdate();
            UsersInRoles.Nodes.Clear();
            TreeNode parentNode = null;
            TreeNode subNode = null;


            DataTable dt = GuardarDatos.GetRoles(queryString);
            string currentName = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                if (rbName.Checked)
                {
                    subNode = new TreeNode(row["roleName"].ToString());
                    if (currentName != row["Name"].ToString())
                    {
                        parentNode = new TreeNode(row["Name"].ToString());
                        currentName = row["Name"].ToString();
                        UsersInRoles.Nodes.Add(parentNode);
                    }
                }
                else
                {
                    subNode = new TreeNode(row["Name"].ToString());
                    if (currentName != row["RoleName"].ToString())
                    {
                        parentNode = new TreeNode(row["RoleName"].ToString());
                        currentName = row["RoleName"].ToString();
                        UsersInRoles.Nodes.Add(parentNode);
                    }

                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(subNode);
                }
            }
            UsersInRoles.EndUpdate();
        }

        private void AddNewAppUser_Click(object sender, EventArgs e)
        {
            var user = DirectorioActivo.ExisteUsuarioAD(DBMETAL_SHARP.Common.Common.Dominio, NewUserName.Text);

            if (user != null)
            {
                ControlSecurityDataSet.UsersRow newUsersRow;
                newUsersRow = controlSecurityDataSet1.Users.NewUsersRow();
                newUsersRow.Name = NewUserName.Text.Trim();
                newUsersRow.Identification = txbIdentificacion.Text.Trim();
                NewUserName.Text = string.Empty;
                txbIdentificacion.Text = string.Empty;
                this.controlSecurityDataSet1.Users.Rows.Add(newUsersRow);
                this.usersTableAdapter1.Update(this.controlSecurityDataSet1.Users);
                AppUsersListBox.SelectedIndex = -1;
            }
            else
                MessageBox.Show("El usuario no existe en el directorio activo");
        }

        private void ManageRoles_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'controlSecurityDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter1.Fill(this.controlSecurityDataSet1.Users);
            // TODO: This line of code loads data into the 'controlSecurityDataSet.Roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter1.Fill(this.controlSecurityDataSet1.Roles);

        }

        private void AddNewRole_Click(object sender, EventArgs e)
        {
            string newName = string.Empty;
            newName = NewRoleName.Text;
            NewRoleName.Text = string.Empty; // clear the control

            ControlSecurityDataSet.RolesRow newRolesRow;
            newRolesRow = controlSecurityDataSet1.Roles.NewRolesRow();
            newRolesRow.RoleName = newName;
            this.controlSecurityDataSet1.Roles.Rows.Add(newRolesRow);

            try
            {
                this.rolesTableAdapter1.Update(this.controlSecurityDataSet1.Roles);
            }
            catch (Exception ex)
            {
                this.controlSecurityDataSet1.Roles.Rows.Remove(newRolesRow);
                MessageBox.Show("No se puede adicionar el rol" + newName + ex.Message,
                "No se puede agregar el rol!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RolesListBox.SelectedIndex = -1;

        }

        private void AddUsersToRole_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexion.OpenConexion();

            SqlParameter param;

            foreach (DataRowView userRow in AppUsersListBox.SelectedItems)
            {
                foreach (DataRowView roleRow in RolesListBox.SelectedItems)
                {
                    int userID = Convert.ToInt32(userRow["UserID"]);
                    int roleID = Convert.ToInt32(roleRow["RoleID"]);
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "spInsertNewUserInRole";
                        cmd.CommandType = CommandType.StoredProcedure;
                        param = cmd.Parameters.Add("@USERID", SqlDbType.Int);
                        param.Value = userID;
                        param.Direction = ParameterDirection.Input;
                        param = cmd.Parameters.Add("@RoleID", SqlDbType.Int);
                        param.Value = roleID;
                        param.Direction = ParameterDirection.Input;
                        int rowsInserted = cmd.ExecuteNonQuery();
                        if (rowsInserted != 1)
                        {
                            DisplayError(userID, roleID, "Rows inserted = " + rowsInserted.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        DisplayError(userID, roleID, ex.Message);
                    }

                }
            }
            conn.Close();
            FillUsersInRollsTree();

        }


        private void DisplayError(int userID, int roleID, string message)
        {
            MessageBox.Show("No se logro adicionar el usuario(" + userID + ") al rol (" + roleID + ")" + message,
                "No se puede agregar usuario al rol",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void rbName_Click(object sender, EventArgs e)
        {
            FillUsersInRollsTree();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = Conexion.OpenConexion();

            SqlParameter param;


            //UsersInRoles.Nodes.Remove(UsersInRoles.SelectedNode);

            if (UsersInRoles.SelectedNode != null)
            {
                string[] node = UsersInRoles.SelectedNode.FullPath.Split('\\');
                string userID = string.Empty;
                string roleID = string.Empty;

                if (node.Length > 1)
                {
                    if (rbName.Checked)
                    {
                        userID = node[0].ToString().Trim();

                        roleID = node[1].ToString().Trim();
                    }
                    else
                    {
                        userID = node[1].ToString().Trim();

                        roleID = node[0].ToString().Trim();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un relación a eliminar");
                    return;
                }

                var nameUser = this.controlSecurityDataSet1.Users.Where(u => u.Name == userID).Select(s => s.UserID);
                // this.controlSecurityDataSet1.Roles
                var roleId = this.controlSecurityDataSet1.Roles.Where(u => u.RoleName == roleID).Select(s => s.RoleID);

                foreach (var item in nameUser)
                {
                    userID = item.ToString().Trim();
                }
                foreach (var item in roleId)
                {
                    roleID = item.ToString().Trim();
                }
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "spDeleteUserInRole";
                    cmd.CommandType = CommandType.StoredProcedure;
                    param = cmd.Parameters.Add("@USERID", SqlDbType.Int);
                    param.Value = userID;
                    param.Direction = ParameterDirection.Input;
                    param = cmd.Parameters.Add("@RoleID", SqlDbType.Int);
                    param.Value = roleID;
                    param.Direction = ParameterDirection.Input;
                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted != 1)
                    {
                        //DisplayError(userID, roleID, "Rows inserted = " + rowsInserted.ToString());
                    }
                }
                catch (Exception ex)
                {
                    //DisplayError(userID, roleID, ex.Message);
                }


                conn.Close();
                FillUsersInRollsTree();

            }
            else
                MessageBox.Show("Seleccione una relación a eliminar");
        }

        private void button4_Click(object sender, EventArgs e)
        {
           rows = this.controlSecurityDataSet1.Users.Where(r => r.Name == AppUsersListBox.Text).FirstOrDefault();
            var vass = this.controlSecurityDataSet1.Users.Where(r => r.Name == AppUsersListBox.Text).FirstOrDefault();

            int value = this.usersTableAdapter1.Delete(Convert.ToInt32(rows[0]), rows[1].ToString(), rows[2].ToString(), rows[3].ToString());

            DataRowAction act = new DataRowAction();
            ControlSecurityDataSet.UsersRow rw = this.controlSecurityDataSet1.Users[6];
            rw.Delete();
            vass.Delete();
            ControlSecurityDataSet.UsersRowChangeEvent es = new ControlSecurityDataSet.UsersRowChangeEvent(rw, act);
            controlSecurityDataSet1.Users.Rows.Remove(rows);
            controlSecurityDataSet1.Users.AcceptChanges();
            //object val;
            //this.controlSecurityDataSet1.Users.UsersRowDeleted += Users_UsersRowDeleted(null, es);

            this.usersTableAdapter1.Update(this.controlSecurityDataSet1.Users);

            AppUsersListBox.SelectedIndex = -1;
        }

        private void Users_UsersRowDeleted(object sender, ControlSecurityDataSet.UsersRowChangeEvent e)
        {
            //e.Row = rows;
            //    new ControlSecurityDataSet.UsersRow .Delete();
        }

        private void AppUsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRow rows = this.controlSecurityDataSet1.Roles.Where(r => r.RoleName == RolesListBox.Text).FirstOrDefault();

            this.controlSecurityDataSet1.Roles.Where(r => r.RoleName == RolesListBox.Text).FirstOrDefault().Delete();

            controlSecurityDataSet1.Roles.Rows.Remove(rows);
            this.rolesTableAdapter1.Update(this.controlSecurityDataSet1.Roles);
            RolesListBox.SelectedIndex = -1;            
        }

       
    }
}

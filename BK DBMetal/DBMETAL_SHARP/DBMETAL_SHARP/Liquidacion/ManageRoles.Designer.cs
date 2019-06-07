namespace DBMETAL_SHARP
{
    partial class ManageRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rbRole = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.UsersInRoles = new System.Windows.Forms.TreeView();
            this.RolesMessage = new System.Windows.Forms.Label();
            this.NewRoleName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RolesListBox = new System.Windows.Forms.ListBox();
            this.rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlSecurityDataSet1 = new DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSet();
            this.lblMsg = new System.Windows.Forms.Label();
            this.NewUserName = new System.Windows.Forms.TextBox();
            this.AddUsersToRole = new System.Windows.Forms.Button();
            this.AppUsersListBox = new System.Windows.Forms.ListBox();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rolesTableAdapter1 = new DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSetTableAdapters.RolesTableAdapter();
            this.usersTableAdapter1 = new DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSetTableAdapters.UsersTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTitulos = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbIdentificacion = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.botonEliminarUsuario = new System.Windows.Forms.Button();
            this.botonEliminarRelUsuRol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlSecurityDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbRole
            // 
            this.rbRole.AutoSize = true;
            this.rbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbRole.Location = new System.Drawing.Point(703, 221);
            this.rbRole.Name = "rbRole";
            this.rbRole.Size = new System.Drawing.Size(60, 24);
            this.rbRole.TabIndex = 124;
            this.rbRole.Text = "Role";
            this.rbRole.UseVisualStyleBackColor = true;
            this.rbRole.Click += new System.EventHandler(this.rbName_Click);
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbName.Location = new System.Drawing.Point(615, 223);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(82, 24);
            this.rbName.TabIndex = 123;
            this.rbName.TabStop = true;
            this.rbName.Text = "Usuario";
            this.rbName.UseVisualStyleBackColor = true;
            this.rbName.Click += new System.EventHandler(this.rbName_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(632, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 122;
            this.label4.Text = "Usuario en Roles";
            // 
            // UsersInRoles
            // 
            this.UsersInRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UsersInRoles.Location = new System.Drawing.Point(615, 45);
            this.UsersInRoles.Name = "UsersInRoles";
            this.UsersInRoles.Size = new System.Drawing.Size(169, 164);
            this.UsersInRoles.TabIndex = 121;
            // 
            // RolesMessage
            // 
            this.RolesMessage.AutoSize = true;
            this.RolesMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RolesMessage.Location = new System.Drawing.Point(323, 223);
            this.RolesMessage.Name = "RolesMessage";
            this.RolesMessage.Size = new System.Drawing.Size(50, 20);
            this.RolesMessage.TabIndex = 120;
            this.RolesMessage.Text = "Roles";
            // 
            // NewRoleName
            // 
            this.NewRoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NewRoleName.Location = new System.Drawing.Point(258, 246);
            this.NewRoleName.Name = "NewRoleName";
            this.NewRoleName.Size = new System.Drawing.Size(169, 26);
            this.NewRoleName.TabIndex = 118;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(275, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 115;
            this.label3.Text = "Roles Ingresados";
            // 
            // RolesListBox
            // 
            this.RolesListBox.DataSource = this.rolesBindingSource;
            this.RolesListBox.DisplayMember = "RoleName";
            this.RolesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RolesListBox.FormattingEnabled = true;
            this.RolesListBox.ItemHeight = 20;
            this.RolesListBox.Location = new System.Drawing.Point(258, 45);
            this.RolesListBox.Name = "RolesListBox";
            this.RolesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RolesListBox.Size = new System.Drawing.Size(169, 164);
            this.RolesListBox.TabIndex = 114;
            this.RolesListBox.ValueMember = "RoleID";
             // 
            // rolesBindingSource
            // 
            this.rolesBindingSource.DataMember = "Roles";
            this.rolesBindingSource.DataSource = this.controlSecurityDataSet1;
            // 
            // controlSecurityDataSet1
            // 
            this.controlSecurityDataSet1.DataSetName = "ControlSecurityDataSet";
            this.controlSecurityDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMsg.Location = new System.Drawing.Point(75, 223);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(64, 20);
            this.lblMsg.TabIndex = 113;
            this.lblMsg.Text = "Usuario";
            // 
            // NewUserName
            // 
            this.NewUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NewUserName.Location = new System.Drawing.Point(22, 246);
            this.NewUserName.Name = "NewUserName";
            this.NewUserName.Size = new System.Drawing.Size(169, 26);
            this.NewUserName.TabIndex = 111;
            // 
            // AddUsersToRole
            // 
            this.AddUsersToRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUsersToRole.Image = global::DBMETAL_SHARP.Properties.Resources.mail;
            this.AddUsersToRole.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddUsersToRole.Location = new System.Drawing.Point(476, 106);
            this.AddUsersToRole.Name = "AddUsersToRole";
            this.AddUsersToRole.Size = new System.Drawing.Size(106, 40);
            this.AddUsersToRole.TabIndex = 106;
            this.AddUsersToRole.Text = "Enviar Permiso";
            this.AddUsersToRole.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddUsersToRole.UseVisualStyleBackColor = true;
            this.AddUsersToRole.Click += new System.EventHandler(this.AddUsersToRole_Click);
            // 
            // AppUsersListBox
            // 
            this.AppUsersListBox.DataSource = this.usersBindingSource;
            this.AppUsersListBox.DisplayMember = "Name";
            this.AppUsersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AppUsersListBox.FormattingEnabled = true;
            this.AppUsersListBox.ItemHeight = 20;
            this.AppUsersListBox.Location = new System.Drawing.Point(22, 45);
            this.AppUsersListBox.Name = "AppUsersListBox";
            this.AppUsersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AppUsersListBox.Size = new System.Drawing.Size(169, 164);
            this.AppUsersListBox.TabIndex = 108;
            this.AppUsersListBox.ValueMember = "UserID";
            this.AppUsersListBox.SelectedIndexChanged += new System.EventHandler(this.AppUsersListBox_SelectedIndexChanged);
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.controlSecurityDataSet1;
            // 
            // rolesTableAdapter1
            // 
            this.rolesTableAdapter1.ClearBeforeFill = true;
            // 
            // usersTableAdapter1
            // 
            this.usersTableAdapter1.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 125;
            this.label2.Text = "Usuario Ingresados";
            // 
            // LblTitulos
            // 
            this.LblTitulos.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulos.Font = new System.Drawing.Font("Britannic Bold", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTitulos.Image = global::DBMETAL_SHARP.Properties.Resources.BarrasL;
            this.LblTitulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new System.Drawing.Point(-1, 2);
            this.LblTitulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new System.Drawing.Size(823, 72);
            this.LblTitulos.TabIndex = 126;
            this.LblTitulos.Text = "Administración Usuarios - Roles";
            this.LblTitulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbIdentificacion);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.botonEliminarUsuario);
            this.groupBox1.Controls.Add(this.botonEliminarRelUsuRol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.AppUsersListBox);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NewUserName);
            this.groupBox1.Controls.Add(this.rbRole);
            this.groupBox1.Controls.Add(this.RolesListBox);
            this.groupBox1.Controls.Add(this.rbName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.UsersInRoles);
            this.groupBox1.Controls.Add(this.AddUsersToRole);
            this.groupBox1.Controls.Add(this.RolesMessage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NewRoleName);
            this.groupBox1.Location = new System.Drawing.Point(8, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 392);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(52, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 133;
            this.label5.Text = "Identificación";
            // 
            // txbIdentificacion
            // 
            this.txbIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txbIdentificacion.Location = new System.Drawing.Point(22, 303);
            this.txbIdentificacion.Name = "txbIdentificacion";
            this.txbIdentificacion.Size = new System.Drawing.Size(169, 26);
            this.txbIdentificacion.TabIndex = 132;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::DBMETAL_SHARP.Properties.Resources.trash_16;
            this.button5.Location = new System.Drawing.Point(367, 280);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 48);
            this.button5.TabIndex = 131;
            this.button5.Text = "Eliminar";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // botonEliminarUsuario
            // 
            this.botonEliminarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEliminarUsuario.Image = global::DBMETAL_SHARP.Properties.Resources.trash_16;
            this.botonEliminarUsuario.Location = new System.Drawing.Point(131, 332);
            this.botonEliminarUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.botonEliminarUsuario.Name = "botonEliminarUsuario";
            this.botonEliminarUsuario.Size = new System.Drawing.Size(60, 48);
            this.botonEliminarUsuario.TabIndex = 130;
            this.botonEliminarUsuario.Text = "Eliminar";
            this.botonEliminarUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonEliminarUsuario.UseVisualStyleBackColor = true;
            this.botonEliminarUsuario.Click += new System.EventHandler(this.button4_Click);
            // 
            // botonEliminarRelUsuRol
            // 
            this.botonEliminarRelUsuRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEliminarRelUsuRol.Image = global::DBMETAL_SHARP.Properties.Resources.trash_16;
            this.botonEliminarRelUsuRol.Location = new System.Drawing.Point(672, 246);
            this.botonEliminarRelUsuRol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.botonEliminarRelUsuRol.Name = "botonEliminarRelUsuRol";
            this.botonEliminarRelUsuRol.Size = new System.Drawing.Size(60, 48);
            this.botonEliminarRelUsuRol.TabIndex = 129;
            this.botonEliminarRelUsuRol.Text = "Eliminar";
            this.botonEliminarRelUsuRol.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonEliminarRelUsuRol.UseVisualStyleBackColor = true;
            this.botonEliminarRelUsuRol.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(463, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 128;
            this.label1.Text = "Rol por Usuario";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.button1.Location = new System.Drawing.Point(258, 280);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 48);
            this.button1.TabIndex = 127;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddNewRole_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.btnGuardar.Location = new System.Drawing.Point(22, 332);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(60, 48);
            this.btnGuardar.TabIndex = 126;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.AddNewAppUser_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.button2.Location = new System.Drawing.Point(740, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 62);
            this.button2.TabIndex = 135;
            this.button2.Text = "Salir";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManageRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(831, 487);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblTitulos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageRoles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Roles";
            this.Load += new System.EventHandler(this.ManageRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlSecurityDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbRole;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView UsersInRoles;
        private System.Windows.Forms.Label RolesMessage;
        private System.Windows.Forms.TextBox NewRoleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox RolesListBox;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox NewUserName;
        private System.Windows.Forms.Button AddUsersToRole;
        private System.Windows.Forms.ListBox AppUsersListBox;
        //private ControlSecurityDataSet controlSecurityDataSet;
        private System.Windows.Forms.BindingSource rolesBindingSource;
        //private ControlBasedSecurity.ControlSecurityDataSetTableAdapters.RolesTableAdapter rolesTableAdapter;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private Liquidacion.DataSet.ControlSecurityDataSet controlSecurityDataSet1;
        private DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSetTableAdapters.RolesTableAdapter rolesTableAdapter1;
        private DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSetTableAdapters.UsersTableAdapter usersTableAdapter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTitulos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button botonEliminarRelUsuRol;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button botonEliminarUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbIdentificacion;
    }
}
namespace DBMETAL_SHARP.Liquidacion
{
    partial class ManagePermissions
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
            this.ByRoleRB = new System.Windows.Forms.RadioButton();
            this.ByControlRB = new System.Windows.Forms.RadioButton();
            this.PermissionTree = new System.Windows.Forms.TreeView();
            this.rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlSecurityDataSet1 = new DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSet();
            this.ControlPermissions = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PermissionRoles = new System.Windows.Forms.ListBox();
            this.Disabled = new System.Windows.Forms.CheckBox();
            this.InVisible = new System.Windows.Forms.CheckBox();
            this.PageControls = new System.Windows.Forms.ListBox();
            this.rolesTableAdapter1 = new DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSetTableAdapters.RolesTableAdapter();
            this.LblTitulos = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlSecurityDataSet1)).BeginInit();
            this.ControlPermissions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ByRoleRB
            // 
            this.ByRoleRB.AutoSize = true;
            this.ByRoleRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ByRoleRB.Location = new System.Drawing.Point(10, 41);
            this.ByRoleRB.Name = "ByRoleRB";
            this.ByRoleRB.Size = new System.Drawing.Size(51, 24);
            this.ByRoleRB.TabIndex = 64;
            this.ByRoleRB.Text = "Rol";
            this.ByRoleRB.UseVisualStyleBackColor = true;
            // 
            // ByControlRB
            // 
            this.ByControlRB.AutoSize = true;
            this.ByControlRB.Checked = true;
            this.ByControlRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ByControlRB.Location = new System.Drawing.Point(9, 11);
            this.ByControlRB.Name = "ByControlRB";
            this.ByControlRB.Size = new System.Drawing.Size(78, 24);
            this.ByControlRB.TabIndex = 63;
            this.ByControlRB.TabStop = true;
            this.ByControlRB.Text = "Control";
            this.ByControlRB.UseVisualStyleBackColor = true;
            this.ByControlRB.CheckedChanged += new System.EventHandler(this.ByControlRB_CheckedChanged);
            // 
            // PermissionTree
            // 
            this.PermissionTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PermissionTree.Location = new System.Drawing.Point(15, 19);
            this.PermissionTree.Name = "PermissionTree";
            this.PermissionTree.Size = new System.Drawing.Size(656, 243);
            this.PermissionTree.TabIndex = 61;
            this.PermissionTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PermissionTree_AfterSelect);
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
            // ControlPermissions
            // 
            this.ControlPermissions.Controls.Add(this.button3);
            this.ControlPermissions.Controls.Add(this.checkBox4);
            this.ControlPermissions.Controls.Add(this.checkBox2);
            this.ControlPermissions.Controls.Add(this.checkBox1);
            this.ControlPermissions.Controls.Add(this.button1);
            this.ControlPermissions.Controls.Add(this.PermissionRoles);
            this.ControlPermissions.Controls.Add(this.Disabled);
            this.ControlPermissions.Controls.Add(this.InVisible);
            this.ControlPermissions.Controls.Add(this.PageControls);
            this.ControlPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ControlPermissions.Location = new System.Drawing.Point(12, 162);
            this.ControlPermissions.Name = "ControlPermissions";
            this.ControlPermissions.Size = new System.Drawing.Size(847, 286);
            this.ControlPermissions.TabIndex = 60;
            this.ControlPermissions.TabStop = false;
            this.ControlPermissions.Text = "Permisos a control";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::DBMETAL_SHARP.Properties.Resources.Refresh_icon_Value;
            this.button3.Location = new System.Drawing.Point(753, 222);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 48);
            this.button3.TabIndex = 133;
            this.button3.Text = "Actualizar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(685, 119);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(109, 24);
            this.checkBox4.TabIndex = 132;
            this.checkBox4.Text = "Cont. Otros";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(685, 98);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(121, 24);
            this.checkBox2.TabIndex = 130;
            this.checkBox2.Text = "Cont. Zandor";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(685, 75);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(153, 24);
            this.checkBox1.TabIndex = 129;
            this.checkBox1.Text = "Cont. Peq Mineria";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.button1.Location = new System.Drawing.Point(685, 222);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 48);
            this.button1.TabIndex = 128;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Save_Click);
            // 
            // PermissionRoles
            // 
            this.PermissionRoles.DataSource = this.rolesBindingSource;
            this.PermissionRoles.DisplayMember = "RoleName";
            this.PermissionRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PermissionRoles.FormattingEnabled = true;
            this.PermissionRoles.ItemHeight = 20;
            this.PermissionRoles.Location = new System.Drawing.Point(410, 26);
            this.PermissionRoles.Name = "PermissionRoles";
            this.PermissionRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PermissionRoles.Size = new System.Drawing.Size(261, 244);
            this.PermissionRoles.TabIndex = 64;
            this.PermissionRoles.ValueMember = "RoleID";
            // 
            // Disabled
            // 
            this.Disabled.AutoSize = true;
            this.Disabled.Location = new System.Drawing.Point(685, 51);
            this.Disabled.Name = "Disabled";
            this.Disabled.Size = new System.Drawing.Size(112, 24);
            this.Disabled.TabIndex = 58;
            this.Disabled.Text = "Deshabilitar";
            this.Disabled.UseVisualStyleBackColor = true;
            // 
            // InVisible
            // 
            this.InVisible.AutoSize = true;
            this.InVisible.Location = new System.Drawing.Point(685, 26);
            this.InVisible.Name = "InVisible";
            this.InVisible.Size = new System.Drawing.Size(84, 24);
            this.InVisible.TabIndex = 57;
            this.InVisible.Text = "Invisible";
            this.InVisible.UseVisualStyleBackColor = true;
            // 
            // PageControls
            // 
            this.PageControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PageControls.FormattingEnabled = true;
            this.PageControls.ItemHeight = 20;
            this.PageControls.Location = new System.Drawing.Point(15, 26);
            this.PageControls.Name = "PageControls";
            this.PageControls.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PageControls.Size = new System.Drawing.Size(389, 244);
            this.PageControls.Sorted = true;
            this.PageControls.TabIndex = 56;
            // 
            // rolesTableAdapter1
            // 
            this.rolesTableAdapter1.ClearBeforeFill = true;
            // 
            // LblTitulos
            // 
            this.LblTitulos.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulos.Font = new System.Drawing.Font("Britannic Bold", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTitulos.Image = global::DBMETAL_SHARP.Properties.Resources.BarrasL;
            this.LblTitulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new System.Drawing.Point(-1, 1);
            this.LblTitulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new System.Drawing.Size(860, 72);
            this.LblTitulos.TabIndex = 127;
            this.LblTitulos.Text = "Administración Permisos - Roles";
            this.LblTitulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PermissionTree);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 273);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permisos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ByControlRB);
            this.groupBox2.Controls.Add(this.ByRoleRB);
            this.groupBox2.Location = new System.Drawing.Point(720, 456);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 75);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordnenar";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 28);
            this.comboBox1.TabIndex = 129;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 20);
            this.label1.TabIndex = 130;
            this.label1.Text = "Cargue formulario para asirgnar permisos";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.button2.Location = new System.Drawing.Point(777, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 62);
            this.button2.TabIndex = 134;
            this.button2.Text = "Salir";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManagePermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(871, 726);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblTitulos);
            this.Controls.Add(this.ControlPermissions);
            this.MaximizeBox = false;
            this.Name = "ManagePermissions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Permisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagePermissions_FormClosing);
            this.Load += new System.EventHandler(this.ManagePermissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlSecurityDataSet1)).EndInit();
            this.ControlPermissions.ResumeLayout(false);
            this.ControlPermissions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton ByRoleRB;
        private System.Windows.Forms.RadioButton ByControlRB;
        private System.Windows.Forms.TreeView PermissionTree;
        private System.Windows.Forms.GroupBox ControlPermissions;
        private System.Windows.Forms.CheckBox Disabled;
        private System.Windows.Forms.CheckBox InVisible;
        private System.Windows.Forms.ListBox PageControls;
        private Liquidacion.DataSet.ControlSecurityDataSet controlSecurityDataSet1;
        private System.Windows.Forms.BindingSource rolesBindingSource;
        private DBMETAL_SHARP.Liquidacion.DataSet.ControlSecurityDataSetTableAdapters.RolesTableAdapter rolesTableAdapter1;
        private System.Windows.Forms.ListBox PermissionRoles;
        private System.Windows.Forms.Label LblTitulos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
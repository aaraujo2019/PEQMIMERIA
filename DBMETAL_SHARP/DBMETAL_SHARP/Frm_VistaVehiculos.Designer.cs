namespace DBMETAL_SHARP
{
    partial class Frm_VistaVehiculos
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
            this.TxbPlaca = new System.Windows.Forms.MaskedTextBox();
            this.ChbEstado = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.TxbDetalle = new System.Windows.Forms.TextBox();
            this.ptbVehiculo = new System.Windows.Forms.PictureBox();
            this.label41 = new System.Windows.Forms.Label();
            this.CmbTipoVehiculo1 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.TxbLicencia = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.TxbMotor1 = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.TxbCapacidad1 = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.TxbNombrePropietario1 = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.TxbClase1 = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.TxbCilindraje1 = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.TxbCombustible1 = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.TxbModelo1 = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.TxbMarca1 = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVehiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // TxbPlaca
            // 
            this.TxbPlaca.BackColor = System.Drawing.Color.White;
            this.TxbPlaca.Enabled = false;
            this.TxbPlaca.Location = new System.Drawing.Point(76, 15);
            this.TxbPlaca.Mask = ">LLL-000";
            this.TxbPlaca.Name = "TxbPlaca";
            this.TxbPlaca.Size = new System.Drawing.Size(120, 20);
            this.TxbPlaca.TabIndex = 74;
            // 
            // ChbEstado
            // 
            this.ChbEstado.AutoSize = true;
            this.ChbEstado.Enabled = false;
            this.ChbEstado.Location = new System.Drawing.Point(12, 0);
            this.ChbEstado.Name = "ChbEstado";
            this.ChbEstado.Size = new System.Drawing.Size(59, 17);
            this.ChbEstado.TabIndex = 3;
            this.ChbEstado.Text = "Estado";
            this.ChbEstado.UseVisualStyleBackColor = true;
            this.ChbEstado.CheckedChanged += new System.EventHandler(this.ChbEstado_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Placa";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.TxbDetalle);
            this.groupBox10.Controls.Add(this.ChbEstado);
            this.groupBox10.Controls.Add(this.TxbPlaca);
            this.groupBox10.Controls.Add(this.ptbVehiculo);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.CmbTipoVehiculo1);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Controls.Add(this.label30);
            this.groupBox10.Controls.Add(this.TxbLicencia);
            this.groupBox10.Controls.Add(this.label86);
            this.groupBox10.Controls.Add(this.TxbMotor1);
            this.groupBox10.Controls.Add(this.label88);
            this.groupBox10.Controls.Add(this.TxbCapacidad1);
            this.groupBox10.Controls.Add(this.label89);
            this.groupBox10.Controls.Add(this.TxbNombrePropietario1);
            this.groupBox10.Controls.Add(this.label91);
            this.groupBox10.Controls.Add(this.TxbClase1);
            this.groupBox10.Controls.Add(this.label94);
            this.groupBox10.Controls.Add(this.TxbCilindraje1);
            this.groupBox10.Controls.Add(this.label96);
            this.groupBox10.Controls.Add(this.TxbCombustible1);
            this.groupBox10.Controls.Add(this.label97);
            this.groupBox10.Controls.Add(this.TxbModelo1);
            this.groupBox10.Controls.Add(this.label98);
            this.groupBox10.Controls.Add(this.TxbMarca1);
            this.groupBox10.Location = new System.Drawing.Point(12, 48);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(582, 192);
            this.groupBox10.TabIndex = 83;
            this.groupBox10.TabStop = false;
            // 
            // TxbDetalle
            // 
            this.TxbDetalle.BackColor = System.Drawing.Color.White;
            this.TxbDetalle.Enabled = false;
            this.TxbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbDetalle.Location = new System.Drawing.Point(77, 164);
            this.TxbDetalle.Name = "TxbDetalle";
            this.TxbDetalle.Size = new System.Drawing.Size(294, 20);
            this.TxbDetalle.TabIndex = 85;
            // 
            // ptbVehiculo
            // 
            this.ptbVehiculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbVehiculo.Image = global::DBMETAL_SHARP.Properties.Resources.Volqueta;
            this.ptbVehiculo.Location = new System.Drawing.Point(381, 15);
            this.ptbVehiculo.Name = "ptbVehiculo";
            this.ptbVehiculo.Size = new System.Drawing.Size(196, 173);
            this.ptbVehiculo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbVehiculo.TabIndex = 84;
            this.ptbVehiculo.TabStop = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(31, 167);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(40, 13);
            this.label41.TabIndex = 75;
            this.label41.Text = "Detalle";
            // 
            // CmbTipoVehiculo1
            // 
            this.CmbTipoVehiculo1.BackColor = System.Drawing.Color.White;
            this.CmbTipoVehiculo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoVehiculo1.Enabled = false;
            this.CmbTipoVehiculo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipoVehiculo1.FormattingEnabled = true;
            this.CmbTipoVehiculo1.Items.AddRange(new object[] {
            "Propio",
            "Tercero",
            "Mixto"});
            this.CmbTipoVehiculo1.Location = new System.Drawing.Point(251, 92);
            this.CmbTipoVehiculo1.Name = "CmbTipoVehiculo1";
            this.CmbTipoVehiculo1.Size = new System.Drawing.Size(120, 21);
            this.CmbTipoVehiculo1.TabIndex = 19;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(202, 88);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 26);
            this.label27.TabIndex = 74;
            this.label27.Text = "Tipo\r\nVehiculo\r\n";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(202, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Licencia";
            // 
            // TxbLicencia
            // 
            this.TxbLicencia.BackColor = System.Drawing.Color.White;
            this.TxbLicencia.Enabled = false;
            this.TxbLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbLicencia.Location = new System.Drawing.Point(251, 15);
            this.TxbLicencia.Name = "TxbLicencia";
            this.TxbLicencia.Size = new System.Drawing.Size(120, 20);
            this.TxbLicencia.TabIndex = 0;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(202, 144);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(34, 13);
            this.label86.TabIndex = 37;
            this.label86.Text = "Motor";
            // 
            // TxbMotor1
            // 
            this.TxbMotor1.BackColor = System.Drawing.Color.White;
            this.TxbMotor1.Enabled = false;
            this.TxbMotor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbMotor1.Location = new System.Drawing.Point(251, 140);
            this.TxbMotor1.Name = "TxbMotor1";
            this.TxbMotor1.Size = new System.Drawing.Size(120, 20);
            this.TxbMotor1.TabIndex = 11;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(21, 143);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(50, 13);
            this.label88.TabIndex = 35;
            this.label88.Text = "Peso Kg.";
            // 
            // TxbCapacidad1
            // 
            this.TxbCapacidad1.BackColor = System.Drawing.Color.White;
            this.TxbCapacidad1.Enabled = false;
            this.TxbCapacidad1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbCapacidad1.Location = new System.Drawing.Point(76, 140);
            this.TxbCapacidad1.Name = "TxbCapacidad1";
            this.TxbCapacidad1.Size = new System.Drawing.Size(120, 21);
            this.TxbCapacidad1.TabIndex = 5;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(14, 46);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(57, 13);
            this.label89.TabIndex = 29;
            this.label89.Text = "Propietario";
            // 
            // TxbNombrePropietario1
            // 
            this.TxbNombrePropietario1.BackColor = System.Drawing.Color.White;
            this.TxbNombrePropietario1.Enabled = false;
            this.TxbNombrePropietario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbNombrePropietario1.Location = new System.Drawing.Point(76, 42);
            this.TxbNombrePropietario1.Name = "TxbNombrePropietario1";
            this.TxbNombrePropietario1.Size = new System.Drawing.Size(295, 20);
            this.TxbNombrePropietario1.TabIndex = 28;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(202, 118);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(33, 13);
            this.label91.TabIndex = 23;
            this.label91.Text = "Clase";
            // 
            // TxbClase1
            // 
            this.TxbClase1.BackColor = System.Drawing.Color.White;
            this.TxbClase1.Enabled = false;
            this.TxbClase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbClase1.Location = new System.Drawing.Point(251, 116);
            this.TxbClase1.Name = "TxbClase1";
            this.TxbClase1.Size = new System.Drawing.Size(120, 20);
            this.TxbClase1.TabIndex = 10;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(22, 90);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(49, 13);
            this.label94.TabIndex = 17;
            this.label94.Text = "Cilindraje";
            // 
            // TxbCilindraje1
            // 
            this.TxbCilindraje1.BackColor = System.Drawing.Color.White;
            this.TxbCilindraje1.Enabled = false;
            this.TxbCilindraje1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbCilindraje1.Location = new System.Drawing.Point(76, 90);
            this.TxbCilindraje1.Name = "TxbCilindraje1";
            this.TxbCilindraje1.Size = new System.Drawing.Size(120, 20);
            this.TxbCilindraje1.TabIndex = 9;
            // 
            // label96
            // 
            this.label96.Location = new System.Drawing.Point(7, 119);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(64, 13);
            this.label96.TabIndex = 7;
            this.label96.Text = "Combustible";
            // 
            // TxbCombustible1
            // 
            this.TxbCombustible1.BackColor = System.Drawing.Color.White;
            this.TxbCombustible1.Enabled = false;
            this.TxbCombustible1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbCombustible1.Location = new System.Drawing.Point(76, 116);
            this.TxbCombustible1.Name = "TxbCombustible1";
            this.TxbCombustible1.Size = new System.Drawing.Size(120, 20);
            this.TxbCombustible1.TabIndex = 4;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(29, 71);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(42, 13);
            this.label97.TabIndex = 5;
            this.label97.Text = "Modelo";
            // 
            // TxbModelo1
            // 
            this.TxbModelo1.BackColor = System.Drawing.Color.White;
            this.TxbModelo1.Enabled = false;
            this.TxbModelo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbModelo1.Location = new System.Drawing.Point(76, 68);
            this.TxbModelo1.Name = "TxbModelo1";
            this.TxbModelo1.Size = new System.Drawing.Size(120, 20);
            this.TxbModelo1.TabIndex = 2;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(202, 70);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(37, 13);
            this.label98.TabIndex = 3;
            this.label98.Text = "Marca";
            // 
            // TxbMarca1
            // 
            this.TxbMarca1.BackColor = System.Drawing.Color.White;
            this.TxbMarca1.Enabled = false;
            this.TxbMarca1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbMarca1.Location = new System.Drawing.Point(251, 66);
            this.TxbMarca1.Name = "TxbMarca1";
            this.TxbMarca1.Size = new System.Drawing.Size(120, 20);
            this.TxbMarca1.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(519, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 40);
            this.btnExit.TabIndex = 85;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Agency FB", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Image = global::DBMETAL_SHARP.Properties.Resources.Ondadegradada;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 45);
            this.label1.TabIndex = 86;
            this.label1.Text = "Ficha Vehiculo - Bascula";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_VistaVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(605, 247);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_VistaVehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista Vehiculos";
            this.Load += new System.EventHandler(this.Frm_VistaVehiculos_Load);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVehiculo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox TxbPlaca;
        private System.Windows.Forms.CheckBox ChbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptbVehiculo;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox CmbTipoVehiculo1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox TxbLicencia;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox TxbMotor1;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.TextBox TxbCapacidad1;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.TextBox TxbNombrePropietario1;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox TxbClase1;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.TextBox TxbCilindraje1;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.TextBox TxbCombustible1;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TextBox TxbModelo1;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.TextBox TxbMarca1;
        private System.Windows.Forms.TextBox TxbDetalle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
    }
}
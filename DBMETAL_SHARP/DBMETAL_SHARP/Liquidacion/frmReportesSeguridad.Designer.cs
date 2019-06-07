namespace DBMETAL_SHARP.Liquidacion
{
    partial class frmReportesSeguridad
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCargaUsuario = new System.Windows.Forms.ComboBox();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LblTitulos = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboCargaUsuario);
            this.groupBox2.Controls.Add(this.BtnImprimir);
            this.groupBox2.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(8, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 87);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos por usuario";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(381, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 18);
            this.checkBox1.TabIndex = 133;
            this.checkBox1.Text = "Agrupar Nombre";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 130;
            this.label3.Text = "Usuario";
            // 
            // cboCargaUsuario
            // 
            this.cboCargaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.cboCargaUsuario.FormattingEnabled = true;
            this.cboCargaUsuario.Location = new System.Drawing.Point(88, 36);
            this.cboCargaUsuario.Name = "cboCargaUsuario";
            this.cboCargaUsuario.Size = new System.Drawing.Size(276, 39);
            this.cboCargaUsuario.TabIndex = 131;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnImprimir.Image = global::DBMETAL_SHARP.Properties.Resources.printer_setup;
            this.BtnImprimir.Location = new System.Drawing.Point(707, 12);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(96, 63);
            this.BtnImprimir.TabIndex = 132;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.button1.Location = new System.Drawing.Point(741, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 62);
            this.button1.TabIndex = 134;
            this.button1.Text = "Salir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblTitulos
            // 
            this.LblTitulos.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulos.Font = new System.Drawing.Font("Britannic Bold", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTitulos.Image = global::DBMETAL_SHARP.Properties.Resources.BarrasL1;
            this.LblTitulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new System.Drawing.Point(-2, -2);
            this.LblTitulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new System.Drawing.Size(823, 72);
            this.LblTitulos.TabIndex = 128;
            this.LblTitulos.Text = "Administrador Reportes Permisos";
            this.LblTitulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReportesSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 218);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LblTitulos);
            this.Name = "frmReportesSeguridad";
            this.Text = "frmReportesSeguridad";
            this.Load += new System.EventHandler(this.frmReportesSeguridad_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCargaUsuario;
        private System.Windows.Forms.Button BtnImprimir;
    }
}
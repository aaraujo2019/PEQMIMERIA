namespace DBMETAL_SHARP
{
    partial class Frm_CargaAnalisis
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmdExaminar = new System.Windows.Forms.Button();
            this.Txtruta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtgExcel = new System.Windows.Forms.DataGridView();
            this.LblTitulos = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmdExaminar);
            this.groupBox1.Controls.Add(this.Txtruta);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(6, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1069, 102);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            // 
            // CmdExaminar
            // 
            this.CmdExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CmdExaminar.Location = new System.Drawing.Point(944, 40);
            this.CmdExaminar.Name = "CmdExaminar";
            this.CmdExaminar.Size = new System.Drawing.Size(113, 36);
            this.CmdExaminar.TabIndex = 112;
            this.CmdExaminar.Text = "Cargar";
            this.CmdExaminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CmdExaminar.UseVisualStyleBackColor = true;
            this.CmdExaminar.Click += new System.EventHandler(this.CmdExaminar_Click);
            // 
            // Txtruta
            // 
            this.Txtruta.Enabled = false;
            this.Txtruta.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtruta.Location = new System.Drawing.Point(7, 42);
            this.Txtruta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Txtruta.Name = "Txtruta";
            this.Txtruta.Size = new System.Drawing.Size(920, 36);
            this.Txtruta.TabIndex = 110;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 14);
            this.label11.TabIndex = 109;
            this.label11.Text = "Selección Archivo a cargar";
            // 
            // dtgExcel
            // 
            this.dtgExcel.AllowUserToAddRows = false;
            this.dtgExcel.AllowUserToDeleteRows = false;
            this.dtgExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExcel.Location = new System.Drawing.Point(2, 182);
            this.dtgExcel.Name = "dtgExcel";
            this.dtgExcel.ReadOnly = true;
            this.dtgExcel.Size = new System.Drawing.Size(1073, 503);
            this.dtgExcel.TabIndex = 12;
            // 
            // LblTitulos
            // 
            this.LblTitulos.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulos.Font = new System.Drawing.Font("Britannic Bold", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTitulos.Image = global::DBMETAL_SHARP.Properties.Resources.BarrasL;
            this.LblTitulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new System.Drawing.Point(-1, -2);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new System.Drawing.Size(1076, 72);
            this.LblTitulos.TabIndex = 114;
            this.LblTitulos.Text = "Ingreso de Análisis ";
            this.LblTitulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(1147, 14);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 62);
            this.btnExit.TabIndex = 113;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Frm_CargaAnalisis
            // 
            this.AcceptButton = this.CmdExaminar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1087, 697);
            this.Controls.Add(this.LblTitulos);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dtgExcel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CargaAnalisis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga Analisis";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txtruta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button CmdExaminar;
        private System.Windows.Forms.DataGridView dtgExcel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label LblTitulos;
    }
}
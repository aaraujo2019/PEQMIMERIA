namespace DBMETAL_SHARP
{
    partial class Frm_TenorZandor
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
            this.chbMarcar = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TxbConsecutivo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.TxbPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.StStrip = new System.Windows.Forms.StatusStrip();
            this.StsLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StsProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.StStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbMarcar);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.TxbConsecutivo);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.TxbPath);
            this.groupBox2.Controls.Add(this.btnPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 331);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuracion";
            // 
            // chbMarcar
            // 
            this.chbMarcar.AutoSize = true;
            this.chbMarcar.Location = new System.Drawing.Point(17, 65);
            this.chbMarcar.Name = "chbMarcar";
            this.chbMarcar.Size = new System.Drawing.Size(83, 17);
            this.chbMarcar.TabIndex = 2;
            this.chbMarcar.Text = "Marcar todo";
            this.chbMarcar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            this.dataGridView1.Location = new System.Drawing.Point(17, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 11;
            this.dataGridView1.Size = new System.Drawing.Size(371, 232);
            this.dataGridView1.TabIndex = 5;
            // 
            // Check
            // 
            this.Check.HeaderText = "Incluir";
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            // 
            // TxbConsecutivo
            // 
            this.TxbConsecutivo.Location = new System.Drawing.Point(17, 19);
            this.TxbConsecutivo.Name = "TxbConsecutivo";
            this.TxbConsecutivo.Size = new System.Drawing.Size(86, 20);
            this.TxbConsecutivo.TabIndex = 0;
            this.TxbConsecutivo.Leave += new System.EventHandler(this.TxbConsecutivo_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::DBMETAL_SHARP.Properties.Resources.srch_16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(104, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 22);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // TxbPath
            // 
            this.TxbPath.Enabled = false;
            this.TxbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbPath.Location = new System.Drawing.Point(17, 41);
            this.TxbPath.Name = "TxbPath";
            this.TxbPath.Size = new System.Drawing.Size(243, 20);
            this.TxbPath.TabIndex = 1;
            // 
            // btnPath
            // 
            this.btnPath.Image = global::DBMETAL_SHARP.Properties.Resources.impt_16;
            this.btnPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPath.Location = new System.Drawing.Point(260, 40);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(128, 22);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "Seleccionar Archivo";
            this.btnPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Britannic Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Image = global::DBMETAL_SHARP.Properties.Resources.Ondadegradada;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(-1, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(837, 45);
            this.label2.TabIndex = 62;
            this.label2.Text = " Reporte de Tenor Zandor (Excel- Formato Especial)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // StStrip
            // 
            this.StStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StsLabel1,
            this.StsProgressBar1});
            this.StStrip.Location = new System.Drawing.Point(0, 389);
            this.StStrip.Name = "StStrip";
            this.StStrip.Size = new System.Drawing.Size(830, 22);
            this.StStrip.TabIndex = 64;
            this.StStrip.Text = "statusStrip1";
            // 
            // StsLabel1
            // 
            this.StsLabel1.Name = "StsLabel1";
            this.StsLabel1.Size = new System.Drawing.Size(118, 17);
            this.StsLabel1.Text = "toolStripStatusLabel1";
            // 
            // StsProgressBar1
            // 
            this.StsProgressBar1.Name = "StsProgressBar1";
            this.StsProgressBar1.Size = new System.Drawing.Size(280, 16);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(416, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 156);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sellos que seran Actualizados";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 11;
            this.dataGridView2.Size = new System.Drawing.Size(371, 107);
            this.dataGridView2.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Location = new System.Drawing.Point(420, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 156);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sellos NO Encontrados";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 19);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 11;
            this.dataGridView3.Size = new System.Drawing.Size(371, 107);
            this.dataGridView3.TabIndex = 5;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::DBMETAL_SHARP.Properties.Resources.excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(478, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(58, 40);
            this.btnExcel.TabIndex = 65;
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::DBMETAL_SHARP.Properties.Resources.apps_16;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcesar.Location = new System.Drawing.Point(594, 2);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(58, 40);
            this.btnProcesar.TabIndex = 56;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::DBMETAL_SHARP.Properties.Resources.new_16;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(651, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(58, 40);
            this.btnNuevo.TabIndex = 58;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::DBMETAL_SHARP.Properties.Resources.trash_16;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(536, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 40);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(765, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 40);
            this.btnExit.TabIndex = 60;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(708, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 40);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Frm_TenorZandor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(830, 411);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StStrip);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_TenorZandor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DBMETAL - TenorZandor";
            this.Load += new System.EventHandler(this.Frm_TenorZandor_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.StStrip.ResumeLayout(false);
            this.StStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbMarcar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.TextBox TxbConsecutivo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox TxbPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip StStrip;
        private System.Windows.Forms.ToolStripStatusLabel StsLabel1;
        private System.Windows.Forms.ToolStripProgressBar StsProgressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btnExcel;
    }
}
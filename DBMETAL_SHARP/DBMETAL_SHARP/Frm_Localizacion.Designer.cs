namespace DBMETAL_SHARP
{
    partial class Frm_Localizacion
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChbEstado = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxbNombre = new System.Windows.Forms.TextBox();
            this.TxbIdentificacion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.lblDetail = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::DBMETAL_SHARP.Properties.Resources.trash_full;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(357, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 40);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(519, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(465, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::DBMETAL_SHARP.Properties.Resources.new_16;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(411, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Nuevo";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Image = global::DBMETAL_SHARP.Properties.Resources.Ondadegradada;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 40);
            this.label1.TabIndex = 108;
            this.label1.Text = " Localización";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(558, 182);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Localización";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDetail);
            this.groupBox2.Controls.Add(this.lblDetail);
            this.groupBox2.Controls.Add(this.ChbEstado);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.TxbNombre);
            this.groupBox2.Controls.Add(this.TxbIdentificacion);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 171);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // ChbEstado
            // 
            this.ChbEstado.AutoSize = true;
            this.ChbEstado.Location = new System.Drawing.Point(6, 0);
            this.ChbEstado.Name = "ChbEstado";
            this.ChbEstado.Size = new System.Drawing.Size(59, 17);
            this.ChbEstado.TabIndex = 109;
            this.ChbEstado.Text = "Estado";
            this.ChbEstado.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::DBMETAL_SHARP.Properties.Resources.srch_16;
            this.button1.Location = new System.Drawing.Point(268, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 107;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxbNombre
            // 
            this.TxbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TxbNombre.ForeColor = System.Drawing.Color.Navy;
            this.TxbNombre.Location = new System.Drawing.Point(64, 41);
            this.TxbNombre.Multiline = true;
            this.TxbNombre.Name = "TxbNombre";
            this.TxbNombre.Size = new System.Drawing.Size(468, 20);
            this.TxbNombre.TabIndex = 106;
            // 
            // TxbIdentificacion
            // 
            this.TxbIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TxbIdentificacion.ForeColor = System.Drawing.Color.Navy;
            this.TxbIdentificacion.Location = new System.Drawing.Point(65, 16);
            this.TxbIdentificacion.Multiline = true;
            this.TxbIdentificacion.Name = "TxbIdentificacion";
            this.TxbIdentificacion.Size = new System.Drawing.Size(201, 20);
            this.TxbIdentificacion.TabIndex = 0;
            this.TxbIdentificacion.Text = "33333";
            this.TxbIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbIdentificacion_KeyPress);
            this.TxbIdentificacion.Leave += new System.EventHandler(this.TxbIdentificacion_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(19, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Código";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(14, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Nombre";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(10, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(566, 208);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // txtDetail
            // 
            this.txtDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDetail.ForeColor = System.Drawing.Color.Navy;
            this.txtDetail.Location = new System.Drawing.Point(64, 69);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(468, 95);
            this.txtDetail.TabIndex = 111;
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDetail.ForeColor = System.Drawing.Color.Navy;
            this.lblDetail.Location = new System.Drawing.Point(14, 76);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(40, 13);
            this.lblDetail.TabIndex = 110;
            this.lblDetail.Text = "Detalle";
            // 
            // Frm_Localizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(580, 258);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Frm_Localizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal de Muestreo";
            this.Load += new System.EventHandler(this.Frm_PersonalMuestreo_Load);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxbIdentificacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox TxbNombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ChbEstado;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label lblDetail;
    }
}
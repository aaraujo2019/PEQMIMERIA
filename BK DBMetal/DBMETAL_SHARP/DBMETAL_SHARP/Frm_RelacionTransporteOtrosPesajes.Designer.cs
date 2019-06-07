namespace DBMETAL_SHARP
{
    partial class Frm_RelacionTransporteOtrosPesajes
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TxbNombreTipo = new System.Windows.Forms.TextBox();
            this.TxbTipo = new System.Windows.Forms.TextBox();
            this.TxbOrigen = new System.Windows.Forms.TextBox();
            this.label152 = new System.Windows.Forms.Label();
            this.TxbNombreOrigen = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TreeDestinos = new System.Windows.Forms.TreeView();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::DBMETAL_SHARP.Properties.Resources.new_16;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(281, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(58, 40);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(395, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(58, 40);
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
            this.btnSave.Location = new System.Drawing.Point(338, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Image = global::DBMETAL_SHARP.Properties.Resources.Ondadegradada;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 45);
            this.label1.TabIndex = 86;
            this.label1.Text = "Rutas otros pesajes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TxbNombreTipo);
            this.groupBox6.Controls.Add(this.TxbTipo);
            this.groupBox6.Controls.Add(this.TxbOrigen);
            this.groupBox6.Controls.Add(this.label152);
            this.groupBox6.Controls.Add(this.TxbNombreOrigen);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.btnBuscar);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(18, 51);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(425, 65);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // TxbNombreTipo
            // 
            this.TxbNombreTipo.BackColor = System.Drawing.Color.White;
            this.TxbNombreTipo.Enabled = false;
            this.TxbNombreTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbNombreTipo.ForeColor = System.Drawing.Color.Navy;
            this.TxbNombreTipo.Location = new System.Drawing.Point(163, 16);
            this.TxbNombreTipo.Name = "TxbNombreTipo";
            this.TxbNombreTipo.Size = new System.Drawing.Size(255, 20);
            this.TxbNombreTipo.TabIndex = 83;
            // 
            // TxbTipo
            // 
            this.TxbTipo.BackColor = System.Drawing.Color.White;
            this.TxbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbTipo.ForeColor = System.Drawing.Color.Navy;
            this.TxbTipo.Location = new System.Drawing.Point(53, 16);
            this.TxbTipo.Name = "TxbTipo";
            this.TxbTipo.Size = new System.Drawing.Size(83, 21);
            this.TxbTipo.TabIndex = 0;
            this.TxbTipo.Leave += new System.EventHandler(this.TxbTipo_Leave);
            // 
            // TxbOrigen
            // 
            this.TxbOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbOrigen.ForeColor = System.Drawing.Color.Navy;
            this.TxbOrigen.Location = new System.Drawing.Point(53, 39);
            this.TxbOrigen.Name = "TxbOrigen";
            this.TxbOrigen.Size = new System.Drawing.Size(83, 20);
            this.TxbOrigen.TabIndex = 1;
            this.TxbOrigen.Leave += new System.EventHandler(this.TxbOrigen_Leave);
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(5, 44);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(38, 13);
            this.label152.TabIndex = 81;
            this.label152.Text = "Origen";
            // 
            // TxbNombreOrigen
            // 
            this.TxbNombreOrigen.BackColor = System.Drawing.Color.White;
            this.TxbNombreOrigen.Enabled = false;
            this.TxbNombreOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbNombreOrigen.ForeColor = System.Drawing.Color.Navy;
            this.TxbNombreOrigen.Location = new System.Drawing.Point(163, 39);
            this.TxbNombreOrigen.Name = "TxbNombreOrigen";
            this.TxbNombreOrigen.Size = new System.Drawing.Size(255, 20);
            this.TxbNombreOrigen.TabIndex = 80;
            // 
            // button2
            // 
            this.button2.Image = global::DBMETAL_SHARP.Properties.Resources.srch_16;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(137, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 22);
            this.button2.TabIndex = 82;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::DBMETAL_SHARP.Properties.Resources.srch_16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(137, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(24, 22);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TreeDestinos);
            this.groupBox1.Location = new System.Drawing.Point(18, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 237);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destinos unicos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TreeDestinos
            // 
            this.TreeDestinos.CheckBoxes = true;
            this.TreeDestinos.Location = new System.Drawing.Point(8, 19);
            this.TreeDestinos.Name = "TreeDestinos";
            this.TreeDestinos.Size = new System.Drawing.Size(410, 212);
            this.TreeDestinos.TabIndex = 0;
            // 
            // Frm_RelacionTransporteOtrosPesajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(459, 371);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_RelacionTransporteOtrosPesajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BASCULA - Relacion de Tipos - Origenes - Destinos";
            this.Load += new System.EventHandler(this.Frm_RelacionTransporteOtrosPesajes_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox TxbNombreTipo;
        private System.Windows.Forms.TextBox TxbTipo;
        private System.Windows.Forms.TextBox TxbOrigen;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.TextBox TxbNombreOrigen;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView TreeDestinos;
    }
}
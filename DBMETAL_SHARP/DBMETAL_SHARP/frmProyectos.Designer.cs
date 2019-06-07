using DBMETAL_SHARP.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    partial class frmProyectos
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAnalisis = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbPlaza = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CmbPlaza);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDescripcion);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtAnalisis);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtCodigo);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(14, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 141);
            this.groupBox2.TabIndex = 102;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::DBMETAL_SHARP.Properties.Resources.srch_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(250, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 40;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::DBMETAL_SHARP.Properties.Resources.trash_full;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(346, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 40);
            this.btnDelete.TabIndex = 101;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(509, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 40);
            this.btnExit.TabIndex = 100;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(455, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.TabIndex = 98;
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::DBMETAL_SHARP.Properties.Resources.new_16;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(401, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.TabIndex = 99;
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
            this.label1.Location = new System.Drawing.Point(-1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 40);
            this.label1.TabIndex = 97;
            this.label1.Text = "Protectos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtCodigo.ForeColor = Color.Navy;
            this.txtCodigo.Location = new Point(84, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new Size(166, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.ForeColor = Color.Navy;
            this.label11.Location = new Point(12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new Size(40, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Código";
            // 
            // txtAnalisis
            // 
            this.txtAnalisis.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtAnalisis.ForeColor = Color.Navy;
            this.txtAnalisis.Location = new Point(83, 105);
            this.txtAnalisis.Name = "txtAnalisis";
            this.txtAnalisis.Size = new Size(146, 20);
            this.txtAnalisis.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label8.ForeColor = Color.Navy;
            this.label8.Location = new Point(12, 110);
            this.label8.Name = "label8";
            this.label8.Size = new Size(42, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Análisis";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtDescripcion.ForeColor = Color.Navy;
            this.txtDescripcion.Location = new Point(84, 76);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(448, 20);
            this.txtDescripcion.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = Color.Navy;
            this.label5.Location = new Point(11, 79);
            this.label5.Name = "label5";
            this.label5.Size = new Size(63, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descripción";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtNombre.ForeColor = Color.Navy;
            this.txtNombre.Location = new Point(84, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(448, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label10.ForeColor = Color.Navy;
            this.label10.Location = new Point(12, 50);
            this.label10.Name = "label10";
            this.label10.Size = new Size(44, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Nombre";
            // 
            // CmbPlaza
            // 
            this.CmbPlaza.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbPlaza.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CmbPlaza.FormattingEnabled = true;
            this.CmbPlaza.Location = new Point(340, 15);
            this.CmbPlaza.Name = "CmbPlaza";
            this.CmbPlaza.Size = new Size(192, 21);
            this.CmbPlaza.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.Navy;
            this.label2.Location = new Point(301, 20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(33, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Plaza";
            // 
            // frmProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(577, 201);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "frmProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBMETAL BASCULA - Proyectos";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private Button button1;
        private Label label2;
        private ComboBox CmbPlaza;
        private Label label10;
        private TextBox txtNombre;
        private Label label5;
        private TextBox txtDescripcion;
        private Label label8;
        private TextBox txtAnalisis;
        private Label label11;
        private TextBox txtCodigo;
    }
}
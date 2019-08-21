using DBMETAL_SHARP.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    partial class frmFiltroReporte
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
            this.dtpEventEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpEventInitial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProyecto = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.LblTitulos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEventEnd);
            this.groupBox1.Controls.Add(this.dtpEventInitial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(11, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 72);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            // 
            // dtpEventEnd
            // 
            this.dtpEventEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventEnd.CalendarForeColor = System.Drawing.Color.Transparent;
            this.dtpEventEnd.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtpEventEnd.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dtpEventEnd.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dtpEventEnd.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dtpEventEnd.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventEnd.Location = new System.Drawing.Point(466, 26);
            this.dtpEventEnd.Name = "dtpEventEnd";
            this.dtpEventEnd.Size = new System.Drawing.Size(164, 30);
            this.dtpEventEnd.TabIndex = 110;
            this.dtpEventEnd.Value = new System.DateTime(2018, 5, 31, 0, 0, 0, 0);
            // 
            // dtpEventInitial
            // 
            this.dtpEventInitial.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventInitial.CalendarForeColor = System.Drawing.Color.Transparent;
            this.dtpEventInitial.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dtpEventInitial.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dtpEventInitial.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dtpEventInitial.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dtpEventInitial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventInitial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventInitial.Location = new System.Drawing.Point(141, 26);
            this.dtpEventInitial.Name = "dtpEventInitial";
            this.dtpEventInitial.Size = new System.Drawing.Size(161, 30);
            this.dtpEventInitial.TabIndex = 107;
            this.dtpEventInitial.Value = new System.DateTime(2018, 5, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 34);
            this.label2.TabIndex = 111;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 34);
            this.label1.TabIndex = 108;
            this.label1.Text = "Fecha inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(18, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 130;
            this.label3.Text = "Proyecto";
            // 
            // cmbProyecto
            // 
            this.cmbProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProyecto.FormattingEnabled = true;
            this.cmbProyecto.Location = new System.Drawing.Point(89, 21);
            this.cmbProyecto.Name = "cmbProyecto";
            this.cmbProyecto.Size = new System.Drawing.Size(246, 28);
            this.cmbProyecto.TabIndex = 131;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbPeriodo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbProyecto);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(10, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 71);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(352, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 134;
            this.label4.Text = "Periodo";
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(420, 21);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(211, 28);
            this.cmbPeriodo.TabIndex = 135;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Image = global::DBMETAL_SHARP.Properties.Resources.printer_setup;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(540, 222);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(117, 41);
            this.BtnImprimir.TabIndex = 135;
            this.BtnImprimir.Text = "Generar Reporte";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // LblTitulos
            // 
            this.LblTitulos.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulos.Font = new System.Drawing.Font("Britannic Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTitulos.Image = global::DBMETAL_SHARP.Properties.Resources.BarrasL;
            this.LblTitulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new System.Drawing.Point(-1, -3);
            this.LblTitulos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new System.Drawing.Size(706, 72);
            this.LblTitulos.TabIndex = 127;
            this.LblTitulos.Text = "Reportes Diario Muestreo Planta";
            this.LblTitulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmFiltroReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 278);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LblTitulos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFiltroReporte";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Diario ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DateTimePicker dtpEventInitial;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpEventEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbProyecto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPeriodo;
    }
}
using DBMETAL_SHARP.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBMETAL_SHARP.Liquidacion
{
    partial class frmReportMananger
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
            this.groupBox1 = new GroupBox();
            this.dtpEventEnd = new DateTimePicker();
            this.dtpEventInitial = new DateTimePicker();
            this.label2 = new Label();
            this.label6 = new Label();
            this.label1 = new Label();
            this.label3 = new Label();
            this.comboBox1 = new ComboBox();
            this.groupBox2 = new GroupBox();
            this.label4 = new Label();
            this.comboMina = new ComboBox();
            this.checkBox1 = new CheckBox();
            this.BtnImprimir = new Button();
            this.LblTitulos = new Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.dtpEventEnd);
            this.groupBox1.Controls.Add(this.dtpEventInitial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new Font("Rockwell", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.groupBox1.ForeColor = Color.Navy;
            this.groupBox1.Location = new Point(7, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(669, 72);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.dtpEventEnd.CalendarFont = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dtpEventEnd.CalendarForeColor = Color.Transparent;
            this.dtpEventEnd.CalendarMonthBackground = Color.Transparent;
            this.dtpEventEnd.CalendarTitleBackColor = Color.Transparent;
            this.dtpEventEnd.CalendarTitleForeColor = Color.Transparent;
            this.dtpEventEnd.CalendarTrailingForeColor = Color.Transparent;
            this.dtpEventEnd.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dtpEventEnd.Format = DateTimePickerFormat.Custom;
            this.dtpEventEnd.Location = new Point(466, 26);
            this.dtpEventEnd.Name = "dtpEventEnd";
            this.dtpEventEnd.Size = new Size(164, 30);
            this.dtpEventEnd.TabIndex = 110;
            this.dtpEventEnd.Value = new DateTime(2018, 5, 31, 0, 0, 0, 0);
            this.dtpEventInitial.CalendarFont = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dtpEventInitial.CalendarForeColor = Color.Transparent;
            this.dtpEventInitial.CalendarMonthBackground = Color.Transparent;
            this.dtpEventInitial.CalendarTitleBackColor = Color.Transparent;
            this.dtpEventInitial.CalendarTitleForeColor = Color.Transparent;
            this.dtpEventInitial.CalendarTrailingForeColor = Color.Transparent;
            this.dtpEventInitial.Font = new Font("Tahoma", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.dtpEventInitial.Format = DateTimePickerFormat.Custom;
            this.dtpEventInitial.Location = new Point(141, 26);
            this.dtpEventInitial.Name = "dtpEventInitial";
            this.dtpEventInitial.Size = new Size(161, 30);
            this.dtpEventInitial.TabIndex = 107;
            this.dtpEventInitial.Value = new DateTime(2018, 5, 31, 0, 0, 0, 0);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Agency FB", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(357, 23);
            this.label2.Name = "label2";
            this.label2.Size = new Size(107, 34);
            this.label2.TabIndex = 111;
            this.label2.Text = "Fecha Final";
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.ForeColor = Color.Navy;
            this.label6.Location = new Point(10, -2);
            this.label6.Name = "label6";
            this.label6.Size = new Size(130, 18);
            this.label6.TabIndex = 129;
            this.label6.Text = "Rango de fechas ";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Agency FB", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new Size(119, 34);
            this.label1.TabIndex = 108;
            this.label1.Text = "Fecha inicial";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.Navy;
            this.label3.Location = new Point(20, 58);
            this.label3.Name = "label3";
            this.label3.Size = new Size(125, 18);
            this.label3.TabIndex = 130;
            this.label3.Text = "Generar Reporte";
            this.comboBox1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new Point(151, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(214, 28);
            this.comboBox1.TabIndex = 131;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboMina);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Font = new Font("Arial Narrow", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.groupBox2.ForeColor = Color.Navy;
            this.groupBox2.Location = new Point(7, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(669, 98);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selección Reporte";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = Color.Navy;
            this.label4.Location = new Point(374, 57);
            this.label4.Name = "label4";
            this.label4.Size = new Size(42, 18);
            this.label4.TabIndex = 134;
            this.label4.Text = "Mina";
            this.comboMina.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.comboMina.FormattingEnabled = true;
            this.comboMina.Location = new Point(422, 53);
            this.comboMina.Name = "comboMina";
            this.comboMina.Size = new Size(210, 28);
            this.comboMina.TabIndex = 135;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(23, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(113, 20);
            this.checkBox1.TabIndex = 133;
            this.checkBox1.Text = "Agrupar Nombre";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.BtnImprimir.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BtnImprimir.Image = Resources.printer_setup;
            this.BtnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new Point(559, 252);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new Size(117, 41);
            this.BtnImprimir.TabIndex = 135;
            this.BtnImprimir.Text = "Generar Reporte";
            this.BtnImprimir.TextAlign = ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new EventHandler(this.BtnImprimir_Click);
            this.LblTitulos.BackColor = Color.Transparent;
            this.LblTitulos.Font = new Font("Britannic Bold", 21.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LblTitulos.ForeColor = Color.DodgerBlue;
            this.LblTitulos.Image = Resources.BarrasL;
            this.LblTitulos.ImageAlign = ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new Point(-1, -3);
            this.LblTitulos.Margin = new Padding(4, 0, 4, 0);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new Size(706, 72);
            this.LblTitulos.TabIndex = 127;
            this.LblTitulos.Text = "Administrador Reportes Liquidación - DBMeal";
            this.LblTitulos.TextAlign = ContentAlignment.MiddleLeft;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(687, 305);
            base.Controls.Add(this.BtnImprimir);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.LblTitulos);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmReportMananger";
            base.ShowIcon = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestionador de Reportes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label LblTitulos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DateTimePicker dtpEventInitial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DateTimePicker dtpEventEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboMina;
    }
}
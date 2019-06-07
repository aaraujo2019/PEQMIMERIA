namespace DBMETAL_SHARP
{
    partial class Frm_Estadisticas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CmbSeleccion = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblPesos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbOpcion = new System.Windows.Forms.ComboBox();
            this.DtpAñoMes = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbSeleccion
            // 
            this.CmbSeleccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSeleccion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CmbSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbSeleccion.Font = new System.Drawing.Font("Britannic Bold", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSeleccion.FormattingEnabled = true;
            this.CmbSeleccion.Items.AddRange(new object[] {
            "Pesajes de Mineral - Planta MD (Bascula)",
            "Otros Pesajes - (Bascula)"});
            this.CmbSeleccion.Location = new System.Drawing.Point(3, 5);
            this.CmbSeleccion.Name = "CmbSeleccion";
            this.CmbSeleccion.Size = new System.Drawing.Size(903, 43);
            this.CmbSeleccion.TabIndex = 1;
            this.CmbSeleccion.TabStop = false;
            this.CmbSeleccion.SelectedIndexChanged += new System.EventHandler(this.CmbSeleccion_SelectedIndexChanged);
            this.CmbSeleccion.Leave += new System.EventHandler(this.CmbSeleccion_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblPesos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CmbOpcion);
            this.groupBox1.Controls.Add(this.DtpAñoMes);
            this.groupBox1.Location = new System.Drawing.Point(15, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de consulta";
            // 
            // LblPesos
            // 
            this.LblPesos.AutoSize = true;
            this.LblPesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPesos.Location = new System.Drawing.Point(6, 89);
            this.LblPesos.Name = "LblPesos";
            this.LblPesos.Size = new System.Drawing.Size(57, 25);
            this.LblPesos.TabIndex = 9;
            this.LblPesos.Text = "Peso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Año y mes de procesamiento";
            // 
            // CmbOpcion
            // 
            this.CmbOpcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbOpcion.BackColor = System.Drawing.SystemColors.Window;
            this.CmbOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOpcion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOpcion.FormattingEnabled = true;
            this.CmbOpcion.Location = new System.Drawing.Point(5, 53);
            this.CmbOpcion.Name = "CmbOpcion";
            this.CmbOpcion.Size = new System.Drawing.Size(249, 21);
            this.CmbOpcion.TabIndex = 7;
            this.CmbOpcion.Leave += new System.EventHandler(this.CmbOpcion_Leave);
            // 
            // DtpAñoMes
            // 
            this.DtpAñoMes.CustomFormat = "";
            this.DtpAñoMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpAñoMes.Location = new System.Drawing.Point(152, 18);
            this.DtpAñoMes.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.DtpAñoMes.Name = "DtpAñoMes";
            this.DtpAñoMes.Size = new System.Drawing.Size(102, 20);
            this.DtpAñoMes.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.Size = new System.Drawing.Size(598, 99);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(284, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 127);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tabla de Contenido";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Location = new System.Drawing.Point(15, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(880, 251);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tabla de Contenido";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(6, 22);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(868, 223);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Frm_Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(907, 465);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbSeleccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_Estadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.Frm_Estadisticas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbSeleccion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtpAñoMes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox CmbOpcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblPesos;
    }
}
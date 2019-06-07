using DBMETAL_SHARP.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    partial class Frm_Periodo
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
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatenEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEventInitial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOnzasRecuperadas = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRecuperacion = new System.Windows.Forms.MaskedTextBox();
            this.txtOnzasFundidas = new System.Windows.Forms.MaskedTextBox();
            this.dataHistoryPeriodo = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrarPe = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataDetailPeriodo = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTenor = new System.Windows.Forms.TextBox();
            this.txtOnzas = new System.Windows.Forms.TextBox();
            this.txtToneladas = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.LblTitulos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHistoryPeriodo)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetailPeriodo)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPeriodo);
            this.groupBox1.Controls.Add(this.cboMes);
            this.groupBox1.Controls.Add(this.cboAno);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpDatenEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEventInitial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(14, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1087, 81);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Periodos";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Items.AddRange(new object[] {
            "Periodo1",
            "Periodo2",
            "Periodo3"});
            this.cboPeriodo.Location = new System.Drawing.Point(929, 28);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(132, 29);
            this.cboPeriodo.TabIndex = 120;
            this.cboPeriodo.Click += new System.EventHandler(this.cboPeriodo_Click);
            // 
            // cboMes
            // 
            this.cboMes.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboMes.Location = new System.Drawing.Point(768, 28);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(76, 29);
            this.cboMes.TabIndex = 119;
            this.cboMes.Click += new System.EventHandler(this.cboMes_Click);
            // 
            // cboAno
            // 
            this.cboAno.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAno.FormattingEnabled = true;
            this.cboAno.Location = new System.Drawing.Point(627, 28);
            this.cboAno.Name = "cboAno";
            this.cboAno.Size = new System.Drawing.Size(88, 29);
            this.cboAno.TabIndex = 118;
            this.cboAno.Click += new System.EventHandler(this.cboAno_Click);
            this.cboAno.Leave += new System.EventHandler(this.cboAno_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(850, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 34);
            this.label5.TabIndex = 117;
            this.label5.Text = "Periodo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(721, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 34);
            this.label4.TabIndex = 115;
            this.label4.Text = "Mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(581, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 34);
            this.label3.TabIndex = 113;
            this.label3.Text = "Año";
            // 
            // dtpDatenEnd
            // 
            this.dtpDatenEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatenEnd.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatenEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatenEnd.Location = new System.Drawing.Point(404, 28);
            this.dtpDatenEnd.Name = "dtpDatenEnd";
            this.dtpDatenEnd.Size = new System.Drawing.Size(144, 30);
            this.dtpDatenEnd.TabIndex = 110;
            this.dtpDatenEnd.Value = new System.DateTime(2018, 4, 30, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 34);
            this.label2.TabIndex = 111;
            this.label2.Text = "Fecha Final";
            // 
            // dtpEventInitial
            // 
            this.dtpEventInitial.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventInitial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventInitial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEventInitial.Location = new System.Drawing.Point(124, 29);
            this.dtpEventInitial.Name = "dtpEventInitial";
            this.dtpEventInitial.Size = new System.Drawing.Size(160, 30);
            this.dtpEventInitial.TabIndex = 107;
            this.dtpEventInitial.Value = new System.DateTime(2018, 4, 30, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 34);
            this.label1.TabIndex = 108;
            this.label1.Text = "Fecha Inicial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(4, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 31);
            this.label6.TabIndex = 121;
            this.label6.Text = "Onzas fundidas periodo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(343, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 31);
            this.label7.TabIndex = 123;
            this.label7.Text = "Recuperación planta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtOnzasRecuperadas);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtRecuperacion);
            this.groupBox2.Controls.Add(this.txtOnzasFundidas);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(14, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1087, 65);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Captura de Datos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(627, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 31);
            this.label9.TabIndex = 129;
            this.label9.Text = "%";
            // 
            // txtOnzasRecuperadas
            // 
            this.txtOnzasRecuperadas.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnzasRecuperadas.Location = new System.Drawing.Point(842, 19);
            this.txtOnzasRecuperadas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOnzasRecuperadas.Mask = "00000.00";
            this.txtOnzasRecuperadas.Name = "txtOnzasRecuperadas";
            this.txtOnzasRecuperadas.Size = new System.Drawing.Size(115, 30);
            this.txtOnzasRecuperadas.TabIndex = 128;
            this.txtOnzasRecuperadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(678, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 31);
            this.label8.TabIndex = 125;
            this.label8.Text = "Onzas recuperadas";
            // 
            // txtRecuperacion
            // 
            this.txtRecuperacion.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecuperacion.Location = new System.Drawing.Point(511, 20);
            this.txtRecuperacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRecuperacion.Mask = "00.00";
            this.txtRecuperacion.Name = "txtRecuperacion";
            this.txtRecuperacion.Size = new System.Drawing.Size(111, 30);
            this.txtRecuperacion.TabIndex = 127;
            this.txtRecuperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOnzasFundidas
            // 
            this.txtOnzasFundidas.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnzasFundidas.Location = new System.Drawing.Point(196, 20);
            this.txtOnzasFundidas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOnzasFundidas.Mask = "00000.00";
            this.txtOnzasFundidas.Name = "txtOnzasFundidas";
            this.txtOnzasFundidas.Size = new System.Drawing.Size(116, 30);
            this.txtOnzasFundidas.TabIndex = 126;
            this.txtOnzasFundidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataHistoryPeriodo
            // 
            this.dataHistoryPeriodo.AllowUserToAddRows = false;
            this.dataHistoryPeriodo.AllowUserToDeleteRows = false;
            this.dataHistoryPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataHistoryPeriodo.Location = new System.Drawing.Point(11, 21);
            this.dataHistoryPeriodo.Name = "dataHistoryPeriodo";
            this.dataHistoryPeriodo.ReadOnly = true;
            this.dataHistoryPeriodo.Size = new System.Drawing.Size(506, 291);
            this.dataHistoryPeriodo.TabIndex = 0;
            this.dataHistoryPeriodo.DataSourceChanged += new System.EventHandler(this.dataHistoryPeriodo_DataSourceChanged);
            this.dataHistoryPeriodo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataHistoryPeriodo_CellClick);
            this.dataHistoryPeriodo.BindingContextChanged += new System.EventHandler(this.dataHistoryPeriodo_BindingContextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCerrarPe);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(13, 221);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 72);
            this.groupBox4.TabIndex = 127;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estado Periodo";
            // 
            // btnCerrarPe
            // 
            this.btnCerrarPe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPe.Image = global::DBMETAL_SHARP.Properties.Resources.cruz;
            this.btnCerrarPe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarPe.Location = new System.Drawing.Point(125, 14);
            this.btnCerrarPe.Name = "btnCerrarPe";
            this.btnCerrarPe.Size = new System.Drawing.Size(136, 50);
            this.btnCerrarPe.TabIndex = 110;
            this.btnCerrarPe.Text = "Cerrar periodo";
            this.btnCerrarPe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarPe.UseVisualStyleBackColor = true;
            this.btnCerrarPe.Click += new System.EventHandler(this.btnCerrarPe_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(24, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 35);
            this.label17.TabIndex = 108;
            this.label17.Text = "ABIERTO";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataHistoryPeriodo);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(13, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 329);
            this.groupBox3.TabIndex = 125;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Historial de Periodos de año en curso";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataDetailPeriodo);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.Navy;
            this.groupBox5.Location = new System.Drawing.Point(548, 299);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(553, 329);
            this.groupBox5.TabIndex = 130;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalles del Periodo Seleccionado";
            // 
            // dataDetailPeriodo
            // 
            this.dataDetailPeriodo.AllowUserToAddRows = false;
            this.dataDetailPeriodo.AllowUserToDeleteRows = false;
            this.dataDetailPeriodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetailPeriodo.Location = new System.Drawing.Point(11, 21);
            this.dataDetailPeriodo.Name = "dataDetailPeriodo";
            this.dataDetailPeriodo.ReadOnly = true;
            this.dataDetailPeriodo.Size = new System.Drawing.Size(534, 291);
            this.dataDetailPeriodo.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtTenor);
            this.groupBox6.Controls.Add(this.txtOnzas);
            this.groupBox6.Controls.Add(this.txtToneladas);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.Navy;
            this.groupBox6.Location = new System.Drawing.Point(312, 222);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(789, 71);
            this.groupBox6.TabIndex = 131;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Total del Periodo seleccionado";
            // 
            // txtTenor
            // 
            this.txtTenor.Enabled = false;
            this.txtTenor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenor.Location = new System.Drawing.Point(584, 20);
            this.txtTenor.Name = "txtTenor";
            this.txtTenor.Size = new System.Drawing.Size(143, 30);
            this.txtTenor.TabIndex = 134;
            // 
            // txtOnzas
            // 
            this.txtOnzas.Enabled = false;
            this.txtOnzas.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnzas.Location = new System.Drawing.Point(345, 22);
            this.txtOnzas.Name = "txtOnzas";
            this.txtOnzas.Size = new System.Drawing.Size(143, 30);
            this.txtOnzas.TabIndex = 133;
            // 
            // txtToneladas
            // 
            this.txtToneladas.Enabled = false;
            this.txtToneladas.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToneladas.Location = new System.Drawing.Point(109, 24);
            this.txtToneladas.Name = "txtToneladas";
            this.txtToneladas.Size = new System.Drawing.Size(143, 30);
            this.txtToneladas.TabIndex = 132;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Agency FB", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(520, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 34);
            this.label12.TabIndex = 125;
            this.label12.Text = "Tenor";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Agency FB", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(7, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 34);
            this.label15.TabIndex = 121;
            this.label15.Text = "Toneladas";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Agency FB", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(280, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 34);
            this.label18.TabIndex = 123;
            this.label18.Text = "Onzas";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::DBMETAL_SHARP.Properties.Resources.print;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(559, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 38);
            this.button1.TabIndex = 132;
            this.button1.Text = "Onzas recuperadas";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::DBMETAL_SHARP.Properties.Resources.print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(720, 24);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(152, 38);
            this.btnPrint.TabIndex = 129;
            this.btnPrint.Text = "Onzas entregadas";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::DBMETAL_SHARP.Properties.Resources.new_16;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(1017, 24);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(82, 37);
            this.btnNew.TabIndex = 128;
            this.btnNew.Text = "Nuevo";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(878, 24);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(132, 37);
            this.btnCreate.TabIndex = 97;
            this.btnCreate.Text = "Crear periodo";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblTitulos
            // 
            this.LblTitulos.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulos.Font = new System.Drawing.Font("Britannic Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulos.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTitulos.Image = global::DBMETAL_SHARP.Properties.Resources.BarrasL;
            this.LblTitulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new System.Drawing.Point(-2, -8);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new System.Drawing.Size(1109, 72);
            this.LblTitulos.TabIndex = 90;
            this.LblTitulos.Text = "Gestión de Periodos";
            this.LblTitulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Periodo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1109, 636);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.LblTitulos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Periodo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Periodos";
            this.Load += new System.EventHandler(this.Frm_Periodo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHistoryPeriodo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataDetailPeriodo)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulos;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DateTimePicker dtpDatenEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DateTimePicker dtpEventInitial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataHistoryPeriodo;
        private System.Windows.Forms.MaskedTextBox txtOnzasRecuperadas;
        private System.Windows.Forms.MaskedTextBox txtRecuperacion;
        private System.Windows.Forms.MaskedTextBox txtOnzasFundidas;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnCerrarPe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataDetailPeriodo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtToneladas;
        private System.Windows.Forms.TextBox txtTenor;
        private System.Windows.Forms.TextBox txtOnzas;
        private System.Windows.Forms.Button button1;
    }
}
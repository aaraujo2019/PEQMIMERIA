using DBMETAL_SHARP.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    partial class Frm_ControlCalidadMuestras
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCantidadMuestras = new System.Windows.Forms.DataGridView();
            this.chkSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboDuplicado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCantidadPendientesMuestras = new System.Windows.Forms.DataGridView();
            this.lblCantidadPendienteMuestras = new System.Windows.Forms.Label();
            this.lblCantidadMuestrasNumero = new System.Windows.Forms.Label();
            this.lblCantidadPendienteMuestrasNumero = new System.Windows.Forms.Label();
            this.cbmLabo = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvCantidadDeMuestrasEnElLaboratorio = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCantidadMuestras = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvMuestrasDuplicadas = new System.Windows.Forms.DataGridView();
            this.AUGFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAQAQC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMuestrasDuplicadasNumero = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txtBuscarSelloControl = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpEvent = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.LblTitulos = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadMuestras)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadPendientesMuestras)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadDeMuestrasEnElLaboratorio)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestrasDuplicadas)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(271, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 23);
            this.label7.TabIndex = 122;
            this.label7.Text = "Laboratorio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(21, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 23);
            this.label6.TabIndex = 120;
            this.label6.Text = "Fecha Producción";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCantidadMuestras);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(10, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 182);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Muestreo del día";
            // 
            // dgvCantidadMuestras
            // 
            this.dgvCantidadMuestras.AllowUserToDeleteRows = false;
            this.dgvCantidadMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCantidadMuestras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelection,
            this.cboDuplicado});
            this.dgvCantidadMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCantidadMuestras.Location = new System.Drawing.Point(3, 19);
            this.dgvCantidadMuestras.Name = "dgvCantidadMuestras";
            this.dgvCantidadMuestras.Size = new System.Drawing.Size(558, 160);
            this.dgvCantidadMuestras.TabIndex = 112;
            // 
            // chkSelection
            // 
            this.chkSelection.HeaderText = "Selección";
            this.chkSelection.Name = "chkSelection";
            this.chkSelection.Width = 50;
            // 
            // cboDuplicado
            // 
            this.cboDuplicado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboDuplicado.HeaderText = "Analísis";
            this.cboDuplicado.Items.AddRange(new object[] {
            "(1)",
            "(2)",
            "(3)",
            "(4)"});
            this.cboDuplicado.Name = "cboDuplicado";
            this.cboDuplicado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cboDuplicado.Width = 50;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvCantidadPendientesMuestras);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(584, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(567, 142);
            this.groupBox3.TabIndex = 114;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pendientes para Muestreo";
            // 
            // dgvCantidadPendientesMuestras
            // 
            this.dgvCantidadPendientesMuestras.AllowUserToDeleteRows = false;
            this.dgvCantidadPendientesMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCantidadPendientesMuestras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCantidadPendientesMuestras.Location = new System.Drawing.Point(3, 19);
            this.dgvCantidadPendientesMuestras.Name = "dgvCantidadPendientesMuestras";
            this.dgvCantidadPendientesMuestras.ReadOnly = true;
            this.dgvCantidadPendientesMuestras.Size = new System.Drawing.Size(561, 120);
            this.dgvCantidadPendientesMuestras.TabIndex = 112;
            // 
            // lblCantidadPendienteMuestras
            // 
            this.lblCantidadPendienteMuestras.AutoSize = true;
            this.lblCantidadPendienteMuestras.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadPendienteMuestras.ForeColor = System.Drawing.Color.Navy;
            this.lblCantidadPendienteMuestras.Location = new System.Drawing.Point(581, 56);
            this.lblCantidadPendienteMuestras.Name = "lblCantidadPendienteMuestras";
            this.lblCantidadPendienteMuestras.Size = new System.Drawing.Size(307, 23);
            this.lblCantidadPendienteMuestras.TabIndex = 116;
            this.lblCantidadPendienteMuestras.Text = "Cantidad Pendientes de Muestras";
            // 
            // lblCantidadMuestrasNumero
            // 
            this.lblCantidadMuestrasNumero.AutoSize = true;
            this.lblCantidadMuestrasNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblCantidadMuestrasNumero.Location = new System.Drawing.Point(204, 54);
            this.lblCantidadMuestrasNumero.Name = "lblCantidadMuestrasNumero";
            this.lblCantidadMuestrasNumero.Size = new System.Drawing.Size(24, 26);
            this.lblCantidadMuestrasNumero.TabIndex = 117;
            this.lblCantidadMuestrasNumero.Text = "0";
            // 
            // lblCantidadPendienteMuestrasNumero
            // 
            this.lblCantidadPendienteMuestrasNumero.AutoSize = true;
            this.lblCantidadPendienteMuestrasNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadPendienteMuestrasNumero.Location = new System.Drawing.Point(884, 53);
            this.lblCantidadPendienteMuestrasNumero.Name = "lblCantidadPendienteMuestrasNumero";
            this.lblCantidadPendienteMuestrasNumero.Size = new System.Drawing.Size(24, 26);
            this.lblCantidadPendienteMuestrasNumero.TabIndex = 118;
            this.lblCantidadPendienteMuestrasNumero.Text = "0";
            // 
            // cbmLabo
            // 
            this.cbmLabo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmLabo.FormattingEnabled = true;
            this.cbmLabo.Items.AddRange(new object[] {
            "SGS",
            "Zandor ",
            "ACTLAB",
            "Otros"});
            this.cbmLabo.Location = new System.Drawing.Point(265, 12);
            this.cbmLabo.Margin = new System.Windows.Forms.Padding(2);
            this.cbmLabo.Name = "cbmLabo";
            this.cbmLabo.Size = new System.Drawing.Size(179, 32);
            this.cbmLabo.TabIndex = 121;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvCantidadDeMuestrasEnElLaboratorio);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 10F);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(13, 307);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(561, 189);
            this.groupBox4.TabIndex = 114;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Enviado a Laboratorio";
            // 
            // dgvCantidadDeMuestrasEnElLaboratorio
            // 
            this.dgvCantidadDeMuestrasEnElLaboratorio.AllowUserToDeleteRows = false;
            this.dgvCantidadDeMuestrasEnElLaboratorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCantidadDeMuestrasEnElLaboratorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCantidadDeMuestrasEnElLaboratorio.Location = new System.Drawing.Point(3, 19);
            this.dgvCantidadDeMuestrasEnElLaboratorio.Name = "dgvCantidadDeMuestrasEnElLaboratorio";
            this.dgvCantidadDeMuestrasEnElLaboratorio.ReadOnly = true;
            this.dgvCantidadDeMuestrasEnElLaboratorio.Size = new System.Drawing.Size(555, 167);
            this.dgvCantidadDeMuestrasEnElLaboratorio.TabIndex = 112;
            this.dgvCantidadDeMuestrasEnElLaboratorio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(9, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(219, 23);
            this.label12.TabIndex = 123;
            this.label12.Text = "Muestras en laboratorio";
            // 
            // lblCantidadMuestras
            // 
            this.lblCantidadMuestras.AutoSize = true;
            this.lblCantidadMuestras.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadMuestras.ForeColor = System.Drawing.Color.Navy;
            this.lblCantidadMuestras.Location = new System.Drawing.Point(6, 56);
            this.lblCantidadMuestras.Name = "lblCantidadMuestras";
            this.lblCantidadMuestras.Size = new System.Drawing.Size(204, 23);
            this.lblCantidadMuestras.TabIndex = 125;
            this.lblCantidadMuestras.Text = "Cantidad de Muestras";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.dgvMuestrasDuplicadas);
            this.groupBox6.Font = new System.Drawing.Font("Arial", 10F);
            this.groupBox6.ForeColor = System.Drawing.Color.Navy;
            this.groupBox6.Location = new System.Drawing.Point(582, 253);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(569, 175);
            this.groupBox6.TabIndex = 115;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Muestras Duplicadas";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Agency FB", 40F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(161, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(277, 64);
            this.label13.TabIndex = 140;
            this.label13.Text = "Guardando.....";
            this.label13.Visible = false;
            // 
            // dgvMuestrasDuplicadas
            // 
            this.dgvMuestrasDuplicadas.AllowUserToDeleteRows = false;
            this.dgvMuestrasDuplicadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMuestrasDuplicadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AUGFinal,
            this.AAQAQC});
            this.dgvMuestrasDuplicadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMuestrasDuplicadas.Location = new System.Drawing.Point(3, 19);
            this.dgvMuestrasDuplicadas.Name = "dgvMuestrasDuplicadas";
            this.dgvMuestrasDuplicadas.Size = new System.Drawing.Size(563, 153);
            this.dgvMuestrasDuplicadas.TabIndex = 112;
            this.dgvMuestrasDuplicadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            this.dgvMuestrasDuplicadas.BindingContextChanged += new System.EventHandler(this.dataGridView4_BindingContextChanged);
            // 
            // AUGFinal
            // 
            this.AUGFinal.HeaderText = "AU Final";
            this.AUGFinal.Name = "AUGFinal";
            // 
            // AAQAQC
            // 
            this.AAQAQC.HeaderText = "QAQC2";
            this.AAQAQC.Name = "AAQAQC";
            this.AAQAQC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AAQAQC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(580, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(278, 23);
            this.label8.TabIndex = 126;
            this.label8.Text = "Cantidad Muestras Duplicadas";
            // 
            // lblMuestrasDuplicadasNumero
            // 
            this.lblMuestrasDuplicadasNumero.AutoSize = true;
            this.lblMuestrasDuplicadasNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMuestrasDuplicadasNumero.Location = new System.Drawing.Point(864, 229);
            this.lblMuestrasDuplicadasNumero.Name = "lblMuestrasDuplicadasNumero";
            this.lblMuestrasDuplicadasNumero.Size = new System.Drawing.Size(24, 26);
            this.lblMuestrasDuplicadasNumero.TabIndex = 127;
            this.lblMuestrasDuplicadasNumero.Text = "0";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.Navy;
            this.groupBox7.Location = new System.Drawing.Point(587, 428);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(418, 68);
            this.groupBox7.TabIndex = 134;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Análisis";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(201, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 26);
            this.label16.TabIndex = 132;
            this.label16.Text = "label16";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(202, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(157, 24);
            this.label17.TabIndex = 131;
            this.label17.Text = "DESVIACIÓN ESTANDAR";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(103, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 26);
            this.label15.TabIndex = 130;
            this.label15.Text = "label15";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Agency FB", 15F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(104, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 24);
            this.label14.TabIndex = 129;
            this.label14.Text = "MEDIANA";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button5.Image = global::DBMETAL_SHARP.Properties.Resources.signo_menos_dentro_de_un_circulo_negro;
            this.button5.Location = new System.Drawing.Point(1086, 443);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 42);
            this.button5.TabIndex = 135;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtBuscarSelloControl
            // 
            this.txtBuscarSelloControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtBuscarSelloControl.Location = new System.Drawing.Point(395, 275);
            this.txtBuscarSelloControl.Multiline = true;
            this.txtBuscarSelloControl.Name = "txtBuscarSelloControl";
            this.txtBuscarSelloControl.Size = new System.Drawing.Size(94, 23);
            this.txtBuscarSelloControl.TabIndex = 137;
            this.txtBuscarSelloControl.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtBuscarSelloControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtBuscarSelloControl.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Navy;
            this.label20.Location = new System.Drawing.Point(280, 271);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 31);
            this.label20.TabIndex = 138;
            this.label20.Text = "Sello Control";
            // 
            // dtpEvent
            // 
            this.dtpEvent.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEvent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEvent.Location = new System.Drawing.Point(68, 14);
            this.dtpEvent.Name = "dtpEvent";
            this.dtpEvent.Size = new System.Drawing.Size(160, 30);
            this.dtpEvent.TabIndex = 107;
            this.dtpEvent.Value = new System.DateTime(2018, 3, 12, 11, 1, 50, 0);
            this.dtpEvent.ValueChanged += new System.EventHandler(this.dtpEvent_ValueChanged);
            this.dtpEvent.Leave += new System.EventHandler(this.dateTimePicker2_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 31);
            this.label1.TabIndex = 108;
            this.label1.Text = "Fecha";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.txtBuscarSelloControl);
            this.groupBox5.Controls.Add(this.dtpEvent);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.lblMuestrasDuplicadasNumero);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.lblCantidadMuestras);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.cbmLabo);
            this.groupBox5.Controls.Add(this.lblCantidadPendienteMuestrasNumero);
            this.groupBox5.Controls.Add(this.lblCantidadMuestrasNumero);
            this.groupBox5.Controls.Add(this.lblCantidadPendienteMuestras);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Location = new System.Drawing.Point(3, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1164, 503);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(226, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 26);
            this.label10.TabIndex = 124;
            this.label10.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Image = global::DBMETAL_SHARP.Properties.Resources.mail;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1085, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 36);
            this.button1.TabIndex = 93;
            this.button1.Text = "Enviar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button6.Image = global::DBMETAL_SHARP.Properties.Resources.trash_16;
            this.button6.Location = new System.Drawing.Point(495, 271);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 30);
            this.button6.TabIndex = 139;
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Image = global::DBMETAL_SHARP.Properties.Resources.marcaragistrada1;
            this.button2.Location = new System.Drawing.Point(365, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 43);
            this.button2.TabIndex = 135;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button3.Image = global::DBMETAL_SHARP.Properties.Resources.refresh;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(7, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 30);
            this.button3.TabIndex = 133;
            this.button3.Text = "QAQC";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button4.Image = global::DBMETAL_SHARP.Properties.Resources.mas;
            this.button4.Location = new System.Drawing.Point(1027, 443);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 43);
            this.button4.TabIndex = 134;
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnImprimir.Image = global::DBMETAL_SHARP.Properties.Resources.printer_setup;
            this.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImprimir.Location = new System.Drawing.Point(981, 34);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(98, 36);
            this.BtnImprimir.TabIndex = 92;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // LblTitulos
            // 
            this.LblTitulos.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulos.Font = new System.Drawing.Font("Agency FB", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LblTitulos.Image = global::DBMETAL_SHARP.Properties.Resources.BarrasL;
            this.LblTitulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitulos.Location = new System.Drawing.Point(-3, -9);
            this.LblTitulos.Name = "LblTitulos";
            this.LblTitulos.Size = new System.Drawing.Size(1185, 64);
            this.LblTitulos.TabIndex = 89;
            this.LblTitulos.Text = "Control Calidad Muestreo";
            this.LblTitulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_ControlCalidadMuestras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1171, 586);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.LblTitulos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ControlCalidadMuestras";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Calidad Muestreo";
            this.Load += new System.EventHandler(this.Frm_MuestreoPM_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadMuestras)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadPendientesMuestras)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantidadDeMuestrasEnElLaboratorio)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestrasDuplicadas)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Label LblTitulos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DateTimePicker dtpEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCantidadMuestras;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCantidadPendienteMuestrasNumero;
        private System.Windows.Forms.Label lblCantidadMuestras;
        private System.Windows.Forms.Label lblCantidadPendienteMuestras;
       private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbmLabo;
        private System.Windows.Forms.DataGridView dgvCantidadPendientesMuestras;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvCantidadDeMuestrasEnElLaboratorio;
        private System.Windows.Forms.Label lblCantidadMuestrasNumero;
        private System.Windows.Forms.Label label12;
    
     
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvMuestrasDuplicadas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMuestrasDuplicadasNumero;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelection;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboDuplicado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUGFinal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AAQAQC;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBuscarSelloControl;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button6;
        private Label label10;
    }
}
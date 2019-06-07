namespace DBMETAL_SHARP
{
    partial class FrmReclamos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReclamos));
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.gbEncabezado = new System.Windows.Forms.GroupBox();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtNumMuestras = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaReporte = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNumOrden = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbSellos = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHumedad = new System.Windows.Forms.TextBox();
            this.dtgvSellos = new System.Windows.Forms.DataGridView();
            this.cmpSello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Humedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmpAu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmpAg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtAg = new System.Windows.Forms.TextBox();
            this.txtAu = new System.Windows.Forms.TextBox();
            this.txtSellos = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbEncabezado.SuspendLayout();
            this.gbSellos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSellos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Image = global::DBMETAL_SHARP.Properties.Resources.Ondadegradada;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-4, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(722, 53);
            this.label1.TabIndex = 99;
            this.label1.Text = "Reclamos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::DBMETAL_SHARP.Properties.Resources.print;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcesar.Location = new System.Drawing.Point(388, 7);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(58, 40);
            this.btnProcesar.TabIndex = 113;
            this.btnProcesar.Text = "Imprimir";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::DBMETAL_SHARP.Properties.Resources.trash_full;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(334, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 40);
            this.btnDelete.TabIndex = 112;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(553, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 40);
            this.btnExit.TabIndex = 111;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(499, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.TabIndex = 109;
            this.btnSave.Tag = "1";
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::DBMETAL_SHARP.Properties.Resources.new_16;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(445, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.TabIndex = 110;
            this.btnNew.Text = "Nuevo";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // gbEncabezado
            // 
            this.gbEncabezado.Controls.Add(this.txtLugar);
            this.gbEncabezado.Controls.Add(this.label28);
            this.gbEncabezado.Controls.Add(this.btnIngresar);
            this.gbEncabezado.Controls.Add(this.txtNumMuestras);
            this.gbEncabezado.Controls.Add(this.label4);
            this.gbEncabezado.Controls.Add(this.dtpFechaReporte);
            this.gbEncabezado.Controls.Add(this.label3);
            this.gbEncabezado.Controls.Add(this.dtpFechaRecepcion);
            this.gbEncabezado.Controls.Add(this.label2);
            this.gbEncabezado.Controls.Add(this.btnBuscar);
            this.gbEncabezado.Controls.Add(this.txtNumOrden);
            this.gbEncabezado.Controls.Add(this.label11);
            this.gbEncabezado.Controls.Add(this.txtCliente);
            this.gbEncabezado.Controls.Add(this.label10);
            this.gbEncabezado.Location = new System.Drawing.Point(9, 55);
            this.gbEncabezado.Name = "gbEncabezado";
            this.gbEncabezado.Size = new System.Drawing.Size(598, 109);
            this.gbEncabezado.TabIndex = 114;
            this.gbEncabezado.TabStop = false;
            // 
            // txtLugar
            // 
            this.txtLugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLugar.ForeColor = System.Drawing.Color.Navy;
            this.txtLugar.Location = new System.Drawing.Point(139, 43);
            this.txtLugar.MaxLength = 100;
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(151, 20);
            this.txtLugar.TabIndex = 3;
            this.txtLugar.Tag = "Número de Muestras";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Navy;
            this.label28.Location = new System.Drawing.Point(20, 45);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(119, 16);
            this.label28.TabIndex = 120;
            this.label28.Text = "* Lugar Recepción";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Image = global::DBMETAL_SHARP.Properties.Resources.red;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIngresar.Location = new System.Drawing.Point(519, 18);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(61, 40);
            this.btnIngresar.TabIndex = 7;
            this.btnIngresar.Tag = "1";
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtNumMuestras
            // 
            this.txtNumMuestras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumMuestras.ForeColor = System.Drawing.Color.Navy;
            this.txtNumMuestras.Location = new System.Drawing.Point(498, 74);
            this.txtNumMuestras.MaxLength = 3;
            this.txtNumMuestras.Name = "txtNumMuestras";
            this.txtNumMuestras.Size = new System.Drawing.Size(88, 20);
            this.txtNumMuestras.TabIndex = 6;
            this.txtNumMuestras.Tag = "Número de Muestras";
            this.txtNumMuestras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumMuestras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMuestras_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(396, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 118;
            this.label4.Text = "* # de Muestras";
            // 
            // dtpFechaReporte
            // 
            this.dtpFechaReporte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReporte.Location = new System.Drawing.Point(418, 43);
            this.dtpFechaReporte.Name = "dtpFechaReporte";
            this.dtpFechaReporte.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaReporte.TabIndex = 4;
            this.dtpFechaReporte.Tag = "Fecha Reporte";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(294, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 115;
            this.label3.Text = "* Fecha Reporte";
            // 
            // dtpFechaRecepcion
            // 
            this.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRecepcion.Location = new System.Drawing.Point(418, 14);
            this.dtpFechaRecepcion.Name = "dtpFechaRecepcion";
            this.dtpFechaRecepcion.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaRecepcion.TabIndex = 2;
            this.dtpFechaRecepcion.Tag = "Fecha Recepción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(294, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 113;
            this.label2.Text = "* Fecha Recepción";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::DBMETAL_SHARP.Properties.Resources.srch_16;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(258, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(32, 23);
            this.btnBuscar.TabIndex = 112;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNumOrden
            // 
            this.txtNumOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOrden.ForeColor = System.Drawing.Color.Navy;
            this.txtNumOrden.Location = new System.Drawing.Point(139, 13);
            this.txtNumOrden.MaxLength = 10;
            this.txtNumOrden.Name = "txtNumOrden";
            this.txtNumOrden.Size = new System.Drawing.Size(117, 20);
            this.txtNumOrden.TabIndex = 1;
            this.txtNumOrden.Tag = "Número de Orden";
            this.txtNumOrden.Leave += new System.EventHandler(this.txtNumOrden_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(22, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 111;
            this.label11.Text = "* # Orden";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Navy;
            this.txtCliente.Location = new System.Drawing.Point(138, 74);
            this.txtCliente.MaxLength = 100;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(246, 20);
            this.txtCliente.TabIndex = 5;
            this.txtCliente.Tag = "Cliente";
            this.txtCliente.Leave += new System.EventHandler(this.txtCliente_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(20, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 109;
            this.label10.Text = "* Ref. del Cliente";
            // 
            // gbSellos
            // 
            this.gbSellos.Controls.Add(this.label8);
            this.gbSellos.Controls.Add(this.label24);
            this.gbSellos.Controls.Add(this.label27);
            this.gbSellos.Controls.Add(this.label25);
            this.gbSellos.Controls.Add(this.label26);
            this.gbSellos.Controls.Add(this.label21);
            this.gbSellos.Controls.Add(this.label22);
            this.gbSellos.Controls.Add(this.label23);
            this.gbSellos.Controls.Add(this.txtWeight);
            this.gbSellos.Controls.Add(this.label5);
            this.gbSellos.Controls.Add(this.txtHumedad);
            this.gbSellos.Controls.Add(this.dtgvSellos);
            this.gbSellos.Controls.Add(this.btnAdicionar);
            this.gbSellos.Controls.Add(this.txtAg);
            this.gbSellos.Controls.Add(this.txtAu);
            this.gbSellos.Controls.Add(this.txtSellos);
            this.gbSellos.Controls.Add(this.label18);
            this.gbSellos.Controls.Add(this.label19);
            this.gbSellos.Controls.Add(this.label20);
            this.gbSellos.Controls.Add(this.label15);
            this.gbSellos.Controls.Add(this.label16);
            this.gbSellos.Controls.Add(this.label17);
            this.gbSellos.Controls.Add(this.label12);
            this.gbSellos.Controls.Add(this.label13);
            this.gbSellos.Controls.Add(this.label14);
            this.gbSellos.Controls.Add(this.label9);
            this.gbSellos.Controls.Add(this.label7);
            this.gbSellos.Controls.Add(this.label6);
            this.gbSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSellos.ForeColor = System.Drawing.Color.Navy;
            this.gbSellos.Location = new System.Drawing.Point(10, 165);
            this.gbSellos.Name = "gbSellos";
            this.gbSellos.Size = new System.Drawing.Size(595, 375);
            this.gbSellos.TabIndex = 115;
            this.gbSellos.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(475, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 133;
            this.label8.Text = "Weight";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Navy;
            this.label24.Location = new System.Drawing.Point(391, 105);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 16);
            this.label24.TabIndex = 132;
            this.label24.Text = "500";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Navy;
            this.label27.Location = new System.Drawing.Point(286, 105);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(36, 16);
            this.label27.TabIndex = 131;
            this.label27.Text = "3000";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Navy;
            this.label25.Location = new System.Drawing.Point(477, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 16);
            this.label25.TabIndex = 130;
            this.label25.Text = "PMI_CH";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Navy;
            this.label26.Location = new System.Drawing.Point(482, 38);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(18, 16);
            this.label26.TabIndex = 129;
            this.label26.Text = "G";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Navy;
            this.label21.Location = new System.Drawing.Point(176, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 16);
            this.label21.TabIndex = 126;
            this.label21.Text = "GQ_H2O";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Navy;
            this.label22.Location = new System.Drawing.Point(193, 38);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 16);
            this.label22.TabIndex = 125;
            this.label22.Text = "%";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Navy;
            this.label23.Location = new System.Drawing.Point(167, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 16);
            this.label23.TabIndex = 124;
            this.label23.Text = "Humedad";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.ForeColor = System.Drawing.Color.Navy;
            this.txtWeight.Location = new System.Drawing.Point(460, 128);
            this.txtWeight.MaxLength = 5;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(88, 20);
            this.txtWeight.TabIndex = 12;
            this.txtWeight.Tag = "Weight";
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(18, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 122;
            this.label5.Text = "Limite Superior";
            // 
            // txtHumedad
            // 
            this.txtHumedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHumedad.ForeColor = System.Drawing.Color.Navy;
            this.txtHumedad.Location = new System.Drawing.Point(160, 128);
            this.txtHumedad.MaxLength = 5;
            this.txtHumedad.Name = "txtHumedad";
            this.txtHumedad.Size = new System.Drawing.Size(88, 20);
            this.txtHumedad.TabIndex = 9;
            this.txtHumedad.Tag = "Humedad";
            this.txtHumedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHumedad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHumedad_KeyPress);
            // 
            // dtgvSellos
            // 
            this.dtgvSellos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvSellos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmpSello,
            this.Humedad,
            this.cmpAu,
            this.cmpAg,
            this.Weight});
            this.dtgvSellos.Location = new System.Drawing.Point(15, 156);
            this.dtgvSellos.Name = "dtgvSellos";
            this.dtgvSellos.Size = new System.Drawing.Size(570, 209);
            this.dtgvSellos.TabIndex = 120;
            // 
            // cmpSello
            // 
            this.cmpSello.HeaderText = "Sello";
            this.cmpSello.Name = "cmpSello";
            // 
            // Humedad
            // 
            this.Humedad.HeaderText = "Humedad";
            this.Humedad.Name = "Humedad";
            // 
            // cmpAu
            // 
            this.cmpAu.HeaderText = "Au";
            this.cmpAu.Name = "cmpAu";
            // 
            // cmpAg
            // 
            this.cmpAg.HeaderText = "Ag";
            this.cmpAg.Name = "cmpAg";
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionar.Image = global::DBMETAL_SHARP.Properties.Resources.add;
            this.btnAdicionar.Location = new System.Drawing.Point(556, 127);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdicionar.Size = new System.Drawing.Size(24, 22);
            this.btnAdicionar.TabIndex = 13;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtAg
            // 
            this.txtAg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAg.ForeColor = System.Drawing.Color.Navy;
            this.txtAg.Location = new System.Drawing.Point(359, 128);
            this.txtAg.MaxLength = 5;
            this.txtAg.Name = "txtAg";
            this.txtAg.Size = new System.Drawing.Size(88, 20);
            this.txtAg.TabIndex = 11;
            this.txtAg.Tag = "Ag";
            this.txtAg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAg_KeyPress);
            // 
            // txtAu
            // 
            this.txtAu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAu.ForeColor = System.Drawing.Color.Navy;
            this.txtAu.Location = new System.Drawing.Point(259, 128);
            this.txtAu.MaxLength = 5;
            this.txtAu.Name = "txtAu";
            this.txtAu.Size = new System.Drawing.Size(88, 20);
            this.txtAu.TabIndex = 10;
            this.txtAu.Tag = "Au";
            this.txtAu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAu_KeyPress);
            // 
            // txtSellos
            // 
            this.txtSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellos.ForeColor = System.Drawing.Color.Navy;
            this.txtSellos.Location = new System.Drawing.Point(58, 128);
            this.txtSellos.MaxLength = 50;
            this.txtSellos.Name = "txtSellos";
            this.txtSellos.Size = new System.Drawing.Size(95, 20);
            this.txtSellos.TabIndex = 8;
            this.txtSellos.Tag = "Sello";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(393, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 16);
            this.label18.TabIndex = 115;
            this.label18.Text = "0,3";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(296, 81);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 16);
            this.label19.TabIndex = 114;
            this.label19.Text = "1";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Navy;
            this.label20.Location = new System.Drawing.Point(17, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 16);
            this.label20.TabIndex = 113;
            this.label20.Text = "Limite Detec.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(376, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 16);
            this.label15.TabIndex = 112;
            this.label15.Text = "AAS12C";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(280, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 16);
            this.label16.TabIndex = 111;
            this.label16.Text = "FAG303";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(18, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 16);
            this.label17.TabIndex = 110;
            this.label17.Text = "Método";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(386, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 16);
            this.label12.TabIndex = 109;
            this.label12.Text = "PPM";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(285, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 16);
            this.label13.TabIndex = 108;
            this.label13.Text = "G/TM";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(17, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 16);
            this.label14.TabIndex = 107;
            this.label14.Text = "Unidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(391, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 16);
            this.label9.TabIndex = 106;
            this.label9.Text = "Ag";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(291, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 16);
            this.label7.TabIndex = 105;
            this.label7.Text = "Au";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(18, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 104;
            this.label6.Text = "Elemento";
            // 
            // FrmReclamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 546);
            this.Controls.Add(this.gbSellos);
            this.Controls.Add(this.gbEncabezado);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmReclamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBMETAL - Reclamos";
            this.Load += new System.EventHandler(this.FrmReclamos_Load);
            this.gbEncabezado.ResumeLayout(false);
            this.gbEncabezado.PerformLayout();
            this.gbSellos.ResumeLayout(false);
            this.gbSellos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSellos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox gbEncabezado;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtNumMuestras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaRecepcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNumOrden;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbSellos;
        private System.Windows.Forms.DataGridView dtgvSellos;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtAg;
        private System.Windows.Forms.TextBox txtAu;
        private System.Windows.Forms.TextBox txtSellos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpSello;
        private System.Windows.Forms.DataGridViewTextBoxColumn Humedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpAu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpAg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHumedad;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.Label label28;
    }
}
namespace DBMETAL_SHARP
{
    partial class FrmReanalisis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReanalisis));
            this.gbSellos = new System.Windows.Forms.GroupBox();
            this.dtgvSellos = new System.Windows.Forms.DataGridView();
            this.cmpSello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmpAu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmpAu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtAu2 = new System.Windows.Forms.TextBox();
            this.txtAu1 = new System.Windows.Forms.TextBox();
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEncabezado = new System.Windows.Forms.GroupBox();
            this.dthReporte = new System.Windows.Forms.DateTimePicker();
            this.dthIngreso = new System.Windows.Forms.DateTimePicker();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtNumMuestras = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaReporte = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNumOrden = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTipoAnalisis = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.gbSellos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSellos)).BeginInit();
            this.gbEncabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSellos
            // 
            this.gbSellos.Controls.Add(this.dtgvSellos);
            this.gbSellos.Controls.Add(this.btnAdicionar);
            this.gbSellos.Controls.Add(this.txtAu2);
            this.gbSellos.Controls.Add(this.txtAu1);
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
            this.gbSellos.Location = new System.Drawing.Point(9, 215);
            this.gbSellos.Name = "gbSellos";
            this.gbSellos.Size = new System.Drawing.Size(401, 322);
            this.gbSellos.TabIndex = 106;
            this.gbSellos.TabStop = false;
            // 
            // dtgvSellos
            // 
            this.dtgvSellos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvSellos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmpSello,
            this.cmpAu1,
            this.cmpAu2});
            this.dtgvSellos.Location = new System.Drawing.Point(26, 126);
            this.dtgvSellos.Name = "dtgvSellos";
            this.dtgvSellos.Size = new System.Drawing.Size(348, 181);
            this.dtgvSellos.TabIndex = 120;
            // 
            // cmpSello
            // 
            this.cmpSello.HeaderText = "Sello";
            this.cmpSello.Name = "cmpSello";
            // 
            // cmpAu1
            // 
            this.cmpAu1.HeaderText = "Au";
            this.cmpAu1.Name = "cmpAu1";
            // 
            // cmpAu2
            // 
            this.cmpAu2.HeaderText = "Au";
            this.cmpAu2.Name = "cmpAu2";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionar.Image = global::DBMETAL_SHARP.Properties.Resources.add;
            this.btnAdicionar.Location = new System.Drawing.Point(360, 97);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdicionar.Size = new System.Drawing.Size(24, 23);
            this.btnAdicionar.TabIndex = 14;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtAu2
            // 
            this.txtAu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAu2.ForeColor = System.Drawing.Color.Navy;
            this.txtAu2.Location = new System.Drawing.Point(268, 99);
            this.txtAu2.MaxLength = 5;
            this.txtAu2.Name = "txtAu2";
            this.txtAu2.Size = new System.Drawing.Size(88, 20);
            this.txtAu2.TabIndex = 13;
            this.txtAu2.Tag = "Au2";
            this.txtAu2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAu2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAu2_KeyPress);
            // 
            // txtAu1
            // 
            this.txtAu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAu1.ForeColor = System.Drawing.Color.Navy;
            this.txtAu1.Location = new System.Drawing.Point(171, 99);
            this.txtAu1.MaxLength = 5;
            this.txtAu1.Name = "txtAu1";
            this.txtAu1.Size = new System.Drawing.Size(88, 20);
            this.txtAu1.TabIndex = 12;
            this.txtAu1.Tag = "Au";
            this.txtAu1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAu1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAu1_KeyPress);
            // 
            // txtSellos
            // 
            this.txtSellos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellos.ForeColor = System.Drawing.Color.Navy;
            this.txtSellos.Location = new System.Drawing.Point(69, 99);
            this.txtSellos.MaxLength = 50;
            this.txtSellos.Name = "txtSellos";
            this.txtSellos.Size = new System.Drawing.Size(95, 20);
            this.txtSellos.TabIndex = 11;
            this.txtSellos.Tag = "Sello";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(301, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 16);
            this.label18.TabIndex = 115;
            this.label18.Text = "0,2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(201, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 16);
            this.label19.TabIndex = 114;
            this.label19.Text = "0,2";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Navy;
            this.label20.Location = new System.Drawing.Point(24, 81);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(142, 16);
            this.label20.TabIndex = 113;
            this.label20.Text = "Limite Detec. (ppm)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(278, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 16);
            this.label15.TabIndex = 112;
            this.label15.Text = "FA+GRAV";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(188, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 16);
            this.label16.TabIndex = 111;
            this.label16.Text = "FA+AA";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(25, 60);
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
            this.label12.Location = new System.Drawing.Point(293, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 109;
            this.label12.Text = "gr/ton";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(193, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 16);
            this.label13.TabIndex = 108;
            this.label13.Text = "gr/ton";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(24, 38);
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
            this.label9.Location = new System.Drawing.Point(302, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 16);
            this.label9.TabIndex = 106;
            this.label9.Text = "Au";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(201, 18);
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
            this.label6.Location = new System.Drawing.Point(61, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 104;
            this.label6.Text = "Elemento";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::DBMETAL_SHARP.Properties.Resources.trash_full;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(431, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 40);
            this.btnDelete.TabIndex = 105;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(650, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 40);
            this.btnExit.TabIndex = 104;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DBMETAL_SHARP.Properties.Resources.save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(596, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.TabIndex = 102;
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
            this.btnNew.Location = new System.Drawing.Point(542, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.TabIndex = 103;
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
            this.label1.Location = new System.Drawing.Point(-3, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(722, 53);
            this.label1.TabIndex = 98;
            this.label1.Text = "Reanálisis Químico";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbEncabezado
            // 
            this.gbEncabezado.Controls.Add(this.dthReporte);
            this.gbEncabezado.Controls.Add(this.dthIngreso);
            this.gbEncabezado.Controls.Add(this.btnIngresar);
            this.gbEncabezado.Controls.Add(this.txtNumMuestras);
            this.gbEncabezado.Controls.Add(this.label4);
            this.gbEncabezado.Controls.Add(this.dtpFechaReporte);
            this.gbEncabezado.Controls.Add(this.label3);
            this.gbEncabezado.Controls.Add(this.dtpFechaIngreso);
            this.gbEncabezado.Controls.Add(this.label2);
            this.gbEncabezado.Controls.Add(this.btnBuscar);
            this.gbEncabezado.Controls.Add(this.txtNumOrden);
            this.gbEncabezado.Controls.Add(this.label11);
            this.gbEncabezado.Controls.Add(this.txtTipoAnalisis);
            this.gbEncabezado.Controls.Add(this.label8);
            this.gbEncabezado.Controls.Add(this.txtDescripcion);
            this.gbEncabezado.Controls.Add(this.label5);
            this.gbEncabezado.Controls.Add(this.txtCliente);
            this.gbEncabezado.Controls.Add(this.label10);
            this.gbEncabezado.Location = new System.Drawing.Point(9, 54);
            this.gbEncabezado.Name = "gbEncabezado";
            this.gbEncabezado.Size = new System.Drawing.Size(696, 164);
            this.gbEncabezado.TabIndex = 107;
            this.gbEncabezado.TabStop = false;
            // 
            // dthReporte
            // 
            this.dthReporte.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dthReporte.Location = new System.Drawing.Point(530, 43);
            this.dthReporte.Name = "dthReporte";
            this.dthReporte.ShowUpDown = true;
            this.dthReporte.Size = new System.Drawing.Size(91, 20);
            this.dthReporte.TabIndex = 5;
            this.dthReporte.Tag = "Hora Ingreso";
            // 
            // dthIngreso
            // 
            this.dthIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dthIngreso.Location = new System.Drawing.Point(226, 43);
            this.dthIngreso.Name = "dthIngreso";
            this.dthIngreso.ShowUpDown = true;
            this.dthIngreso.Size = new System.Drawing.Size(89, 20);
            this.dthIngreso.TabIndex = 3;
            this.dthIngreso.Tag = "Hora Ingreso";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Image = global::DBMETAL_SHARP.Properties.Resources.red;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIngresar.Location = new System.Drawing.Point(611, 77);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(61, 40);
            this.btnIngresar.TabIndex = 10;
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
            this.txtNumMuestras.Location = new System.Drawing.Point(498, 75);
            this.txtNumMuestras.MaxLength = 2;
            this.txtNumMuestras.Name = "txtNumMuestras";
            this.txtNumMuestras.Size = new System.Drawing.Size(88, 20);
            this.txtNumMuestras.TabIndex = 7;
            this.txtNumMuestras.Tag = "Número de Muestras";
            this.txtNumMuestras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumMuestras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumMuestras_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(396, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 118;
            this.label4.Text = "* # de Muestras";
            // 
            // dtpFechaReporte
            // 
            this.dtpFechaReporte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReporte.Location = new System.Drawing.Point(447, 43);
            this.dtpFechaReporte.Name = "dtpFechaReporte";
            this.dtpFechaReporte.Size = new System.Drawing.Size(81, 20);
            this.dtpFechaReporte.TabIndex = 4;
            this.dtpFechaReporte.Tag = "Fecha Reporte";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(339, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 115;
            this.label3.Text = "* Fecha Reporte";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(139, 43);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaIngreso.TabIndex = 2;
            this.dtpFechaIngreso.Tag = "Fecha Ingreso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(24, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 113;
            this.label2.Text = "* Fecha Ingreso";
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
            this.label11.Location = new System.Drawing.Point(25, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 111;
            this.label11.Text = "* # Orden";
            // 
            // txtTipoAnalisis
            // 
            this.txtTipoAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoAnalisis.ForeColor = System.Drawing.Color.Navy;
            this.txtTipoAnalisis.Location = new System.Drawing.Point(139, 132);
            this.txtTipoAnalisis.MaxLength = 50;
            this.txtTipoAnalisis.Name = "txtTipoAnalisis";
            this.txtTipoAnalisis.Size = new System.Drawing.Size(240, 20);
            this.txtTipoAnalisis.TabIndex = 9;
            this.txtTipoAnalisis.Tag = "Tipo Análisis";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(24, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 16);
            this.label8.TabIndex = 110;
            this.label8.Text = "* Tipo de Análisis";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.txtDescripcion.Location = new System.Drawing.Point(138, 103);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(448, 20);
            this.txtDescripcion.TabIndex = 8;
            this.txtDescripcion.Tag = "Descripción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(24, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 108;
            this.label5.Text = "Descripción";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Navy;
            this.txtCliente.Location = new System.Drawing.Point(138, 73);
            this.txtCliente.MaxLength = 100;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(246, 20);
            this.txtCliente.TabIndex = 6;
            this.txtCliente.Tag = "Cliente";
            this.txtCliente.Leave += new System.EventHandler(this.txtCliente_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(25, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 16);
            this.label10.TabIndex = 109;
            this.label10.Text = "* Cliente";
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::DBMETAL_SHARP.Properties.Resources.print;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcesar.Location = new System.Drawing.Point(485, 7);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(58, 40);
            this.btnProcesar.TabIndex = 108;
            this.btnProcesar.Text = "Imprimir";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Navy;
            this.label21.Location = new System.Drawing.Point(423, 226);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 16);
            this.label21.TabIndex = 124;
            this.label21.Text = "NOTAS";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(426, 250);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(277, 202);
            this.txtNotas.TabIndex = 125;
            // 
            // FrmReanalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 546);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.gbEncabezado);
            this.Controls.Add(this.gbSellos);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmReanalisis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBMETAL - Reanálisis Químico";
            this.Load += new System.EventHandler(this.FrmReanalisis_Load);
            this.gbSellos.ResumeLayout(false);
            this.gbSellos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSellos)).EndInit();
            this.gbEncabezado.ResumeLayout(false);
            this.gbEncabezado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox gbSellos;
        private System.Windows.Forms.DataGridView dtgvSellos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpSello;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpAu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmpAu2;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtAu2;
        private System.Windows.Forms.TextBox txtAu1;
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
        private System.Windows.Forms.GroupBox gbEncabezado;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtNumMuestras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNumOrden;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTipoAnalisis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dthIngreso;
        private System.Windows.Forms.DateTimePicker dthReporte;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtNotas;
    }
}
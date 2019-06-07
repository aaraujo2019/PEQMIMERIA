namespace DBMETAL_SHARP
{
    partial class Frm_DetalleLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DetalleLiquidacion));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CmbPeriodos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkMarcar = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Continuo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripBtnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripTxbRegistros = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripTxbDetalle = new System.Windows.Forms.ToolStripTextBox();
            this.RtbBodyMail = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnImprimirSeleccion = new System.Windows.Forms.Button();
            this.BtnEnviarMail = new System.Windows.Forms.Button();
            this.BtnRefrescar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ChbOmitirDamasa = new System.Windows.Forms.CheckBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnPicture2 = new System.Windows.Forms.Button();
            this.PtbLogo2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnPicture1 = new System.Windows.Forms.Button();
            this.PtbLogo1 = new System.Windows.Forms.PictureBox();
            this.BtnEnvioDamasa = new System.Windows.Forms.Button();
            this.ChbOmitirMasora = new System.Windows.Forms.CheckBox();
            this.BtnEnvioMasora = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbLogo2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbLogo1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.CmbPeriodos);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(13, 11);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(534, 50);
            this.groupBox6.TabIndex = 85;
            this.groupBox6.TabStop = false;
            // 
            // CmbPeriodos
            // 
            this.CmbPeriodos.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CmbPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPeriodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPeriodos.FormattingEnabled = true;
            this.CmbPeriodos.Location = new System.Drawing.Point(53, 12);
            this.CmbPeriodos.Name = "CmbPeriodos";
            this.CmbPeriodos.Size = new System.Drawing.Size(468, 33);
            this.CmbPeriodos.TabIndex = 2;
            this.CmbPeriodos.SelectionChangeCommitted += new System.EventHandler(this.CmbPeriodos_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Periodo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkMarcar);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 421);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            // 
            // ChkMarcar
            // 
            this.ChkMarcar.AutoSize = true;
            this.ChkMarcar.Location = new System.Drawing.Point(15, 17);
            this.ChkMarcar.Name = "ChkMarcar";
            this.ChkMarcar.Size = new System.Drawing.Size(15, 14);
            this.ChkMarcar.TabIndex = 2;
            this.ChkMarcar.UseVisualStyleBackColor = true;
            this.ChkMarcar.CheckedChanged += new System.EventHandler(this.ChkMarcar_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Continuo});
            this.dataGridView1.Location = new System.Drawing.Point(12, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.Size = new System.Drawing.Size(826, 396);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // Continuo
            // 
            this.Continuo.HeaderText = "Enviar";
            this.Continuo.Name = "Continuo";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnRefrescar,
            this.ToolStripTxbRegistros,
            this.toolStripSeparator1,
            this.ToolStripTxbDetalle});
            this.toolStrip1.Location = new System.Drawing.Point(0, 680);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 27);
            this.toolStrip1.TabIndex = 100;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripBtnRefrescar
            // 
            this.ToolStripBtnRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripBtnRefrescar.Image = global::DBMETAL_SHARP.Properties.Resources.apps_16;
            this.ToolStripBtnRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripBtnRefrescar.Name = "ToolStripBtnRefrescar";
            this.ToolStripBtnRefrescar.Size = new System.Drawing.Size(24, 24);
            this.ToolStripBtnRefrescar.Text = "toolStripButton1";
            this.ToolStripBtnRefrescar.Click += new System.EventHandler(this.ToolStripBtnRefrescar_Click);
            // 
            // ToolStripTxbRegistros
            // 
            this.ToolStripTxbRegistros.AutoSize = false;
            this.ToolStripTxbRegistros.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ToolStripTxbRegistros.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.ToolStripTxbRegistros.Name = "ToolStripTxbRegistros";
            this.ToolStripTxbRegistros.Size = new System.Drawing.Size(200, 20);
            this.ToolStripTxbRegistros.Enter += new System.EventHandler(this.ToolStripTxbRegistros_Enter);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // ToolStripTxbDetalle
            // 
            this.ToolStripTxbDetalle.AutoSize = false;
            this.ToolStripTxbDetalle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ToolStripTxbDetalle.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.ToolStripTxbDetalle.Name = "ToolStripTxbDetalle";
            this.ToolStripTxbDetalle.Size = new System.Drawing.Size(620, 20);
            // 
            // RtbBodyMail
            // 
            this.RtbBodyMail.Location = new System.Drawing.Point(12, 593);
            this.RtbBodyMail.Name = "RtbBodyMail";
            this.RtbBodyMail.Size = new System.Drawing.Size(870, 70);
            this.RtbBodyMail.TabIndex = 102;
            this.RtbBodyMail.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(12, 577);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 103;
            this.label3.Text = "Detalle o cuerpo del email";
            // 
            // BtnImprimirSeleccion
            // 
            this.BtnImprimirSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimirSeleccion.Image = global::DBMETAL_SHARP.Properties.Resources.lgicn_16;
            this.BtnImprimirSeleccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnImprimirSeleccion.Location = new System.Drawing.Point(533, 3);
            this.BtnImprimirSeleccion.Name = "BtnImprimirSeleccion";
            this.BtnImprimirSeleccion.Size = new System.Drawing.Size(92, 40);
            this.BtnImprimirSeleccion.TabIndex = 104;
            this.BtnImprimirSeleccion.Text = "Check Seleccion";
            this.BtnImprimirSeleccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnImprimirSeleccion.UseVisualStyleBackColor = true;
            this.BtnImprimirSeleccion.Click += new System.EventHandler(this.BtnImprimirSeleccion_Click);
            // 
            // BtnEnviarMail
            // 
            this.BtnEnviarMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviarMail.Image = global::DBMETAL_SHARP.Properties.Resources.mail;
            this.BtnEnviarMail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEnviarMail.Location = new System.Drawing.Point(460, 3);
            this.BtnEnviarMail.Name = "BtnEnviarMail";
            this.BtnEnviarMail.Size = new System.Drawing.Size(75, 40);
            this.BtnEnviarMail.TabIndex = 101;
            this.BtnEnviarMail.Text = "Enviar e-mail";
            this.BtnEnviarMail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEnviarMail.UseVisualStyleBackColor = true;
            this.BtnEnviarMail.Click += new System.EventHandler(this.BtnEnviarMail_Click);
            // 
            // BtnRefrescar
            // 
            this.BtnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefrescar.Image = global::DBMETAL_SHARP.Properties.Resources.refresh;
            this.BtnRefrescar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRefrescar.Location = new System.Drawing.Point(727, 3);
            this.BtnRefrescar.Name = "BtnRefrescar";
            this.BtnRefrescar.Size = new System.Drawing.Size(60, 40);
            this.BtnRefrescar.TabIndex = 99;
            this.BtnRefrescar.Text = "Refrescar";
            this.BtnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRefrescar.UseVisualStyleBackColor = true;
            this.BtnRefrescar.Click += new System.EventHandler(this.BtnRefrescar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::DBMETAL_SHARP.Properties.Resources.printer_setup1;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(623, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(106, 40);
            this.btnImprimir.TabIndex = 95;
            this.btnImprimir.Text = "Revisar Liquidacion";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = global::DBMETAL_SHARP.Properties.Resources.new_16;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(785, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(50, 40);
            this.btnNuevo.TabIndex = 93;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::DBMETAL_SHARP.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(833, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 40);
            this.btnExit.TabIndex = 96;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Image = global::DBMETAL_SHARP.Properties.Resources.OndadegradadaL;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(902, 45);
            this.label1.TabIndex = 97;
            this.label1.Text = "Liquidacion de Mineral";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPage1);
            this.tabControl1.Controls.Add(this.TabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 53);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(881, 518);
            this.tabControl1.TabIndex = 105;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TabPage1.Controls.Add(this.ChbOmitirMasora);
            this.TabPage1.Controls.Add(this.ChbOmitirDamasa);
            this.TabPage1.Controls.Add(this.groupBox6);
            this.TabPage1.Controls.Add(this.groupBox1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.TabPage1.Size = new System.Drawing.Size(873, 492);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Liquidacion";
            // 
            // ChbOmitirDamasa
            // 
            this.ChbOmitirDamasa.AutoSize = true;
            this.ChbOmitirDamasa.Location = new System.Drawing.Point(559, 17);
            this.ChbOmitirDamasa.Name = "ChbOmitirDamasa";
            this.ChbOmitirDamasa.Size = new System.Drawing.Size(193, 17);
            this.ChbOmitirDamasa.TabIndex = 99;
            this.ChbOmitirDamasa.Text = "Omitir Proyectos del Grupo Damasa";
            this.ChbOmitirDamasa.UseVisualStyleBackColor = true;
            this.ChbOmitirDamasa.CheckedChanged += new System.EventHandler(this.ChbOmitirDamasa_CheckedChanged);
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TabPage2.Controls.Add(this.groupBox3);
            this.TabPage2.Controls.Add(this.groupBox2);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.TabPage2.Size = new System.Drawing.Size(873, 492);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Imagenes Publicitarias";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnPicture2);
            this.groupBox3.Controls.Add(this.PtbLogo2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(446, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 423);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Segunda Derecha";
            // 
            // BtnPicture2
            // 
            this.BtnPicture2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPicture2.ForeColor = System.Drawing.Color.Navy;
            this.BtnPicture2.Location = new System.Drawing.Point(26, 385);
            this.BtnPicture2.Name = "BtnPicture2";
            this.BtnPicture2.Size = new System.Drawing.Size(371, 24);
            this.BtnPicture2.TabIndex = 52;
            this.BtnPicture2.Text = "Seleccionar Imagen";
            this.BtnPicture2.UseVisualStyleBackColor = true;
            this.BtnPicture2.Click += new System.EventHandler(this.BtnPicture2_Click);
            // 
            // PtbLogo2
            // 
            this.PtbLogo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PtbLogo2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PtbLogo2.Location = new System.Drawing.Point(26, 20);
            this.PtbLogo2.Name = "PtbLogo2";
            this.PtbLogo2.Size = new System.Drawing.Size(372, 360);
            this.PtbLogo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PtbLogo2.TabIndex = 51;
            this.PtbLogo2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnPicture1);
            this.groupBox2.Controls.Add(this.PtbLogo1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(15, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 423);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Primera Izquierda";
            // 
            // BtnPicture1
            // 
            this.BtnPicture1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPicture1.ForeColor = System.Drawing.Color.Navy;
            this.BtnPicture1.Location = new System.Drawing.Point(19, 389);
            this.BtnPicture1.Name = "BtnPicture1";
            this.BtnPicture1.Size = new System.Drawing.Size(371, 24);
            this.BtnPicture1.TabIndex = 52;
            this.BtnPicture1.Text = "Seleccionar Imagen";
            this.BtnPicture1.UseVisualStyleBackColor = true;
            this.BtnPicture1.Click += new System.EventHandler(this.BtnPicture1_Click);
            // 
            // PtbLogo1
            // 
            this.PtbLogo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PtbLogo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PtbLogo1.Location = new System.Drawing.Point(19, 20);
            this.PtbLogo1.Name = "PtbLogo1";
            this.PtbLogo1.Size = new System.Drawing.Size(372, 360);
            this.PtbLogo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PtbLogo1.TabIndex = 51;
            this.PtbLogo1.TabStop = false;
            // 
            // BtnEnvioDamasa
            // 
            this.BtnEnvioDamasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnvioDamasa.Image = global::DBMETAL_SHARP.Properties.Resources.mail;
            this.BtnEnvioDamasa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEnvioDamasa.Location = new System.Drawing.Point(378, 3);
            this.BtnEnvioDamasa.Name = "BtnEnvioDamasa";
            this.BtnEnvioDamasa.Size = new System.Drawing.Size(84, 40);
            this.BtnEnvioDamasa.TabIndex = 106;
            this.BtnEnvioDamasa.Text = "e-mail Damasa";
            this.BtnEnvioDamasa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEnvioDamasa.UseVisualStyleBackColor = true;
            this.BtnEnvioDamasa.Click += new System.EventHandler(this.BtnEnvioDamasa_Click);
            // 
            // ChbOmitirMasora
            // 
            this.ChbOmitirMasora.AutoSize = true;
            this.ChbOmitirMasora.Location = new System.Drawing.Point(559, 40);
            this.ChbOmitirMasora.Name = "ChbOmitirMasora";
            this.ChbOmitirMasora.Size = new System.Drawing.Size(189, 17);
            this.ChbOmitirMasora.TabIndex = 100;
            this.ChbOmitirMasora.Text = "Omitir Proyectos del Grupo Masora";
            this.ChbOmitirMasora.UseVisualStyleBackColor = true;
            this.ChbOmitirMasora.CheckedChanged += new System.EventHandler(this.ChbOmitirMasora_CheckedChanged);
            // 
            // BtnEnvioMasora
            // 
            this.BtnEnvioMasora.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnvioMasora.Image = global::DBMETAL_SHARP.Properties.Resources.mail;
            this.BtnEnvioMasora.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEnvioMasora.Location = new System.Drawing.Point(296, 3);
            this.BtnEnvioMasora.Name = "BtnEnvioMasora";
            this.BtnEnvioMasora.Size = new System.Drawing.Size(84, 40);
            this.BtnEnvioMasora.TabIndex = 107;
            this.BtnEnvioMasora.Text = "e-mail Masora";
            this.BtnEnvioMasora.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEnvioMasora.UseVisualStyleBackColor = true;
            this.BtnEnvioMasora.Click += new System.EventHandler(this.BtnEnvioMasora_Click);
            // 
            // Frm_DetalleLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 707);
            this.Controls.Add(this.BtnEnvioMasora);
            this.Controls.Add(this.BtnEnvioDamasa);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BtnImprimirSeleccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RtbBodyMail);
            this.Controls.Add(this.BtnEnviarMail);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.BtnRefrescar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_DetalleLiquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte liquidacion de mineral";
            this.Load += new System.EventHandler(this.Frm_DetalleLiquidacion_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PtbLogo2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PtbLogo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CmbPeriodos;
        private System.Windows.Forms.Button BtnRefrescar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Continuo;
        private System.Windows.Forms.CheckBox ChkMarcar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox ToolStripTxbRegistros;
        private System.Windows.Forms.ToolStripButton ToolStripBtnRefrescar;
        private System.Windows.Forms.Button BtnEnviarMail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox ToolStripTxbDetalle;
        private System.Windows.Forms.RichTextBox RtbBodyMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnImprimirSeleccion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnPicture2;
        private System.Windows.Forms.PictureBox PtbLogo2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnPicture1;
        private System.Windows.Forms.PictureBox PtbLogo1;
        private System.Windows.Forms.Button BtnEnvioDamasa;
        private System.Windows.Forms.CheckBox ChbOmitirDamasa;
        private System.Windows.Forms.CheckBox ChbOmitirMasora;
        private System.Windows.Forms.Button BtnEnvioMasora;
    }
}
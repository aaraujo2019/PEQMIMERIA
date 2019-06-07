namespace DBMETAL_SHARP
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.TstLabelDetalle = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsbtnMuestra1 = new System.Windows.Forms.ToolStripButton();
            this.TsbtnMuestra2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.TsbtnHumedad = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbtnMuestra1,
            this.TsbtnMuestra2,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.TsbtnHumedad});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1107, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TstLabelDetalle});
            this.statusStrip.Location = new System.Drawing.Point(0, 240);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1107, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // TstLabelDetalle
            // 
            this.TstLabelDetalle.Name = "TstLabelDetalle";
            this.TstLabelDetalle.Size = new System.Drawing.Size(118, 17);
            this.TstLabelDetalle.Text = "toolStripStatusLabel1";
            // 
            // TsbtnMuestra1
            // 
            this.TsbtnMuestra1.AutoSize = false;
            this.TsbtnMuestra1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnMuestra1.Image = global::DBMETAL_SHARP.Properties.Resources.SGS_1;
            this.TsbtnMuestra1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnMuestra1.Name = "TsbtnMuestra1";
            this.TsbtnMuestra1.Size = new System.Drawing.Size(60, 60);
            this.TsbtnMuestra1.Text = "Tenor GSG File 1";
            this.TsbtnMuestra1.Click += new System.EventHandler(this.TsbtnMuestra1_Click);
            this.TsbtnMuestra1.MouseLeave += new System.EventHandler(this.TsbtnMuestra1_MouseLeave);
            this.TsbtnMuestra1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsbtnMuestra1_MouseMove);
            // 
            // TsbtnMuestra2
            // 
            this.TsbtnMuestra2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnMuestra2.Image = global::DBMETAL_SHARP.Properties.Resources.SGS_2;
            this.TsbtnMuestra2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnMuestra2.Name = "TsbtnMuestra2";
            this.TsbtnMuestra2.Size = new System.Drawing.Size(44, 52);
            this.TsbtnMuestra2.Text = "Tenor GSG File 2";
            this.TsbtnMuestra2.Click += new System.EventHandler(this.TsbtnMuestra2_Click);
            this.TsbtnMuestra2.MouseLeave += new System.EventHandler(this.TsbtnMuestra2_MouseLeave);
            this.TsbtnMuestra2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsbtnMuestra2_MouseMove);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::DBMETAL_SHARP.Properties.Resources.LogoBarras;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 52);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            this.toolStripButton1.MouseLeave += new System.EventHandler(this.toolStripButton1_MouseLeave);
            this.toolStripButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripButton1_MouseMove);
            // 
            // TsbtnHumedad
            // 
            this.TsbtnHumedad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnHumedad.Image = global::DBMETAL_SHARP.Properties.Resources.color_picker;
            this.TsbtnHumedad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnHumedad.Name = "TsbtnHumedad";
            this.TsbtnHumedad.Size = new System.Drawing.Size(44, 52);
            this.TsbtnHumedad.Text = "Humedad";
            this.TsbtnHumedad.Click += new System.EventHandler(this.TsbtnHumedad_Click);
            this.TsbtnHumedad.MouseLeave += new System.EventHandler(this.TsbtnHumedad_MouseLeave);
            this.TsbtnHumedad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TsbtnHumedad_MouseMove);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1107, 262);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Tenor y Humedad";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsbtnMuestra1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel TstLabelDetalle;
        private System.Windows.Forms.ToolStripButton TsbtnMuestra2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TsbtnHumedad;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}


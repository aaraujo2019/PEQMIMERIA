namespace Reportes.LiquidacionDBMETAL
{
    partial class Frm_Reporte_Liquidacion
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Reporte_Mineras_DetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReporteLiquidacion = new Reportes.LiquidacionDBMETAL.ReporteLiquidacion();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Mineras_DetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteLiquidacion)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_Mineras_DetalleBindingSource
            // 
            this.Reporte_Mineras_DetalleBindingSource.DataSource = this.ReporteLiquidacion;
            this.Reporte_Mineras_DetalleBindingSource.Position = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.Reporte_Mineras_DetalleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(671, 401);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReporteLiquidacion
            // 
            this.ReporteLiquidacion.DataSetName = "ReporteLiquidacion";
            this.ReporteLiquidacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_Reporte_Liquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 401);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Reporte_Liquidacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes Liquidaciòn DBMetal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reprote2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_Mineras_DetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteLiquidacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Reporte_Mineras_DetalleBindingSource;
        private ReporteLiquidacion ReporteLiquidacion;
    }
}
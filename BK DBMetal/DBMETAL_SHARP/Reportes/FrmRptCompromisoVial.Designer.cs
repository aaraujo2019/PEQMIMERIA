namespace Reportes
{
    partial class FrmRptCompromisoVial
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
        /// </summary>f
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Sp_Rpt_CompromisoVialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBMETALDataSet = new Reportes.DBMETALDataSet();
            this.Sp_Rpt_CompromisoVialTableAdapter = new Reportes.DBMETALDataSetTableAdapters.Sp_Rpt_CompromisoVialTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Rpt_CompromisoVialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(576, 451);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Sp_Rpt_CompromisoVialBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Reportes.RptCompromisoVial.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(576, 451);
            this.reportViewer2.TabIndex = 1;
            // 
            // Sp_Rpt_CompromisoVialBindingSource
            // 
            this.Sp_Rpt_CompromisoVialBindingSource.DataMember = "Sp_Rpt_CompromisoVial";
            this.Sp_Rpt_CompromisoVialBindingSource.DataSource = this.DBMETALDataSet;
            // 
            // DBMETALDataSet
            // 
            this.DBMETALDataSet.DataSetName = "DBMETALDataSet";
            this.DBMETALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Sp_Rpt_CompromisoVialTableAdapter
            // 
            this.Sp_Rpt_CompromisoVialTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRptCompromisoVial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 451);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRptCompromisoVial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte Compromiso Vial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRptContratoVial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Rpt_CompromisoVialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource Sp_Rpt_CompromisoVialBindingSource;
        private DBMETALDataSet DBMETALDataSet;
        private DBMETALDataSetTableAdapters.Sp_Rpt_CompromisoVialTableAdapter Sp_Rpt_CompromisoVialTableAdapter;
    }
}


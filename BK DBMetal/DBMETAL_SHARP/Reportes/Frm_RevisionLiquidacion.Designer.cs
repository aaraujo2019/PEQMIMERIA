namespace Reportes
{
    partial class Frm_RevisionLiquidacion
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RevisionLiquidacion));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DBMETALDataSet = new Reportes.DBMETALDataSet();
            this.Rpt_RevisionLiquidacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Rpt_RevisionLiquidacionTableAdapter = new Reportes.DBMETALDataSetTableAdapters.Rpt_RevisionLiquidacionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_RevisionLiquidacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Rpt_RevisionLiquidacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Rpt_RevisionLiquidacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(584, 409);
            this.reportViewer1.TabIndex = 0;
            // 
            // DBMETALDataSet
            // 
            this.DBMETALDataSet.DataSetName = "DBMETALDataSet";
            this.DBMETALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Rpt_RevisionLiquidacionBindingSource
            // 
            this.Rpt_RevisionLiquidacionBindingSource.DataMember = "Rpt_RevisionLiquidacion";
            this.Rpt_RevisionLiquidacionBindingSource.DataSource = this.DBMETALDataSet;
            // 
            // Rpt_RevisionLiquidacionTableAdapter
            // 
            this.Rpt_RevisionLiquidacionTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_RevisionLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 409);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_RevisionLiquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RevisionLiquidacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_RevisionLiquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_RevisionLiquidacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Rpt_RevisionLiquidacionBindingSource;
        private DBMETALDataSet DBMETALDataSet;
        private DBMETALDataSetTableAdapters.Rpt_RevisionLiquidacionTableAdapter Rpt_RevisionLiquidacionTableAdapter;
    }
}
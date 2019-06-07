namespace Reportes
{
    partial class FrmRptProyeccionMineral
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DBMETALDataSet = new Reportes.DBMETALDataSet();
            this.Sp_Rpt_ProyeccionMineralBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Sp_Rpt_ProyeccionMineralTableAdapter = new Reportes.DBMETALDataSetTableAdapters.Sp_Rpt_ProyeccionMineralTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Rpt_ProyeccionMineralBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.Sp_Rpt_ProyeccionMineralBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.RptPRoyeccionMineral.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(884, 462);
            this.reportViewer1.TabIndex = 0;
            // 
            // DBMETALDataSet
            // 
            this.DBMETALDataSet.DataSetName = "DBMETALDataSet";
            this.DBMETALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Sp_Rpt_ProyeccionMineralBindingSource
            // 
            this.Sp_Rpt_ProyeccionMineralBindingSource.DataMember = "Sp_Rpt_ProyeccionMineral";
            this.Sp_Rpt_ProyeccionMineralBindingSource.DataSource = this.DBMETALDataSet;
            // 
            // Sp_Rpt_ProyeccionMineralTableAdapter
            // 
            this.Sp_Rpt_ProyeccionMineralTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRptProyeccionMineral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRptProyeccionMineral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyeccion Mineral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRptProyeccionMineral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Rpt_ProyeccionMineralBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Sp_Rpt_ProyeccionMineralBindingSource;
        private DBMETALDataSet DBMETALDataSet;
        private DBMETALDataSetTableAdapters.Sp_Rpt_ProyeccionMineralTableAdapter Sp_Rpt_ProyeccionMineralTableAdapter;
    }
}
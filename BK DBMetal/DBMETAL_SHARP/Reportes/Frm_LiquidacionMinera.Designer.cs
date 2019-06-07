namespace Reportes
{
    partial class Frm_LiquidacionMinera
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
            this.Rpt_LiquidacionMineraGraficaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBMETALDataSet = new Reportes.DBMETALDataSet();
            this.Rpt_LiquidacionMineraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Rpt_LiquidacionMineraTableAdapter = new Reportes.DBMETALDataSetTableAdapters.Rpt_LiquidacionMineraTableAdapter();
            this.Rpt_LiquidacionMineraGraficaTableAdapter = new Reportes.DBMETALDataSetTableAdapters.Rpt_LiquidacionMineraGraficaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_LiquidacionMineraGraficaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_LiquidacionMineraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rpt_LiquidacionMineraGraficaBindingSource
            // 
            this.Rpt_LiquidacionMineraGraficaBindingSource.DataMember = "Rpt_LiquidacionMineraGrafica";
            this.Rpt_LiquidacionMineraGraficaBindingSource.DataSource = this.DBMETALDataSet;
            // 
            // DBMETALDataSet
            // 
            this.DBMETALDataSet.DataSetName = "DBMETALDataSet";
            this.DBMETALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Rpt_LiquidacionMineraBindingSource
            // 
            this.Rpt_LiquidacionMineraBindingSource.DataMember = "Rpt_LiquidacionMinera";
            this.Rpt_LiquidacionMineraBindingSource.DataSource = this.DBMETALDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Rpt_LiquidacionMineraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Rpt_LiquidacionMinera.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(667, 397);
            this.reportViewer1.TabIndex = 0;
            // 
            // Rpt_LiquidacionMineraTableAdapter
            // 
            this.Rpt_LiquidacionMineraTableAdapter.ClearBeforeFill = true;
            // 
            // Rpt_LiquidacionMineraGraficaTableAdapter
            // 
            this.Rpt_LiquidacionMineraGraficaTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_LiquidacionMinera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 397);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Frm_LiquidacionMinera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion Minera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_LiquidacionMinera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_LiquidacionMineraGraficaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_LiquidacionMineraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Rpt_LiquidacionMineraBindingSource;
        private DBMETALDataSet DBMETALDataSet;
        private DBMETALDataSetTableAdapters.Rpt_LiquidacionMineraTableAdapter Rpt_LiquidacionMineraTableAdapter;
        private System.Windows.Forms.BindingSource Rpt_LiquidacionMineraGraficaBindingSource;
        private DBMETALDataSetTableAdapters.Rpt_LiquidacionMineraGraficaTableAdapter Rpt_LiquidacionMineraGraficaTableAdapter;
    }
}
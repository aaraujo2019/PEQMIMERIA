namespace Reportes
{
    partial class Frm_LiquidacionConsolidadaGrupoMasora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LiquidacionConsolidadaGrupoMasora));
            this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBMETALDataSet = new Reportes.DBMETALDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraTableAdapter = new Reportes.DBMETALDataSetTableAdapters.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource
            // 
            this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource.DataMember = "Sp_Rpt_LiquidacionConsolidadaGrupoMasora";
            this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource.DataSource = this.DBMETALDataSet;
            // 
            // DBMETALDataSet
            // 
            this.DBMETALDataSet.DataSetName = "DBMETALDataSet";
            this.DBMETALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Rpt_LiquidacionConsolidadaGrupoMasora.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(684, 452);
            this.reportViewer1.TabIndex = 0;
            // 
            // Sp_Rpt_LiquidacionConsolidadaGrupoMasoraTableAdapter
            // 
            this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_LiquidacionConsolidadaGrupoMasora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 452);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_LiquidacionConsolidadaGrupoMasora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion Consolidada Grupo Masora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_LiquidacionConsolidadaGrupoMasora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBMETALDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Sp_Rpt_LiquidacionConsolidadaGrupoMasoraBindingSource;
        private DBMETALDataSet DBMETALDataSet;
        private DBMETALDataSetTableAdapters.Sp_Rpt_LiquidacionConsolidadaGrupoMasoraTableAdapter Sp_Rpt_LiquidacionConsolidadaGrupoMasoraTableAdapter;
    }
}
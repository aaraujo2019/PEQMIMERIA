namespace Reportes
{
    partial class Frm_LiqudacionDBMETALMina
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
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_Mineras_DetalleTableAdapter1 = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_DetalleTableAdapter();
            this.reporte_Mineras_DetalleTableAdapter2 = new Reportes.LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_DetalleTableAdapter();
            this.reporteLiquidacion2 = new Reportes.LiquidacionDBMETAL.ReporteLiquidacion();
            this.dbmetalDataSet1 = new Reportes.DBMETALDataSet();
            this.reporteLiquidacion1 = new Reportes.LiquidacionDBMETAL.ReporteLiquidacion();
            ((System.ComponentModel.ISupportInitialize)(this.reporteLiquidacion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbmetalDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteLiquidacion1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Reportes.LiquidacionDBMETAL.Report1.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(953, 381);
            this.reportViewer2.TabIndex = 0;
            // 
            // reporte_Mineras_DetalleTableAdapter1
            // 
            this.reporte_Mineras_DetalleTableAdapter1.ClearBeforeFill = true;
            // 
            // reporte_Mineras_DetalleTableAdapter2
            // 
            this.reporte_Mineras_DetalleTableAdapter2.ClearBeforeFill = true;
            // 
            // reporteLiquidacion2
            // 
            this.reporteLiquidacion2.DataSetName = "ReporteLiquidacion";
            this.reporteLiquidacion2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbmetalDataSet1
            // 
            this.dbmetalDataSet1.DataSetName = "DBMETALDataSet";
            this.dbmetalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteLiquidacion1
            // 
            this.reporteLiquidacion1.DataSetName = "ReporteLiquidacion";
            this.reporteLiquidacion1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_LiqudacionDBMETALMina
            // 
            this.ClientSize = new System.Drawing.Size(953, 381);
            this.Controls.Add(this.reportViewer2);
            this.Name = "Frm_LiqudacionDBMETALMina";
            this.Load += new System.EventHandler(this.Frm_LiqudacionDBMETALMina_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.reporteLiquidacion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbmetalDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteLiquidacion1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_DetalleTableAdapter reporte_Mineras_DetalleTableAdapter1;
        private LiquidacionDBMETAL.ReporteLiquidacionTableAdapters.Reporte_Mineras_DetalleTableAdapter reporte_Mineras_DetalleTableAdapter2;
        private DBMETALDataSet dbmetalDataSet1;
        private LiquidacionDBMETAL.ReporteLiquidacion reporteLiquidacion2;
        private LiquidacionDBMETAL.ReporteLiquidacion reporteLiquidacion1;
    }
}
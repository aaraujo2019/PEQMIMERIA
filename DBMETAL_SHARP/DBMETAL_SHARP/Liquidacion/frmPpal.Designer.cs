using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DBMETAL_SHARP
{
    partial class frmPpal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPpal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.envioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PeriodoStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.esquemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contenedoresDeMinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operadoresminasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Maestros = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Proyectos = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muestreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturaMuestreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlCalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargaAnálisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesLiquidaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorDeRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesInternosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versión6000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 580);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(799, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.envioToolStripMenuItem,
            this.muestreoToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.holaToolStripMenuItem,
            this.versión6000ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(799, 23);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // envioToolStripMenuItem
            // 
            this.envioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PeriodoStripMenuItem1,
            this.esquemasToolStripMenuItem,
            this.contenedoresDeMinasToolStripMenuItem,
            this.operadoresminasToolStripMenuItem,
            this.Menu_Maestros,
            this.salirToolStripMenuItem});
            this.envioToolStripMenuItem.Name = "envioToolStripMenuItem";
            this.envioToolStripMenuItem.Size = new System.Drawing.Size(95, 19);
            this.envioToolStripMenuItem.Text = "Configuración";
            // 
            // PeriodoStripMenuItem1
            // 
            this.PeriodoStripMenuItem1.Name = "PeriodoStripMenuItem1";
            this.PeriodoStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.PeriodoStripMenuItem1.Text = "Periodo";
            this.PeriodoStripMenuItem1.Click += new System.EventHandler(this.selectDBToolStripMenuItem1_Click);
            // 
            // esquemasToolStripMenuItem
            // 
            this.esquemasToolStripMenuItem.Name = "esquemasToolStripMenuItem";
            this.esquemasToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.esquemasToolStripMenuItem.Text = "Esquemas";
            // 
            // contenedoresDeMinasToolStripMenuItem
            // 
            this.contenedoresDeMinasToolStripMenuItem.Name = "contenedoresDeMinasToolStripMenuItem";
            this.contenedoresDeMinasToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.contenedoresDeMinasToolStripMenuItem.Text = "Contenedores de minas";
            this.contenedoresDeMinasToolStripMenuItem.Click += new System.EventHandler(this.contenedoresDeMinasToolStripMenuItem_Click);
            // 
            // operadoresminasToolStripMenuItem
            // 
            this.operadoresminasToolStripMenuItem.Name = "operadoresminasToolStripMenuItem";
            this.operadoresminasToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.operadoresminasToolStripMenuItem.Text = "Operadores/minas";
            this.operadoresminasToolStripMenuItem.Click += new System.EventHandler(this.operadoresminasToolStripMenuItem_Click);
            // 
            // Menu_Maestros
            // 
            this.Menu_Maestros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Proyectos});
            this.Menu_Maestros.Name = "Menu_Maestros";
            this.Menu_Maestros.Size = new System.Drawing.Size(199, 22);
            this.Menu_Maestros.Text = "Maestros";
            // 
            // Menu_Proyectos
            // 
            this.Menu_Proyectos.Name = "Menu_Proyectos";
            this.Menu_Proyectos.Size = new System.Drawing.Size(126, 22);
            this.Menu_Proyectos.Text = "Proyectos";
            this.Menu_Proyectos.Click += new System.EventHandler(this.Menu_Proyectos_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // muestreoToolStripMenuItem
            // 
            this.muestreoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturaMuestreoToolStripMenuItem,
            this.controlCalidadToolStripMenuItem,
            this.cargaAnálisisToolStripMenuItem});
            this.muestreoToolStripMenuItem.Name = "muestreoToolStripMenuItem";
            this.muestreoToolStripMenuItem.Size = new System.Drawing.Size(69, 19);
            this.muestreoToolStripMenuItem.Text = "Muestreo";
            // 
            // capturaMuestreoToolStripMenuItem
            // 
            this.capturaMuestreoToolStripMenuItem.Name = "capturaMuestreoToolStripMenuItem";
            this.capturaMuestreoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.capturaMuestreoToolStripMenuItem.Text = "Captura Muestreo";
            this.capturaMuestreoToolStripMenuItem.Click += new System.EventHandler(this.capturaMuestreoToolStripMenuItem_Click);
            // 
            // controlCalidadToolStripMenuItem
            // 
            this.controlCalidadToolStripMenuItem.Name = "controlCalidadToolStripMenuItem";
            this.controlCalidadToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.controlCalidadToolStripMenuItem.Text = "Control Calidad";
            this.controlCalidadToolStripMenuItem.Click += new System.EventHandler(this.controlCalidadToolStripMenuItem_Click);
            // 
            // cargaAnálisisToolStripMenuItem
            // 
            this.cargaAnálisisToolStripMenuItem.Name = "cargaAnálisisToolStripMenuItem";
            this.cargaAnálisisToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cargaAnálisisToolStripMenuItem.Text = "Carga Análisis";
            this.cargaAnálisisToolStripMenuItem.Click += new System.EventHandler(this.cargaAnálisisToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesLiquidaciónToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 19);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reportesLiquidaciónToolStripMenuItem
            // 
            this.reportesLiquidaciónToolStripMenuItem.Name = "reportesLiquidaciónToolStripMenuItem";
            this.reportesLiquidaciónToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.reportesLiquidaciónToolStripMenuItem.Text = "Reportes Liquidación";
            this.reportesLiquidaciónToolStripMenuItem.Click += new System.EventHandler(this.reportesLiquidaciónToolStripMenuItem_Click);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administradorDeRolesToolStripMenuItem,
            this.administradorPermisosToolStripMenuItem,
            this.reportesInternosToolStripMenuItem});
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(72, 19);
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // administradorDeRolesToolStripMenuItem
            // 
            this.administradorDeRolesToolStripMenuItem.Name = "administradorDeRolesToolStripMenuItem";
            this.administradorDeRolesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.administradorDeRolesToolStripMenuItem.Text = "Administrador de Roles";
            this.administradorDeRolesToolStripMenuItem.Click += new System.EventHandler(this.administradorDeRolesToolStripMenuItem_Click);
            // 
            // administradorPermisosToolStripMenuItem
            // 
            this.administradorPermisosToolStripMenuItem.Name = "administradorPermisosToolStripMenuItem";
            this.administradorPermisosToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.administradorPermisosToolStripMenuItem.Text = "Administrador Permisos";
            this.administradorPermisosToolStripMenuItem.Click += new System.EventHandler(this.administradorPermisosToolStripMenuItem_Click);
            // 
            // reportesInternosToolStripMenuItem
            // 
            this.reportesInternosToolStripMenuItem.Name = "reportesInternosToolStripMenuItem";
            this.reportesInternosToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.reportesInternosToolStripMenuItem.Text = "Reportes Internos";
            this.reportesInternosToolStripMenuItem.Click += new System.EventHandler(this.reportesInternosToolStripMenuItem_Click);
            // 
            // holaToolStripMenuItem
            // 
            this.holaToolStripMenuItem.Name = "holaToolStripMenuItem";
            this.holaToolStripMenuItem.Size = new System.Drawing.Size(42, 19);
            this.holaToolStripMenuItem.Text = "hola";
            // 
            // versión6000ToolStripMenuItem
            // 
            this.versión6000ToolStripMenuItem.Name = "versión6000ToolStripMenuItem";
            this.versión6000ToolStripMenuItem.Size = new System.Drawing.Size(93, 19);
            this.versión6000ToolStripMenuItem.Text = "Versión 6.0.0.0";
            // 
            // frmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(799, 602);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPpal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidación DBMETAL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPpal_FormClosing);
            this.Load += new System.EventHandler(this.frmPpal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem envioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PeriodoStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem holaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administradorDeRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administradorPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesInternosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esquemasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contenedoresDeMinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operadoresminasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muestreoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturaMuestreoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlCalidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargaAnálisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesLiquidaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versión6000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Maestros;
        private System.Windows.Forms.ToolStripMenuItem Menu_Proyectos;
    }
}
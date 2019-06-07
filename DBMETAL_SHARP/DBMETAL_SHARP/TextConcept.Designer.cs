namespace DBMETAL_SHARP
{
    partial class TextConcept
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opcion1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcion2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcion1ToolStripMenuItem,
            this.opcion2ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 48);
            // 
            // opcion1ToolStripMenuItem
            // 
            this.opcion1ToolStripMenuItem.Name = "opcion1ToolStripMenuItem";
            this.opcion1ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.opcion1ToolStripMenuItem.Text = "opcion1";
            // 
            // opcion2ToolStripMenuItem
            // 
            this.opcion2ToolStripMenuItem.Name = "opcion2ToolStripMenuItem";
            this.opcion2ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.opcion2ToolStripMenuItem.Text = "opcion2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 75);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tomar Muestreo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 75);
            this.button2.TabIndex = 2;
            this.button2.Text = "Control Calidad";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // TextConcept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "TextConcept";
            this.Text = "TextConcept";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcion1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcion2ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
namespace DBMETAL_SHARP
{
    partial class Frm_Consultas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.TxbConsulta = new System.Windows.Forms.TextBox();
            this.GrbBuscar = new System.Windows.Forms.GroupBox();
            this.dataGridViewConsulta = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.BackColor = System.Drawing.Color.Transparent;
            this.buttonBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBuscar.Image = global::DBMETAL_SHARP.Properties.Resources.srch_16;
            this.buttonBuscar.Location = new System.Drawing.Point(482, 43);
            this.buttonBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(30, 21);
            this.buttonBuscar.TabIndex = 31;
            this.buttonBuscar.UseVisualStyleBackColor = false;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // TxbConsulta
            // 
            this.TxbConsulta.Location = new System.Drawing.Point(153, 44);
            this.TxbConsulta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxbConsulta.Name = "TxbConsulta";
            this.TxbConsulta.Size = new System.Drawing.Size(329, 20);
            this.TxbConsulta.TabIndex = 30;
            this.TxbConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxbConsulta_KeyPress);
            // 
            // GrbBuscar
            // 
            this.GrbBuscar.BackColor = System.Drawing.Color.Transparent;
            this.GrbBuscar.Location = new System.Drawing.Point(14, 39);
            this.GrbBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GrbBuscar.Name = "GrbBuscar";
            this.GrbBuscar.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GrbBuscar.Size = new System.Drawing.Size(117, 151);
            this.GrbBuscar.TabIndex = 29;
            this.GrbBuscar.TabStop = false;
            this.GrbBuscar.Text = "Buscar Por...";
            // 
            // dataGridViewConsulta
            // 
            this.dataGridViewConsulta.AllowDrop = true;
            this.dataGridViewConsulta.AllowUserToAddRows = false;
            this.dataGridViewConsulta.AllowUserToDeleteRows = false;
            this.dataGridViewConsulta.AllowUserToOrderColumns = true;
            this.dataGridViewConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewConsulta.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridViewConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = "Vacio";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewConsulta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewConsulta.GridColor = System.Drawing.Color.Lavender;
            this.dataGridViewConsulta.Location = new System.Drawing.Point(153, 67);
            this.dataGridViewConsulta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewConsulta.Name = "dataGridViewConsulta";
            this.dataGridViewConsulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewConsulta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewConsulta.Size = new System.Drawing.Size(359, 121);
            this.dataGridViewConsulta.TabIndex = 28;
            this.dataGridViewConsulta.TabStop = false;
            this.dataGridViewConsulta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConsulta_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Image = global::DBMETAL_SHARP.Properties.Resources.OndadegradadaL;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(-3, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 31);
            this.label1.TabIndex = 27;
            this.label1.Text = "Consultas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(531, 200);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.TxbConsulta);
            this.Controls.Add(this.GrbBuscar);
            this.Controls.Add(this.dataGridViewConsulta);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Consultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Busquedas";
            this.Load += new System.EventHandler(this.Frm_Consultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.TextBox TxbConsulta;
        private System.Windows.Forms.GroupBox GrbBuscar;
        private System.Windows.Forms.DataGridView dataGridViewConsulta;
        private System.Windows.Forms.Label label1;
    }
}
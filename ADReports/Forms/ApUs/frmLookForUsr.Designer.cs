namespace ADReports.Forms.ApUs
{
    partial class frmLookForUsr
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
            this.dgvfTabla = new ADReports.Controles.dataGridViewFiltrado();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvfTabla
            // 
            this.dgvfTabla.AllowUserToAddRows = false;
            this.dgvfTabla.AllowUserToDeleteRows = false;
            this.dgvfTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvfTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfTabla.Location = new System.Drawing.Point(12, 32);
            this.dgvfTabla.Name = "dgvfTabla";
            this.dgvfTabla.ReadOnly = true;
            this.dgvfTabla.Size = new System.Drawing.Size(397, 168);
            this.dgvfTabla.TabIndex = 0;
            this.dgvfTabla.DoubleClick += new System.EventHandler(this.dgvfTabla_DoubleClick);
            this.dgvfTabla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvfTabla_KeyDown);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(12, 6);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 2;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // frmLookForUsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 215);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.dgvfTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmLookForUsr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvfTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.dataGridViewFiltrado dgvfTabla;
        private System.Windows.Forms.TextBox txtFiltro;
    }
}
namespace ADReports.Forms.ApUs
{
    partial class frmAsignacion
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ListApp = new System.Windows.Forms.ListBox();
            this.ListAsignado = new System.Windows.Forms.ListBox();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.btnIzquierda = new System.Windows.Forms.Button();
            this.btnDerechaAll = new System.Windows.Forms.Button();
            this.btnIzquierdaAll = new System.Windows.Forms.Button();
            this.dgvUsr = new ADReports.Controles.dataGridViewFiltrado();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsr)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnGuardar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(510, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ListApp
            // 
            this.ListApp.FormattingEnabled = true;
            this.ListApp.Location = new System.Drawing.Point(12, 196);
            this.ListApp.Name = "ListApp";
            this.ListApp.Size = new System.Drawing.Size(185, 212);
            this.ListApp.TabIndex = 12;
            // 
            // ListAsignado
            // 
            this.ListAsignado.FormattingEnabled = true;
            this.ListAsignado.Location = new System.Drawing.Point(310, 196);
            this.ListAsignado.Name = "ListAsignado";
            this.ListAsignado.Size = new System.Drawing.Size(185, 212);
            this.ListAsignado.TabIndex = 13;
            // 
            // btnDerecha
            // 
            this.btnDerecha.Font = new System.Drawing.Font("Algerian", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDerecha.Location = new System.Drawing.Point(230, 196);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(46, 23);
            this.btnDerecha.TabIndex = 14;
            this.btnDerecha.Text = ">";
            this.btnDerecha.UseVisualStyleBackColor = true;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerecha_Click);
            // 
            // btnIzquierda
            // 
            this.btnIzquierda.Font = new System.Drawing.Font("Algerian", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzquierda.Location = new System.Drawing.Point(230, 225);
            this.btnIzquierda.Name = "btnIzquierda";
            this.btnIzquierda.Size = new System.Drawing.Size(46, 23);
            this.btnIzquierda.TabIndex = 15;
            this.btnIzquierda.Text = "<";
            this.btnIzquierda.UseVisualStyleBackColor = true;
            this.btnIzquierda.Click += new System.EventHandler(this.btnIzquierda_Click);
            // 
            // btnDerechaAll
            // 
            this.btnDerechaAll.Font = new System.Drawing.Font("Algerian", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDerechaAll.Location = new System.Drawing.Point(230, 294);
            this.btnDerechaAll.Name = "btnDerechaAll";
            this.btnDerechaAll.Size = new System.Drawing.Size(46, 23);
            this.btnDerechaAll.TabIndex = 16;
            this.btnDerechaAll.Text = ">>";
            this.btnDerechaAll.UseVisualStyleBackColor = true;
            this.btnDerechaAll.Click += new System.EventHandler(this.btnDerechaAll_Click);
            // 
            // btnIzquierdaAll
            // 
            this.btnIzquierdaAll.Font = new System.Drawing.Font("Algerian", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzquierdaAll.Location = new System.Drawing.Point(230, 323);
            this.btnIzquierdaAll.Name = "btnIzquierdaAll";
            this.btnIzquierdaAll.Size = new System.Drawing.Size(46, 23);
            this.btnIzquierdaAll.TabIndex = 17;
            this.btnIzquierdaAll.Text = "<<";
            this.btnIzquierdaAll.UseVisualStyleBackColor = true;
            this.btnIzquierdaAll.Click += new System.EventHandler(this.btnIzquierdaAll_Click);
            // 
            // dgvUsr
            // 
            this.dgvUsr.AllowUserToAddRows = false;
            this.dgvUsr.AllowUserToOrderColumns = true;
            this.dgvUsr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsr.Location = new System.Drawing.Point(12, 40);
            this.dgvUsr.Name = "dgvUsr";
            this.dgvUsr.ReadOnly = true;
            this.dgvUsr.Size = new System.Drawing.Size(483, 150);
            this.dgvUsr.TabIndex = 11;
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::ADReports.Properties.Resources.Add;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Image = global::ADReports.Properties.Resources.save_as;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(23, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.Image = global::ADReports.Properties.Resources.Log_Out;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(23, 22);
            this.btnSalir.Text = "Salir";
            // 
            // frmAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 420);
            this.Controls.Add(this.btnIzquierdaAll);
            this.Controls.Add(this.btnDerechaAll);
            this.Controls.Add(this.btnIzquierda);
            this.Controls.Add(this.btnDerecha);
            this.Controls.Add(this.ListAsignado);
            this.Controls.Add(this.ListApp);
            this.Controls.Add(this.dgvUsr);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAsignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion de Aplicaciones";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private Controles.dataGridViewFiltrado dgvUsr;
        private System.Windows.Forms.ListBox ListApp;
        private System.Windows.Forms.ListBox ListAsignado;
        private System.Windows.Forms.Button btnDerecha;
        private System.Windows.Forms.Button btnIzquierda;
        private System.Windows.Forms.Button btnDerechaAll;
        private System.Windows.Forms.Button btnIzquierdaAll;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripButton btnNuevo;

    }
}
namespace ADReports
{
    partial class panelUsuario
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUsuariosApp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 97);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::ADReports.Properties.Resources.users_male_mixed_race_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(116, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 67);
            this.button2.TabIndex = 4;
            this.button2.Text = "Usuarios Registrados";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUsuariosApp
            // 
            this.btnUsuariosApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUsuariosApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuariosApp.Image = global::ADReports.Properties.Resources.user_and_apps;
            this.btnUsuariosApp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUsuariosApp.Location = new System.Drawing.Point(18, 19);
            this.btnUsuariosApp.Name = "btnUsuariosApp";
            this.btnUsuariosApp.Size = new System.Drawing.Size(92, 67);
            this.btnUsuariosApp.TabIndex = 3;
            this.btnUsuariosApp.Text = "Usuarios y Aplicaciones";
            this.btnUsuariosApp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuariosApp.UseVisualStyleBackColor = true;
            this.btnUsuariosApp.Click += new System.EventHandler(this.btnUsuariosApp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUsuariosApp);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 97);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuarios";
            // 
            // panelUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "panelUsuario";
            this.Size = new System.Drawing.Size(223, 97);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUsuariosApp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

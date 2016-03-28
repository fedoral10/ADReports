namespace ADReports.Controles
{
    partial class frmCustom
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
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.sbLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabel,
            this.sbProgressBar});
            this.StatusBar.Location = new System.Drawing.Point(0, 336);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(447, 22);
            this.StatusBar.TabIndex = 0;
            // 
            // sbLabel
            // 
            this.sbLabel.Name = "sbLabel";
            this.sbLabel.Size = new System.Drawing.Size(35, 17);
            this.sbLabel.Text = "Listo.";
            // 
            // sbProgressBar
            // 
            this.sbProgressBar.Name = "sbProgressBar";
            this.sbProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // frmCustom
            // 
            this.ClientSize = new System.Drawing.Size(447, 358);
            this.Controls.Add(this.StatusBar);
            this.Name = "frmCustom";
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel sbLabel;
        public System.Windows.Forms.ToolStripProgressBar sbProgressBar;
        public System.Windows.Forms.StatusStrip StatusBar;

    }
}

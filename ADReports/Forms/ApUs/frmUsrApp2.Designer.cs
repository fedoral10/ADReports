namespace ADReports.Forms.ApUs
{
    partial class frmUsrApp2
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
            this.cmbPais = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImportar = new System.Windows.Forms.ToolStripButton();
            this.btnAsignar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExportar = new System.Windows.Forms.ToolStripButton();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.colID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colNombre = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colPuesto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colArea = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colEmpresa = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colAplicacion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colXD = new DevExpress.XtraPivotGrid.PivotGridField();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbPais,
            this.tsBtnRefresh,
            this.tsBtnImportar,
            this.btnAsignar,
            this.toolStripSeparator1,
            this.tsBtnExportar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(801, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmbPais
            // 
            this.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRefresh.Image = global::ADReports.Properties.Resources.btnRefresh;
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsBtnRefresh.Text = "Refrescar";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // tsBtnImportar
            // 
            this.tsBtnImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnImportar.Image = global::ADReports.Properties.Resources.import_excel;
            this.tsBtnImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImportar.Name = "tsBtnImportar";
            this.tsBtnImportar.Size = new System.Drawing.Size(23, 22);
            this.tsBtnImportar.Text = "Importar";
            this.tsBtnImportar.Click += new System.EventHandler(this.tsBtnImportar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAsignar.Image = global::ADReports.Properties.Resources.checklist;
            this.btnAsignar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(23, 22);
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.Visible = false;
            // 
            // tsBtnExportar
            // 
            this.tsBtnExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnExportar.Image = global::ADReports.Properties.Resources.btnReport;
            this.tsBtnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExportar.Name = "tsBtnExportar";
            this.tsBtnExportar.Size = new System.Drawing.Size(23, 22);
            this.tsBtnExportar.Text = "Exportar";
            this.tsBtnExportar.Click += new System.EventHandler(this.tsBtnExportar_Click);
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.colID,
            this.colNombre,
            this.colPuesto,
            this.colArea,
            this.colEmpresa,
            this.colAplicacion,
            this.colXD});
            this.pivotGridControl1.Location = new System.Drawing.Point(13, 29);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsCustomization.AllowCustomizationForm = false;
            this.pivotGridControl1.OptionsCustomization.AllowDrag = false;
            this.pivotGridControl1.OptionsCustomization.AllowDragInCustomizationForm = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(776, 447);
            this.pivotGridControl1.TabIndex = 11;
            this.pivotGridControl1.CustomSummary += new DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventHandler(this.pivotGridControl1_CustomSummary);
            // 
            // colID
            // 
            this.colID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colID.AreaIndex = 0;
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colNombre
            // 
            this.colNombre.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colNombre.AreaIndex = 1;
            this.colNombre.FieldName = "NOMBRE";
            this.colNombre.Name = "colNombre";
            // 
            // colPuesto
            // 
            this.colPuesto.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colPuesto.AreaIndex = 2;
            this.colPuesto.FieldName = "PUESTO";
            this.colPuesto.Name = "colPuesto";
            // 
            // colArea
            // 
            this.colArea.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colArea.AreaIndex = 3;
            this.colArea.FieldName = "AREA";
            this.colArea.Name = "colArea";
            // 
            // colEmpresa
            // 
            this.colEmpresa.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colEmpresa.AreaIndex = 4;
            this.colEmpresa.FieldName = "EMPRESA";
            this.colEmpresa.Name = "colEmpresa";
            // 
            // colAplicacion
            // 
            this.colAplicacion.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colAplicacion.AreaIndex = 0;
            this.colAplicacion.FieldName = "APLICACION";
            this.colAplicacion.Name = "colAplicacion";
            // 
            // colXD
            // 
            this.colXD.Appearance.Cell.Options.UseTextOptions = true;
            this.colXD.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXD.Appearance.Cell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colXD.Appearance.Value.Options.UseTextOptions = true;
            this.colXD.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXD.Appearance.Value.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colXD.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colXD.AreaIndex = 0;
            this.colXD.FieldName = "XD";
            this.colXD.Name = "colXD";
            this.colXD.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            // 
            // frmUsrApp2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 488);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmUsrApp2";
            this.Text = "frmUsrApp2";
            this.Load += new System.EventHandler(this.frmUsrApp2_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cmbPais;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.ToolStripButton tsBtnImportar;
        private System.Windows.Forms.ToolStripButton btnAsignar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnExportar;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField colID;
        private DevExpress.XtraPivotGrid.PivotGridField colNombre;
        private DevExpress.XtraPivotGrid.PivotGridField colPuesto;
        private DevExpress.XtraPivotGrid.PivotGridField colArea;
        private DevExpress.XtraPivotGrid.PivotGridField colEmpresa;
        private DevExpress.XtraPivotGrid.PivotGridField colAplicacion;
        private DevExpress.XtraPivotGrid.PivotGridField colXD;
    }
}
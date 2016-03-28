using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace ADReports.Reportes
{
    public partial class rpt_matriz_app : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_matriz_app()
        {
            InitializeComponent();
        }

        private void eventoX(XRTableCell cel)
        {
            if (cel.Text.ToLower() == "true")
            {
                cel.Text = "X";
            }
            if (cel.Text.ToLower() == "false")
            {
                cel.Text = "";
            }
        }

        private void dummy(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            eventoX((XRTableCell)sender);
        }

        private void rpt_matriz_app_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataTable dt = (DataTable)this.DataSource;

            //ghArea.GroupFields.Clear();

            //ghArea.GroupFields.AddRange(
            //new DevExpress.XtraReports.UI.GroupField[] {
            //new DevExpress.XtraReports.UI.GroupField(
            //dt.TableName+".Area", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            
            int x =0;
            foreach (DataColumn dc in dt.Columns)
            {
                if (x > 4)
                {
                    XRTableCell columna_titulo = new XRTableCell();
                    XRTableCell columna_detalle = new XRTableCell();
                    columna_titulo.Name = "ct" + dc.ColumnName;
                    columna_titulo.Text = dc.ColumnName;

                    this.xrTableTitulo.BeginInit();
                    this.xrTableDetalle.BeginInit();

                    //this.xrTableTitulo.Rows[0].Cells.Add(new XRTableCell());
                    this.xrTableTitulo.Rows[1].Cells.Add(columna_titulo);
                    //this.xrTableTitulo.InsertColumnToRight(columna_titulo);
                    columna_detalle.DataBindings.AddRange(
                    new DevExpress.XtraReports.UI.XRBinding[] {
                    new DevExpress.XtraReports.UI.XRBinding("Text", null, dt.TableName+"."+dc.ColumnName)});

                    this.xrTableDetalle.Rows[0].Cells.Add(columna_detalle);
                    columna_detalle.BeforePrint += new System.Drawing.Printing.PrintEventHandler(dummy);
                    //this.xrTableDetalle.InsertColumnToRight(columna_detalle);

                    this.xrTableDetalle.SizeF = new SizeF(1071, 25);
                    this.xrTableTitulo.SizeF = new SizeF(1071, 50);
                    //this.xrTableDetalle.AdjustSize();
                    //this.xrTableTitulo.AdjustSize();

                    this.xrTableDetalle.EndInit();
                    this.xrTableTitulo.EndInit();
                }
                x++;
            }
        }

    }
}

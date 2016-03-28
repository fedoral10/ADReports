using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Data;
using DevExpress.XtraReports.UI;

namespace ADReports.Reportes
{
     
    class clsReportes
    {
        public static void call_reporte_matriz_app(DataTable source)
        {
            try
            {
                if (source == null)
                    throw new Exception("Reporteador recibió un datatable null");


                /*ds_matriz_app ds = new ds_matriz_app();
                
                ds.Tables.Remove("matriz_app");*/

                //DataSet ds = new DataSet();
                source.TableName = "matriz_app";
                //ds.Tables.Add(source);
                rpt_matriz_app reporte = new rpt_matriz_app();
                reporte.DataSource = source;
                reporte.DataMember = source.TableName;
                using (ReportPrintTool printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            
            }
        }
    }
}

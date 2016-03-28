using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADReports.Forms.Aplicacion
{
    public partial class frmAplicaciones : Form
    {
        public frmAplicaciones()
        {
            InitializeComponent();
        }

        private void frmAplicaciones_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsRepo repo = new clsRepo();
            string query = "select a.id_aplicacion as ID_APLICACION, a.nombre as Aplicacion from aplicacion as a ";
            DataTable dt = repo.Seleccionar(query);
            gridControl1.DataSource = dt;
            //dgvApps.DataSource = dt;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAddApp frm = new frmAddApp();
            frm.ShowDialog();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string filename = commons.getSaveFile("Archivos de Excel(*.XLSX)|*.xlsx");
            if (!string.IsNullOrEmpty(filename))
            { 
                gridView1.ExportToXlsx(filename);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int[] selected = gridView1.GetSelectedRows();

            if (selected.Length > 0)
            {
                int id_app = int.Parse(gridView1.GetRowCellValue(selected[0], gridView1.Columns["ID_APLICACION"]).ToString());
                string sql_base = "delete from aplicacion where id_aplicacion = {0}";
                string sql = string.Format(sql_base, id_app);
                try
                {
                    clsRepo repo = new clsRepo();
                    repo.Actualizacion(sql);
                }
                catch (Exception ex)
                {
                    commons.showMessageBoxError(this.Text,"No se pudo eliminar el registro\n"+ ex.Message);
                }
            }
        }

     }
}

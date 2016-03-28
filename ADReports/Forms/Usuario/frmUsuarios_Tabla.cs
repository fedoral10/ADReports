using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADReports.Forms.Usuario
{
    public partial class frmUsuarios_Tabla : Form
    {
        public frmUsuarios_Tabla()
        {
            InitializeComponent();
            actualizar_Grid();
        }
        private void actualizar_Grid()
        {
            clsRepo repo = new clsRepo();
            IList<Dominio.Entidad> lista = repo.Seleccionar<Dominio.Entidad>();

            gcUsuarios.DataSource = clsRepoConvertidor.ToDataTable<Dominio.Entidad>(lista);
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar_Grid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAddUsuario add = new frmAddUsuario();
            add.ShowDialog();
            if (add.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            clsRepo repo = new clsRepo();
            repo.Insertar<Dominio.Entidad>(add.ent);
            commons.showMessageBoxInformation(this.Text, "Registro insertado correctamente");
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string file = commons.getSaveFile("Archivos Excel *.xlsx|*.xlsx");
            if (!string.IsNullOrEmpty(file))
            {
                gcUsuarios.ExportToXlsx(file);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int[] rows = gridView1.GetSelectedRows();
            if (rows.Length > 0)
            {
                string samaccountname = gridView1.GetRowCellValue(rows[0], colID).ToString();
                clsRepo repo = new clsRepo();
                try
                {
                    repo.deleteEntidad_samaccountname(samaccountname);
                    gridView1.DeleteSelectedRows();
                }
                catch (Exception ex)
                {
                    string message = "";
                    if (ex.InnerException != null)
                        message = ex.InnerException.Message;
                    else
                        message = ex.Message;
                    commons.showMessageBoxError(this.Text, "No se pudo eliminar el usuario de la base de datos\n" + message);
                }
                //actualizar_Grid();
            }
        }
    }
}

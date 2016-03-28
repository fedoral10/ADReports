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
    public partial class frmAddApp : Form
    {
        public frmAddApp()
        {
            InitializeComponent();
            //llenar_cmb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dominio.Aplicacion app = new Dominio.Aplicacion();
            app.nombre = txtNombre.Text;
            //app.id_pais = (Dominio.Pais)cmbPais.SelectedItem;
            clsRepo repo = new clsRepo();
            repo.Insertar<Dominio.Aplicacion>(app);
            Close();
        }

        /*private void llenar_cmb()
        {
            clsRepo repo = new clsRepo();
            IList<Dominio.Pais> x = repo.Seleccionar<Dominio.Pais>();
            foreach (Dominio.Pais pais in x)
            {
                cmbPais.Items.Add(pais);
            }
            if (cmbPais.Items.Count > 0)
            {
                cmbPais.SelectedIndex = 0;
            }
        }*/

    }
}

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
            llenar_cmb();
        }

        private bool existe(string nombre_app, string pais)
        {
            clsRepo repo = new clsRepo();
            IList<Dominio.Aplicacion>lista =repo.Seleccionar<Dominio.Aplicacion>();
            foreach (Dominio.Aplicacion app in lista)
            {
                if (app.nombre == nombre_app && app.pais == pais)
                {
                    return true;
                }
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dominio.Aplicacion app = new Dominio.Aplicacion();
            app.nombre = txtNombre.Text;
            app.pais = cmbPais.SelectedItem.ToString();

            if (existe(app.nombre, app.pais))
            {
                MessageBox.Show("La aplicacion ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //app.id_pais = (Dominio.Pais)cmbPais.SelectedItem;
            clsRepo repo = new clsRepo();
            repo.Insertar<Dominio.Aplicacion>(app);
            Close();
        }

        private void llenar_cmb()
        {
            foreach (string p in Dominio.PAIS.paises)
            {
                cmbPais.Items.Add(p);
            }
            if (cmbPais.Items.Count > 0)
                cmbPais.SelectedIndex = 0;
        }

    }
}

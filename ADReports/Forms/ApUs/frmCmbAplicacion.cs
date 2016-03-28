using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADReports.Forms.ApUs
{
    public partial class frmCmbAplicacion : Form
    {

        private Dominio.Aplicacion _app;
        public Dominio.Aplicacion getAplicacion()
        {
            return this._app;
        }

        public frmCmbAplicacion()
        {
            InitializeComponent();
            llenar_cmb();
        }

        private void llenar_cmb()
        {
            clsRepo repo = new clsRepo();
            IList<Dominio.Aplicacion> lista = repo.Seleccionar<Dominio.Aplicacion>();
            foreach (Dominio.Aplicacion app in lista)
            {
                cmbAplicacion.Items.Add(app);
            }
            if (cmbAplicacion.Items.Count > 0)
            {
                cmbAplicacion.SelectedIndex = 0;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this._app = (Dominio.Aplicacion)cmbAplicacion.SelectedItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Dispose();
        }
    }
}

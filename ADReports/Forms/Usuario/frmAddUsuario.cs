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
    public partial class frmAddUsuario : Form
    {
        public frmAddUsuario()
        {
            InitializeComponent();
        }

        private bool pasa_validacion()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtPuesto.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtArea.Text))
            {
                return false;
            }

            return true;
                
        }
        public Dominio.Entidad ent;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if (!pasa_validacion())
            {
                commons.showMessageBoxError(this.Text, "Verifique los datos ingresados");
                return;
            }
            this.ent = new Dominio.Entidad();
            ent.samaccountname = txtID.Text;
            ent.displayname = txtNombre.Text;
            ent.cn = txtNombre.Text;
            ent.description = txtPuesto.Text;
            ent.physicalDeliveryOfficeName = txtArea.Text;
            ent.department = txtArea.Text;
            ent.mail = txtCorreo.Text;
            ent.company = txtEmpresa.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            /*clsRepo repo = new clsRepo();
            repo.Insertar<Dominio.Entidad>(ent);*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Dispose();
        }
    }
}

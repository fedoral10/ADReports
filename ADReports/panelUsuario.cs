using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADReports
{
    public partial class panelUsuario : UserControl
    {
        public panelUsuario()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void btnUsuariosApp_Click(object sender, EventArgs e)
        {
            Forms.ApUs.frmUsrApp usr = new Forms.ApUs.frmUsrApp();
            usr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.Usuario.frmUsuarios_Tabla usr = new Forms.Usuario.frmUsuarios_Tabla();
            usr.ShowDialog();
        }
    }
}

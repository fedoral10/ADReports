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
    public partial class panelAplicaciones : UserControl
    {
        public panelAplicaciones()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void btnApps_Click(object sender, EventArgs e)
        {
            Forms.Aplicacion.frmAplicaciones frm = new Forms.Aplicacion.frmAplicaciones();
            frm.Show();
        }
    }
}

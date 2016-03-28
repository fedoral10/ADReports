using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADReports.Controles
{
    public partial class frmCustom : Form
    {
        public frmCustom()
        {
            InitializeComponent();
        }

        /*protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }*/

        public void setStatusBarText(string texto)
        {
            sbLabel.Text = texto;
        }

    }
}

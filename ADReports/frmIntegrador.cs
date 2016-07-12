using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADReports
{
    public partial class frmIntegrador : Form
    {
        public frmIntegrador()
        {
            InitializeComponent();
            var pm = new panelMain();

            pm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(pm);
            /*Dominio.Pais nic = new Dominio.Pais();
            nic.prefijo = "NJ";
            nic.nombre = "Nicaragua";
            Dominio.Pais sv = new Dominio.Pais();
            sv.prefijo = "ME";
            sv.nombre = "El Salvador";
            Dominio.Pais pa = new Dominio.Pais();
            pa.prefijo = "NC";
            pa.nombre = "Panamá";
            Dominio.Pais mx = new Dominio.Pais();
            mx.prefijo = "MX";
            mx.nombre = "Mexico";
            Dominio.Pais gt = new Dominio.Pais();
            gt.prefijo = "MG";
            gt.nombre = "Guatemala";
            clsRepo repo = new clsRepo();
            if (repo.ContadorRows<Dominio.Pais>() == 0)
            {
                repo.Insertar<Dominio.Pais>(nic);
                repo.Insertar<Dominio.Pais>(sv);
                repo.Insertar<Dominio.Pais>(pa);
                repo.Insertar<Dominio.Pais>(mx);
                repo.Insertar<Dominio.Pais>(gt);
            }
            */
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void btnusrapp_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void aplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new panelAplicaciones());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(new panelUsuario());
        }

        private void activeDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADSI.Forms.Usuario.frmUsuarios usr = new ADSI.Forms.Usuario.frmUsuarios();
            usr.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }
    }
}

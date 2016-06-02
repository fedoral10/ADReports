using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;


namespace ADReports
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        /*
         * OU=TCN,DC=TCN,DC=COM,DC=NI
         * 
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            /*foreach (string s in AD.ADScopes())
            {
                Console.WriteLine(s);
            }*/
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            NHelper.setConnectionString(this.txtUser.Text, txtPassword.Text, txtServer.Text, txtPort.Value.ToString());
            try
            {
                using (ISession session = NHelper.OpenSession())
                {
                    /*Prueba de conexion*/
                    this.Visible = false;
                    //clsRepo repo = new clsRepo();
                    //Dominio.Entidad ent =repo.getEntidadfromIDAD("NJN04571");
                    //Dominio.EntidadAplicacion ea = repo.getEntidadAppValue("NJN04571", 5);
                    //Dominio.Aplicacion ap = repo.getApplicacion("LINUX");
                    frmIntegrador i = new frmIntegrador();
                    i.ShowDialog();

                    Close();
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter&& this.ActiveControl.GetType() != typeof(Button))
            {
                //MessageBox.Show("You pressed the F1 key");
                SendKeys.Send("{TAB}");
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnAD_Click(object sender, EventArgs e)
        {
            Forms.Usuario.frmUsuarios usr = new Forms.Usuario.frmUsuarios();
            usr.ShowDialog();
        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ADReports.Forms.Usuario
{
    public partial class frmUsuarios : Form//ADReports.Controles.frmCustom
    {

        private string[] _columnas ={
                                "sAMAccountName",
                                "displayName",
                                "description",
                                "department",
                                "mail",
                                "telephoneNumber",
                                "physicalDeliveryOfficeName",
                                "lastLogoff",
                                "lastLogon",
                                "lastLogonTimestamp",
                                "company",
                                "whenChanged",
                                "whenCreated",
                                "pwdLastSet",
                                "title",
                                "givenname",
                                "sn",
                                "cn",
                                "objectclass",
                                "distinguishedname"
                                  };

        private DataTable _dataTable;


        public frmUsuarios()
        {
            InitializeComponent();
            
        }

        private void actulizarGrid()
        {
            _dataTable.Rows.Clear();
            string[] arr = cmbADScope.SelectedItem.ToString().Split('.');
            string root = "";
            foreach (String s in arr)
            {
                root = root + "DC=" + s + ",";
            }
            root = root.Substring(0, root.Length - 1);

            SearchResultCollection sr = AD.queryAD("(&(sAMAccountName=*)(objectClass=user)(!(objectClass=computer))(!(objectClass=organizationalUnit)))", root, System.DirectoryServices.SearchScope.Subtree,_columnas);

            foreach (SearchResult s in sr)
            {
                //Console.WriteLine(s.Properties["samaccountname"][0]);
                _dataTable.Rows.Add();
                foreach (string col in _columnas)
                {
                    _dataTable.Rows[_dataTable.Rows.Count - 1][col] = s.Properties[col].Count > 0 ? commons.allProperties(s.Properties,col) : null;
                }
                
            }
            dgvUsuarios.DataSource = _dataTable;
            if (!String.IsNullOrEmpty(txtFiltro.Text))
            {
                dgvUsuarios.setFiltro(txtFiltro.Text);
            }
        }
        //private BackgroundWorker worker;
        /*
        private void actulizarGrid(string[] dc)
        {
            _dataTable.Rows.Clear();
            string[] arr = dc;
            string root = "";
            foreach (String s in arr)
            {
                root = root + "DC=" + s + ",";
            }
            root = root.Substring(0, root.Length - 1);

            SearchResultCollection sr = AD.queryAD("(&(sAMAccountName=*)(objectClass=user)(!(objectClass=computer))(!(objectClass=organizationalUnit)))", root, System.DirectoryServices.SearchScope.Subtree, _columnas);
            
            int i = 0;
            if (sbProgressBar.GetCurrentParent().InvokeRequired)
            {
                sbProgressBar.GetCurrentParent().Invoke(new MethodInvoker(delegate { this.sbProgressBar.Maximum = sr.Count; this.sbProgressBar.Minimum = 0; }));
            }
            
            foreach (SearchResult s in sr)
            {
                //Console.WriteLine(s.Properties["samaccountname"][0]);
                _dataTable.Rows.Add();
                foreach (string col in _columnas)
                {


                    _dataTable.Rows[_dataTable.Rows.Count - 1][col] = s.Properties[col].Count > 0 ? commons.allProperties(s.Properties, col) : null;
                }
                Thread.Sleep(1);
                this.worker.ReportProgress(i);
                i++;
            }
           // dgvUsuarios.DataSource = _dataTable;
            //if (!String.IsNullOrEmpty(txtFiltro.Text))
            //{
            //    dgvUsuarios.setFiltro(txtFiltro.Text);
            //}


        }
        */
        
        /*
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate { this.Cursor = Cursors.WaitCursor; this.panel1.Enabled = false; }));
            var dc = (string[])e.Argument;

            _dataTable.Rows.Clear();
            string[] arr = dc;
            string root = "";
            foreach (String s in arr)
            {
                root = root + "DC=" + s + ",";
            }
            root = root.Substring(0, root.Length - 1);

            SearchResultCollection sr = AD.queryAD("(&(sAMAccountName=*)(objectClass=user)(!(objectClass=computer))(!(objectClass=organizationalUnit)))", root, System.DirectoryServices.SearchScope.Subtree, _columnas);

            int i = 0;
            //if (sbProgressBar.GetCurrentParent().InvokeRequired)
            {

                sbProgressBar.GetCurrentParent().Invoke(new MethodInvoker(delegate { this.sbProgressBar.Maximum = sr.Count; this.sbProgressBar.Minimum = 0; }));
                sbProgressBar.GetCurrentParent().Invoke(new MethodInvoker(delegate { this.setStatusBarText("Obteniendo registros de Active Directory"); }));
            }

            foreach (SearchResult s in sr)
            {
                //Console.WriteLine(s.Properties["samaccountname"][0]);
                _dataTable.Rows.Add();
                foreach (string col in _columnas)
                {


                    _dataTable.Rows[_dataTable.Rows.Count - 1][col] = s.Properties[col].Count > 0 ? commons.allProperties(s.Properties, col) : null;
                }
                //Thread.Sleep(1);
                this.worker.ReportProgress(i);
                i++;
            }


            //actulizarGrid((string[])e.Argument);
            
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //Console.WriteLine(e.ProgressPercentage);
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            //if (this.sbProgressBar.GetCurrentParent().InvokeRequired)
            {
                this.sbProgressBar.GetCurrentParent().Invoke(new MethodInvoker(delegate { this.sbProgressBar.Value = e.ProgressPercentage; }));
                // Set the text.
                //this.StatusBar.Parent.Invoke(new MethodInvoker(delegate { this.setStatusBarText(e.ProgressPercentage.ToString()); }));
            }
            //if (this.InvokeRequired)
            {
                //
            }
            //if (StatusBar.InvokeRequired)
            {
                StatusBar.Invoke(new MethodInvoker(delegate { this.StatusBar.Refresh(); }));
            }
            //if (dgvUsuarios.InvokeRequired)
            {
                //dgvUsuarios.Invoke(new MethodInvoker(delegate { dgvUsuarios.DataSource = _dataTable; }));
                
            }
            
        }

        private void worker_finalizacion(object sender, RunWorkerCompletedEventArgs e)
        {

            dgvUsuarios.Invoke(new MethodInvoker(delegate { dgvUsuarios.Refresh(); }));
            this.Invoke(new MethodInvoker(delegate { this.Refresh(); }));
            this.sbProgressBar.GetCurrentParent().Invoke(new MethodInvoker(delegate { this.sbProgressBar.Value = 0; }));
            sbProgressBar.GetCurrentParent().Invoke(new MethodInvoker(delegate { this.setStatusBarText("Listo"); }));
            Application.DoEvents();
            this.Invoke(new MethodInvoker(delegate { this.Cursor = Cursors.Default; this.panel1.Enabled = true; }));

        }
        */
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            /*worker = new BackgroundWorker();
            
            worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_finalizacion);
            worker.WorkerReportsProgress = true;

            worker.RunWorkerAsync(cmbADScope.SelectedItem.ToString().Split('.'));*/
            this.Cursor = Cursors.WaitCursor;
            actulizarGrid();
            this.Cursor = Cursors.Default;
        }

        private void btnImportarDB_Click(object sender, EventArgs e)
        {/**
            cn character varying(255),
  company character varying(255),
  department character varying(255),
  description character varying(255),
  displayname character varying(255),
  distinguishedname character varying(255),
  givenname character varying(255),
  mail character varying(255),
  objectclass character varying(255),
  samaccountname character varying(255),
  surname character varying(255),
  telephonenumber character varying(255),
  title character varying(255),
  whenchanged character varying(255),
  whencreated character varying(255),
  topou character varying(255),
          * 
          *  "sAMAccountName",
                                "displayName",
                                "description",
                                "department",
                                "mail",
                                "telephoneNumber",
                                "physicalDeliveryOfficeName",
                                "lastLogoff",
                                "lastLogon",
                                "lastLogonTimestamp",
                                "company",
                                "whenChanged",
                                "whenCreated",
                                "pwdLastSet",
                                "title",
                                "givenname",
                                "surname",
                                "cn",
                                "objectclass"
          * 
          */
            clsRepo repo = new clsRepo();
            foreach (DataRow dr in _dataTable.Rows) 
            {
                Dominio.Entidad ent = new Dominio.Entidad();

                ent.samaccountname = dr["sAMAccountName"].ToString();
                ent.displayname = dr["displayName"].ToString();
                ent.description = dr["description"].ToString();
                ent.department = dr["department"].ToString();
                ent.mail = dr["mail"].ToString();
                ent.telephonenumber = dr["telephoneNumber"].ToString();
                ent.physicalDeliveryOfficeName = dr["physicalDeliveryOfficeName"].ToString();
                ent.lastLogonDT = commons.convertLDAPDateToDateTime(dr["lastLogon"].ToString());
                ent.company = dr["company"].ToString();
                ent.whenchanged = dr["whenChanged"].ToString();
                ent.whenChangedDT = DateTime.Parse(ent.whenchanged);//commons.convertLDAPWhenCreateToDateTime(ent.whenchanged);
                ent.whencreated = dr["whenCreated"].ToString();
                ent.whenCreatedDT = DateTime.Parse(ent.whencreated);
                ent.pwdLastSetDT = commons.convertLDAPDateToDateTime(dr["pwdLastSet"].ToString());
                ent.title = dr["title"].ToString();
                ent.givenname = dr["givenname"].ToString();
                ent.surname = dr["sn"].ToString();
                ent.cn = dr["cn"].ToString();
                ent.objectclass = dr["objectclass"].ToString();
                ent.distinguishedname = dr["distinguishedname"].ToString();
                repo.Insertar<Dominio.Entidad>(ent);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("pwdLastSet: " + dgvUsuarios.SelectedRows[0].Cells["pwdLastSet"].Value);
            DateTime dt=  DateTime.FromFileTime(long.Parse(dgvUsuarios.SelectedRows[0].Cells["pwdLastSet"].Value.ToString()));
            Console.WriteLine(dt);
            Console.WriteLine();
            Console.WriteLine("lastLogon: " + dgvUsuarios.SelectedRows[0].Cells["lastLogon"].Value);
            DateTime d = DateTime.FromFileTime(long.Parse(dgvUsuarios.SelectedRows[0].Cells["lastLogon"].Value.ToString()));
            Console.WriteLine(d);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.frmReporte frm = new Reportes.frmReporte(_dataTable);
            frm.exportXLS();
            //frm.Show();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            dgvUsuarios.setFiltro(txtFiltro.Text);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            _dataTable = new DataTable();
            foreach (string s in AD.ADScopes())
            {
                cmbADScope.Items.Add(s);
            }
            foreach (string s in AD.domainControllers())
            {
                cmbDomainController.Items.Add(s);
            }
            cmbDomainController.SelectedIndex = cmbDomainController.Items.Count - 1;
            cmbADScope.SelectedIndex = cmbADScope.Items.Count - 1;

            foreach (string col in _columnas)
            {
                /* var columna = new DataGridViewColumn();
                 columna.Name = col;
                 dgvUsuarios.Columns.Add(columna);*/
                _dataTable.Columns.Add(col);

            }
            dgvUsuarios.DataSource = _dataTable;
        }

        
    }
}

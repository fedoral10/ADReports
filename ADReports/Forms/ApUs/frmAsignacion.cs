using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADReports.Forms.ApUs
{
    public partial class frmAsignacion : Form
    {

        private DataTable _values;

        private Dictionary<string, List<Dominio.Aplicacion>> _origen;
        private Dictionary<string, List<Dominio.Aplicacion>> _destino;

        public frmAsignacion(DataTable selected)
        {
            InitializeComponent();
            _origen = new Dictionary<string, List<Dominio.Aplicacion>>();
            _destino = new Dictionary<string, List<Dominio.Aplicacion>>();

            llenar_maps();

            this.dgvUsr.DataSource = selected;
            this._values = selected;
            this.dgvUsr.Rows[0].Selected = true;

        }

        private void llenar_maps()
        {
            /*Privilegios que tiene*/
            foreach (DataRow dr in this._values.Rows)
            {
                string id = dr["ID"].ToString();
                List<Dominio.Aplicacion> list_app = llenaListAppAsignar(id).ToList<Dominio.Aplicacion>();
                _destino.Add(id, list_app);
                
                /*Aplicaciones disponibles*/
                List<Dominio.Aplicacion> disponibles = new List<Dominio.Aplicacion>();
                foreach (Dominio.Aplicacion app in getListApp())
                {
                    if (!list_app.Contains(app))
                    { 
                        disponibles.Add(app);
                    }

                }
                _origen.Add(id, disponibles);
            }


        }


        private IList<Dominio.Aplicacion> llenaListAppAsignar(string samaccountname)
        { 
            clsRepo repo = new clsRepo();
            string id_ent = repo.getEntidadfromIDAD(samaccountname).idEntidad.ToString();

            return getAppsOfEntidad(id_ent);
        }

        private IList<Dominio.Aplicacion> getAppsOfEntidad(string id_entidad)
        {
            clsRepo repo = new clsRepo();
            return repo.getAppInEntApp(id_entidad);
        }
        
        private void llenarListApp()
        {
            foreach (Dominio.Aplicacion app in getListApp())
            {
                if(!ListAsignado.Items.Contains(app))
                    ListApp.Items.Add(app);
            }
        }

        private IList<Dominio.Aplicacion> getListApp()
        {
            clsRepo repo = new clsRepo();
            IList<Dominio.Aplicacion> apps = repo.Seleccionar<Dominio.Aplicacion>();
            return apps;
        }

        private void moveItem(ListBox origen, ListBox destino)
        {
            int index = origen.SelectedIndex < 0 ? 0 : origen.SelectedIndex - 1;

            if (origen.SelectedItem != null)
            {
                destino.Items.Add(origen.SelectedItem);
                origen.Items.Remove(origen.SelectedItem);
                
            }
            if(origen.Items.Count>0)
                origen.SelectedIndex = index;

        }
        private void moveAllItems(ListBox origen, ListBox destino)
        {
            int count = origen.Items.Count;
            for (int x = count -1; x >= 0; x--)
            {
                object app = origen.Items[x];
                List<Dominio.Aplicacion> lista = _destino[""]
                destino.Items.Add(app);
                origen.Items.Remove(app);
            }
        }

        private string getIDSelected()
        {
            DataGridViewRow row = this.dgvUsr.Rows[this.dgvUsr.SelectedCells[0].RowIndex];
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            moveItem(ListApp, ListAsignado);
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            moveItem(ListAsignado, ListApp);
        }

        private void btnDerechaAll_Click(object sender, EventArgs e)
        {
            moveAllItems(ListApp, ListAsignado);
        }

        private void btnIzquierdaAll_Click(object sender, EventArgs e)
        {
            moveAllItems(ListAsignado, ListApp);
        }

        private void asignar()
        {
            List<string> usuarios = lista_usr_table();
            if (usuarios.Count > 0)
            {
                clsRepo repo = new clsRepo();
                /*Delete*/
                string sql_delete_ent_app = "delete from entidad_aplicacion where id_entidad = (select id_entidad from entidad where samaccountname = '{x}')";

                foreach (DataRow dr in this._values.Rows)
                {
                    string id = dr["ID"].ToString();
                    string sql = sql_delete_ent_app.Replace("{x}", id);

                    repo.executeNonQuery(sql);
                }
        
                /*Read table*/
                foreach(string usuario in usuarios)
                {
                    foreach (object o in ListAsignado.Items)
                    {
                        Dominio.Aplicacion app = (Dominio.Aplicacion)o;
                        Dominio.EntidadAplicacion ent = new Dominio.EntidadAplicacion();
                        long id_entidad = repo.getIdEntidad(usuario);

                        ent.idAplicacion = app.idAplicacion;
                        ent.idEntidad = id_entidad;

                        repo.Insertar<Dominio.EntidadAplicacion>(ent);
                    }
                }
            }
        }

        private List<string> lista_usr_table()
        {
            List<string> lista = null;
            if (this._values.Rows.Count>0)
            {
                lista = new List<string>();
            }

            foreach (DataRow dr in this._values.Rows)
            {
                lista.Add(dr[0].ToString());
            }
            return lista;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Desea ejecutar los cambios realizados?", "Asignacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                asignar();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string sql = "select samaccountname as ID,cn as NOMBRE,description as PUESTO,department AS AREA,company AS EMPRESA from entidad";
            clsRepo repo = new clsRepo();
            DataTable dt =repo.Seleccionar(sql);
            frmLookForUsr frm = new frmLookForUsr("Usuarios", dt, "ID");

            frm.ShowDialog();

            DataRow dr = this._values.Rows.Add();
            dr["ID"] = frm.row_retorno["ID"];
            dr["NOMBRE"] = frm.row_retorno["NOMBRE"];
            dr["PUESTO"] = frm.row_retorno["PUESTO"];
            dr["AREA"] = frm.row_retorno["AREA"];
            dr["EMPRESA"] = frm.row_retorno["EMPRESA"];
            for (int x = 5; x < this._values.Columns.Count; x++)
            {
                dr[x] = false;
            }

            //frm.id_retorno


        }

    }
}

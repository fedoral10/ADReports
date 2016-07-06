using ADReports.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using SimpleExcelImport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADReports.Forms.ApUs
{
    public partial class frmUsrApp : Form
    {

        private DataTable _dtGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView _main_view;

        public frmUsrApp()
        {
            InitializeComponent();
            //InicializaGrid();
            llenar_cmb();
        }
        private void llenar_cmb()
        {
            foreach (string p in Dominio.PAIS.paises)
            {
                cmbPais.Items.Add(p);
            }
            cmbPais.Items.Add("TODOS");
            if (cmbPais.Items.Count > 0)
                cmbPais.SelectedIndex = 0;
        }
        private void InicializaGrid()
        {
            clsRepo repo = new clsRepo();
            _dtGrid = new DataTable();
            var apps = repo.Seleccionar<Dominio.Aplicacion>();

            _dtGrid.Columns.Add(new DataColumn("ID", typeof(string)));
            _dtGrid.Columns.Add(new DataColumn("NOMBRE", typeof(string)));
            _dtGrid.Columns.Add(new DataColumn("PUESTO", typeof(string)));


            foreach (Dominio.Aplicacion ap in apps)
            {
                DataColumn dc = new DataColumn(ap.nombre, typeof(bool));
                dc.DefaultValue = false;

                _dtGrid.Columns.Add(dc);
            }
            //dgvUsuarios.DataSource = this._dtGrid;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsRepo repo = new clsRepo();
            int apps = cmbPais.SelectedItem.ToString() == "TODOS"? repo.ContadorRows<Dominio.Aplicacion>() : repo.getCountAppPais(cmbPais.SelectedItem.ToString());//repo.ContadorRows<Dominio.Aplicacion>();
            int usr = repo.ContadorRows<Dominio.Entidad>();

            if (apps == 0 || usr == 0)
            {
                commons.showMessageBoxError(this.Text, "Verifique si hay Aplicaciones y Usuarios registrados en la aplicacion para ese pais");
                return;
            }

            //var lista = repo.Seleccionar<Dominio.Entidad>();
            //var timer = Stopwatch.StartNew();


            /*foreach (Dominio.Entidad ent in lista)
            {
                var entapps = repo.getEntidadAppValues(ent.samaccountname);
                _dtGrid.Rows.Add();
                if (entapps != null)
                {
                    foreach (Dominio.EntidadAplicacion ea in entapps)
                    { 
                        Dominio.Aplicacion app = repo.getApplicacion(ea.idAplicacion);
                        _dtGrid.Rows[_dtGrid.Rows.Count - 1][app.nombre] = true;
                    }
                }
            }
            dgvUsuarios.DataSource = _dtGrid;*/

            string sql_base = "select * from ( " +
                    "select e.samaccountname AS ID,e.cn as NOMBRE,e.description AS PUESTO,case when e.department ='' then e.physicaldeliveryofficename else e.department end AS AREA, company as EMPRESA, " +
                /*(select id_aplicacion from entidad_aplicacion where id_aplicacion = 1 and id_entidad = e.id_entidad) as scl,
                (select id_aplicacion from entidad_aplicacion where id_aplicacion = 2 and id_entidad = e.id_entidad) as xa*/
                    "{0} " +
                    " from entidad e" +
                    " ) as x where {1}";
            string apli;
            string a_sql = genera_columnas_x_pais(out apli);
            sql_base = string.Format(sql_base, a_sql, apli);
            this._dtGrid = repo.Seleccionar(sql_base);
            //dgvUsuarios.DataSource = this._dtGrid;

            gridView1.Columns.Clear();
            
            gc.DataSource = null;
            DevExpress.XtraGrid.Views.Grid.GridView view = new DevExpress.XtraGrid.Views.Grid.GridView(gc);

            view.OptionsBehavior.Editable = false;
            view.OptionsBehavior.ReadOnly = true;
            view.OptionsSelection.MultiSelect = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;

            gc.MainView = view;
            _main_view = view;
            gc.DataSource = this._dtGrid;



            /*timer.Stop();
            Console.WriteLine("----------------------");
            Console.WriteLine(string.Format("Elapsed para int.Parse: {0}", timer.Elapsed));
            Console.WriteLine(string.Format("ElapsedMilliseconds para int.Parse: {0}", timer.ElapsedMilliseconds));
            Console.WriteLine(string.Format("ElapsedTicks para int.Parse: {0}", timer.ElapsedTicks));
            Console.WriteLine("----------------------");*/

        }

        private string genera_columnas(out string apli)
        {
            apli = "";
            clsRepo repo = new clsRepo();
            IList<Dominio.Aplicacion> lista_apli = repo.Seleccionar<Dominio.Aplicacion>();

            //string sql_base = "(select case when id_aplicacion is null then false else true  end from entidad_aplicacion where id_aplicacion = {0} and id_entidad = e.id_entidad limit 1) as {1}";
            string sql_base = "(select case when (select count(id_aplicacion) from entidad_aplicacion where id_aplicacion = {0} and id_entidad =e.id_entidad)> 0 then true else false end) as {1}";
            string sql_fina = "";
            string where_base = " x.{0} is not null ";
            foreach (Dominio.Aplicacion app in lista_apli)
            {
                sql_fina = sql_fina + string.Format(sql_base, app.idAplicacion, "\""+app.nombre+"-"+app.pais+"\"") + ",";
                apli = apli + string.Format(where_base, "\"" + app.nombre + "-" + app.pais + "\"") + " or ";
            }
            sql_fina = sql_fina.Substring(0, sql_fina.Length - 1) + " ";
            apli = apli.Substring(0, apli.Length - 3);
            return sql_fina;
        }

        private string genera_columnas_x_pais(out string apli)
        {
            apli = "";
            clsRepo repo = new clsRepo();
            IList<Dominio.Aplicacion> lista_apli = cmbPais.SelectedItem.ToString() =="TODOS" ?  repo.Seleccionar<Dominio.Aplicacion>() : repo.getAplicacionesXPais(cmbPais.SelectedItem.ToString());

            //string sql_base = "(select case when id_aplicacion is null then false else true  end from entidad_aplicacion where id_aplicacion = {0} and id_entidad = e.id_entidad limit 1) as {1}";
            string sql_base = "(select case when (select count(id_aplicacion) from entidad_aplicacion where id_aplicacion = {0} and id_entidad =e.id_entidad)> 0 then true else false end) as {1}";
            string sql_fina = "";
            string where_base = " x.{0} is not null ";
            foreach (Dominio.Aplicacion app in lista_apli)
            {
                sql_fina = sql_fina + string.Format(sql_base, app.idAplicacion, "\"" + app.nombre + "-" + app.pais + "\"") + ",";
                apli = apli + string.Format(where_base, "\"" + app.nombre + "-" + app.pais + "\"") + " or ";
            }
            sql_fina = sql_fina.Substring(0, sql_fina.Length - 1) + " ";
            apli = apli.Substring(0, apli.Length - 3);
            return sql_fina;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            frmCmbAplicacion cmbApp = new frmCmbAplicacion();
            if (cmbApp.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string filtro = "Archivos Excel (*.xlsx)|*.xlsx";
            string archivo = commons.getOpenFile(filtro);
            if (string.IsNullOrEmpty(archivo))
            {
                return;
            }
            try
            {
                var data = File.ReadAllBytes(archivo);
                ImportFromExcel import = new ImportFromExcel();
                import.LoadXlsx(data);
                //first parameter it's the sheet number in the excel workbook
                //second parameter it's the number of rows to skip at the start(we have an header in the file)
                List<UsuarioExcel> output = import.ExcelToList<UsuarioExcel>(0, 1);
                int x = 0;

                /*string sql_base = "insert into entidad_aplicacion(id_aplicacion,id_entidad)" +
                             "values({0},(select id_entidad from entidad where samaccountname = '{1}' limit 1))";*/

                foreach (UsuarioExcel usr in output)
                {
                    /*Verifica si existe ese usuario*/
                    clsRepo repo = new clsRepo();

                    switch (repo.getCountEntidad(usr.ID))
                    {

                        /*Si es 0, el usuario no existe y se debe insertar*/
                        case 0:
                            repo.Insertar<Dominio.Entidad>(usr.getEntidad());
                        break;
                        case 1:
                            /*el usuario existe y se debe procesar*/
                        break;
                        default:
                            /*verificar ese usuario*/
                        return;


                    }
                    
                    //string sql = string.Format(sql_base, cmbApp.getAplicacion().idAplicacion, usr.ID);
                    try
                    {
                        Dominio.EntidadAplicacion ea = new Dominio.EntidadAplicacion();
                        ea.idAplicacion = cmbApp.getAplicacion().idAplicacion;
                        ea.idEntidad = repo.getIdEntidad(usr.ID);
                        repo.Insertar<Dominio.EntidadAplicacion>(ea);
                        //int lol = repo.Actualizacion(sql);
                        //Console.WriteLine("rows affected: " + lol + " usr ID:" + usr.ID);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error con usuario: " + usr.ID + "\n" + ex.Message);
                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                commons.showMessageBoxError(ex.Source, ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Reportes.clsReportes.call_reporte_matriz_app(_dtGrid);
        }

        private DataTable getSelectedRows()
        {
            DataTable dt = new DataTable();
            int[] row_index = _main_view.GetSelectedRows();

            foreach (GridColumn column in _main_view.Columns)
            {
                dt.Columns.Add(column.FieldName,column.ColumnType);
            }

            //rows
            for (int r = 0; r < row_index.Length; r++)
            {
                object[] rows = new object[dt.Columns.Count];
                
                //columns
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    rows[i] = this._main_view.GetRowCellValue(r, this._main_view.Columns[i].FieldName);
                }
                dt.Rows.Add(rows);
            }
            return dt;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            frmAsignacion frm = new frmAsignacion(this.getSelectedRows());

            frm.ShowDialog();
        }

    }
}

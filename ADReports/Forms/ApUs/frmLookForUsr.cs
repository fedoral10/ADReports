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
    public partial class frmLookForUsr : Form
    {
        private string _nombre_columna;

        public string id_retorno { get; set; }
        public DataRow row_retorno { get; set; }

        public frmLookForUsr(string nombre_form, DataTable dt,string nombre_columna)
        {
            InitializeComponent();
            this.dgvfTabla.DataSource = dt;
            this._nombre_columna = nombre_columna;
            this.Text = nombre_form;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            this.dgvfTabla.setFiltro(txtFiltro.Text);
        }

        private string get_value_table()
        {
            if (this.dgvfTabla.SelectedCells.Count > 0)
            {
                var row = this.dgvfTabla.Rows[this.dgvfTabla.SelectedCells[0].RowIndex];
                //var r = this.dgvfTabla.SelectedRows[0];
                //var dgvrow = this.dgvfTabla.SelectedRows[0];
                this.row_retorno = ((DataRowView)row.DataBoundItem).Row;
                this.Close();
                return row.Cells[this._nombre_columna].Value.ToString();
            }
            return null;
        }

        private void dgvfTabla_DoubleClick(object sender, EventArgs e)
        {
            id_retorno = get_value_table();
        }

        private void dgvfTabla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                id_retorno = get_value_table();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvfTabla.Focus();
            }
        }
    }
}

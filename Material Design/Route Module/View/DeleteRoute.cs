using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design.Route_Module.View
{
    public partial class DeleteRoute : Form
    {
        public DeleteRoute()
        {
            InitializeComponent();
        }
        RouteController RouteController = new RouteController();
        public BindingSource Databinding = new BindingSource();

        private void DeleteRoute_Load(object sender, EventArgs e)
        {

            dgvRoutes.DataSource = Databinding.DataSource = RouteController.Read();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Route model = new Route();
            if (dgvRoutes.SelectedRows.Count > 0)
            {
                DialogResult d;
                d = MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    model.RouteID = (int)dgvRoutes.CurrentRow.Cells[0].Value;
                    int rowIndex = dgvRoutes.CurrentCell.RowIndex;
                    DataGridViewRow row = RouteModule.instance.dgv.Rows[rowIndex];

                    RouteController.Delete(model.RouteID);
                    RouteModule.instance.Databinding.RemoveAt(row.Cells[0].RowIndex);
                    Databinding.RemoveAt(dgvRoutes.CurrentCell.RowIndex);
                    MessageBox.Show("Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public partial class DeleteBus : Form
    {
        public DeleteBus()
        {
            InitializeComponent();
        }
        BusController BusController = new BusController();
        public BindingSource Databinding = new BindingSource();

        private void DeleteBus_Load(object sender, EventArgs e)
        {

            dgvBus.DataSource = Databinding.DataSource = BusController.Read();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Bus model = new Bus();
            if (dgvBus.SelectedRows.Count > 0)
            {
                DialogResult d;
                d = MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    model.BusID = (int)dgvBus.CurrentRow.Cells[0].Value;
                    int rowIndex = dgvBus.CurrentCell.RowIndex;
                    DataGridViewRow row = BusModule.instance.dgvBus.Rows[rowIndex];

                    BusController.Delete(model.BusID);
                    BusModule.instance.Databinding.RemoveAt(row.Cells[0].RowIndex);
                    Databinding.RemoveAt(dgvBus.CurrentCell.RowIndex);
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

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
    public partial class DeleteDriver : Form
    {
        DriverController drivercontroller = new DriverController();

        
        public DeleteDriver()
        {
            InitializeComponent();
        }

        public BindingSource Databinding = new BindingSource();

        private void DeleteDriver_Load(object sender, EventArgs e)
        {

            dgvDrivers.DataSource =Databinding.DataSource = drivercontroller.Read();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Driver model = new Driver();
            if (dgvDrivers.SelectedRows.Count > 0)
            {
                DialogResult d;
                d = MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    model.DriverID = (int)dgvDrivers.CurrentRow.Cells[0].Value; 
                    int rowIndex = dgvDrivers.CurrentCell.RowIndex;
                    DataGridViewRow row = DriverModule.instance.dgvDrivers.Rows[rowIndex];

                    drivercontroller.Delete(model.DriverID);
                    //at DriverModule frondend
                    DriverModule.instance.Databinding.RemoveAt(row.Cells[0].RowIndex);
                    //at deletedriver view
                    Databinding.RemoveAt(dgvDrivers.CurrentCell.RowIndex);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design.Student_Module.View
{
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }
        public BindingSource Databinding = new BindingSource();
        StudentController controller = new StudentController();
        private void StudentModule_Load(object sender, EventArgs e)
        {

            dgvStudents.DataSource = Databinding.DataSource = controller.Read();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Driver model = new Driver();
            if (dgvStudents.SelectedRows.Count > 0)
            {
                DialogResult d;
                d = MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    model.DriverID = (int)dgvStudents.CurrentRow.Cells[0].Value;
                    int rowIndex = dgvStudents.CurrentCell.RowIndex;
                    DataGridViewRow row = StudentModule.instance.dgvStudents.Rows[rowIndex];
                    controller.Delete(model.DriverID);
                    StudentModule.instance.Databinding.RemoveAt(row.Cells[0].RowIndex);
                    Databinding.RemoveAt(dgvStudents.CurrentCell.RowIndex);
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

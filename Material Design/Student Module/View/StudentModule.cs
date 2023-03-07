using Material_Design.Route_Module.View;
using Material_Design.Student_Module.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public partial class StudentModule : Form
    {
        Student Model = new Student();
        StudentController controller = new StudentController();
        public static StudentModule instance;
        public BindingSource Databinding = new BindingSource();
        public DataTable table = new DataTable();
        public StudentModule()
        {
            InitializeComponent();
            instance = this;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddStudent student = new AddStudent();
            student.DataToGui();
            student.ShowDialog();
        }
        public void Student_Load(object sender, EventArgs e)
        {
            dgvStudents.DataSource = table = controller.Search("");
            Databinding.DataSource = table;
            btnStudent.Checked = true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvStudents.SelectedRows.Count > 0)
            {
                Model.StudentID = (int)dgvStudents.CurrentRow.Cells[0].Value;
                Model.StudentName = dgvStudents.CurrentRow.Cells[1].Value.ToString();
                Model.Age = (int)dgvStudents.CurrentRow.Cells[2].Value;
                Model.CNIC = dgvStudents.CurrentRow.Cells[3].Value.ToString();
                Model.PhoneNumber = dgvStudents.CurrentRow.Cells[4].Value.ToString();
                Model.Address = dgvStudents.CurrentRow.Cells[5].Value.ToString();
                UpdateStudent student = new UpdateStudent();
                student.DataToGui(Model);
                student.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select, First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void updateRowToGrid(Student Model)
        {

            int rowIndex = dgvStudents.CurrentCell.RowIndex;
            DataGridViewRow row = dgvStudents.Rows[rowIndex];

            var arraylist = new ArrayList() {
                Model.StudentID,
                Model.StudentName,
                Model.Age,
                Model.CNIC,
                Model.PhoneNumber,
                Model.Address,
            };


            for (int i = 0; i < table.Columns.Count; i++)
            {
                row.Cells[i].Value = arraylist[i];
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DeleteStudent deleteStudent = new DeleteStudent();
            deleteStudent.ShowDialog();
        }
        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            dgvStudents.DataSource = Databinding.DataSource = controller.Search(SearchText.Text);
        }

        private void backtoMenu_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Do you want to go Back to Menu?", "Go back", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.Hide();
                MainMenu menu = new MainMenu();
                menu.ShowDialog();
            }
        }
    }
}

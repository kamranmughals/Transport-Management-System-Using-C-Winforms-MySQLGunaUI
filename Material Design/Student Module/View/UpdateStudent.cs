using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design.Student_Module.View
{
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }
        Student Model = new Student();
        StudentController studentController = new StudentController();
        public void GuiToData(Student Model)
        {
            Model.StudentID = int.Parse(studentID.Text);
            Model.StudentName = studentname.Text;
            Model.Age = int.Parse(st_age.Text);
            Model.CNIC = stcnic.Text;
            Model.PhoneNumber = stphone.Text;
            Model.Address = staddress.Text;
        }
        public void DataToGui(Student Model)
        {
            studentID.Text = Model.StudentID.ToString();
            studentname.Text = Model.StudentName;
            st_age.Text = Model.Age.ToString();
            stcnic.Text = Model.CNIC;
            staddress.Text = Model.Address;
            stphone.Text = Model.PhoneNumber;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (studentname.Text == "" || st_age.Text == "" || stcnic.Text == "" || stphone.Text == "" || staddress.Text == "")
            {
                MessageBox.Show("Please fill the credentials");
            }
            if ((Convert.ToInt32(st_age.Text) < 25 || Convert.ToInt32(st_age.Text) > 85))
            {
                MessageBox.Show("Please enter age 25-85 !", "Incorrect age", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Do you want to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    GuiToData(Model);
                    studentController.Update(Model);
                    StudentModule.instance.updateRowToGrid(Model);
                    MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }


        }
        private void d_validKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {

                e.Handled = true;
            }
        }
    }
}

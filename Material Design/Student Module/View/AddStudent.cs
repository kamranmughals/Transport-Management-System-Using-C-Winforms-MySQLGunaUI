using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        Student Model = new Student();
        StudentController controller = new StudentController();
        
        public void GuiToData()
        {
            Model.StudentID = int.Parse(studentID.Text);
            Model.StudentName = studentname.Text;
            Model.Age = int.Parse(st_age.Text);
            Model.CNIC = stcnic.Text;
            Model.PhoneNumber = stphone.Text;
            Model.Address = staddress.Text;
        }
        public void DataToGui()
        {
            Model.StudentID = controller.IDIncrement();
            studentID.Text = Model.StudentID.ToString();
            studentname.PlaceholderText = Model.StudentName;
            st_age.PlaceholderText = Model.Age.ToString();
            stcnic.PlaceholderText = Model.CNIC;
            staddress.PlaceholderText = Model.Address;
            stphone.PlaceholderText = Model.PhoneNumber;
        }



        private void btnSave_Click(object sender, EventArgs e)
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
                d = MessageBox.Show("Do you want to add driver?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    GuiToData();
                    controller.Add(Model);
                    StudentModule.instance.table.Rows.Add(Model.StudentID.ToString(), Model.StudentName, Model.Age.ToString(), Model.CNIC, Model.Address, Model.PhoneNumber);
                    MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            DataToGui();
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

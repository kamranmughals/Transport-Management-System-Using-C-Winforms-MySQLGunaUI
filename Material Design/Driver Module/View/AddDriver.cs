using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public partial class AddDriver : Form
    {
        Driver Model = new Driver();
        DriverController controller = new DriverController();
        public AddDriver()
        {
            InitializeComponent();
        }
        public void GuiToData()
        {
            Model.DriverID = int.Parse(driver_ID.Text);
            Model.DriverName = driver_name.Text;
            Model.Age = int.Parse(d_age.Text);
            Model.CNIC = d_cnic.Text;
            Model.City = d_city.Text;
            Model.Address = d_address.Text;
            Model.PhoneNumber = d_phone.Text;
            Model.Salary = int.Parse(d_salary.Text);
        }
        public void DataToGui()
        {
            Model.DriverID = controller.IDIncrement();
                driver_ID.Text = Model.DriverID.ToString();
                driver_name.PlaceholderText = Model.DriverName;
                d_age.PlaceholderText = Model.Age.ToString();
                d_cnic.PlaceholderText = Model.CNIC;
                d_city.PlaceholderText = Model.City;
                d_address.PlaceholderText = Model.Address;
                d_phone.PlaceholderText = Model.PhoneNumber;
                d_salary.PlaceholderText = Model.Salary.ToString();
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
           

            if (driver_name.Text== "" || d_age.Text =="" || d_city.Text=="" || d_cnic.Text=="" || d_phone.Text=="" || d_salary.Text=="")
            {
                MessageBox.Show("Please fill the credentials");
            }
            if((Convert.ToInt32(d_age.Text) < 25 || Convert.ToInt32(d_age.Text) > 85)){
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
                    DriverModule.instance.table.Rows.Add(Model.DriverID.ToString(), Model.DriverName, Model.Age, Model.CNIC, Model.City, Model.Address, Model.PhoneNumber, Model.Salary.ToString());
                    MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }
        }

        private void AddDriver_Load(object sender, EventArgs e)
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

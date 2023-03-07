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
    public partial class UpdateDriver : Form
    {
        public UpdateDriver()
        {
            InitializeComponent();
        }
        Driver Model = new Driver();
        DriverController drivercontroller = new DriverController();




        public void GuiToData(Driver Model)
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
        public void DataToGui(Driver Model)
        {
            driver_ID.Text = Model.DriverID.ToString();
            driver_name.Text = Model.DriverName;
            d_age.Text = Model.Age.ToString();
            d_cnic.Text = Model.CNIC;
            d_city.Text = Model.City;
            d_address.Text = Model.Address;
            d_phone.Text = Model.PhoneNumber;
            d_salary.Text = Model.Salary.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (driver_name.Text == "" || d_age.Text == "" || d_city.Text == "" || d_cnic.Text == "" || d_phone.Text == "" || d_salary.Text == "")
            {
                MessageBox.Show("Please fill the credentials");
            }
            if ((Convert.ToInt32(d_age.Text) < 25 || Convert.ToInt32(d_age.Text) > 85))
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
                    drivercontroller.Update(Model);
                    DriverModule.instance.updateRowToGrid(Model);
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

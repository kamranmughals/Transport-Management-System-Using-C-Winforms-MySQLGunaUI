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

namespace Material_Design
{
    public partial class UpdateBus : Form
    {
        public UpdateBus()
        {
            InitializeComponent();
        }
        Bus Model = new Bus();
        BusController BusController = new BusController();
        public void GuiToData(Bus Model)
        {
            Model.BusID = int.Parse(bus_ID.Text);
            Model.BusNo = int.Parse(bus_no.Text);
            Model.BusType = bus_type.Text;
            Model.BusName = bus_name.Text;
            Model.PickUpTime = DateTime.Parse(bus_pickup.Text);
            Model.DropTime = DateTime.Parse(bus_droptime.Text);
        }
        public void DataToGui(Bus Model)
        {
            bus_ID.Text = Model.BusID.ToString();
            bus_no.Text = Model.BusNo.ToString();
            bus_type.Text = Model.BusType;
            bus_name.Text = Model.BusName;
            bus_pickup.Text = Model.PickUpTime.ToShortTimeString();
            bus_droptime.Text = Model.DropTime.ToShortTimeString();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (bus_no.Text == "" || bus_type.Text == "" || bus_name.Text == "" || bus_pickup.Text == "" || bus_droptime.Text == "")
            {
                MessageBox.Show("Please fill the credentials");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Do you want to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    GuiToData(Model);
                    BusController.Update(Model);
                    BusModule.instance.updateRowToGrid(Model);
                    MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }


        }

    }
}

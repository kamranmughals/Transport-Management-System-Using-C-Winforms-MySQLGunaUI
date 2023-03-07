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
    public partial class AddBus : Form
    {
        public AddBus()
        {
            InitializeComponent();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        Bus Model = new Bus();
        BusController controller = new BusController();
       
        public void GuiToData()
        {
            Model.BusID = int.Parse(bus_ID.Text);
            Model.BusNo = Convert.ToInt32(bus_no.Text);
            Model.BusType = bus_type.Text;
            Model.BusName = bus_name.Text;
            Model.PickUpTime = DateTime.Parse(bus_pickup.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Model.DropTime = DateTime.Parse(droptime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public void DataToGui()
        {
            Model.BusID = controller.IDIncrement();
            bus_ID.Text = Model.BusID.ToString();
            bus_no.PlaceholderText = Model.BusNo.ToString();
            bus_type.PlaceholderText =Model.BusType;
            bus_name.PlaceholderText = Model.BusName;
            bus_pickup.Value = Model.PickUpTime;
            droptime.Value = Model.DropTime;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {


            if (bus_no.Text == "" || bus_type.Text == "" || bus_name.Text == "" || bus_pickup.Text == "" || droptime.Text == "")
            {
                MessageBox.Show("Please fill the credentials");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Do you want to add Bus?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    GuiToData();
                    controller.Add(Model);
                    BusModule.instance.table.Rows.Add(Model.BusID.ToString(), Model.BusNo.ToString(), Model.BusType, Model.BusName, Model.PickUpTime,  Model.DropTime);
                    MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }
        }

        private void AddBus_Load(object sender, EventArgs e)
        {
            DataToGui();
        }

        private void TimeChanged(object sender, EventArgs e)
        {
            
            bus_pickup.CustomFormat = "HH:mm";
           droptime.CustomFormat = "HH:mm";
        }

        private void bus_pickup_MouseDown(object sender, MouseEventArgs e)
        {
            droptime.CustomFormat = "HH:mm";

            bus_pickup.CustomFormat = "HH:mm";
        }
    }
}

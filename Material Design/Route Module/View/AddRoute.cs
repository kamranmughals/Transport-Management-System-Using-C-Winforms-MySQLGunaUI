using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design.Route_Module.View
{
    public partial class AddRoute : Form
    {
        public AddRoute()
        {
            InitializeComponent();
        }
        Route Model = new Route();
        RouteController controller = new RouteController();

        public void GuiToData()
        {
            Model.RouteID = int.Parse(routeID.Text);
            Model.RoutePath = routepath.Text;
            Model.RouteName = routename.Text;
            Model.RouteSP = routesp.Text;
            Model.RouteEP = routeEp.Text;
        }
        public void DataToGui()
        {
                Model.RouteID = controller.IDIncrement();
                routeID.Text = Model.RouteID.ToString();
                routepath.PlaceholderText = Model.RoutePath;
                routename.PlaceholderText = Model.RouteName;
                routesp.PlaceholderText = Model.RouteSP;
                routeEp.PlaceholderText = Model.RouteEP;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {


            if (routepath.Text == "" || routename.Text == "" || routesp.Text == "" || routeEp.Text == "")
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
                    RouteModule.instance.table.Rows.Add(Model.RouteID, Model.RoutePath, Model.RouteName, Model.RouteSP, Model.RouteEP);
                    MessageBox.Show("Saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }
        }

        private void AddRoute_Load(object sender, EventArgs e)
        {
            DataToGui();
        }

        
    }
}

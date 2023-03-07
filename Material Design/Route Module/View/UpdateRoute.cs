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
    public partial class UpdateRoute : Form
    {
        public UpdateRoute()
        {
            InitializeComponent();
        }
        Route Model = new Route();
        RouteController RouteController = new RouteController();
        public void GuiToData(Route Model)
        {
            Model.RouteID = int.Parse(routeID.Text);
            Model.RoutePath = routepath.Text;
            Model.RouteName = routename.Text;
            Model.RouteSP = routesp.Text;
            Model.RouteEP = routeEp.Text;
        }
        public void DataToGui(Route Model)
        {
           
            routeID.Text = Model.RouteID.ToString();
            routepath.Text = Model.RoutePath;
            routename.Text = Model.RouteName;
            routesp.Text = Model.RouteSP;
            routeEp.Text = Model.RouteEP;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (routepath.Text == "" || routename.Text == "" || routesp.Text == "" || routeEp.Text == "")
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
                    RouteController.Update(Model);
                    RouteModule.instance.updateRowToGrid(Model);
                    MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Hide();
                }
            }


        }
    }
}

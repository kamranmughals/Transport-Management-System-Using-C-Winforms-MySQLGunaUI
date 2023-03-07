using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(d== DialogResult.Yes)
            {
                this.Hide();
            }
            
        }

        private void btnBus_Click(object sender, EventArgs e)
        {
            this.Hide();
            BusModule busModule = new BusModule();
            busModule.ShowDialog();
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverModule driverModule = new DriverModule();
            driverModule.ShowDialog();
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            this.Hide();
            RouteModule routeModule = new RouteModule();
            routeModule.ShowDialog();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentModule studentModule = new StudentModule();
            studentModule.ShowDialog();

        }
    }
}

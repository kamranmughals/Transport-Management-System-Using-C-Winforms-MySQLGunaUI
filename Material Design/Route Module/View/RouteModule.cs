using Material_Design.Route_Module.View;
using System;
using System.Collections;
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
    public partial class RouteModule : Form
    {
        RouteController routeController = new RouteController();
        public static RouteModule instance;
        Route Model = new Route();
        public BindingSource Databinding = new BindingSource();
        public DataTable table = new DataTable();
        public RouteModule()
        {
            InitializeComponent();
            instance = this;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddRoute newRoute = new AddRoute();
            newRoute.DataToGui();
            newRoute.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                Model.RouteID = (int)dgv.CurrentRow.Cells[0].Value;
                Model.RoutePath = dgv.CurrentRow.Cells[1].Value.ToString();
                Model.RouteName = dgv.CurrentRow.Cells[2].Value.ToString();
                Model.RouteSP = dgv.CurrentRow.Cells[3].Value.ToString();
                Model.RouteEP = dgv.CurrentRow.Cells[4].Value.ToString();
                UpdateRoute route = new UpdateRoute();
                route.DataToGui(Model);
                route.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select, First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void RouteLoad_Load(object sender, EventArgs e)
        {
            dgv.DataSource = table = routeController.Search("");
            Databinding.DataSource = table;
            btndriver.Checked = true;
        }
        public void updateRowToGrid(Route Model)
        {

            int rowIndex = dgv.CurrentCell.RowIndex;
            DataGridViewRow row = dgv.Rows[rowIndex];

            var arraylist = new ArrayList() {
                Model.RouteID,
                Model.RoutePath,
                Model.RouteName,
                Model.RouteSP,
                Model.RouteEP,
            };


            for (int i = 0; i < table.Columns.Count; i++)
            {
                row.Cells[i].Value = arraylist[i];
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DeleteRoute deleteRoute = new DeleteRoute();
            deleteRoute.ShowDialog();
        }
        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = Databinding.DataSource = routeController.Search(SearchText.Text);
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

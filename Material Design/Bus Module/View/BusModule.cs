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
    public partial class BusModule : Form
    {
        BusController Buscontroller = new BusController();
        Bus Model = new Bus();
        public BindingSource Databinding = new BindingSource();
        public DataTable table = new DataTable();

        public static BusModule instance;

        public BusModule()
        {

            InitializeComponent();
            instance = this;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddBus newBus = new AddBus();
            newBus.DataToGui();
            newBus.ShowDialog();
           
        }
        public void BusModule_Load(object sender, EventArgs e)
        {
            dgvBus.DataSource = table = Buscontroller.Search("");
            Databinding.DataSource = table;
            btnbus.Checked = true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dgvBus.SelectedRows.Count > 0)
            {


                Model.BusID = (int)dgvBus.CurrentRow.Cells[0].Value;
                Model.BusNo = (int)dgvBus.CurrentRow.Cells[1].Value;
                Model.BusType = dgvBus.CurrentRow.Cells[2].Value.ToString();
                Model.BusName = dgvBus.CurrentRow.Cells[3].Value.ToString();
                Model.PickUpTime = DateTime.Parse(dgvBus.CurrentRow.Cells[4].Value.ToString());    
                Model.DropTime = DateTime.Parse(dgvBus.CurrentRow.Cells[5].Value.ToString());
                UpdateBus bus = new UpdateBus();
                bus.DataToGui(Model);
                bus.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select, First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        public void updateRowToGrid(Bus Model)
        {

            int rowIndex = dgvBus.CurrentCell.RowIndex;
            DataGridViewRow row = dgvBus.Rows[rowIndex];

            var arraylist = new ArrayList() {
                Model.BusID,
                Model.BusNo,
                Model.BusType,
                Model.BusName,
                Model.PickUpTime,
                Model.DropTime,
            };


            for (int i = 0; i < table.Columns.Count; i++)
            {
                row.Cells[i].Value = arraylist[i];
            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DeleteBus deleteBus = new DeleteBus();
            deleteBus.ShowDialog();
        }
        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            dgvBus.DataSource = Databinding.DataSource = Buscontroller.Search(SearchText.Text);
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

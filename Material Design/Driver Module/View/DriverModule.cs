using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public partial class DriverModule : Form
    {
        DriverController drivercontroller = new DriverController();
        public static DriverModule instance;
        Driver Model = new Driver(); 
        public BindingSource Databinding = new BindingSource();
        public DataTable table = new DataTable();

        public DriverModule()
        {
            InitializeComponent();
            instance = this;
        }

       
        //new button for calling add module
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddDriver newDriver = new AddDriver();
            newDriver.DataToGui();
            newDriver.ShowDialog();
        }

     
        //update button and verify selected row index
        private void btnUpdate_Click(object sender, EventArgs e)
        {


            List<Driver> list = new List<Driver>();

            if (dgvDrivers.SelectedRows.Count > 0)
            {


                Model.DriverID = (int)dgvDrivers.CurrentRow.Cells[0].Value;
                Model.DriverName = dgvDrivers.CurrentRow.Cells[1].Value.ToString();
                Model.Age = (int)dgvDrivers.CurrentRow.Cells[2].Value;
                Model.CNIC = dgvDrivers.CurrentRow.Cells[3].Value.ToString();
                Model.City = dgvDrivers.CurrentRow.Cells[4].Value.ToString();
                Model.Address = dgvDrivers.CurrentRow.Cells[5].Value.ToString();
                Model.PhoneNumber = dgvDrivers.CurrentRow.Cells[6].Value.ToString();
                Model.Salary = (int)dgvDrivers.CurrentRow.Cells[7].Value;
                UpdateDriver driver = new UpdateDriver();
                driver.DataToGui(Model);
                driver.ShowDialog();    
            }
            else
            {
                MessageBox.Show("Please Select, First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //load module for data grid
        public void DriverModule_Load(object sender, EventArgs e)
        {
            //for adding row use table
            dgvDrivers.DataSource = table = drivercontroller.Search("");
            Databinding.DataSource = table;
            btndriver.Checked = true;
        }




        //update row
        public void updateRowToGrid(Driver Model)
        {

            int rowIndex = dgvDrivers.CurrentCell.RowIndex;
            DataGridViewRow row  = dgvDrivers.Rows[rowIndex];

            var arraylist = new ArrayList() { 
                Model.DriverID,
                Model.DriverName,
                Model.Age,
                Model.CNIC, Model.City,
                Model.Address,
                Model.PhoneNumber,
                Model.Salary
            };

            
            for(int i = 0; i < table.Columns.Count; i++)
            {
                row.Cells[i].Value = arraylist[i];
            }


        }

        //calling delete module
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DeleteDriver deleteDriver = new DeleteDriver();
            deleteDriver.ShowDialog();
        }



        //search by id, name, city 
        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            dgvDrivers.DataSource =Databinding.DataSource = drivercontroller.Search(SearchText.Text);
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

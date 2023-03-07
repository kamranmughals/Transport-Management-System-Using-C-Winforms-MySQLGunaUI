using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public partial class Login : Form
    {
        private string SQLQuery { get; set; }
        private static string conString = "datasource=localhost;port=3306;username=root;password=;database=transport;";
        private MySqlConnection connection = new MySqlConnection(conString);
        private MySqlCommand CMD { get; set; }
        public int AdminCode { get; set; }
        public string Password { get; set; }    
        public Login()
        {
            InitializeComponent();
        }
        bool flag = true;

        

        private void admincode_TextChanged(object sender, EventArgs e)
        {
            iconButton1.Visible= false;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            iconButton1.Visible = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (flag == true) {
                password.PasswordChar = '\0';
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.Eye;
                flag = false;
            }
            else
            {
                flag = true;
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                password.PasswordChar = '●';
            }

        }

        private void password_Click(object sender, EventArgs e)
        {
            if(password.Text == string.Empty)
            {
                password.PasswordChar = '●';
            }
        }

        void LoginCheck()
        {
            connection.Open();
            SQLQuery = "Select admincode, password from admin";
            CMD = new MySqlCommand(SQLQuery,connection);
            CMD.CommandText = SQLQuery;



            MySqlDataReader reader= CMD.ExecuteReader();


            while (reader.Read())
            {
                Login admin = new Login();
                admin.AdminCode = reader.GetInt32(0);
                admin.Password = reader.GetString(1);

                if(admincode.Text == admin.AdminCode.ToString() && password.Text == admin.Password)
                {
                    labelvalid.Text = "Login Success";
                    labelvalid.ForeColor = Color.Green;

                    DialogResult d;
                    d= MessageBox.Show("Login Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                    {
                        this.Hide();
                        MainMenu menu = new MainMenu();
                        menu.ShowDialog();

                    }
                    else
                    {
                        this.Close();
                    }

                }
                if(admincode.Text != admin.AdminCode.ToString())
                {
                    labelvalid.Text = "Invalid, admin code please try again";
                    labelvalid.ForeColor = Color.Red;
                }
                if(password != admin.password)
                {
                    labelvalid.Text = "Invalid,password please try again";
                    labelvalid.ForeColor = Color.Red;
                }
                else
                {
                    labelvalid.Text = "Invalid, admin code and password";
                    labelvalid.ForeColor = Color.Red;

                }
            }
            connection.Close();

        }
        private void admincode_Click(object sender, EventArgs e)
        {
            password.PasswordChar = '●';
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }
    }
}

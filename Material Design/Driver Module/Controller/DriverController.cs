using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_Design
{
    public class DriverController
    {

        private string SQLQuery { get; set; }
        private static string conString = "datasource=localhost;port=3306;username=root;password=;database=transport;";
        private MySqlConnection connection = new MySqlConnection(conString);

        public static List<Driver> list = new List<Driver>();
        private MySqlCommand CMD { get; set; }

        //add controller
        public void Add(Driver Model)
        {
            connection.Open();
            SQLQuery = "INSERT INTO driver values ('" + Model.DriverID + "','" + Model.DriverName + "','" + Model.Age + "','" + Model.CNIC + "','" + Model.City + "','" + Model.Address + "','" + Model.PhoneNumber + "','" + Model.Salary + "','" + "false" + "')";
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        //autoID increment
        public int IDIncrement()
        {
            connection.Open();
            SQLQuery = "Select Count(DriverID) from driver";
            CMD = new MySqlCommand(SQLQuery, connection);
            int maxID = Convert.ToInt32(CMD.ExecuteScalar());
            connection.Close();
            maxID++;
            return maxID;
        }



        //Driver Details
        public DataTable Read()
        {
            DataTable table = new DataTable();
            connection.Open();
            SQLQuery = "Select `DriverID`,`DriverName`,`Age`, `CNIC`, `City`, `Address`, `PhoneNumber`, `Salary` from driver where IsDeleted= 'false'";
            CMD = new MySqlCommand(SQLQuery, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(CMD);
            //adapter.FillSchema(table, SchemaType.Source);
            //table.Columns[0].DataType = typeof(string);
            //table.Columns[2].DataType = typeof(string);
            //table.Columns[7].DataType = typeof(string);
            adapter.Fill(table);
            connection.Close();
            return table;

        }
        //search controller
        public DataTable Search(string data)
        {
            DataTable table = new DataTable();
            connection.Open();
            SQLQuery = "SELECT `DriverID`,`DriverName`,`Age`, `CNIC`, `City`, `Address`, `PhoneNumber`, `Salary`  FROM driver WHERE CONCAT(`DriverID`,`DriverName`, `City`) Like '%" + data + "%' AND isDeleted = 'false'";
            CMD = new MySqlCommand(SQLQuery, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(CMD);
            adapter.Fill(table);   
            connection.Close();
            return table;
        }

        //Delete Driver
        public void Delete(int ID)
        {
            connection.Open();
            SQLQuery = "Update driver set IsDeleted = 'true'  where driverID = " + ID;
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        //update controller
        public void Update(Driver Model)
        {
            SQLQuery = "INSERT INTO driver(DriverID, DriverName, Age, CNIC, City, Address, PhoneNumber, Salary)" +
                "VALUES(@DriverID, @DriverName, @Age, @CNIC, @City, @Address, @PhoneNumber, @Salary) ON DUPLICATE KEY UPDATE DriverName = VALUES(DriverName), Age=VALUES(Age)," +
                "CNIC=VALUES(CNIC), City=VALUES(City), Address=VALUES(Address), PhoneNumber=VALUES(PhoneNumber), Salary=VALUES(Salary)";
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.Parameters.AddWithValue("@DriverID", Model.DriverID);
            CMD.Parameters.AddWithValue("@DriverName", Model.DriverName);
            CMD.Parameters.AddWithValue("@Age", Model.Age);
            CMD.Parameters.AddWithValue("@CNIC", Model.CNIC);
            CMD.Parameters.AddWithValue("@City", Model.City);
            CMD.Parameters.AddWithValue("@Address", Model.Address);
            CMD.Parameters.AddWithValue("@PhoneNumber", Model.PhoneNumber);
            CMD.Parameters.AddWithValue("@Salary", Model.Salary);
            connection.Open();
            CMD.ExecuteNonQuery();
            connection.Close();
        }
    }
}

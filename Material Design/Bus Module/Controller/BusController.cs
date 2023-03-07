using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Material_Design
{

    public class BusController
    {
        private string SQLQuery { get; set; }
        private static string conString = "datasource=localhost;port=3306;username=root;password=;database=transport;";
        private MySqlConnection connection = new MySqlConnection(conString);
        private MySqlCommand CMD { get; set; }
        private MySqlDataAdapter DataAdapter { get; set; }

        public static List<Driver> list = new List<Driver>();
        public void Add(Bus BusModel)
        {
            connection.Open();
            SQLQuery = "INSERT INTO bus values (" +BusModel.BusID + "," + BusModel.BusNo+ ",'" + BusModel.BusType + "','" + BusModel.BusName + "','" + BusModel.PickUpTime + "','" + BusModel.DropTime + "','" + "false" + "')";
            CMD = new MySqlCommand(SQLQuery,connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int id)
        {
            connection.Open();
            SQLQuery = "Update bus set IsDeleted = 'true'  where BusID = " + id;
            CMD = new MySqlCommand(SQLQuery,connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        public int IDIncrement()
        {
            connection.Open();
            SQLQuery = "Select Count(BusID) from bus";
            CMD = new MySqlCommand(SQLQuery, connection);
            int maxID = Convert.ToInt32(CMD.ExecuteScalar());
            connection.Close();
            maxID++;
            return maxID;
        }
        public DataTable Read()
        {

            DataTable table = new DataTable();
            SQLQuery = "Select `BusID`,`BusNo`,`BusType`, `BusName`, `PickUpTime`, `DropTime` from bus where IsDeleted= 'false'";
            CMD = new MySqlCommand(SQLQuery, connection);
           
            DataAdapter = new MySqlDataAdapter(CMD);
            DataAdapter.Fill(table);
            connection.Close();
            return table;
        }
        public DataTable Search(string data)
        {
            DataTable table = new DataTable();
            connection.Open();
            SQLQuery = "SELECT `BusID`,`BusNo`,`BusType`, `BusName`, `PickUpTime`, `DropTime` FROM bus WHERE CONCAT(`BusID`,`BusName`, `BusType`) Like '%" + data + "%' AND isDeleted = 'false'";
            CMD = new MySqlCommand(SQLQuery, connection);
          
            DataAdapter = new MySqlDataAdapter(CMD);
            DataAdapter.Fill(table);
            connection.Close();
            return table;
        }
       
        public void Update(Bus BusModel)
        {
            SQLQuery = "Update Bus Set BusNo='"+ BusModel.BusNo + "',BusType='" + BusModel.BusType + "', BusName='" +  BusModel.BusName + "',PickUpTime='" + BusModel.DropTime.ToString("dd/mm/yyyyy hh:mm:ss")  + "',DropTime='" + BusModel.DropTime.ToString("dd/mm/yyyyy hh:mm:ss") + "'";
            connection.Open();
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
    }
}

using Material_Design;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Design
{
    public class RouteController
    {
        private string SQLQuery { get; set; }
        private static string conString = "datasource=localhost;port=3306;username=root;password=;database=transport;";
        private MySqlConnection connection = new MySqlConnection(conString);
        private MySqlCommand CMD { get; set; }
        private MySqlDataAdapter DataAdapter { get; set; }
        public void Add(Route routeModel)
        {
            connection.Open();
            SQLQuery = "INSERT INTO route values (" + routeModel.RouteID + ",'" + routeModel.RouteName+ "','" + routeModel.RoutePath + "','" + routeModel.RouteSP + "','" + routeModel.RouteEP+"','" + "false" + "')";
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int id)
        {
            connection.Open();
            SQLQuery = "Update route set IsDeleted = 'true'  where RouteID = " + id;
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        public int IDIncrement()
        {
            connection.Open();
            SQLQuery = "Select Count(RouteID) from route";
            CMD = new MySqlCommand(SQLQuery, connection);
            int maxID = Convert.ToInt32(CMD.ExecuteScalar());
            connection.Close();
            maxID++;
            return maxID;
        }
        public DataTable Read()
        {
            DataTable table = new DataTable();
            connection.Open();
            SQLQuery = "Select `RouteID`,`RouteName`,`RoutePath`, `RouteSP`, `RouteEP` from route where IsDeleted= 'false'";
            CMD = new MySqlCommand(SQLQuery,connection);
            DataAdapter = new MySqlDataAdapter(CMD);
            DataAdapter.Fill(table);
            connection.Close();
            return table;
        }
        public DataTable Search(string data)
        {
            DataTable table = new DataTable();
            connection.Open();
            SQLQuery = "SELECT `RouteID`,`RoutePath`,`RouteName`, `RouteSP`, `RouteEP` FROM route WHERE CONCAT(`RouteID`,`RouteName`, `RoutePath`) Like '%" + data + "%' AND isDeleted = 'false'";
            CMD = new MySqlCommand(SQLQuery, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(CMD);
            adapter.Fill(table);
            connection.Close();
            return table;
        }

        public void Update(Route routeModel)
        {
            connection.Open();
            SQLQuery = "Update route Set RoutePath='" + routeModel.RoutePath + "',RouteName='" + routeModel.RouteName + "', RouteSP='" + routeModel.RouteSP + "',RouteEP='" + routeModel.RouteEP +"'";
            CMD = new MySqlCommand(SQLQuery,connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
    }
}

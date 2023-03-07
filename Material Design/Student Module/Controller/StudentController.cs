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
    public class StudentController 
    {
        private string SQLQuery { get; set; }
        private static string conString = "datasource=localhost;port=3306;username=root;password=;database=transport;";
        private MySqlConnection connection = new MySqlConnection(conString);
        private MySqlCommand CMD { get; set; }
        private MySqlDataAdapter DataAdapter { get; set; }
        public void Add(Student studentModel)
        {
            connection.Open();
            SQLQuery = "INSERT INTO student values ('" + studentModel.StudentID + "','" + studentModel.StudentName + "','" + studentModel.Age + "','" + studentModel.CNIC + "','" + studentModel.PhoneNumber + "','" + studentModel.Address + "','" + "false" + "')";
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int id)
        {
            connection.Open();
            SQLQuery = "Update student set IsDeleted = 'true'  where studentID = " + id;
            CMD = new MySqlCommand(SQLQuery,connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
        public int IDIncrement()
        {
            connection.Open();
            SQLQuery = "Select Count(StudentID) from student";
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
            SQLQuery = "Select `StudentID`,`StudentName`,`Age`, `CNIC`, `Phone`, `Address` from student where IsDeleted= 'false'";
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
            SQLQuery = "SELECT `studentID`,`studentName`,`Age`, `CNIC`, `Phone`, `Address` FROM student WHERE CONCAT(`studentID`,`studentName`) Like '%" + data + "%' AND isDeleted = 'false'";
            CMD = new MySqlCommand(SQLQuery, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(CMD);
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        

        public void Update(Student studentModel)
        {

            SQLQuery = "Update student Set StudentName='" + studentModel.StudentName + "',Age=" + studentModel.Age + ", CNIC='" + studentModel.CNIC + "',Phone='" + studentModel.PhoneNumber + "',Address='" +studentModel.Address + "'";
            connection.Open();
            CMD = new MySqlCommand(SQLQuery, connection);
            CMD.ExecuteNonQuery();
            connection.Close();
        }
    }
}

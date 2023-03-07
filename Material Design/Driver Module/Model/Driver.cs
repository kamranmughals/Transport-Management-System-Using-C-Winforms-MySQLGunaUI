using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Design
{
    public class Driver
    {

        public int DriverID { get; set; }
        public string DriverName { get; set; }
        public int Age { get; set; }
        public string CNIC { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }



        public Driver()
        {
            DriverID = 0;
            DriverName = "Enter Name";
            Age = 25;
            CNIC = "34202-8651512-1";
            City = "Lahore";
            Address = "Kakrali";
            PhoneNumber = "03417938434";
            Salary = 12000;
        }

        public Driver(int driverID, string driverName, int age, string cNIC, string city, string address, string phoneNumber, int salary)
        {
            DriverID = driverID;
            DriverName = driverName;
            Age = age;
            CNIC = cNIC;
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
            Salary = salary;
        }
    }
}

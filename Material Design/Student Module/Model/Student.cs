using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Design
{
    public class Student
    {

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


        public Student()
        {
            StudentID = 0;
            StudentName = "Student Name";
            Age = 0;
            CNIC = "34202-5678291-1";
            PhoneNumber = "0342319087";
            Address = "Village, etc";
        }
    }
}

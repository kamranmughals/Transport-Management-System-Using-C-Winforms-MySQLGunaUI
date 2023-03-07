using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Design
{
    public class Bus
    {
        public int BusID { get; set; }
        public int BusNo { get; set; }
        public string BusType { get; set; }
        public string BusName { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DropTime { get; set; }
        public int Salary { get; set; }



        public Bus()
        {
            BusID = 0;
            BusNo = 0;
            BusType = "Bus Type";
            BusName = "Bus Name";
            PickUpTime = DateTime.Now;
            DropTime = DateTime.Now;
        }

    }
}

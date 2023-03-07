using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_Design
{
    public class Route
    {
        public int RouteID { get; set; }
        public string RouteName { get; set; }

        public string RoutePath { get; set; }
        public string RouteSP { get; set; }
        public string RouteEP { get; set; }

        public Route() {
            RouteID = 0;
            RouteName = "Route Name";
            RoutePath = "Route Path";
            RouteSP = "Route Starting Point";
            RouteEP = "Route Ending Point";
        }
    }
}

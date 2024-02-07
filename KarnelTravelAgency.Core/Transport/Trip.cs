using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }
        public int VehicleID { get; set; }
        public int RouteID { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public Vehicle Vehicle { get; set; }
        public Route Route { get; set; }
    }

}

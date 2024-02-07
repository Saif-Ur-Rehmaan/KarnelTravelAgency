using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }
        public int AirlineID { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public Airline Airline { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Admin.Models
{
    public class FlightViewModel
    {
        public int FlightID { get; set; }
        public int AirlineID { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public string DepartureAirportCode { get; set; }
        [Required]
        public string ArrivalAirportCode { get; set; }
        [Required]
        public DateTime DepartureDateTime { get; set; }
        [Required]
        public DateTime ArrivalDateTime { get; set; }
        [Required]
        public Airline Airline { get; set; }
    }
}

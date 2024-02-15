using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Admin.Models
{
    public class FlightCreateViewModel
    {
        public int? FlightID { get; set; }
        [Required]
        [MaxLength(10)]
        public string FlightNumber { get; set; }
        [Required]
        [MaxLength(3)]
        public string DepartureAirportCode { get; set; }
        [MaxLength(3)]
        [Required]
        public string ArrivalAirportCode { get; set; }
        [Required]
        public DateTime DepartureDateTime { get; set; }
        [Required]
        public DateTime ArrivalDateTime { get; set; }
        [Required]
        public int AirlineID { get; set; }
        public Airline? Airline { get; set; }
        public List<Airline>? AirlineList { get; set; }
    }

}

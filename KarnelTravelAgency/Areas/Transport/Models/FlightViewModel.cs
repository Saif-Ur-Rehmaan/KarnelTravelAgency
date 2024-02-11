using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Transport.Models
{
    public class FlightViewModel
    {
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

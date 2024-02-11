namespace KarnelTravelAgency.Areas.Transport.Models
{
    public class SingleFlightViewModel
    {
        public int FlightID { get; set; }
        public int AirlineID { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string AirlineName { get; set; } // Add AirlineName property
        public string AirlineIATACode { get; set; } // Add AirlineIATACode property
        public string AirlineICAOCode { get; set; } // Add AirlineICAOCode property
    }
}

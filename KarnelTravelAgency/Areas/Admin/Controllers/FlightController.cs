using KarnelTravelAgency.Areas.Admin.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    public class FlightController(ApplicationDbContext context) : Controller
    {
        FlightRepository FlightRepo = new(context);
            

        [Route("/Admin/Flights")]
        public IActionResult Flights()
        {
            var allFlights = FlightRepo.GetAll().ToList();
            var Flights = new List<FlightViewModel>();
            foreach (var Flight in allFlights)
            {
                Flights.Add(new FlightViewModel()
                {
                    FlightID = Flight.FlightID,
                    AirlineID = Flight.AirlineID,
                    FlightNumber = Flight.FlightNumber,
                    DepartureAirportCode = Flight.DepartureAirportCode,
                    ArrivalAirportCode = Flight.ArrivalAirportCode,
                    DepartureDateTime = Flight.DepartureDateTime,
                    ArrivalDateTime = Flight.ArrivalDateTime,
                    Airline = Flight.Airline
                });
            }
            return View(Flights);
        }

    }
}

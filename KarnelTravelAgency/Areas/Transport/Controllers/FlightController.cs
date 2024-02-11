using KarnelTravelAgency.Areas.Transport.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAgency.Areas.Transport.Controllers
{
    [Area("Transport")]
    public class FlightController(ApplicationDbContext context) : Controller
    {
        public FlightRepository FlightRepo =new(context);

        [Route("/Flights")]
        public IActionResult Flights()
        {
            List<FlightViewModel> Flights = new();
            var FlightsFromDb = FlightRepo.GetAll().ToList();
            foreach (var flight in FlightsFromDb)
            {
                Flights.Add(new FlightViewModel()
                {
                    FlightID=flight.FlightID,
                    AirlineID =flight.AirlineID ,
                    FlightNumber=flight.FlightNumber ,
                    DepartureAirportCode=flight.DepartureAirportCode ,
                    ArrivalAirportCode=flight.ArrivalAirportCode ,
                    ArrivalDateTime=flight.ArrivalDateTime ,
                    Airline=flight.Airline 

                });

            }
            return View(Flights);
        }

        [Route("/Details/{id}")]
        public IActionResult Details(int id)
        {
            var flight = FlightRepo.GetAll().Include(f => f.Airline).FirstOrDefault(f => f.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            var flightViewModel = new SingleFlightViewModel
            {
                FlightID = flight.FlightID,
                AirlineID = flight.AirlineID,
                FlightNumber = flight.FlightNumber,
                DepartureAirportCode = flight.DepartureAirportCode,
                ArrivalAirportCode = flight.ArrivalAirportCode,
                DepartureDateTime = flight.DepartureDateTime,
                ArrivalDateTime = flight.ArrivalDateTime,
                AirlineName = flight.Airline.AirlineName, // Populate AirlineName property
                AirlineIATACode = flight.Airline.IATACode, // Populate AirlineIATACode property
                AirlineICAOCode = flight.Airline.ICAOCode // Populate AirlineICAOCode property
            };

            return View(flightViewModel);
        }

        [HttpPost]
        [Route("/Details")]
        public IActionResult Details(int id)
        {
            var flight = FlightRepo.GetAll().Include(f => f.Airline).FirstOrDefault(f => f.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            var flightViewModel = new SingleFlightViewModel
            {
                FlightID = flight.FlightID,
                AirlineID = flight.AirlineID,
                FlightNumber = flight.FlightNumber,
                DepartureAirportCode = flight.DepartureAirportCode,
                ArrivalAirportCode = flight.ArrivalAirportCode,
                DepartureDateTime = flight.DepartureDateTime,
                ArrivalDateTime = flight.ArrivalDateTime,
                AirlineName = flight.Airline.AirlineName, // Populate AirlineName property
                AirlineIATACode = flight.Airline.IATACode, // Populate AirlineIATACode property
                AirlineICAOCode = flight.Airline.ICAOCode // Populate AirlineICAOCode property
            };

            return View(flightViewModel);
        }

    }
}

using KarnelTravelAgency.Areas.Residence.Models;
using KarnelTravelAgency.Areas.Transport.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using KarnelTravelAgency.Repository.Transport.RepoTransport;
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
        [HttpGet]
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
        public IActionResult Details(SingleFlightViewModel SFVM)
        {
            int? userIdNullable = HttpContext.Session.GetInt32("UserId");
            int userId = userIdNullable.HasValue ? userIdNullable.Value : default(int); // Assigns default value (0) if userIdNullable is null
            if (userId == 0)
            {
                TempData["LoginFirstThenBook"] = "You Have To Login/Register Yourself First Before Booking Any Flight";
                return Redirect("/login");
            }

            var flight = FlightRepo.GetAll().Include(f => f.Airline).FirstOrDefault(f => f.FlightID == SFVM.FlightID);
            try
            {
                    new BookedFlightsRepository(context).Add(new BookedFlights()
                {
                    FlightId = SFVM.FlightID,
                    userId = userId,
                    Flight=flight,
                    user=(new UserRepository(context).GetAll().Where(x=>x.UserID==userId).First())
                }) ;//inserting new record
                    TempData["BookingResult"] = true;//indicates that data added successfully
            }
            catch (Exception ex)
            {

                TempData["BookingResult"] = false;//indicates that error occur while data inserting
                TempData["errorMsg"] = ex.Message.ToString();//to show error on Front end

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

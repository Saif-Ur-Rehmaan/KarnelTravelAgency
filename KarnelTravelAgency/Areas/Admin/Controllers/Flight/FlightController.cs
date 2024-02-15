using KarnelTravelAgency.Areas.Admin.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FlightController(ApplicationDbContext context) : Controller
    {
        FlightRepository FlightRepo = new(context);
        AirlineRepository AirlineRepo = new(context);
            

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





        [HttpGet]
        [Route("/Flight/Create")]
        public IActionResult Create()
        {
            return View(new FlightCreateViewModel()
            {
                AirlineList=AirlineRepo.GetAll().ToList()
            });
        }
        [HttpPost]
        [Route("/Flight/Create")]
        public IActionResult Create(FlightCreateViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    Core.Flight Flight = new()
                    { 
                        AirlineID=HVCM.AirlineID ,
                        FlightNumber=HVCM.FlightNumber ,
                        DepartureAirportCode=HVCM.DepartureAirportCode ,
                        ArrivalAirportCode=HVCM.ArrivalAirportCode ,
                        DepartureDateTime=HVCM.DepartureDateTime ,
                        ArrivalDateTime=HVCM.ArrivalDateTime ,
                        Airline=AirlineRepo.GetById(HVCM.AirlineID)
                    };
                    FlightRepo.Add(Flight);
                    TempData["State"] = true;
                    TempData["StateMsg"] = "Data Added Successfully";
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "error occur " + ex.Message;

                }

            }
            return Redirect("/Admin/Flights");

        }

        [HttpGet]
        [Route("/Flight/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var FlightFromDb = FlightRepo.GetById(Id);
            var Flight = new FlightEditViewModel()
            {
                FlightID = FlightFromDb.FlightID,
                AirlineID = FlightFromDb.AirlineID,
                FlightNumber = FlightFromDb.FlightNumber,
                DepartureAirportCode = FlightFromDb.DepartureAirportCode,
                ArrivalAirportCode = FlightFromDb.ArrivalAirportCode,
                DepartureDateTime = FlightFromDb.DepartureDateTime,
                ArrivalDateTime = FlightFromDb.ArrivalDateTime,
                Airline = AirlineRepo.GetById(FlightFromDb.AirlineID),
                AirlineList = AirlineRepo.GetAll().ToList()
            };
            return View(Flight);
        }

        [HttpPost]
        [Route("/Flight/Edit/{id}")]
        public IActionResult Update(int id, FlightEditViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing Flight from the database
                    var existingFlight = FlightRepo.GetById(id);

                    if (existingFlight != null)
                    {
                         
                        existingFlight.AirlineID = HVCM.AirlineID;
                        existingFlight.FlightNumber = HVCM.FlightNumber;
                        existingFlight.DepartureAirportCode = HVCM.DepartureAirportCode;
                        existingFlight.ArrivalAirportCode = HVCM.ArrivalAirportCode;
                        existingFlight.DepartureDateTime = HVCM.DepartureDateTime;
                        existingFlight.ArrivalDateTime = HVCM.ArrivalDateTime;
                        existingFlight.Airline = AirlineRepo.GetById(HVCM.AirlineID);
                        // Save changes to the database
                        FlightRepo.Update(existingFlight);

                        TempData["State"] = true;
                        TempData["StateMsg"] = "Data Updated Successfully";
                    }
                    else
                    {
                        TempData["State"] = false;
                        TempData["StateMsg"] = "Flight not found";
                    }
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Error occurred: " + ex.Message;
                }
            }

            return Redirect("/Admin/Flights");
        }


        [HttpGet]
        [Route("/Flight/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Flight = await FlightRepo.GetByIdAsync(id);
                if (Flight != null)
                {

                    // Delete the Flight record
                    FlightRepo.Delete(Flight);

                    TempData["State"] = true;
                    TempData["StateMsg"] = "Flight   deleted successfully";
                }
                else
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Flight not found";
                }
            }
            catch (Exception ex)
            {
                TempData["State"] = false;
                TempData["StateMsg"] = "An error occurred: " + ex.Message;
            }
            return Redirect("/Admin/Flights");
        }





    }
}

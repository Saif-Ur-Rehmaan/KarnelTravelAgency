using System.Globalization;
using KarnelTravelAgency.Areas.Residence.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Residence.Controllers
{
    [Area("Residence")]
    public class HotelController(ApplicationDbContext context) : Controller
    {
        HotelRepository HotelRepo = new(context);
        [Route("/Hotels")]
        public IActionResult Hotels()
        {
            List<HotelsViewModel> allHotels = new List<HotelsViewModel>();

            var AllHotels = HotelRepo.GetAll().ToList();
            foreach (var hotel in AllHotels)
            {
                allHotels.Add(new HotelsViewModel()
                {
                    Hotelid = hotel.HotelID,
                    HotelImg = hotel.HotelImg,
                    HotelName = hotel.HotelName,
                    Location = hotel.Location,
                    Rating = hotel.Rating
                });
            }

            return View(allHotels); // Pass the list of hotels as the model to the view
        }


        [HttpGet]
        [Route("/SingleHotel/{HotelId}")]
        public IActionResult SingleHotel(int HotelId)
        {
            if (HotelId != 0)
            {
                var hotel = HotelRepo.GetAll()
                    .Where(x => x.HotelID == HotelId)
                    .FirstOrDefault();
                //getting all rooms of hotel of id HotelId
                var rooms = (new RoomRepository(context)).GetAll().Where(x => x.HotelID == HotelId).ToList();
                var Hotel = new SingleHotelViewModel()
                {
                    hotelId = hotel.HotelID,
                    HotelName = hotel.HotelName,
                    HotelImg = hotel.HotelImg,
                    HotelLocation = hotel.Location,
                    HotelDescription = "hotel description",
                    HotelRooms = rooms,
                    HotelRating = hotel.Rating
                };
                //bundling 3 models in 1 model
                Bundle_SingleHotelViewModel bundle_singleHotel = new()
                {
                    Hotel = Hotel,
                    RoomsOfHotels = rooms                    
                };
                
                return View(bundle_singleHotel);
            }
            else
            {
                return Redirect("/Hotels");
            }
        }

        [HttpPost]
        [Route("/SingleHotelRoomBooking")]
        public IActionResult SingleHotel(BookRoomVewModel  RBM)
        {
            int? userIdNullable = HttpContext.Session.GetInt32("UserId");
            int userId = userIdNullable.HasValue ? userIdNullable.Value : default(int); // Assigns default value (0) if userIdNullable is null
            if (userId == 0)
            {
                TempData["LoginFirstThenBook"] = "You Have To Login/Register Yourself First Before Booking Any Room";
                return Redirect("/login");
            }
            else
            {
                        var HotelId = RBM.HotelID;
                        var hotel = HotelRepo.GetAll()
                         .Where(x => x.HotelID == HotelId)
                         .FirstOrDefault();
                        //getting all rooms of hotel of id HotelId
                        var rooms = (new RoomRepository(context)).GetAll().Where(x => x.HotelID == HotelId).ToList();
                        var Hotel = new SingleHotelViewModel()
                        {
                            hotelId = hotel.HotelID,
                            HotelName = hotel.HotelName,
                            HotelImg = hotel.HotelImg,
                            HotelLocation = hotel.Location,
                            HotelDescription = "hotel description",
                            HotelRooms = rooms,
                            HotelRating = hotel.Rating
                        };
                        //bundling 3 models in 1 model
                        Bundle_SingleHotelViewModel bundle_singleHotel = new()
                        {
                            Hotel = Hotel,
                            RoomsOfHotels = rooms
                        };

                        if (ModelState.IsValid)
                        {

                            Reservation newHotelReservation = new()
                            {
                                HotelID = RBM.HotelID,
                                RoomID = RBM.RoomId,
                                Guest = new()
                                {
                                    GuestID = userId,
                                    Email = "example@gmail.com",
                                    FirstName="ex1",
                                    LastName="last",
                                    Phone="12426378467"
                                },
                                CheckInDate =RBM.CheckInDate,
                                CheckOutDate = RBM.CheckOutDate
                            };

                            ReservationRepository HotelResRepo = new(context);
                            try
                            {
                                HotelResRepo.Add(newHotelReservation);
                                TempData["BookingResult"] = true;
                            }
                            catch (Exception ex)
                            {
                                TempData["BookingResult"] = false;
                                TempData["errorMsg"] = ex.Message.ToString();
                            }
                            return View(bundle_singleHotel);
                        }
                        else
                        {
                                TempData["BookingResult"] = false;
                                TempData["errorMsg"] = "model not valid";
                            return View(bundle_singleHotel);

                        }

            }
        }
    }
}

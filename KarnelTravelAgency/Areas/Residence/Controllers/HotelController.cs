using System.Globalization;
using KarnelTravelAgency.Areas.Residence.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KarnelTravelAgency.Areas.Residence.Controllers
{
    [Area("Residence")]
    public class HotelController(ApplicationDbContext context) : Controller
    {
        private HotelRepository HotelRepo = new(context);
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
        public IActionResult SingleHotel(Bundle_SingleHotelViewModel bm)
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
                var RBM = bm.BookedRoom;
                int HotelID = bm.Hotel.hotelId;
                int RoomID = RBM.RoomID;
                DateTime CheckInDate = RBM.CheckInDate;
                DateTime CheckOutDate = RBM.CheckOutDate;

                /* returning data*/
                var hotel = HotelRepo.GetAll().Where(x => x.HotelID == HotelID).FirstOrDefault();//get hotel
                var roomList = (new RoomRepository(context)).GetAll().Where(x => x.HotelID == HotelID).ToList();//get rooms avalible in hotel
                var SingleHotelViewModel = new SingleHotelViewModel()
                {
                    hotelId = hotel.HotelID,
                    HotelName = hotel.HotelName,
                    HotelImg = hotel.HotelImg,
                    HotelLocation = hotel.Location,
                    HotelDescription = "hotel description",
                    HotelRooms = roomList,
                    HotelRating = hotel.Rating
                };
                Bundle_SingleHotelViewModel Data = new()
                {
                    Hotel = SingleHotelViewModel,
                    RoomsOfHotels = roomList
                };
                /* returning data*/




                // Add the new guest to the database
                try
                {
                    // Check if the room is already reserved for the given date range
                    var isGuestReserved = (new ReservationRepository(context)).GetAll().Any(x =>
                        x.HotelID == HotelID &&
                        x.RoomID == RoomID &&
                        // Compare dates without considering time
                        x.CheckInDate.Date <= RBM.CheckOutDate.Date && // Check if existing reservation check-in date is before or same as new reservation check-out date
                        x.CheckOutDate.Date >= RBM.CheckInDate.Date   // Check if existing reservation check-out date is after or same as new reservation check-in date
                    );
                    if (!isGuestReserved)
                    {
                        // Create a new Guest object with the guest details
                        Guest newGuest = new Guest()
                        {
                            FirstName = RBM.FirstName,
                            LastName = RBM.LastName,
                            Email = RBM.Email,
                            Phone = RBM.Phone
                        };
                        (new GuestRepository(context)).Add(newGuest);
                        // creating new reservation
                        Reservation newHotelReservation = new Reservation()
                        {
                            HotelID = HotelID,
                            RoomID = RoomID,
                            GuestID = newGuest.GuestID, // Assign the generated GuestID
                            CheckInDate = CheckInDate,
                            CheckOutDate = CheckOutDate,
                            Guest = newGuest,// Assign the newly created Guest object
                            Hotel = (HotelRepo.GetAll().Where(x => x.HotelID == HotelID).First()),
                            Room = (new RoomRepository(context).GetAll().Where(x => x.RoomID == RoomID).First())
                        };
                        //inserting reservation in db
                        try
                        {
                            //tryin to insert new reservation in db
                            (new ReservationRepository(context)).Add(newHotelReservation);
                            TempData["BookingResult"] = true;//indicates that data added successfully

                        }
                        catch (Exception ex)
                        {
                            TempData["BookingResult"] = false;//indicates that error occur while data inserting
                            TempData["errorMsg"] = ex.Message.ToString();//to show error on Front end
                        }

                        return View(Data);

                    }
                    else
                    {
                        TempData["BookingResult"] = false;//indicates that room is reserved
                        TempData["errorMsg"] = "the room is Already Reserved try Booking different in different time period";//to show error on Front end
                        return View(Data);
                    }

                }
                catch (Exception ex)
                {
                    TempData["BookingResult"] = false;//indicates that error occur while data inserting
                    TempData["errorMsg"] = "TheRoom Is Already Reserved For the given Time period" + ex.Message.ToString();//to show error on Front end
                    return View(Data);
                }






            }
        }

        [Route("/SearchHotel")]
        public IActionResult SearchHotel()
        {
            var Location = Request.Query["Location"];
            var MaximumPrice = decimal.Parse(Request.Query["MaximumPrice"]);



            var AllHotels = (from hotel in context.Hotels
                             join room in context.Rooms
                             on hotel.HotelID equals room.HotelID
                             where
                                 hotel.Location.Contains(Location) &&
                                 room.Price <= MaximumPrice
                             select hotel
                            ).ToList();


            List<HotelsViewModel> allHotels = new List<HotelsViewModel>();
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
            if (allHotels.Any())
            {
                return View("Hotels", allHotels);
            }
            else
            {
                TempData["NoDataAvalible"] = "no data Avalible For the given Location and price range";
                return Redirect("/");

            }
        }
 
            [HttpPost]
            [Route("/AjaxSearch_Hotels")]
            public IActionResult AjaxSearch_Hotels()
            {
                string query = Request.Form["Query"];
                List<Hotel> AllHotels;
                AllHotels = HotelRepo.GetAll().Where(hotel => hotel.Location.Contains(query)).ToList();
                if (!AllHotels.Any())
                {
                    AllHotels = HotelRepo.GetAll().Where(hotel => hotel.HotelName.Contains(query)).ToList();
                    if (!AllHotels.Any() && decimal.TryParse(query, out var a))
                    {
                        AllHotels = HotelRepo.GetAll().Where(resort => resort.Rating <= a).ToList();
                    }
                }
                List<HotelsViewModel> allHotels = new List<HotelsViewModel>();
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
                var jsonStr = JsonConvert.SerializeObject(allHotels);
                return Content(jsonStr, "application/json");
            }

        }
}

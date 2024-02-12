using KarnelTravelAgency.Areas.Residence.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Residence.Controllers
{
     [Area("Residence")]
    public class ResortController(ApplicationDbContext context) : Controller
    {
        ResortRepository ResortRepo = new(context);
        [Route("/Resorts")]
        public IActionResult Resorts()
        {
            List<ResortsViewModel> allResorts = new();

            var AllResorts = ResortRepo.GetAll().ToList();
            foreach (var Resort in AllResorts)
            {
                allResorts.Add(new ResortsViewModel()
                {
                    ResortID= Resort.ResortID,
                    ResortImg = Resort.ResortImg,
                    ResortName = Resort.ResortName,
                    Location = Resort.Location,
                    Rating = Resort.Rating
                });
            }

            return View(allResorts); // Pass the list of hotels as the model to the view
           
        }
     
         


        [HttpGet]
        [Route("/SingleResort/{ResortId}")]
        public IActionResult SingleResort(int ResortId)
        {
            if (ResortId != 0)
            {
                var Resort = ResortRepo.GetAll()
                    .Where(x => x.ResortID == ResortId)
                    .FirstOrDefault();
                //getting all rooms of hotel of id ResortId
                var rooms = (new ResortRoomRepository(context)).GetAll().Where(x => x.ResortID== ResortId).ToList();
                var SingleResort = new SingleResortViewModel()
                {
                    ResortID = Resort.ResortID,
                    ResortName = Resort.ResortName,
                    ResortImg = Resort.ResortImg,
                    Location= Resort.Location,
                    resortlDescription= "resort description",
                    ResortRooms = rooms,
                    Rating = Resort.Rating
                };
                //bundling 3 models in 1 model
                Bundle_SinglelResortViewModel bundle_singleResort = new()
                {
                    resort = SingleResort,
                    RoomsOfHotels=rooms,
                    BookedResortRoom=new()
                };

                return View(bundle_singleResort);
            }
            else
            {
                return Redirect("/Resorts");
            }
        }

        [HttpPost]
        [Route("/SingleResortRoomBooking")]
        public IActionResult SingleResort(Bundle_SinglelResortViewModel bm)
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
                var RBM = bm.BookedResortRoom;
                int ResortId = bm.resort.ResortID;
                int RoomID = RBM.ResortRoomID;
                DateTime CheckInDate = RBM.CheckInDate;
                DateTime CheckOutDate = RBM.CheckOutDate;

                /* returning data*/
                var Resort = ResortRepo.GetAll().Where(x => x.ResortID == ResortId).FirstOrDefault();//get resorts
                var roomList = (new ResortRoomRepository(context)).GetAll().Where(x => x.ResortID== ResortId).ToList();//get rooms avalible in resorts
                var SingleHotelViewModel = new SingleResortViewModel()
                {
                    ResortID = Resort.ResortID,
                    ResortName = Resort.ResortName,
                    ResortImg = Resort.ResortImg,
                    Location= Resort.Location,
                    resortlDescription= "hotel description",
                    ResortRooms = roomList,
                    Rating = Resort.Rating
                };
                Bundle_SinglelResortViewModel Data = new()
                {
                    resort = SingleHotelViewModel,
                    RoomsOfHotels = roomList
                };
                /* returning data*/




                // Add the new guest to the database
                try
                {
                    // Check if the room is already reserved for the given date range
                    var isGuestReserved = (new ResortReservationRepository(context)).GetAll().Any(x =>
                        x.ResortID == ResortId &&
                        x.RoomID == RoomID &&
                        // Compare dates without considering time
                        x.CheckInDate.Date <= RBM.CheckOutDate.Date && // Check if existing reservation check-in date is before or same as new reservation check-out date
                        x.CheckOutDate.Date >= RBM.CheckInDate.Date   // Check if existing reservation check-out date is after or same as new reservation check-in date
                    );
                    if (!isGuestReserved)
                    {
                        // Create a new Guest object with the guest details
                        ResortGuest newGuest = new()
                        {
                            FirstName = RBM.FirstName,
                            LastName = RBM.LastName,
                            Email = RBM.Email,
                            Phone = RBM.Phone
                        };
                        (new ResortGuestRepository(context)).Add(newGuest);
                        // creating new reservation
                        ResortReservation newResortReservation = new()
                        {
                             ResortID= ResortId,
                            RoomID = RoomID,
                            GuestID = newGuest.GuestID, // Assign the generated GuestID
                            CheckInDate = CheckInDate,
                            CheckOutDate = CheckOutDate,
                            Guest = newGuest,// Assign the newly created Guest object
                            Resort = (ResortRepo.GetAll().Where(x => x.ResortID== ResortId).First()),
                            Room = (new ResortRoomRepository(context).GetAll().Where(x => x.RoomID== RoomID).First())
                        };
                        //inserting reservation in db
                        try
                        {
                            //tryin to insert new reservation in db
                            (new ResortReservationRepository(context)).Add(newResortReservation);
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






        [Route("/SearchResort")]
        public IActionResult SearchResort()
        {
            var Location = Request.Query["Location"];
            var MaximumPrice = decimal.Parse(Request.Query["MaximumPrice"]);

        

            var resorts = (from resort in context.Resorts
                             join Resortroom in context.ResortRooms
                             on resort.ResortID equals Resortroom.ResortID
                             where
                                 resort.Location.Contains(Location) &&
                                 Resortroom.Price <= MaximumPrice
                             select resort
                            ).ToList();


            List<ResortsViewModel> allResorts = new();

            var AllResorts = ResortRepo.GetAll().ToList();
            foreach (var Resort in resorts)
            {
                allResorts.Add(new ResortsViewModel()
                {
                    ResortID = Resort.ResortID,
                    ResortImg = Resort.ResortImg,
                    ResortName = Resort.ResortName,
                    Location = Resort.Location,
                    Rating = Resort.Rating
                });
            }
            if (allResorts.Any())
            {
                return View("Resorts", allResorts);
            }
            else
            {
                TempData["NoDataAvalible"] = "no data Avalible For the given Location and price range";
                return Redirect("/");

            }
        }




    }
}

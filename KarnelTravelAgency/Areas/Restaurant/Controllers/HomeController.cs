using System.Runtime.Intrinsics.Arm;
using KarnelTravelAgency.Areas.Residence.Models;
using KarnelTravelAgency.Areas.Restaurant.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using KarnelTravelAgency.Repository.Restaurant.RepoRestaurant;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KarnelTravelAgency.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class HomeController(ApplicationDbContext context) : Controller
    {
        private RestaurantRepository RestaurantRepo= new(context);

        [Route("/Restaurants")]
        public IActionResult Index()
        {
                         var resturants = new List<RestaurantViewModel>();
                        PackegeRepository pack = new(context);
                        var allRestaurants=RestaurantRepo.GetAll().ToList();
                        foreach (var restaurant in allRestaurants)
                        { 
                            resturants.Add(new RestaurantViewModel
                            {
                                RestaurantID=restaurant.RestaurantID,
                                RestaurantName=restaurant.RestaurantName,
                                CuisineType=restaurant.CuisineType,
                                Location=restaurant.Location,
                                Rating=restaurant.Rating, 
                            });
                        }

                        return View(resturants);
        }
        [HttpGet]
        [Route("/SingleRestaurant/{RestaurantId}")]
        public IActionResult SingleRestaurant(int RestaurantId)
        {
            return View(getDataForSingleResturantPage(RestaurantId));
        }
        [HttpPost]
        [Route("/SingleRestaurant")]
        public IActionResult SingleRestaurant(Bundle_SingleRestaurantView BRVM)
        {
            int? userIdNullable = HttpContext.Session.GetInt32("UserId");
            int userId = userIdNullable.HasValue ? userIdNullable.Value : default(int); // Assigns default value (0) if userIdNullable is null
            if (userId == 0)
            {
                TempData["LoginFirstThenBook"] = "You Have To Login/Register Yourself First Before Booking Any Room";
                return Redirect("/login");
            }
            var RestaurantId = BRVM.Restaurant.RestaurantID;

            try
            {
                var isGuestReserved = (new RestaurantReservationRepository(context)).GetAll().Any(x =>
                       x.RestaurantID ==BRVM.Restaurant.RestaurantID &&
                       x.TableID == BRVM.reservation.TableID &&
                       x.ReservationDateTime == BRVM.reservation.ReservationDateTime // Check if existing reservation check-in date is before or same as new reservation check-out date
                   );
                if (!isGuestReserved)
                {
                    try
                    {
                        // Creating and uploding on db a new Guest object with the guest details
                        RestaurantCustomer newcustomer = new()
                        {
                            Email = BRVM.Customer.Email,
                            FirstName = BRVM.Customer.FirstName,
                            LastName = BRVM.Customer.LastName,
                            Phone = BRVM.Customer.Phone,

                        };//creating new customer
                        (new RestaurantCustomerRepository(context)).Add(newcustomer);//inserting new restaurent reservatuion customer

                        // Creating and uploding on db new reservation
                        RestaurantReservation restaurantReservation = new()
                        {
                            RestaurantID = BRVM.Restaurant.RestaurantID,
                            TableID = BRVM.reservation.TableID,
                            CustomerID = newcustomer.CustomerID,
                            ReservationDateTime = BRVM.reservation.ReservationDateTime,
                            Restaurant  =(RestaurantRepo.GetAll().Where(x=>x.RestaurantID== BRVM.Restaurant.RestaurantID).First()),
                            Table  =(new TableRepository(context).GetAll().Where(x=>x.RestaurantID== BRVM.Restaurant.RestaurantID).First()),
                            Customer = newcustomer
                        };//creating new reservation
                        new RestaurantReservationRepository(context).Add(restaurantReservation);//creating new reservation
                        TempData["BookingResult"] = true;//indicates that data added successfully

                    }
                    catch (Exception ex)
                    {
                        TempData["BookingResult"] = false;//indicates that error occur while data inserting
                        TempData["errorMsg"] = ex.Message.ToString();//to show error on Front end
                    }


                }
                else {
                    TempData["BookingResult"] = false;//indicates that room is reserved
                    TempData["errorMsg"] = "the room is Already Reserved try Booking different in different time period";//to show error on Front end
                    return View(getDataForSingleResturantPage(RestaurantId));

                }






            }
            catch (Exception ex)
            {
                TempData["BookingResult"] = false;//indicates that room is reserved
                TempData["errorMsg"] = "error occur "+ex.Message.ToString();//to show error on Front end

                throw;
            }





            return View(getDataForSingleResturantPage(RestaurantId));
        }
        private Bundle_SingleRestaurantView getDataForSingleResturantPage(int RestaurantId)
        {
            var retFromDb = RestaurantRepo.GetAll().Where(x => x.RestaurantID == RestaurantId).First();
            RestaurantViewModel restaurant = new()
            {
                RestaurantID = retFromDb.RestaurantID,
                RestaurantName = retFromDb.RestaurantName,
                CuisineType = retFromDb.CuisineType,
                Location = retFromDb.Location,
                Rating = retFromDb.Rating
            };
            List<RestaurantMenuItem> MenuItemsOfRestaurant = (new RestaurantMenuItemRepository(context)).GetAll().Where(x => x.RestaurantID == RestaurantId).ToList();
            List<Table> ResturantTables = (new TableRepository(context)).GetAll().Where(x => x.RestaurantID == RestaurantId).ToList();
            Bundle_SingleRestaurantView data = new()
            {
                Restaurant = restaurant,
                MenuItemsOfRestaurant = MenuItemsOfRestaurant,
                RestaurantTables = ResturantTables
            };
            return data;

        }




        [Route("/SearchRestaurant")]
        public IActionResult SearchHotel()
        {
            var Location = Request.Query["Location"];
            var MaximumPrice = decimal.Parse(Request.Query["MaximumPrice"]);



            var AllRestaurant = (from restautant in context.Restaurants
                             join restMenuPrice in context.RestaurantMenuItems
                             on restautant.RestaurantID equals restMenuPrice.RestaurantID
                             where
                                 restautant.Location.Contains(Location) &&
                                 restMenuPrice.Price <= MaximumPrice
                             select restautant
                            ).ToList();


            List<RestaurantViewModel> allRestaurants = new();
            foreach (var Restaurant in AllRestaurant)
            {
                allRestaurants.Add(new RestaurantViewModel()
                {
                    RestaurantID= Restaurant.RestaurantID,
                    RestaurantName = Restaurant.RestaurantName,
                    Location = Restaurant.Location,
                    Rating = Restaurant.Rating
                });
            }
            if (allRestaurants.Any())
            {
                return View("Index", allRestaurants);
            }
            else
            {
                TempData["NoDataAvalible"] = "no data Avalible For the given Location and price range";
                return Redirect("/");

            }
        }



    }
}

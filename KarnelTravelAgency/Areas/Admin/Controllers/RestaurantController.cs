using KarnelTravelAgency.Areas.Admin.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantController(ApplicationDbContext context) : Controller
    {
        RestaurantRepository ResTaurantRepo = new(context);

        [Route("/Admin/Restaurants")]
        public IActionResult Restaurants()
        {
            var allRestaurant = ResTaurantRepo.GetAll().ToList();
            var Restaurants = new List<RestaurantViewModel>();
            foreach (var Restaurant in allRestaurant)
            {
                Restaurants.Add(new RestaurantViewModel()
                {
                    RestaurantID = Restaurant.RestaurantID,
                    RestaurantName = Restaurant.RestaurantName,
                    Location = Restaurant.Location,
                    CuisineType = Restaurant.CuisineType,
                    Rating = Restaurant.Rating
                });
            }
            return View(Restaurants);

        }

    }
}

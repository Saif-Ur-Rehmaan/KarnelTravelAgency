using KarnelTravelAgency.Areas.Admin.Models; 
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantController(ApplicationDbContext context) : Controller
    {
        RestaurantRepository RestaurantRepo = new(context);

        [Route("/Admin/Restaurants")]
        public IActionResult Restaurants()
        { 
            var allRestaurant = RestaurantRepo.GetAll().ToList();
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





        [HttpGet]
        [Route("/Restaurant/Create")]
        public IActionResult Create()
        {
            return View(new RestaurantCreateViewModel());
        }
        [HttpPost]
        [Route("/Restaurant/Create")]
        public IActionResult Create(RestaurantCreateViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     

                    Core.Restaurant Restaurant = new()
                    {
                        RestaurantName = HVCM.RestaurantName,
                        Location = HVCM.Location,
                        Rating = HVCM.Rating,
                        CuisineType=HVCM.CuisineType                        
                    };
                    RestaurantRepo.Add(Restaurant);
                    TempData["State"] = true;
                    TempData["StateMsg"] = "Data Added Successfully";
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "error occur " + ex.Message;

                }

            }
            return Redirect("/Admin/Restaurants");

        }

        [HttpGet]
        [Route("/Restaurant/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var RestaurantFromDb = RestaurantRepo.GetById(Id);
            var Restaurant = new RestaurantEditViewModel()
            {
                RestaurantID= RestaurantFromDb.RestaurantID,
                RestaurantName = RestaurantFromDb.RestaurantName,
                Location = RestaurantFromDb.Location,
                Rating = RestaurantFromDb.Rating,
                CuisineType= RestaurantFromDb.CuisineType
            };
            return View(Restaurant);
        }

        [HttpPost]
        [Route("/Restaurant/Edit/{id}")]
        public IActionResult Update(int id, RestaurantEditViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing Resort from the database
                    var existingResort = RestaurantRepo.GetById(id);

                    if (existingResort != null)
                    {
                        
                        existingResort.RestaurantName= HVCM.RestaurantName;
                        existingResort.Location = HVCM.Location;
                        existingResort.Rating = HVCM.Rating;
                        // Save changes to the database
                        RestaurantRepo.Update(existingResort);

                        TempData["State"] = true;
                        TempData["StateMsg"] = "Data Updated Successfully";
                    }
                    else
                    {
                        TempData["State"] = false;
                        TempData["StateMsg"] = "Restaurant not found";
                    }
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Error occurred: " + ex.Message;
                }
            }

            return Redirect("/Admin/Restaurants");
        }

    
        [HttpGet]
        [Route("/Restaurant/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Resort = await RestaurantRepo.GetByIdAsync(id);
                if (Resort != null)
                {
                    
                    // Delete the Resort record
                    RestaurantRepo.Delete(Resort);

                    TempData["State"] = true;
                    TempData["StateMsg"] = "Resort   deleted successfully";
                }
                else
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Resort not found";
                }
            }
            catch (Exception ex)
            {
                TempData["State"] = false;
                TempData["StateMsg"] = "An error occurred: " + ex.Message;
            }
            return Redirect("/Admin/Restaurants");
        }








    }
}

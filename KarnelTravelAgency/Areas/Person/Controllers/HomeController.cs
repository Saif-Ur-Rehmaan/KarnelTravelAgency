using KarnelTravelAgency.Areas.Person.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KarnelTravelAgency.Areas.Person.Controllers
{
    [Area("Person")]
   
    public class HomeController(ApplicationDbContext context) : Controller
    {
        private UserRepository userRepository = new(context);

      
        
        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        } 
        [Route("/Login")]
        public IActionResult LoginUser()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [Route("/Login")]
        public  IActionResult  LoginUser(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.GetAll()
                    .Where(x => x.UserName == loginViewModel.Username && x.Password == loginViewModel.Password)
                    .FirstOrDefault(); // Use FirstOrDefault to get the first user matching the criteria, or null if none

                if (user != null)
                {
                    // Store user information in session
                    HttpContext.Session.SetInt32("UserId", user.UserID); // Assuming user has an Id property
                    HttpContext.Session.SetString("Username", user.UserName);
                    HttpContext.Session.SetInt32("IsLoggedIn", 1);

                    // Redirect to a secured page or perform any other actions for successful login
                    return Redirect("/"); // Redirect to the home page, for example
                }
                else
                {
                    // Handle invalid login
                    ViewBag.Loginstate = "Invalid username or password.";
                    return View(loginViewModel);
                }
            }

            return View(loginViewModel);

        }




        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}

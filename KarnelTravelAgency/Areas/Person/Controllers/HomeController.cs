using KarnelTravelAgency.Areas.Person.Models;
using KarnelTravelAgency.Components;
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
        private ContactRepo ContactRepo = new(context);
        

        [Route("/Register")]
        public IActionResult Register()
        {
            int? userIdNullable = HttpContext.Session.GetInt32("UserId");
            int userId = userIdNullable.HasValue ? userIdNullable.Value : default(int); // Assigns default value (0) if userIdNullable is null
            if (userId != 0)
            {
                TempData["AlreadyLoggedIn"] = "Already Registered";
                return Redirect("/");
            }

            return View();
        }
        [HttpPost] 
        [Route("/Register")]
        public IActionResult Register(RegisterViewModel RVM)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = userRepository.GetAll()
                   .Where(x => x.UserName == RVM.Username)
                   .FirstOrDefault();
                if (userFromDb == null)
                {
                    var encPass = PasswordHelper.HashPassword(RVM.Password);
                   User user = new()
                    {
                        UserName = RVM.Username,
                        Password =  encPass,
                        RoleID = 2
                    };
                    try
                    {
                        userRepository.Add(user);
                        ViewBag.IsAdded = "Registerd SuccessFully";
                    }
                    catch (Exception)
                    {
                        ViewBag.Error = "An Error Occur While Registring";

                    }

                }
                else
                {
                    ViewBag.Error = "UserName Already Exist";
                    return View(RVM);
                }

                return View();
            }

            return View();
        } 
        
        
        [Route("/Login")]
        public IActionResult LoginUser()
        {
            int? userIdNullable = HttpContext.Session.GetInt32("UserId");
            int userId = userIdNullable.HasValue ? userIdNullable.Value : default(int); // Assigns default value (0) if userIdNullable is null
            if (userId != 0)
            {
                TempData["AlreadyLoggedIn"] = "Already Logged in";
                return Redirect("/");
            }

            return View(new LoginViewModel());
        }
        [HttpPost]
        [Route("/Login")]
        public IActionResult LoginUser(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve user from the database based on the username
                var user = userRepository.GetAll()
                    .FirstOrDefault(x => x.UserName == loginViewModel.Username);

                if (user != null)
                {
                    // Verify the password using bcrypt
                    if (PasswordHelper.VerifyPassword(loginViewModel.Password, user.Password))
                    {
                        // Store user information in session
                        HttpContext.Session.SetInt32("UserId", user.UserID); // Assuming user has an Id property
                        HttpContext.Session.SetString("Username", user.UserName);
                        HttpContext.Session.SetInt32("IsLoggedIn", 1);

                        // Redirect to a HomePage
                        return Redirect("/"); // Redirect to the home page, for example
                    }
                }

                // Handle invalid login
                ViewBag.Loginstate = "Invalid username or password.";
                return View(loginViewModel);
            }

            return View(loginViewModel);
        }

        [Route("/logout")]
        public IActionResult LogoutUser()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }


        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [Route("/Contact")]
        public IActionResult Contact(ContactViewModel CVM)
        {
            //validating  form
            if (ModelState.IsValid)
            {
                //try to add msg in db in contact table
                try
                {
                    var message = new Contact()
                    {
                        UserName = CVM.UserName,
                        Email = CVM.Email,
                        phoneNumber = CVM.phoneNumber,
                        topic = CVM.topic,
                        MessageOnTopic = CVM.MessageOnTopic
                    };
                    ContactRepo.Add(message);//addng data in db
                    ViewBag.Success = "Message successFullly Send";
                    return View();

                }
                catch (Exception e)
                {
                    ViewBag.Error = "An Error Ovvur While Adding Data "+e.Message.ToString();
                    return View();
                }

            }

            return View();
        }
    }



}

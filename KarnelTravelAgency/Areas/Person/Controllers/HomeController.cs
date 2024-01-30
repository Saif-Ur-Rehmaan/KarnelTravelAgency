using KarnelTravelAgency.Areas.Person.Models;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Person.Controllers
{
    [Area("Person")]
    public class HomeController : Controller
    {
        UserRepository userRepository;
      
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
        public IActionResult LoginUser(LoginViewModel lgm)
        {
            var a=userRepository.GetAll().Where(x => x.UserName == lgm.Username).FirstOrDefault();

            return Content($"{lgm.Username},{Request.Form["Username"]},{a}");
        }
 



        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}

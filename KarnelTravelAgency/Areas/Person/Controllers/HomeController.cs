using KarnelTravelAgency.Areas.Person.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Person.Controllers
{
    [Area("Person")]
    public class HomeController : Controller
    {
      
        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        } 
        [Route("/Login")]
        public IActionResult LoginUser()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
 



        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}

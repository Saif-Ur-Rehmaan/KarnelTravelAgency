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
            return View();
        }
        
    
        [Route("/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Person.Controllers
{
    [Area("Person")]
    public class HomeController : Controller
    {
        [Route("/personIndex")]
        public IActionResult Index()
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

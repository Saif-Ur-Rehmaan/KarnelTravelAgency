using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Person.Controllers
{
    [Area("Person")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/ContactUs")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}

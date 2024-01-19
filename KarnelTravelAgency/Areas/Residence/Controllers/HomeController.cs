using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Residence.Controllers
{
    [Area("Residence")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DestinationDetails()
        {
            return View();
        }
        public IActionResult Destination()
        {
            return View();
        }
    }
}

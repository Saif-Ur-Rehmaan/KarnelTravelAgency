using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Residence.Controllers
{
    [Area("Residence")]
    public class HomeController : Controller
    {
        [Route("/Residence")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Residence/Destinations")]
        public IActionResult Destination()
        {
            return View();
        }
        [Route("/Residence/Destination/Details")]
        public IActionResult DestinationDetails()
        {
            return View();
        }
    }
}

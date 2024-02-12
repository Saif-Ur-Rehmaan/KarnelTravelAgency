using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Controllers
{
    public class DestinationController : Controller
    {
        [Route("/Destinations")]
        public IActionResult Destination()
        {
            return View();
        }
        [Route("/Destination/Details")]
        public IActionResult DestinationDetails()
        {
            return View();
        }
    }
}

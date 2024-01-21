using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Transport.Controllers
{
    [Area("Transport")]
    public class HomeController : Controller
    {
        [Route("/Transportation")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Transportation/Tour/Details")]
        public IActionResult TourDetails()
        {
            return View();
        }
        [Route("/Transportation/Tour")]
        public IActionResult Tour()
        {
            return View();
        }
    }
}

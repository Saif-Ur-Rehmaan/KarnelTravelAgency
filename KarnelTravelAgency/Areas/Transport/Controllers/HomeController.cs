using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Transport.Controllers
{
    [Area("Transport")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TourDetails()
        {
            return View();
        }
        public IActionResult Tour()
        {
            return View();
        }
    }
}

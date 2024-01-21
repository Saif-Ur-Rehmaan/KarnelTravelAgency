using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class HomeController : Controller
    {
        [Route("/Restaurants")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

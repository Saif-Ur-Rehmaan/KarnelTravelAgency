using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Controllers
{
    public class TourController : Controller
    {
        [Route("/Tour")]
        public IActionResult Tour()
        {
            return View();
        }

        [Route("/Tour/Details")]
        public IActionResult TourDetails()
        {
            return View();
        }
    }
}

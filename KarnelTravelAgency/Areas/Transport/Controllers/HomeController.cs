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

    
      
    }
}

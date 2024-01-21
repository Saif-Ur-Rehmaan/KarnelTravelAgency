using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Residence.Controllers
{
    [Area("Residence")]
    public class HomeController : Controller
    {
        
        [Route("/Hotels")]
        public IActionResult Hotels()
        {
            return View();
        }
        [Route("/Resorts")]
        public IActionResult Resorts()
        {
            return View();
        }
   
    }
}

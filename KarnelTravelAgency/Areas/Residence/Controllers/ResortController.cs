using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Residence.Controllers
{
     [Area("Residence")]
    public class ResortController : Controller
    {
        [Route("/Resorts")]
        public IActionResult Resorts()
        {
            return View();
        }
    }
}

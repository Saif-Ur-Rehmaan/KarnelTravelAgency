using KarnelTravelAgency.Areas.Admin.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResortController(ApplicationDbContext context) : Controller
    {
        ResortRepository ResortRepo = new(context);
        [Route("Admin/ResortList")]
        public IActionResult ResortList()
        {
            var allResorts = ResortRepo.GetAll().ToList();
            var Resorts = new List<ResortViewModel>();
            foreach (var Resort in allResorts)
            {
                Resorts.Add(new ResortViewModel()
                {
                    ResortID = Resort.ResortID,
                    ResortName = Resort.ResortName,
                    Location = Resort.Location,
                    Rating = Resort.Rating,
                    ResortImg = Resort.ResortImg
                });
            }
            return View(Resorts);
        }

    }
}

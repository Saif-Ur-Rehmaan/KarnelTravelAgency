using KarnelTravelAgency.Areas.Admin.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AirlineController(ApplicationDbContext context) : Controller
    {
        AirlineRepository AirlineRepo = new(context);

        [Route("/Admin/Airlines")]
        public ActionResult AirLineList()
        {
             
            var allAirlines = AirlineRepo.GetAll().ToList();
            var Airlines = new List<AirLineViewModel>();
            foreach (var Airline   in allAirlines)
            {
                Airlines.Add(new AirLineViewModel()
                {
                    AirlineID=Airline.AirlineID,
                    AirlineName =Airline.AirlineName ,
                    IATACode=Airline.IATACode ,
                    ICAOCode=Airline.ICAOCode 

                });
            }
            return View(Airlines);
        }

        [HttpGet]
        [Route("/Airline/Create")]
        public IActionResult Create()
        {
            return View(new AirlineCreateViewModel());
        }
        [HttpPost]
        [Route("/Airline/Create")]
        public IActionResult Create(AirlineCreateViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    Core.Airline Airline = new()
                    { 
                        AirlineName =HVCM.AirlineName ,
                        IATACode=HVCM.IATACode ,
                        ICAOCode=HVCM.ICAOCode  

                    };
                    AirlineRepo.Add(Airline);
                    TempData["State"] = true;
                    TempData["StateMsg"] = "Data Added Successfully";
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "error occur " + ex.Message;

                }

            }
            return Redirect("/Admin/Airlines");

        }

        [HttpGet]
        [Route("/Airline/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var HVCM = AirlineRepo.GetById(Id);
            var Airline = new AirlineEditViewModel()
            {
                AirlineID = HVCM.AirlineID,
                AirlineName = HVCM.AirlineName,
                IATACode = HVCM.IATACode,
                ICAOCode = HVCM.ICAOCode
            };
            return View(Airline);
        }

        [HttpPost]
        [Route("/Airline/Edit/{id}")]
        public IActionResult Update(int id, AirlineEditViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing Airline from the database
                    var existingAirline = AirlineRepo.GetById(id);

                    if (existingAirline != null)
                    {
                        existingAirline.AirlineID = HVCM.AirlineID;
                        existingAirline.AirlineName = HVCM.AirlineName;
                        existingAirline.IATACode = HVCM.IATACode;
                        existingAirline.ICAOCode = HVCM.ICAOCode;
                         
                        // Save changes to the database
                        AirlineRepo.Update(existingAirline);

                        TempData["State"] = true;
                        TempData["StateMsg"] = "Data Updated Successfully";
                    }
                    else
                    {
                        TempData["State"] = false;
                        TempData["StateMsg"] = "Airline not found";
                    }
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Error occurred: " + ex.Message;
                }
            }

            return Redirect("/Admin/Airlines");
        }


        [HttpGet]
        [Route("/Airline/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Airline = await AirlineRepo.GetByIdAsync(id);
                if (Airline != null)
                {

                    // Delete the Airline record
                    AirlineRepo.Delete(Airline);

                    TempData["State"] = true;
                    TempData["StateMsg"] = "Airline   deleted successfully";
                }
                else
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Airline not found";
                }
            }
            catch (Exception ex)
            {
                TempData["State"] = false;
                TempData["StateMsg"] = "An error occurred: " + ex.Message;
            }
            return Redirect("/Admin/Airlines");
        }








    
}
}

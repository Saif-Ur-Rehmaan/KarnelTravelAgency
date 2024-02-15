using KarnelTravelAgency.Areas.Admin.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResortController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment) : Controller
    {
        ResortRepository ResortRepo = new(context);
        

        [Route("/Admin/ResortList")]
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






        [HttpGet]
        [Route("/Resort/Create")]
        public IActionResult Create()
        {
            return View(new ResortCreateViewModel());
        }
        [HttpPost]
        [Route("/Resort/Create")]
        public IActionResult Create(ResortCreateViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (HVCM.ImageFile != null && HVCM.ImageFile.Length > 0)
                    {
                        // Define the folder where you want to save the image
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img", "Resort");

                        // Generate a unique file name to avoid overwriting existing files
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + HVCM.ImageFile.FileName;

                        // Combine the folder path with the unique file name
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Copy the uploaded file to the specified path
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            HVCM.ImageFile.CopyTo(fileStream);
                        }

                        // Save the image path in the database
                        HVCM.ResortImg = "img/Resort/" + uniqueFileName;
                    }

                    Resort Resort = new()
                    {
                        ResortName = HVCM.ResortName,
                        Location = HVCM.Location,
                        Rating = HVCM.Rating,
                        ResortImg = HVCM.ResortImg// Save the image path in the database
                    };
                    ResortRepo.Add(Resort);
                    TempData["State"] = true;
                    TempData["StateMsg"] = "Data Added Successfully";
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "error occur " + ex.Message;

                }

            }
            return Redirect("/Admin/ResortList");

        }

        [HttpGet]
        [Route("/Resort/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var ResortFromDb = ResortRepo.GetById(Id);
            var Resort = new ResortEditViewModel()
            {
                ResortID = ResortFromDb.ResortID,
                ResortName= ResortFromDb.ResortName,
                Location = ResortFromDb.Location,
                Rating = ResortFromDb.Rating,
                ResortImg = ResortFromDb.ResortImg
            };
            return View(Resort);
        }

        [HttpPost]
        [Route("/Resort/Edit/{id}")]
        public IActionResult Update(int id, ResortEditViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing Resort from the database
                    var existingResort = ResortRepo.GetById(id);

                    if (existingResort != null)
                    {
                        // Delete the existing image file if a new image is uploaded
                        if (HVCM.ImageFile != null && HVCM.ImageFile.Length > 0)
                        {
                            DeleteImage(existingResort.ResortImg);

                            // Process the uploaded image file
                            string ResortImgPath = ProcessResortImage(HVCM.ImageFile);

                            // Update the Resort image path only when a new image is uploaded
                            existingResort.ResortImg = ResortImgPath;
                        }

                        // Update other Resort details
                        existingResort.ResortName= HVCM.ResortName;
                        existingResort.Location = HVCM.Location;
                        existingResort.Rating = HVCM.Rating;
                        // Save changes to the database
                        ResortRepo.Update(existingResort);

                        TempData["State"] = true;
                        TempData["StateMsg"] = "Data Updated Successfully";
                    }
                    else
                    {
                        TempData["State"] = false;
                        TempData["StateMsg"] = "Resort not found";
                    }
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Error occurred: " + ex.Message;
                }
            }

            return Redirect("/Admin/ResortList");
        }

        // Method to delete Resort image file
        private void DeleteImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                string filePath = Path.Combine(webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }

        // Method to process and save uploaded Resort image file
        private string ProcessResortImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Define the folder where you want to save the image
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img", "Resort");

                // Generate a unique file name to avoid overwriting existing files
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                // Combine the folder path with the unique file name
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Copy the uploaded file to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

                // Return the image path
                return "img/Resort/" + uniqueFileName;
            }

            return null; // If no image is uploaded
        }

        [HttpGet]
        [Route("/Resort/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Resort = await ResortRepo.GetByIdAsync(id);
                if (Resort != null)
                {
                    var Resortimg = Resort.ResortImg;

                    // Extracting the file name from the image path
                    var fileName = Path.GetFileName(Resortimg);

                    // Constructing the directory path
                    var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, "img", "Resort");

                    // Ensure that the directory exists, if not, create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Constructing the full file path
                    var filePath = Path.Combine(directoryPath, fileName);

                    // Check if the file exists and delete it
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    // Delete the Resort record
                    ResortRepo.Delete(Resort);

                    TempData["State"] = true;
                    TempData["StateMsg"] = "Resort and associated image deleted successfully";
                }
                else
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Resort not found";
                }
            }
            catch (Exception ex)
            {
                TempData["State"] = false;
                TempData["StateMsg"] = "An error occurred: " + ex.Message;
            }
            return Redirect("/Admin/ResortList");
        }






    }
}

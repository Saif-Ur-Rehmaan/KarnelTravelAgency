 
using KarnelTravelAgency.Areas.Admin.Models ;

using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : Controller
    {
       private HotelRepository HotelRepo = new(context);
        
        [HttpGet]
        [Route("/Panel")]
        [Route("/Admin/HotelList")]
        public IActionResult HotelList()
        {
            var allhotels = HotelRepo.GetAll().ToList();
            var Hotels = new List<HotelViewModel>();
            foreach (var hotel in allhotels)
            {
                Hotels.Add(new HotelViewModel()
                {
                    HotelID = hotel.HotelID,
                    HotelName = hotel.HotelName,
                    HotelImg = hotel.HotelImg,
                    Location = hotel.Location,
                    Rating = hotel.Rating
                });
            }
            return View(Hotels);
        }

        [HttpGet]
        [Route("/Hotel/Create")]
        public IActionResult Create()
        {
            return View(new HotelCreateViewModel());
        }
        [HttpPost]
        [Route("/Hotel/Create")]
        public IActionResult Create(HotelCreateViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                        try
                        {
                            if (HVCM.ImageFile != null && HVCM.ImageFile.Length > 0)
                            {
                                // Define the folder where you want to save the image
                                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img", "hotel");

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
                                HVCM.HotelImg = "img/hotel/" + uniqueFileName;
                            }

                            Hotel hotel = new()
                            {
                                HotelName = HVCM.HotelName,
                                Location = HVCM.Location,
                                Rating = HVCM.Rating,
                                HotelImg = HVCM.HotelImg // Save the image path in the database
                            };
                            HotelRepo.Add(hotel);
                            TempData["State"] = true;
                            TempData["StateMsg"] = "Data Added Successfully";
                        }
                        catch (Exception ex)
                        {
                            TempData["State"] = false;
                            TempData["StateMsg"] = "error occur "+ex.Message;
 
                        }
              
            }
            return Redirect("/Admin/HotelList");
      
        }

        [HttpGet]
        [Route("/Hotel/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var HotelFromDb = HotelRepo.GetById(Id);
            var hotel = new HotelEditViewModel()
            {
                HotelID = HotelFromDb.HotelID,
                HotelName= HotelFromDb.HotelName,
                Location= HotelFromDb.Location,
                Rating= HotelFromDb.Rating,
                HotelImg= HotelFromDb.HotelImg
            };
            return View(hotel);
        }

        [HttpPost]
        [Route("/Hotel/Edit/{id}")]
        public IActionResult Update(int id, HotelEditViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing hotel from the database
                    var existingHotel = HotelRepo.GetById(id);

                    if (existingHotel != null)
                    { 
                        // Delete the existing image file if a new image is uploaded
                        if (HVCM.ImageFile != null && HVCM.ImageFile.Length > 0)
                        {
                            DeleteHotelImage(existingHotel.HotelImg);

                            // Process the uploaded image file
                            string hotelImgPath = ProcessHotelImage(HVCM.ImageFile);

                            // Update the hotel image path only when a new image is uploaded
                            existingHotel.HotelImg = hotelImgPath;
                        }

                        // Update other hotel details
                        existingHotel.HotelName = HVCM.HotelName;
                        existingHotel.Location = HVCM.Location;
                        existingHotel.Rating = HVCM.Rating;
                        // Save changes to the database
                        HotelRepo.Update(existingHotel);

                        TempData["State"] = true;
                        TempData["StateMsg"] = "Data Updated Successfully";
                    }
                    else
                    {
                        TempData["State"] = false;
                        TempData["StateMsg"] = "Hotel not found";
                    }
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Error occurred: " + ex.Message;
                }
            }

            return Redirect("/Admin/HotelList");
        }

        // Method to delete hotel image file
        private void DeleteHotelImage(string imagePath)
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

        // Method to process and save uploaded hotel image file
        private string ProcessHotelImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Define the folder where you want to save the image
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img", "hotel");

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
                return "img/hotel/" + uniqueFileName;
            }

            return null; // If no image is uploaded
        }















        [HttpGet]
        [Route("/Hotel/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var hotel = await HotelRepo.GetByIdAsync(id);
                if (hotel != null)
                {
                    var hotelimg = hotel.HotelImg;

                    // Extracting the file name from the image path
                    var fileName = Path.GetFileName(hotelimg);

                    // Constructing the directory path
                    var directoryPath = Path.Combine(webHostEnvironment.WebRootPath, "img", "hotel");

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

                    // Delete the hotel record
                    HotelRepo.Delete(hotel);

                    TempData["State"] = true;
                    TempData["StateMsg"] = "Hotel and associated image deleted successfully";
                }
                else
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Hotel not found";
                }
            }
            catch (Exception ex)
            {
                TempData["State"] = false;
                TempData["StateMsg"] = "An error occurred: " + ex.Message;
            }
            return Redirect("/Admin/HotelList");
        }




    }
}

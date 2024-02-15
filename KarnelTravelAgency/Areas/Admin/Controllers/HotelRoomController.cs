using KarnelTravelAgency.Areas.Admin.Models;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HotelRoomController(ApplicationDbContext context) : Controller
    {
        RoomRepository HotelRoomRepo = new(context);
        HotelRepository HotelRepo = new(context);
        [Route("/Admin/HotelRooms")]
        public IActionResult RoomList()
        {
            
            var AllHotelRooms = HotelRoomRepo.GetAll().ToList(); 
            List<HotelRoomViewModel> HotelRoomList = new();
            foreach (var HotelRoom in AllHotelRooms)
            {
                HotelRoomList.Add(new HotelRoomViewModel()
                {
                    RoomID = HotelRoom.RoomID,
                    HotelID = HotelRoom.HotelID,
                    RoomNumber = HotelRoom.RoomNumber,
                    RoomType = HotelRoom.RoomType,
                    Capacity = HotelRoom.Capacity,
                    Price = HotelRoom.Price,
                    Hotel = HotelRoom.Hotel
                });
            }


            return View(HotelRoomList);
        }





        [HttpGet]
        [Route("/HotelRoom/Create")]
        public IActionResult Create()
        {
            return View(new HotelRoomCreateViewModel()
            {
                HotelList = HotelRepo.GetAll().ToList()
            });
        }
        [HttpPost]
        [Route("/HotelRoom/Create")]
        public IActionResult Create(HotelRoomCreateViewModel HotelRoom)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    Core.Room Room = new()
                    {

                        HotelID = HotelRoom.HotelID,
                        RoomNumber = HotelRoom.RoomNumber,
                        RoomType = HotelRoom.RoomType,
                        Capacity = HotelRoom.Capacity,
                        Price = HotelRoom.Price,
                        Hotel = HotelRepo.GetById(HotelRoom.HotelID)
                    };
                    HotelRoomRepo.Add(Room);
                    TempData["State"] = true;
                    TempData["StateMsg"] = "Data Added Successfully";
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "error occur " + ex.Message;

                }

            }
            return Redirect("/Admin/HotelRooms");

        }

        [HttpGet]
        [Route("/HotelRoom/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var HotelRoomFromDb = HotelRoomRepo.GetById(Id);
            var HotelRoom = new HotelRoomEditViewModel()
            {
                RoomID = HotelRoomFromDb.RoomID,
                HotelID = HotelRoomFromDb.HotelID,
                RoomNumber = HotelRoomFromDb.RoomNumber,
                RoomType = HotelRoomFromDb.RoomType,
                Capacity = HotelRoomFromDb.Capacity,
                Price = HotelRoomFromDb.Price,
                Hotel = HotelRoomFromDb.Hotel,
                HotelList = HotelRepo.GetAll().ToList()
            };
            return View(HotelRoom);
        }

        [HttpPost]
        [Route("/HotelRoom/Edit/{id}")]
        public IActionResult Update(int id, HotelRoomEditViewModel HVCM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the existing HotelRoom from the database
                    var existingHotelRoom = HotelRoomRepo.GetById(id);

                    if (existingHotelRoom != null)
                    {
                         
                        existingHotelRoom.HotelID =HVCM.HotelID ;
                        existingHotelRoom.RoomNumber=HVCM.RoomNumber;
                        existingHotelRoom.RoomType=HVCM.RoomType;
                        existingHotelRoom.Capacity=HVCM.Capacity;
                        existingHotelRoom.Price =HVCM.Price ;
                        existingHotelRoom.Hotel = HotelRepo.GetById(HVCM.HotelID) ;
                        // Save changes to the database
                        HotelRoomRepo.Update(existingHotelRoom);

                        TempData["State"] = true;
                        TempData["StateMsg"] = "Data Updated Successfully";
                    }
                    else
                    {
                        TempData["State"] = false;
                        TempData["StateMsg"] = "HotelRoom not found";
                    }
                }
                catch (Exception ex)
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "Error occurred: " + ex.Message;
                }
            }

            return Redirect("/Admin/HotelRooms");
        }


        [HttpGet]
        [Route("/HotelRoom/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var HotelRoom = await HotelRoomRepo.GetByIdAsync(id);
                if (HotelRoom != null)
                {

                    // Delete the HotelRoom record
                    HotelRoomRepo.Delete(HotelRoom);

                    TempData["State"] = true;
                    TempData["StateMsg"] = "HotelRoom   deleted successfully";
                }
                else
                {
                    TempData["State"] = false;
                    TempData["StateMsg"] = "HotelRoom not found";
                }
            }
            catch (Exception ex)
            {
                TempData["State"] = false;
                TempData["StateMsg"] = "An error occurred: " + ex.Message;
            }
            return Redirect("/Admin/HotelRooms");
        }






































    }






}

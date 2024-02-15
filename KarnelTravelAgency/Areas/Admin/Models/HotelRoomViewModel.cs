using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Admin.Models
{
    public class HotelRoomViewModel
    {

        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public Hotel Hotel { get; set; } 
    }
}

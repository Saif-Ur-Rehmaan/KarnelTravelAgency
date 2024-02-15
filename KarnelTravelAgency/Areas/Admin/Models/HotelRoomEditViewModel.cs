using System.ComponentModel.DataAnnotations;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Admin.Models
{
    public class HotelRoomEditViewModel
    {
        public int? RoomID { get; set; }
        [Required]
        public int HotelID { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public decimal Price { get; set; } 
        public Hotel? Hotel { get; set; }
        public List<Hotel>? HotelList { get; set; }
    }
}

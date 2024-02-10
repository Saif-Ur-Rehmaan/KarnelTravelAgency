using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Residence.Models
{
    public class SingleHotelViewModel
    {
        
        public int hotelId { get; set; }
        
        public string HotelName { get; set; }
        public string HotelImg { get; set; }
        public decimal HotelRating { get; set; }
        
        public string HotelLocation { get; set; }
        public string HotelDescription { get; set; }
        public  List<Room> HotelRooms { get; set; }
      

    }
}

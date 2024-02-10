using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Residence.Models
{
    public class Bundle_SingleHotelViewModel
    {
        public SingleHotelViewModel Hotel { get; set; }
        public   List<Room> RoomsOfHotels { get; set; }
        public   BookRoomVewModel BookedRoom { get; set; }
         

    }
}

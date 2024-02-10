using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Residence.Models
{
    public class Bundle_SinglelResortViewModel
    {
        public SingleResortViewModel resort { get; set; }
        public List<ResortRoom> RoomsOfHotels { get; set; }
        public BookResortRoomVewModel BookedResortRoom { get; set; }
    }
}

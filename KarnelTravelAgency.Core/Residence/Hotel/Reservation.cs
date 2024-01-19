using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public int GuestID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
    }
}

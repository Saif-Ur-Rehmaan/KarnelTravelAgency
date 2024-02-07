using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class ResortReservation
    {
        [Key]
        public int ReservationID { get; set; }
        public int ResortID { get; set; }
        public int RoomID { get; set; }
        public int GuestID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Resort Resort { get; set; }
        public ResortRoom Room { get; set; }
        public ResortGuest Guest { get; set; }
    }
}

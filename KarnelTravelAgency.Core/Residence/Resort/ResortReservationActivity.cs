using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class ResortReservationActivity
    {
        public int ReservationActivityID { get; set; }
        public int ReservationID { get; set; }
        public int ActivityID { get; set; }
        public int Quantity { get; set; }
        public ResortReservation Reservation { get; set; }
        public ResortActivity Activity { get; set; }
    }
}

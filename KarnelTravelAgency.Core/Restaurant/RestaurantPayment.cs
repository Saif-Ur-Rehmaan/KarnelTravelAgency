using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class RestaurantPayment
    {
        public int PaymentID { get; set; }
        public int ReservationID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public RestaurantReservation Reservation { get; set; }
    }
}

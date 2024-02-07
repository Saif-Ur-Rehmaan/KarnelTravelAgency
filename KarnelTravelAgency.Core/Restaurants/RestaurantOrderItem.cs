using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class RestaurantOrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        public int ReservationID { get; set; }
        public int MenuItemID { get; set; }
        public int Quantity { get; set; }
        public RestaurantReservation Reservation { get; set; }
        public RestaurantMenuItem MenuItem { get; set; }
    }

}

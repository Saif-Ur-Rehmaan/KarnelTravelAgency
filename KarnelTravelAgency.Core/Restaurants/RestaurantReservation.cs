using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class RestaurantReservation
    {
        [Key]
        public int ReservationID { get; set; }
        public int RestaurantID { get; set; }
        public int TableID { get; set; }
        public int CustomerID { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public Restaurant Restaurant { get; set; }
        public Table Table { get; set; }
        public RestaurantCustomer Customer { get; set; }
    }
}

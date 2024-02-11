using KarnelTravelAgency.Core;
using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Restaurant.Models
{
    public class RestaurantReservationViewModel
    {
         
        

        [Required]
        public int RestaurantID { get; set; }
        [Required]
        public int TableID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReservationDateTime { get; set; }
        [Required]
        public KarnelTravelAgency.Core.Restaurant Restaurant { get; set; }
        public Table Table { get; set; }

    }
}

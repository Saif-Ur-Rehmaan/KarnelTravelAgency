using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Restaurant.Models
{
    public class Bundle_SingleRestaurantView
    {
        public RestaurantViewModel Restaurant { get; set; }
        public List<RestaurantMenuItem> MenuItemsOfRestaurant { get; set; }
        public List<Table> RestaurantTables { get; set; } 

        public RestaurantReservationViewModel reservation { get; set; }
        public RestaurantCustomerViewModel Customer{ get; set; }
    }
}

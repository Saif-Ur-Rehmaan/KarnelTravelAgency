namespace KarnelTravelAgency.Areas.Admin.Models 
{
    public class RestaurantViewModel
    {

        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
        public string CuisineType { get; set; }
        public decimal Rating { get; set; }

    }
}

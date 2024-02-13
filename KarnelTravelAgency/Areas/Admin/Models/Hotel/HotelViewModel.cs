namespace KarnelTravelAgency.Areas.Admin.Models 
{
    public class HotelViewModel
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; }

        public string HotelImg { get; set; }
        public string Location { get; set; }
        public decimal Rating { get; set; }
    }
}

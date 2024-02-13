using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Admin.Models 
{
    public class RestaurantEditViewModel
    {

        public int RestaurantID { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string CuisineType { get; set; }
        [Required]
        [Range(0, 5)]
        public decimal Rating { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Admin.Models 
{
    public class HotelCreateViewModel
    {
        public int HotelID { get; set; }
        public string? HotelImg { get; set; }

        [Required]
        public string HotelName { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        public IFormFile ImageFile { get; set; } // This property will hold the uploaded image file

        [Required]
        public string Location { get; set; }
        [Required]
        [Range(0,5)]
        public decimal Rating { get; set; }
    }
}

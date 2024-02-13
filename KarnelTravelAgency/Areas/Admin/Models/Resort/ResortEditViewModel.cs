using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Admin.Models
{
    public class ResortEditViewModel
    {
        public int ResortID { get; set; }
        [Required]
        public string ResortName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public decimal Rating { get; set; }
         
        public IFormFile? ImageFile { get; set; } // This property will hold the uploaded image file

        public string? ResortImg { get; set; }
    }
}

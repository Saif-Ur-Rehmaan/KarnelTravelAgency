using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Admin.Models
{
    public class AirlineEditViewModel
    {
         
        public int AirlineID { get; set; }
        [Required]
        [MaxLength(100)]
        public string? AirlineName { get; set; }
        [Required]
        [MaxLength(3)]
        public string? IATACode { get; set; }
        [MaxLength(4)]
        [Required]
        public string? ICAOCode { get; set; }
    }
}

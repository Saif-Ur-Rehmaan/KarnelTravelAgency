using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace KarnelTravelAgency.Areas.Admin.Models
{
    public class AirlineCreateViewModel
    {
        public int AirlineID { get; set; }
        [Required]
        public string? AirlineName { get; set; }
        [Required]
        [MaxLength(3)]
        public string? IATACode { get; set; }
        [MaxLength(4)]
        [Required]
        public string? ICAOCode { get; set; }
    }
}

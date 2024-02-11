using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Restaurant.Models
{
    public class RestaurantCustomerViewModel
    {
        public int CustomerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}

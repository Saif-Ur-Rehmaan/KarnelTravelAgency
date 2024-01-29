using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Person.Models
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } 

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }  
    }
}

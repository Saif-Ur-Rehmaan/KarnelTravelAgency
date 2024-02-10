using System.ComponentModel.DataAnnotations;
using Azure.Identity;
using Newtonsoft.Json.Serialization;

namespace KarnelTravelAgency.Areas.Person.Models
{
    public class ContactViewModel
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(11,ErrorMessage ="The Phone Number Must Valid")]
        public string phoneNumber { get; set; }
        [Required]
        public string topic { get; set; }

        [Required]
        public string MessageOnTopic { get; set; }

    }
}

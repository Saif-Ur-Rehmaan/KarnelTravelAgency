using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core

{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string topic { get; set; }
        public string MessageOnTopic { get; set; }
    }
}

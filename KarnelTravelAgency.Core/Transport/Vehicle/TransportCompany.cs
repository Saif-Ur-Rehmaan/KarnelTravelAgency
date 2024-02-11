using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class TransportCompany
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
    }
}

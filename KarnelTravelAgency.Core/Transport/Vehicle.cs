using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public int CompanyID { get; set; }
        public string VehicleType { get; set; }
        public string RegistrationPlate { get; set; }
        public int Capacity { get; set; }
        public TransportCompany Company { get; set; }
    }
}

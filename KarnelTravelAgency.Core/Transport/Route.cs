using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public decimal DistanceInKm { get; set; }
    }
}

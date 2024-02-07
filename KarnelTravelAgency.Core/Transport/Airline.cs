using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Airline
    {

        [Key]
        public int AirlineID { get; set; }
        public string AirlineName { get; set; }
        public string IATACode { get; set; }
        public string ICAOCode { get; set; }
    }
}

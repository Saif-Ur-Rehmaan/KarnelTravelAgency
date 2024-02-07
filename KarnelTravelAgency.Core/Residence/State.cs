using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
    }
}

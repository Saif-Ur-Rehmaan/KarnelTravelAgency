using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Resort
    {
        [Key]
        public int ResortID { get; set; }
        public string ResortName { get; set; }
        public string Location { get; set; }
        public decimal Rating { get; set; }
        public string ResortImg { get; set; }
    }

}

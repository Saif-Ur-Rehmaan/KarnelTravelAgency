using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class ResortActivity
    {
        [Key]
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

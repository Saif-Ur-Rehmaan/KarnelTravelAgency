using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class PackageActivity
    {
        [Key]
        public int PackageActivityID { get; set; }
        public int PackageID { get; set; }
        public int ActivityID { get; set; }
        public int Quantity { get; set; }
        public Package Package { get; set; }
        public ResortActivity Activity { get; set; }
    }
}

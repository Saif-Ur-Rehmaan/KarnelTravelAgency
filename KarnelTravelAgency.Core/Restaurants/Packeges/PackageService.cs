using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class PackageService
    {
        [Key]
        public int PackageServiceID { get; set; }
        public int PackageID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public Package Package { get; set; }
        public Service Service { get; set; }
    }
}

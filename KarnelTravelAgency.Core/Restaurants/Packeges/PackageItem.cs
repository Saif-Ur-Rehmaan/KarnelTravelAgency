using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class PackageItem
    {
        [Key]
        public int PackageItemID { get; set; }
        public int PackageID { get; set; }
        public int ItemID { get; set; }
        public string ItemType { get; set; }
        public int Quantity { get; set; }
        public Package Package { get; set; }
    }
}

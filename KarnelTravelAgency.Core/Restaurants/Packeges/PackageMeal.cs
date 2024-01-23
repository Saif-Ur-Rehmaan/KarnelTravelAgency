using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class PackageMeal
    {
        public int PackageMealID { get; set; }
        public int PackageID { get; set; }
        public int MenuItemID { get; set; }
        public int Quantity { get; set; }
        public Package Package { get; set; }
        public RestaurantMenuItem MenuItem { get; set; }
    }
}

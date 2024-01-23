using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class RestaurantMenuItem
    {
        public int MenuItemID { get; set; }
        public int RestaurantID { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

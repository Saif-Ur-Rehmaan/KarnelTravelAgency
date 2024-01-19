using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Table
    {
        public int TableID { get; set; }
        public int RestaurantID { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

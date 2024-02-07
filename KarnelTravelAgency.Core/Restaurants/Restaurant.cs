﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
        public string CuisineType { get; set; }
        public decimal Rating { get; set; }
    }
}

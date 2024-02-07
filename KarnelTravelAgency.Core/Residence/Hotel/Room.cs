using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public Hotel Hotel { get; set; }
    }
}

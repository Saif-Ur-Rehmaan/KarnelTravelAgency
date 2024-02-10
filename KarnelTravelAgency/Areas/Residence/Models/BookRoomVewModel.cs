﻿using System.ComponentModel.DataAnnotations;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Residence.Models
{
    public class BookRoomVewModel
    {
        public int RoomID { get; set; } 
        public string RoomNumber { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CheckInDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CheckOutDate { get; set; }
    }
}

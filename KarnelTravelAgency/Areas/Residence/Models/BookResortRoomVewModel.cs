using System.ComponentModel.DataAnnotations;

namespace KarnelTravelAgency.Areas.Residence.Models
{
    public class BookResortRoomVewModel
    {
        public int ResortRoomID { get; set; }
        public string ResortRoomNumber { get; set; }
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

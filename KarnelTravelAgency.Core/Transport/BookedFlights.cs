using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class BookedFlights
    {
        [Key]
        public int Id { get; set; }
        public int  FlightId { get; set; }
        public int  userId { get; set; }
        public Flight  Flight { get; set; }
        public User  user { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
    public class ReservationService
    {
        [Key]
        public int ReservationServiceID { get; set; }
        public int ReservationID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public Reservation Reservation { get; set; }
        public Service Service { get; set; }
    }
}

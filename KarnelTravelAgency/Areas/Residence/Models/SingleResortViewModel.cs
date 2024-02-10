using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Areas.Residence.Models
{
    public class SingleResortViewModel
    { 

        public int ResortID { get; set; }
        public string ResortName { get; set; }
        public string Location { get; set; }
        public decimal Rating { get; set; }
        public string ResortImg { get; set; }
        public string resortlDescription { get; set; }
        public List<ResortRoom> ResortRooms { get; set; }
    }
}

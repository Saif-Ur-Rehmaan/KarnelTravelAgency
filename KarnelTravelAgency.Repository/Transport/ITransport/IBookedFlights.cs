using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core; 

namespace KarnelTravelAgency.Repository.Interfaces
{
    interface IBookedFlights
    {
        IQueryable<BookedFlights> GetAll();
        Task<BookedFlights> GetByIdAsync(int id);
        void Add(BookedFlights BookedFlights);
        void Update(BookedFlights BookedFlights);
        void Delete(BookedFlights BookedFlights);
    }
}

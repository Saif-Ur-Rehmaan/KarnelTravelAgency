using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IAirlineRepository
    {
        IQueryable<Airline> GetAll();
        Task<Airline> GetByIdAsync(int id);
        void Add(Airline airline);
        void Update(Airline airline);
        void Delete(Airline airline);
    }
}

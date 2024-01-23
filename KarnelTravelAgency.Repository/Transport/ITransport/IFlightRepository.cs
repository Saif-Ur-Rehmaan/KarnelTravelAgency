using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IFlightRepository
    {
        IQueryable<Flight> GetAll();
        Task<Flight> GetByIdAsync(int id);
        void Add(Flight flight);
        void Update(Flight flight);
        void Delete(Flight flight);
    }
}

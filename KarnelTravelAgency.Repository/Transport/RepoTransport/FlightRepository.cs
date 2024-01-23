using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    internal class FlightRepository(ApplicationDbContext _context) : IFlightRepository
    {
        public void Add(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void Delete(Flight flight)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Flight> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Flight> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}

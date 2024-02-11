using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class FlightRepository(ApplicationDbContext _context) : IFlightRepository
    {
        public void Add(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public void Delete(Flight flight)
        {
            _context.Flights.Remove(flight);
            _context.SaveChanges();
            
        }

        public IQueryable<Flight> GetAll()
        {
            return _context.Flights.AsQueryable();
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            return _context.Flights.Find(id);
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
            _context.SaveChanges();
        }
    }
}

using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class AirlineRepository(ApplicationDbContext _context) : IAirlineRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Airline airline)
        {
            context.Airlines.Add(airline);
            context.SaveChanges();
        }

        public void Delete(Airline airline)
        {
            context.Airlines.Remove(airline);
            context.SaveChanges();
        }

        public IQueryable<Airline> GetAll()
        {
            return context.Airlines.AsQueryable();
        }

        public async Task<Airline> GetByIdAsync(int id)
        {
            return await context.Airlines.FindAsync(id);
        }

        public void Update(Airline airline)
        {
            context.Airlines.Update(airline);
            context.SaveChanges();
        }
    }
}

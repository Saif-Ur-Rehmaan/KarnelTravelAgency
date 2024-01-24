using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class TripRepository(ApplicationDbContext _context) : ITripRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Trip trip)
        {
            context.Trips.Add(trip);
            context.SaveChanges();
        }

        public void Delete(Trip trip)
        {
            context.Trips.Remove(trip); 
            context.SaveChanges();
        }

        public IQueryable<Trip> GetAll()
        {
            return context.Trips.AsQueryable();
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
            return await context.Trips.FindAsync(id);
        }

        public void Update(Trip trip)
        {
            context.Trips.Update(trip);
            context.SaveChanges();
        }
    }
}

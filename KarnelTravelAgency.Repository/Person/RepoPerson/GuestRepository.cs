using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class GuestRepository(ApplicationDbContext _context) : IGuestRepository
    {
        private ApplicationDbContext context { get; set; } = _context;

        public void Add(Guest guest)
        {
            context.Guests.Add(guest);
            context.SaveChanges();
        }

        public void Delete(Guest guest)
        {
            context.Guests.Remove(guest);
            context.SaveChanges();
        }

        public IQueryable<Guest> GetAll()
        {
            return context.Guests.AsQueryable();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            return await context.Guests.FindAsync(id);
        }

        public void Update(Guest guest)
        {
            context.Guests.Update(guest);
            context.SaveChanges();
        }
    }
}

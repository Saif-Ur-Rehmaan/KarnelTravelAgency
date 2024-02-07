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

        public void Add(HotelGuest guest)
        {
            context.Guests.Add(guest);
            context.SaveChanges();
        }

        public void Delete(HotelGuest guest)
        {
            context.Guests.Remove(guest);
            context.SaveChanges();
        }

        public IQueryable<HotelGuest> GetAll()
        {
            return context.Guests.AsQueryable();
        }

        public async Task<HotelGuest> GetByIdAsync(int id)
        {
            return await context.Guests.FindAsync(id);
        }

        public void Update(HotelGuest guest)
        {
            context.Guests.Update(guest);
            context.SaveChanges();
        }
    }
}

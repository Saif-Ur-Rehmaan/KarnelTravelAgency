using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ResortGuestRepository(ApplicationDbContext _context) : IResortGuestRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(ResortGuest resortGuest)
        {
            context.ResortGuests.Add(resortGuest);
            context.SaveChanges();
        }

        public void Delete(ResortGuest resortGuest)
        {
            context.ResortGuests.Remove(resortGuest);
            context.SaveChanges();
        }

        public IQueryable<ResortGuest> GetAll()
        {
            return context.ResortGuests.AsQueryable();
        }

        public async Task<ResortGuest> GetByIdAsync(int id)
        {
            return await context.ResortGuests.FindAsync(id);
        }

        public void Update(ResortGuest resortGuest)
        {
            context.ResortGuests.Update(resortGuest);
            context.SaveChanges();
        }
    }
}

using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class HotelRepository(ApplicationDbContext _context) : IHotelRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Hotel hotel)
        {
            context.Hotels.Add(hotel);
            context.SaveChanges();
        }

        public void Delete(Hotel hotel)
        {
            context.Hotels.Remove(hotel);
            context.SaveChanges();
        }

        public IQueryable<Hotel> GetAll()
        {
            return context.Hotels.AsQueryable();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await context.Hotels.FindAsync(id);
        }

        public void Update(Hotel hotel)
        {
            context.Hotels.Update(hotel); 
            context.SaveChanges();    
        }
    }
}

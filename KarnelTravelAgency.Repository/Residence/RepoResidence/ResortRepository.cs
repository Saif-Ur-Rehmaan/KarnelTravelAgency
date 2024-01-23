using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ResortRepository(ApplicationDbContext _context) : IResortRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Resort resort)
        {
            context.Resorts.Add(resort);
            context.SaveChanges();
        }

        public void Delete(Resort resort)
        {
            context.Resorts.Remove(resort); 
            context.SaveChanges();
        }

        public IQueryable<Resort> GetAll()
        {
            return context.Resorts.AsQueryable();
        }

        public async Task<Resort> GetByIdAsync(int id)
        {
            return await context.Resorts.FindAsync(id);
        }

        public void Update(Resort resort)
        {
            context.Resorts.Update(resort); 
            context.SaveChanges();
        }
    }
}

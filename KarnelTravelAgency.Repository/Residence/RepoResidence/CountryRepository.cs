using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class CountryRepository(ApplicationDbContext _context) : ICountryRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();
        }

        public void Delete(Country country)
        {
            context.Countries.Remove(country);
            context.SaveChanges();
        }

        public IQueryable<Country> GetAll()
        {
            return context.Countries.AsQueryable();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await context.Countries.FindAsync(id);
        }

        public void Update(Country country)
        {
            context.Countries.Update(country);
            context.SaveChanges();
        }
    }
}

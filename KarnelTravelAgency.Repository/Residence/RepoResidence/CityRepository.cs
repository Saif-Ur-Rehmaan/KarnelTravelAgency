using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class CityRepository(ApplicationDbContext _context) : ICityRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
        }

        public void Delete(City city)
        {
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public IQueryable<City> GetAll()
        {
            return context.Cities.AsQueryable();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await context.Cities.FindAsync(id);
        }

        public void Update(City city)
        {
            context.Cities.Update(city);
            context.SaveChanges();
        }
    }
}

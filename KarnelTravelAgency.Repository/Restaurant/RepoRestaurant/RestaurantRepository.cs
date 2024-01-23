using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class RestaurantRepository(ApplicationDbContext _context) : KarnelTravelAgency.Repository.Interfaces.IRestaurantRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Core.Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            context.SaveChanges();
        }

        public void Delete(Core.Restaurant restaurant)
        {
            context.Restaurants.Remove(restaurant);
            context.SaveChanges();
        }

        public IQueryable<Core.Restaurant> GetAll()
        {
            return context.Restaurants.AsQueryable();
        }

        public async Task<Core.Restaurant> GetByIdAsync(int id)
        {
            return await context.Restaurants.FindAsync(id);
        }

        public void Update(Core.Restaurant restaurant)
        {
            context.Restaurants.Update(restaurant);
            context.SaveChanges();
        }
    }
}

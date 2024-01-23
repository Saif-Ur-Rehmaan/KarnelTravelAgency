using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class RestaurantMenuItemRepository(ApplicationDbContext _context) : IRestaurantMenuItemRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(RestaurantMenuItem restaurantMenuItem)
        {
            context.RestaurantMenuItems.Add(restaurantMenuItem);
            context.SaveChanges();
        }

        public void Delete(RestaurantMenuItem restaurantMenuItem)
        {
            context.RestaurantMenuItems.Remove(restaurantMenuItem);
            context.SaveChanges();
        }

        public IQueryable<RestaurantMenuItem> GetAll()
        {
            return context.RestaurantMenuItems.AsQueryable();
        }

        public async Task<RestaurantMenuItem> GetByIdAsync(int id)
        {
            return await context.RestaurantMenuItems.FindAsync(id);
        }

        public void Update(RestaurantMenuItem restaurantMenuItem)
        {
            context.RestaurantMenuItems.Update(restaurantMenuItem);
            context.SaveChanges();
        }
    }
}

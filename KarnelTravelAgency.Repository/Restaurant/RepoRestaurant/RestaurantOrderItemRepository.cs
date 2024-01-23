using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class RestaurantOrderItemRepository(ApplicationDbContext _context) : IRestaurantOrderItemRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(RestaurantOrderItem restaurantOrderItem)
        {
            context.RestaurantOrderItems.Add(restaurantOrderItem);
            context.SaveChanges();
        }

        public void Delete(RestaurantOrderItem restaurantOrderItem)
        {
            context.RestaurantOrderItems.Remove(restaurantOrderItem);
            context.SaveChanges();
        }

        public IQueryable<RestaurantOrderItem> GetAll()
        {
            return context.RestaurantOrderItems.AsQueryable();
        }

        public async Task<RestaurantOrderItem> GetByIdAsync(int id)
        {
            return await context.RestaurantOrderItems.FindAsync(id);
        }

        public void Update(RestaurantOrderItem restaurantOrderItem)
        {
            context.RestaurantOrderItems.Update(restaurantOrderItem);
            context.SaveChanges();
        }
    }
}

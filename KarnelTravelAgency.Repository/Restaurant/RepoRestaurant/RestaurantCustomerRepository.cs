using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class RestaurantCustomerRepository(ApplicationDbContext _context) : IRestaurantCustomerRepository
    {
        private ApplicationDbContext context { get; set; } = _context;

        public void Add(RestaurantCustomer restaurantCustomer)
        {
            context.RestaurantCustomers.Add(restaurantCustomer);
            context.SaveChanges();
        }

        public void Delete(RestaurantCustomer restaurantCustomer)
        {
            context.RestaurantCustomers.Remove(restaurantCustomer);
            context.SaveChanges();
        }

        public IQueryable<RestaurantCustomer> GetAll()
        {
            return context.RestaurantCustomers.AsQueryable();
        }

        public async Task<RestaurantCustomer> GetByIdAsync(int id)
        {
            return await context.RestaurantCustomers.FindAsync(id);
        }

        public void Update(RestaurantCustomer restaurantCustomer)
        {
            context.RestaurantCustomers.Update(restaurantCustomer);
            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class RestaurantPaymentRepository(ApplicationDbContext _context) : IRestaurantPaymentRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(RestaurantPayment restaurantPayment)
        {
            context.RestaurantPayments.Add(restaurantPayment);
            context.SaveChanges();
        }

        public void Delete(RestaurantPayment restaurantPayment)
        {
            context.RestaurantPayments.Remove(restaurantPayment);
            context.SaveChanges();
        }

        public IQueryable<RestaurantPayment> GetAll()
        {
            return context.RestaurantPayments.AsQueryable();
        }

        public async Task<RestaurantPayment> GetByIdAsync(int id)
        {
            return await context.RestaurantPayments.FindAsync(id);
        }

        public void Update(RestaurantPayment restaurantPayment)
        {
            context.RestaurantPayments.Update(restaurantPayment);
            context.SaveChanges();
        }
    }
}

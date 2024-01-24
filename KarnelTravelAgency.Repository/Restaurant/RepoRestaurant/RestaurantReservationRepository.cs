using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Restaurant.RepoRestaurant
{
    public class RestaurantReservationRepository(ApplicationDbContext _context) : IRestaurantReservationRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(RestaurantReservation restaurantReservation)
        {
            context.RestaurantReservations.Add(restaurantReservation);
            context.SaveChanges();
        }

        public void Delete(RestaurantReservation restaurantReservation)
        {
            context.RestaurantReservations.Remove(restaurantReservation);
            context.SaveChanges();
        }

        public IQueryable<RestaurantReservation> GetAll()
        {
            return context.RestaurantReservations.AsQueryable();
        }

        public async Task<RestaurantReservation> GetByIdAsync(int id)
        {
            return await context.RestaurantReservations.FindAsync(id);
        }

        public void Update(RestaurantReservation restaurantReservation)
        {
            context.RestaurantReservations.Update(restaurantReservation);
            context.SaveChanges();
        }
    }
}

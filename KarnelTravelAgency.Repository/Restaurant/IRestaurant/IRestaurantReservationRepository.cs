using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IRestaurantReservationRepository
    {
        IQueryable<RestaurantReservation> GetAll();
        Task<RestaurantReservation> GetByIdAsync(int id);
        void Add(RestaurantReservation restaurantReservation);
        void Update(RestaurantReservation restaurantReservation);
        void Delete(RestaurantReservation restaurantReservation);
    }
}

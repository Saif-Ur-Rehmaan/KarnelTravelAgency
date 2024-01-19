using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IRestaurantPaymentRepository
    {
        IQueryable<RestaurantPayment> GetAll();
        Task<RestaurantPayment> GetByIdAsync(int id);
        void Add(RestaurantPayment restaurantPayment);
        void Update(RestaurantPayment restaurantPayment);
        void Delete(RestaurantPayment restaurantPayment);
    }
}

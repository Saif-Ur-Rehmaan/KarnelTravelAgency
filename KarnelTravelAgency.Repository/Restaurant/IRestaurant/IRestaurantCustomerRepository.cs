using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IRestaurantCustomerRepository
    {
        IQueryable<RestaurantCustomer> GetAll();
        Task<RestaurantCustomer> GetByIdAsync(int id);
        void Add(RestaurantCustomer restaurantCustomer);
        void Update(RestaurantCustomer restaurantCustomer);
        void Delete(RestaurantCustomer restaurantCustomer);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IRestaurantOrderItemRepository
    {
        IQueryable<RestaurantOrderItem> GetAll();
        Task<RestaurantOrderItem> GetByIdAsync(int id);
        void Add(RestaurantOrderItem restaurantOrderItem);
        void Update(RestaurantOrderItem restaurantOrderItem);
        void Delete(RestaurantOrderItem restaurantOrderItem);
    }
}

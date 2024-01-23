using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IRestaurantMenuItemRepository
    {
        IQueryable<RestaurantMenuItem> GetAll();
        Task<RestaurantMenuItem> GetByIdAsync(int id);
        void Add(RestaurantMenuItem restaurantMenuItem);
        void Update(RestaurantMenuItem restaurantMenuItem);
        void Delete(RestaurantMenuItem restaurantMenuItem);
    }
}

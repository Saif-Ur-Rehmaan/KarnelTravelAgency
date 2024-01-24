using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IRestaurantRepository
    {
        IQueryable<KarnelTravelAgency.Core.Restaurant> GetAll();
        Task<KarnelTravelAgency.Core.Restaurant> GetByIdAsync(int id);
        void Add(KarnelTravelAgency.Core.Restaurant restaurant);
        void Update(KarnelTravelAgency.Core.Restaurant restaurant);
        void Delete(KarnelTravelAgency.Core.Restaurant restaurant);
    }
}

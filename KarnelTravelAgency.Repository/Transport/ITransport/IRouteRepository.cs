using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{

    public interface IRouteRepository
    {
        IQueryable<Route> GetAll();
        Task<Route> GetByIdAsync(int id);
        void Add(Route route);
        void Update(Route route);
        void Delete(Route route);
    }
}

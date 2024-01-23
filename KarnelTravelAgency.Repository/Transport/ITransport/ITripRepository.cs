using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface ITripRepository
    {
        IQueryable<Trip> GetAll();
        Task<Trip> GetByIdAsync(int id);
        void Add(Trip trip);
        void Update(Trip trip);
        void Delete(Trip trip);
    }
}

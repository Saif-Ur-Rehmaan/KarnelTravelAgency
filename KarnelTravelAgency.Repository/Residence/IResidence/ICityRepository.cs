using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface ICityRepository
    {
        IQueryable<City> GetAll();
        Task<City> GetByIdAsync(int id);
        void Add(City city);
        void Update(City city);
        void Delete(City city);
    }
}

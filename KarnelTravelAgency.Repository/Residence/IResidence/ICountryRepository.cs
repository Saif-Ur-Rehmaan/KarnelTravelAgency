using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface ICountryRepository
    {
        IQueryable<Country> GetAll();
        Task<Country> GetByIdAsync(int id);
        void Add(Country country);
        void Update(Country country);
        void Delete(Country country);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IServiceRepository
    {
        IQueryable<Service> GetAll();
        Task<Service> GetByIdAsync(int id);
        void Add(Service service);
        void Update(Service service);
        void Delete(Service service);
    }
}

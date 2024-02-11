using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IPackageRepository
    {
        IQueryable<Package> GetAll();
        Task<Package> GetByIdAsync(int id);
        void Add(Package package);
        void Update(Package package);
        void Delete(Package package);
    }
}

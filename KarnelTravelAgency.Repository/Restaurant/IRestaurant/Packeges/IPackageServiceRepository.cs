using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IPackageServiceRepository
    {
        IQueryable<PackageService> GetAll();
        Task<PackageService> GetByIdAsync(int id);
        void Add(PackageService packageService);
        void Update(PackageService packageService);
        void Delete(PackageService packageService);
    }
}

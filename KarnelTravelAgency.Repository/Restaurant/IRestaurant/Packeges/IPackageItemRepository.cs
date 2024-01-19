using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IPackageItemRepository
    {
        IQueryable<PackageItem> GetAll();
        Task<PackageItem> GetByIdAsync(int id);
        void Add(PackageItem packageItem);
        void Update(PackageItem packageItem);
        void Delete(PackageItem packageItem);
    }
}

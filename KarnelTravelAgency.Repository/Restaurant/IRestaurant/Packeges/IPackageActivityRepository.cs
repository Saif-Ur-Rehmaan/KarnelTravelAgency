using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IPackageActivityRepository
    {
        IQueryable<PackageActivity> GetAll();
        Task<PackageActivity> GetByIdAsync(int id);
        void Add(PackageActivity packageActivity);
        void Update(PackageActivity packageActivity);
        void Delete(PackageActivity packageActivity);
    }
}

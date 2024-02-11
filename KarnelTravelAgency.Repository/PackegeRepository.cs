using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class PackegeRepository(ApplicationDbContext context) : IPackageRepository
    {
        public void Add(Package package)
        {
            context.Packages.Add(package);
            context.SaveChanges();
        }

        public void Delete(Package package)
        {
            context.Packages.Remove(package);
            context.SaveChanges();
        }

        public IQueryable<Package> GetAll()
        {
            return context.Packages.AsQueryable();
        }

        public async Task<Package> GetByIdAsync(int id)
        {
            return await context.Packages.FindAsync(id);
        }

        public void Update(Package package)
        {
            context.Packages.Update(package);
            context.SaveChanges();
        }
    }
}

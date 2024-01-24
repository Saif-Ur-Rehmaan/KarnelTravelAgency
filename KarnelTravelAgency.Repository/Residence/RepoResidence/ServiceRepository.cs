using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ServiceRepository(ApplicationDbContext _context) : IServiceRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
        }

        public void Delete(Service service)
        {
            context.Services.Remove(service);
            context.SaveChanges();
        }

        public IQueryable<Service> GetAll()
        {
            return context.Services.AsQueryable();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await context.Services.FindAsync(id);
        }

        public void Update(Service service)
        {
            context.Services.Update(service);
            context.SaveChanges();
        }
    }
}

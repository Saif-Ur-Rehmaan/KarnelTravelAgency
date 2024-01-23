using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    internal class RouteRepository(ApplicationDbContext _context) : IRouteRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Route route)
        {
            context.Routes.Add(route);
            context.SaveChanges();
        }

        public void Delete(Route route)
        {
            context.Routes.Remove(route);
            context.SaveChanges();
        }

        public IQueryable<Route> GetAll()
        {
            return context.Routes.AsQueryable();
        }

        public async Task<Route> GetByIdAsync(int id)
        {
            return await context.Routes.FindAsync(id);
        }

        public void Update(Route route)
        {
            context.Routes.Update(route); 
            context.SaveChanges();
        }
    }
}

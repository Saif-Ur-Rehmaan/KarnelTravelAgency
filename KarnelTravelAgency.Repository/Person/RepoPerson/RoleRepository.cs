using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class RoleRepository(ApplicationDbContext _context) : IRoleRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
        }

        public void Delete(Role role)
        {
            context.Roles.Remove(role);
            context.SaveChanges();
        }

        public IQueryable<Role> GetAll()
        {
            return context.Roles.AsQueryable();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await context.Roles.FindAsync(id);
        }

        public void Update(Role role)
        {
            context.Roles.Update(role);
            context.SaveChanges();
        }
    }
}

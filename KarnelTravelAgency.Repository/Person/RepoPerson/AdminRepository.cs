using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo

{
    public class AdminRepository(ApplicationDbContext _context) : IAdminRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
        }

        public void Delete(Admin admin)
        {
            context.Admins.Remove(admin);
            context.SaveChanges();
        }

        public IQueryable<Admin> GetAll()
        {
            return context.Admins.AsQueryable();
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await context.Admins.FindAsync(id);
        }

        public void Update(Admin admin)
        {
            context.Admins.Update(admin);
            context.SaveChanges();
        }
    }
}

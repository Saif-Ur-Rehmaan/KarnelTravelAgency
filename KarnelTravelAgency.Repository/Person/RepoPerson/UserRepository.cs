using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class UserRepository(ApplicationDbContext _context) : IUserRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        
        

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return context.Users.AsQueryable();
        }
     

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}

using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class StateRepository(ApplicationDbContext _context) : IStateRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(State state)
        {
            context.States.Add(state);
            context.SaveChanges();
        }

        public void Delete(State state)
        {
            context.States.Remove(state);
            context.SaveChanges();
        }

        public IQueryable<State> GetAll()
        {
            return context.States.AsQueryable();
        }

        public async Task<State> GetByIdAsync(int id)
        {
            return await context.States.FindAsync(id);
        }

        public void Update(State state)
        {
            context.States.Update(state);
            context.SaveChanges();
        }
    }
}

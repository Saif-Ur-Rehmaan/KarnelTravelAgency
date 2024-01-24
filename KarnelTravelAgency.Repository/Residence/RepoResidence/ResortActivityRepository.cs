using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ResortActivityRepository(ApplicationDbContext _context) : IResortActivityRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(ResortActivity resortActivity)
        {
            context.ResortActivities.Add(resortActivity);
            context.SaveChanges();
        }

        public void Delete(ResortActivity resortActivity)
        {
            context.ResortActivities.Remove(resortActivity);
            context.SaveChanges();
        }

        public IQueryable<ResortActivity> GetAll()
        {
            return context.ResortActivities.AsQueryable();
        }

        public async Task<ResortActivity> GetByIdAsync(int id)
        {
            return await context.ResortActivities.FindAsync(id);
        }

        public void Update(ResortActivity resortActivity)
        {
            context.ResortActivities.Update(resortActivity);
            context.SaveChanges();   
        }
    }
}

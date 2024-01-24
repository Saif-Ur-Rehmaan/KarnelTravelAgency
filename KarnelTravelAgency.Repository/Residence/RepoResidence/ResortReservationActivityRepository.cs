using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ResortReservationActivityRepository(ApplicationDbContext _context) : IResortReservationActivityRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(ResortReservationActivity resortReservationActivity)
        {
            context.ResortReservationActivities.Add(resortReservationActivity);
            context.SaveChanges();
        }

        public void Delete(ResortReservationActivity resortReservationActivity)
        {
            context.ResortReservationActivities.Remove(resortReservationActivity);
            context.SaveChanges();
        }

        public IQueryable<ResortReservationActivity> GetAll()
        {
            return context.ResortReservationActivities.AsQueryable();
        }

        public async Task<ResortReservationActivity> GetByIdAsync(int id)
        {
            return await context.ResortReservationActivities.FindAsync(id);
        }

        public void Update(ResortReservationActivity resortReservationActivity)
        {
            context.ResortReservationActivities.Update(resortReservationActivity);
            context.SaveChanges();
        }
    }
}

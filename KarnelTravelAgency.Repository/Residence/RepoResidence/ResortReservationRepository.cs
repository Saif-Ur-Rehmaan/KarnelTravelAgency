using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ResortReservationRepository(ApplicationDbContext _context) : IResortReservationRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(ResortReservation resortReservation)
        {
            context.ResortReservations.Add(resortReservation);
            context.SaveChanges();
        }

        public void Delete(ResortReservation resortReservation)
        {
            context.ResortReservations.Remove(resortReservation);
            context.SaveChanges();
        }

        public IQueryable<ResortReservation> GetAll()
        {
            return context.ResortReservations.AsQueryable();
        }

        public async Task<ResortReservation> GetByIdAsync(int id)
        {
            return await context.ResortReservations.FindAsync(id);
        }

        public void Update(ResortReservation resortReservation)
        {
            context.ResortReservations.Update(resortReservation);
            context.SaveChanges();
        }
    }
}

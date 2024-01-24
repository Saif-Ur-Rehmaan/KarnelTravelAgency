using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ReservationServiceRepository(ApplicationDbContext _context) : IReservationServiceRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(ReservationService reservationService)
        {
            context.ReservationServices.Add(reservationService);
            context.SaveChanges();
        }

        public void Delete(ReservationService reservationService)
        {
            context.ReservationServices.Remove(reservationService);
            context.SaveChanges();
        }

        public IQueryable<ReservationService> GetAll()
        {
            return context.ReservationServices.AsQueryable();
        }

        public async Task<ReservationService> GetByIdAsync(int id)
        {
            return await context.ReservationServices.FindAsync(id);
        }

        public void Update(ReservationService reservationService)
        {
            context.ReservationServices.Update(reservationService);
            context.SaveChanges();
        }
    }
}

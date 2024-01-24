using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ReservationRepository(ApplicationDbContext _context) : IReservationRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

        public IQueryable<Reservation> GetAll()
        {
            return context.Reservations.AsQueryable();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await context.Reservations.FindAsync(id);
        }

        public void Update(Reservation reservation)
        {
            context.Reservations.Update(reservation);
            context.SaveChanges();
        }
    }
}

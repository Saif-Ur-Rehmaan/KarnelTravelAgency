using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Transport.RepoTransport
{
    public class BookedFlightsRepository(ApplicationDbContext context) : IBookedFlights
    {
        public void Add(BookedFlights BookedFlights)
        {
            context.BookedFlights.Add(BookedFlights);
            context.SaveChanges();
        }

        public void Delete(BookedFlights BookedFlights)
        {
            context.BookedFlights.Remove(BookedFlights);
            context.SaveChanges();
        }

        public IQueryable<BookedFlights> GetAll()
        {

         return  context.BookedFlights.AsQueryable();
        }

        public async Task<BookedFlights> GetByIdAsync(int id)
        {
         return  await context.BookedFlights.FindAsync(id);
        }

        public void Update(BookedFlights BookedFlights)
        {
            context.BookedFlights.Update(BookedFlights);
            context.SaveChanges();
        }
    }
}

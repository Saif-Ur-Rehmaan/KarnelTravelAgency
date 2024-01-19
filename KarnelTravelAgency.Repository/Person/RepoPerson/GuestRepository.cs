using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
namespace KarnelTravelAgency.Repository.Repo
{
    public class GuestRepository(ApplicationDbContext context) : IResortGuestRepository
    {
        private ApplicationDbContext _Context { get; set; }

        public void Add(ResortGuest resortGuest)
        {
            context.ResortGuests.Add(resortGuest);
            context.SaveChanges();
        }

        public void Delete(ResortGuest resortGuest)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ResortGuest> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResortGuest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ResortGuest resortGuest)
        {
            throw new NotImplementedException();
        }
    }
}

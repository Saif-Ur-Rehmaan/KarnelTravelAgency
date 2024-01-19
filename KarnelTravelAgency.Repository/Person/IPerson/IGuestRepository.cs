using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface GuestRepository
    {
        IQueryable<Guest> GetAll();
        Task<Guest> GetByIdAsync(int id);
        void Add(Guest guest);
        void Update(Guest guest);
        void Delete(Guest guest);
    }
}

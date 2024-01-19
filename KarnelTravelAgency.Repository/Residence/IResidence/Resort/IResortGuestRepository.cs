using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IResortGuestRepository
    {
        IQueryable<ResortGuest> GetAll();
        Task<ResortGuest> GetByIdAsync(int id);
        void Add(ResortGuest resortGuest);
        void Update(ResortGuest resortGuest);
        void Delete(ResortGuest resortGuest);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IGuestRepository
    {
        IQueryable<HotelGuest> GetAll();
        Task<HotelGuest> GetByIdAsync(int id);
        void Add(HotelGuest guest);
        void Update(HotelGuest guest);
        void Delete(HotelGuest guest);
    }
}

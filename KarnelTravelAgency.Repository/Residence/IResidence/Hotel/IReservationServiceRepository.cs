using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IReservationServiceRepository
    {
        IQueryable<ReservationService> GetAll();
        Task<ReservationService> GetByIdAsync(int id);
        void Add(ReservationService reservationService);
        void Update(ReservationService reservationService);
        void Delete(ReservationService reservationService);
    }
}

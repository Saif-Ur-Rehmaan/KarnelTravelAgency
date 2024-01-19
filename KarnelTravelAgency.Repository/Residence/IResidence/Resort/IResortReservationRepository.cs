using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IResortReservationRepository
    {
        IQueryable<ResortReservation> GetAll();
        Task<ResortReservation> GetByIdAsync(int id);
        void Add(ResortReservation resortReservation);
        void Update(ResortReservation resortReservation);
        void Delete(ResortReservation resortReservation);
    }
}

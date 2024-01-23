using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IResortReservationActivityRepository
    {
        IQueryable<ResortReservationActivity> GetAll();
        Task<ResortReservationActivity> GetByIdAsync(int id);
        void Add(ResortReservationActivity resortReservationActivity);
        void Update(ResortReservationActivity resortReservationActivity);
        void Delete(ResortReservationActivity resortReservationActivity);
    }
}

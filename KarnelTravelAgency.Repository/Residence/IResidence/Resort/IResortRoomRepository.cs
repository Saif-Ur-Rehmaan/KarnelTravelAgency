using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IResortRoomRepository
    {
        IQueryable<ResortRoom> GetAll();
        Task<ResortRoom> GetByIdAsync(int id);
        void Add(ResortRoom resortRoom);
        void Update(ResortRoom resortRoom);
        void Delete(ResortRoom resortRoom);
    }
}

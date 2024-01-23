using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IRoomRepository
    {
        IQueryable<Room> GetAll();
        Task<Room> GetByIdAsync(int id);
        void Add(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}

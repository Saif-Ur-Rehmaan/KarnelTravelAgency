using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class RoomRepository(ApplicationDbContext _context) : IRoomRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void Delete(Room room)
        {
            context.Rooms.Remove(room);
            context.SaveChanges();
        }

        public IQueryable<Room> GetAll()
        {
            return context.Rooms.AsQueryable();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await context.Rooms.FindAsync(id);
        }

        public void Update(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
        }
    }
}

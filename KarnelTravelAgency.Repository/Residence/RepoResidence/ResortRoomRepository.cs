using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ResortRoomRepository(ApplicationDbContext _context) : IResortRoomRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(ResortRoom resortRoom)
        {
            context.ResortRooms.Add(resortRoom);
            context.SaveChanges();
        }

        public void Delete(ResortRoom resortRoom)
        {
            context.ResortRooms.Remove(resortRoom);
            context.SaveChanges();
        }

        public IQueryable<ResortRoom> GetAll()
        {
            return context.ResortRooms.AsQueryable();
        }

        public async Task<ResortRoom> GetByIdAsync(int id)
        {
            return await context.ResortRooms.FindAsync(id);
        }

        public void Update(ResortRoom resortRoom)
        {
            context.ResortRooms.Update(resortRoom);
            context.SaveChanges();
        }
    }
}

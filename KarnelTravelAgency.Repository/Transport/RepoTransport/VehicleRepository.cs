using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class VehicleRepository(ApplicationDbContext _context) : IVehicleRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
        }

        public void Delete(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
            context.SaveChanges();
        }

        public IQueryable<Vehicle> GetAll()
        {
            return context.Vehicles.AsQueryable();
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await context.Vehicles.FindAsync(id);
        }

        public void Update(Vehicle vehicle)
        {
            context.Vehicles.Update(vehicle);
            context.SaveChanges();
        }
    }
}

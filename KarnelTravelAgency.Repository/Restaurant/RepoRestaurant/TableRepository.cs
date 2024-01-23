using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Repository.Repo
{
    public class TableRepository(ApplicationDbContext _context) : ITableRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Table table)
        {
            context.Tables.Add(table);
            context.SaveChanges();
        }

        public void Delete(Table table)
        {
            context.Tables.Remove(table);
            context.SaveChanges();
        }

        public IQueryable<Table> GetAll()
        {
            return context.Tables.AsQueryable();
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            return await context.Tables.FindAsync(id);
        }

        public void Update(Table table)
        {
            context.Tables.Update(table);
            context.SaveChanges();
        }
    }
}

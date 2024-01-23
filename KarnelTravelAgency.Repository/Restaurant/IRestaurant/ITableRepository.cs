using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface ITableRepository
    {
        IQueryable<Table> GetAll();
        Task<Table> GetByIdAsync(int id);
        void Add(Table table);
        void Update(Table table);
        void Delete(Table table);
    }
}

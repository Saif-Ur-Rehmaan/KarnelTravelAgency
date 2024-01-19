using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IResortRepository
    {
        IQueryable<Resort> GetAll();
        Task<Resort> GetByIdAsync(int id);
        void Add(Resort resort);
        void Update(Resort resort);
        void Delete(Resort resort);
    }

}

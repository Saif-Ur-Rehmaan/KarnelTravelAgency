using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IStateRepository
    {
        IQueryable<State> GetAll();
        Task<State> GetByIdAsync(int id);
        void Add(State state);
        void Update(State state);
        void Delete(State state);
    }
}

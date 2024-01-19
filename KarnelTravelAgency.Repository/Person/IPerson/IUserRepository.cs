using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> GetByIdAsync(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}

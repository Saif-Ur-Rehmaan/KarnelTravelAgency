using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IAdminRepository
    {
        IQueryable<Admin> GetAll();
        Task<Admin> GetByIdAsync(int id);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IResortActivityRepository
    {
        IQueryable<ResortActivity> GetAll();
        Task<ResortActivity> GetByIdAsync(int id);
        void Add(ResortActivity resortActivity);
        void Update(ResortActivity resortActivity);
        void Delete(ResortActivity resortActivity);
    }
}

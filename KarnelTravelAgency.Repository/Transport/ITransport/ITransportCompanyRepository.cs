using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface ITransportCompanyRepository
    {
        IQueryable<TransportCompany> GetAll();
        Task<TransportCompany> GetByIdAsync(int id);
        void Add(TransportCompany company);
        void Update(TransportCompany company);
        void Delete(TransportCompany company);
    }
}

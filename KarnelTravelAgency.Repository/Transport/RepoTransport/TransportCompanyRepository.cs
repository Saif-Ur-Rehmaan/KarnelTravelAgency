using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class TransportCompanyRepository(ApplicationDbContext _context) : ITransportCompanyRepository
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(TransportCompany company)
        {
            context.TransportCompanies.Add(company);
            context.SaveChanges();
        }

        public void Delete(TransportCompany company)
        {
            context.TransportCompanies.Remove(company);
            context.SaveChanges();
        }

        public IQueryable<TransportCompany> GetAll()
        {
            return context.TransportCompanies.AsQueryable();
        }

        public async Task<TransportCompany> GetByIdAsync(int id)
        {
            return await context.TransportCompanies.FindAsync(id);
        }

        public void Update(TransportCompany company)
        {
            context.TransportCompanies.Update(company);
            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAgency.Repository.Repo
{
    public class ContactRepo(ApplicationDbContext _context) : IContact
    {
        private ApplicationDbContext context { get; set; } = _context;
        public void Add(Contact Contact)
        {
            context.Contact.Add(Contact);
            context.SaveChanges();
        }

        public void Delete(Contact Contact)
        {
            context.Contact.Remove(Contact);
            context.SaveChanges();
        }

        public IQueryable<Contact> GetAll()
        {
            return context.Contact.AsQueryable();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await context.Contact.FindAsync(id);
        }

        public void Update(Contact Contact)
        {
            context.Contact.Update(Contact);
            context.SaveChanges();
        }
    }
}

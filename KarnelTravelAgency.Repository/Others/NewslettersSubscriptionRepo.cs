using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;
using KarnelTravelAgency.Repository.Interfaces;

namespace KarnelTravelAgency.Repository.Repo
{
    public class NewslettersSubscriptionRepo(ApplicationDbContext Context) : INewsLetter
    {
        public void Add(Core.NewslettersSubscription NewslettersSubscription)
        {
            Context.NewslettersSubscription.Add(NewslettersSubscription);
        }

        public void Delete(Core.NewslettersSubscription NewslettersSubscription)
        {
            Context.NewslettersSubscription.Remove(NewslettersSubscription);
        }

        public IQueryable<Core.NewslettersSubscription> GetAll()
        {
            return Context.NewslettersSubscription.AsQueryable();
        }

        public async Task<Core.NewslettersSubscription> GetByIdAsync(int id)
        {
            return Context.NewslettersSubscription.Find(id);
        }

        public void Update(Core.NewslettersSubscription NewslettersSubscription)
        {
            Context.NewslettersSubscription.Update(NewslettersSubscription);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    interface INewsLetter
    {
        IQueryable<NewslettersSubscription> GetAll();
        Task<NewslettersSubscription> GetByIdAsync(int id);
        void Add(NewslettersSubscription NewslettersSubscription);
        void Update(NewslettersSubscription NewslettersSubscription);
        void Delete(NewslettersSubscription NewslettersSubscription);
    }
}

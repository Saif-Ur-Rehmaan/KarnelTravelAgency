using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface IPackageMealRepository
    {
        IQueryable<PackageMeal> GetAll();
        Task<PackageMeal> GetByIdAsync(int id);
        void Add(PackageMeal packageMeal);
        void Update(PackageMeal packageMeal);
        void Delete(PackageMeal packageMeal);
    }
}

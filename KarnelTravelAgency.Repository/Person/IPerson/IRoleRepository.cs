﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarnelTravelAgency.Core;

namespace KarnelTravelAgency.Repository.Interfaces
{
    public interface RoleRepository
    {
        IQueryable<Role> GetAll();
        Task<Role> GetByIdAsync(int id);
        void Add(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
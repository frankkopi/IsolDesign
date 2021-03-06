﻿using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class EconomyRepository : Repository<Economy>, IEconomyRepository
    {
        public EconomyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

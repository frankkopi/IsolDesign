﻿using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class SubcontractorRepository : Repository<Subcontractor>, ISubcontractorRepository
    {
        public SubcontractorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
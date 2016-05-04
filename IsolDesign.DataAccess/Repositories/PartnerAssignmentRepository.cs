﻿using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class PartnerAssignmentRepository : Repository<Assignment>, IPartnerAssignmentRepository
    {
        public PartnerAssignmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
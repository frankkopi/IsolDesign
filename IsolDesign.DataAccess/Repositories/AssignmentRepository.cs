using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ISolDesign.DataAccess.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {

        public AssignmentRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Assignment> GetAllAss()
        {
            IQueryable<Assignment> linqQuery = from a in ApplicationDbContext.Assignments select a;
            List<Assignment> assignments = linqQuery.ToList();

            return assignments;
        }

        // casting the Context we inherit from the Repository<TEntity> to ApplicationDbContext
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

    }
}

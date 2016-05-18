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
            IQueryable<Assignment> linqQuery = from a in Context.Assignments select a;
            List<Assignment> assignments = linqQuery.ToList();

            return assignments;
        }

    }
}

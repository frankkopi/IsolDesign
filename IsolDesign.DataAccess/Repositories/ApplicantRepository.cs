using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Data.Entity;

namespace IsolDesign.DataAccess.Repositories
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApplicationDbContext context) : base(context)
        {

        }

        // Get all applicants including navigation properties
        public IQueryable<Applicant> AllIncluding(
            params Expression<Func<Applicant, object>>[] includeProperties)
        {
            IQueryable<Applicant> query = Context.Applicants;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}

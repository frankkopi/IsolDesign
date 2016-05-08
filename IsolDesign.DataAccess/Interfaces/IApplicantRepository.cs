using IsolDesign.Data.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IsolDesign.DataAccess.Interfaces
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        IQueryable<Applicant> AllIncluding(params Expression<Func<Applicant, object>>[] includeProperties);
    }
}

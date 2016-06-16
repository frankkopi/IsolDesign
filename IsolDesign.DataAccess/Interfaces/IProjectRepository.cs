using IsolDesign.Data.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IsolDesign.DataAccess.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties);
    }
}

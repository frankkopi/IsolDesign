using IsolDesign.Data.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IsolDesign.DataAccess.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        IQueryable<Team> AllIncluding(params Expression<Func<Team, object>>[] includeProperties);
    }
}

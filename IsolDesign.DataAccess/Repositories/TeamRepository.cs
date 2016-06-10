using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Data.Entity;

namespace IsolDesign.DataAccess.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {

        }

        // Get all Teams including navigation properties
        public IQueryable<Team> AllIncluding(params Expression<Func<Team, object>>[] includeProperties)
        {
            IQueryable<Team> query = ApplicationDbContext.Teams;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        // casting the Context we inherit from the Repository<TEntity> to ApplicationDbContext
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}

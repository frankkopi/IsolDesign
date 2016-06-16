using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Data.Entity;

namespace IsolDesign.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {

        }

        // Get all Projects including navigation properties
        public IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties)
        {
            IQueryable<Project> query = ApplicationDbContext.Projects;
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

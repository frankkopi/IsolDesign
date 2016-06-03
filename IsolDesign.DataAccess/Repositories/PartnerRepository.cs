using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Data.Entity;

namespace IsolDesign.DataAccess.Repository
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        public PartnerRepository(ApplicationDbContext context) : base(context)
        {

        }

        // Get all partners including navigation properties
        public IQueryable<Partner> AllIncluding(params Expression<Func<Partner, object>>[] includeProperties)
        {
            IQueryable<Partner> query = ApplicationDbContext.Partners;
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

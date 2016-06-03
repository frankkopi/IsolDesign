using IsolDesign.Data.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IsolDesign.DataAccess.Interfaces
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        IQueryable<Partner> AllIncluding(params Expression<Func<Partner, object>>[] includeProperties);
    }
}

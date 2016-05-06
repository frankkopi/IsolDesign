using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class DevMethodRepository : Repository<DevMethod>, IDevMethodRepository
    {
        public DevMethodRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

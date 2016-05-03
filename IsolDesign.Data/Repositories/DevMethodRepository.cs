using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class DevMethodRepository : Repository<DevMethod>, IDevMethodRepository
    {
        public DevMethodRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class EconomyRepository : Repository<Economy>, IEconomyRepository
    {
        public EconomyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

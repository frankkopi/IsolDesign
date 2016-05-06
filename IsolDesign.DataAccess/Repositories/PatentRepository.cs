using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class PatentRepository : Repository<Patent>, IPatentRepository
    {
        public PatentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

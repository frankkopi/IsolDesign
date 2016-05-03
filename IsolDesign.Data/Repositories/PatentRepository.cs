using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class PatentRepository : Repository<Patent>, IPatentRepository
    {
        public PatentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class PortfolioSubjectRepository : Repository<PortfolioSubject>, IPortfolioSubjectRepository
    {
        public PortfolioSubjectRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

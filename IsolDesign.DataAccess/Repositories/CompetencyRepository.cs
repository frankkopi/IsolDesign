using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class CompetencyRepository : Repository<Competency>, ICompetencyRepository
    {
        public CompetencyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

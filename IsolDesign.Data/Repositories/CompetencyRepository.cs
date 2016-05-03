using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class CompetencyRepository : Repository<Competency>, ICompetencyRepository
    {
        public CompetencyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

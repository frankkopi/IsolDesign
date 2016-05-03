using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class SubcontractorRepository : Repository<Subcontractor>, ISubcontractorRepository
    {
        public SubcontractorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

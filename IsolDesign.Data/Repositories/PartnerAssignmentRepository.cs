using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class PartnerAssignmentRepository : Repository<Assignment>, IPartnerAssignmentRepository
    {
        public PartnerAssignmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

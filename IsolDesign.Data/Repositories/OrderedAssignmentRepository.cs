using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class OrderedAssignmentRepository : Repository<Assignment>, IOrderedAssignmentRepository
    {
        public OrderedAssignmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

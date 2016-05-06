using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class OrderedAssignmentRepository : Repository<Assignment>, IOrderedAssignmentRepository
    {
        public OrderedAssignmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

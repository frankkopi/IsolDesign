using IsolDesign.Data.Models;
using System.Collections.Generic;

namespace IsolDesign.DataAccess.Interfaces
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        IEnumerable<Assignment> GetAllAss();
    }
}

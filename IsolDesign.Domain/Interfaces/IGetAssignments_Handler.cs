using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetAssignments_Handler
    {
        IEnumerable<AssignmentModel> GetAssignments();
    }
}

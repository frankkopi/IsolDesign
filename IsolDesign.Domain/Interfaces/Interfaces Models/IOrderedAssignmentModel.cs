using System;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Interfaces.Interfaces_Models
{
    public interface IOrderedAssignmentModel : IAssignmentModel
    {
        DateTime Deadline { get; set; }
        int CustomerId { get; set; } // FK

        CustomerModel Customer { get; set; } // Customer who placed the order
    }
}

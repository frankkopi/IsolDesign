using System;
using System.ComponentModel.DataAnnotations;
using IsolDesign.Domain.Interfaces.Interfaces_Models;

namespace IsolDesign.Domain.Models
{
    public class OrderedAssignmentModel : AssignmentModel, IOrderedAssignmentModel
    {
        public DateTime Deadline { get; set; }

        public int CustomerId { get; set; } // FK


        public virtual CustomerModel Customer { get; set; }
    }
}

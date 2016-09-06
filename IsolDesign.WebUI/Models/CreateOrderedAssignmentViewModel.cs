using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.WebUI.Models
{
    public class CreateOrderedAssignmentViewModel
    {
        public OrderedAssignmentModel orderedAssignmentModel { get; set; } 

        public IEnumerable<CustomerModel> Customers { get; set; }
    }
}
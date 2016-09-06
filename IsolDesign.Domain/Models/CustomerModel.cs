using IsolDesign.Data.Enums;
using System.Collections.Generic;

namespace IsolDesign.Domain.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public CategoryType Category { get; set; }

        public string Homepage { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }


        public virtual ICollection<OrderedAssignmentModel> Assignments { get; set; }
    }
}

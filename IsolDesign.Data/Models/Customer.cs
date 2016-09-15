using System.Collections.Generic;
using IsolDesign.Data.Enums;

namespace IsolDesign.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public CustomerCategory Category { get; set; }

        public string Homepage { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }


        public virtual ICollection<OrderedAssignment> Assignments { get; set; }
    }
}

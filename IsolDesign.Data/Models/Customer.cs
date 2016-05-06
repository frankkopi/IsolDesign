using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Data.Models
{

    public enum CategoryType
    {
        //[Display(Name = "High Level")]
        high = 1,

        //[Display(Name = "Mid Level")]
        middel = 2,
        //[Display(Name = "Low Level")]
        low = 3
    }

    public class Customer
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


        public virtual ICollection<OrderedAssignment> Assignments { get; set; }
    }
}

using System;

namespace IsolDesign.Data.Models
{
    public class OrderedAssignment : Assignment
    {
        public DateTime Deadline { get; set; }

        public int CustomerId { get; set; } // FK


        public virtual Customer Customer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.DataAccess.Models
{
    public class OrderedAssignment : Assignment
    {
        public DateTime Deadline { get; set; }

        public int CustomerId { get; set; } // FK


        public virtual Customer Customer { get; set; }
    }
}

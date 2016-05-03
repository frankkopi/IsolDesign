using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Data.Models
{
    // Assignment is parent class for PartnerAssignment and OrderedAssignment
    public abstract class Assignment
    {
        public int AssignmentId { get; set; }

        public string WorkTitle { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string Drawing { get; set; }

        public string Video { get; set; }

    }
}

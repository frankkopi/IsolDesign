using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Data.Models
{
    public enum AssignmentType
    {
        PartnerAssignment = 1,
        OrderedAssignment = 2
    }


    // Assignment is parent class for PartnerAssignment and OrderedAssignment
    public abstract class Assignment
    {
        public int AssignmentId { get; set; }

        public string WorkTitle { get; set; }

        public AssignmentType Type { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string Drawing { get; set; }

        public string Video { get; set; }

    }
}

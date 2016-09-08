using System.ComponentModel.DataAnnotations;
using IsolDesign.Data.Enums;

namespace IsolDesign.Data.Models
{

    // Assignment is parent class for PartnerAssignment and OrderedAssignment
    public abstract class Assignment
    {
        public int AssignmentId { get; set; }

        public string WorkTitle { get; set; }

        public AssignmentType Type { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; } // path to photo

        public string Drawing { get; set; } // path to drawing

        public string Video { get; set; } // path to video

    }
}

using System.ComponentModel.DataAnnotations;
using IsolDesign.Domain.Interfaces.Interfaces_Models;

namespace IsolDesign.Domain.Models
{
    public enum AssignmentType
    {
        [Display(Name = "Partner Assignment")]
        PartnerAssignment = 1,
        [Display(Name = "Ordered Assignment")]
        OrderedAssignment = 2,
    }

    public class AssignmentModel : IAssignmentModel
    {
        public int AssignmentId { get; set; }

        [Required(ErrorMessage = "Work Title is required")]
        [Display(Name = "Assignment Work Title")]
        public string WorkTitle { get; set; }

        public AssignmentType? Type { get; set; }

        //public string Type { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string Photo { get; set; }

        public string Drawing { get; set; }

        public string Video { get; set; }

    }
}

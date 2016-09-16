using System.ComponentModel.DataAnnotations;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using IsolDesign.Data.Enums;
using IsolDesign.Domain.Helpers;

namespace IsolDesign.Domain.Models
{

    public class AssignmentModel : IAssignmentModel
    {
        public int AssignmentId { get; set; }

        [Required(ErrorMessage = "Work Title is required")]
        [Display(Name = "Work Title")]
        public string WorkTitle { get; set; }

        public AssignmentType? Type { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description must be between 20 and 500 characters", MinimumLength = 20)]
        public string Description { get; set; }

        public string Photo { get; set; }

        public string Drawing { get; set; }

        public string Video { get; set; }

        // Gets the string from the Display(Name = "") attribute in the AssignmentType enum
        public string DisplayName(AssignmentType? enumValue)
        {
            return GetDisplayNameFromEnum_Helper.GetDisplayName(enumValue);
        }
    }
}

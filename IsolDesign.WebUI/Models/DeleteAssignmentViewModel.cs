using IsolDesign.Domain.Models;
using IsolDesign.Domain.Helpers;
using IsolDesign.Data.Enums;

namespace IsolDesign.WebUI.Models
{
    public class DeleteAssignmentViewModel
    {
        public AssignmentModel AssignmentModel { get; set; }

        public string DisplayName(AssignmentType? enumValue)
        {
            return GetDisplayNameFromEnum_Helper.GetDisplayName(enumValue);
        }
    }
}